public class CUovo : Control    //Eredita da Control per gestire la grafica
{
    private string mColore1;    //Attributo che indica il primo colore
    private string mColore2;    //Attributo che indica il secondo colore
    private Guid mID;   //Identificatore unico per l'uovo

    //Property pubbliche 
    public string Colore1 { get { return mColore1; } set { mColore1 = value; } } 
    public string Colore2 { get { return mColore2; } set { mColore2 = value; } }
    public Guid Id { get { return mID; } set { mID = value; } }

    //Definizione delle dimenzioni di base dell'uovo
    private const int LARGHEZZA_BASE = 70;
    private const int ALTEZZA_BASE = 90;

    private float fattoreDiScala = 1.0f;   //Definizione di un fattore di scala

    public CUovo(string colore1, string colore2, float fattoreScala = 1.0f)    //Costruttore per l'uovo
    {
        Colore1 = colore1;  //Associo all'uovo il colore1
        Colore2 = colore2;  //Associo all'uovo il colore2
        Id = Guid.NewGuid(); //Assegno all'uovo un ID unico

        SetScale(fattoreScala);    //Imposto le dimensioni in base al fattore di scala attuale
        DoubleBuffered = true;  //Evito lo sfarfallio quando viene ridisegnato
    }

    //Metodo per impostare la dimesnione dell'uovo in base al fattore di scala
    public void SetScale(float fattoreScala)
    {
        fattoreDiScala = fattoreScala;  //Salvo il nuovo fattore di scala   
        Width = (int)(LARGHEZZA_BASE * fattoreScala);   //Modifico la larghezza in base al nuovo fattore di scala
        Height = (int)(ALTEZZA_BASE * fattoreScala);    //Modifico l'altezza in base al nuovo fattore di scala
        Invalidate();   //Richiedo il ridisegno del controllo
    }

    //Metodo per verificare se un uovo ha un colore in comune con un altro uovo
    public bool HaColoreInComune(CUovo altroUovo)
    {
        return Colore1 == altroUovo.Colore1 ||
               Colore1 == altroUovo.Colore2 ||
               Colore2 == altroUovo.Colore1 ||
               Colore2 == altroUovo.Colore2;    //Controllo caso per caso se ci sono due colori corrispondenti
    }

    //Ridefinizione di Equals per confrontare gli ID di due uova, non i colori
    public override bool Equals(object obj)
    {
        if (obj is CUovo altro) //Se l'oggeto parametro è un uovo chiamato altro
        {
            return Id == altro.Id; //Ritorno true se l'ID dell'altro uovo corrisponde all'ID del mio uovo
        }
        return false;   //Altrimenti ritorno false
    }

    //Ridefinisco la funzione GetHashCode
    public override int GetHashCode()
    {
        return Id.GetHashCode(); //Uso l'ID dell'uovo per il calcolo dell'hash
    }

    //Metodo per disegnare fisicamente le uova nel form
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);    //Chiamo il metodo OnPaint della classe Control per mantenere il comportamento standard
        Graphics g = e.Graphics;    //Ottengo l'oggetto Graphics dal PaintEventArgs per disegnare
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //Imposto l'antialiasing per avere bordi più morbidi e grafica migliore

        int eggWidth = (int)(Width - 10 * fattoreDiScala);  //Calcolo la larghezza dell'uovo tenendo conto del fattore di scala
        int eggHeight = (int)(Height - 20 * fattoreDiScala);    //Calcolo l'altezza dell'uovo tenendo conto del fattore di scala
        float borderWidth = 1.5f * fattoreDiScala;  //Definisco lo spessore del bordo dell'uovo proporzionalmente al fattore di scala
        float dividerWidth = 0.5f * fattoreDiScala; //Definisco lo spessore della linea divisoria tra i due colori sempre tenendo conto del fattore di scala
        Pen Penna;  //Dichiaro una variabile Pen che userò per disegnare i bordi
        Brush Brush;    //Dichiaro una variabile Brush che userò per colorare l'uovo

        using (System.Drawing.Drawing2D.GraphicsPath Path = new System.Drawing.Drawing2D.GraphicsPath())    //Creo un blocco using per assicurarmi che il persorso venga correttamente eliminato dopo l'uso
        {

            Path.AddEllipse(5 * fattoreDiScala, 10 * fattoreDiScala, eggWidth, eggHeight);  //Aggiungo un'ellisse (un po' schiacciato) al percorso per creare la forma dell'uovo

            using (Brush = new SolidBrush(ColorFromName(Colore1)))  //Creo un blocco using per colorare la prima parte
            {
                g.FillPath(Brush, Path);    //Riempio tutto l'uovo con il primo colore
            }
            
            using (Brush = new SolidBrush(ColorFromName(Colore2)))  //Creo un blocco using per colorare la seconda parte
            {
                g.SetClip(new Rectangle(0, Height / 2, Width, Height / 2)); //Imposto un'area di ritaglio per la metà inferiore dell'uovo
                g.FillPath(Brush, Path);    //Riempio l'uovo con il secondo colore, ma sarà visibile solo nella metà inferiore
                g.ResetClip();  //Resetto l'area di ritaglio per poter disegnare di nuovo su tutta l'area
            }

            using (Penna = new Pen(Color.Black, borderWidth))   //Creo un blocco using per disegnare il bordo
            {
                g.DrawPath(Penna, Path);    //Disegno il bordo attorno all'uovo
            }

            using (Penna = new Pen(Color.Black, dividerWidth))  //Creo un blocco using per disegnare la linea di separazione tra i due colore
            {
                g.DrawLine(Penna, 5 * fattoreDiScala, Height / 2, Width - 5 * fattoreDiScala, Height / 2);  //Disegno una linea orizzontale che divide i due colori dell'uovo
            }
        }
    }

    //Metodo che associa il colore reale ad un nome di riferimento (perché i colori scelti non sono standard)
    private Color ColorFromName(string nome)
    {
        return nome switch
        {
            "Giallo" => ColorTranslator.FromHtml("#fffdd0"),
            "Rosa" => ColorTranslator.FromHtml("#ffe6de"),
            "Viola" => ColorTranslator.FromHtml("#f8e5fa"),
            "Verde" => ColorTranslator.FromHtml("#749951"),
            "Azzurro" => ColorTranslator.FromHtml("#dee4ff"),
            "Arancione" => ColorTranslator.FromHtml("#ff9c7e"),
            _ => Color.White
        };
    }
}