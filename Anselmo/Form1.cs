namespace Anselmo
{
    public partial class Form1 : Form
    {
        private Queue<CUovo> fabbrica = new Queue<CUovo>(); //Dichiaro una coda per contenere la fabbrica con uova inizializzate casualmente
        private Queue<CUovo> prato = new Queue<CUovo>();    //Dichiaro una coda per contenere il prato con uova riordinate correttamente con il backtracking
        private Random rnd = new Random();  //Creo un generatore di numeri casuali
        private List<string> colori = new List<string> { "Verde", "Azzurro", "Giallo", "Arancione", "Rosa", "Viola" };  //Definisco i colori possibili per le uova
        private bool isRunning = false; //Flag per controllare se l'algoritmo è in esecuzione
        private bool shouldStop = false; //Flag per interrompere l'algoritmo
        private int movimentiEffettuati = 0; //Contatore dei movimenti effettuati (per informazioni logger)
        private int backtrackEseguiti = 0; //Contatore dei backtrack eseguiti   (per informazioni logger)
        private int numeroUova; //Numero di metà uova per colore

        //ELEMENTI GRAFICI DEL FORM1
        private Panel panelFabbrica; //Panel per visualizzare le uova in fabbrica
        private Panel panelPrato; //Panel per visualizzare le uova nel prato
        private TrackBar trackBar; //TrackBar per regolare la velocità dell'animazione
        private System.Windows.Forms.Timer timer; //Timer per gli aggiornare l'interfaccia
        private Label lblVelocita; //Label per mostrare la velocità attuale
        private Label lblStatoAttuale; //Label per mostrare lo stato dell'algoritmo
        private Button btnMostraLog; //Pulsante per visualizzare il log
        private PictureBox picConiglio; //Immagine di Anselmo
        private Label lblFabbrica; //Label per la fabbrica
        private Label lblPrato; //Label per il prato
        private Button btnStart; //Pulsante per avviare l'algoritmo
        private Button btnStop; //Pulsante per fermare l'algoritmo
        private Button btnReset; //Pulsante per resettare l'algoritmo
        private Button btnTornaIndietro; //Pulsante per tornare al form iniziale
        private Label lblVelocitaMin; //Label per la velocità minima
        private Label lblVelocitaMax; //Label per la velocità massima
        public FormStart FormStartReference { get; set; } //Riferimento al formStart

        //Costruttore del Form1 che accetta come parametro il numero di metà uova per colore
        public Form1(int numeroUova)
        {
            InitializeComponent(); //Vedi From1.Designer.cs per ulteriori informazioni

            this.numeroUova = numeroUova;   //Salvo il parametro passati dal formStart
            int velocita = 1000; //Imposto la velocità iniziale a 1000ms

            Logger.Inizializza();   //Inizializzo il logger
            Logger.Log($"Applicazione avviata con {numeroUova} metà per colore");   //Scrivo nel logger che l'applicazione è stata avviata con successo

            trackBar.Value = velocita;  //Imposto valore iniziale della trackBar
            lblVelocita.Text = $"Velocità: {trackBar.Value} ms";    //Aggiorno la label con la nuova velocità

            this.Resize += Form1_Resize;    //Gestisco il ridimensionamento del Form1
        }

        //Metodo per inizializzare le uova
        private void InizializzaUova()
        {
            fabbrica.Clear(); //Svuoto la coda della fabbrica per evitare errori
            List<string> metaUova = new List<string>(); //Creo una lista che conterrà le metà uova generate
            int metaPerColore = numeroUova; //Imposto il numero di metà per colore in base al parametrop

            foreach (string colore in colori)   //Per ogni colore nella lista di colori definita all'inizio
            {
                for (int i = 0; i < metaPerColore; i++)
                    metaUova.Add(colore); //Aggiungo tante metà uova per ogni colore quante indicate dal parametro
            }

            metaUova = metaUova.OrderBy(x => rnd.Next()).ToList();  //Mescolo le metà delle uova in modo casuale

            while (metaUova.Count >= 2) //Creo le uova prendendo due colori alla volta
            {
                string c1 = metaUova[0]; //Prendo il primo colore
                string c2 = metaUova[1]; //Prendo il secondo colore

                metaUova.RemoveAt(0); //Rimuovo il primo colore dalla lista di metà
                metaUova.RemoveAt(0); //Rimuovo il secondo colore dalla lista di metà

                fabbrica.Enqueue(new CUovo(c1, c2)); //Aggiungo alla fabbrica un nuovo uovo creato con le due metà prese
            }

            Logger.Log($"Inizializzate {fabbrica.Count} uova con colori casuali");  //Scrivo nel logger che le uova sono state generate correttamente
        }

        //Metodo per gestire la grafica delle uova in un panel dato (posizione nel panel)
        private void DisegnaUova(Panel panel, Queue<CUovo> uova)
        {
            panel.Controls.Clear(); //Pulisco il panel per evitare errori
            int x; //Posizione x iniziale
            int y; //Posizione y iniziale
            int maxWidth = panel.Width - 80; //Calcolo larghezza massima disponibile con un margine

            float fattoreScalaLarghezza = Math.Max(1.0f, panel.Width / 860.0f); //Calcolo il fattore di scala in base alla larghezza del panel
            float FattoreScalaAltezza = Math.Max(1.0f, panel.Height / (panel == panelFabbrica ? 150.0f : 250.0f));  //Calcolo il fattore di scala in base all'altezza del panel

            float fattoreScala = Math.Min(fattoreScalaLarghezza, FattoreScalaAltezza);   //Uso il minore tra i due per mantenere le proporzioni

            int larghezzaUovo = (int)((70 + 10) * fattoreScala);    //Calcolo la larghezza dell'uovo in base al fattore di scala
            int altezzaUovo = (int)((90 + 10) * fattoreScala);  //Calcolo l'altezza dell'uovo in base al fattore di scala

            int uovaPerRiga = Math.Max(1, maxWidth / larghezzaUovo);    //Calcolo quante uova possono stare al massimo su una riga

            int indice = 0; //Inizializzo un indice 
            foreach (CUovo uovo in uova)    //Per ogni uovo nella coda di uova passata come parametro
            {
                CUovo uovoGrafico = new CUovo(uovo.Colore1, uovo.Colore2, fattoreScala); //Creo un nuovo uovo passando anche il fattore di scala

                //Calcolo la posizione basata sull'indice
                int riga = indice / uovaPerRiga;
                int colonna = indice % uovaPerRiga;

                x = 10 + colonna * larghezzaUovo; //Calcolo posizione x
                y = 10 + riga * altezzaUovo; //Calcolo posizione y

                uovoGrafico.Location = new Point(x, y); //Imposto la posizione dell'uovo
                panel.Controls.Add(uovoGrafico); //Aggiungo l'uovo al panel (questo include anche il diegno dell'uovo perché CUovo eredita da Control)

                indice++;   //Incremento l'indice
            }

            //Aggiorno l'altezza minima del contenuto del panel per lo scrolling
            int altezzaTotale = 10 + ((indice + uovaPerRiga - 1) / uovaPerRiga) * altezzaUovo;
            panel.AutoScrollMinSize = new Size(0, altezzaTotale + 20);
        }

        //Metodo per gestire i ritardi con l'animazione
        private async Task Ritardo(double fattore = 1.0)
        { 
            await Task.Delay((int)(trackBar.Value * fattore));  //Scelgo un ritardo in base al fattore e al valore della TrackBar
            Application.DoEvents(); //Permetto all'interfaccia di aggiornarsi
        }

        //Metodo per nascondere le uova
        private async Task<bool> NascondiUova()
        {
            prato.Clear(); //Svuoto il prato per evitare errori
            return await ProvaPiazzamento(new Queue<CUovo>(), new Queue<CUovo>(fabbrica)); //Avvio l'algoritmo di backtracking
        }

        //Metodo per il posizionamento delle uova nel prato
        private async Task<bool> ProvaPiazzamento(Queue<CUovo> pratoParziale, Queue<CUovo> codaRimanente)   //I parametri sono due code:
            //1. la prima contiene il prato parziale, quidni le uova che sono in quel momento all'interno del prato
            //2. la seconda contiene la fabbrica restante con le uova che devono ancora essere posizionate
        {
            DisegnaUova(panelPrato, pratoParziale); //Disegno le uova rimanenti nel prato
            DisegnaUova(panelFabbrica, codaRimanente); //Disegno le uova rimanenti in fabbrica

            await Ritardo(); //Aggiungo un ritardo chiamando la funzione apposita per fare in modo di avere una sorta di animazione

            if (shouldStop) //Se viene richiesto di stoppare l'esecuzione
                return false; //Interrompo ritornando false, non sono riuscito a piazzare tutte le uova

            if (codaRimanente.Count == 0)   //Se in fabbrica non ci sono più uova
            {
                prato = new Queue<CUovo>(pratoParziale); //Salvo la soluzione completa che ho trovato
                Logger.Log($"Soluzione trovata! Tutte le {pratoParziale.Count} uova piazzate correttamente");   //Lo scrivo nel logger
                return true;    //Ritorno true, ho completato l'esecuzione
            }

            bool trovatoSoluzione = false;  //Variabile booleana che indica se la soluzione è stata trovata
            List<CUovo> uovaDaProvare = new List<CUovo>(codaRimanente); //Creo una lista delle uova rimanenti da provare

            foreach (CUovo candidato in uovaDaProvare)  //Per ogni uovo candidato nelle uova da provare 
            {
                List<CUovo> tempList = new List<CUovo>(codaRimanente);  //Inizializzo una lista temporanea
                tempList.Remove(candidato); //Rimuovo il candidato dalla lista temporanea usando l'ID
                Queue<CUovo> nuovaCodaRimanente = new Queue<CUovo>(tempList); //Creo una nuova coda senza il candidato

                if (pratoParziale.Count == 0 || candidato.HaColoreInComune(pratoParziale.Last()))   //Se il prato parziale non ha elementi
                    //o il candidato ha un colo il comune con l'ultimo elemento del prato parziale
                {
                    Queue<CUovo> nuovoPrato = new Queue<CUovo>(pratoParziale);  //Creo un nuovo prato
                    nuovoPrato.Enqueue(candidato); //Aggiungo il candidato al nuovo prato
                    movimentiEffettuati++; //Incremento il contatore dei movimenti

                    string logInfo = $"Provo uovo {candidato.Colore1}/{candidato.Colore2}, rimanenti: {nuovaCodaRimanente.Count}";  //Scrivo nel logger che tento di piazzare l'uovo
                    Logger.Log(logInfo); //Registro l'operazione nel logger

                    DisegnaUova(panelFabbrica, nuovaCodaRimanente); //Aggiorno la visualizzazione della fabbrica
                    DisegnaUova(panelPrato, nuovoPrato); //Aggiorno la visualizzazione del prato

                    await Ritardo(0.5); //Aggiungo un breve ritardo

                    if (shouldStop) //Se viene richiesto di stoppare l'esecuzione
                        return false; //Interrompo ritornando false... non sono ancora riuscito a piazzare tutte le uova

                    trovatoSoluzione = await ProvaPiazzamento(nuovoPrato, nuovaCodaRimanente); //Continuo ricorsivamente

                    if (trovatoSoluzione)   //Se ho trovato una soluzione
                        return true; //Ritorno true
                    else
                    {
                        backtrackEseguiti++; //Incremento il contatore dei backtrack
                        Logger.Log($"Backtrack - rimozione uovo {candidato.Colore1}/{candidato.Colore2}");  //Scrivo nel logger che ho effettuato un'operazione di backtracking
                    }
                }
                else //Altrimenti se l'uovo non ha colori in comune con il successivo
                {
                    Logger.Log($"Scartato uovo {candidato.Colore1}/{candidato.Colore2} - colori non compatibili");  //Scrivo nel logger che l'ho scartato
                }
            }
            return trovatoSoluzione; //Ritorno lo stato della soluzione (che deve essere sempre false fino al ritrovamento della soluzione)
        }
    }
}