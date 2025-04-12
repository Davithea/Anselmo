namespace Anselmo
{
    public partial class Form1 : Form
    {
        private Queue<CUovo> fabbrica = new Queue<CUovo>();
        private List<CUovo> prato = new List<CUovo>();
        private Random rnd = new Random();
        private List<string> colori = new List<string> { "Verde", "Azzurro", "Giallo", "Arancione", "Rosa", "Viola" };
        private List<CUovo> codaIniziale = new List<CUovo>(); // Nuova variabile per la copia originale

        public Form1()
        {
            InitializeComponent();
            InizializzaUova();

            if (NascondiUova())
                MessageBox.Show("Sequenza completata!");
            else
                MessageBox.Show("Impossibile completare la sequenza."); 

            MostraRisultato();
        }

        private void InizializzaUova()
        {
            List<string> metaUova = new List<string>();
            int copiePerColore = 3; // Numero di metà per ogni colore (totale: 6 * 5 = 30 -> 15 uova)

            // Genera 5 metà per ciascun colore
            foreach (string colore in colori)
            {
                for (int i = 0; i < copiePerColore; i++)
                    metaUova.Add(colore);
            }

            // Mescola le metà
            metaUova = metaUova.OrderBy(x => rnd.Next()).ToList();

            // Combina a due a due in uova
            while (metaUova.Count >= 2)
            {
                string c1 = metaUova[0];
                string c2 = metaUova[1];
                metaUova.RemoveAt(0);
                metaUova.RemoveAt(0);

                CUovo uovo = new CUovo(c1, c2);
                fabbrica.Enqueue(uovo);
                codaIniziale.Add(new CUovo(c1, c2)); // Copia per visualizzare l'ordine iniziale
            }
        }



        private bool NascondiUova()
        {
            return ProvaPiazzamento(new List<CUovo>(), fabbrica.ToList());
        }

        private bool ProvaPiazzamento(List<CUovo> pratoParziale, List<CUovo> rimanenti)
        {
            // Caso base: tutte le uova sono piazzate
            if (rimanenti.Count == 0)
            {
                prato = pratoParziale; // Salva la soluzione trovata
                return true;
            }

            for (int i = 0; i < rimanenti.Count; i++)
            {
                CUovo candidato = rimanenti[i];

                // Verifica regola: deve avere almeno un colore in comune con l'ultimo del prato
                if (pratoParziale.Count == 0 || candidato.HaColoreInComune(pratoParziale.Last()))
                {
                    // Fai la scelta
                    List<CUovo> nuovoPrato = new List<CUovo>(pratoParziale) { candidato };
                    List<CUovo> nuoveRimanenti = new List<CUovo>(rimanenti);
                    nuoveRimanenti.RemoveAt(i);

                    // Ricorsione
                    if (ProvaPiazzamento(nuovoPrato, nuoveRimanenti))
                        return true;
                }
            }

            // Nessuna scelta valida → backtrack
            return false;
        }


        private void MostraRisultato()
        {
            listBoxIniziale.Items.Clear();
            foreach (CUovo u in codaIniziale)
                listBoxIniziale.Items.Add(u.ToString());

            listBoxPrato.Items.Clear();
            foreach (CUovo u in prato)
                listBoxPrato.Items.Add(u.ToString());
        }

    }
}
