using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Buffete_juridico_estudiantil.Clases
{
    class Usuarios
    {
        #region Variables privadas

        SqlCommand cmd;
        SqlDataAdapter dapUsuarios;
        DataSet dtsUsuarios;
        int m_clave;

        bool bEsNuevo;
        bool bCargarDatos;

        #endregion

        #region Constructor

        public Usuarios(int Clave)
        {
            this.m_clave = Clave;
            this.bCargarDatos = true;
        }

        public Usuarios()
        {
        }

        #endregion

        #region Propiedades
        public string Conexion
        {
           get
            {
               string cnn =
               System.Configuration.ConfigurationManager.
               ConnectionStrings["Conexion"].ConnectionString;
            return cnn;
            }
        }

        public string Usuario
        {
            get
            {
                this.Cargar();
                return this.dtsUsuarios.Tables[0].Rows[0]["USUARIO"].ToString();
            }
        }

        public string Contraseña
        {
            get
            {
                this.Cargar();
                return this.dtsUsuarios.Tables[0].Rows[0]["CONTRASEÑA"].ToString();

            }
        }
        #endregion

        public void Cargar()
        {
            #region abrir conexion

            SqlConnection con = new SqlConnection(this.Conexion);
            con.Open();

            #endregion
            if (bCargarDatos)
            {
                try
                {
                    #region Obtener catalogo

                    string strConsulta = "SELECT * FROM Usuarios WHERE CLAVE = @CLAVE";
                    cmd = new SqlCommand(strConsulta, con);
                    cmd.Parameters.AddWithValue("@CLAVE", this.m_clave);
                    dapUsuarios = new SqlDataAdapter();
                    dtsUsuarios = new DataSet();
                    dapUsuarios.SelectCommand = cmd;
                    dapUsuarios.Fill(dtsUsuarios);

                    #endregion

                    #region Siguiente consecutivo

                    if (this.dtsUsuarios.Tables[0] == null)
                    {
                        DataRow drwUsuarios = dtsUsuarios.Tables[0].NewRow();
                        drwUsuarios["CLAVE"] = siguienteConsecutivo();
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    #region Cerrar conexion
                    con.Close();
                    #endregion

                    throw new Exception("Ocurrio un error al obtener los usuarios" + ex.Message);
                }
                bCargarDatos = false;
            }

            #region Cerrar conexion

            con.Close();
            #endregion

        }

        public void Guardar()
        {
            #region abrir conexion

            SqlConnection con = new SqlConnection(this.Conexion);
            con.Open();

            #endregion

            dapUsuarios.InsertCommand = cmd;
            dapUsuarios.UpdateCommand = cmd;
            dapUsuarios.DeleteCommand = cmd;
            dapUsuarios.Update(dtsUsuarios.Tables[0]);

            #region Cerrar conexion

            con.Close();

            #endregion
        }

        public int siguienteConsecutivo()
        {
            #region abrir conexion

            SqlConnection con = new SqlConnection(this.Conexion);
            con.Open();

            #endregion

            #region Consulta

            string strConsulta = "SELECT MAX(CLAVE)+1 FROM Usuarios";
            cmd = new SqlCommand(strConsulta, con);
            dapUsuarios = new SqlDataAdapter(cmd);
            DataTable dtResultado = new DataTable();
            dapUsuarios.Fill(dtResultado);
            int iResultado = Convert.ToInt32(dtResultado.Rows[0]["CLAVE"]);

            #endregion

            #region Cerrar conexion

            con.Close();
            #endregion

            return iResultado;
        }

        public Usuarios[] buscarPorUsuario(string Usuario)
        {
            #region abrir conexion

            SqlConnection con = new SqlConnection(this.Conexion);
            con.Open();

            #endregion

            #region Obtener catalogo

            string strConsulta = "SELECT * FROM Usuarios WHERE USUARIO = @USUARIO";
            cmd = new SqlCommand(strConsulta, con);
            cmd.Parameters.AddWithValue("@USUARIO", Usuario);
            dapUsuarios = new SqlDataAdapter();
            DataTable dtResultado = new DataTable();
            dapUsuarios.SelectCommand = cmd;
            dapUsuarios.Fill(dtResultado);

            #endregion

            #region crear arreglo

            ArrayList arlUsuarios = new ArrayList();

            foreach (DataRow row in dtResultado.Rows)
            {
                Usuarios usuario = new Usuarios(Convert.ToInt32(row["CLAVE"]));
                arlUsuarios.Add(usuario);
            }
            Usuarios[] arrUsuarios = new Usuarios[arlUsuarios.Count];
            arlUsuarios.CopyTo(arrUsuarios);
            #endregion

            #region Cerrar conexion

            con.Close();
            #endregion

            return arrUsuarios;
        }

    }

}
