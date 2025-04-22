using System.Windows.Forms;

namespace Anselmo
{
    partial class FormStart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>


        private void InitializeComponent()  //Funzione per l'inizializzazione del formStart
        {
            this.Text = "Home";    //Testo che compare in alto a sinistra del formStart
            this.StartPosition = FormStartPosition.CenterScreen;    //Il fromStart deve essere centrato nello schermo quando viene creato
            this.FormBorderStyle = FormBorderStyle.FixedDialog;     //Funzione per rendere il formStart non ridimensionabile
            this.MaximizeBox = false;   //Impedisce che venga mostrato il pulsante in alto a destra del form per metterlo a schermo intera
            this.MinimizeBox = false;   //Impedisce che venga mostrato il pulsante in alto a destra del form per ridurlo a icona
            this.Icon = new Icon("Icons/homeIcon.ico");	//Icona del form
            this.ClientSize = new Size(600, 500);   //Inizializzo la dimensione iniziale del form
            this.BackColor = ColorTranslator.FromHtml("#fffdd0"); //Colore dello sfondo --> fffdd0 (giallo)

            //IMMAGINI
            PictureBox imgGatto1 = new PictureBox   //Creo una nuova pictureBox poer contenere una delle due immagini del form
            {
                Image = Image.FromFile("1.png"),    //Seleziono l'immagine "1.png"
                Location = new Point(20, 350),  //Scelgo il punto in cui metterla
                Size = new Size(130, 130),  //Scelgo la dimensione che dovrà avere
                SizeMode = PictureBoxSizeMode.Zoom  //Seleziono la modalità di visualizzazione a Zoom
            };
            this.Controls.Add(imgGatto1);   //Aggiungo la pictureBox al form

            PictureBox imgGatto2 = new PictureBox   //Creo una nuova pictureBox poer contenere una delle due immagini del form
            {
                Image = Image.FromFile("2.png"),    //Seleziono l'immagine "2.png"
                Location = new Point(470, 350),     //Scelgo il punto in cui metterla
                Size = new Size(130, 130),  //Scelgo la dimensione che dovrà avere
                SizeMode = PictureBoxSizeMode.Zoom  //Seleziono la modalità di visualizzazione a Zoom
            };
            this.Controls.Add(imgGatto2);   //Aggiungo la pictureBox al form

            //TITOLO
            lblTitolo = new Label   //Creo una label per il titolo
            {
                Text = "🐣 Nascondi le Uova!",   //Scrivo il testo che dovrà contenere
                Font = new Font("Segoe UI", 22, FontStyle.Bold),    //Seleziono alcune specifiche realtive al Font
                AutoSize = true,    //Adatto la dimensione del testo alla label
                ForeColor = Color.Black,    //Il colore del testo sarà nero
                Location = new Point(150, 20)   //Dico la posizione che dovrà avere questa label
            };
            this.Controls.Add(lblTitolo);   //Aggiugno la label al form

            //DESCRIZIONE
            lblDescrizione = new Label  //Creo una label per la descrizione
            {
                Text = "Benvenuto! Scegli quante uova vuoi nascondere per colore.", //Scrivo il testo che dovrà contenere
                Location = new Point(30, 80),   //Determino la posizione che dovrà avere
                Size = new Size(540, 40),   //Determino la dimensione che dovrà avere
                Font = new Font("Segoe UI", 12),    //Seleziono alcune specifiche relative al Font
                ForeColor = Color.Black     //Il colore del testo sarà nero
            };
            this.Controls.Add(lblDescrizione);  //Aggiungo la label al form

            //LABEL_UOVA
            lblUova = new Label //Creo una label per chiedere il numero di metà per colore che si volgiono inizializzare
            {
                Text = "Numero di metà per colore:",    //Scrivo il testo che dovrà contenere
                Location = new Point(30, 150),  //Determino la posizione che dovrà avere
                Size = new Size(250, 30),   //Determino la dimensione che dovrà avere
                Font = new Font("Segoe UI", 11, FontStyle.Regular), //Seleziono alcune specifiche relative al Font
                ForeColor = Color.Black     //Il colore del testo sarà nero
            };
            this.Controls.Add(lblUova);     //Aggiungo la label al form

            //SELEZIONATORE_NUMERO_UOVA
            numUova = new NumericUpDown     //Creo un nuovo Box numerico
            {
                Location = new Point(300, 150),   //Determino la posizione che dovrà avere
                Size = new Size(80, 30),    //Determino la dimensione che dovrà avere
                Minimum = 2,    //Il minimo valore accettato è 2 (per evitare 100% esecuzioni impossibili)
                Maximum = 6,    //Il massimo valore accettato è 6 (per evitare esecuzioni troppo lunghe)
                Value = 4,  //Il valore di dsefault è 4
                Font = new Font("Segoe UI", 11),    //Seleziono alcune specifiche relative al Font
                ForeColor = Color.Black     //Il colore del testo sarà nero
            };
            numUova.ValueChanged += NumUova_ValueChanged;   //associo un evento al cambiamento di valore 
            this.Controls.Add(numUova);     //Aggiungo il Box numerico al form

            //PULSANTE_AVVIO
            btnStart = new Button   //Creo un pulsante per avviare il form
            {
                Text = "🎮 Inizia il gioco!",    //Scrivo il testo che dovrà contenere
                Location = new Point(200, 250), //Determino la posizione che dovrà avere
                Size = new Size(200, 45),   //Determino la dimensione che dovrà avere
                Font = new Font("Segoe UI", 12, FontStyle.Bold),    //Seleziono alcune specifiche relative al Font
                BackColor = ColorTranslator.FromHtml("#93c808"),   //Colore di sfondo --> 93c808 (verde) 
                ForeColor = Color.White,    //Colore del testo bianco
                FlatStyle = FlatStyle.Flat,  //Cambio colore quando il mouse passa sopra
                Cursor = Cursors.Hand   //Cambio cursore quando passa sopra
            };
            btnStart.FlatAppearance.BorderSize = 0; //Tolgo i bordi
            btnStart.Click += BtnStart_Click;   //Eseguo la funzione apposita al click del pulsante
            this.Controls.Add(btnStart);    //Aggiungo il bottone al form
        }

        //Funzione da eseguire ogni volta che viene prenuto il pulsante di avvio
        private void BtnStart_Click(object sender, EventArgs e)
        {
            NumeroUovaSelezionate = (int)numUova.Value; //Prelevo il numero di metà uova per colore da inizializzare

            this.Hide();    //Nascondo il formStart

            Form1 form1 = new Form1(NumeroUovaSelezionate); //Creo un nuovo form1 passando come parametro il "numero di uova"
            form1.FormStartReference = this;    //Lascio al form1 un riferimento del formStart
            form1.Show();   //Mostro il form1
        }

        //Funzione che viene eseguita ogni volta che cambia il valore del Box numerico contenente il numero di metà uova
        private void NumUova_ValueChanged(object sender, EventArgs e)
        {
            NumeroUovaSelezionate = (int)numUova.Value; //Salvo il nuovo valore
        }
        #endregion
    }
}