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

        public FormEditarNotaUC(NotaUC nuevaNotaUC, string laNota, int index) : this()
        {
            IndiceNota = index;
            //notaUC1 = nuevaNotaUC;
            notaUC1.EditorText = laNota;
            notaUC1.OcultarCabecera = true;
            notaUC1.TituloCabecera = laNota;
            notaUC1.ComboGrupos.Text = nuevaNotaUC.ComboGrupos.Text;
        }

        //public FormEditarNotaUC(NotaUC nuevaNotaUC) : this()
        //{

        //    notaUC1 = nuevaNotaUC;
        //    //notaUC1.NotaUCBase = nuevaNotaUC;
        //    //notaUC1.EditorText = notaUC1.EditorText;
        //    notaUC1.OcultarCabecera = true;
        //    notaUC1.TituloCabecera = notaUC1.EditorText;
        //}

        private void FormEditarNotaUC_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            //notaUC1.EditorText = nuevaNotaUC.EditorText;
            //notaUC1.Show();
            //notaUC1.NotaUCBase = nuevaNotaUC;
            //notaUC1.EditorText = notaUC1.NotaUCBase.EditorText;
        }

        private void FormEditarNotaUC_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
