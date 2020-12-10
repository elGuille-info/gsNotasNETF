//-----------------------------------------------------------------------------
// NotaUC                                                           (05/Dic/20)
// Editor de notas (y grupos)
// Unifico CabeceraNotaUC y NotaUC en este fichero                  (09/Dic/20)
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
    /// Control para manejar los grupos y notas.
    /// </summary>
    public partial class NotaUC : UserControl
    {
        private bool iniciando = true;

        public NotaUC()
        {
            InitializeComponent();

            CboGrupos.Text = "";
            CboNotas.Text = "";
            LabelTitulo.Text = "";
            BackColor = Color.White;
            ForeColor = Color.FromArgb(0, 99, 177);

            var ensamblado = System.Reflection.Assembly.GetCallingAssembly();
            var fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(ensamblado.Location);
            FileVersion = fvi.FileVersion;
            NombreProducto = fvi.ProductName;
            VersionProducto = fvi.ProductVersion;

            FicNotas = Path.Combine(DirDocumentos, $"{fvi.ProductName}.notasUC.txt");

            LongitudTituloNota = LongitudTituloNotaDefault;

            // Esto estaba en el evento Load
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

            iniciando = false;
        }

        [Browsable(true)]
        [Description("Este evento se produce cuando se cambia el tema.")]
        [Category("NotasUC")]
        public event TemaCambiado CambioDeTema;

        protected virtual void OnCambioDeTema(Temas tema)
        {
            CambioDeTema?.Invoke(tema);
        }

        [Browsable(true)]
        [Description("Este evento se produce cuando se ha elegido el menú de cerrar.")]
        [Category("NotasUC")]
        public event MensajeDelegate MenuCerrar;

        protected virtual void OnMenuCerrar(string mensaje)
        {
            MenuCerrar?.Invoke(mensaje);
        }

        /// <summary>
        /// Este evento se usará para avisar de que se ha reemplazado una nota.
        /// </summary>
        [Browsable(true)]
        [Description("Este evento se usará para avisar de que se ha reemplazado una nota.")]
        [Category("NotasUC")]
        public event ReemplazarNota NotaReemplazada;

        protected virtual void OnNotaReemplazada(string grupo, string texto, int index)
        {
            NotaReemplazada?.Invoke(grupo, texto, index);
        }

        /// <summary>
        /// Este evento se lanzará cuando se produzca un error o
        /// un aviso para alertar de que algo no va del todo bien.
        /// </summary>
        [Browsable(true)]
        [Description("Este evento se lanzará cuando se produzca un error o un aviso para alertar de que algo no va del todo bien.")]
        [Category("NotasUC")]
        public event MensajeDelegate ErrorEnNotasUC;

        protected virtual void OnDatosErrorEnNotasUC(string mensaje)
        {
            ErrorEnNotasUC?.Invoke(mensaje);
        }

        /// <summary>
        /// Este evento se produce cuando se han cambiado los datos y no se han guardado.
        /// </summary>
        [Browsable(true)]
        [Description("Este evento se produce cuando se han cambiado los datos y no se han guardado.")]
        [Category("NotasUC")]
        public event MensajeDelegate DatosModificados;

        protected virtual void OnDatosModificados(string mensaje)
        {
            DatosModificados?.Invoke(mensaje);
        }

        /// <summary>
        /// Se produce cuando se selecciona una nota.
        /// </summary>
        [Browsable(true)]
        [Description("Se produce cuando se selecciona una nota.")]
        [Category("NotasUC")]
        public event TextoModificado NotaCambiada;

        protected virtual void OnNotaCambiada(string texto, int index)
        {
            NotaCambiada?.Invoke(texto, index);
        }

        /// <summary>
        /// Se produce cuando se selecciona un grupo.
        /// </summary>
        [Browsable(true)]
        [Description("Se produce cuando se selecciona un grupo.")]
        [Category("NotasUC")]
        public event TextoModificado GrupoCambiado;

        protected virtual void OnGrupoCambiado(string texto, int index)
        {
            GrupoCambiado?.Invoke(texto, index);
        }

        private bool _ModoEdicionNota = false;

        /// <summary>
        /// Poner o quitar el Modo de edición.
        /// Si está activo (true) no se pueden añadir notas ni grupos,
        /// solo se permite actualizar la nota que actualmente se está editando.
        /// </summary>
        [Browsable(true)]
        [Description("Poner o quitar el Modo de edición. Si está activo (true) no se pueden añadir notas ni grupos, solo se permite actualizar la nota que actualmente se está editando.")]
        [DefaultValue(false)]
        [Category("NotasUC")]
        public bool ModoEdicionNota
        {
            get { return _ModoEdicionNota; }
            set
            {
                _ModoEdicionNota = value;

                CboGrupos.Enabled = !value;
                CboGrupos.BackColor = this.BackColor;
                CboNotas.Visible = !value;

                if (_ModoEdicionNota)
                {
                    foreach (ToolStripItem c in statusInfoTecla.DropDownItems)
                    {
                        c.Enabled = false;
                        c.Visible = false;
                    }
                    MnuSustituirNota.Enabled = true;
                    MnuSustituirNota.Visible = true;
                    //MnuSustituirNota.Text = "Sustituir nota y cerrar";
                    MnuCerrar.Enabled = true;
                    MnuCerrar.Visible = true;
                    MnuCerrarSeparator.Enabled = true;
                    MnuCerrarSeparator.Visible = true;
                }
                else
                {
                    foreach (ToolStripItem c in statusInfoTecla.DropDownItems)
                    {
                        c.Enabled = true;
                        c.Visible = true;
                    }
                    //MnuSustituirNota.Text = "Sustituir nota";
                }
            }
        }

        /// <summary>
        /// Colores a usar en el tema Oscuro.
        /// Fondo negro, letras amarillo.
        /// </summary>
        [Browsable(true)]
        [Description("Colores a usar en el tema Oscuro. Fondo negro, letras Gold.")]
        [DefaultValue(typeof(Color[]),"Black, Gold")]
        [Category("NotasUC")]
        public Color[] ColoresOscuro { get; set; } = new Color[] { Color.Black, Color.Gold};

        /// <summary>
        /// Colores a usar en el tema Claro.
        /// Fondo blanco, letras en color azul 0,99,177.
        /// </summary>
        [Browsable(true)]
        [Description("Colores a usar en el tema Claro. Fondo blanco, letras en color azul (0,99,177).")]
        [DefaultValue(typeof(Color[]), "White, (0,99,177)")]
        [Category("NotasUC")]
        public Color[] ColoresClaro { get; set; } = new Color[] {Color.White, Color.FromArgb(0,99,177) };

        private Temas _Tema = Temas.Claro;

        /// <summary>
        /// El color de los temas. Light/Claro o Dark/Oscuro.
        /// </summary>
        [Browsable(true)]
        [Description("El color de los temas. Light/Claro o Dark/Oscuro.")]
        [DefaultValue(typeof(Temas),"Claro")]
        [Category("NotasUC")]
        public Temas Tema
        {
            get { return _Tema; }
            set
            {
                _Tema = value;
                if (_Tema == Temas.Claro)
                {
                    BackColor = ColoresClaro[0];
                    ForeColor = ColoresClaro[1];
                }
                else
                {
                    BackColor = ColoresOscuro[0];
                    ForeColor = ColoresOscuro[1];
                }
            }
        }

        //
        // El código que había en CabeceraNotaUC
        //

        #region  El código que había en CabeceraNotaUC

        /// <summary>
        /// El título a mostrar.
        /// </summary>
        [Browsable(true)]
        [Description("El título a mostrar.")]
        [DefaultValue("NotasUC")]
        [Category("NotasUC")]
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
        [Category("NotasUC")]
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
        [Category("NotasUC")]
        public ComboBox ComboNotas
        {
            get { return CboNotas; }
        }

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
        /// Cuando se asigna, se asigna al editor.
        /// </summary>
        [Browsable(true)]
        [Description("Devuelve la nota que se ha seleccionado (el texto del combo de notas). Cuando se asigna, se asigna al editor.")]
        [Category("NotasUC")]
        public string Nota
        {
            get { return CboNotas.Text; }
            set { txtEdit.Text = value; }
        }

        /// <summary>
        /// Lee o asigna el nombre del grupo seleccionado (del texto del combo de grupos).
        /// </summary>
        [Browsable(true)]
        [Description("Lee o asigna el nombre del grupo seleccionado (del texto del combo de grupos).")]
        [Category("NotasUC")]
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
        [Category("NotasUC")]
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
        [Category("NotasUC")]
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

            if(!_ModoEdicionNota)
            {
                _notas[grupo][CboNotas.SelectedIndex] = nota;
                CboNotas.Items[CboNotas.SelectedIndex] = nota;

                OnNotaCambiada(nota, CboNotas.SelectedIndex);
            }
                        
            OnNotaReemplazada(grupo, nota, CboNotas.SelectedIndex);

            iniciando = false;
        }


        /// <summary>
        /// Array con los caracteres especiales que se sustituirán al guardar.
        /// </summary>
        [Browsable(true)]
        [Description("Array con los caracteres especiales que se sustituirán al guardar.")]
        [DefaultValue(typeof(string[]), "\n\r, \n, \r, \", <, >, &" )]
        [Category("NotasUC")]
        public string[] EspCaracteres { get; set; } = { "\n\r", "\n", "\r", "\"", "<", ">", "&" };

        /// <summary>
        /// Array con las marcas a reemplazar según el caracter especial.
        /// </summary>
        [Browsable(true)]
        [Description("Array con las marcas a reemplazar según el caracter especial.")]
        [DefaultValue(typeof(string[]), "|NL|, |CR|, |LF|, |quot|, |lt|, |gt|, |A|")]
        [Category("NotasUC")]
        public string[] EspMarcas { get; set; } = { "|NL|", "|CR|", "|LF|", "|quot|", "|lt|", "|gt|", "|A|" };

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
        public bool GuardarNotas(string path = "")
        {
            if (string.IsNullOrWhiteSpace(path))
                path = FicNotas;

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
        public void LeerNotas(string path ="")
        {
            if (string.IsNullOrWhiteSpace(path))
                path = FicNotas;

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
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            };

            _notas = colNotas;
            AsignarGrupos();
        }

        /// <summary>
        /// Asignar una nota existente a un grupo y en el índice indicado.
        /// Se usará cuando está en modo <see cref="ModoEdicionNota"./>
        /// </summary>
        /// <param name="grupo">El grupo.</param>
        /// <param name="nota">El texto de la nota.</param>
        /// <param name="index">El índice de la nota.</param>
        /// <remarks>Usar esto solo para asignar notas existentes.</remarks>
        public void AsignarNota(string grupo, string nota, int index)
        {
            if (index < 0)
            {
                OnDatosErrorEnNotasUC("El índice no puede ser menor de cero. En: 'AsignarNota'.");
                return;
            }

            iniciando = true;

            // Si está en modo edición no asignarlo a la colección ???
            //if(!_ModoEdicionNota)
            //{
            //}
            if (!_notas.ContainsKey(grupo))
            {
                OnDatosErrorEnNotasUC($"El grupo '{grupo}' no existe. En: 'AsignarNota'.");
                iniciando = false;
                return;
            }
            _notas[grupo][index] = nota;
            if (_notas[grupo].Count <= index)
            {
                OnDatosErrorEnNotasUC($"El índice '{index}' no es válido, valor máximo: {_notas[grupo].Count - 1}. En: 'AsignarNota'.");
                iniciando = false;
                return;
            }
            if((string)CboNotas.Items[index] != nota)
                Modificado = true;

            CboNotas.Items[index] = nota;

            OnNotaCambiada(nota, index);
            OnNotaReemplazada(grupo, nota, index);

            iniciando = false;
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
            OnGrupoCambiado(CboGrupos.Text, CboGrupos.SelectedIndex);
        }

        private void CboGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iniciando) return;

            Titulo = $"'{Grupo} - {TituloNota}'";

            Titulo = $"Notas de '{Grupo}'";
            //    OnGrupoCambiado(nota, index);

            //statusInfo.Text = $"Grupo: '{Grupo}' con {CboNotas.Items.Count} notas";


            if (CboGrupos.Items.Count > 0 && CboGrupos.SelectedIndex != -1)
                OnGrupoCambiado(Grupo, CboGrupos.SelectedIndex);

            AsignarNotas(Grupo);

            statusInfo.Text = $"Grupo: '{Grupo}' con {CboNotas.Items.Count} nota{(CboNotas.Items.Count==1 ? "" : "s")}";
        }

        private void CboGrupos_Validating(object sender, CancelEventArgs e)
        {
            if (iniciando) return;

            Titulo = $"'{Grupo} - {TituloNota}'";

            if (CboGrupos.Items.Count > 0 && CboGrupos.SelectedIndex != -1)
                OnGrupoCambiado(Grupo, CboGrupos.SelectedIndex);

            if (!_notas.ContainsKey(Grupo))
                GruposAdd(Grupo, "");
            else
                AsignarNotas(Grupo);
        }

        private void CboNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iniciando) return;

            Titulo = $"'{Grupo} - {TituloNota}'";
            
            txtEdit.Text = Nota;

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


        #endregion

        //
        // Fin del código de CabeceraNotaUC
        //

        private bool _Modificado;

        //internal NotaUC NotaUCBase = null;

        /// <summary>
        /// La versión del fichero no la de Application.ProductVersion
        /// </summary>
        private string FileVersion;

        private string NombreProducto;
        private string VersionProducto;

        /// <summary>
        /// Indica si los datos se han modificado.
        /// </summary>
        [Browsable(true)]
        [Description("Indica si los datos se han modificado.")]
        [Category("NotasUC")]
        public bool Modificado
        {
            get { return _Modificado; }
            private set 
            {
                _Modificado = value;
                if (_Modificado)
                    OnDatosModificados("Los datos se han modificado.");
            }
        }

        /// <summary>
        /// El fichero donde se guardarán o se leerán las notas.
        /// </summary>
        [Browsable(true)]
        [Description("El fichero con las notas.")]
        [DefaultValue("Notas.notasUC.txt")]
        [Category("NotasUC")]
        public string FicNotas { get; private set; }

        /// <summary>
        /// El path al directorio de documentos.
        /// </summary>
        [Browsable(true)]
        [Description("El directorio de documentos.")]
        [Category("NotasUC")]
        public string DirDocumentos 
        { 
            get {return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); } 
        }

        private void NotaUC_Load(object sender, EventArgs e)
        {
            // No poner nada aquí
        }

        /// <summary>
        /// Asigna el título de la cabecera.
        /// </summary>
        [Browsable(false)]
        [Description("Asigna el título de la cabecera.")]
        [Category("NotasUC")]
        public string TituloCabecera
        {
            get { return Titulo; }
            set 
            {
                ComboNotas.Items.Add(value);
                ComboNotas.Text = value;
                Titulo = TituloNota; 
            }
        }

        /// <summary>
        /// Seleccionar el elemento del grupo con el índice indicado.
        /// </summary>
        /// <param name="index">El índice del combo de los grupos a seleccionar.</param>
        /// <param name="esNota">
        /// True si se debe seleccionar una nota, 
        /// false si se debe seleccioanr un grupo</param>
        [Browsable(false)]
        public void Seleccionar(int index, bool esNota)
        {
            if (index > -1)
            {
                if (esNota)
                {
                    if (ComboNotas.Items.Count > 0)
                        ComboNotas.SelectedIndex = index;
                }
                else
                {
                    if (ComboGrupos.Items.Count > 0)
                        ComboGrupos.SelectedIndex = index;
                }
            }
        }

        /// <summary>
        /// El color de fondo del control, del control de las notas y del color del texto del título.
        /// </summary>
        [Browsable(true)]
        [Description("El color de fondo del control, del control de las notas y del color del texto del título.")]
        [DefaultValue( typeof(Color), "White")]
        [Category("NotasUC")]
        public override Color BackColor 
        { 
            get => base.BackColor;
            set 
            { 
                base.BackColor = value;
                LabelTitulo.ForeColor = value;
                CboGrupos.BackColor = value;
                CboNotas.BackColor = value;
                panelCabecera.BackColor = value;
                panelEditor.BackColor = value;
                txtEdit.BackColor = value;
                statusStrip1.BackColor = value;
                statusInfo.BackColor = value;
                statusInfoPos.BackColor = value;
                statusInfoTecla.BackColor = value;
            }
        }

        /// <summary>
        /// El color del texto y del fondo del título.
        /// </summary>
        [Browsable(true)]
        [Description("El color del texto y del fondo del título.")]
        [DefaultValue(typeof(Color),"0,99,177")]
        [Category("NotasUC")]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                LabelTitulo.BackColor = value;
                CboGrupos.ForeColor = value;
                CboNotas.ForeColor = value;
                panelCabecera.ForeColor = value;
                panelEditor.ForeColor = value;
                txtEdit.ForeColor = value;
                statusStrip1.ForeColor = value;
                statusInfo.ForeColor = value;
                statusInfoPos.ForeColor = value;
                statusInfoTecla.ForeColor = value;
            }
        }

        /// <summary>
        /// El texto del editor.
        /// </summary>
        [Browsable(true)]
        [Description("El texto del editor.")]
        [DefaultValue("")]
        [Category("NotasUC")]
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
        [Category("NotasUC")]
        public string EditorRtf
        {
            get { return txtEdit.Rtf; }
            set { txtEdit.Rtf = value; }
        }

        //
        // Las propiedades y métodos para acceder a los expuestos por CabceraNotaUC
        // Lo suyo es derivar este control de SeleccionarNotaUC pero se solapan los controles.
        //

        ///// <summary>
        ///// Las notas a asignar.
        ///// </summary>
        //[Browsable(false)]
        //[Description("Colección con los grupos y notas.")]
        //[Category("NotasUC")]
        //public Dictionary<string, List<string>> Notas
        //{
        //    get { return Notas; }
        //    set { Notas = value; }
        //}

        ///// <summary>
        ///// Añadir notas al grupo indicado.
        ///// Si el grupo existe, se agregan las notas indicadas.
        ///// </summary>
        ///// <param name="grupo">El nombre grupo.</param>
        ///// <param name="notas">Colección con las notas a asignar al grupo.</param>
        //public void GruposAdd(string grupo, List<string> notas)
        //{
        //    GruposAdd(grupo, notas);
        //}

        ///// <summary>
        ///// Añade un grupo (si no existe previamente) y 
        ///// opcionalmente añade una nota.
        ///// </summary>
        ///// <param name="grupo">El nombre del grupo.</param>
        ///// <param name="nota">Una nota a añadir al grupo. 
        ///// Si es una cadena vacía, solo se crea el grupo si no existe previamente.</param>
        //public void GruposAdd(string grupo, string nota = "")
        //{
        //    if (string.IsNullOrEmpty(nota))
        //        GruposAdd(grupo);
        //    else
        //        GruposAdd(grupo, nota);
        //}

        ///// <summary>
        ///// Guardar las notas en el fichero indicado, si se deja en blanco, se usar <see cref="FicNotas"/>.
        ///// </summary>
        ///// <param name="nuevoNombre">Si se indica, se usará este nombre para guardar el fichero.</param>
        //public void GuardarNotas(string nuevoNombre="")
        //{
        //    if(string.IsNullOrWhiteSpace(nuevoNombre))
        //        GuardarNotas(FicNotas);
        //    else
        //        GuardarNotas(nuevoNombre);

        //    Modificado = false;
        //}

        ///// <summary>
        ///// Leer las notas del fichero indicado, si se deja en blanco, se usar <see cref="FicNotas"/>.
        ///// </summary>
        ///// <param name="nuevoNombre">Si se indica, se usará este nombre para leer el fichero.</param>
        //public void LeerNotas(string nuevoNombre = "")
        //{
        //    if (string.IsNullOrWhiteSpace(nuevoNombre))
        //        LeerNotas(FicNotas);
        //    else
        //        LeerNotas(nuevoNombre);

        //    Modificado = false;
        //}

        //
        // Los métodos de evento de CabeceraNotaUC
        // 

        //private void cabeceraNotaUC1_NotaCambiada(string nota, int index)
        //{
        //    txtEdit.Text = nota;
            
        //    OnNotaCambiada(nota, index);
        //}

        //private void cabeceraNotaUC1_GrupoCambiado(string nota, int index)
        //{
        //    Titulo = $"Notas de '{Grupo}'";
        //    OnGrupoCambiado(nota, index);

        //    statusInfo.Text = $"Grupo: '{Grupo}' con {ComboNotas.Items.Count} notas";
        //}

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

            var g = ComboGrupos.Text;
            if (!ExisteGrupo(g))
            {
                // Añadir el grupo
                Notas.Add(g, new List<string>());
                GruposAdd(g, txtEdit.Text);
                OnGrupoCambiado(g, ComboGrupos.SelectedIndex);
            }
            else
            {
                NotasAdd(g, txtEdit.Text);
                OnNotaCambiada(txtEdit.Text, ComboNotas.SelectedIndex);
            }

            Modificado = true;
        }

        private void MnuSustituirNota_Click(object sender, EventArgs e)
        {
            statusInfoTecla.Text = "Shift+F8";

            var g = ComboGrupos.Text;

            if (!ModoEdicionNota && !ExisteGrupo(g))
                return;

            if(!ModoEdicionNota)
                NotaReplace(g, txtEdit.Text);

            OnNotaReemplazada(g, txtEdit.Text, ComboNotas.SelectedIndex);

            Modificado = true;
        }

        private void MnuClasificar_Click(object sender, EventArgs e)
        {
            statusInfoTecla.Text = "F5";

            var g = ComboGrupos.Text;

            if (!ExisteGrupo(g))
                return;

            Notas[g].Sort();
            AsignarNotas(g);

            Modificado = true;
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

            ComboNotas.Text = "";
            ComboGrupos.Text = "Nuevo-grupo";
            ComboGrupos.Focus();

            statusInfo.Text = "Nuevo grupo, indica el nombre y pulsa ENTER para crearlo.";
        }

        private void MnuEliminarNota_Click(object sender, EventArgs e)
        {
            statusInfoTecla.Text = "F6";

            var i = ComboNotas.SelectedIndex;
            if (i == -1)
                return;

            Notas[ComboGrupos.Text].Remove(ComboNotas.Text);
            ComboNotas.Items.RemoveAt(i);

            statusInfo.Text = "Se ha eliminado la nota, el texto se deja en el editor.";

            Modificado = true;
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

        private void MnuTemaClaro_Click(object sender, EventArgs e)
        {
            Tema = Temas.Claro;
            OnCambioDeTema(Tema);
        }

        private void MnuTemaOscuro_Click(object sender, EventArgs e)
        {
            Tema = Temas.Oscuro;
            OnCambioDeTema(Tema);
        }

        private void MnuTemas_DropDownOpening(object sender, EventArgs e)
        {
            MnuTemaClaro.Checked = (Tema == Temas.Claro);
            MnuTemaOscuro.Checked = (Tema == Temas.Oscuro);
        }

        private void MnuCerrar_Click(object sender, EventArgs e)
        {
            OnMenuCerrar("Cerrar la aplicación.");
        }
    }
}
