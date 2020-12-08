/* 
    Para poder usar el C# 9.0 (por defecto en .NET Framework se usa el 7.3)
    hay que añadir esto en el fichero del proyecto:
    <PropertyGroup>
        <LangVersion>latest</LangVersion>
    </PropertyGroup>
    Y para usar init en las propiedades, añadir esto después del espacio de nombres normal
    o mejor en clase aparte.
    Si se añade antes de la definición del namespace del formulario,
    el diseñador de Windows Forms se hace un lío y define ese espacio de nombres en Form1.Designer.cs
    en lugar del espacio de nombres del proyecto.
    namespace System.Runtime.CompilerServices
    {
        public class IsExternalInit { }
    }
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;


namespace gsNotasNETF
{
    public partial class Form1 : Form
    {

        ///// <summary>
        ///// El path del fichero de notas.
        ///// </summary>
        //private string FicNotas { get; init; }

        ///// <summary>
        ///// El path al directorio de documentos.
        ///// </summary>
        //private string DirDocumentos { get; init; }

        public Form1()
        {
            InitializeComponent();

            // Seleccionar que grupo de colores se usarán
            Random rnd = new Random();
            var n = rnd.Next(0, 3);
            if (n==1)
                ColoresGrupo = new List<Color>() {Color.FromArgb(0,99,177), Color.Gold, Color.Lime, Color.Pink, Color.Yellow,
                                                  Color.AliceBlue, Color.LightGray, Color.LightPink, Color.LightSkyBlue, Color.LightGoldenrodYellow };
            else if(n==2)
                ColoresGrupo = new List<Color>() {Color.AliceBlue, Color.LightPink, Color.LightSkyBlue, Color.LightGoldenrodYellow,
                                                  Color.LightGray, Color.Gold, Color.FromArgb(0,99,177), Color.Lime, Color.Pink, Color.Yellow };
            else
                ColoresGrupo = new List<Color>() {Color.LightPink, Color.LightSkyBlue, Color.LightGoldenrodYellow, Color.Gold, Color.DeepPink,
                                                  Color.Lime, Color.Yellow, Color.LightGray,Color.AliceBlue,Color.FromArgb(0,99,177) };

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
        }

        /// <summary>
        /// Colección con las etiquetas a mostrar con el contenido de las notas
        /// del grupo seleccionado.
        /// </summary>
        private readonly List<Label> TxtNotas = new List<Label>();

        private string ElGrupo;
        private int ElGrupoIndex;
        //private string LaNota;

        private List<Color> ColoresGrupo = new List<Color>() {
            Color.FromArgb(0,99,177), Color.Gold, Color.Lime, Color.Pink, Color.Yellow, 
            Color.LightGray,Color.AliceBlue, Color.LightPink, Color.LightSkyBlue, Color.LightGoldenrodYellow };

        private void notaUC1_GrupoCambiado(string grupo, int index)
        {
            // al cambiar de grupo crear las notas
            ElGrupo = grupo;
            ElGrupoIndex = index;

            notaUC1.ComboGrupos.Text = ElGrupo;

            MostrarNotas(grupo, index);
        }

        private void notaUC1_NotaCambiada(string nota, int index)
        {
            MostrarNotas(ElGrupo, ElGrupoIndex);
            //LaNota = nota;

            for (var i = 0; i < TxtNotas.Count; i++)
            { 
                if (i == index)
                {
                    TxtNotas[i].Font = new Font(TxtNota.Font, FontStyle.Bold);
                    TxtNotas[i].FlatStyle = FlatStyle.Popup;
                    TxtNotas[i].BorderStyle = BorderStyle.Fixed3D;
                    TxtNotas[i].Padding = new Padding(3);
                }
                else
                {
                    TxtNotas[i].Font = new Font(TxtNota.Font, FontStyle.Regular);
                    TxtNotas[i].FlatStyle = FlatStyle.Standard;
                    TxtNotas[i].BorderStyle = BorderStyle.None;
                    TxtNotas[i].Padding = new Padding(0);
                }
            }
        }

        private void MostrarNotas(string grupo, int index)
        {
            Color col = GetRandomColor();
            var rnd = new Random();

            if (ColoresGrupo.Count == 0)
            {
                for (var j = 0; j < notaUC1.Notas.Keys.Count; j++)
                {
                    ColoresGrupo.Add(col);
                    var n = rnd.Next(1, 4);
                    byte r = col.R, g = col.G, b = col.B;
                    if (n == 1)
                        r = 0;
                    else if (n == 2)
                        g = 0;
                    else if (n == 3)
                        b = 0;
                    Color col2; // = GetRandomColor(r, g, b);
                    do
                    {
                        col2 = GetRandomColor(r, g, b);
                    } while (col.Equals(col2));
                    col = col2;
                }
            }
            else if (ColoresGrupo.Count < notaUC1.Notas.Keys.Count)
            { 
                for(var j=ColoresGrupo.Count; j<notaUC1.Notas.Keys.Count; j++)
                {
                    var n = rnd.Next(1, 4);
                    byte r = col.R, g = col.G, b = col.B;
                    if (n == 1)
                        r = 0;
                    else if (n == 2)
                        g = 0;
                    else if (n == 3)
                        b = 0;
                    Color col2;
                    do
                    {
                        col2 = GetRandomColor(r, g, b);
                    } while (col.Equals(col2));
                    col = col2;

                    ColoresGrupo.Add(col);
                }
            }

            TxtNotas.Clear();
            flowLayoutPanel1.Controls.Clear();
            // Poner color aleatorio a cada grupo
            col = ColoresGrupo[ElGrupoIndex];
            //int i = 0;
            for (var j = 0; j < notaUC1.Notas[grupo].Count; j++)
            {
                var n = notaUC1.Notas[grupo][j];
                var txt = CrearNota(n, col);
                txt.Click += TxtNota_Click;
                TxtNotas.Add(txt);
                flowLayoutPanel1.Controls.Add(txt);
                txt.Tag = j;
                if (j == index)
                {
                    txt.Font = new Font(txt.Font, FontStyle.Bold);
                    txt.FlatStyle = FlatStyle.Popup;
                    txt.BorderStyle = BorderStyle.Fixed3D;
                    txt.Padding = new Padding(3);
                }
            }
        }

        private Label CrearNota(string nota, Color col)
        {
            var txt = new Label();
            txt.Size = TxtNota.Size;
            txt.Margin =new Padding(3);
            txt.Font = new Font(TxtNota.Font, FontStyle.Regular);
            SetBackColor(txt, col);
            txt.Text = nota;
            txt.Padding = new Padding(0);

            return txt;
        }

        private Color GetRandomColor(byte red=0, byte green=0, byte blue=0)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            byte r = red==0 ? (byte)random.Next(0, 255): red;
            byte g = green == 0 ? (byte)random.Next(0, 255) : green;
            byte b = blue == 0 ? (byte)random.Next(0, 255) : blue;
            if(random.Next(0,2) == 0)
                return Color.FromArgb(255, r, g, b);
            else
                return Color.FromArgb(255, b, r, g);
        }

        private void SetBackColor(Control ctrl, Color col)
        {
            ctrl.BackColor = col;
            ctrl.ForeColor = (col.GetBrightness() < 0.5) ? (Color.White) : (Color.Black);
        }

        private void TxtNota_Click(object sender, EventArgs e)
        {
            foreach (var l in TxtNotas)
            {
                l.FlatStyle = FlatStyle.Standard;
                l.BorderStyle = BorderStyle.None;
                l.Padding = new Padding(0);
                l.Font = new Font(TxtNota.Font, FontStyle.Regular);
            }
            var lbl = sender as Label;
            lbl.FlatStyle = FlatStyle.Popup;
            lbl.BorderStyle = BorderStyle.Fixed3D;
            lbl.Padding = new Padding(3);
            lbl.Font = new Font(TxtNota.Font, FontStyle.Bold);
            var index = (int)lbl.Tag;
            notaUC1.Seleccionar(index);
        }
    }
}

/* 
Para evitar el error al usar init:
Error CS0518 Predefined type ‘System.Runtime.CompilerServices.IsExternalInit’ is not defined or imported
*/
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}
