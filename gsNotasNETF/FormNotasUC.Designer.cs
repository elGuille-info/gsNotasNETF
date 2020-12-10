
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNotasUC));
            this.NotasFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.LblNota = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GruposFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.LblGrupo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.notaUC1 = new gsNotasNETF.NotaUC();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NotasFlowLayoutPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.GruposFlowLayoutPanel.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotasFlowLayoutPanel
            // 
            this.NotasFlowLayoutPanel.AutoScroll = true;
            this.NotasFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NotasFlowLayoutPanel.Controls.Add(this.LblNota);
            this.NotasFlowLayoutPanel.Controls.Add(this.label4);
            this.NotasFlowLayoutPanel.Controls.Add(this.label1);
            this.NotasFlowLayoutPanel.Controls.Add(this.label2);
            this.NotasFlowLayoutPanel.Controls.Add(this.label3);
            this.NotasFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotasFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.NotasFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.NotasFlowLayoutPanel.Name = "NotasFlowLayoutPanel";
            this.NotasFlowLayoutPanel.Size = new System.Drawing.Size(762, 169);
            this.NotasFlowLayoutPanel.TabIndex = 0;
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
            this.LblNota.Size = new System.Drawing.Size(201, 87);
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
            this.label4.Location = new System.Drawing.Point(210, 3);
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
            this.label1.Location = new System.Drawing.Point(417, 3);
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
            this.label2.Location = new System.Drawing.Point(603, 3);
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
            this.label3.Location = new System.Drawing.Point(603, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 80);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            this.label3.Click += new System.EventHandler(this.LblNota_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(5, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(789, 247);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.NotasFlowLayoutPanel);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 175);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Notas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GruposFlowLayoutPanel);
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(781, 217);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Grupos";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.GruposFlowLayoutPanel.Size = new System.Drawing.Size(775, 211);
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
            // notaUC1
            // 
            this.notaUC1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notaUC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notaUC1.ColoresClaro = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))))};
            this.notaUC1.ColoresOscuro = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
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
            this.notaUC1.Grupo = "";
            this.notaUC1.Location = new System.Drawing.Point(4, 259);
            this.notaUC1.Margin = new System.Windows.Forms.Padding(1);
            this.notaUC1.MinimumSize = new System.Drawing.Size(400, 200);
            this.notaUC1.Name = "notaUC1";
            this.notaUC1.Nota = "Prueba NotaUC";
            this.notaUC1.Notas = ((System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>)(resources.GetObject("notaUC1.Notas")));
            this.notaUC1.Padding = new System.Windows.Forms.Padding(1);
            this.notaUC1.Size = new System.Drawing.Size(792, 310);
            this.notaUC1.TabIndex = 2;
            this.notaUC1.Titulo = "Prueba NotaUC";
            this.notaUC1.TituloCabecera = "Prueba NotaUC";
            this.notaUC1.CambioDeTema += new gsNotasNETF.TemaCambiado(this.notaUC1_CambioDeTema);
            this.notaUC1.MenuCerrar += new gsNotasNETF.MensajeDelegate(this.notaUC1_MenuCerrar);
            this.notaUC1.NotaReemplazada += new gsNotasNETF.ReemplazarNota(this.notaUC1_NotaReemplazada_1);
            this.notaUC1.NotaCambiada += new gsNotasNETF.TextoModificado(this.notaUC1_NotaCambiada);
            this.notaUC1.GrupoCambiado += new gsNotasNETF.TextoModificado(this.notaUC1_GrupoCambiado);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(781, 217);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Editar grupo";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(769, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editar Grupo";
            // 
            // FormNotasUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.notaUC1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "FormNotasUC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "gsNotasNETF - Gestionar notas y grupos de notas usando NotaUC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNotasUC_FormClosing);
            this.Load += new System.EventHandler(this.FormNotasUC_Load);
            this.NotasFlowLayoutPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.GruposFlowLayoutPanel.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel GruposFlowLayoutPanel;
        private System.Windows.Forms.Label LblGrupo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

