
namespace gsNotasNETF
{
    partial class CabeceraNotaUC
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
            this.LabelTitulo = new System.Windows.Forms.Label();
            this.CboGrupos = new System.Windows.Forms.ComboBox();
            this.CboNotas = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LabelTitulo
            // 
            this.LabelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.LabelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTitulo.ForeColor = System.Drawing.Color.White;
            this.LabelTitulo.Location = new System.Drawing.Point(0, 0);
            this.LabelTitulo.Margin = new System.Windows.Forms.Padding(0);
            this.LabelTitulo.Name = "LabelTitulo";
            this.LabelTitulo.Size = new System.Drawing.Size(490, 21);
            this.LabelTitulo.TabIndex = 0;
            this.LabelTitulo.Text = "NotasUC";
            this.LabelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CboGrupos
            // 
            this.CboGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboGrupos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.CboGrupos.FormattingEnabled = true;
            this.CboGrupos.Location = new System.Drawing.Point(0, 21);
            this.CboGrupos.Margin = new System.Windows.Forms.Padding(0);
            this.CboGrupos.Name = "CboGrupos";
            this.CboGrupos.Size = new System.Drawing.Size(181, 21);
            this.CboGrupos.TabIndex = 1;
            this.CboGrupos.Text = "Grupos";
            this.CboGrupos.SelectedIndexChanged += new System.EventHandler(this.CboGrupos_SelectedIndexChanged);
            this.CboGrupos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboGrupos_KeyPress);
            this.CboGrupos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CboGrupos_KeyUp);
            this.CboGrupos.Validating += new System.ComponentModel.CancelEventHandler(this.CboGrupos_Validating);
            // 
            // CboNotas
            // 
            this.CboNotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CboNotas.BackColor = System.Drawing.Color.White;
            this.CboNotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboNotas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboNotas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.CboNotas.FormattingEnabled = true;
            this.CboNotas.Location = new System.Drawing.Point(182, 21);
            this.CboNotas.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.CboNotas.Name = "CboNotas";
            this.CboNotas.Size = new System.Drawing.Size(308, 21);
            this.CboNotas.TabIndex = 2;
            this.CboNotas.SelectedIndexChanged += new System.EventHandler(this.CboNotas_SelectedIndexChanged);
            this.CboNotas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboNotas_KeyPress);
            this.CboNotas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CboNotas_KeyUp);
            this.CboNotas.Validating += new System.ComponentModel.CancelEventHandler(this.CboNotas_Validating);
            // 
            // CabeceraNotaUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.CboNotas);
            this.Controls.Add(this.CboGrupos);
            this.Controls.Add(this.LabelTitulo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.MinimumSize = new System.Drawing.Size(400, 42);
            this.Name = "CabeceraNotaUC";
            this.Size = new System.Drawing.Size(490, 42);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelTitulo;
        private System.Windows.Forms.ComboBox CboGrupos;
        private System.Windows.Forms.ComboBox CboNotas;
    }
}
