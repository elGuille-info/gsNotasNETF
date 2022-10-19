﻿//-----------------------------------------------------------------------------
// FormNotaUC                                                       (05/Dic/20)
// Formulario para manejar las notas
//
// (c) Guillermo Som (elGuille), 2020-2022
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
                        Ver: https://github.com/elGuille-info/gsNotasNETF/releases/tag/v1.0.0.129
v1.0.0.130  17-dic-20   Cambio la forma de usar GuardarNotasDrive para que acepte también una colección con las notas.
                        Quito la opción Mostrar en la barra de tareas de Windows y la dejo siempre a true.
                        Pongo la opción de ocultar/mostrar el panel superior al inicio.
                        Durante la ejecución del programa también se podrá ocultar, pero no afecta al valor del inicio.
v1.0.0.131              Comprobado el correcto funcionamiento de mostrar/ocultar el panel de configuración
v1.0.0.132              Cambio los colores oscuros y pongo comillas simple en la info de los documentos copiados.
v1.0.0.133              Añado opción de invertir los colores del tema actual.
v1.0.0.134              Guardo el estado de invertir colores en la configuración.
                        Ver: https://github.com/elGuille-info/gsNotasNETF/releases/tag/v1.0.0.134
v1.0.0.135  18-dic-20   Hago comprobación de error cuando se guardan las notas en Drive.
v1.0.0.136              Quito las opciones de guardar automáticamente en Drive y borrar las notas anteriores.
                        Ya no se borrarán las notas desde el programa. Me ha dado error de muchos accesos.
                        Pongo un botón para guardar las notas en Drive (pero ya no es automático).
v1.0.0.137              Se crearán copias de seguridad del fichero de notas (al iniciar el programa)
                        No se borrarán las copias de seguridad, de eso te tendrás que encargar tú,
                        ya que se hace una copia cada vez que se inicia la aplicación.
                        Si da error al crear el directorio, se cancela hacer la copia.
v1.0.0.138  19-dic-20   A ver si consigo que el link se vea bien al invertir el tema claro
                        Ahora siempre muestra el color asignado a ForeColor
v1.0.0.139              Al pulsar en el botón del menú, mostrar el menú.
                        Ver: https://github.com/elGuille-info/gsNotasNETF/releases/tag/v1.0.0.139
v1.0.0.140  24-dic-20   Cambio el icono de la aplicación.
v1.0.0.141              Y el del formulario y por tanto el del icono de notificación.
v1.0.0.142  26-dic-20   Se puede iniciar con Windows (se debe ejecutar como administrador).
v1.0.0.143  30-dic-20   Añado un tab para acerca de y hago comprobación de si es la versión más reciente.
                        Añado menú contextual de edición a la caja de texto.
v1.0.0.144  10-feb-21   Quito el aviso cuando se inicia y no puede acceder al registro.
                        Si se quiere seguir mostrando el aviso, asignar true a mostrarAvisoReg
                        Añado la propiedad StatusInfo a NotaUC para mostrar un mensaje en la barra de estado.
v1.0.0.145              Se movieron los botones de Guardar/Cancelar en la pestaña de opciones.
                        Al iniciar la aplicación (o guardar los datos de configuración)
                        ocultar la aplicación si se inicia minimizada.
v1.0.0.146              Para que esto funcione bien en el evento Load hay que usar un temporizador.
v1.0.0.147  14-abr-21   Cambio el icono de FormEditarNotaUC.
v1.0.0.148  21-abr-21   Se "perdieron" los botones de Guardar y Deshacer en las Opciones.
                        Pongo el tamaño mínimo en 800x400, el tamaño en diseño es 823; 659
v1.0.0.149  15-oct-22   Cambio a .NET Framework 4.8.1
v1.0.0.150  18-oct-22   Mover las notas mostradas de forma independiente.
                        Pongo el título con el de la nota y en el status el nombre del grupo (antes mostraba el valor predeterminado).
                        Pongo scroll en el texto de AcercaDe.
                        Cambio tamaño fuente de los tabs. Diseño de editar grupos y notas.
v1.0.0.151              Nuevos directorios para notas y backup gestionado desde NotaUC.
v1.0.0.152              Opción para usar los colores indicados o aleatorio y nuevos colores en tema oscuro.
v1.0.0.153              Crear nuevos grupos desde Editar grupos y notas.
v1.0.0.154              En opciones, mostrar los colores de las etiquetas según el color seleccionado.
v1.0.0.155              Asignar los anchor manualmente (quitados en diseño) porque al FormDesigner se le va la olla.
                        Pongo todos los controles de las opciones.
v1.0.0.156  19-oct-22   Quito código no usado. Asignar el tema en Settings.
v1.0.0.157              Importar notas (deben estar en el formato NotasUC).
v1.0.0.158              No permitir más de una instancia en ejecución.
v1.0.0.159              Nuevo evento en NotaUC: TemaCambiado (equivale a CambioDeTema, marcado como obsoleto).
                        Si se cambia de tema mientras está en opciones, se pierden los colores de la presonalización de los grupos.
v1.0.0.160              Usar Event Properties para manejar los eventos.
v1.0.0.161              Actualizo el enlace de OpcLinkSolicitarAutorización.
                        ToolTip en importar notas.
v1.0.0.162              Menú Siempre encima (TopMost), el control de usuario no tiene la propiedad TopMost, asignarlo al ParentForm.
v1.0.0.163              Menú contextual para editar la nota en ventana separada.
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
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;

namespace gsNotasNETF
{
    public partial class FormNotasUC : Form
    {
        /// <summary>
        /// Si se quiere o no mostrar el aviso en caso de error al escribir en el registro.
        /// </summary>
        private bool mostrarAvisoReg = false;

        /// <summary>
        /// Acceso a los datos de configuración.
        /// </summary>
        private Properties.Settings MySetting = Properties.Settings.Default;

        ///// <summary>
        ///// Array con los controles a no asignar cuando se permite cambiar el tamaño y posición.
        ///// </summary>
        //private readonly string[] NoAsignar;

        /// <summary>
        /// Para controlar que no re-entre en un método de evento.
        /// </summary>
        private bool iniciando = true;
        /// <summary>
        /// Colección con las notas del grupo seleccionado. A mostrar en la ficha Notas.
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
        /// El color de grupo a usar.
        /// </summary>
        private int ColorGrupo { get; set; }

        /// <summary>
        /// Colección con los colores a mostrar en cada grupo y notas de cada grupo.
        /// </summary>
        private List<Color> ColoresGrupo;
        
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

            //// Comprobar si se permiten varias instancias. (19/oct/22 08.25)
            //if (MySetting.PermitirVariasInstancias == false)
            //{
            //    if (NoPermitirVariasInstancias())
            //        return;
            //}

            // Comprobar si se permite más de una instancia de la aplicación.
            // Seleccionar que grupo de colores se usarán

            // Poder indicar en configuración que se use aleatorio o el indicado.
            ColorGrupo = MySetting.ColorGrupo;
            AsignarColoresGrupo();

            //NoAsignar = new string[] { notaUC1.Name };
        }

        ///// <summary>
        ///// Si se está ejecutando la aplicación salir.
        ///// </summary>
        ///// <returns>True si no se permite otra instancia, false si no está en ejecución.</returns>
        //private bool NoPermitirVariasInstancias()
        //{
        //    // No permitir más de una instancia en ejecución. (19/oct/22)

        //    //bool blnInstance;
        //    //_ = new System.Threading.Mutex(false, "gsNotasNETF", out blnInstance);

        //    //if (!blnInstance)
        //    //{
        //    //    Application.Exit();
        //    //    return true;
        //    //}
        //    //return false;

        //    System.Threading.Mutex mut = new System.Threading.Mutex(false, Application.ProductName);
        //    bool running = !mut.WaitOne(0, false);
        //    if (running)
        //    {
        //        Application.ExitThread();
        //        return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// Asignar los colores del grupo según el valor de ColorGrupo (de la configuración).
        /// </summary>
        private void AsignarColoresGrupo()
        {
            int elColorGrupo = ColorGrupo;

            if (ColorGrupo < 1)
            {
                Random rnd = new Random();
                // Un valor aleatorio entre 1 y 4 (inclusive)
                elColorGrupo = rnd.Next(1, 5);
            }
            //var n = elColorGrupo;
            //if (n == 2)
            //    ColoresGrupo = new List<Color>() {Color.LightSkyBlue, Color.Gold, Color.PaleGreen, Color.LightPink, Color.Yellow,
            //                                      Color.FromArgb(0,99,177), Color.LightGoldenrodYellow, Color.AliceBlue, Color.LightGray, Color.Pink };
            //else if (n == 3)
            //    ColoresGrupo = new List<Color>() {Color.AliceBlue, Color.LightPink, Color.LightSkyBlue, Color.LightGoldenrodYellow,
            //                                      Color.LightGray, Color.Gold, Color.FromArgb(0,99,177), Color.PaleGreen, Color.Pink, Color.Yellow };
            //else if (n == 4)
            //    ColoresGrupo = new List<Color>() {Color.LightPink, Color.LightSkyBlue, Color.LightGoldenrodYellow, Color.Gold, Color.DeepPink,
            //                                      Color.PaleGreen, Color.Yellow, Color.LightGray,Color.AliceBlue,Color.FromArgb(0,99,177) };
            //else
            //    // Predeterminado (el que estaba asignado al definir ColoresGrupo.
            //    ColoresGrupo = new List<Color>() {Color.FromArgb(0,99,177), Color.Gold, Color.PaleGreen, Color.Pink, Color.Yellow,
            //                                      Color.LightGray, Color.AliceBlue, Color.LightPink, Color.LightSkyBlue, Color.LightGoldenrodYellow };
            ColoresGrupo = ElColorGrupo(elColorGrupo);
        }

        /// <summary>
        /// Devuelve el color del grupo con un número mínimo de colores.
        /// </summary>
        /// <param name="elColorGrupo"></param>
        /// <param name="cuantosColores"></param>
        private List<Color> ElColorGrupo(int elColorGrupo, int cuantosColores = 15)
        {
            List<Color> colores;

            if (elColorGrupo == 2)
                colores = new List<Color>() {Color.LightSkyBlue, Color.Gold, Color.PaleGreen, Color.MistyRose, Color.LemonChiffon,
                                             Color.FromArgb(0,99,177), Color.LightGoldenrodYellow, Color.AliceBlue, Color.LightGray, Color.LightPink };
            else if (elColorGrupo == 3)
                // Colores pálidos
                colores = new List<Color>() {Color.AliceBlue, Color.LightGoldenrodYellow, Color.PaleGreen, Color.PaleTurquoise, Color.Moccasin,
                                             Color.SeaShell, Color.Beige, Color.LightCyan, Color.LemonChiffon, Color.MistyRose };
            else if (elColorGrupo == 4)
                colores = new List<Color>() {Color.MistyRose, Color.LightSkyBlue, Color.LightGoldenrodYellow, Color.Gold, Color.Pink,
                                             Color.PaleGreen, Color.LemonChiffon, Color.LightGray, Color.AliceBlue, Color.FromArgb(0,99,177) };
            else
                // Predeterminado (el que estaba asignado al definir ColoresGrupo.
                colores = new List<Color>() {Color.FromArgb(0,99,177), Color.Gold, Color.PaleGreen, Color.Pink, Color.LemonChiffon,
                                             Color.LightGray, Color.AliceBlue, Color.LightPink, Color.LightSkyBlue, Color.LightGoldenrodYellow };
            for (int i = colores.Count - 1; i < cuantosColores; i++)
            {
                AñadirNuevoColor(colores);
            }
            return colores;
        }

        private void FormNotasUC_Load(object sender, EventArgs e)
        {
            // Usar un icono de notificación en la barra de tarea
            notifyIcon1.Text = Application.ProductName;
            NotifyMenuRestaurar.Text = "Minimizar";
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Visible = true;

            var grupoTmp = MySetting.UltimoGrupo;
            
            TabsConfigHeightNormal = tabsConfig.Height;

            AsignarSettings();

            AsignarColores();

            NotasFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            GruposFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;

            NotasFlowLayoutPanel.Controls.Clear();
            GruposFlowLayoutPanel.Controls.Clear();

            lblBuscando.Text = "";
            lstResultadoBuscar.Items.Clear();

            // Hacer la copia antes de llamar a leerNotas
            notaUC1.HacerCopia();

            notaUC1.LeerNotas();

            if (MySetting.MostrarMismoGrupo)
                if (notaUC1.Notas.ContainsKey(grupoTmp))
                    notaUC1.ComboGrupos.Text = grupoTmp;

            MySetting.UltimoGrupo = grupoTmp;

            //
            // Antes estaba en AsignarSettings                      (10/Feb/21)
            // 

            if (MySetting.IniciarMinimizada)
                this.WindowState = FormWindowState.Minimized;

            // Usar un temporizador para ocultar al minimizar       (10/Feb/21)
            // cuando se inicia la aplicación.
            timerInicio.Interval = 300;
            timerInicio.Start();

            iniciando = false;
        }

        private void timerInicio_Tick(object sender, EventArgs e)
        {
            timerInicio.Stop();

            if (this.WindowState == FormWindowState.Minimized)
            {
                NotifyMenuRestaurar.Text = "Restaurar";
                // al minimizar, ocultar el formulario
                this.Hide();
            }
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
            if (notaUC1.Tema == Temas.Claro || notaUC1.Tema == Temas.Light)
                MySetting.Tema = "Claro";
            else
                MySetting.Tema = "Oscuro";

            // No hace falta asignarlos, tienen los mismos valores
            if (this.WindowState == FormWindowState.Normal)
            {
                MySetting.Left = this.Left;
                MySetting.Top = this.Top;
                if(!OcultarPanelExpanded)
                {
                    MySetting.Height = this.Height;
                    MySetting.Width = this.Width;
                }
            }
            MySetting.SiempreEncima = notaUC1.SiempreEncima;
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
                if(!OcultarPanelExpanded)
                {
                    MySetting.Width = this.Width;
                    MySetting.Height = this.Height;

                    TabsConfigHeightNormal = tabsConfig.Height;
                }
                TamApp = (MySetting.Left, MySetting.Top, MySetting.Width, MySetting.Height);

                AsignarAnchors();
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
            var cm = new ContextMenu();
            cm.Popup += Cm_Popup;
            cm.MenuItems.Add(new MenuItem("Editar en ventana de tamaño fijo", mnu_EditarEnVentana));

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
                lbl.ContextMenu = cm;
                CtrlNotas.Add(lbl);
                NotasFlowLayoutPanel.Controls.Add(lbl);
                lbl.Tag = j;
                if (j == index)
                {
                    AsignarValores(lbl, true, true);
                }
            }
        }

        private bool esEnMenu = false;

        private void Cm_Popup(object sender, EventArgs e)
        {
            esEnMenu = true;
        }

        private void mnu_EditarEnVentana(object sender, EventArgs e)
        {
            var mnu = sender as MenuItem;
            if (mnu == null) return;

            esEnMenu = true;

            int index = notaUC1.ComboNotas.SelectedIndex;
            Label lbl = (mnu.Parent as ContextMenu).SourceControl as Label;
            if (lbl == null) return;

            index = (int)lbl.Tag;

            FormEditarNotaUC frmEditUC;
            frmEditUC = new FormEditarNotaUC(notaUC1, lbl.Text, index);
            frmEditUC.NotaReemplazada += NotaUC1_NotaReemplazada;
            frmEditUC.FormBorderStyle = FormBorderStyle.None;

            frmEditUC.Show();

            // Al mostrar la nota, ponerla encima y un poco a la derecha para que se vea.
            if (this.TopMost)
            {
                frmEditUC.Left = this.Left + 40;
            }
            frmEditUC.BringToFront();
            esEnMenu = false;
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

        /// <summary>
        /// Asignar los colores para que haya para todos los grupos de notas.
        /// </summary>
        private Color AsignarColoresGrupos()
        {
            Color col = GetRandomColor();
            var rnd = new Random();

            //if (ColoresGrupo.Count == 0)
            //{
            //    for (var j = 0; j < notaUC1.Notas.Keys.Count; j++)
            //    {
            //        ColoresGrupo.Add(col);
            //        var n = rnd.Next(1, 4);
            //        byte r = col.R, g = col.G, b = col.B;
            //        if (n == 1)
            //            r = 0;
            //        else if (n == 2)
            //            g = 0;
            //        else if (n == 3)
            //            b = 0;
            //        Color col2;
            //        do
            //        {
            //            col2 = GetRandomColor(r, g, b);
            //        } while (col.Equals(col2));
            //        col = col2;
            //    }
            //}
            //else if (ColoresGrupo.Count < notaUC1.Notas.Keys.Count)
            //{
            //    for (var j = ColoresGrupo.Count; j < notaUC1.Notas.Keys.Count; j++)
            //    {
            //        var n = rnd.Next(1, 4);
            //        byte r = col.R, g = col.G, b = col.B;
            //        if (n == 1)
            //            r = 0;
            //        else if (n == 2)
            //            g = 0;
            //        else if (n == 3)
            //            b = 0;
            //        Color col2;
            //        do
            //        {
            //            col2 = GetRandomColor(r, g, b);
            //        } while (col.Equals(col2));
            //        col = col2;

            //        ColoresGrupo.Add(col);
            //    }
            //}
            // No es necesario hacer la comprobación de si no hay datos de colores. (18/oct/22 17.11)
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

        /// <summary>
        /// Crear un color de forma aleatoria.
        /// </summary>
        /// <param name="red">Si no se indica o se indica el valor cero, se asignará un valor aleatorio para el rojo.</param>
        /// <param name="green">Si no se indica o se indica el valor cero, se asignará un valor aleatorio para el verde.</param>
        /// <param name="blue">Si no se indica o se indica el valor cero, se asignará un valor aleatorio para el azul.</param>
        private Color GetRandomColor(byte red = 0, byte green = 0, byte blue = 0)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            byte r = red == 0 ? (byte)random.Next(0, 255): red;
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
            if (esEnMenu) return;

            var lbl = sender as Label;
            if (lbl is null)
                return;

            // Si tiene este borde es que está seleccionada. (19/oct/22 14.35)
            // Salir para que al hacer doble-clic reaccione antes.
            if (lbl.BorderStyle == BorderStyle.Fixed3D) return;

            foreach (var l in CtrlNotas)
            {
                AsignarValores(l, false, true);
            }

            AsignarValores(lbl, true, true);

            if (!(lbl.Tag is null))
            {
                notaUC1.Seleccionar((int)lbl.Tag, true);
                lbl.Click -= LblNota_Click;
                lbl.DoubleClick -= LblNota_DoubleClick;
            }
        }

        private void LblNota_DoubleClick(object sender, EventArgs e)
        {
            FormEditarNotaUC frmEditUC;
            frmEditUC = new FormEditarNotaUC(notaUC1, notaUC1.ComboNotas.Text, notaUC1.ComboNotas.SelectedIndex);
            frmEditUC.NotaReemplazada += NotaUC1_NotaReemplazada;

            frmEditUC.Show();

            // Al mostrar la nota, ponerla encima y un poco a la izquierda para que se vea.
            //frmEditUC.TopMost = this.TopMost;
            if (this.TopMost)
            {
                frmEditUC.Left = this.Left + 40;
            }
            frmEditUC.BringToFront();
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
            tabsConfig.SelectedIndex = 0;

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

        private void notaUC1_TemaCambiado(Temas tema)
        {
            AsignarColores();
            // Si está mostrada la pestaña de opciones, colorear los grupos. (19/oct/22 11.29)
            if (tabsConfig.SelectedTab.Name == "tabOpciones")
            {
                OpcCboColorGrupo_SelectedIndexChanged(null, null);
            }
        }

        /// <summary>
        /// Asigna los colores de los controles según el tema.
        /// En realidad según los valores de BackColor y ForeColor del control NotasUC.
        /// </summary>
        private void AsignarColores()
        {
            MySetting.InvertirColores = notaUC1.InvertirColores;

            // Asignar el tema. (19/oct/22 05.53)
            MySetting.Tema = notaUC1.Tema.ToString();

            this.BackColor =  notaUC1.BackColor;
            this.ForeColor = notaUC1.ForeColor;
            AsignarColores(tabsConfig, MySetting.InvertirColores);

            // Esta forma de asignación múltiple de un valor me gusta :-)
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
                // aquí no llega nunca cuando es linkLabel
                if (ctr is LinkLabel)
                {
                    var lnk = ctr as LinkLabel;
                    //lnk.LinkColor = notaUC1.ForeColor;
                    //lnk.VisitedLinkColor = lnk.LinkColor;
                    //lnk.ActiveLinkColor= lnk.LinkColor;
                    lnk.LinkColor = Color.Blue;
                    lnk.VisitedLinkColor = Color.FromArgb(0, 0, 177);
                    lnk.ActiveLinkColor = Color.Red;

                }
                else
                {
                    ctr.ForeColor = notaUC1.BackColor;
                    ctr.BackColor = notaUC1.ForeColor;
                }
            }
            else
            {
                ctr.BackColor = notaUC1.BackColor;
                ctr.ForeColor = notaUC1.ForeColor;

                if (ctr is LinkLabel)
                {
                    var lnk = ctr as LinkLabel;
                    lnk.LinkColor = notaUC1.ForeColor;
                    lnk.VisitedLinkColor = lnk.LinkColor;
                    lnk.ActiveLinkColor = lnk.LinkColor;
                }
            }

            if (ctr.Controls is null) return;

            // no cambiar los colores delcontenido de los flowLayout
            if (ctr.Name.IndexOf("FlowLayout") > -1)
                return;

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

            if (MySetting.VistaNotasHorizontal)
            {
                HorizontalSize.Width = NotasFlowLayoutPanel.ClientSize.Width - 12;
                NotasSize = HorizontalSize;
            }
            else
                NotasSize = NormalSize;

            NotasFlowLayoutPanel.WrapContents = MySetting.VistaNotasHorizontal;

            OcultarPanelSuperior(MySetting.OcultarPanelSuperior);

            IniciarConWindows = MySetting.IniciarConWindows;

            // los valores a asignar a NotaUC
            if (MySetting.Tema == "Claro")
                notaUC1.Tema = Temas.Claro;
            else
                notaUC1.Tema = Temas.Oscuro;

            notaUC1.SiempreEncima = MySetting.SiempreEncima;

            notaUC1.txtEdit.WordWrap = MySetting.AjusteLineas;
            notaUC1.AutoGuardar = MySetting.Autoguardar;
            notaUC1.NoGuardarEnBlanco = MySetting.NoGuardarEnBlanco;
            notaUC1.GuardarEnDrive = false; // MySetting.GuardarEnDrive;
            notaUC1.BorrarNotasAnterioresDeDrive = false; // MySetting.BorrarNotasAnterioresDeDrive;
            notaUC1.InvertirColores = MySetting.InvertirColores;

            TamApp = TamAppOriginal;
            if (MySetting.RecordarTam)
            {
                // Si Left tiene un valor pequeño y solo hay una pantalla, ponerlo a cero.
                if (MySetting.Left < 0 && Screen.AllScreens.Length < 2)
                    MySetting.Left = 0;

                TamApp = (MySetting.Left, MySetting.Top, MySetting.Width, MySetting.Height);
            }
            AsignarTamañoVentana(TamApp);

            MostrarNotas(notaUC1.Grupo, notaUC1.ComboNotas.SelectedIndex);

            //
            // Quitado de AsignarSettings y puesto en el evento Load (10/feb/21)
            //

            //if (MySetting.IniciarMinimizada)
            //    this.WindowState = FormWindowState.Minimized;

            //// Aunque esto se puede poner dentro del if anterior,   (10/Feb/21)
            //// dejarlo así, por separado.
            //if (this.WindowState == FormWindowState.Minimized)
            //{
            //    NotifyMenuRestaurar.Text = "Restaurar";
            //    // al minimizar, ocultar el formulario
            //    this.Hide();
            //}
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
            tabsConfig_SelectedIndexChanged(null, null);
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
            tabsConfig_SelectedIndexChanged(null, null);
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
            
            tabsConfig_SelectedIndexChanged(null, null);
        }

        private void tabsConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar todo el formulario cuando se pulsa en una ficha
            if (OcultarPanelExpanded)
                OcultarPanelSuperior(false);

            if (tabsConfig.SelectedTab.Name == "tabOpciones")
            {
                OpcCboColorGrupo_SelectedIndexChanged(null, null);
                OpcDeshacerCambios();
                return;
            }

            if (tabsConfig.SelectedTab.Name == "tabAcercaDe")
            {
                System.Reflection.Assembly ensamblado = typeof(VersionUtilidades).Assembly;

                var versionWeb = "xx";
                string msgVersion;

                var cualVersion = VersionUtilidades.CompararVersionWeb(ensamblado, ref versionWeb);

                if (cualVersion == 1)
                    msgVersion = $"Existe una versión más reciente de '{Application.ProductName}': v{versionWeb}.";
                else //if (cualVersion == -1)
                    msgVersion = $"Esta versión de '{Application.ProductName}' es la más reciente.";

                var titulo = $"Acerca de {Application.ProductName} v{Application.ProductVersion}";
                var msg = @$"Acerca de {titulo}

Utilidad para crear notas y grupos de notas.
Las notas se guardan en el fichero '{notaUC1.FicNotas}'.

Operaciones que puedes hacer:
    Añadir nuevos grupos y notas.
    Sustituir una nota con un nuevo texto.
    Eliminar una nota.
    Clasificar las notas del grupo seleccionado.
    Leer y guardar las notas en un fichero de texto.
    Buscar texto en las notas.

Al hacer doble-clic en una nota, se muestra en ventana independiente.

No se guardan los grupos y notas en blanco.

{msgVersion}";

                txtAcercaDe.Text = msg;
                return;
            }

            //if (tabOpciones.SelectedIndex != 2) return;
            if (tabsConfig.SelectedTab.Name != "tabEditarGrupos") return;
            
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
            tabsConfig_SelectedIndexChanged(null, null);
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

            // Asignar el valor del color del grupo a usar (los valores van de 0 a 4)
            OpcCboColorGrupo.SelectedIndex = MySetting.ColorGrupo;
            OpcChkAutoGuardar.Checked = MySetting.Autoguardar;
            OpcChkRecordarTam.Checked = MySetting.RecordarTam;
            OpcChkAjusteLineas.Checked = MySetting.AjusteLineas;
            OpChkNoGuardarEnBlanco.Checked = MySetting.NoGuardarEnBlanco;
            OpcChkIniciarMinimizada.Checked = MySetting.IniciarMinimizada;
            OpcChkMinimizarAlCerrar.Checked = MySetting.MinimizarAlCerrar;
            OpcChkMostrarMismoGrupo.Checked = MySetting.MostrarMismoGrupo;
            OpcChkMostrarHorizontal.Checked = MySetting.VistaNotasHorizontal;
            OpcChkOcultarPanelSuperior.Checked = MySetting.OcultarPanelSuperior;
            OpcChkIniciarConWindows.Checked = MySetting.IniciarConWindows;

            //OpcChkPermitirVariasInstancias.Checked = MySetting.PermitirVariasInstancias;

            //OpcChkGuardarEnDrive.Checked = MySetting.GuardarEnDrive;
            //OpcChkBorrarNotasAnterioresDrive.Checked = MySetting.BorrarNotasAnterioresDeDrive;

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
            else if (OpcChkOcultarPanelSuperior.Checked != MySetting.OcultarPanelSuperior)
                modificado = true;
            else if (OpcChkIniciarConWindows.Checked != MySetting.IniciarConWindows)
                modificado = true;
            else if (OpcCboColorGrupo.SelectedIndex != MySetting.ColorGrupo)
                modificado = true;
            //else if (OpcChkPermitirVariasInstancias.Checked != MySetting.PermitirVariasInstancias)
            //    modificado = true;

            //else if (OpcChkGuardarEnDrive.Checked != MySetting.GuardarEnDrive)
            //    modificado = true;
            //else if (OpcChkBorrarNotasAnterioresDrive.Checked != MySetting.BorrarNotasAnterioresDeDrive)
            //    modificado = true;

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
            //MySetting.PermitirVariasInstancias = OpcChkPermitirVariasInstancias.Checked;

            MySetting.ColorGrupo = OpcCboColorGrupo.SelectedIndex;
            ColorGrupo = MySetting.ColorGrupo;
            MySetting.Autoguardar = OpcChkAutoGuardar.Checked;
            MySetting.RecordarTam = OpcChkRecordarTam.Checked;
            MySetting.AjusteLineas = OpcChkAjusteLineas.Checked;
            MySetting.NoGuardarEnBlanco = OpChkNoGuardarEnBlanco.Checked;
            MySetting.IniciarMinimizada = OpcChkIniciarMinimizada.Checked;
            MySetting.MinimizarAlCerrar = OpcChkMinimizarAlCerrar.Checked;
            MySetting.MostrarMismoGrupo = OpcChkMostrarMismoGrupo.Checked;
            var vistaAnt = MySetting.VistaNotasHorizontal;
            MySetting.VistaNotasHorizontal = OpcChkMostrarHorizontal.Checked;
            MySetting.OcultarPanelSuperior = OpcChkOcultarPanelSuperior.Checked;
            MySetting.IniciarConWindows = OpcChkIniciarConWindows.Checked;
            //MySetting.GuardarEnDrive = OpcChkGuardarEnDrive.Checked;
            //MySetting.BorrarNotasAnterioresDeDrive = OpcChkBorrarNotasAnterioresDrive.Checked;

            OpcBtnDeshacer.Enabled = false;
            
            MySetting.Save();
            OpcConfigurando = false;

            AsignarColoresGrupo();
            AsignarColores();
            // Colorear también los grupos.
            MostrarGrupos(ElGrupo, ElGrupoIndex);

            AsignarSettings();

            if (vistaAnt != MySetting.VistaNotasHorizontal)
                AplicarVista();
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

        private void AplicarVista()
        {
            if (OpcChkMostrarHorizontal.Checked)
            {
                HorizontalSize.Width = NotasFlowLayoutPanel.ClientSize.Width - 12;
                NotasFlowLayoutPanel.WrapContents = false; // true;
            }
            else
                NotasFlowLayoutPanel.WrapContents = false;

            MostrarNotas(notaUC1.Grupo, notaUC1.ComboNotas.SelectedIndex);
        }

        private void OpcLinkSolicitarAutorización_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Esto da error 404. (19/oct/22 12.46)
            //System.Diagnostics.Process.Start("http://www.elguillemola.com/2020/12/te-gustaria-obtener-mas-prestaciones-de-gsnotasnet/#comments");
            System.Diagnostics.Process.Start("https://www.elguillemola.com/te-gustaria-obtener-mas-prestaciones-de-gsnotasnet/#comments");
        }

        /// <summary>
        /// Ocultar o mostrar el panel superior.
        /// </summary>
        /// <param name="ocultar">true para ocultarlo, false para mostrarlo.</param>
        private void OcultarPanelSuperior(bool ocultar)
        {
            OcultarPanelExpanded = ocultar;

            // El tamaño de las notas hacerlo fijo
            if (notaUC1.Height != 310)
                notaUC1.Height = 310;

            tabsConfig.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            notaUC1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;

            if (ocultar)
            {
                picOcultarPanel1.Image = Properties.Resources.ExpanderDown;
                tabsConfig.Height = 25;
            }
            else
            {
                picOcultarPanel1.Image = Properties.Resources.ExpanderUp;
                tabsConfig.Height = TabsConfigHeightNormal;
            }

            // Actualizar el tamaño del formulario
            this.Height = tabsConfig.Height + notaUC1.Height + picOcultarPanel1.Height + 35;
            tabsConfig.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            notaUC1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private bool OcultarPanelExpanded = false;
        private int TabsConfigHeightNormal;

        private void picOcultarPanel1_Click(object sender, EventArgs e)
        {
            if (iniciando) return;

            OcultarPanelSuperior(!OcultarPanelExpanded);
        }

        private void OpcBtnGuardarEnDrive_Click(object sender, EventArgs e)
        {
            notaUC1.GuardarEnDrive = true;
            notaUC1.BorrarNotasAnterioresDeDrive = false;
            notaUC1.GuardarNotas();
            
            notaUC1.GuardarEnDrive = false;
        }

        /// <summary>
        /// Indicar si se inicia con Windows.
        /// Modificando el registro de Windows.
        /// </summary>
        /// <remarks>Debes ejecutar la aplicación con permisos de administrador.</remarks>
        private bool IniciarConWindows
        {
            get
            {
                return MySetting.IniciarConWindows;
            }
            set
            {
                //// Avisar si no se ejecuta como administrador            (12/Ago/07)
                //if (DatosConfiguracion.ComoAdministrador == false)
                //{
                //    MessageBox.Show("Sólo puedes modificar el registro de Windows " + "si ejecutas la aplicación como administrador.", "Iniciar con Windows", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    break;
                //}
                
                MySetting.IniciarConWindows = value;
                
                // Guardar la clave en el registro
                // HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
                try
                {
                    Microsoft.Win32.RegistryKey runK = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                    if (value)
                    {
                        // El ensamblado actual
                        System.Reflection.Assembly ensamblado = typeof(FormNotasUC).Assembly;
                        // añadirlo al registro
                        var appPath = System.IO.Path.GetFullPath(ensamblado.Location);

                        runK.SetValue("gsNotasNETF", $"\"{appPath}\"");
                    }
                    else
                        // quitarlo del registo
                        runK.DeleteValue("gsNotasNETF", false);
                }
                catch (Exception ex)
                {
                    if (mostrarAvisoReg)
                        MessageBox.Show("ERROR al guardar en el registro.\r\n" +
                            "Seguramente no tienes privilegios suficientes.\r\n" +
                            ex.Message + "\r\n---xxx---\r\n" +
                            ex.StackTrace,
                            "Iniciar automáticamente con Windows",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        notaUC1.StatusInfo = "Error al guardar en el registro.";
                }
            }
        }

        private void notaUC1_BuscarTexto(string mensaje)
        {
            // Se ha elegido buscar en el menú contextual
            // en mensaje estará el texto seleccionado 
            txtBuscar.Text = mensaje;
            tabsConfig.SelectedTab = tabBuscarTexto;
            tabBuscarTexto.Show();
        }

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            var nuevoGrupo = txtEdNuevoNombreGrupo.Text;
            // Si ese nombre existe no se hace nada, si no existe, se crea vacío.
            if (!notaUC1.Notas.ContainsKey(nuevoGrupo))
                notaUC1.Notas.Add(nuevoGrupo, new List<string>());
            
            notaUC1.AsignarGrupos(grupo: nuevoGrupo);
            tabsConfig_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// Añade un nuevo color aleatorio a la colección.
        /// </summary>
        /// <param name="colores">Colección con los colores que hay para no repetir.</param>
        private void AñadirNuevoColor(List<Color> colores)
        {
            //var rnd = new Random();
            //var col = colores[0];

            //var n = rnd.Next(1, 4);
            //byte r = col.R, g = col.G, b = col.B;
            //if (n == 1)
            //    r = 0;
            //else if (n == 2)
            //    g = 0;
            //else if (n == 3)
            //    b = 0;
            Color col2;
            do
            {
                col2 = GetRandomColor();
            } while (colores.Contains(col2));

            colores.Add(col2);

            //return col2;
        }

        // Mostrar los colores de las etiquetas según el grupo seleccionado. (18/oct/22 21.30)
        private void OpcCboColorGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iniciando) return;

            flowLayoutPanel1.Controls.Clear();

            if (OpcCboColorGrupo.SelectedIndex < 0)
                OpcCboColorGrupo.SelectedIndex = 0;

            // Por si hay más grupos que los colores predeterminados.
            var colores = ElColorGrupo(OpcCboColorGrupo.SelectedIndex, notaUC1.Notas.Keys.Count);

            // Solo mostrar los colores con los grupos que hay actualmente
            //for (int i = 0; i < notaUC1.Notas.Keys.Count; i++)
            for (int i = 0; i < colores.Count; i++)
            {
                var col = colores[i];
                var lbl = new Label();
                lbl.Width = 30;
                lbl.Text = i.ToString();
                lbl.BackColor = col;
                SetBackColor(lbl, col);
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }

        private void AsignarAnchors()
        {
            lblResultadoBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lstResultadoBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            lblBuscando.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            OpcBtnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OpcBtnDeshacer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OpcLinkSolicitarAutorización.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OpcBtnGuardarEnDrive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right |AnchorStyles.Left;
            OpcBtnRestablecerTam.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnCambiarNombre.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEdNombreGrupo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEdCambiar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEdInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboEdGrupos.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            txtEdNuevoNombreGrupo.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;

            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            cboEdGrupoDestino.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMoverNota.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboEdNotas.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
        }
    }
}
