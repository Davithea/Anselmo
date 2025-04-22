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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Logger";
        }

        public static void ShowLogForm()
        {
            if (logForm == null || logForm.IsDisposed)
            {
                // Dimensioni minime della finestra
                int minWidth = 700;
                int minHeight = 500;

                logForm = new Form
                {
                    Text = "Log - Nascondi le Uova",
                    Size = new Size(minWidth, minHeight),
                    MinimumSize = new Size(minWidth, minHeight), // Imposta dimensioni minime
                    StartPosition = FormStartPosition.CenterScreen,
                    BackColor = ColorTranslator.FromHtml("#fffdd0"), // sfondo giallo chiaro
                    Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
                };

                // Creazione pannello principale
                TableLayoutPanel mainPanel = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 2,
                    RowCount = 2,
                    BackColor = Color.Transparent
                };

                mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
                mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
                mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));

                logForm.Controls.Add(mainPanel);

                // Pannello per il log text
                Panel logPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    Padding = new Padding(10)
                };

                mainPanel.Controls.Add(logPanel, 0, 0);
                mainPanel.SetRowSpan(logPanel, 1);

                // RichTextBox per i log
                logTextBox = new RichTextBox
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    BackColor = ColorTranslator.FromHtml("#dee4ff"),
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 10),
                    BorderStyle = BorderStyle.None
                };

                // Angoli arrotondati per il RichTextBox (simulati)
                Panel roundedPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    Padding = new Padding(2),
                    BackColor = Color.DarkGray
                };
                roundedPanel.Controls.Add(logTextBox);
                logPanel.Controls.Add(roundedPanel);

                // Aggiungi i log esistenti
                logTextBox.Text = logBuffer.ToString();
                logTextBox.SelectionStart = logTextBox.Text.Length;
                logTextBox.ScrollToCaret();

                // Panel per l'immagine del coniglio
                Panel imagePanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    Padding = new Padding(10)
                };
                mainPanel.Controls.Add(imagePanel, 1, 0);

                // PictureBox per il coniglio
                PictureBox pictureBox = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = Image.FromFile("4.png"),
                    BackColor = Color.Transparent
                };
                imagePanel.Controls.Add(pictureBox);

                // Label informativa sotto l'immagine
                Label infoLabel = new Label
                {
                    Text = "Logger delle attività",
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    ForeColor = Color.DarkSlateGray,
                    Height = 30
                };
                imagePanel.Controls.Add(infoLabel);

                // Pannello per i pulsanti
                FlowLayoutPanel buttonPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = false,
                    Padding = new Padding(10, 5, 10, 5)
                };
                mainPanel.Controls.Add(buttonPanel, 0, 1);
                mainPanel.SetColumnSpan(buttonPanel, 2);

                // Bottone per cancellare i log
                Button clearButton = new Button
                {
                    Text = "🗑️ Cancella Log",
                    Height = 40,
                    Width = 160,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = ColorTranslator.FromHtml("#93c808"),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(10, 0, 10, 0),
                    Cursor = Cursors.Hand
                };
                clearButton.FlatAppearance.BorderSize = 0;
                buttonPanel.Controls.Add(clearButton);

                // Bottone per esportare i log
                Button exportButton = new Button
                {
                    Text = "📄 Esporta Log",
                    Height = 40,
                    Width = 160,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = ColorTranslator.FromHtml("#dee4ff"),
                    ForeColor = Color.Black,
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(10, 0, 10, 0),
                    Cursor = Cursors.Hand
                };
                exportButton.FlatAppearance.BorderSize = 0;
                buttonPanel.Controls.Add(exportButton);

                // Event handlers per i pulsanti
                clearButton.Click += (sender, e) =>
                {
                    logTextBox.Clear();
                    logBuffer.Clear();
                    Logger.Log("Log cancellati dall'utente");
                };

                exportButton.Click += (sender, e) =>
                {
                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "File di testo (*.txt)|*.txt",
                        Title = "Esporta log",
                        FileName = "LogNascondiUova_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveDialog.FileName, logTextBox.Text);
                        Logger.Log($"Log esportati in {saveDialog.FileName}");
                    }
                };

                // Gestione evento LogAdded in modo sicuro
                logEventHandler = (sender, log) =>
                {
                    if (logTextBox != null && !logTextBox.IsDisposed)
                    {
                        if (logTextBox.InvokeRequired)
                        {
                            try
                            {
                                logTextBox.Invoke(new Action(() => AppendLog(log)));
                            }
                            catch (ObjectDisposedException)
                            {
                                // Ignora se l'oggetto è già stato eliminato
                            }
                        }
                        else
                        {
                            AppendLog(log);
                        }
                    }
                };

                // Registrazione sicura dell'evento
                LogAdded += logEventHandler;

                // Pulizia risorse quando il form viene chiuso
                logForm.FormClosing += (sender, e) =>
                {
                    // Rimuovi la registrazione all'evento in modo sicuro
                    if (logEventHandler != null)
                    {
                        LogAdded -= logEventHandler;
                        logEventHandler = null;
                    }
                };

                logForm.Show();
            }
            else
            {
                logForm.BringToFront();
            }
        }

        #endregion
    }
}