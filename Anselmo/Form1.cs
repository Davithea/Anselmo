using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anselmo
{
    public partial class Form1 : Form
    {
        private Queue<CUovo> fabbrica = new Queue<CUovo>();
        private Queue<CUovo> prato = new Queue<CUovo>();

        private Random rnd = new Random();
        private List<string> colori = new List<string> { "Verde", "Azzurro", "Giallo", "Arancione", "Rosa", "Viola" };

        private bool isRunning = false;
        private bool shouldStop = false;
        private int movimentiEffettuati = 0;
        private int backtrackEseguiti = 0;

        private int numeroUova;

        private Panel panelFabbrica;
        private Panel panelPrato;
        private TrackBar trackBar;
        private System.Windows.Forms.Timer timer;
        private Label lblVelocita;
        private Label lblStatoAttuale;
        private Button btnMostraLog;
        private PictureBox picConiglio;
        private Label lblIniziale;
        private Label lblPrato;
        private Button btnStart;
        private Button btnStop;
        private Button btnReset;
        private Button btnTornaIndietro;
        private Label lblVelocitaMin;
        private Label lblVelocitaMax;
        public FormStart FormStartReference { get; set; }
        public Form1(int numeroUova)
        {
            InitializeComponent();
            this.Text = "Nascondi le Uova - Anselmo";
            this.AutoScroll = true;
            this.Shown += Form1_Shown;

            // Imposta la dimensione minima del form alle dimensioni iniziali
            this.MinimumSize = new Size(900, 600);

            // Salva i parametri passati dal form di benvenuto
            this.numeroUova = numeroUova;
            int velocita = 1000;

            // Inizializza il logger
            Logger.Initialize();
            Logger.Log($"Applicazione avviata con {numeroUova} metà per colore");

            // Imposta valore iniziale della trackBar e aggiorna la label
            trackBar.Value = velocita;
            lblVelocita.Text = $"Velocità: {trackBar.Value} ms";

            // Rimuoviamo il vecchio handler e aggiungiamo quello nuovo
            this.Resize += Form1_Resize;
        }

        // Helper per gestire i ritardi con animazione
        private async Task DelayWithAnimation(double factor = 1.0)
        {
            // factor = 1 è il ritardo completo, 0.5 è mezzo ritardo, ecc.
            await Task.Delay((int)(trackBar.Value * factor));
            Application.DoEvents(); // Permette all'UI di aggiornarsi
        }

        private async Task<bool> NascondiUova()
        {
            prato.Clear();
            return await ProvaPiazzamento(new Queue<CUovo>(), new Queue<CUovo>(fabbrica));
        }

        private async Task<bool> ProvaPiazzamento(Queue<CUovo> pratoParziale, Queue<CUovo> codaRimanente)
        {
            DisegnaUova(panelPrato, pratoParziale);
            DisegnaUova(panelFabbrica, codaRimanente);

            await DelayWithAnimation();

            if (shouldStop)
                return false;

            if (codaRimanente.Count == 0)
            {
                prato = new Queue<CUovo>(pratoParziale);
                Logger.Log($"Soluzione trovata! Tutte le {pratoParziale.Count} uova piazzate correttamente");
                return true;
            }

            bool trovatoSoluzione = false;
            List<CUovo> uovaDaProvare = new List<CUovo>(codaRimanente);

            foreach (CUovo candidato in uovaDaProvare)
            {
                // Rimuovi SOLO il candidato specifico dalla coda rimanente
                List<CUovo> tempList = new List<CUovo>(codaRimanente);
                tempList.Remove(candidato); // Questo ora usa l'ID per la rimozione
                Queue<CUovo> nuovaCodaRimanente = new Queue<CUovo>(tempList);

                if (pratoParziale.Count == 0 || candidato.HaColoreInComune(pratoParziale.Last()))
                {
                    // Resto del codice come prima
                    var nuovoPrato = new Queue<CUovo>(pratoParziale);
                    nuovoPrato.Enqueue(candidato);
                    movimentiEffettuati++;

                    string logInfo = $"Provo uovo {candidato.Colore1}/{candidato.Colore2}, rimanenti: {nuovaCodaRimanente.Count}";
                    Logger.Log(logInfo);

                    DisegnaUova(panelFabbrica, nuovaCodaRimanente);
                    DisegnaUova(panelPrato, nuovoPrato);

                    await DelayWithAnimation(0.5);

                    if (shouldStop)
                        return false;

                    trovatoSoluzione = await ProvaPiazzamento(nuovoPrato, nuovaCodaRimanente);

                    if (trovatoSoluzione)
                        return true;
                    else
                    {
                        backtrackEseguiti++;
                        Logger.Log($"Backtrack - rimozione uovo {candidato.Colore1}/{candidato.Colore2}");
                    }
                }
                else
                {
                    Logger.Log($"Scartato uovo {candidato.Colore1}/{candidato.Colore2} - colori non compatibili");
                }
            }
            return trovatoSoluzione;
        }

        private void DisegnaUova(Panel panel, Queue<CUovo> uova)
        {
            panel.Controls.Clear();
            int x = 10;
            int y = 10;
            int maxWidth = panel.Width - 80; // Lascia spazio per evitare troncamenti

            // Calcola il fattore di scala in base sia alla larghezza che all'altezza del pannello
            float scaleFactorWidth = Math.Max(1.0f, panel.Width / 860.0f);
            float scaleFactorHeight = Math.Max(1.0f, panel.Height / (panel == panelFabbrica ? 150.0f : 250.0f));

            // Usa il minore tra i due per mantenere le proporzioni
            float scaleFactor = Math.Min(scaleFactorWidth, scaleFactorHeight);

            // Larghezza effettiva dell'uovo con il margine, considerando la scala
            int effectiveEggWidth = (int)((70 + 10) * scaleFactor);
            int effectiveEggHeight = (int)((90 + 10) * scaleFactor);

            // Calcola quante uova possono stare su una riga
            int uovaPerRiga = Math.Max(1, maxWidth / effectiveEggWidth);

            int indice = 0;
            foreach (CUovo uovo in uova)
            {
                CUovo uovoControl = new CUovo(uovo.Colore1, uovo.Colore2, scaleFactor);

                // Calcola la posizione basata sull'indice
                int riga = indice / uovaPerRiga;
                int colonna = indice % uovaPerRiga;

                x = 10 + colonna * effectiveEggWidth;
                y = 10 + riga * effectiveEggHeight;

                uovoControl.Location = new Point(x, y);
                panel.Controls.Add(uovoControl);

                indice++;
            }

            // Aggiorna l'altezza minima del contenuto del pannello per lo scrolling
            int altezzaTotale = 10 + ((indice + uovaPerRiga - 1) / uovaPerRiga) * effectiveEggHeight;
            panel.AutoScrollMinSize = new Size(0, altezzaTotale + 20);
        }

        private void InizializzaUova()
        {
            fabbrica.Clear();
            List<string> metaUova = new List<string>();
            int metaPerColore = numeroUova;

            foreach (string colore in colori)
            {
                for (int i = 0; i < metaPerColore; i++)
                    metaUova.Add(colore);
            }

            // Mescola le metà delle uova
            metaUova = metaUova.OrderBy(x => rnd.Next()).ToList();

            // Crea le uova con due colori
            while (metaUova.Count >= 2)
            {
                string c1 = metaUova[0];
                string c2 = metaUova[1];

                metaUova.RemoveAt(0);
                metaUova.RemoveAt(0);

                fabbrica.Enqueue(new CUovo(c1, c2));
            }

            Logger.Log($"Inizializzate {fabbrica.Count} uova con colori casuali");
        }
    }
}