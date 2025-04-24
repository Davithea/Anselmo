using System.Text;

namespace Anselmo
{
    public partial class Logger : Form  //Classe per la gestione del logger
    {
        private static StringBuilder logBuffer = new StringBuilder();   //Definisco un buffer per gestire il log
        private static Form logForm;    //Creo un nuoco Form di log
        private static RichTextBox logTextBox;  //Definisco una textBox in cui verranno scritte le informazioni
        private static string logFilePath = "Log.txt";  //Creo un file di testo per salvare le infromazioni di log
        private static EventHandler<string> logEventHandler;    //Creo un evento da associare al log

        public static event EventHandler<string> LogAdded;  //Creo un evento che notifica quando un nuovo log viene aggiunto

        public Logger() //Costruttore di default per il logger
        {
            InitializeComponent();  //Vedi Logger.Desginer.cs per ulteriori informazioni
        }

        //Metodo che inizializza il file di log
        public static void Inizializza()
        {
            File.WriteAllText(logFilePath, "--- Log avviato " + DateTime.Now.ToString() + " ---\r\n");  //Creo o sovrascrivo il file di log
        }

        //Metodo che permette di scrivere un messaggio nel logger
        public static void Log(string message)
        {
            string timeStamp = DateTime.Now.ToString("HH:mm:ss.fff");   //Scrivo l'ora in cui è stato scritto il messaggio
            string logMessage = $"[{timeStamp}] {message}"; //Imposto il layout del messaggio

            logBuffer.AppendLine(logMessage);   //Aggiung al buffer il messaggio

            //Scrivo nel file di testo gestendo l'errore
            try
            {
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nella scrittura del log: {ex.Message}");
            }

            LogAdded?.Invoke(null, logMessage); //Informo di aver scritto sul logger
        }
    }
}