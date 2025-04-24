namespace Anselmo
{
    partial class Logger
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
        private void InitializeComponent()  //Funzione per l'inizializzazione del Logger
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;   //Gestione autoamtica del ridimensionamento
            this.ClientSize = new System.Drawing.Size(800, 450);    //Inizializzo la dimensione iniziale del logger
            ShowLogForm();  //Chiamata alla funzione che permette la visualizzazione del Logger
        }

        public static void ShowLogForm()  //Funzione per mostrare il form di log
        {
            if (logForm == null || logForm.IsDisposed)  //Controllo se il form di log esiste già
            {
                //Dimensioni minime della finestra
                int minWidth = 700;
                int minHeight = 500;

                logForm = new Form  //Creo un nuovo form per il logger
                {
                    Text = "Logger",
                    Size = new Size(minWidth, minHeight),    //Inizializzo la dimensione iniziale del form
                    MinimumSize = new Size(minWidth, minHeight),    //Imposto le dimensioni minime
                    StartPosition = FormStartPosition.CenterScreen,  //Il form deve essere centrato nello schermo quando viene creato
                    BackColor = ColorTranslator.FromHtml("#fffdd0"),    //Colore dello sfondo --> fffdd0 (giallo)
                    Icon = new Icon("Icons/loggerIcon.ico")  //Icona del Logger
            };

                //CREAZIONE PANNELLO PRINCIPALE
                TableLayoutPanel mainPanel = new TableLayoutPanel  //Creo un nuovo pannello per organizzare gli elementi
                {
                    Dock = DockStyle.Fill,      //Il pannello occupa tutto lo spazio disponibile
                    ColumnCount = 2,    //Numero di colonne del pannello
                    RowCount = 2,   //Numero di righe del pannello
                    BackColor = Color.Transparent   //Colore di sfondo trasparente
                };

                mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));     //Dimensiono la prima colonna al 75%
                mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));     //Dimensiono la seconda colonna al 25%
                mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));   //Dimensiono la prima riga al 90%
                mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));   //Dimensiono la seconda riga al 10%

                logForm.Controls.Add(mainPanel);    //Aggiungo il panel principale al form

                //PANEL PER IL LOG TEXT
                Panel logPanel = new Panel      //Creo un nuovo panel per contenere il text box dei log
                {
                    Dock = DockStyle.Fill,      //Il panel occupa tutto lo spazio disponibile
                    Padding = new Padding(10)   //Aggiungo un margine interno di 10px
                };

                mainPanel.Controls.Add(logPanel, 0, 0);     //Aggiungo il panel alla prima colonna, prima riga
                mainPanel.SetRowSpan(logPanel, 1);      //Il panel occupa una sola riga

                //RICHTEXTBOX PER I LOG
                logTextBox = new RichTextBox    //Creo una nuova casella di testo per i log
                {
                    Dock = DockStyle.Fill,      //La casella occupa tutto lo spazio disponibile
                    ReadOnly = true,    //Rendo la casella di sola lettura
                    BackColor = ColorTranslator.FromHtml("#dee4ff"),    //Colore dello sfondo --> dee4ff (azzurro chiaro)
                    ForeColor = Color.Black,    //Il colore del testo sarà nero
                    Font = new Font("Segoe UI", 10),     //Seleziono alcune specifiche relative al Font
                    BorderStyle = BorderStyle.None      //Rimuovo i bordi della casella
                };

                //PANEL ARROTONDATO PER IL RICHTEXTBOX
                Panel roundedPanel = new Panel      //Creo un nuovo pannello per simulare gli angoli arrotondati
                {
                    Dock = DockStyle.Fill,   //Il panel occupa tutto lo spazio disponibile
                    Padding = new Padding(2),  //Aggiungo un margine interno di 2px
                    BackColor = Color.DarkGray  //Colore dello sfondo grigio scuro
                };
                roundedPanel.Controls.Add(logTextBox);  //Aggiungo la casella di testo al panel arrotondato
                logPanel.Controls.Add(roundedPanel);  //Aggiungo il panel arrotondato al panel dei log

                //AGGIUNGO I LOG ESISTENTI
                logTextBox.Text = logBuffer.ToString();     //Inserisco i log presenti nel buffer
                logTextBox.SelectionStart = logTextBox.Text.Length;     //Posiziono il cursore alla fine del testo
                logTextBox.ScrollToCaret();     //Scorro automaticamente alla posizione del cursore

                //PANEL PER L'IMMAGINE DEL CONIGLIO
                Panel imagePanel = new Panel    //Creo un nuovo panel per l'immagine
                {
                    Dock = DockStyle.Fill,      //Il panel occupa tutto lo spazio disponibile
                    Padding = new Padding(10)   //Aggiungo un margine interno di 10px
                };
                mainPanel.Controls.Add(imagePanel, 1, 0);   //Aggiungo il panel alla seconda colonna, prima riga

                //PICTUREBOX PER IL CONIGLIO
                PictureBox pictureBox = new PictureBox      //Creo una nuova pictureBox per contenere l'immagine del coniglio
                {
                    Dock = DockStyle.Fill,      //La pictureBox occupa tutto lo spazio disponibile
                    SizeMode = PictureBoxSizeMode.Zoom,     //Seleziono la modalità di visualizzazione a Zoom
                    Image = Image.FromFile("4.png"),    //Seleziono l'immagine "4.png"
                    BackColor = Color.Transparent   //Colore di sfondo trasparente
                };
                imagePanel.Controls.Add(pictureBox);    //Aggiungo la pictureBox al panel dell'immagine

                //LABEL INFORMATIVA
                Label infoLabel = new Label     //Creo una label per l'informazione
                {
                    Text = "Logger delle attività",     //Scrivo il testo che dovrà contenere
                    Dock = DockStyle.Bottom,    //La label si posiziona in basso
                    TextAlign = ContentAlignment.MiddleCenter,      //Allineamento del testo al centro
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),   //Seleziono alcune specifiche relative al Font
                    ForeColor = Color.Black,    //Il colore del testo sarà nero
                    Height = 30     //Altezza della label
                };
                imagePanel.Controls.Add(infoLabel);  //Aggiungo la label al pannello dell'immagine

                //PANNELLO PER I PULSANTI
                FlowLayoutPanel buttonPanel = new FlowLayoutPanel   //Creo un nuovo pannello per i pulsanti
                {
                    Dock = DockStyle.Fill,      //Il pannello occupa tutto lo spazio disponibile
                    FlowDirection = FlowDirection.LeftToRight,      //Gli elementi fluiscono da sinistra a destra
                    WrapContents = false,   //Gli elementi non vanno a capo
                    Padding = new Padding(10, 5, 10, 5)     //Aggiungo margini interni
                };
                mainPanel.Controls.Add(buttonPanel, 0, 1);      //Aggiungo il pannello alla prima colonna, seconda riga
                mainPanel.SetColumnSpan(buttonPanel, 2);    //Il pannello occupa entrambe le colonne

                //BOTTONE PER CANCELLARE I LOG
                Button clearButton = new Button     //Creo un pulsante per cancellare i log
                {
                    Text = "🗑️ Cancella Log",    //Scrivo il testo che dovrà contenere
                    Height = 40,    //Altezza del pulsante
                    Width = 160,    //Larghezza del pulsante
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),    //Seleziono alcune specifiche relative al Font
                    BackColor = ColorTranslator.FromHtml("#93c808"),    //Colore di sfondo --> 93c808 (verde)
                    ForeColor = Color.White,    //Colore del testo bianco
                    FlatStyle = FlatStyle.Flat,     //Cambio colore quando il mouse passa sopra
                    Margin = new Padding(10, 0, 10, 0),     //Aggiungo margini esterni
                    Cursor = Cursors.Hand   //Cambio cursore quando il mouse passa sopra
                };
                clearButton.FlatAppearance.BorderSize = 0;      //Tolgo i bordi
                buttonPanel.Controls.Add(clearButton);      //Aggiungo il bottone al pannello dei pulsanti

                //BOTTONE PER ESPORTARE I LOG
                Button exportButton = new Button    //Creo un pulsante per esportare i log
                {
                    Text = "📄 Esporta Log",      //Scrivo il testo che dovrà contenere
                    Height = 40,    //Altezza del pulsante
                    Width = 160,     //Larghezza del pulsante
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),      //Seleziono alcune specifiche relative al Font
                    BackColor = ColorTranslator.FromHtml("#dee4ff"),      //Colore di sfondo --> dee4ff (azzurro chiaro)
                    ForeColor = Color.Black,      //Il colore del testo sarà nero
                    FlatStyle = FlatStyle.Flat,     //Cambio colore quando il mouse passa sopra
                    Margin = new Padding(10, 0, 10, 0),      //Aggiungo margini esterni
                    Cursor = Cursors.Hand    //Cambio cursore quando passa sopra
                };
                exportButton.FlatAppearance.BorderSize = 0;     //Tolgo i bordi
                buttonPanel.Controls.Add(exportButton);      //Aggiungo il bottone al pannello dei pulsanti

                //EVENT HANDLERS PER I PULSANTI
                clearButton.Click += (sender, e) =>     //Eseguo la funzione apposita al click del pulsante di cancellazione
                {
                    logTextBox.Clear();     //Pulisco la casella di testo
                    logBuffer.Clear();   //Pulisco il buffer dei log
                    Logger.Log("Log cancellati dall'utente");    //Aggiungo un nuovo log per registrare l'azione
                };

                exportButton.Click += (sender, e) =>    //Eseguo la funzione apposita al click del pulsante di esportazione
                {
                    SaveFileDialog saveDialog = new SaveFileDialog   //Creo una nuova finestra di dialogo per il salvataggio
                    {
                        Filter = "File di testo (*.txt)|*.txt",      //Filtro per i file di testo
                        Title = "Esporta log",   //Titolo della finestra di dialogo
                        FileName = "LogNascondiUova_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt"   //Nome del file predefinito
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)     //Se l'utente conferma il salvataggio
                    {
                        File.WriteAllText(saveDialog.FileName, logTextBox.Text);    //Salvo il contenuto della casella di testo nel file
                        Logger.Log($"Log esportati in {saveDialog.FileName}");      //Scrivo nel log che ho salvato il logger in un file
                    }
                };

                //GESTIONE EVENTO LOGADDED
                logEventHandler = (sender, log) =>      //Funzione per gestire l'aggiunta di nuovi log
                {
                    if (logTextBox != null && !logTextBox.IsDisposed)   //Controllo se la casella di testo esiste ancora
                    {
                        if (logTextBox.InvokeRequired)   //Se richiede invocazione da altro thread
                        {
                            try
                            {
                                logTextBox.Invoke(new Action(() => AppendLog(log)));  //Invoco l'aggiunta del log nel thread dell'interfaccia utente
                            }
                            catch (ObjectDisposedException)     //Gestisco l'eccezione se l'oggetto è già stato eliminato
                            {
                            }
                        }
                        else
                        {
                            AppendLog(log);     //Aggiungo direttamente il log
                        }
                    }
                };

                //REGISTRAZIONE DELL'EVENTO
                LogAdded += logEventHandler;    //Registro l'handler all'evento LogAdded

                //PULIZIA RISORSE
                logForm.FormClosing += (sender, e) =>   //Funzione da eseguire quando il form sta per essere chiuso
                {
                    //Rimuovo la registrazione all'evento in modo sicuro
                    if (logEventHandler != null)    //Controllo se l'handler esiste
                    {
                        LogAdded -= logEventHandler;    //Rimuovo la registrazione
                        logEventHandler = null;     //Imposto l'handler a null
                    }
                };

                logForm.Show();     //Mostro il form di log
            }
            else
            {
                logForm.BringToFront();     //Porto il form in primo piano se esiste già
            }
        }

        private static void AppendLog(string log)   //Funzione per aggiungere il testo alla textBox
        {
            try
            {
                if (logTextBox != null && !logTextBox.IsDisposed)   //Se il logTextBox esiste e non è già stato inizializzato
                {
                    logTextBox.AppendText(log + Environment.NewLine);   //Aggiungo il testo e vado a capo
                    logTextBox.SelectionStart = logTextBox.Text.Length; //Sposto il cursore alla fine del testo
                    logTextBox.ScrollToCaret(); //Scorro il testo fino al cursore, così da mostrarlo all'utente
                }
            }
            catch (ObjectDisposedException)
            {
            }
        }

        #endregion
    }
}