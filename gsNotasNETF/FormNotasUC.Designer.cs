
namespace gsNotasNETF
{
    partial class FormNotasUC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNotasUC));
            this.NotasFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.LblNota = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabOpciones = new System.Windows.Forms.TabControl();
            this.tabNotas = new System.Windows.Forms.TabPage();
            this.tabGrupos = new System.Windows.Forms.TabPage();
            this.GruposFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.LblGrupo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabEditarGrupos = new System.Windows.Forms.TabPage();
            this.panelEditarGrupos = new System.Windows.Forms.Panel();
            this.btnClasificarGrupos = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboEdGrupoDestino = new System.Windows.Forms.ComboBox();
            this.cboEdGrupoNotas = new System.Windows.Forms.ComboBox();
            this.btnMoverNota = new System.Windows.Forms.Button();
            this.cboEdNotas = new System.Windows.Forms.ComboBox();
            this.lblEdSeleccionarNota = new System.Windows.Forms.Label();
            this.lblEdInfo = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnCambiarNombre = new System.Windows.Forms.Button();
            this.txtEdNombreGrupo = new System.Windows.Forms.TextBox();
            this.lblEdCambiar = new System.Windows.Forms.Label();
            this.cboEdGrupos = new System.Windows.Forms.ComboBox();
            this.lblEdSeleccionar = new System.Windows.Forms.Label();
            this.tabBuscarTexto = new System.Windows.Forms.TabPage();
            this.panelBuscarTexto = new System.Windows.Forms.Panel();
            this.lblResultadoBuscar = new System.Windows.Forms.Label();
            this.lblBuscando = new System.Windows.Forms.Label();
            this.lstResultadoBuscar = new System.Windows.Forms.ListBox();
            this.chkBuscarEnGrupoActual = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panelOpciones = new System.Windows.Forms.Panel();
            this.OpcLinkSolicitarAutorización = new System.Windows.Forms.LinkLabel();
            this.OpcChkGuardarEnDrive = new System.Windows.Forms.CheckBox();
            this.OpcChkMostrarHorizontal = new System.Windows.Forms.CheckBox();
            this.OpcChkShowInTaskBar = new System.Windows.Forms.CheckBox();
            this.OpcChkMostrarMismoGrupo = new System.Windows.Forms.CheckBox();
            this.OpcChkIniciarMinimizada = new System.Windows.Forms.CheckBox();
            this.OpcBtnDeshacer = new System.Windows.Forms.Button();
            this.OpcBtnGuardar = new System.Windows.Forms.Button();
            this.OpcChkMinimizarAlCerrar = new System.Windows.Forms.CheckBox();
            this.OpcChkAjusteLineas = new System.Windows.Forms.CheckBox();
            this.OpcBtnRestablecerTam = new System.Windows.Forms.Button();
            this.OpcChkRecordarTam = new System.Windows.Forms.CheckBox();
            this.OpChkNoGuardarEnBlanco = new System.Windows.Forms.CheckBox();
            this.OpcChkAutoGuardar = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NotifyMenuRestaurar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NotifyMenuCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.notaUC1 = new gsNotasNETF.NotaUC();
            this.OpcChkBorrarNotasAnterioresDrive = new System.Windows.Forms.CheckBox();
            this.NotasFlowLayoutPanel.SuspendLayout();
            this.tabOpciones.SuspendLayout();
            this.tabNotas.SuspendLayout();
            this.tabGrupos.SuspendLayout();
            this.GruposFlowLayoutPanel.SuspendLayout();
            this.tabEditarGrupos.SuspendLayout();
            this.panelEditarGrupos.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabBuscarTexto.SuspendLayout();
            this.panelBuscarTexto.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panelOpciones.SuspendLayout();
            this.contextNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotasFlowLayoutPanel
            // 
            this.NotasFlowLayoutPanel.AutoScroll = true;
            this.NotasFlowLayoutPanel.Controls.Add(this.LblNota);
            this.NotasFlowLayoutPanel.Controls.Add(this.label4);
            this.NotasFlowLayoutPanel.Controls.Add(this.label1);
            this.NotasFlowLayoutPanel.Controls.Add(this.label2);
            this.NotasFlowLayoutPanel.Controls.Add(this.label3);
            this.NotasFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotasFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.NotasFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.NotasFlowLayoutPanel.Name = "NotasFlowLayoutPanel";
            this.NotasFlowLayoutPanel.Size = new System.Drawing.Size(782, 247);
            this.NotasFlowLayoutPanel.TabIndex = 0;
            this.NotasFlowLayoutPanel.WrapContents = false;
            this.NotasFlowLayoutPanel.Resize += new System.EventHandler(this.NotasFlowLayoutPanel_Resize);
            // 
            // LblNota
            // 
            this.LblNota.BackColor = System.Drawing.Color.LightPink;
            this.LblNota.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblNota.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNota.Location = new System.Drawing.Point(3, 3);
            this.LblNota.Margin = new System.Windows.Forms.Padding(3);
            this.LblNota.Name = "LblNota";
            this.LblNota.Size = new System.Drawing.Size(752, 87);
            this.LblNota.TabIndex = 0;
            this.LblNota.Text = "LblNota\r\nPulsando en una etiqueta la pondrás la primera y con mayor tamaño.\r\nEl r" +
    "esto de etiquetas se pondrán en un tamaño más pequeño.";
            this.LblNota.DoubleClick += new System.EventHandler(this.LblNota_DoubleClick);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 80);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            this.label4.Click += new System.EventHandler(this.LblNota_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 182);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 87);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1\r\nPrueba con estas etiquetas para moverlas.";
            this.label1.Click += new System.EventHandler(this.LblNota_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PaleGreen;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 275);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 80);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.LblNota_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Cornsilk;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 361);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 80);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            this.label3.Click += new System.EventHandler(this.LblNota_Click);
            // 
            // tabOpciones
            // 
            this.tabOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabOpciones.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabOpciones.Controls.Add(this.tabNotas);
            this.tabOpciones.Controls.Add(this.tabGrupos);
            this.tabOpciones.Controls.Add(this.tabEditarGrupos);
            this.tabOpciones.Controls.Add(this.tabBuscarTexto);
            this.tabOpciones.Controls.Add(this.tabPage5);
            this.tabOpciones.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOpciones.Location = new System.Drawing.Point(5, 10);
            this.tabOpciones.Margin = new System.Windows.Forms.Padding(1);
            this.tabOpciones.Multiline = true;
            this.tabOpciones.Name = "tabOpciones";
            this.tabOpciones.SelectedIndex = 0;
            this.tabOpciones.Size = new System.Drawing.Size(796, 286);
            this.tabOpciones.TabIndex = 0;
            this.tabOpciones.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabNotas
            // 
            this.tabNotas.BackColor = System.Drawing.Color.White;
            this.tabNotas.Controls.Add(this.NotasFlowLayoutPanel);
            this.tabNotas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.tabNotas.Location = new System.Drawing.Point(4, 29);
            this.tabNotas.Name = "tabNotas";
            this.tabNotas.Padding = new System.Windows.Forms.Padding(3);
            this.tabNotas.Size = new System.Drawing.Size(788, 253);
            this.tabNotas.TabIndex = 0;
            this.tabNotas.Text = "Notas";
            // 
            // tabGrupos
            // 
            this.tabGrupos.BackColor = System.Drawing.Color.White;
            this.tabGrupos.Controls.Add(this.GruposFlowLayoutPanel);
            this.tabGrupos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.tabGrupos.Location = new System.Drawing.Point(4, 29);
            this.tabGrupos.Name = "tabGrupos";
            this.tabGrupos.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrupos.Size = new System.Drawing.Size(788, 253);
            this.tabGrupos.TabIndex = 1;
            this.tabGrupos.Text = "Grupos";
            // 
            // GruposFlowLayoutPanel
            // 
            this.GruposFlowLayoutPanel.AutoScroll = true;
            this.GruposFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GruposFlowLayoutPanel.Controls.Add(this.LblGrupo);
            this.GruposFlowLayoutPanel.Controls.Add(this.label6);
            this.GruposFlowLayoutPanel.Controls.Add(this.label7);
            this.GruposFlowLayoutPanel.Controls.Add(this.label9);
            this.GruposFlowLayoutPanel.Controls.Add(this.label8);
            this.GruposFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GruposFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.GruposFlowLayoutPanel.Name = "GruposFlowLayoutPanel";
            this.GruposFlowLayoutPanel.Size = new System.Drawing.Size(782, 247);
            this.GruposFlowLayoutPanel.TabIndex = 1;
            this.GruposFlowLayoutPanel.Click += new System.EventHandler(this.LblGrupo_Click);
            this.GruposFlowLayoutPanel.DoubleClick += new System.EventHandler(this.LblGrupo_DoubleClick);
            // 
            // LblGrupo
            // 
            this.LblGrupo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.LblGrupo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblGrupo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGrupo.Location = new System.Drawing.Point(3, 3);
            this.LblGrupo.Margin = new System.Windows.Forms.Padding(3);
            this.LblGrupo.Name = "LblGrupo";
            this.LblGrupo.Size = new System.Drawing.Size(180, 80);
            this.LblGrupo.TabIndex = 0;
            this.LblGrupo.Text = "LblGrupo\r\nPulsando en una etiqueta la pondrás la primera y con mayor tamaño.\r\nEl " +
    "resto de etiquetas se pondrán en un tamaño más pequeño.";
            this.LblGrupo.Click += new System.EventHandler(this.LblGrupo_Click);
            this.LblGrupo.DoubleClick += new System.EventHandler(this.LblGrupo_DoubleClick);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(189, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 80);
            this.label6.TabIndex = 4;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SkyBlue;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(375, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 80);
            this.label7.TabIndex = 1;
            this.label7.Text = "label1\r\nPrueba con estas etiquetas para moverlas.";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Cornsilk;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(561, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 80);
            this.label9.TabIndex = 3;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.PaleGreen;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 89);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 80);
            this.label8.TabIndex = 2;
            this.label8.Text = "label8";
            // 
            // tabEditarGrupos
            // 
            this.tabEditarGrupos.BackColor = System.Drawing.Color.White;
            this.tabEditarGrupos.Controls.Add(this.panelEditarGrupos);
            this.tabEditarGrupos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.tabEditarGrupos.Location = new System.Drawing.Point(4, 29);
            this.tabEditarGrupos.Name = "tabEditarGrupos";
            this.tabEditarGrupos.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditarGrupos.Size = new System.Drawing.Size(788, 253);
            this.tabEditarGrupos.TabIndex = 2;
            this.tabEditarGrupos.Text = "Editar grupos y notas";
            // 
            // panelEditarGrupos
            // 
            this.panelEditarGrupos.AutoScroll = true;
            this.panelEditarGrupos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelEditarGrupos.Controls.Add(this.btnClasificarGrupos);
            this.panelEditarGrupos.Controls.Add(this.groupBox2);
            this.panelEditarGrupos.Controls.Add(this.lblEdInfo);
            this.panelEditarGrupos.Controls.Add(this.btnBorrar);
            this.panelEditarGrupos.Controls.Add(this.btnCambiarNombre);
            this.panelEditarGrupos.Controls.Add(this.txtEdNombreGrupo);
            this.panelEditarGrupos.Controls.Add(this.lblEdCambiar);
            this.panelEditarGrupos.Controls.Add(this.cboEdGrupos);
            this.panelEditarGrupos.Controls.Add(this.lblEdSeleccionar);
            this.panelEditarGrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEditarGrupos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panelEditarGrupos.Location = new System.Drawing.Point(3, 3);
            this.panelEditarGrupos.Name = "panelEditarGrupos";
            this.panelEditarGrupos.Padding = new System.Windows.Forms.Padding(3);
            this.panelEditarGrupos.Size = new System.Drawing.Size(782, 247);
            this.panelEditarGrupos.TabIndex = 0;
            this.panelEditarGrupos.Text = "Editar los grupos";
            // 
            // btnClasificarGrupos
            // 
            this.btnClasificarGrupos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btnClasificarGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClasificarGrupos.ForeColor = System.Drawing.Color.White;
            this.btnClasificarGrupos.Location = new System.Drawing.Point(153, 52);
            this.btnClasificarGrupos.Name = "btnClasificarGrupos";
            this.btnClasificarGrupos.Size = new System.Drawing.Size(191, 29);
            this.btnClasificarGrupos.TabIndex = 7;
            this.btnClasificarGrupos.Text = "Clasificar los grupos";
            this.btnClasificarGrupos.UseVisualStyleBackColor = false;
            this.btnClasificarGrupos.Click += new System.EventHandler(this.btnClasificarGrupos_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboEdGrupoDestino);
            this.groupBox2.Controls.Add(this.cboEdGrupoNotas);
            this.groupBox2.Controls.Add(this.btnMoverNota);
            this.groupBox2.Controls.Add(this.cboEdNotas);
            this.groupBox2.Controls.Add(this.lblEdSeleccionarNota);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.groupBox2.Location = new System.Drawing.Point(6, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(757, 71);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editar las notas";
            // 
            // cboEdGrupoDestino
            // 
            this.cboEdGrupoDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEdGrupoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEdGrupoDestino.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboEdGrupoDestino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.cboEdGrupoDestino.FormattingEnabled = true;
            this.cboEdGrupoDestino.Location = new System.Drawing.Point(630, 21);
            this.cboEdGrupoDestino.Name = "cboEdGrupoDestino";
            this.cboEdGrupoDestino.Size = new System.Drawing.Size(121, 25);
            this.cboEdGrupoDestino.TabIndex = 4;
            // 
            // cboEdGrupoNotas
            // 
            this.cboEdGrupoNotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEdGrupoNotas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboEdGrupoNotas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.cboEdGrupoNotas.FormattingEnabled = true;
            this.cboEdGrupoNotas.Location = new System.Drawing.Point(202, 21);
            this.cboEdGrupoNotas.Name = "cboEdGrupoNotas";
            this.cboEdGrupoNotas.Size = new System.Drawing.Size(121, 25);
            this.cboEdGrupoNotas.TabIndex = 1;
            this.cboEdGrupoNotas.SelectedIndexChanged += new System.EventHandler(this.cboEdGrupoNotas_SelectedIndexChanged);
            // 
            // btnMoverNota
            // 
            this.btnMoverNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoverNota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btnMoverNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoverNota.ForeColor = System.Drawing.Color.White;
            this.btnMoverNota.Location = new System.Drawing.Point(540, 17);
            this.btnMoverNota.Name = "btnMoverNota";
            this.btnMoverNota.Size = new System.Drawing.Size(84, 29);
            this.btnMoverNota.TabIndex = 3;
            this.btnMoverNota.Text = "Mover a";
            this.btnMoverNota.UseVisualStyleBackColor = false;
            this.btnMoverNota.Click += new System.EventHandler(this.btnMoverNota_Click);
            // 
            // cboEdNotas
            // 
            this.cboEdNotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEdNotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEdNotas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboEdNotas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.cboEdNotas.FormattingEnabled = true;
            this.cboEdNotas.Location = new System.Drawing.Point(329, 21);
            this.cboEdNotas.Name = "cboEdNotas";
            this.cboEdNotas.Size = new System.Drawing.Size(205, 25);
            this.cboEdNotas.TabIndex = 2;
            // 
            // lblEdSeleccionarNota
            // 
            this.lblEdSeleccionarNota.Location = new System.Drawing.Point(6, 24);
            this.lblEdSeleccionarNota.Margin = new System.Windows.Forms.Padding(3);
            this.lblEdSeleccionarNota.Name = "lblEdSeleccionarNota";
            this.lblEdSeleccionarNota.Size = new System.Drawing.Size(190, 23);
            this.lblEdSeleccionarNota.TabIndex = 0;
            this.lblEdSeleccionarNota.Text = "Selecciona la nota a mover:";
            // 
            // lblEdInfo
            // 
            this.lblEdInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEdInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.lblEdInfo.ForeColor = System.Drawing.Color.White;
            this.lblEdInfo.Location = new System.Drawing.Point(440, 61);
            this.lblEdInfo.Margin = new System.Windows.Forms.Padding(3);
            this.lblEdInfo.Name = "lblEdInfo";
            this.lblEdInfo.Size = new System.Drawing.Size(326, 81);
            this.lblEdInfo.TabIndex = 6;
            this.lblEdInfo.Text = "Si indicas un nombre existente, las notas se moverán a ese grupo.\r\nEn los nombres" +
    " de los grupos se distinguen mayúsculas de minúsculas.";
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.ForeColor = System.Drawing.Color.White;
            this.btnBorrar.Location = new System.Drawing.Point(350, 18);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(84, 29);
            this.btnBorrar.TabIndex = 2;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnCambiarNombre
            // 
            this.btnCambiarNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCambiarNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btnCambiarNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarNombre.ForeColor = System.Drawing.Color.White;
            this.btnCambiarNombre.Location = new System.Drawing.Point(682, 21);
            this.btnCambiarNombre.Name = "btnCambiarNombre";
            this.btnCambiarNombre.Size = new System.Drawing.Size(84, 29);
            this.btnCambiarNombre.TabIndex = 5;
            this.btnCambiarNombre.Text = "Cambiar";
            this.btnCambiarNombre.UseVisualStyleBackColor = false;
            this.btnCambiarNombre.Click += new System.EventHandler(this.btnCambiarNombre_Click);
            // 
            // txtEdNombreGrupo
            // 
            this.txtEdNombreGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEdNombreGrupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.txtEdNombreGrupo.Location = new System.Drawing.Point(576, 24);
            this.txtEdNombreGrupo.Name = "txtEdNombreGrupo";
            this.txtEdNombreGrupo.Size = new System.Drawing.Size(100, 25);
            this.txtEdNombreGrupo.TabIndex = 4;
            // 
            // lblEdCambiar
            // 
            this.lblEdCambiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEdCambiar.Location = new System.Drawing.Point(443, 27);
            this.lblEdCambiar.Margin = new System.Windows.Forms.Padding(3);
            this.lblEdCambiar.Name = "lblEdCambiar";
            this.lblEdCambiar.Size = new System.Drawing.Size(127, 23);
            this.lblEdCambiar.TabIndex = 3;
            this.lblEdCambiar.Text = "Nuevo nombre:";
            // 
            // cboEdGrupos
            // 
            this.cboEdGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEdGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboEdGrupos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.cboEdGrupos.FormattingEnabled = true;
            this.cboEdGrupos.Location = new System.Drawing.Point(153, 21);
            this.cboEdGrupos.Name = "cboEdGrupos";
            this.cboEdGrupos.Size = new System.Drawing.Size(191, 25);
            this.cboEdGrupos.TabIndex = 1;
            // 
            // lblEdSeleccionar
            // 
            this.lblEdSeleccionar.Location = new System.Drawing.Point(6, 24);
            this.lblEdSeleccionar.Margin = new System.Windows.Forms.Padding(3);
            this.lblEdSeleccionar.Name = "lblEdSeleccionar";
            this.lblEdSeleccionar.Size = new System.Drawing.Size(141, 23);
            this.lblEdSeleccionar.TabIndex = 0;
            this.lblEdSeleccionar.Text = "Selecciona el grupo:";
            // 
            // tabBuscarTexto
            // 
            this.tabBuscarTexto.BackColor = System.Drawing.Color.White;
            this.tabBuscarTexto.Controls.Add(this.panelBuscarTexto);
            this.tabBuscarTexto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.tabBuscarTexto.Location = new System.Drawing.Point(4, 29);
            this.tabBuscarTexto.Name = "tabBuscarTexto";
            this.tabBuscarTexto.Padding = new System.Windows.Forms.Padding(3);
            this.tabBuscarTexto.Size = new System.Drawing.Size(788, 253);
            this.tabBuscarTexto.TabIndex = 3;
            this.tabBuscarTexto.Text = "Buscar texto";
            // 
            // panelBuscarTexto
            // 
            this.panelBuscarTexto.AutoScroll = true;
            this.panelBuscarTexto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelBuscarTexto.Controls.Add(this.lblResultadoBuscar);
            this.panelBuscarTexto.Controls.Add(this.lblBuscando);
            this.panelBuscarTexto.Controls.Add(this.lstResultadoBuscar);
            this.panelBuscarTexto.Controls.Add(this.chkBuscarEnGrupoActual);
            this.panelBuscarTexto.Controls.Add(this.btnBuscar);
            this.panelBuscarTexto.Controls.Add(this.txtBuscar);
            this.panelBuscarTexto.Controls.Add(this.lblBuscar);
            this.panelBuscarTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBuscarTexto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panelBuscarTexto.Location = new System.Drawing.Point(3, 3);
            this.panelBuscarTexto.Name = "panelBuscarTexto";
            this.panelBuscarTexto.Padding = new System.Windows.Forms.Padding(3);
            this.panelBuscarTexto.Size = new System.Drawing.Size(782, 247);
            this.panelBuscarTexto.TabIndex = 0;
            // 
            // lblResultadoBuscar
            // 
            this.lblResultadoBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResultadoBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.lblResultadoBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoBuscar.ForeColor = System.Drawing.Color.White;
            this.lblResultadoBuscar.Location = new System.Drawing.Point(489, 21);
            this.lblResultadoBuscar.Margin = new System.Windows.Forms.Padding(3);
            this.lblResultadoBuscar.Name = "lblResultadoBuscar";
            this.lblResultadoBuscar.Size = new System.Drawing.Size(284, 23);
            this.lblResultadoBuscar.TabIndex = 5;
            this.lblResultadoBuscar.Text = "Resultado de la búsqueda:";
            // 
            // lblBuscando
            // 
            this.lblBuscando.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuscando.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.lblBuscando.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscando.ForeColor = System.Drawing.Color.White;
            this.lblBuscando.Location = new System.Drawing.Point(9, 215);
            this.lblBuscando.Margin = new System.Windows.Forms.Padding(3);
            this.lblBuscando.Name = "lblBuscando";
            this.lblBuscando.Size = new System.Drawing.Size(474, 23);
            this.lblBuscando.TabIndex = 4;
            this.lblBuscando.Text = "Buscando...";
            // 
            // lstResultadoBuscar
            // 
            this.lstResultadoBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResultadoBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.lstResultadoBuscar.FormattingEnabled = true;
            this.lstResultadoBuscar.ItemHeight = 17;
            this.lstResultadoBuscar.Location = new System.Drawing.Point(489, 51);
            this.lstResultadoBuscar.Name = "lstResultadoBuscar";
            this.lstResultadoBuscar.Size = new System.Drawing.Size(284, 157);
            this.lstResultadoBuscar.Sorted = true;
            this.lstResultadoBuscar.TabIndex = 6;
            this.lstResultadoBuscar.DoubleClick += new System.EventHandler(this.lstResultadoBuscar_DoubleClick);
            // 
            // chkBuscarEnGrupoActual
            // 
            this.chkBuscarEnGrupoActual.AutoSize = true;
            this.chkBuscarEnGrupoActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.chkBuscarEnGrupoActual.Location = new System.Drawing.Point(78, 55);
            this.chkBuscarEnGrupoActual.Name = "chkBuscarEnGrupoActual";
            this.chkBuscarEnGrupoActual.Size = new System.Drawing.Size(268, 21);
            this.chkBuscarEnGrupoActual.TabIndex = 3;
            this.chkBuscarEnGrupoActual.Text = "Buscar solo en las notas del grupo actual";
            this.chkBuscarEnGrupoActual.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(231, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(84, 29);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.txtBuscar.Location = new System.Drawing.Point(75, 21);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(150, 25);
            this.txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.lblBuscar.Location = new System.Drawing.Point(6, 24);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(3);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(63, 23);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.White;
            this.tabPage5.Controls.Add(this.panelOpciones);
            this.tabPage5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(788, 253);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Opciones";
            // 
            // panelOpciones
            // 
            this.panelOpciones.AutoScroll = true;
            this.panelOpciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelOpciones.Controls.Add(this.OpcChkBorrarNotasAnterioresDrive);
            this.panelOpciones.Controls.Add(this.OpcLinkSolicitarAutorización);
            this.panelOpciones.Controls.Add(this.OpcChkGuardarEnDrive);
            this.panelOpciones.Controls.Add(this.OpcChkMostrarHorizontal);
            this.panelOpciones.Controls.Add(this.OpcChkShowInTaskBar);
            this.panelOpciones.Controls.Add(this.OpcChkMostrarMismoGrupo);
            this.panelOpciones.Controls.Add(this.OpcChkIniciarMinimizada);
            this.panelOpciones.Controls.Add(this.OpcBtnDeshacer);
            this.panelOpciones.Controls.Add(this.OpcBtnGuardar);
            this.panelOpciones.Controls.Add(this.OpcChkMinimizarAlCerrar);
            this.panelOpciones.Controls.Add(this.OpcChkAjusteLineas);
            this.panelOpciones.Controls.Add(this.OpcBtnRestablecerTam);
            this.panelOpciones.Controls.Add(this.OpcChkRecordarTam);
            this.panelOpciones.Controls.Add(this.OpChkNoGuardarEnBlanco);
            this.panelOpciones.Controls.Add(this.OpcChkAutoGuardar);
            this.panelOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOpciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panelOpciones.Location = new System.Drawing.Point(3, 3);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Padding = new System.Windows.Forms.Padding(3);
            this.panelOpciones.Size = new System.Drawing.Size(782, 247);
            this.panelOpciones.TabIndex = 0;
            // 
            // OpcLinkSolicitarAutorización
            // 
            this.OpcLinkSolicitarAutorización.AutoSize = true;
            this.OpcLinkSolicitarAutorización.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.OpcLinkSolicitarAutorización.Location = new System.Drawing.Point(293, 250);
            this.OpcLinkSolicitarAutorización.Name = "OpcLinkSolicitarAutorización";
            this.OpcLinkSolicitarAutorización.Size = new System.Drawing.Size(129, 17);
            this.OpcLinkSolicitarAutorización.TabIndex = 11;
            this.OpcLinkSolicitarAutorización.TabStop = true;
            this.OpcLinkSolicitarAutorización.Text = "Solicitar autorización";
            this.OpcLinkSolicitarAutorización.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.OpcLinkSolicitarAutorización, "Pide al Guille que te incluya en las cuentas autorizadas");
            this.OpcLinkSolicitarAutorización.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(177)))));
            this.OpcLinkSolicitarAutorización.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpcLinkSolicitarAutorización_LinkClicked);
            // 
            // OpcChkGuardarEnDrive
            // 
            this.OpcChkGuardarEnDrive.AutoSize = true;
            this.OpcChkGuardarEnDrive.Location = new System.Drawing.Point(6, 249);
            this.OpcChkGuardarEnDrive.Name = "OpcChkGuardarEnDrive";
            this.OpcChkGuardarEnDrive.Size = new System.Drawing.Size(281, 21);
            this.OpcChkGuardarEnDrive.TabIndex = 10;
            this.OpcChkGuardarEnDrive.Text = "Guardar las notas también en Google Drive";
            this.toolTip1.SetToolTip(this.OpcChkGuardarEnDrive, "Si quieres que las notas se guarden en el fichero de notas y en Google Drive \r\n(p" +
        "ara guardar en Google Drive debes tener tu correo de Gmail autorizado)");
            this.OpcChkGuardarEnDrive.UseVisualStyleBackColor = true;
            this.OpcChkGuardarEnDrive.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // OpcChkMostrarHorizontal
            // 
            this.OpcChkMostrarHorizontal.AutoSize = true;
            this.OpcChkMostrarHorizontal.Location = new System.Drawing.Point(6, 168);
            this.OpcChkMostrarHorizontal.Name = "OpcChkMostrarHorizontal";
            this.OpcChkMostrarHorizontal.Size = new System.Drawing.Size(228, 21);
            this.OpcChkMostrarHorizontal.TabIndex = 7;
            this.OpcChkMostrarHorizontal.Text = "Mostrar las notas horizontalmente";
            this.OpcChkMostrarHorizontal.UseVisualStyleBackColor = true;
            this.OpcChkMostrarHorizontal.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // OpcChkShowInTaskBar
            // 
            this.OpcChkShowInTaskBar.AutoSize = true;
            this.OpcChkShowInTaskBar.Checked = true;
            this.OpcChkShowInTaskBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OpcChkShowInTaskBar.Location = new System.Drawing.Point(6, 195);
            this.OpcChkShowInTaskBar.Name = "OpcChkShowInTaskBar";
            this.OpcChkShowInTaskBar.Size = new System.Drawing.Size(353, 21);
            this.OpcChkShowInTaskBar.TabIndex = 8;
            this.OpcChkShowInTaskBar.Text = "Mostrar la aplicación en la barra de tareas de Windows";
            this.OpcChkShowInTaskBar.UseVisualStyleBackColor = true;
            this.OpcChkShowInTaskBar.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // OpcChkMostrarMismoGrupo
            // 
            this.OpcChkMostrarMismoGrupo.AutoSize = true;
            this.OpcChkMostrarMismoGrupo.Location = new System.Drawing.Point(6, 114);
            this.OpcChkMostrarMismoGrupo.Name = "OpcChkMostrarMismoGrupo";
            this.OpcChkMostrarMismoGrupo.Size = new System.Drawing.Size(361, 21);
            this.OpcChkMostrarMismoGrupo.TabIndex = 5;
            this.OpcChkMostrarMismoGrupo.Text = "Al iniciar la aplicación mostrar el mismo grupo que había";
            this.OpcChkMostrarMismoGrupo.UseVisualStyleBackColor = true;
            this.OpcChkMostrarMismoGrupo.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // OpcChkIniciarMinimizada
            // 
            this.OpcChkIniciarMinimizada.AutoSize = true;
            this.OpcChkIniciarMinimizada.Location = new System.Drawing.Point(6, 87);
            this.OpcChkIniciarMinimizada.Name = "OpcChkIniciarMinimizada";
            this.OpcChkIniciarMinimizada.Size = new System.Drawing.Size(267, 21);
            this.OpcChkIniciarMinimizada.TabIndex = 4;
            this.OpcChkIniciarMinimizada.Text = "Al inicar la aplicación hacerlo minimizado";
            this.OpcChkIniciarMinimizada.UseVisualStyleBackColor = true;
            this.OpcChkIniciarMinimizada.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // OpcBtnDeshacer
            // 
            this.OpcBtnDeshacer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpcBtnDeshacer.AutoSize = true;
            this.OpcBtnDeshacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.OpcBtnDeshacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpcBtnDeshacer.ForeColor = System.Drawing.Color.White;
            this.OpcBtnDeshacer.Location = new System.Drawing.Point(577, 6);
            this.OpcBtnDeshacer.Name = "OpcBtnDeshacer";
            this.OpcBtnDeshacer.Size = new System.Drawing.Size(88, 29);
            this.OpcBtnDeshacer.TabIndex = 14;
            this.OpcBtnDeshacer.Text = "Deshacer";
            this.toolTip1.SetToolTip(this.OpcBtnDeshacer, "Deshacer los cambios actuales");
            this.OpcBtnDeshacer.UseVisualStyleBackColor = false;
            this.OpcBtnDeshacer.Click += new System.EventHandler(this.OpcBtnDeshacer_Click);
            // 
            // OpcBtnGuardar
            // 
            this.OpcBtnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpcBtnGuardar.AutoSize = true;
            this.OpcBtnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.OpcBtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpcBtnGuardar.ForeColor = System.Drawing.Color.White;
            this.OpcBtnGuardar.Location = new System.Drawing.Point(671, 6);
            this.OpcBtnGuardar.Name = "OpcBtnGuardar";
            this.OpcBtnGuardar.Size = new System.Drawing.Size(88, 29);
            this.OpcBtnGuardar.TabIndex = 13;
            this.OpcBtnGuardar.Text = "Guardar";
            this.OpcBtnGuardar.UseVisualStyleBackColor = false;
            this.OpcBtnGuardar.Click += new System.EventHandler(this.OpcBtnGuardar_Click);
            // 
            // OpcChkMinimizarAlCerrar
            // 
            this.OpcChkMinimizarAlCerrar.AutoSize = true;
            this.OpcChkMinimizarAlCerrar.Location = new System.Drawing.Point(6, 222);
            this.OpcChkMinimizarAlCerrar.Name = "OpcChkMinimizarAlCerrar";
            this.OpcChkMinimizarAlCerrar.Size = new System.Drawing.Size(400, 21);
            this.OpcChkMinimizarAlCerrar.TabIndex = 9;
            this.OpcChkMinimizarAlCerrar.Text = "Al cerrar (desde X de la ventana) minimizar en el área de tareas";
            this.OpcChkMinimizarAlCerrar.UseVisualStyleBackColor = true;
            this.OpcChkMinimizarAlCerrar.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // OpcChkAjusteLineas
            // 
            this.OpcChkAjusteLineas.AutoSize = true;
            this.OpcChkAjusteLineas.Location = new System.Drawing.Point(6, 141);
            this.OpcChkAjusteLineas.Name = "OpcChkAjusteLineas";
            this.OpcChkAjusteLineas.Size = new System.Drawing.Size(194, 21);
            this.OpcChkAjusteLineas.TabIndex = 6;
            this.OpcChkAjusteLineas.Text = "Ajuste de líneas (WordWrap)";
            this.OpcChkAjusteLineas.UseVisualStyleBackColor = true;
            this.OpcChkAjusteLineas.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // OpcBtnRestablecerTam
            // 
            this.OpcBtnRestablecerTam.AutoSize = true;
            this.OpcBtnRestablecerTam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.OpcBtnRestablecerTam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpcBtnRestablecerTam.ForeColor = System.Drawing.Color.White;
            this.OpcBtnRestablecerTam.Location = new System.Drawing.Point(412, 55);
            this.OpcBtnRestablecerTam.Name = "OpcBtnRestablecerTam";
            this.OpcBtnRestablecerTam.Size = new System.Drawing.Size(199, 29);
            this.OpcBtnRestablecerTam.TabIndex = 3;
            this.OpcBtnRestablecerTam.Text = "Restablecer tamaño y posición";
            this.toolTip1.SetToolTip(this.OpcBtnRestablecerTam, "Restablece (ahora) el tamaño y posición de la ventana");
            this.OpcBtnRestablecerTam.UseVisualStyleBackColor = false;
            this.OpcBtnRestablecerTam.Click += new System.EventHandler(this.OpcBtnRestablecerTam_Click);
            // 
            // OpcChkRecordarTam
            // 
            this.OpcChkRecordarTam.AutoSize = true;
            this.OpcChkRecordarTam.Location = new System.Drawing.Point(6, 60);
            this.OpcChkRecordarTam.Name = "OpcChkRecordarTam";
            this.OpcChkRecordarTam.Size = new System.Drawing.Size(400, 21);
            this.OpcChkRecordarTam.TabIndex = 2;
            this.OpcChkRecordarTam.Text = "Al iniciar la aplicación recordar posición y tamaño de la ventana";
            this.OpcChkRecordarTam.UseVisualStyleBackColor = true;
            this.OpcChkRecordarTam.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // OpChkNoGuardarEnBlanco
            // 
            this.OpChkNoGuardarEnBlanco.AutoSize = true;
            this.OpChkNoGuardarEnBlanco.Checked = true;
            this.OpChkNoGuardarEnBlanco.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OpChkNoGuardarEnBlanco.Location = new System.Drawing.Point(6, 33);
            this.OpChkNoGuardarEnBlanco.Name = "OpChkNoGuardarEnBlanco";
            this.OpChkNoGuardarEnBlanco.Size = new System.Drawing.Size(193, 21);
            this.OpChkNoGuardarEnBlanco.TabIndex = 1;
            this.OpChkNoGuardarEnBlanco.Text = "No guardar notas en blanco";
            this.toolTip1.SetToolTip(this.OpChkNoGuardarEnBlanco, "Aunque en NotaUC se hace esta comprobación,\r\nesta opción no está habilitada para " +
        "comprobar siempre \r\nque la nota  a añadir no esté en blanco.");
            this.OpChkNoGuardarEnBlanco.UseVisualStyleBackColor = true;
            this.OpChkNoGuardarEnBlanco.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // OpcChkAutoGuardar
            // 
            this.OpcChkAutoGuardar.AutoSize = true;
            this.OpcChkAutoGuardar.Location = new System.Drawing.Point(6, 6);
            this.OpcChkAutoGuardar.Name = "OpcChkAutoGuardar";
            this.OpcChkAutoGuardar.Size = new System.Drawing.Size(510, 21);
            this.OpcChkAutoGuardar.TabIndex = 0;
            this.OpcChkAutoGuardar.Text = "Auto guardar las notas (se actualiza automáticamente al cambiar de nota o grupo)";
            this.toolTip1.SetToolTip(this.OpcChkAutoGuardar, "Por ahora se crea una nueva nota en el grupo actual \r\n(cuando se cambia de grupo)" +
        " si el texto está modificado.");
            this.OpcChkAutoGuardar.UseVisualStyleBackColor = true;
            this.OpcChkAutoGuardar.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextNotify;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.MnuNotifyRestaurar_Click);
            // 
            // contextNotify
            // 
            this.contextNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotifyMenuRestaurar,
            this.toolStripSeparator1,
            this.NotifyMenuCerrar});
            this.contextNotify.Name = "contextNotify";
            this.contextNotify.Size = new System.Drawing.Size(124, 54);
            // 
            // NotifyMenuRestaurar
            // 
            this.NotifyMenuRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("NotifyMenuRestaurar.Image")));
            this.NotifyMenuRestaurar.Name = "NotifyMenuRestaurar";
            this.NotifyMenuRestaurar.Size = new System.Drawing.Size(123, 22);
            this.NotifyMenuRestaurar.Text = "Restaurar";
            this.NotifyMenuRestaurar.Click += new System.EventHandler(this.MnuNotifyRestaurar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // NotifyMenuCerrar
            // 
            this.NotifyMenuCerrar.Image = ((System.Drawing.Image)(resources.GetObject("NotifyMenuCerrar.Image")));
            this.NotifyMenuCerrar.Name = "NotifyMenuCerrar";
            this.NotifyMenuCerrar.Size = new System.Drawing.Size(123, 22);
            this.NotifyMenuCerrar.Text = "Cerrar";
            this.NotifyMenuCerrar.Click += new System.EventHandler(this.MnuNotifyCerrar_Click);
            // 
            // notaUC1
            // 
            this.notaUC1.AllowDrop = true;
            this.notaUC1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notaUC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notaUC1.ColoresClaro = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))))};
            this.notaUC1.ColoresOscuro = new System.Drawing.Color[] {
        System.Drawing.Color.DimGray,
        System.Drawing.Color.Gold};
            this.notaUC1.EditorRtf = resources.GetString("notaUC1.EditorRtf");
            this.notaUC1.EditorText = "Prueba NotaUC";
            this.notaUC1.EspCaracteres = new string[] {
        "\n\r",
        "\n",
        "\r",
        "\"",
        "<",
        ">",
        "&"};
            this.notaUC1.EspMarcas = new string[] {
        "|NL|",
        "|CR|",
        "|LF|",
        "|quot|",
        "|lt|",
        "|gt|",
        "|A|"};
            this.notaUC1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notaUC1.Grupo = "";
            this.notaUC1.Location = new System.Drawing.Point(4, 298);
            this.notaUC1.Margin = new System.Windows.Forms.Padding(1);
            this.notaUC1.MinimumSize = new System.Drawing.Size(400, 200);
            this.notaUC1.Name = "notaUC1";
            this.notaUC1.Nota = "Prueba NotaUC";
            this.notaUC1.Notas = ((System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>)(resources.GetObject("notaUC1.Notas")));
            this.notaUC1.Padding = new System.Windows.Forms.Padding(1);
            this.notaUC1.Size = new System.Drawing.Size(799, 310);
            this.notaUC1.TabIndex = 1;
            this.notaUC1.Titulo = "Prueba NotaUC";
            this.notaUC1.TituloCabecera = "Prueba NotaUC";
            this.notaUC1.CambioDeTema += new gsNotasNETF.TemaCambiado(this.notaUC1_CambioDeTema);
            this.notaUC1.MenuCerrar += new gsNotasNETF.MensajeDelegate(this.notaUC1_MenuCerrar);
            this.notaUC1.NotaReemplazada += new gsNotasNETF.ReemplazarNota(this.notaUC1_NotaReemplazada_1);
            this.notaUC1.NotaCambiada += new gsNotasNETF.TextoModificado(this.notaUC1_NotaCambiada);
            this.notaUC1.GrupoCambiado += new gsNotasNETF.TextoModificado(this.notaUC1_GrupoCambiado);
            // 
            // OpcChkBorrarNotasAnterioresDrive
            // 
            this.OpcChkBorrarNotasAnterioresDrive.AutoSize = true;
            this.OpcChkBorrarNotasAnterioresDrive.Location = new System.Drawing.Point(6, 276);
            this.OpcChkBorrarNotasAnterioresDrive.Name = "OpcChkBorrarNotasAnterioresDrive";
            this.OpcChkBorrarNotasAnterioresDrive.Size = new System.Drawing.Size(413, 21);
            this.OpcChkBorrarNotasAnterioresDrive.TabIndex = 12;
            this.OpcChkBorrarNotasAnterioresDrive.Text = "Al guardar las notas en Google Drive eliminar las notas anteriores";
            this.OpcChkBorrarNotasAnterioresDrive.UseVisualStyleBackColor = true;
            this.OpcChkBorrarNotasAnterioresDrive.CheckedChanged += new System.EventHandler(this.Opciones_CheckedChanged);
            // 
            // FormNotasUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(807, 613);
            this.Controls.Add(this.tabOpciones);
            this.Controls.Add(this.notaUC1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "FormNotasUC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "gsNotasNETF - Gestionar notas y grupos de notas usando NotaUC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNotasUC_FormClosing);
            this.Load += new System.EventHandler(this.FormNotasUC_Load);
            this.LocationChanged += new System.EventHandler(this.FormNotasUC_LocationChanged);
            this.Resize += new System.EventHandler(this.FormNotasUC_Resize);
            this.NotasFlowLayoutPanel.ResumeLayout(false);
            this.tabOpciones.ResumeLayout(false);
            this.tabNotas.ResumeLayout(false);
            this.tabGrupos.ResumeLayout(false);
            this.GruposFlowLayoutPanel.ResumeLayout(false);
            this.tabEditarGrupos.ResumeLayout(false);
            this.panelEditarGrupos.ResumeLayout(false);
            this.panelEditarGrupos.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabBuscarTexto.ResumeLayout(false);
            this.panelBuscarTexto.ResumeLayout(false);
            this.panelBuscarTexto.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.panelOpciones.ResumeLayout(false);
            this.panelOpciones.PerformLayout();
            this.contextNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel NotasFlowLayoutPanel;
        private NotaUC notaUC1;
        private System.Windows.Forms.Label LblNota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabOpciones;
        private System.Windows.Forms.TabPage tabNotas;
        private System.Windows.Forms.TabPage tabGrupos;
        private System.Windows.Forms.FlowLayoutPanel GruposFlowLayoutPanel;
        private System.Windows.Forms.Label LblGrupo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabEditarGrupos;
        private System.Windows.Forms.Panel panelEditarGrupos;
        private System.Windows.Forms.TextBox txtEdNombreGrupo;
        private System.Windows.Forms.Label lblEdCambiar;
        private System.Windows.Forms.ComboBox cboEdGrupos;
        private System.Windows.Forms.Label lblEdSeleccionar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnCambiarNombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboEdGrupoDestino;
        private System.Windows.Forms.ComboBox cboEdGrupoNotas;
        private System.Windows.Forms.Button btnMoverNota;
        private System.Windows.Forms.ComboBox cboEdNotas;
        private System.Windows.Forms.Label lblEdSeleccionarNota;
        private System.Windows.Forms.Label lblEdInfo;
        private System.Windows.Forms.Button btnClasificarGrupos;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextNotify;
        private System.Windows.Forms.ToolStripMenuItem NotifyMenuRestaurar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem NotifyMenuCerrar;
        private System.Windows.Forms.TabPage tabBuscarTexto;
        private System.Windows.Forms.Panel panelBuscarTexto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.ListBox lstResultadoBuscar;
        private System.Windows.Forms.CheckBox chkBuscarEnGrupoActual;
        private System.Windows.Forms.Label lblBuscando;
        private System.Windows.Forms.Label lblResultadoBuscar;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Panel panelOpciones;
        private System.Windows.Forms.Button OpcBtnDeshacer;
        private System.Windows.Forms.Button OpcBtnGuardar;
        private System.Windows.Forms.CheckBox OpcChkMinimizarAlCerrar;
        private System.Windows.Forms.CheckBox OpcChkAjusteLineas;
        private System.Windows.Forms.Button OpcBtnRestablecerTam;
        private System.Windows.Forms.CheckBox OpcChkRecordarTam;
        private System.Windows.Forms.CheckBox OpChkNoGuardarEnBlanco;
        private System.Windows.Forms.CheckBox OpcChkAutoGuardar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox OpcChkIniciarMinimizada;
        private System.Windows.Forms.CheckBox OpcChkMostrarMismoGrupo;
        private System.Windows.Forms.CheckBox OpcChkMostrarHorizontal;
        private System.Windows.Forms.CheckBox OpcChkShowInTaskBar;
        private System.Windows.Forms.LinkLabel OpcLinkSolicitarAutorización;
        private System.Windows.Forms.CheckBox OpcChkGuardarEnDrive;
        private System.Windows.Forms.CheckBox OpcChkBorrarNotasAnterioresDrive;
    }
}

