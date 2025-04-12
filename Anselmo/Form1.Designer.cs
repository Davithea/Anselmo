namespace Anselmo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        private System.Windows.Forms.ListBox listBoxPrato;
        private System.Windows.Forms.ListBox listBoxIniziale;

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label lblIniziale = new Label();
            lblIniziale.Text = "Coda Iniziale";
            lblIniziale.Location = new Point(20, 0);
            this.Controls.Add(lblIniziale);

            Label lblPrato = new Label();
            lblPrato.Text = "Prato";
            lblPrato.Location = new Point(460, 0);
            this.Controls.Add(lblPrato);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";


            this.listBoxPrato = new System.Windows.Forms.ListBox();

            // 
            // listBoxPrato
            // 
            this.listBoxPrato.FormattingEnabled = true;
            this.listBoxPrato.Location = new System.Drawing.Point(460, 20);
            this.listBoxPrato.Size = new System.Drawing.Size(200, 300);
            this.Controls.Add(this.listBoxPrato);

            this.listBoxIniziale = new System.Windows.Forms.ListBox();

            // 
            // listBoxIniziale
            // 
            this.listBoxIniziale.FormattingEnabled = true;
            this.listBoxIniziale.Location = new System.Drawing.Point(20, 20);
            this.listBoxIniziale.Size = new System.Drawing.Size(200, 300);
            this.Controls.Add(this.listBoxIniziale);
        }

        #endregion
    }
}
