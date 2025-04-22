using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anselmo
{
    public partial class Logger : Form
    {
        private static StringBuilder logBuffer = new StringBuilder();
        private static Form logForm;
        private static RichTextBox logTextBox;
        private static string logFilePath = "Log.txt";
        private static EventHandler<string> logEventHandler;

        // Evento che notifica quando un nuovo log viene aggiunto
        public static event EventHandler<string> LogAdded;

        public Logger()
        {
            InitializeComponent();
            ShowLogForm();
        }

        public static void Initialize()
        {
            // Crea o sovrascrive il file di log
            File.WriteAllText(logFilePath, "--- Log avviato " + DateTime.Now.ToString() + " ---\r\n");
        }

        public static void Log(string message)
        {
            string timeStamp = DateTime.Now.ToString("HH:mm:ss.fff");
            string logMessage = $"[{timeStamp}] {message}";

            // Aggiungi al buffer
            logBuffer.AppendLine(logMessage);

            // Scrivi al file
            try
            {
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nella scrittura del log: {ex.Message}");
            }

            // Notifica i listener
            LogAdded?.Invoke(null, logMessage);
        }

        private static void AppendLog(string log)
        {
            try
            {
                if (logTextBox != null && !logTextBox.IsDisposed)
                {
                    logTextBox.AppendText(log + Environment.NewLine);
                    logTextBox.SelectionStart = logTextBox.Text.Length;
                    logTextBox.ScrollToCaret();
                }
            }
            catch (ObjectDisposedException)
            {
                // Ignora se l'oggetto è già stato eliminato
            }
        }
    }
}