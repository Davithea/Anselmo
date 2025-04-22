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
        

        private void InitializeComponent()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            components = new System.ComponentModel.Container();
            lblIniziale = new Label();
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

            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picConiglio).BeginInit();
            SuspendLayout();

            // lblIniziale
            lblIniziale.Text = "Fabbrica";
            lblIniziale.Location = new Point(10, 10);
            lblIniziale.Size = new Size(140, 35);
            lblIniziale.TextAlign = ContentAlignment.MiddleCenter;
            lblIniziale.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblIniziale.BackColor = ColorTranslator.FromHtml("#dee4ff");
            lblIniziale.ForeColor = Color.Black;
            lblIniziale.BorderStyle = BorderStyle.FixedSingle;
            lblIniziale.Padding = new Padding(5);

            // panelFabbrica
            panelFabbrica.Location = new Point(10, 55);
            panelFabbrica.Size = new Size(860, 150);
            panelFabbrica.BorderStyle = BorderStyle.FixedSingle;
            panelFabbrica.BackColor = Color.White;
            panelFabbrica.AutoScroll = true;
            panelFabbrica.Padding = new Padding(10);

            // lblPrato
            lblPrato.Text = "Prato";
            lblPrato.Location = new Point(10, 215);
            lblPrato.Size = new Size(120, 35);
            lblPrato.TextAlign = ContentAlignment.MiddleCenter;
            lblPrato.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPrato.BackColor = ColorTranslator.FromHtml("#93c808");
            lblPrato.ForeColor = Color.Black;
            lblPrato.BorderStyle = BorderStyle.FixedSingle;
            lblPrato.Padding = new Padding(5);

            // panelPrato
            panelPrato.Location = new Point(10, 260);
            panelPrato.Size = new Size(860, 250);
            panelPrato.BorderStyle = BorderStyle.FixedSingle;
            panelPrato.BackColor = Color.FromArgb(147, 200, 8);
            panelPrato.AutoScroll = true;
            panelPrato.Padding = new Padding(10);

            // picConiglio
            picConiglio.Image = Image.FromFile("3.png");
            picConiglio.Size = new Size(150, 150);
            picConiglio.SizeMode = PictureBoxSizeMode.Zoom;
            picConiglio.BorderStyle = BorderStyle.None;
            picConiglio.BackColor = Color.Transparent;
            picConiglio.Padding = new Padding(5);

            // lblStatoAttuale
            lblStatoAttuale.Text = "Pronto";
            lblStatoAttuale.Size = new Size(500, 25);
            lblStatoAttuale.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblStatoAttuale.BackColor = Color.Transparent;
            lblStatoAttuale.ForeColor = Color.DarkSlateGray;

            // Pulsanti con stile migliorato
            ConfiguraButton(btnStart, "Start", Color.FromArgb(147, 200, 8));
            ConfiguraButton(btnStop, "Stop", Color.FromArgb(255, 100, 100));
            ConfiguraButton(btnReset, "Reset", Color.FromArgb(255, 180, 0));
            ConfiguraButton(btnMostraLog, "Mostra Log", ColorTranslator.FromHtml("#dee4ff"));
            ConfiguraButton(btnTornaIndietro, "Torna Indietro", Color.LightGray);

            // lblVelocita
            lblVelocita.Text = "Velocità: 1000 ms";
            lblVelocita.Size = new Size(200, 25);
            lblVelocita.Font = new Font("Segoe UI", 10F);
            lblVelocita.BackColor = Color.Transparent;

            // trackBar
            trackBar.Size = new Size(300, 45);
            trackBar.Minimum = 100;
            trackBar.Maximum = 3000;
            trackBar.Value = 1000;
            trackBar.TickFrequency = 300;
            trackBar.LargeChange = 300;
            trackBar.SmallChange = 100;
            trackBar.Cursor = Cursors.Hand;
            trackBar.Scroll += TrackBar_Scroll;

            // lblVelocitaMin & Max
            lblVelocitaMin.Size = new Size(100, 23);
            lblVelocitaMax.Size = new Size(100, 23);
            lblVelocitaMin.Font = new Font("Segoe UI", 9F);
            lblVelocitaMax.Font = new Font("Segoe UI", 9F);

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = false; // Disabilita AutoScroll del form
            ClientSize = new Size(1100, 650);
            MinimumSize = new Size(1100, 650);
            Text = "Nascondi le Uova - Anselmo";
            BackColor = Color.FromArgb(250, 250, 250);
            Controls.AddRange(new Control[] {
                lblIniziale, panelFabbrica, lblPrato, panelPrato,
                picConiglio, lblStatoAttuale, btnStart, btnStop,
                btnReset, btnMostraLog, btnTornaIndietro, lblVelocita, trackBar,
                lblVelocitaMin, lblVelocitaMax
            });

            this.Shown += Form1_Shown;
            this.Resize += Form1_Resize;

            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)picConiglio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Metodo helper per configurare i pulsanti con stile consistente
        private void ConfiguraButton(Button btn, string text, Color backColor)
        {
            btn.Text = text;
            btn.Size = new Size(90, 35);
            btn.Cursor = Cursors.Hand;
            btn.BackColor = backColor;
            btn.ForeColor = Color.Black;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.DarkGray;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            if (text == "Start") btn.Click += BtnStart_Click;
            else if (text == "Stop") btn.Click += BtnStop_Click;
            else if (text == "Reset") btn.Click += BtnReset_Click;
            else if (text == "Mostra Log") btn.Click += BtnMostraLog_Click;
            else if (text == "Torna Indietro") btn.Click += BtnTornaIndietro_Click;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            InizializzaUova();
            DisegnaUova(panelFabbrica, fabbrica);
            Logger.Log($"Inizializzate {fabbrica.Count} uova");
            Form1_Resize(this, EventArgs.Empty);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Calcola lo spazio disponibile
            int spazioDisponibile = this.ClientSize.Height;
            int margineSuperiore = 10;
            int margineInferiore = 10;
            int spaziTraElementi = 10;

            // Altezza fissa per etichette e controlli
            int altezzaEtichetta = 35;
            int altezzaControlliInferiori = 90; // spazio per pulsanti, label velocità e trackbar

            // Calcola lo spazio disponibile per i pannelli
            int spazioPerPannelli = spazioDisponibile - margineSuperiore - margineInferiore -
                                   (altezzaEtichetta * 2) - altezzaControlliInferiori - (spaziTraElementi * 5);

            // Dividi lo spazio proporzionalmente
            int altezzaPanelFabbrica = Math.Max(100, spazioPerPannelli / 3);
            int altezzaPanelPrato = Math.Max(150, spazioPerPannelli * 2 / 3);

            // Calcola la larghezza in base alla finestra
            int larghezza = this.ClientSize.Width - 40;

            // Posiziona lblIniziale
            lblIniziale.Top = margineSuperiore;
            lblIniziale.Left = 10;

            // Posiziona panelFabbrica
            panelFabbrica.Top = lblIniziale.Bottom + spaziTraElementi;
            panelFabbrica.Left = 10;
            panelFabbrica.Width = larghezza;
            panelFabbrica.Height = altezzaPanelFabbrica;

            // Posiziona lblPrato
            lblPrato.Top = panelFabbrica.Bottom + spaziTraElementi;
            lblPrato.Left = 10;

            // Posiziona panelPrato
            panelPrato.Top = lblPrato.Bottom + spaziTraElementi;
            panelPrato.Left = 10;
            panelPrato.Width = larghezza;
            panelPrato.Height = altezzaPanelPrato;

            // Posiziona lblStatoAttuale
            lblStatoAttuale.Top = panelPrato.Bottom + spaziTraElementi;
            lblStatoAttuale.Left = 10;

            // Posiziona i pulsanti
            int baselineControlli = lblStatoAttuale.Bottom + spaziTraElementi;
            btnStart.Top = baselineControlli;
            btnStart.Left = 10;
            btnStop.Top = baselineControlli;
            btnStop.Left = btnStart.Right + 10;
            btnReset.Top = baselineControlli;
            btnReset.Left = btnStop.Right + 10;
            btnMostraLog.Top = baselineControlli;
            btnMostraLog.Left = btnReset.Right + 10;
            btnTornaIndietro.Top = baselineControlli;
            btnTornaIndietro.Left = btnMostraLog.Right + 10;

            // Posiziona lblVelocita e trackBar
            lblVelocita.Top = baselineControlli + 10;
            lblVelocita.Left = btnTornaIndietro.Right + 30;

            trackBar.Top = baselineControlli + 5;
            trackBar.Left = lblVelocita.Right + 10;
            trackBar.Width = Math.Min(300, this.ClientSize.Width - trackBar.Left - picConiglio.Width - 60);

            lblVelocitaMin.Top = trackBar.Bottom - 5;
            lblVelocitaMin.Left = trackBar.Left;
            lblVelocitaMax.Top = trackBar.Bottom - 5;
            lblVelocitaMax.Left = trackBar.Right - lblVelocitaMax.Width;

            // Posiziona picConiglio
            picConiglio.Top = baselineControlli - 20;
            picConiglio.Left = this.ClientSize.Width - picConiglio.Width - 20;

            // Assicurati che i pannelli mostrino il contenuto correttamente
            panelFabbrica.AutoScroll = true;
            panelPrato.AutoScroll = true;
            this.AutoScroll = false;

            DisegnaUova(panelFabbrica, fabbrica);
            DisegnaUova(panelPrato, prato);
            Logger.Log($"Form ridimensionato a {this.Width}x{this.Height}");
        }

        // Eventi dei pulsanti
        private async void BtnStart_Click(object sender, EventArgs e)
        {
            if (isRunning) return;

            isRunning = true;
            shouldStop = false;
            movimentiEffettuati = 0;
            backtrackEseguiti = 0;
            lblStatoAttuale.Text = "Elaborazione in corso...";
            Logger.Log("Avviata elaborazione");

            bool completato = await NascondiUova();

            if (completato && !shouldStop)
            {
                lblStatoAttuale.Text = "Sequenza completata!";
                Logger.Log($"Sequenza completata! Movimenti: {movimentiEffettuati}, Backtrack: {backtrackEseguiti}");
                MessageBox.Show("Sequenza completata con successo!");
            }
            else if (shouldStop)
            {
                lblStatoAttuale.Text = "Operazione interrotta";
                Logger.Log($"Operazione interrotta dall'utente. Movimenti: {movimentiEffettuati}, Backtrack: {backtrackEseguiti}");
                MessageBox.Show("Operazione interrotta dall'utente.");
            }
            else
            {
                lblStatoAttuale.Text = "Sequenza non completabile";
                Logger.Log($"Sequenza non completabile. Movimenti: {movimentiEffettuati}, Backtrack: {backtrackEseguiti}");
                MessageBox.Show("Impossibile completare la sequenza.");
            }

            isRunning = false;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            shouldStop = true;
            lblStatoAttuale.Text = "Arresto in corso...";
            Logger.Log("Richiesto arresto dell'elaborazione");
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            shouldStop = true;
            prato.Clear();
            InizializzaUova();
            DisegnaUova(panelFabbrica, fabbrica);
            DisegnaUova(panelPrato, prato);
            lblStatoAttuale.Text = "Pronto";
            movimentiEffettuati = 0;
            backtrackEseguiti = 0;
            Logger.Log("Reset effettuato");
        }

        private void BtnMostraLog_Click(object sender, EventArgs e)
        {
            Logger.ShowLogForm();
        }

        private void BtnTornaIndietro_Click(object sender, EventArgs e)
        {
            // Mostriamo nuovamente FormStart invece di crearne una nuova
            if (FormStartReference != null)
            {
                FormStartReference.Show();
            }

            // Chiudiamo Form1
            this.Close();
        }

        // Aggiungiamo un override per OnFormClosing per gestire la chiusura della form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Se la form viene chiusa (per qualsiasi motivo) mostriamo FormStart
            if (FormStartReference != null && !FormStartReference.Visible)
            {
                FormStartReference.Show();
            }
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            timer.Interval = trackBar.Value;
            lblVelocita.Text = $"Velocità: {trackBar.Value} ms";
            Logger.Log($"Velocità impostata a {trackBar.Value} ms");
        }

        #endregion
    }
}