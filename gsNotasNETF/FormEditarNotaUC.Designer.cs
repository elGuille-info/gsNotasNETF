
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
            this.notaUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notaUC1.EditorRtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang3082{\\fonttbl{\\f0\\fnil\\fcharset0 " +
    "Consolas;}}\r\n{\\*\\generator Riched20 10.0.19041}\\viewkind4\\uc1 \r\n\\pard\\f0\\fs20\\pa" +
    "r\r\n}\r\n";
            this.notaUC1.Location = new System.Drawing.Point(0, 0);
            this.notaUC1.MinimumSize = new System.Drawing.Size(400, 200);
            this.notaUC1.Name = "notaUC1";
            this.notaUC1.Notas = ((System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>)(resources.GetObject("notaUC1.Notas")));
            this.notaUC1.Padding = new System.Windows.Forms.Padding(2);
            this.notaUC1.Size = new System.Drawing.Size(633, 296);
            this.notaUC1.TabIndex = 0;
            // 
            // FormEditarNotaUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 296);
            this.Controls.Add(this.notaUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarNotaUC";
            this.Text = "FormEditarNotaUC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditarNotaUC_FormClosing);
            this.Load += new System.EventHandler(this.FormEditarNotaUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private NotaUC notaUC1;
    }
}