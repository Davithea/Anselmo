namespace Anselmo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormStart formStart = new FormStart();  //Avvio dell'applicazione con la creazione di un nuovo FormStart

            Application.Run(formStart); //Avvio l'applicazione con FormStart come form principale
        }
    }
}