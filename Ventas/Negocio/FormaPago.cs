using System;
using System.Configuration;
using System.Data.SqlClient;
using Ventas.Acceso;

namespace Ventas.Negocio
{
    public class FormaPago 
    {
        private Mensaje error;

  

       public void actualizar(string nombre, int codigo)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["stringConexionVentas"].ConnectionString)) {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE TB_FORMA_PAGO SET FopNombre =@nombre WHERE FopCodigo= @codigo", cnx);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx) {
                    error.mensaje = sqlEx.Message;
                    error.cabecera = ".: Error Sistema :.";
                    error.btn = System.Windows.Forms.MessageBoxButtons.OK;
                    error.icon = System.Windows.Forms.MessageBoxIcon.Warning;
                }catch (Exception eEx) {
                    error.mensaje = eEx.Message;
                    error.cabecera = ".: Error Sistema :.";
                    error.btn = System.Windows.Forms.MessageBoxButtons.OK;
                    error.icon = System.Windows.Forms.MessageBoxIcon.Warning;
                }  
            }
        }

    }
}