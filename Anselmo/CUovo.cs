public class CUovo : Control
{
    public string Colore1 { get; set; }
    public string Colore2 { get; set; }
    public Guid Id { get; private set; } // ID unico per identificare ciascuna uova

    // Dimensioni base dell'uovo
    private const int BASE_WIDTH = 70;
    private const int BASE_HEIGHT = 90;

    // Fattore di scala attuale
    private float scaleFactor = 1.0f;

    public CUovo(string colore1, string colore2, float scale = 1.0f)
    {
        Colore1 = colore1;
        Colore2 = colore2;
        Id = Guid.NewGuid(); // Assegna un ID unico

        // Imposta le dimensioni in base al fattore di scala
        SetScale(scale);
        DoubleBuffered = true; // Evita lo sfarfallio durante il ridisegno
    }

    // Metodo per impostare la scala dell'uovo
    public void SetScale(float scale)
    {
        scaleFactor = scale;
        Width = (int)(BASE_WIDTH * scale);
        Height = (int)(BASE_HEIGHT * scale);
        Invalidate(); // Richiede il ridisegno del controllo
    }

    // Metodo per verificare se ha un colore in comune con un altro uovo
    public bool HaColoreInComune(CUovo altroUovo)
    {
        return Colore1 == altroUovo.Colore1 ||
               Colore1 == altroUovo.Colore2 ||
               Colore2 == altroUovo.Colore1 ||
               Colore2 == altroUovo.Colore2;
    }

    // Necessari per confrontare l'identità degli oggetti, non solo i colori
    public override bool Equals(object obj)
    {
        if (obj is CUovo altro)
        {
            return Id == altro.Id; // Confronta gli ID, non i colori
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode(); // Usa l'ID per il calcolo dell'hash
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // Calcola le dimensioni scalate dell'uovo
        int eggWidth = (int)(Width - 10 * scaleFactor);
        int eggHeight = (int)(Height - 20 * scaleFactor);
        float borderWidth = 1.5f * scaleFactor;
        float dividerWidth = 0.5f * scaleFactor;
        float fontSize = 7 * scaleFactor;

        // Disegna la forma dell'uovo
        using (var path = new System.Drawing.Drawing2D.GraphicsPath())
        {
            // Crea forma ovale dell'uovo (leggermente più stretta in alto)
            path.AddEllipse(5 * scaleFactor, 10 * scaleFactor, eggWidth, eggHeight);

            // Colore primario per la parte superiore
            using (var brush = new SolidBrush(ColorFromName(Colore1)))
            {
                g.FillPath(brush, path);
            }

            // Colore secondario per la parte inferiore
            using (var brush = new SolidBrush(ColorFromName(Colore2)))
            {
                g.SetClip(new Rectangle(0, Height / 2, Width, Height / 2));
                g.FillPath(brush, path);
                g.ResetClip();
            }

            // Bordo dell'uovo
            using (var pen = new Pen(Color.Black, borderWidth))
            {
                g.DrawPath(pen, path);
            }

            // Linea divisoria tra i due colori
            using (var pen = new Pen(Color.Black, dividerWidth))
            {
                g.DrawLine(pen, 5 * scaleFactor, Height / 2, Width - 5 * scaleFactor, Height / 2);
            }
        }
    }

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
            _ => Color.Gray,
        };
    }
}