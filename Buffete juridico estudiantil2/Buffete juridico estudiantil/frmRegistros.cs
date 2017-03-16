using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buffete_juridico_estudiantil
{
    public partial class frmRegistros : Form
    {
        public frmRegistros()
        {
            InitializeComponent();
        }

        private void Registros_Load(object sender, EventArgs e)
        {
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Salir",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Asterisk,
            MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                this.Close();
        }
    }
}
