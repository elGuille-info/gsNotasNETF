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
        private readonly string[] noAsignar;

        public Form1()
        {
            InitializeComponent();

            // Seleccionar que grupo de colores se usarán
            Random rnd = new Random();
            var n = rnd.Next(0, 3);
            if (n==1)
                ColoresGrupo = new List<Color>() {Color.LightSkyBlue, Color.Gold, Color.PaleGreen, Color.LightPink, Color.Yellow,
                                                  Color.FromArgb(0,99,177), Color.LightGoldenrodYellow, Color.AliceBlue, Color.LightGray, Color.Pink };
            else if(n==2)
                ColoresGrupo = new List<Color>() {Color.AliceBlue, Color.LightPink, Color.LightSkyBlue, Color.LightGoldenrodYellow,
                                                  Color.LightGray, Color.Gold, Color.FromArgb(0,99,177), Color.PaleGreen, Color.Pink, Color.Yellow };
            else
                ColoresGrupo = new List<Color>() {Color.LightPink, Color.LightSkyBlue, Color.LightGoldenrodYellow, Color.Gold, Color.DeepPink,
                                                  Color.PaleGreen, Color.Yellow, Color.LightGray,Color.AliceBlue,Color.FromArgb(0,99,177) };

            noAsignar = new string[] { notaUC1.Name };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;

            //flowLayoutPanel1.Controls.Clear();
            
            CtrlNotas.Clear();
            foreach (Label c in flowLayoutPanel1.Controls)
                CtrlNotas.Add(c);
            
            // para que la primera etiqueta se ponga más grande
            LblNota_Click(LblNota, null);
        }

        /// <summary>
        /// Colección con las etiquetas a mostrar con el contenido de las notas
        /// del grupo seleccionado.
        /// </summary>
        private readonly List<Label> CtrlNotas = new List<Label>();

        private string ElGrupo;
        private int ElGrupoIndex;

        private List<Color> ColoresGrupo = new List<Color>() {
            Color.FromArgb(0,99,177), Color.Gold, Color.PaleGreen, Color.Pink, Color.Yellow, 
            Color.LightGray,Color.AliceBlue, Color.LightPink, Color.LightSkyBlue, Color.LightGoldenrodYellow };

        private readonly Size NormalSize = new Size(180, 80);

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

            for (var i = 0; i < CtrlNotas.Count; i++)
            { 
                if (i == index)
                    AsignarValores(CtrlNotas[i], true);
                else
                    AsignarValores(CtrlNotas[i], false);
            }
        }

        private void AsignarValores(Label lbl, bool esSeleccionado)
        {
            if (esSeleccionado)
            {
                lbl.FlatStyle = FlatStyle.Popup;
                lbl.BorderStyle = BorderStyle.Fixed3D;
                lbl.Padding = new Padding(0);
                lbl.Font = new Font(LblNota.Font, FontStyle.Bold);
                flowLayoutPanel1.SetFlowBreak(lbl, true);
                //lbl.Width = flowLayoutPanel1.ClientSize.Width-12;
                lbl.Width = (int)(flowLayoutPanel1.ClientSize.Width / 2) - 12;
                //lbl.Height = 90;
                //lbl.Height = (int)(flowLayoutPanel1.ClientSize.Height / 1.5) - 12;
                lbl.Height = flowLayoutPanel1.ClientSize.Height - 12;
                lbl.BringToFront();
            }
            else
            {
                lbl.FlatStyle = FlatStyle.Flat;
                lbl.BorderStyle = BorderStyle.None;
                lbl.Padding = new Padding(2);
                lbl.Font = new Font(LblNota.Font, FontStyle.Regular);
                flowLayoutPanel1.SetFlowBreak(lbl, false);
                lbl.Size = NormalSize;
                lbl.SendToBack();
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
                for (var j = ColoresGrupo.Count; j < notaUC1.Notas.Keys.Count; j++)
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

            CtrlNotas.Clear();
            flowLayoutPanel1.Controls.Clear();

            // Esto se dará cuando se cree un nuevo grupo
            if (ElGrupoIndex < 0)
                return;

            // Poner color aleatorio a cada grupo
            col = ColoresGrupo[ElGrupoIndex];
            for (var j = 0; j < notaUC1.Notas[grupo].Count; j++)
            {
                var n = notaUC1.Notas[grupo][j];
                var lbl = CrearNota(n, col);
                lbl.Click += LblNota_Click;
                CtrlNotas.Add(lbl);
                flowLayoutPanel1.Controls.Add(lbl);
                lbl.Tag = j;
                if (j == index)
                {
                    AsignarValores(lbl, true);
                }
            }
        }

        private Label CrearNota(string nota, Color col)
        {
            var lbl = new Label();
            
            AsignarValores(lbl, false);
            // Los valores fijos
            lbl.Margin = new Padding(3);
            SetBackColor(lbl, col);
            lbl.Text = nota;

            return lbl;
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

        private void LblNota_Click(object sender, EventArgs e)
        {
            foreach (var l in CtrlNotas)
            {
                AsignarValores(l, false);
            }
            var lbl = sender as Label;
            AsignarValores(lbl, true);

            if (!(lbl.Tag is null))
                notaUC1.Seleccionar((int)lbl.Tag);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notaUC1.Modificado)
            {
                if (MessageBox.Show("Los datos están modificados y no se han guardado." + "\n\r"+
                                    "¿Quieres guardarlos?", 
                                    "Datos modificados", 
                                    MessageBoxButtons.YesNo, 
                                    MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    notaUC1.GuardarNotas();
                }
            }
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
