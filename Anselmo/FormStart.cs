using System;
using System.Drawing;
using System.Windows.Forms;

namespace Anselmo
{
    public partial class FormStart : Form
    {
        private NumericUpDown numUova;  //Variabile che salva il valore risultante da un numberBox (come quello nel mio formStart)
        private Button btnStart;    //Bottone per iniziare la simulazione
        private Label lblTitolo;    //Label che contiene il titolo dell'applicazione
        private Label lblDescrizione;   //Label che contiene la descrizione dell'applicazione
        private Label lblUova;  //Label che contiene la richiesta del numero di metà uova per colore 
        public int NumeroUovaSelezionate { get; private set; }  //Intero per contenere il numero di metà per colore selezionate

        public FormStart()  //Costruttore di default
        {
            InitializeComponent();  //Vedi FormStart.Designer.cs per ulteriori infromazioni
        }
    }
}