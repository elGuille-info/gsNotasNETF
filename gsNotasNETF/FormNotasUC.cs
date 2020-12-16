//-----------------------------------------------------------------------------
// FormNotaUC                                                       (05/Dic/20)
// Formulario para manejar las notas
//
// (c) Guillermo Som (elGuille), 2020
//-----------------------------------------------------------------------------
/* Versiones y cambios
v1.0.0.0    05-dic-20   Primera versión.
v1.0.0.40   09-dic-20   Última versión con los dos controles de usuario.
                        Ver: https://github.com/elGuille-info/gsNotasNETF/releases/tag/1.0.0.40
v1.0.0.78   10-dic-20   Quito el control CabeceraNotaUC y otras opciones
                        Ver: https://github.com/elGuille-info/gsNotasNETF/releases/tag/v1.0.0.78
v1.0.0.98   10-dic-20   Editar notas y grupos.
                        Ver: https://github.com/elGuille-info/gsNotasNETF/releases/tag/v1.0.0.98
v1.0.0.109  10-dic-20   Drag & drop, buscar texto, icono de notificación
                        Ver: https://github.com/elGuille-info/gsNotasNETF/releases/tag/v1.0.0.109
v1.0.0.111  11-dic-20   Opciones de configuración
v1.0.0.112              Las opciones de configuración están efectivas
                        Salvo las de AutoGuardar y NoGuardarEnBlanco
                        Ver: https://github.com/elGuille-info/gsNotasNETF/releases/tag/v1.0.0.112
v1.0.0.113              Se comprueba en NotaUC las asignaciones de notas teniendo en cuenta NoGuardarEnBlanco
                        Otras mejoras o comprobaciones en el código de NotaUC
v1.0.0.114              Se comprueba el grupo a mostrar en la lista 
                        cuando se añade uno nuevo o se cambia de nombre, etc.
                        Para mostrar el que había seleccionado.
v1.0.0.115              Al guardar las notas no asignaba Modificado a false
v1.0.0.116              En cambiar nombre de los grupos aviso que distinguen mayúsculas de minúsculas
v1.0.0.117              Creo que la comprobación de si se cambia el texto del editor está controlada
v1.0.0.118  12-dic-20   Ya va lo de asignar al cambiar de grupo (aún no al cambiar de nota)
                        Aunque lo añade como nueva nota.
v1.0.0.119              También se asignan las notas cuando en un mismo grupo se cambia de nota.
v1.0.0.120              Nuevas comprobaciones para mostrar el texto en la barra de estado y
                        asignar false a TextoModificado
v1.0.0.121              Al iniciar se puede mostrar el último grupo que estaba mostrado al cerrar.
                        Ver: https://github.com/elGuille-info/gsNotasNETF/releases/tag/v1.0.0.121
v1.0.0.122  15-dic-20   Cambio los GroupBox a Panel para añadir Autoscroll
                        Añado el panel Vista
                        Añado la opción para mostrar las notas horizontalmente (más estrechas y largas)
                        NotasFlowLayoutPanel.FlowDirection = TopDown
                        Tamaño de las etiquetas: Normal: 180, 80; Horizontal: ancho del FlowPanel y 35 de alto
                        Nuevas opciones para mostrar en la barra de tareas de Windows y guardar en Drive
                        Por ahora solo se guardan las notas en Drive, no se leen desde allí.
v1.0.0.123              Utilizo la biblioteca gsGoogleDriveDocsAPINET para guardar (si así se indica) las notas en Google Drive.
v1.0.0.124              Ajustes a la hora de leer los valores (y asignarlos) de la configuración.
v1.0.0.125              Asignado los valores de guardar en drive y borrar anteriores en el control NotaUC.
v1.0.0.126              Se capturan los eventos de la DLL para cuando inicia, termina y está creando los documentos.
                        Ver: https://github.com/elGuille-info/gsNotasNETF/releases/tag/v1.0.0.126
v1.0.0.127  16-dic-20   Cambio el alto de las notas horizontales de 35 a 23
v1.0.0.128              Arreglado que al cerrar con la X se oculte al minimizar 
                        (antes no se quitaba de la barra de tareas de Windows)
                        Al abrir el diseñador de formularios da 2 errores sin lógica (compila bien)
                        Que no se encuentra la DLL del API Docs en el otro proyecto y 
                        que notaUC1 o no está declarada o nunca se ha asignado.
                        He quitado la DLL y puesto el código en gsNotasNETF y ya se han quitado los errores.
v1.0.0.129              Incluyo la clase ApisDriveDocs y las referencias al Google.API en gsNotasNETF

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
        /// <summary>
        /// Acceso a los datos de configuración.
        /// </summary>
        private Properties.Settings MySetting = Properties.Settings.Default;
        /// <summary>
        /// Array con los controles a no asignar cuando se permite cambiar el tamaño y posición.
        /// </summary>
        private readonly string[] NoAsignar;
        /// <summary>
        /// Para controlar que no re-entre en un método de evento.
        /// </summary>
        private bool iniciando = true;
        /// <summary>
        /// Colección con las notas del grupo seleccionado. 
        /// A mostrar en la ficha Notas.
        /// </summary>
        private readonly List<Label> CtrlNotas = new List<Label>();
        /// <summary>
        /// Colección con los grupos mostrados en la ficha de Grupos.
        /// </summary>
        private readonly List<Label> CtrlGrupos = new List<Label>();
        /// <summary>
        /// El grupo seleccionado del combo.
        /// </summary>
        private string ElGrupo;
        /// <summary>
        /// El índice del grupo seleccionado.
        /// </summary>
        private int ElGrupoIndex;
        /// <summary>
        /// Colección con los colores a mostrar en cada grupo y notas de cada grupo.
        /// </summary>
        private List<Color> ColoresGrupo = new List<Color>() {
                    Color.FromArgb(0,99,177), Color.Gold, Color.PaleGreen, Color.Pink, Color.Yellow,
                    Color.LightGray,Color.AliceBlue, Color.LightPink, Color.LightSkyBlue, Color.LightGoldenrodYellow 
                    };
        /// <summary>
        /// El tamaño normal de las notas y grupos en el panel.
        /// </summary>
        private readonly Size NormalSize = new Size(180, 80);

        /// <summary>
        /// El tamaño de las notas si se elige mostrar en horizontal.
        /// El ancho se asignará al de NotasFlowLayoutPanel.Client.Width - 12
        /// </summary>
        private Size HorizontalSize = new Size(250, 23);

        /// <summary>
        /// El tamaño a usar en las notas
        /// </summary>
        private Size NotasSize = new Size(180, 80);

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

            NoAsignar = new string[] { notaUC1.Name };
        }

        private void FormNotasUC_Load(object sender, EventArgs e)
        {
            // Usar un icono de notificación en la barra de tarea
            notifyIcon1.Text = Application.ProductName;
            NotifyMenuRestaurar.Text = "Minimizar";
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Visible = true;

            var grupoTmp = MySetting.UltimoGrupo;

            AsignarSettings();

            AsignarColores();

            NotasFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            GruposFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;

            NotasFlowLayoutPanel.Controls.Clear();
            GruposFlowLayoutPanel.Controls.Clear();

            lblBuscando.Text = "";
            lstResultadoBuscar.Items.Clear();

            notaUC1.LeerNotas();

            if (MySetting.MostrarMismoGrupo)
                if (notaUC1.Notas.ContainsKey(grupoTmp))
                    notaUC1.ComboGrupos.Text = grupoTmp;

            MySetting.UltimoGrupo = grupoTmp;

            iniciando = false;
        }

        /// <summary>
        /// Solo asignar true cuando se cierre desde el menú cerrar.
        /// Ya que al cerrar desde la X del formulario puede que queramos minimizar.
        /// </summary>
        private bool NoCerrar = true;

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
                MySetting.Tema = "Claro";
            else
                MySetting.Tema = "Oscuro";
            // No hace falta asignarlos, tienen los mismos valores
            if (this.WindowState == FormWindowState.Normal)
            {
                MySetting.Left = this.Left;
                MySetting.Top = this.Top;
                MySetting.Heigh = this.Height;
                MySetting.Width = this.Width;
                MySetting.Save();
            }
            //MySetting.Left = TamApp.Left;
            //MySetting.Top = TamApp.Top;
            //MySetting.Heigh = TamApp.Height;
            //MySetting.Width = TamApp.Width;
            MySetting.Save();

            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Solo minimizar si así se indica en MinimizarAlCerrar
                // y no se está cerrando desde el menú cerrar.
                if (NoCerrar && MySetting.MinimizarAlCerrar)
                {
                    // no cerrar, sólo minimizar
                    e.Cancel = true;
                    WindowState = FormWindowState.Minimized;
                }
            }
            else
            {
                try { notifyIcon1.Visible = false; }
                catch { }
            }
        }

        private void FormNotasUC_Resize(object sender, EventArgs e)
        {
            if (iniciando) return;

            if (this.WindowState == FormWindowState.Normal)
            {
                NotifyMenuRestaurar.Text = "Minimizar";
                MySetting.Left = this.Left;
                MySetting.Top = this.Top;
                MySetting.Width = this.Width;
                MySetting.Heigh = this.Height;
                TamApp = (this.Left, this.Top, this.Width, this.Height);
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                NotifyMenuRestaurar.Text = "Restaurar";
                // al minimizar, ocultar el formulario
                this.Hide();
            }
        }

        private void FormNotasUC_LocationChanged(object sender, EventArgs e)
        {
            if (iniciando) return;

            if (WindowState == FormWindowState.Normal)
            {
                MySetting.Left = this.Left;
                MySetting.Top = this.Top;
                TamApp.Left = this.Left;
                TamApp.Top = this.Top;
            }
        }

        private void notaUC1_GrupoCambiado(string grupo, int index)
        {
            // al cambiar de grupo crear las notas
            ElGrupo = grupo;
            ElGrupoIndex = index;

            MostrarGrupos(ElGrupo, ElGrupoIndex);

            for (var i = 0; i < CtrlGrupos.Count; i++)
            {
                if (i == index)
                    AsignarValores(CtrlGrupos[i], true, esNota: false);
                else
                    AsignarValores(CtrlGrupos[i], false, esNota: false);
            }
            if (notaUC1.ComboGrupos.Text != ElGrupo)
                notaUC1.ComboGrupos.Text = ElGrupo;

            // mostrar la primera nota
            MostrarNotas(grupo, 0);

            MySetting.UltimoGrupo = ElGrupo;
        }

        private void notaUC1_NotaCambiada(string nota, int index)
        {
            MostrarGrupos(ElGrupo, ElGrupoIndex);
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
                    //if(MySetting.VistaNotasHorizontal)
                    //    NotasFlowLayoutPanel.SetFlowBreak(lbl, true);
                    //else
                    //    NotasFlowLayoutPanel.SetFlowBreak(lbl, false);

                    // Asignar el tamaño grande de la nota seleccionada
                    //lbl.Width = (int)(NotasFlowLayoutPanel.ClientSize.Width / 2) - 12;
                    //lbl.Height = NotasFlowLayoutPanel.ClientSize.Height - 12;

                    // lo dejo al doble de ancho cuando no se muestra horizontal
                    if (MySetting.VistaNotasHorizontal)
                        lbl.Width = NotasSize.Width;
                    else
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

                    //if (MySetting.VistaNotasHorizontal)
                    //    NotasFlowLayoutPanel.SetFlowBreak(lbl, true);
                    //else
                    //    NotasFlowLayoutPanel.SetFlowBreak(lbl, false);

                    lbl.Size = NotasSize;
                }
                else
                {
                    lbl.Font = new Font(LblGrupo.Font, FontStyle.Regular);
                    lbl.Size = NormalSize;
                }
                //lbl.SendToBack();
            }
            // Por si se quiere que todos tengan el tamaño normal
            // Nota: Los grupos usan NormalSize y las notas NotasSize
            //lbl.Size = NormalSize;
        }

        /// <summary>
        /// Mostrar las notas en el flowPanel.
        /// </summary>
        /// <param name="grupo">El grupo a mostrar.</param>
        /// <param name="index">Indica la nota a marcar como seleccionada.</param>
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
                var lbl = CrearNota(n, col, true);
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

        /// <summary>
        /// Mostrar los grupos en el flowPanel
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="index"></param>
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
                var lbl = CrearNota(s, col, false);
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

        private Label CrearNota(string nota, Color col, bool esNota)
        {
            var lbl = new Label();
            
            AsignarValores(lbl, false, esNota);
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
            tabOpciones.SelectedIndex = 0;

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
            AsignarColores();
        }

        /// <summary>
        /// Asigna los colores de los controles según el tema.
        /// En realidad según los valores de BackColor y ForeColor del control NotasUC.
        /// </summary>
        private void AsignarColores()
        {
            // Esta forma de asignación múltiple de un valor me gusta :-)
            this.BackColor =  notaUC1.BackColor;
            this.ForeColor = notaUC1.ForeColor;
            AsignarColores(tabOpciones);

            // Los colores invertidos de las etiquetas.
            lblEdInfo.BackColor = lblResultadoBuscar.BackColor = lblBuscando.BackColor = btnBuscar.BackColor = btnClasificarGrupos.BackColor = btnBorrar.BackColor = btnCambiarNombre.BackColor = btnMoverNota.BackColor = notaUC1.ForeColor;
            lblEdInfo.ForeColor = lblResultadoBuscar.ForeColor = lblBuscando.ForeColor = btnBuscar.ForeColor = btnClasificarGrupos.ForeColor = btnBorrar.ForeColor = btnCambiarNombre.ForeColor = btnMoverNota.ForeColor = notaUC1.BackColor;
        }

        /// <summary>
        /// Asignar recursivamente los colores. Se asignan los colores de NotaUC.
        /// </summary>
        /// <param name="ctr">El control y controles contenidos al que aplicar los colores.</param>
        /// <param name="invertir">Si se debe invertir la asignación de BackColor y ForeColor.</param>
        /// <remarks>Los botones tienen los colores invertidos.</remarks>
        private void AsignarColores(Control ctr, bool invertir = false)
        {
            if (invertir)
            {
                ctr.ForeColor = notaUC1.BackColor;
                ctr.BackColor = notaUC1.ForeColor;
            }
            else
            {
                ctr.BackColor = notaUC1.BackColor;
                ctr.ForeColor = notaUC1.ForeColor;
            }

            if (ctr.Controls is null) return;

            foreach (Control c in ctr.Controls)
            {
                AsignarColores(c, c is Button);
            }
        }

        /// <summary>
        /// Asigna los valores de la configuración.
        /// </summary>
        private void AsignarSettings()
        {
            OpcDeshacerCambios();

            if (MySetting.Tema == "Claro")
                notaUC1.Tema = Temas.Claro;
            else
                notaUC1.Tema = Temas.Oscuro;

            if (MySetting.VistaNotasHorizontal)
            {
                HorizontalSize.Width = NotasFlowLayoutPanel.ClientSize.Width - 12;
                NotasSize = HorizontalSize;
            }
            else
                NotasSize = NormalSize;

            NotasFlowLayoutPanel.WrapContents = MySetting.VistaNotasHorizontal;

            this.ShowInTaskbar = MySetting.ShowInTaskBar;

            notaUC1.txtEdit.WordWrap = MySetting.AjusteLineas;
            notaUC1.AutoGuardar = MySetting.Autoguardar;
            notaUC1.NoGuardarEnBlanco = MySetting.NoGuardarEnBlanco;
            notaUC1.GuardarEnDrive = MySetting.GuardarEnDrive;
            notaUC1.BorrarNotasAnterioresDeDrive = MySetting.BorrarNotasAnterioresDeDrive;

            TamApp = TamAppOriginal;
            if (MySetting.RecordarTam)
            {
                // Si Left tiene un valor pequeño y solo hay una pantalla, ponerlo a cero.
                if (MySetting.Left < 0 && Screen.AllScreens.Length < 2)
                    MySetting.Left = 0;

                TamApp = (MySetting.Left, MySetting.Top, MySetting.Width, MySetting.Heigh);
            }
            AsignarTamañoVentana(TamApp);
            if (MySetting.IniciarMinimizada)
                this.WindowState = FormWindowState.Minimized;

            MostrarNotas(notaUC1.Grupo, notaUC1.ComboNotas.SelectedIndex);
        }

        private void notaUC1_MenuCerrar(string mensaje)
        {
            MnuNotifyCerrar_Click(null, null);
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

            notaUC1.AsignarGrupos(false);
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
            notaUC1.Notas.Remove(grupo);

            cboEdGrupos.Items.Clear();
            foreach (var g in notaUC1.Notas.Keys)
            {
                cboEdGrupos.Items.Add(g);
            }
            iniciando = false;
            notaUC1.AsignarGrupos(grupo: nuevoGrupo);
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
            notaUC1.AsignarGrupos(grupo: grupoDestino);
            
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabOpciones.SelectedTab.Name == "tabOpciones")// .SelectedIndex == 4)
            {
                OpcDeshacerCambios();
                return;
            }

            //if (tabOpciones.SelectedIndex != 2) return;
            if (tabOpciones.SelectedTab.Name != "tabEditarGrupos") return;
            
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

            notaUC1.AsignarGrupos(false);
            iniciando = false;
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void MnuNotifyRestaurar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                NotifyMenuRestaurar.Text = "Minimizar";
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
            }
            else
            {
                NotifyMenuRestaurar.Text = "Restaurar";
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void MnuNotifyCerrar_Click(object sender, EventArgs e)
        {
            // Indicar que se está cerrando desde las opciones de cerrar el programa
            // no desde la X del formulario.
            NoCerrar = false;
            this.Close();
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

        //
        // Para las opciones de configuración.
        //

        private bool OpcConfigurando = false;

        /// <summary>
        /// Deshace los cambios en el panel de configuración.
        /// Llamarla cuando se entra en la ficha de opciones (si no se está ya configurando).
        /// </summary>
        private void OpcDeshacerCambios()
        {
            if (OpcConfigurando) return;

            OpcChkAutoGuardar.Checked = MySetting.Autoguardar;
            OpcChkRecordarTam.Checked = MySetting.RecordarTam;
            OpcChkAjusteLineas.Checked = MySetting.AjusteLineas;
            OpChkNoGuardarEnBlanco.Checked = MySetting.NoGuardarEnBlanco;
            OpcChkIniciarMinimizada.Checked = MySetting.IniciarMinimizada;
            OpcChkMinimizarAlCerrar.Checked = MySetting.MinimizarAlCerrar;
            OpcChkMostrarMismoGrupo.Checked = MySetting.MostrarMismoGrupo;
            OpcChkMostrarHorizontal.Checked = MySetting.VistaNotasHorizontal;
            OpcChkShowInTaskBar.Checked = MySetting.ShowInTaskBar;
            OpcChkGuardarEnDrive.Checked = MySetting.GuardarEnDrive;
            OpcChkBorrarNotasAnterioresDrive.Checked = MySetting.BorrarNotasAnterioresDeDrive;

            OpcBtnDeshacer.Enabled = false;
        }

        /// <summary>
        /// Comprueba si se han modificado las opciones.
        /// </summary>
        /// <returns>True si se han modificado las opciones.</returns>
        private void OpcDatosModificados()
        {
            var modificado = false;

            if (OpcChkAutoGuardar.Checked != MySetting.Autoguardar)
                modificado = true;
            else if (OpcChkRecordarTam.Checked != MySetting.RecordarTam)
                modificado = true;
            else if (OpcChkAjusteLineas.Checked != MySetting.AjusteLineas)
                modificado = true;
            else if (OpChkNoGuardarEnBlanco.Checked != MySetting.NoGuardarEnBlanco)
                modificado = true;
            else if (OpcChkIniciarMinimizada.Checked != MySetting.IniciarMinimizada)
                modificado = true;
            else if (OpcChkMinimizarAlCerrar.Checked != MySetting.MinimizarAlCerrar)
                modificado = true;
            else if (OpcChkMostrarMismoGrupo.Checked != MySetting.MostrarMismoGrupo)
                modificado = true;
            else if (OpcChkMostrarHorizontal.Checked != MySetting.VistaNotasHorizontal)
                modificado = true;
            else if (OpcChkShowInTaskBar.Checked != MySetting.ShowInTaskBar)
                modificado = true;
            else if (OpcChkGuardarEnDrive.Checked != MySetting.GuardarEnDrive)
                modificado = true;
            else if (OpcChkBorrarNotasAnterioresDrive.Checked != MySetting.BorrarNotasAnterioresDeDrive)
                modificado = true;

            OpcBtnDeshacer.Enabled = modificado;
        }

        private void OpcBtnRestablecerTam_Click(object sender, EventArgs e)
        {
            // Restablecer el tamaño y posición de la ventana de la aplicación.
            AsignarTamañoVentana(TamAppOriginal);
        }

        /// <summary>
        /// Asignar el tamaño y posición a la ventana.
        /// </summary>
        /// <param name="nuevoTam"></param>
        private void AsignarTamañoVentana((int Left, int Top, int Width, int Height) nuevoTam)
        {
            var iniTmp = iniciando;
            iniciando = true;

            if (nuevoTam.Left == -2)
            {
                this.CenterToScreen();
                if (nuevoTam.Width != -1)
                    this.Width = nuevoTam.Width;
                if (nuevoTam.Height != -1)
                    this.Height = nuevoTam.Height;
            }
            else
            {
                if (nuevoTam.Left != -1)
                    this.Left = nuevoTam.Left;
                if (nuevoTam.Top != -1)
                    this.Top = nuevoTam.Top;
                if (nuevoTam.Width != -1)
                    this.Width = nuevoTam.Width;
                if (nuevoTam.Height != -1)
                    this.Height = nuevoTam.Height;
            }
            iniciando = iniTmp;
        }

        /// <summary>
        /// La posición y tamaño original de la ventana.
        /// </summary>
        private (int Left, int Top, int Width, int Height) TamAppOriginal = (-2, -1, 823, 613);

        /// <summary>
        /// La posición y tamaño actual de la ventana.
        /// </summary>
        private (int Left, int Top, int Width, int Height) TamApp;

        private void OpcBtnGuardar_Click(object sender, EventArgs e)
        {
            MySetting.Autoguardar = OpcChkAutoGuardar.Checked;
            MySetting.RecordarTam = OpcChkRecordarTam.Checked;
            MySetting.AjusteLineas = OpcChkAjusteLineas.Checked;
            MySetting.NoGuardarEnBlanco = OpChkNoGuardarEnBlanco.Checked;
            MySetting.IniciarMinimizada = OpcChkIniciarMinimizada.Checked;
            MySetting.MinimizarAlCerrar = OpcChkMinimizarAlCerrar.Checked;
            MySetting.MostrarMismoGrupo = OpcChkMostrarMismoGrupo.Checked;
            var vistaAnt = MySetting.VistaNotasHorizontal;
            MySetting.VistaNotasHorizontal = OpcChkMostrarHorizontal.Checked;
            MySetting.ShowInTaskBar = OpcChkShowInTaskBar.Checked;
            MySetting.GuardarEnDrive = OpcChkGuardarEnDrive.Checked;
            MySetting.BorrarNotasAnterioresDeDrive = OpcChkBorrarNotasAnterioresDrive.Checked;

            OpcBtnDeshacer.Enabled = false;
            
            MySetting.Save();
            OpcConfigurando = false;

            AsignarSettings();

            if (vistaAnt != MySetting.VistaNotasHorizontal)
                APlicarVista();
        }

        private void OpcBtnDeshacer_Click(object sender, EventArgs e)
        {
            OpcConfigurando = false;
            OpcDeshacerCambios();
        }

        private void Opciones_CheckedChanged(object sender, EventArgs e)
        {
            if (iniciando) return;

            OpcConfigurando = true;
            // Esta opción siempre debe ser TRUE
            OpChkNoGuardarEnBlanco.Checked = true;
            OpcDatosModificados();
        }

        private void NotasFlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            if (OpcChkMostrarHorizontal.Checked)
            {
                HorizontalSize.Width = NotasFlowLayoutPanel.ClientSize.Width - 12;
            }
        }

        private void APlicarVista()
        {
            if (OpcChkMostrarHorizontal.Checked)
            {
                HorizontalSize.Width = NotasFlowLayoutPanel.ClientSize.Width - 12;
                NotasFlowLayoutPanel.WrapContents = true;
            }
            else
                NotasFlowLayoutPanel.WrapContents = false;

            MostrarNotas(notaUC1.Grupo, notaUC1.ComboNotas.SelectedIndex);
        }

        private void OpcLinkSolicitarAutorización_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.elguillemola.com/2020/12/te-gustaria-obtener-mas-prestaciones-de-gsnotasnet/#comments");
        }
    }
}
