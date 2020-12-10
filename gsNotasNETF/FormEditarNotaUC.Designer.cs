﻿
namespace gsNotasNETF
{
    partial class FormEditarNotaUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarNotaUC));
            this.notaUC1 = new gsNotasNETF.NotaUC();
            this.SuspendLayout();
            // 
            // notaUC1
            // 
            this.notaUC1.ColoresClaro = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))))};
            this.notaUC1.ColoresOscuro = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Gold};
            this.notaUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notaUC1.EditorRtf = resources.GetString("notaUC1.EditorRtf");
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
            this.notaUC1.Location = new System.Drawing.Point(3, 3);
            this.notaUC1.MinimumSize = new System.Drawing.Size(400, 200);
            this.notaUC1.Name = "notaUC1";
            this.notaUC1.Nota = "";
            this.notaUC1.Notas = ((System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>)(resources.GetObject("notaUC1.Notas")));
            this.notaUC1.Padding = new System.Windows.Forms.Padding(2);
            this.notaUC1.Size = new System.Drawing.Size(504, 284);
            this.notaUC1.TabIndex = 0;
            this.notaUC1.Tema = gsNotasNETF.Temas.Claro;
            this.notaUC1.Titulo = "";
            this.notaUC1.TituloCabecera = "";
            this.notaUC1.MenuCerrar += new gsNotasNETF.MensajeDelegate(this.notaUC1_MenuCerrar);
            this.notaUC1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notaUC1_MouseDown);
            this.notaUC1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notaUC1_MouseMove);
            this.notaUC1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notaUC1_MouseUp);
            // 
            // FormEditarNotaUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 290);
            this.Controls.Add(this.notaUC1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarNotaUC";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "FormEditarNotaUC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditarNotaUC_FormClosing);
            this.Load += new System.EventHandler(this.FormEditarNotaUC_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notaUC1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notaUC1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notaUC1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private NotaUC notaUC1;
    }
}