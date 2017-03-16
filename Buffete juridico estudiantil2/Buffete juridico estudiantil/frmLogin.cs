using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buffete_juridico_estudiantil.Clases;

namespace Buffete_juridico_estudiantil
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtUsuario.Text != "")
                {
                    if (this.txtContraseña.Text != "")
                    {
                        Usuarios usuarios = new Usuarios();
                        Usuarios[] arrUsuarios = usuarios.buscarPorUsuario(this.txtUsuario.Text);
                        if (arrUsuarios.Length == 0)
                            throw new Exception("El usuario no existe");
                            foreach (Usuarios us in arrUsuarios)
                            {
                                if (this.txtContraseña.Text != us.Contraseña)
                                    throw new Exception("La contraseña es incorrecta");

                                frmMenu menu = new frmMenu();
                                menu.Show();
                                this.Hide();
                            }
                        
                    }
                    else
                        throw new Exception("Debe teclear una contraseña");
                }
                else
                    throw new Exception("Debe teclear un usuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión. " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
