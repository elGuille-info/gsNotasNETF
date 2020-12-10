//-----------------------------------------------------------------------------
// <Nombre>                                                         (09/Dic/20)
// <descripción>
//
// (c) Guillermo (elGuille) Som, 2020
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace gsNotasNETF
{
    public partial class FormEditarNotaUC : Form
    {
        public FormEditarNotaUC()
        {
            InitializeComponent();
        }
        
        private int IndiceNota;
        private string ElGrupo;

        public FormEditarNotaUC(NotaUC nuevaNotaUC, string laNota, int index) : this()
        {
            IndiceNota = index;
            ElGrupo = nuevaNotaUC.ComboGrupos.Text;

            // Si se hace esta asignación no se muestra la nota
            //notaUC1 = nuevaNotaUC;
            notaUC1.EditorText = laNota;
            notaUC1.ModoEdicionNota = true;
            notaUC1.TituloCabecera = laNota;
            notaUC1.ComboGrupos.Text = nuevaNotaUC.ComboGrupos.Text;
            notaUC1.NotaReemplazada += NotaUC1_NotaReemplazada;
            notaUC1.Tema = nuevaNotaUC.Tema;
            this.BackColor = notaUC1.ForeColor;
            this.ForeColor = notaUC1.BackColor;
        }

        private void NotaUC1_NotaReemplazada(string grupo, string texto, int index)
        {
            //OnNotaReemplazada(grupo, texto, index);
            OnNotaReemplazada(ElGrupo, notaUC1.EditorText, IndiceNota);
            //this.Close();
        }

        public event ReemplazarNota NotaReemplazada;

        protected virtual void OnNotaReemplazada(string grupo, string texto, int index)
        {
            NotaReemplazada?.Invoke(grupo, texto, index);
        }

        private void FormEditarNotaUC_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void FormEditarNotaUC_FormClosing(object sender, FormClosingEventArgs e)
        {
            //OnNotaReemplazada(ElGrupo, notaUC1.EditorText, IndiceNota);
        }

        //
        // Para mover el formulario pulsando en los controles que están encima
        // el código que suelo usar en mis aplicaciones (normalmente en las ventanas AcercaDe)
        // adaptado de VB a C#
        //

        private int pX;
        private int pY;
        private bool ratonPulsado;

        private void notaUC1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ratonPulsado = true;
                pX = e.X;
                pY = e.Y;
            }
        }

        private void notaUC1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ratonPulsado)
            {
                this.Left += e.X - pX;
                this.Top += e.Y - pY;
            }
        }

        private void notaUC1_MouseUp(object sender, MouseEventArgs e)
        {
            ratonPulsado = false;
        }

        private void notaUC1_MenuCerrar(string mensaje)
        {
            this.Close();
        }
    }
}
