//-----------------------------------------------------------------------------
// NotaUC                                                           (05/Dic/20)
// Editor de notas (y grupos)
//
// (c) Guillermo (elGuille) Som, 2020
//-----------------------------------------------------------------------------

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
    /// <summary>
    /// Control para manejar los grupos y notas.
    /// </summary>
    public partial class NotaUC : UserControl
    {
        /// <summary>
        /// El fichero donde se guardarán o se leerán las notas.
        /// </summary>
        [Browsable(false)]
        [Description("El fichero con las notas")]
        [DefaultValue("Notas.notasUC.txt")]
        public string FicNotas { get; private set; }

        /// <summary>
        /// El path al directorio de documentos.
        /// </summary>
        public string DirDocumentos { get; init; }

        /// <summary>
        /// La versión del fichero no la de Application.ProductVersion
        /// </summary>
        private string FileVersion;

        private string NombreProducto;
        private string VersionProducto;

        public NotaUC()
        {
            InitializeComponent();

            var ensamblado = System.Reflection.Assembly.GetCallingAssembly();
            var fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(ensamblado.Location);
            FileVersion = fvi.FileVersion;
            NombreProducto = fvi.ProductName;
            VersionProducto = fvi.ProductVersion;

            DirDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            FicNotas = Path.Combine(DirDocumentos, $"{fvi.ProductName}.notasUC.txt");

            BackColor = Color.White;
            cabeceraNotaUC1.LongitudTituloNota = CabeceraNotaUC.LongitudTituloNotaDefault;
        }

        /// <summary>
        /// Se produce cuando se selecciona una nota.
        /// </summary>
        public event TextoModificado NotaCambiada;

        /// <summary>
        /// Se produce cuando se selecciona un grupo.
        /// </summary>
        public event TextoModificado GrupoCambiado;

        protected virtual void OnNotaCambiada(string texto, int index)
        {
            NotaCambiada?.Invoke(texto, index);
        }
        protected virtual void OnGrupoCambiado(string texto, int index)
        {
            GrupoCambiado?.Invoke(texto, index);
        }

        private void NotaUC_Load(object sender, EventArgs e)
        {
            const int m_AñoActual = 2020;

            var elGuille = "©Guillermo Som (elGuille), 2020";
            if (DateTime.Now.Year > m_AñoActual)
                elGuille += $"-{DateTime.Now.Year}";
            elGuille += $" - {NombreProducto} v{VersionProducto} ({FileVersion})";

            statusInfo.Text = elGuille;
            statusInfoTecla.Text = "...";
            statusInfoPos.Enabled = false;
            statusInfoPos.Text = "L: 0 , C: 0";
            txtEdit.Text = "";
            cabeceraNotaUC1.ComboGrupos.Text = "";
            cabeceraNotaUC1.ComboNotas.Text = "";
            cabeceraNotaUC1.Titulo = "";
        }

        /// <summary>
        /// Seleccionar el elemento del grupo con el índice indicado.
        /// </summary>
        /// <param name="index">El índice del combo de los grupos a seleccionar.</param>
        [Browsable(false)]
        public void Seleccionar(int index)
        {
            if (index > -1)
                cabeceraNotaUC1.ComboNotas.SelectedIndex = index;
        }

        /// <summary>
        /// El ComboBox con los grupos de notas.
        /// </summary>
        [Browsable(true)]
        [Description("El ComboBox con los grupos de notas.")]
        public ComboBox ComboGrupos
        {
            get { return cabeceraNotaUC1.ComboGrupos; }
        }

        /// <summary>
        /// El ComboBox con las notas.
        /// </summary>
        /// <remarks>Hay que rellenarla con las nots de cada elemento del Grupo.</remarks>
        [Browsable(true)]
        [Description("El ComboBox con las notas.")]
        public ComboBox ComboNotas
        {
            get { return cabeceraNotaUC1.ComboNotas; }
        }

        /// <summary>
        /// El color de fondo del control y del control de las notas.
        /// </summary>
        [Browsable(true)]
        [Description("El color de fondo del control y del control de las notas.")]
        [DefaultValue("White")]
        public override Color BackColor 
        { 
            get => base.BackColor;
            set 
            { 
                base.BackColor = value;
                cabeceraNotaUC1.BackColor = value;
            }
        }

        /// <summary>
        /// El color de las letras del control y del control de las notas.
        /// </summary>
        [Browsable(true)]
        [Description("El color de las letras del control y del control de las notas.")]
        [DefaultValue("0; 99; 177")]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                cabeceraNotaUC1.ForeColor = value;
            }
        }

        /// <summary>
        /// El texto del editor.
        /// </summary>
        [Browsable(true)]
        [Description("El texto del editor.")]
        [DefaultValue("")]
        public string EditorText
        {
            get { return txtEdit.Text; }
            set { txtEdit.Text = value; }
        }

        /// <summary>
        /// El texto enriquecido (Rtf) del editor.
        /// </summary>
        [Browsable(true)]
        [Description("El texto enriquecido (Rtf) del editor.")]
        [DefaultValue("")]
        public string EditorRtf
        {
            get { return txtEdit.Rtf; }
            set { txtEdit.Rtf = value; }
        }

        //
        // Las propiedades y métodos para acceder a los expuestos por CabceraNotaUC
        // Lo suyo es derivar este control de SeleccionarNotaUC pero se solapan los controles.
        //

        /// <summary>
        /// Las notas a asignar.
        /// </summary>
        [Browsable(false)]
        public Dictionary<string, List<string>> Notas
        {
            get { return cabeceraNotaUC1.Notas; }
            set { cabeceraNotaUC1.Notas = value; }
        }

        /// <summary>
        /// Añadir notas al grupo indicado.
        /// Si el grupo existe, se agregan las notas indicadas.
        /// </summary>
        /// <param name="grupo">El nombre grupo.</param>
        /// <param name="notas">Colección con las notas a asignar al grupo.</param>
        [Browsable(false)]
        public void GruposAdd(string grupo, List<string> notas)
        {
            cabeceraNotaUC1.GruposAdd(grupo, notas);
        }

        /// <summary>
        /// Añade un grupo (si no existe previamente) y 
        /// opcionalmente añade una nota.
        /// </summary>
        /// <param name="grupo">El nombre del grupo.</param>
        /// <param name="nota">Una nota a añadir al grupo. 
        /// Si es una cadena vacía, solo se crea el grupo si no existe previamente.</param>
        [Browsable(false)]
        public void GruposAdd(string grupo, string nota = "")
        {
            if (string.IsNullOrEmpty(nota))
                cabeceraNotaUC1.GruposAdd(grupo);
            else
                cabeceraNotaUC1.GruposAdd(grupo, nota);
        }

        /// <summary>
        /// Guardar las notas en el fichero indicado, si se deja en blanco, se usar <see cref="FicNotas"/>.
        /// </summary>
        /// <param name="nuevoNombre">Si se indica, se usará este nombre para guardar el fichero.</param>
        public void GuardarNotas(string nuevoNombre="")
        {
            if(string.IsNullOrWhiteSpace(nuevoNombre))
                cabeceraNotaUC1.GuardarNotas(FicNotas);
            else
                cabeceraNotaUC1.GuardarNotas(nuevoNombre);
        }

        /// <summary>
        /// Leer las notas del fichero indicado, si se deja en blanco, se usar <see cref="FicNotas"/>.
        /// </summary>
        /// <param name="nuevoNombre">Si se indica, se usará este nombre para leer el fichero.</param>
        public void LeerNotas(string nuevoNombre = "")
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre))
                cabeceraNotaUC1.LeerNotas(FicNotas);
            else
                cabeceraNotaUC1.LeerNotas(nuevoNombre);
        }

        //
        // Los métodos de evento de CabeceraNotaUC
        // 

        private void cabeceraNotaUC1_NotaCambiada(string nota, int index)
        {
            txtEdit.Text = nota;
            
            OnNotaCambiada(nota, index);
        }

        private void cabeceraNotaUC1_GrupoCambiado(string nota, int index)
        {
            cabeceraNotaUC1.Titulo = $"Notas de '{cabeceraNotaUC1.Grupo}'";
            OnGrupoCambiado(nota, index);
        }

        //
        // Los métodos de evento normales 
        //

        /// <summary>
        /// Muestra la posición en la que se está en el editor.
        /// </summary>
        /// <param name="e">
        /// Un objeto de tipo <see cref="KeyEventArgs"/> o nulo.
        /// Si se llama desde KeyUp o KeyDown pasar el valor de e.
        /// </param>
        private void mostrarPosicion(KeyEventArgs e)
        {
            // Saber la línea y columna de la posición del cursor
            int pos = txtEdit.SelectionStart + 1;
            int lin = txtEdit.GetLineFromCharIndex(pos) + 1;
            int col = pos - txtEdit.GetFirstCharIndexOfCurrentLine();
            if (e != null)
            {
                if (e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift)
                    col = 1;
                else if (e.KeyCode == Keys.Home)
                    col = 1;
            }
            statusInfoPos.Text = $"L: {lin} , C: {col}";
        }

        private void txtEdit_SelectionChanged(object sender, EventArgs e)
        {
            mostrarPosicion(null);
        }

        private void txtEdit_KeyDown(object sender, KeyEventArgs e)
        {
            mostrarPosicion(e);
        }

        private void txtEdit_Enter(object sender, EventArgs e)
        {
            statusInfoPos.Enabled = true;
        }

        private void txtEdit_Leave(object sender, EventArgs e)
        {
            statusInfoPos.Enabled = false;
        }

        private void MnuAñadirNota_Click(object sender, EventArgs e)
        {
            statusInfoTecla.Text = "F8";

            var g = cabeceraNotaUC1.ComboGrupos.Text;
            if (!ExisteGrupo(g))
            {
                // Añadir el grupo
                Notas.Add(g, new List<string>());
                cabeceraNotaUC1.GruposAdd(g, txtEdit.Text);
                OnGrupoCambiado(g, cabeceraNotaUC1.ComboGrupos.SelectedIndex);
            }
            else
            {
                cabeceraNotaUC1.NotasAdd(g, txtEdit.Text);
                OnNotaCambiada(txtEdit.Text, cabeceraNotaUC1.ComboNotas.SelectedIndex);
            }
        }

        private void MnuSustituirNota_Click(object sender, EventArgs e)
        {
            statusInfoTecla.Text = "Shift+F8";

            var g = cabeceraNotaUC1.ComboGrupos.Text;

            if (!ExisteGrupo(g))
                return;

            cabeceraNotaUC1.NotaReplace(g, txtEdit.Text);
        }

        private void MnuClasificar_Click(object sender, EventArgs e)
        {
            statusInfoTecla.Text = "F5";

            var g = cabeceraNotaUC1.ComboGrupos.Text;

            if (!ExisteGrupo(g))
                return;

            Notas[g].Sort();
            cabeceraNotaUC1.AsignarNotas(g);
        }

        /// <summary>
        /// Comprueba si existe el grupo indicado.
        /// </summary>
        /// <param name="g">El nombre del grupo.</param>
        /// <returns>True si el grupo existe, false si no existe.</returns>
        private bool ExisteGrupo(string g)
        {
            if (!Notas.ContainsKey(g))
            {
                statusInfo.Text = $"No existe el grupo {g}";
                return false;
            }
            return true;
        }

        private void MnuGuardar_Click(object sender, EventArgs e)
        {
            statusInfoTecla.Text = "Ctrl+Shift+S";

            if (string.IsNullOrEmpty(FicNotas))
            {
                statusInfo.Text = "No se ha indicado un nombre fichero para guardar.";
                return;
            }
            GuardarNotas();

            MostrarInfoNotas();
        }

        private void MnuLeer_Click(object sender, EventArgs e)
        {
            statusInfoTecla.Text = "Ctrl+L";
            LeerNotas();

            MostrarInfoNotas();
        }

        /// <summary>
        /// Mostrar la información de cuantas notas hay.
        /// </summary>
        private void MostrarInfoNotas()
        {
            var grupos = Notas.Keys.Count;
            var notas = 0;
            foreach (var g in Notas.Keys)
            {
                notas += Notas[g].Count;
            }
            statusInfo.Text = $"Hay {grupos} grupos y {notas} notas en total.";
        }

        private void MnuNuevoGrupo_Click(object sender, EventArgs e)
        {
            statusInfoTecla.Text = "Ctrl+G";

            cabeceraNotaUC1.ComboNotas.Text = "";
            cabeceraNotaUC1.ComboGrupos.Text = "Nuevo-grupo";
            cabeceraNotaUC1.ComboGrupos.Focus();

            statusInfo.Text = "Nuevo grupo, indica el nombre y pulsa ENTER para crearlo.";
        }

        private void MnuEliminarNota_Click(object sender, EventArgs e)
        {
            statusInfoTecla.Text = "F6";

            var i = cabeceraNotaUC1.ComboNotas.SelectedIndex;
            if (i == -1)
                return;

            Notas[cabeceraNotaUC1.ComboGrupos.Text].Remove(cabeceraNotaUC1.ComboNotas.Text);
            cabeceraNotaUC1.ComboNotas.Items.RemoveAt(i);

            statusInfo.Text = "Se ha eliminado la nota, el texto se deja en el editor.";
        }

        private void NotaUC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                statusInfoTecla.Text = "F9";

                if (string.IsNullOrEmpty(FicNotas))
                {
                    statusInfo.Text = "No se ha indicado un nombre de fichero para guardar.";
                    return;
                }
                GuardarNotas();
                MostrarInfoNotas();
            }
        }

        private void MnuAcercaDe_Click(object sender, EventArgs e)
        {
            statusInfoTecla.Text = "F1";
            // Mostrar acerca de
            var titulo = $"Acerca de {Application.ProductName} v{Application.ProductVersion}";
            MessageBox.Show(@$"Acerca de {titulo}

Utilidad para crear notas y grupos de notas.
Las notas se guardan en el fichero '{FicNotas}'.

Operaciones que puedes hacer:
    Añadir nuevos grupos y notas.
    Sustituir una nota con un nuevo texto.
    Eliminar una nota.
    Clasificar las notas del grupo seleccionado.
    Leer y guardar las notas en un fichero de texto.

El formato del fichero de notas es:
    G: Nombre del grupo 1
        Lista de notas del grupo 1, una en cada línea
        GFin: Fin de las notas del grupo 1

Al guardar se sustituyen caracteres especiales por marcadores:
    Las comillas dobles se guardan como |quot|.
    El signo mayor > se guarda como | gt |.
    El signo mayor < se guarda como | lt |.
    El ampersand &se guarda como | A |.
    Si la cadena empieza con un espacio, se sustituye por | sp |.
    Los cambios de línea  '\n\r'(CrLf) se guardan como | NL |.
    Los cambios de línea  '\n'(Cr)   se guardan como | CR |.
    Los retornos de carro '\r'(Lf)   se guardan como | LF |.
    La comprobación se hace en este orden: CrLf, Cr, Lf.

No se guardan los grupos y notas en blanco.",
                $"Acerca de {titulo}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
