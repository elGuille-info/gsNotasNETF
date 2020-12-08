
namespace gsNotasNETF
{
    partial class NotaUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotaUC));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusInfoPos = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusInfoTecla = new System.Windows.Forms.ToolStripSplitButton();
            this.MnuLeer = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuNuevoGrupo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuClasificar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuEliminarNota = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuSustituirNota = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAñadirNota = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuAcercaDE = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtEdit = new System.Windows.Forms.RichTextBox();
            this.cabeceraNotaUC1 = new gsNotasNETF.CabeceraNotaUC();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cabeceraNotaUC1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 42);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(2, 273);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(496, 25);
            this.panel2.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusInfo,
            this.statusInfoPos,
            this.statusInfoTecla});
            this.statusStrip1.Location = new System.Drawing.Point(0, 3);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(496, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusInfo
            // 
            this.statusInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(349, 17);
            this.statusInfo.Spring = true;
            this.statusInfo.Text = "ToolStripStatusLabel1";
            this.statusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusInfoPos
            // 
            this.statusInfoPos.AutoSize = false;
            this.statusInfoPos.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.statusInfoPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.statusInfoPos.Name = "statusInfoPos";
            this.statusInfoPos.Size = new System.Drawing.Size(72, 17);
            this.statusInfoPos.Text = "L: 10, C: 80";
            // 
            // statusInfoTecla
            // 
            this.statusInfoTecla.AutoSize = false;
            this.statusInfoTecla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusInfoTecla.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuLeer,
            this.MnuGuardar,
            this.toolStripSeparator2,
            this.MnuNuevoGrupo,
            this.toolStripSeparator1,
            this.MnuClasificar,
            this.toolStripSeparator3,
            this.MnuEliminarNota,
            this.toolStripSeparator4,
            this.MnuSustituirNota,
            this.MnuAñadirNota,
            this.toolStripSeparator5,
            this.MnuAcercaDE});
            this.statusInfoTecla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.statusInfoTecla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.statusInfoTecla.Name = "statusInfoTecla";
            this.statusInfoTecla.Size = new System.Drawing.Size(60, 20);
            this.statusInfoTecla.Text = "Shift+F8";
            this.statusInfoTecla.ToolTipText = "Opciones rápidas";
            // 
            // MnuLeer
            // 
            this.MnuLeer.Image = ((System.Drawing.Image)(resources.GetObject("MnuLeer.Image")));
            this.MnuLeer.Name = "MnuLeer";
            this.MnuLeer.ShortcutKeyDisplayString = "Ctrl+L";
            this.MnuLeer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.MnuLeer.Size = new System.Drawing.Size(220, 22);
            this.MnuLeer.Text = "Leer notas";
            this.MnuLeer.Click += new System.EventHandler(this.MnuLeer_Click);
            // 
            // MnuGuardar
            // 
            this.MnuGuardar.Image = ((System.Drawing.Image)(resources.GetObject("MnuGuardar.Image")));
            this.MnuGuardar.Name = "MnuGuardar";
            this.MnuGuardar.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            this.MnuGuardar.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.MnuGuardar.Size = new System.Drawing.Size(220, 22);
            this.MnuGuardar.Text = "Guardar notas";
            this.MnuGuardar.ToolTipText = "Guarda las notas\r\nTambién pulsando F9";
            this.MnuGuardar.Click += new System.EventHandler(this.MnuGuardar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(217, 6);
            // 
            // MnuNuevoGrupo
            // 
            this.MnuNuevoGrupo.Image = ((System.Drawing.Image)(resources.GetObject("MnuNuevoGrupo.Image")));
            this.MnuNuevoGrupo.Name = "MnuNuevoGrupo";
            this.MnuNuevoGrupo.ShortcutKeyDisplayString = "Ctrl+G";
            this.MnuNuevoGrupo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.MnuNuevoGrupo.Size = new System.Drawing.Size(220, 22);
            this.MnuNuevoGrupo.Text = "Nuevo Grupo";
            this.MnuNuevoGrupo.ToolTipText = "Escribe el nuevo nombre del grupo y pulsa ENTER";
            this.MnuNuevoGrupo.Click += new System.EventHandler(this.MnuNuevoGrupo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // MnuClasificar
            // 
            this.MnuClasificar.Image = ((System.Drawing.Image)(resources.GetObject("MnuClasificar.Image")));
            this.MnuClasificar.Name = "MnuClasificar";
            this.MnuClasificar.ShortcutKeyDisplayString = "F5";
            this.MnuClasificar.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.MnuClasificar.Size = new System.Drawing.Size(220, 22);
            this.MnuClasificar.Text = "Clasificar las notas";
            this.MnuClasificar.ToolTipText = "Clasifica las notas del grupo seleccionado";
            this.MnuClasificar.Click += new System.EventHandler(this.MnuClasificar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(217, 6);
            // 
            // MnuEliminarNota
            // 
            this.MnuEliminarNota.Image = ((System.Drawing.Image)(resources.GetObject("MnuEliminarNota.Image")));
            this.MnuEliminarNota.Name = "MnuEliminarNota";
            this.MnuEliminarNota.ShortcutKeyDisplayString = "F6";
            this.MnuEliminarNota.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.MnuEliminarNota.Size = new System.Drawing.Size(220, 22);
            this.MnuEliminarNota.Text = "Eliminar nota";
            this.MnuEliminarNota.ToolTipText = "Elimina la nota actual";
            this.MnuEliminarNota.Click += new System.EventHandler(this.MnuEliminarNota_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(217, 6);
            // 
            // MnuSustituirNota
            // 
            this.MnuSustituirNota.Image = ((System.Drawing.Image)(resources.GetObject("MnuSustituirNota.Image")));
            this.MnuSustituirNota.Name = "MnuSustituirNota";
            this.MnuSustituirNota.ShortcutKeyDisplayString = "Shift+F8";
            this.MnuSustituirNota.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F8)));
            this.MnuSustituirNota.Size = new System.Drawing.Size(220, 22);
            this.MnuSustituirNota.Text = "Sustituir nota";
            this.MnuSustituirNota.ToolTipText = "Sustituye la nota seleccionada con el texto actual";
            this.MnuSustituirNota.Click += new System.EventHandler(this.MnuSustituirNota_Click);
            // 
            // MnuAñadirNota
            // 
            this.MnuAñadirNota.Image = ((System.Drawing.Image)(resources.GetObject("MnuAñadirNota.Image")));
            this.MnuAñadirNota.Name = "MnuAñadirNota";
            this.MnuAñadirNota.ShortcutKeyDisplayString = "F8";
            this.MnuAñadirNota.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.MnuAñadirNota.Size = new System.Drawing.Size(220, 22);
            this.MnuAñadirNota.Text = "Añadir nota";
            this.MnuAñadirNota.ToolTipText = "Añade el texto actual como nueva nota";
            this.MnuAñadirNota.Click += new System.EventHandler(this.MnuAñadirNota_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(217, 6);
            // 
            // MnuAcercaDE
            // 
            this.MnuAcercaDE.Image = ((System.Drawing.Image)(resources.GetObject("MnuAcercaDE.Image")));
            this.MnuAcercaDE.Name = "MnuAcercaDE";
            this.MnuAcercaDE.ShortcutKeyDisplayString = "F1";
            this.MnuAcercaDE.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.MnuAcercaDE.Size = new System.Drawing.Size(220, 22);
            this.MnuAcercaDE.Text = "Acerca de...";
            this.MnuAcercaDE.Click += new System.EventHandler(this.MnuAcercaDe_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtEdit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(496, 229);
            this.panel3.TabIndex = 2;
            // 
            // txtEdit
            // 
            this.txtEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEdit.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdit.Location = new System.Drawing.Point(0, 0);
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.Size = new System.Drawing.Size(496, 229);
            this.txtEdit.TabIndex = 0;
            this.txtEdit.Text = "";
            this.txtEdit.SelectionChanged += new System.EventHandler(this.txtEdit_SelectionChanged);
            this.txtEdit.Enter += new System.EventHandler(this.txtEdit_Enter);
            this.txtEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEdit_KeyDown);
            this.txtEdit.Leave += new System.EventHandler(this.txtEdit_Leave);
            // 
            // cabeceraNotaUC1
            // 
            this.cabeceraNotaUC1.BackColor = System.Drawing.Color.White;
            this.cabeceraNotaUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cabeceraNotaUC1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.cabeceraNotaUC1.Location = new System.Drawing.Point(0, 0);
            this.cabeceraNotaUC1.LongitudTituloNota = 80;
            this.cabeceraNotaUC1.MinimumSize = new System.Drawing.Size(400, 42);
            this.cabeceraNotaUC1.Name = "cabeceraNotaUC1";
            this.cabeceraNotaUC1.Notas = null;
            this.cabeceraNotaUC1.Size = new System.Drawing.Size(496, 42);
            this.cabeceraNotaUC1.TabIndex = 0;
            this.cabeceraNotaUC1.Titulo = "Título de la nota";
            this.cabeceraNotaUC1.NotaCambiada += new gsNotasNETF.TextoModificado(this.cabeceraNotaUC1_NotaCambiada);
            this.cabeceraNotaUC1.GrupoCambiado += new gsNotasNETF.TextoModificado(this.cabeceraNotaUC1_GrupoCambiado);
            // 
            // NotaUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "NotaUC";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(500, 300);
            this.Load += new System.EventHandler(this.NotaUC_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NotaUC_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusInfo;
        private System.Windows.Forms.ToolStripStatusLabel statusInfoPos;
        private System.Windows.Forms.ToolStripSplitButton statusInfoTecla;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox txtEdit;
        private CabeceraNotaUC cabeceraNotaUC1;
        private System.Windows.Forms.ToolStripMenuItem MnuGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MnuClasificar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MnuSustituirNota;
        private System.Windows.Forms.ToolStripMenuItem MnuAñadirNota;
        private System.Windows.Forms.ToolStripMenuItem MnuLeer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem MnuNuevoGrupo;
        private System.Windows.Forms.ToolStripMenuItem MnuEliminarNota;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem MnuAcercaDE;
    }
}
