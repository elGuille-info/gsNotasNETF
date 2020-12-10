//-----------------------------------------------------------------------------
// FormNotaUC                                                       (05/Dic/20)
// Formulario para manejar las notas
//
// (c) Guillermo (elGuille) Som, 2020
//-----------------------------------------------------------------------------

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
    public partial class FormNotasUC : Form
    {
        private readonly string[] noAsignar;

        public FormNotasUC()
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

        private void FormNotasUC_Load(object sender, EventArgs e)
        {
            // Usar un icono de notificación en la barra de tarea
            notifyIcon1.Text = Application.ProductName;
            MnuNotifyRestaurar.Text = "Minimizar";
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Visible = true;

            if (Properties.Settings.Default.Tema == "Claro")
                notaUC1.Tema = Temas.Claro;
            else
                notaUC1.Tema = Temas.Oscuro;

            this.BackColor = tabPage1.BackColor = tabPage2.BackColor = notaUC1.BackColor;
            this.ForeColor = tabPage1.ForeColor = tabPage2.ForeColor = notaUC1.ForeColor;

            NotasFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            GruposFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;

            NotasFlowLayoutPanel.Controls.Clear();
            GruposFlowLayoutPanel.Controls.Clear();

            //CtrlNotas.Clear();
            //foreach (Label c in NotasFlowLayoutPanel.Controls)
            //    CtrlNotas.Add(c);

            //// para que la primera etiqueta se ponga más grande
            //LblNota_Click(LblNota, null);

            lblBuscando.Text = "";
            lstResultadoBuscar.Items.Clear();

            notaUC1.LeerNotas();
        }

        private void FormNotasUC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notaUC1.Modificado)
            {
                if (MessageBox.Show("Los datos están modificados y no se han guardado." + "\n\r" +
                                    "¿Quieres guardarlos?",
                                    "Datos modificados",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    notaUC1.GuardarNotas();
                }
            }
            if (notaUC1.Tema == Temas.Claro)
                Properties.Settings.Default.Tema = "Claro";
            else
                Properties.Settings.Default.Tema = "Oscuro";
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Colección con las etiquetas a mostrar con el contenido de las notas
        /// del grupo seleccionado.
        /// </summary>
        private readonly List<Label> CtrlNotas = new List<Label>();
        
        private readonly List<Label> CtrlGrupos = new List<Label>();

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

            MostrarGrupos(ElGrupo, ElGrupoIndex);

            for (var i = 0; i < CtrlGrupos.Count; i++)
            {
                if (i == index)
                    AsignarValores(CtrlGrupos[i], true, esNota:false);
                else
                    AsignarValores(CtrlGrupos[i], false, esNota: false);
            }
            notaUC1.ComboGrupos.Text = ElGrupo;

            // mostrar la primera nota
            MostrarNotas(grupo, 0);
        }

        private void notaUC1_NotaCambiada(string nota, int index)
        {
            MostrarNotas(ElGrupo, ElGrupoIndex);

            for (var i = 0; i < CtrlNotas.Count; i++)
            { 
                if (i == index)
                    AsignarValores(CtrlNotas[i], true, true);
                else
                    AsignarValores(CtrlNotas[i], false, true);
            }
            
        }

        private void AsignarValores(Label lbl, bool esSeleccionado, bool esNota)
        {
            if (esSeleccionado)
            {
                lbl.FlatStyle = FlatStyle.Popup;
                lbl.BorderStyle = BorderStyle.Fixed3D;
                lbl.Padding = new Padding(0);
                if (esNota)
                {
                    lbl.Font = new Font(LblNota.Font, FontStyle.Bold);
                    // Si queremos que se separe del resto de etiquetas
                    //NotasFlowLayoutPanel.SetFlowBreak(lbl, true);
                    // Asignar el tamaño grande de la nota seleccionada
                    //lbl.Width = (int)(NotasFlowLayoutPanel.ClientSize.Width / 2) - 12;
                    //lbl.Height = NotasFlowLayoutPanel.ClientSize.Height - 12;

                    // lo dejo al doble de ancho
                    lbl.Width = NormalSize.Width * 2;
                }
                else
                {
                    lbl.Font = new Font(LblGrupo.Font, FontStyle.Bold);
                    lbl.Size = NormalSize;
                }
                // Esto hace que se ponga al principio
                //lbl.BringToFront();
            }
            else
            {
                lbl.FlatStyle = FlatStyle.Flat;
                lbl.BorderStyle = BorderStyle.None;
                lbl.Padding = new Padding(2);
                if (esNota)
                {
                    lbl.Font = new Font(LblNota.Font, FontStyle.Regular);
                    //NotasFlowLayoutPanel.SetFlowBreak(lbl, false);
                }
                else
                {
                    lbl.Font = new Font(LblGrupo.Font, FontStyle.Regular);
                }
                lbl.Size = NormalSize;
                //lbl.SendToBack();
            }
            // Por si se quiere que todos tengan el tamaño normal
            //lbl.Size = NormalSize;
        }
                
        private void MostrarNotas(string grupo, int index)
        {
            Color col = AsignarColoresGrupos();

            CtrlNotas.Clear();
            NotasFlowLayoutPanel.Controls.Clear();

            // Esto se dará cuando se cree un nuevo grupo
            if (ElGrupoIndex < 0)
                return;

            if (!notaUC1.Notas.ContainsKey(grupo))
                return;

            // Poner color aleatorio a cada grupo
            col = ColoresGrupo[ElGrupoIndex];
            for (var j = 0; j < notaUC1.Notas[grupo].Count; j++)
            {
                var n = notaUC1.Notas[grupo][j];
                var lbl = CrearNota(n, col);
                lbl.Click += LblNota_Click;
                lbl.DoubleClick += LblNota_DoubleClick;
                CtrlNotas.Add(lbl);
                NotasFlowLayoutPanel.Controls.Add(lbl);
                lbl.Tag = j;
                if (j == index)
                {
                    AsignarValores(lbl, true, true);
                }
            }
        }

        private void MostrarGrupos(string grupo, int index)
        {
            Color col = AsignarColoresGrupos();

            CtrlGrupos.Clear();
            GruposFlowLayoutPanel.Controls.Clear();

            // Esto se dará cuando se cree un nuevo grupo
            if (ElGrupoIndex < 0)
                return;

            // Poner color aleatorio a cada grupo
            //col = ColoresGrupo[ElGrupoIndex];
            int ind = 0;
            foreach (var n in notaUC1.Notas.Keys)
            {
                col = ColoresGrupo[ind];
                var s = $"{n}\n\rGrupo con {notaUC1.Notas[n].Count} notas.";
                var lbl = CrearNota(s, col);
                lbl.Click += LblGrupo_Click;
                lbl.DoubleClick += LblGrupo_DoubleClick;
                CtrlGrupos.Add(lbl);
                GruposFlowLayoutPanel.Controls.Add(lbl);
                lbl.Tag = ind;
                if (ind == index)
                {
                    AsignarValores(lbl, true, false);
                }
                ind++;
            }
        }

        private Color AsignarColoresGrupos()
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
                    Color col2;
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

            return col;
        }

        private Label CrearNota(string nota, Color col)
        {
            var lbl = new Label();
            
            AsignarValores(lbl, false, true);
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
                AsignarValores(l, false, true);
            }
            var lbl = sender as Label;
            if (lbl is null)
                return;

            AsignarValores(lbl, true, true);

            if (!(lbl.Tag is null))
            {
                notaUC1.Seleccionar((int)lbl.Tag, true);
                lbl.Click -= LblNota_Click;
            }
        }

        private void LblNota_DoubleClick(object sender, EventArgs e)
        {
            FormEditarNotaUC frmEditUC;
            frmEditUC = new FormEditarNotaUC(notaUC1, notaUC1.ComboNotas.Text, notaUC1.ComboNotas.SelectedIndex);
            frmEditUC.NotaReemplazada += NotaUC1_NotaReemplazada;

            frmEditUC.Show();
        }

        private void NotaUC1_NotaReemplazada(string grupo, string texto, int index)
        {
            // Se ha remplazado desde el editor externo
            notaUC1.AsignarNota(grupo, texto, index);
        }

        private void LblGrupo_Click(object sender, EventArgs e)
        {
            foreach (var l in CtrlNotas)
            {
                AsignarValores(l, false, false);
            }
            var lbl = sender as Label;
            if (lbl is null)
                return;

            AsignarValores(lbl, true, false);

            if (!(lbl.Tag is null))
                notaUC1.Seleccionar((int)lbl.Tag, false);

            // Activar la ficha de notas
            tabControl1.SelectedIndex = 0;

            notaUC1.Seleccionar(0, true);
        }

        private void LblGrupo_DoubleClick(object sender, EventArgs e)
        {

        }

        private void notaUC1_NotaReemplazada_1(string grupo, string texto, int index)
        {
            // Se ha reemplazado en esta ventana
            notaUC1.Seleccionar(index, true);
        }

        private void notaUC1_CambioDeTema(Temas tema)
        {
            // Esta forma de asignación múltiple de un valor me gusta :-)
            this.BackColor = tabPage1.BackColor = tabPage2.BackColor = tabPage3.BackColor = tabPage4.BackColor = notaUC1.BackColor;
            this.ForeColor = tabPage1.ForeColor = tabPage2.ForeColor = tabPage3.ForeColor = tabPage4.ForeColor = notaUC1.ForeColor;
            // Los colores de la tercera ficha
            lblEdSeleccionar.BackColor = lblEdCambiar.BackColor = lblEdSeleccionarNota.BackColor = notaUC1.BackColor;
            lblEdSeleccionar.ForeColor = lblEdCambiar.ForeColor = lblEdSeleccionarNota.ForeColor = notaUC1.ForeColor;
            cboEdGrupoDestino.BackColor = txtEdNombreGrupo.BackColor = cboEdGrupoNotas.BackColor = cboEdGrupos.BackColor = cboEdNotas.BackColor = notaUC1.BackColor;
            cboEdGrupoDestino.ForeColor = txtEdNombreGrupo.ForeColor = cboEdGrupoNotas.ForeColor = cboEdGrupos.ForeColor = cboEdNotas.ForeColor = notaUC1.ForeColor;
            lblBuscar.BackColor = txtBuscar.BackColor = chkBuscarEnGrupoActual.BackColor = lstResultadoBuscar.BackColor = notaUC1.BackColor;
            lblBuscar.ForeColor = txtBuscar.ForeColor = chkBuscarEnGrupoActual.ForeColor = lstResultadoBuscar.ForeColor = notaUC1.ForeColor;
            // Colores invertidos
            lblEdInfo.BackColor = lblResultadoBuscar.BackColor = lblBuscando.BackColor = btnBuscar.BackColor = btnClasificarGrupos.BackColor = btnBorrar.BackColor = btnCambiarNombre.BackColor = btnMoverNota.BackColor = notaUC1.ForeColor;
            lblEdInfo.ForeColor = lblResultadoBuscar.ForeColor = lblBuscando.ForeColor = btnBuscar.ForeColor = btnClasificarGrupos.ForeColor = btnBorrar.ForeColor = btnCambiarNombre.ForeColor = btnMoverNota.ForeColor = notaUC1.BackColor;
        }

        private void notaUC1_MenuCerrar(string mensaje)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Eliminar el grupo seleccionado
            var grupo = cboEdGrupos.Text;
            if (MessageBox.Show($"¿Quieres eliminar el grupo '{grupo}' y todo su contenido?", "Eliminar grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            iniciando = true;
            //notaUC1.Notas[grupo].RemoveRange(0, notaUC1.Notas[grupo].Count);
            notaUC1.Notas.Remove(grupo);
            cboEdGrupos.Items.Clear();
            foreach (var g in notaUC1.Notas.Keys)
            {
                cboEdGrupos.Items.Add(g);
            }
            iniciando = false;

            notaUC1.AsignarGrupos();
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void btnCambiarNombre_Click(object sender, EventArgs e)
        {
            iniciando = true;

            // Cambiar el nombre del grupo
            var grupo = cboEdGrupos.Text;
            var nuevoGrupo = txtEdNombreGrupo.Text;
            // Si ese nombre existe, se copiarán los datos y se eliminará el seleccionado
            // si no existe, se crea el grupo y se copian los datos
            // después se eliminan las notas del grupo de origen
            if (!notaUC1.Notas.ContainsKey(nuevoGrupo))
                notaUC1.Notas.Add(nuevoGrupo, new List<string>());

            notaUC1.Notas[nuevoGrupo].AddRange(notaUC1.Notas[grupo]);
            //notaUC1.Notas[grupo].RemoveRange(0, notaUC1.Notas[grupo].Count);
            notaUC1.Notas.Remove(grupo);

            cboEdGrupos.Items.Clear();
            foreach (var g in notaUC1.Notas.Keys)
            {
                cboEdGrupos.Items.Add(g);
            }
            iniciando = false;
            notaUC1.AsignarGrupos();
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void btnMoverNota_Click(object sender, EventArgs e)
        {
            iniciando = true;
            var laNota = cboEdNotas.Text;
            var index = cboEdNotas.SelectedIndex;
            var grupoDestino = cboEdGrupoDestino.Text;
            var grupo = cboEdGrupoNotas.Text;
            notaUC1.Notas[grupoDestino].Add(laNota);
            notaUC1.Notas[grupo].RemoveAt(index);
            iniciando = false;
            notaUC1.AsignarGrupos();
            
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 2) return;
            if (!notaUC1.Notas.Keys.Any()) return;

            // Llenar los grupos
            iniciando = true;
            cboEdGrupoDestino.Items.Clear();
            cboEdGrupoNotas.Items.Clear();
            cboEdGrupos.Items.Clear();
            cboEdNotas.Items.Clear();
            foreach(var g in notaUC1.Notas.Keys)
            {
                cboEdGrupoDestino.Items.Add(g);
                cboEdGrupoNotas.Items.Add(g);
                cboEdGrupos.Items.Add(g);
            }
            iniciando = false;
            cboEdGrupoDestino.SelectedIndex = 0;
            cboEdGrupoNotas.SelectedIndex = 0;
            cboEdGrupos.SelectedIndex = 0;
        }

        private bool iniciando;

        private void cboEdGrupoNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iniciando) return;

            iniciando = true;

            cboEdNotas.Items.Clear();
            var g = cboEdGrupoNotas.SelectedItem.ToString();
            for (var i = 0; i < notaUC1.Notas[g].Count; i++)
                cboEdNotas.Items.Add(notaUC1.Notas[g][i]);

            iniciando = false;

            if (cboEdNotas.Items.Count > 0)
                cboEdNotas.SelectedIndex = 0;
        }

        private void btnClasificarGrupos_Click(object sender, EventArgs e)
        {
            iniciando = true;

            var col = new List<string>();
            foreach (var g in notaUC1.Notas.Keys)
                col.Add(g);

            col.Sort();
            var dic = new Dictionary<string,List<string>>();
            for (var i = 0; i < col.Count; i++)
                dic.Add(col[i], notaUC1.Notas[col[i]]);

            notaUC1.Notas.Clear();
            notaUC1.Notas = dic;

            notaUC1.AsignarGrupos();
            iniciando = false;
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void MnuNotifyRestaurar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                MnuNotifyRestaurar.Text = "Restaurar";
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                MnuNotifyRestaurar.Text = "Minimizar";
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void MnuNotifyCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormNotasUC_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                MnuNotifyRestaurar.Text = "Minimizar";
            else
                MnuNotifyRestaurar.Text = "Restaurar";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var buscar = txtBuscar.Text;
            if (string.IsNullOrWhiteSpace(buscar))
            {
                lblBuscando.Text = "Debes indicar un texto válido a buscar.";
                txtBuscar.Focus();
                return;
            }
            bool hallado = false;

            btnBuscar.Enabled = false;
            lblBuscando.Text = "Buscando...";
            Application.DoEvents();
            var grupo = notaUC1.ComboGrupos.Text;
            lstResultadoBuscar.Items.Clear();
            if (chkBuscarEnGrupoActual.Checked)
            {
                for (var i = 0; i < notaUC1.Notas[grupo].Count; i++)
                {
                    if (notaUC1.Notas[grupo][i].IndexOf(buscar, StringComparison.InvariantCultureIgnoreCase) > -1)
                    {
                        var index = lstResultadoBuscar.Items.Add(notaUC1.Notas[grupo][i]);
                        lstResultadoBuscar.Items[index] = $"{grupo} @ {i}";
                        hallado = true;
                    }
                }
            }
            else
            {
                foreach (var g in notaUC1.Notas.Keys)
                {
                    for (var i = 0; i < notaUC1.Notas[g].Count; i++)
                    {
                        if (notaUC1.Notas[g][i].IndexOf(buscar, StringComparison.InvariantCultureIgnoreCase) > -1)
                        {
                            var index = lstResultadoBuscar.Items.Add(notaUC1.Notas[g][i]);
                            lstResultadoBuscar.Items[index] = $"{g} @ {i}";
                            hallado = true;
                        }
                    }
                }
            }
            if (!hallado)
                lblBuscando.Text = "No se ha encontrado lo que se buscaba.";
            else
                lblBuscando.Text = $"Halladas {lstResultadoBuscar.Items.Count} coincidencias.";
            btnBuscar.Enabled = true;
            Application.DoEvents();
        }

        private void lstResultadoBuscar_DoubleClick(object sender, EventArgs e)
        {
            // al hacer doble-click en el listbox, mostrar esa nota
            if (lstResultadoBuscar.Items.Count == 0)
                return;

            var s = lstResultadoBuscar.SelectedItem.ToString();
            // el formato es: grupo @ índice
            var i = s.IndexOf("@");
            if (i == -1) return;
            var grupo = s.Substring(0, i - 1);
            var index =-1;
            int.TryParse(s.Substring(i + 2), out index);
            if (index == -1) return;

            notaUC1.ComboGrupos.Text = grupo;
            notaUC1.Seleccionar(index, true);
        }
    }
}
