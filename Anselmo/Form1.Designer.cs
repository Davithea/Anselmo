namespace Anselmo
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()  //Funzione per l'inizializzazione del Form1
        {
            this.StartPosition = FormStartPosition.CenterScreen; //Il Form1 deve essere centrato nello schermo quando viene creato
            components = new System.ComponentModel.Container();
            this.Icon = new Icon("Icons/eggIcon.ico"); //Icona del Form1

            //Creo tutti gli elementi di cui ho bisogno per popolare il Form1 (la definizione l'ho fatta nella classe Form1)
            lblFabbrica = new Label();
            panelFabbrica = new Panel();
            lblPrato = new Label();
            panelPrato = new Panel();
            lblStatoAttuale = new Label();
            btnStart = new Button();
            btnStop = new Button();
            btnReset = new Button();
            btnMostraLog = new Button();
            btnTornaIndietro = new Button();
            lblVelocita = new Label();
            trackBar = new TrackBar();
            lblVelocitaMin = new Label();
            lblVelocitaMax = new Label();
            timer = new System.Windows.Forms.Timer(components);
            picConiglio = new PictureBox();

            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit(); //Inizializzo il trackBar
            ((System.ComponentModel.ISupportInitialize)picConiglio).BeginInit(); //Inizializzo il picConiglio
            SuspendLayout();

            //LABEL FABBRICA
            lblFabbrica.Text = "Fabbrica";    //Testo che compare nella label
            lblFabbrica.Location = new Point(10, 10);    //Scelgo il punto in cui metterla
            lblFabbrica.Size = new Size(140, 35);    //Scelgo la dimensione che dovrà avere
            lblFabbrica.TextAlign = ContentAlignment.MiddleCenter;      //Imposto l'allineamento del testo al centro
            lblFabbrica.Font = new Font("Segoe UI", 12F, FontStyle.Bold);   //Seleziono alcune specifiche realtive al Font
            lblFabbrica.BackColor = ColorTranslator.FromHtml("#dee4ff");    //Colore dello sfondo --> dee4ff (azzurro chiaro)
            lblFabbrica.ForeColor = Color.Black;    //Colore del testo nero
            lblFabbrica.BorderStyle = BorderStyle.FixedSingle;  //Stile del bordo fisso
            lblFabbrica.Padding = new Padding(5);   //Padding interno della label

            //PANEL FABBRICA
            panelFabbrica.Location = new Point(10, 55);     //Scelgo il punto in cui metterlo
            panelFabbrica.Size = new Size(860, 150);    //Scelgo la dimensione che dovrà avere
            panelFabbrica.BorderStyle = BorderStyle.FixedSingle;    //Stile del bordo fisso
            panelFabbrica.BackColor = Color.White;  //Colore dello sfondo bianco
            panelFabbrica.AutoScroll = true;    //Attivo lo scorrimento automatico
            panelFabbrica.Padding = new Padding(10);    //Padding interno del panel

            //LABEL PRATO
            lblPrato.Text = "Prato";    //Testo che compare nella label
            lblPrato.Location = new Point(10, 215);     //Scelgo il punto in cui metterla
            lblPrato.Size = new Size(120, 35);  //Scelgo la dimensione che dovrà avere
            lblPrato.TextAlign = ContentAlignment.MiddleCenter;     //Allineamento del testo al centro
            lblPrato.Font = new Font("Segoe UI", 12F, FontStyle.Bold);  //Seleziono alcune specifiche realtive al Font
            lblPrato.BackColor = ColorTranslator.FromHtml("#93c808");   //Colore dello sfondo --> 93c808 (verde)
            lblPrato.ForeColor = Color.Black;   //Colore del testo nero
            lblPrato.BorderStyle = BorderStyle.FixedSingle;     //Stile del bordo fisso
            lblPrato.Padding = new Padding(5);  //Padding interno della label

            //PANEL PRATO
            panelPrato.Location = new Point(10, 260);   //Scelgo il punto in cui metterla
            panelPrato.Size = new Size(860, 250);   //Scelgo la dimensione che dovrà avere
            panelPrato.BorderStyle = BorderStyle.FixedSingle;    //Stile del bordo fisso
            panelPrato.BackColor = ColorTranslator.FromHtml("#93c808");     //Colore dello sfondo verde
            panelPrato.AutoScroll = true;   //Attivo lo scorrimento automatico
            panelPrato.Padding = new Padding(10);   //Padding interno del pannello

            //IMMAGINE CONIGLIO
            picConiglio.Image = Image.FromFile("3.png");    //Seleziono l'immagine "3.png"
            picConiglio.Size = new Size(150, 150);  //Scelgo la dimensione che dovrà avere
            picConiglio.SizeMode = PictureBoxSizeMode.Zoom;     //Modalità di visualizzazione a Zoom
            picConiglio.BorderStyle = BorderStyle.None;     //Nessun bordo
            picConiglio.BackColor = Color.Transparent;  //Sfondo trasparente
            picConiglio.Padding = new Padding(5);   //Padding interno dell'immagine

            //LABEL STATO
            lblStatoAttuale.Text = "Pronto";    //Testo iniziale della label
            lblStatoAttuale.Size = new Size(500, 25);   //Scelgo la dimensione che dovrà avere
            lblStatoAttuale.Font = new Font("Segoe UI", 10F, FontStyle.Italic);     //Seleziono alcune specifiche realtive al Font
            lblStatoAttuale.BackColor = Color.Transparent;  //Sfondo trasparente
            lblStatoAttuale.ForeColor = Color.Black;    //Colore del testo grigio scuro

            //CONFIGURAZIONE PULSANTI
            ConfiguraButton(btnStart, "Start", ColorTranslator.FromHtml("#93c808"));    //Configuro il pulsante Start con colore verde
            ConfiguraButton(btnStop, "Stop", ColorTranslator.FromHtml("#ff9c7e"));    //Configuro il pulsante Stop con colore rosso
            ConfiguraButton(btnReset, "Reset", ColorTranslator.FromHtml("#fffdd0"));    //Configuro il pulsante Reset con colore giallo
            ConfiguraButton(btnMostraLog, "Mostra Log", ColorTranslator.FromHtml("#b8ffed"));   //Configuro il pulsante Mostra Log con colore azzurro
            ConfiguraButton(btnTornaIndietro, "Home", ColorTranslator.FromHtml("#749951"));   //Configuro il pulsante Home con colore verde scuro

            //LABEL VELOCITA'
            lblVelocita.Text = "Velocità: 1000 ms";     //Testo iniziale della label
            lblVelocita.Size = new Size(200, 25);   //Scelgo la dimensione che dovrà avere
            lblVelocita.Font = new Font("Segoe UI", 10F);   //Seleziono alcune specifiche realtive al Font
            lblVelocita.BackColor = Color.Transparent;  //Sfondo trasparente

            //TRACKBAR
            trackBar.Size = new Size(300, 45);  //Scelgo la dimensione che dovrà avere
            trackBar.Minimum = 100;     //Valore minimo di 100ms
            trackBar.Maximum = 3000;    //Valore massimo di 3000ms
            trackBar.Value = 1000;   //Valore iniziale di 1000ms
            trackBar.TickFrequency = 300;   //Frequenza dei segni sulla barra
            trackBar.LargeChange = 300;     //Incremento grande per i click
            trackBar.SmallChange = 100;     //Incremento piccolo per i click
            trackBar.Cursor = Cursors.Hand;     //Cambio cursore quando passa sopra
            trackBar.Scroll += TrackBar_Scroll;     //Evento da eseguire quando si sposta la barra

            //LABEL VELOCITA' MINIMA
            lblVelocitaMin.Size = new Size(100, 23);    //Scelgo la dimensione che dovrà avere
            lblVelocitaMin.Font = new Font("Segoe UI", 9F);     //Seleziono alcune specifiche realtive al Font

            //LABEL VELOCITA' MASSIMA
            lblVelocitaMax.Size = new Size(100, 23);    //Scelgo la dimensione che dovrà avere
            lblVelocitaMax.Font = new Font("Segoe UI", 9F);     //Seleziono alcune specifiche realtive al Font

            //FORM1
            AutoScaleDimensions = new SizeF(8F, 20F);   //Dimensioni per il ridimensionamento automatico
            AutoScaleMode = AutoScaleMode.Font;     //Modalità di ridimensionamento automatico basata sul font
            ClientSize = new Size(1100, 650);       //Scelgo la dimensione iniziale che dovrà avere
            Text = "Backtracking - nascondere le uova";    //Testo che compare in alto a sinistra del Form1
            BackColor = ColorTranslator.FromHtml("#f8e5fa"); //Colore dello sfondo viola chiaro
            Controls.AddRange(new Control[] {   //Aggiungo tutti gli elementi al Form1
                lblFabbrica, panelFabbrica, lblPrato, panelPrato,
                picConiglio, lblStatoAttuale, btnStart, btnStop,
                btnReset, btnMostraLog, btnTornaIndietro, lblVelocita, trackBar,
                lblVelocitaMin, lblVelocitaMax
            });

            Resize += Form1_Resize; //Aggiungo un gestore per il ridimensionamento

            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();     //Termino l'inizializzazione della trackBar
            ((System.ComponentModel.ISupportInitialize)picConiglio).EndInit();  //Termino l'inizializzazione del picConiglio
            ResumeLayout(false);    //Riprendo il layout
            PerformLayout();    //Eseguo il layout

            AutoScroll = true;  //Abilito lo scroll automatico
            Shown += Form1_Shown;   //Aggiungo un gestore per l'evento Shown
            MinimumSize = new Size(900, 600);   //Imposto la dimensione minima del form
        }

        //Metodo per configurare i pulsanti 
        private void ConfiguraButton(Button btn, string text, Color backColor)
        {
            btn.Text = text;    //Imposto il testo del pulsante
            btn.Size = new Size(90, 35);    //Dimensione del pulsante
            btn.Cursor = Cursors.Hand;  //Cambio cursore quando passa sopra
            btn.BackColor = backColor;  //Colore di sfondo passato come parametro
            btn.ForeColor = Color.Black;    //Colore del testo nero
            btn.FlatStyle = FlatStyle.Flat;     //Stile piatto per il pulsante
            btn.FlatAppearance.BorderSize = 1;  //Dimensione del bordo
            btn.FlatAppearance.BorderColor = Color.Black; //Colore del bordo nero
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);    //Seleziono alcune specifiche realtive al Font
            if (text == "Start") btn.Click += BtnStart_Click;   //Associo evento click per Start
            else if (text == "Stop") btn.Click += BtnStop_Click;    //Associo evento click per Stop
            else if (text == "Reset") btn.Click += BtnReset_Click;  //Associo evento click per Reset
            else if (text == "Mostra Log") btn.Click += BtnMostraLog_Click;     //Associo evento click per Mostra Log
            else if (text == "Home") btn.Click += BtnTornaIndietro_Click;     //Associo evento click per Torna Indietro
        }

        //Metodo per gestire l'evento Shown
        private void Form1_Shown(object sender, EventArgs e)
        {
            InizializzaUova();  //Inizializzo le uova
            DisegnaUova(panelFabbrica, fabbrica);   //Disegno le uova nel pannello fabbrica
            Logger.Log($"Inizializzate {fabbrica.Count} uova");     //Scrivo nel log che ho inizializzato le uova
            Form1_Resize(this, EventArgs.Empty);    //Ridimensiono il form
        }

        //Metodo per gestire l'evento Resize
        private void Form1_Resize(object sender, EventArgs e)
        {
            //GESTIONE DELL'ALTEZZA
            int spazioDisponibile = this.ClientSize.Height;     //Ottengo l'altezza disponibile
            int margineSuperiore = 10;  //Margine superiore di 10 pixel
            int margineInferiore = 10;  //Margine inferiore di 10 pixel
            int spaziTraElementi = 10;  //Spazio tra gli elementi di 10 pixel

            int altezzaEtichetta = 35;  //Altezza delle etichette di 35 pixel (fissa)
            int altezzaControlliInferiori = 90;     //Spazio per pulsanti, label velocità e trackbar (fisso)

            int spazioPerPannelli = spazioDisponibile - margineSuperiore - margineInferiore -
                                   (altezzaEtichetta * 2) - altezzaControlliInferiori - (spaziTraElementi * 5);     //Calcolo lo spazio per i pannelli (sottrazione di tutti gli altri spazi dallo spazio totale disponibile)

            int altezzaPanelFabbrica = Math.Max(100, spazioPerPannelli / 3);    //Calcolo l'altezza del panel fabbrica
            int altezzaPanelPrato = Math.Max(150, spazioPerPannelli * 2 / 3);   //Calcolo l'altezza del panel prato

            //GESTIONE DELLA LARGHEZZA
            int larghezza = this.ClientSize.Width - 40;     //Calcolo la larghezza disponibile

            //Posiziono la LABEL FABBRICA 
            lblFabbrica.Top = margineSuperiore;     //Posiziono in alto
            lblFabbrica.Left = 10;  //Posiziono a sinistra

            //Posiziono PANEL FABBRICA
            panelFabbrica.Top = lblFabbrica.Bottom + spaziTraElementi;  //Posiziono sotto lblFabbrica
            panelFabbrica.Left = 10;    //Posiziono a sinistra
            panelFabbrica.Width = larghezza;    //Imposto la larghezza
            panelFabbrica.Height = altezzaPanelFabbrica;    //Imposto l'altezza

            //Posiziono LABEL PRATO
            lblPrato.Top = panelFabbrica.Bottom + spaziTraElementi;     //Posiziono sotto panelFabbrica
            lblPrato.Left = 10;     //Posiziono a sinistra

            //Posiziono PANEL PRATO
            panelPrato.Top = lblPrato.Bottom + spaziTraElementi;    //Posiziono sotto lblPrato
            panelPrato.Left = 10;   //Posiziono a sinistra
            panelPrato.Width = larghezza;   //Imposto la larghezza
            panelPrato.Height = altezzaPanelPrato;  //Imposto l'altezza

            //Posiziono LABEL STATO
            lblStatoAttuale.Top = panelPrato.Bottom + spaziTraElementi;     //Posiziono sotto panelPrato
            lblStatoAttuale.Left = 10;  //Posiziono a sinistra

            //Posiziono i PULSANTI
            int baselineControlli = lblStatoAttuale.Bottom + spaziTraElementi;  //Calcolo la linea di base per i controlli
            btnStart.Top = baselineControlli;   //Posiziono alla linea di base
            btnStart.Left = 10;     //Posiziono a sinistra
            btnStop.Top = baselineControlli;    //Posiziono alla linea di base
            btnStop.Left = btnStart.Right + 10;     //Posiziono a destra di btnStart
            btnReset.Top = baselineControlli;   //Posiziono alla linea di base
            btnReset.Left = btnStop.Right + 10;     //Posiziono a destra di btnStop
            btnMostraLog.Top = baselineControlli;   //Posiziono alla linea di base
            btnMostraLog.Left = btnReset.Right + 10;    //Posiziono a destra di btnReset
            btnTornaIndietro.Top = baselineControlli;   //Posiziono alla linea di base
            btnTornaIndietro.Left = btnMostraLog.Right + 10;    //Posiziono a destra di btnMostraLog

            //Posiziono LABEL VELOCITA'
            lblVelocita.Top = baselineControlli + 10;   //Posiziono sotto la linea di base
            lblVelocita.Left = btnTornaIndietro.Right + 30;     //Posiziono a destra dei pulsanti

            //Posiziono TRACKBAR
            trackBar.Top = baselineControlli + 5;   //Posiziono sotto la linea di base
            trackBar.Left = lblVelocita.Right + 10;     //Posiziono a destra di lblVelocita
            trackBar.Width = Math.Min(300, this.ClientSize.Width - trackBar.Left - picConiglio.Width - 60);     //Calcolo la larghezza massima

            //Posiziono LABEL VELOCITA' MIN e MAX
            lblVelocitaMin.Top = trackBar.Bottom - 5;   //Posiziono sotto trackBar
            lblVelocitaMin.Left = trackBar.Left;    //Allineo a sinistra con trackBar
            lblVelocitaMax.Top = trackBar.Bottom - 5;   //Posiziono sotto trackBar
            lblVelocitaMax.Left = trackBar.Right - lblVelocitaMax.Width;    //Allineo a destra con trackBar

            //Posiziono IMMAGINE CONIGLIO
            picConiglio.Top = baselineControlli - 20;   //Posiziono in alto rispetto alla linea di base
            picConiglio.Left = this.ClientSize.Width - picConiglio.Width - 20;  //Posiziono a destra

            //Mi assicuro che i panel mostrino correttamente le informazioni
            panelFabbrica.AutoScroll = true;    //Attivo lo scorrimento automatico
            panelPrato.AutoScroll = true;   //Attivo lo scorrimento automatico
            this.AutoScroll = false;    //Disattivo lo scorrimento automatico del form

            DisegnaUova(panelFabbrica, fabbrica);   //Ridisegno le uova nel pannello fabbrica
            DisegnaUova(panelPrato, prato);     //Ridisegno le uova nel pannello prato
            Logger.Log($"Form ridimensionato a {this.Width}x{this.Height}");    //Scrivo nel log che il Form1 è stato ridimensionato
        }

        //Metodo per associare un evento al click del btnStart
        private async void BtnStart_Click(object sender, EventArgs e)
        {
            if (isRunning) return;  //Se è già in esecuzione esco

            isRunning = true;   //Imposto il flag di esecuzione
            shouldStop = false;     //Resetto il flag di arresto
            movimentiEffettuati = 0;    //Azzero il contatore dei movimenti
            backtrackEseguiti = 0;  //Azzero il contatore dei backtrack
            lblStatoAttuale.Text = "Elaborazione in corso...";  //Aggiorno il testo dello stato
            Logger.Log("Avviata elaborazione");     //Scrivo nel log che è iniziata l'esecuzione

            bool completato = await NascondiUova();     //Avvio il processo di nascondere le uova

            if (completato && !shouldStop)  //Se è stato completato e non è stato interrotto
            {
                lblStatoAttuale.Text = "Sequenza completata!";  //Aggiorno il testo dello stato
                Logger.Log($"Sequenza completata! Movimenti: {movimentiEffettuati}, Backtrack: {backtrackEseguiti}");   //Scrivo nel log l'avvenuto completamento
                MessageBox.Show("Sequenza completata con successo!");   //Mostro un messaggio di successo
            }
            else if (shouldStop)    //Se è stato interrotto
            {
                lblStatoAttuale.Text = "Operazione interrotta";     //Aggiorno il testo dello stato
                Logger.Log($"Operazione interrotta dall'utente. Movimenti: {movimentiEffettuati}, Backtrack: {backtrackEseguiti}");     //Scrivo nel log che è stato interrotto
                MessageBox.Show("Operazione interrotta dall'utente.");   //Mostro un messaggio
            }
            else    //Se non è completabile
            {
                lblStatoAttuale.Text = "Sequenza non completabile";     //Aggiorno il testo dello stato
                Logger.Log($"Sequenza non completabile. Movimenti: {movimentiEffettuati}, Backtrack: {backtrackEseguiti}");     //Scrivo nel log che è impossibile
                MessageBox.Show("Impossibile completare la sequenza.");     //Mostro un messaggio
            }

            isRunning = false;  //Resetto il flag di esecuzione
        }

        //Metodo per associare un evento al click del btnStop
        private void BtnStop_Click(object sender, EventArgs e)
        {
            shouldStop = true;  //Imposto il flag di arresto
            lblStatoAttuale.Text = "Arresto in corso...";   //Aggiorno il testo dello stato
            Logger.Log("Richiesto arresto dell'elaborazione");  //Scrivo nel log che è stato richiesto l'arresto dell'esecuzione
        }

        //Metodo per associare un evento al click del btnReset
        private void BtnReset_Click(object sender, EventArgs e)
        {
            shouldStop = true;  //Imposto il flag di arresto
            prato.Clear();  //Svuoto il prato
            InizializzaUova();  //Reinizializzo le uova
            DisegnaUova(panelFabbrica, fabbrica);   //Ridisegno le uova nella fabbrica
            DisegnaUova(panelPrato, prato);     //Ridisegno le uova nel prato
            lblStatoAttuale.Text = "Pronto";    //Aggiorno il testo dello stato
            movimentiEffettuati = 0;    //Azzero il contatore dei movimenti
            backtrackEseguiti = 0;  //Azzero il contatore dei backtrack
            Logger.Log("Reset effettuato");     //Scrivo nel log che è stato effettuato un reset
        }

        //Metodo per associare un evento al click del btnMostraLog
        private void BtnMostraLog_Click(object sender, EventArgs e)
        {
            Logger.ShowLogForm();   //Mostro il form di log
        }

        //Metodo per associare un evento al click del btnTornaIndietro
        private void BtnTornaIndietro_Click(object sender, EventArgs e)
        {
            if (FormStartReference != null)     //Se esiste il riferimento al FormStart (dovrebbe sempre esistere perché se chiudo quello termina il programma)
            {
                FormStartReference.Show(); //Mostro il FormStart
            }

            this.Close(); //Chiudo Form1
        }

        //Override per gestire la chiusura del Form1
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e); //Chiamo il metodo base

            //Se la form viene chiusa (click pulsante Home oppure chiusura da comandi del Form) mostro FormStart
            if (FormStartReference != null && !FormStartReference.Visible)  //Se il riferimento a FormStart esiste e non è visibile
            {
                FormStartReference.Show(); //Mostro il FormStart
            }
        }

        //Metodo per gestire lo scorrimento della TrackBar
        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            timer.Interval = trackBar.Value;    //Imposto l'intervallo del timer
            lblVelocita.Text = $"Velocità: {trackBar.Value} ms";    //Aggiorno il testo della velocità
            Logger.Log($"Velocità impostata a {trackBar.Value} ms");    //Scrivo nel log la nuova velocità
        }

        #endregion
    }
}