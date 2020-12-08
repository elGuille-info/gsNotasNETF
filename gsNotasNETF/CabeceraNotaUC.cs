//-----------------------------------------------------------------------------
// SeleccionarNotaUC                                                (05/Dic/20)
// Seleccionar una nota a editar
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
using System.Diagnostics;

namespace gsNotasNETF
{
    /// <summary>
    /// Control para poner como cabecera del control de notas y gestionar los grupos y notas.
    /// </summary>
    /// <remarks>Se usa por NotaUC. No usar directamente.</remarks>
    internal partial class CabeceraNotaUC : UserControl
    {
        private bool iniciando = true;

        public CabeceraNotaUC()
        {
            InitializeComponent();

            CboGrupos.Text = "";
            CboNotas.Text = "";
            LabelTitulo.Text = "";
            BackColor = Color.White;
            ForeColor = Color.FromArgb(0, 99, 177);

            iniciando = false;
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

        /// <summary>
        /// El color de fondo del control y del color del texto del título.
        /// </summary>
        [Browsable(true)]
        [Description("El color de fondo del control y del color del texto del título.")]
        [DefaultValue("White")]
        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                LabelTitulo.ForeColor = value;
                CboGrupos.BackColor = value;
                CboNotas.BackColor = value;
            }
        }

        /// <summary>
        /// El color del texto y del fondo del título.
        /// </summary>
        [Browsable(true)]
        [Description("El color del texto y del fondo del título.")]
        [DefaultValue("0; 99; 177")]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                LabelTitulo.BackColor = value;
                CboGrupos.ForeColor = value;
                CboNotas.ForeColor = value;
            }
        }

        /// <summary>
        /// El título a mostrar.
        /// </summary>
        [Browsable(true)]
        [Description("El título a mostrar.")]
        [DefaultValue("NotasUC")]
        public string Titulo
        {
            get { return LabelTitulo.Text; }
            set { LabelTitulo.Text = value; }
        }

        /// <summary>
        /// El ComboBox con los grupos de notas.
        /// </summary>
        [Browsable(true)]
        [Description("El ComboBox con los grupos.")]
        public ComboBox ComboGrupos
        {
            get { return CboGrupos; }
        }

        /// <summary>
        /// El ComboBox con las notas.
        /// </summary>
        /// <remarks>Hay que rellenarla con las notas de cada elemento del Grupo</remarks>
        [Browsable(true)]
        [Description("El ComboBox con las notas.")]
        public ComboBox ComboNotas
        {
            get { return CboNotas; }
        }

        ///// <summary>
        ///// La etiqueta del título.
        ///// </summary>
        //[Browsable(true)]
        //[Description("La etiqueta del título")]
        //public Label EtiquetaTitulo
        //{
        //    get { return LabelTitulo; }
        //}

        private Dictionary<string, List<string>> _notas = new Dictionary<string, List<string>>();

        /// <summary>
        /// Colección con los grupos y las notas asociadas a cada grupo.
        /// </summary>
        [Browsable(false)]
        public Dictionary<string, List<string>> Notas
        {
            get { return _notas; }
            set
            {
                _notas = value;
                AsignarGrupos();
            }
        }

        /// <summary>
        /// Asignar los grupos.
        /// No asigna las notas hasta que se seleccione un grupo.
        /// </summary>
        [Browsable(false)]
        public void AsignarGrupos()
        {
            iniciando = true;

            CboGrupos.Items.Clear();
            CboNotas.Items.Clear();
            CboGrupos.Text = "";
            CboNotas.Text = "";

            if (ComprobarNotasEsNulo())
                return;

            foreach (var k in _notas.Keys)
                CboGrupos.Items.Add(k);

            iniciando = false;

            if (CboGrupos.Items.Count > 0)
                CboGrupos.SelectedIndex = 0;
        }

        /// <summary>
        /// Comprueba si _notas es nulo o las claves del dictionary es nulo
        /// en ese caso crea un nuevo objeto en _notas y devuelve true.
        /// </summary>
        /// <returns>True si _notas es nulo o _notas.Keys es nulo (pero crea la colección _notas),
        /// False si _notas no era nulo.</returns>
        private bool ComprobarNotasEsNulo()
        {
            if (_notas is null || _notas.Keys is null)
            {
                _notas = new Dictionary<string, List<string>>();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Devuelve la nota que se ha seleccionado (el texto del combo de notas).
        /// </summary>
        [Browsable(false)]
        public string Nota
        {
            get { return CboNotas.Text; }
        }

        /// <summary>
        /// Devuelve el nombre del grupo seleccionado (el texto del combo de grupos).
        /// </summary>
        [Browsable(false)]
        public string Grupo
        {
            get { return CboGrupos.Text; }
            set { CboGrupos.Text = value; }
        }

        /// <summary>
        /// El valor de la longitud del texto a mostrar en el título.
        /// El título será el nombre del grupo y la nota seleccionada.
        /// </summary>
        [Browsable(false)]
        [Description("El valor predeterminado de la longitud máxima del título")]
        [DefaultValue(70)]
        public const int LongitudTituloNotaDefault = 70;

        /// <summary>
        /// Resetea el control.
        /// En realidad la longitud del título.
        /// </summary>
        public void Reset()
        {
            LongitudTituloNota = LongitudTituloNotaDefault;
        }

        /// <summary>
        /// Longitud del título de la nota.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(LongitudTituloNotaDefault)]
        [Description("La longitud máxima del título")]
        public int LongitudTituloNota { get; set; } = LongitudTituloNotaDefault;

        /// <summary>
        /// El título de la nota (los <see cref="LongitudTituloNota"/> primeros caracteres)
        /// </summary>
        [Browsable(false)]
        public string TituloNota
        {
            get
            {
                if (string.IsNullOrEmpty(Nota))
                    return "";

                var s = Nota.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                if (s.Length == 0)
                    return Nota;

                if (s[0].Length < LongitudTituloNota)
                    return s[0];

                return s[0].Substring(0, LongitudTituloNota);
            }
        }

        /// <summary>
        /// Añadir un nuevo grupo de notas vacío.
        /// Si el grupo existe, se ignora esta creación, 
        /// ya que los grupos no pueden estar repetidos.
        /// </summary>
        /// <param name="grupo">El nombre del grupo</param>
        [Browsable(false)]
        public void GruposAdd(string grupo)
        {
            _ = ComprobarNotasEsNulo();

            if (!_notas.ContainsKey(grupo))
            {
                _notas.Add(grupo, new List<string>());
                AsignarGrupos();
            }
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
            _ = ComprobarNotasEsNulo();

            if (!_notas.ContainsKey(grupo))
                _notas.Add(grupo, notas);

            _notas[grupo].AddRange(notas);

            AsignarGrupos();
        }

        /// <summary>
        /// Añadir una nota al grupo indicado.
        /// No se comprueba si ya existe esa nota, simplemente se añade.
        /// si el grupo no existe, se crea uno nuevo.
        /// </summary>
        /// <param name="grupo">El nombre del grupo.</param>
        /// <param name="nota">La nota a añadir.</param>
        [Browsable(false)]
        public void GruposAdd(string grupo, string nota)
        {
            _ = ComprobarNotasEsNulo();

            if (_notas.ContainsKey(grupo))
            {
                _notas.TryGetValue(grupo, out List<string> colNotas);
                colNotas.Add(nota);
            }
            else
                _notas.Add(grupo, new List<string> { nota });

            AsignarGrupos();
        }

        /// <summary>
        /// Añadir una nota al grupo indicado.
        /// Si el grupo no existe, se crea.
        /// </summary>
        /// <param name="grupo">El nombre del grupo.</param>
        /// <param name="nota">La nota a añadir.</param>
        [Browsable(false)]
        public void NotasAdd(string grupo, string nota)
        {
            _ = ComprobarNotasEsNulo();

            if (_notas.ContainsKey(grupo))
            {
                _notas.TryGetValue(grupo, out List<string> colNotas);
                colNotas.Add(nota);
            }
            else
                _notas.Add(grupo, new List<string> { nota });

            CboNotas.Items.Add(nota);
        }

        /// <summary>
        /// Añadir notas al grupo indicado.
        /// Si el grupo no existe, se crea.
        /// </summary>
        /// <param name="grupo">El nombre grupo.</param>
        /// <param name="notas">Colección con las notas a asignar al grupo.</param>
        [Browsable(false)]
        public void NotasAdd(string grupo, List<string> notas)
        {
            _ = ComprobarNotasEsNulo();

            if (!_notas.ContainsKey(grupo))
                _notas.Add(grupo, notas);
            else
                _notas[grupo].AddRange(notas);

            AsignarNotas(grupo);
        }

        /// <summary>
        /// Reemplazar la nota actualmente seleccionada en el CboNotas por la nueva.
        /// </summary>
        /// <param name="grupo">El nombre del grupo.</param>
        /// <param name="nota">La nueva nota a poner.</param>
        [Browsable(false)]
        public void NotaReplace(string grupo, string nota)
        {
            var i = CboNotas.SelectedIndex;
            if (i == -1)
                return;

            iniciando = true;

            _notas[grupo][CboNotas.SelectedIndex] = nota;
            CboNotas.Items[CboNotas.SelectedIndex] = nota;

            OnNotaCambiada(nota, CboNotas.SelectedIndex);

            iniciando = false;
        }


        /// <summary>
        /// Array con los caracteres especiales que se sustituirán al guardar.
        /// </summary>
        [Browsable(true)]
        [Description("Array con los caracteres especiales que se sustituirán al guardar.")]
        public string[] EspCaracteres = {"\n\r", "\n","\r", "\"", "<", ">", "&" };
        
        /// <summary>
        /// Array con las marcas a reemplazar según el caracter especial.
        /// </summary>
        [Browsable(true)]
        [Description("Array con las marcas a reemplazar según el caracter especial.")]
        public string[] EspMarcas = { "|NL|","|CR|","|LF|", "|quot|", "|lt|", "|gt|", "|A|" };

        /// <summary>
        /// Cambia los caracteres normales en marcas para guardar.
        /// </summary>
        /// <param name="s">La cadena donde se harán los cambios.</param>
        /// <returns>Una nueva cadena con los caracteres sustituidos por las marcas.</returns>
        /// <remarks>Usar esta función para guardarlos en el fichero.</remarks>
        private string espQuitar(string s)
        {
            // sustituir los caracteres especiales
            // usar esta función para guardarlo en la colección
            if (s.StartsWith(" "))
                s = "|sp|" + s;
            for (int j = 0; j < EspCaracteres.Length; j++)
                s = s.Replace(EspCaracteres[j], EspMarcas[j]);
            return s;
        }

        /// <summary>
        /// Cambia las marcas especiales por los caracteres normales.
        /// </summary>
        /// <param name="s">La cadena donde se harán los cambios.</param>
        /// <returns>Una nueva cadena con las marcas sustituidas por los caracteres.</returns>
        /// <remarks>Usar esta función al leer del fichero y mostrarlos correctamente.</remarks>
        private string espPoner(string s)
        {
            // restablecer los caracteres especiales
            // usar esta función para mostrarlos correctamente
            if (s.StartsWith("|sp|"))
                s = s.Substring(4);
            for (int j = 0; j < EspCaracteres.Length; j++)
                s = s.Replace(EspMarcas[j], EspCaracteres[j]);
            return s;
        }

        /// <summary>
        /// Guarda las notas en el fichero indicado.
        /// </summary>
        /// <param name="path">El path completo donde se guardarán las notas.</param>
        /// <returns>true si se guardaron correctamente las notas, en otro caso, false.</returns>
        [Browsable(false)]
        public bool GuardarNotas(string path)
        {
            try 
            {
                using (var sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    sw.WriteLine("#Formato NotasUC - v1.0.0.0 - 05-dic-2020");
                    sw.WriteLine("#");
                    sw.WriteLine("# Fichero de Notas con formato NotasUC");
                    sw.WriteLine("#");
                    sw.WriteLine($"# Contenido de {Path.GetFileName(path)}");
                    sw.WriteLine("#");
                    sw.WriteLine("# Formato:");
                    sw.WriteLine("#    G:Nombre del grupo");
                    sw.WriteLine("#       Lista de notas del grupo 1, una en cada línea");
                    sw.WriteLine("#    GFin: # Fin de las notas del grupo");
                    sw.WriteLine("#");
                    sw.WriteLine("# Notas:");
                    sw.WriteLine("#     No se guardan los grupos y notas que estén en blanco.");
                    sw.WriteLine("#     Las líneas que empiecen por # no se procesan.");
                    sw.WriteLine("#         No usar # después de la nota o el grupo, ya que se asignarán como si fuesen parte del texto.");
                    sw.WriteLine("#     Si la nota tiene estos caracteres, se hará un cambio al guardar el texto:");
                    sw.WriteLine("#         Las comillas dobles se guardan como |quot|.");
                    sw.WriteLine("#         El signo mayor > se guarda como |gt|.");
                    sw.WriteLine("#         El signo mayor < se guarda como |lt|.");
                    sw.WriteLine("#         El ampersand & se guarda como |A|.");
                    sw.WriteLine("#         Si la cadena empieza con un espacio, se sustituye por |sp|.");
                    sw.WriteLine(@"#         Los cambios de línea  '\n\r' (CrLf) se guardan como |NL|.");
                    sw.WriteLine(@"#         Los cambios de línea  '\n'   (Cr)   se guardan como |CR|.");
                    sw.WriteLine(@"#         Los retornos de carro '\r'   (Lf)   se guardan como |LF|.");
                    sw.WriteLine("#             La comprobación se hace en este orden: CrLf, Cr, Lf");
                    sw.WriteLine("#             Es para los casos que haya distintos cambios de línea (según el formato del fichero)");
                    sw.WriteLine("#");
                    
                    foreach (var g in _notas.Keys)
                    {
                        if (g.Any())
                        {
                            sw.WriteLine($"G:{g}");
                            foreach (var n in _notas[g])
                                if (n.Any())
                                    sw.WriteLine(espQuitar(n));
                            sw.WriteLine($"GFin:{g}");
                        }
                    }
                    sw.Flush();
                    sw.Close();
                }
                return true;
            }
            catch { return false; };
        }

        /// <summary>
        /// Lee las notas del fichero indicado y las asigna a la colección <see cref="Notas"/>.
        /// </summary>
        /// <param name="path">El path completo donde están las notas guardadas.</param>
        [Browsable(false)]
        public void LeerNotas(string path)
        {
            var colNotas = new Dictionary<string, List<string>>();

            try
            {
                if (!File.Exists(path))
                {
                    _notas = colNotas;
                    return;
                }

                using var sr = new StreamReader(path, Encoding.UTF8, true);
                while (!sr.EndOfStream)
                {
                    var s = sr.ReadLine();
                    if (!string.IsNullOrEmpty(s))
                    {
                        var s1 = s.TrimStart();
                        // Ignorar los comentarios #
                        if (s1.StartsWith("#"))
                            continue;

                        // Si es un grupo
                        if (s1.StartsWith("g:", StringComparison.OrdinalIgnoreCase))
                        {
                            var i = s.IndexOf("g:", StringComparison.OrdinalIgnoreCase);
                            if (i == -1) continue;

                            var g = s.Substring(i + 2).Trim();
                            // Es un grupo
                            // si ya existe, se ignora, pero se leen las notas y se continúa
                            var existe = false;
                            if (colNotas.ContainsKey(g))
                                existe = true;
                            else
                                colNotas.Add(g, new List<string>());

                            // Leer las notas
                            while (!sr.EndOfStream)
                            {
                                s = sr.ReadLine();
                                if (string.IsNullOrEmpty(s))
                                    continue;

                                s1 = s.TrimStart();
                                if (!s1.StartsWith("gfin:", StringComparison.OrdinalIgnoreCase))
                                {
                                    if (!existe)
                                        colNotas[g].Add(espPoner(s));
                                }
                                else
                                    break;
                            }
                        }
                    }
                }
                sr.Close();
            }
            catch(Exception ex) 
            { 
                Debug.WriteLine(ex.Message); 
            };

            _notas = colNotas;
            AsignarGrupos();
        }

        /// <summary>
        /// Asignar las notas del grupo indicado.
        /// </summary>
        /// <param name="grupo"></param>
        [Browsable(false)]
        public void AsignarNotas(string grupo)
        {
            CboNotas.Items.Clear();

            if (string.IsNullOrEmpty(grupo) || !_notas.ContainsKey(grupo))
                return;

            iniciando = true;

            if (_notas.TryGetValue(grupo, out List<string> colNotas))
            {
                // Rellenar el grupo de notas
                for (var i = 0; i < colNotas.Count; i++)
                {
                    CboNotas.Items.Add(colNotas[i]);
                }

                iniciando = false;

                if (CboNotas.Items.Count > 0)
                    CboNotas.SelectedIndex = 0;
            }
        }

        private void CboGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iniciando) return;

            Titulo = $"'{Grupo} - {TituloNota}'";

            if (CboGrupos.Items.Count > 0 && CboGrupos.SelectedIndex != -1)
                OnGrupoCambiado(Grupo, CboGrupos.SelectedIndex);

            AsignarNotas(Grupo);
        }

        private void CboGrupos_Validating(object sender, CancelEventArgs e)
        {
            if (iniciando) return;

            Titulo = $"'{Grupo} - {TituloNota}'";

            if (CboGrupos.Items.Count > 0 && CboGrupos.SelectedIndex != -1)
                OnGrupoCambiado(Grupo, CboGrupos.SelectedIndex);

            if(!_notas.ContainsKey(Grupo))
                GruposAdd(Grupo, "");
            else 
                AsignarNotas(Grupo);
        }

        private void CboNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iniciando) return;

            Titulo = $"'{Grupo} - {TituloNota}'";

            OnNotaCambiada(Nota, CboNotas.SelectedIndex);
        }

        private void CboNotas_Validating(object sender, CancelEventArgs e)
        {
            if (iniciando) return;

            Titulo = $"'{Grupo} - {TituloNota}'";

            if (CboNotas.Items.Count > 0 && CboNotas.SelectedIndex != -1)
                OnNotaCambiada(Nota, CboNotas.SelectedIndex);

            if (_notas.ContainsKey(Grupo) && !_notas[Grupo].Contains(Nota))
                NotasAdd(Grupo, Nota);
        }

        private void CboGrupos_KeyUp(object sender, KeyEventArgs e)
        {
            if (iniciando) return;

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                    SendKeys.Send("{TAB}");

                OnGrupoCambiado(Grupo, CboGrupos.SelectedIndex);
            }
        }

        private void CboNotas_KeyUp(object sender, KeyEventArgs e)
        {
            if (iniciando) return;

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void CboGrupos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (iniciando) return;

            if (e.KeyChar == '\n')
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void CboNotas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (iniciando) return;

            if (e.KeyChar == '\n')
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
