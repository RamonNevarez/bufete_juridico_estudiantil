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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        #region Eventos de los controles

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistros registro = new frmRegistros();
            registro.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Salir",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Asterisk,
            MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                Application.Exit();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar la sesión actual?", "Cerrar sesión",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Asterisk,
            MessageBoxDefaultButton.Button1
            ) == DialogResult.Yes)
            {
                this.Close();
                frmLogin login = new frmLogin();
                login.txtUsuario.Text = null;
                login.txtContraseña.Text = null;
                login.Show();
            }
        }

        private void tramitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTramites tramites = new frmTramites();
            tramites.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes clientes = new frmClientes();
            clientes.Show();
        }

        private void juzgadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJuzgados juzgados = new frmJuzgados();
            juzgados.Show();
        }

        #endregion
    }
}
