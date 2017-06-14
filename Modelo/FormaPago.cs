using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class FormaPago
    {
         
        /*
         * declaracion de atributos, deben ser de tipo private, 
         * para asegurar el ocultamiento de los atributos
         */
        private string nombre;
        private int codigo;


        /*
         * las propiedade en C# :
         * Representan características de los objetos que son accedidas como si fueran atributos.
         * Ocultan el uso de métodos get/set.
         * Una propiedad puede representar un atributo calculado.
          *********************************************
          * el nombre de la propiedad debe ser igual al nombre del atributo
          *  *atributo*    private int codigo;
          *  *propiedad*   public  int Codigo{get;set} el nombre de la propiedad debe comenzar con la primera letra mayuscula
         */

        public string Nombre { get; set; }//de esta forma se genera el getter && setter, en una propiead en C#, la finalidad es poder dar visibilidad a una propiedad privada (private int codigo) por medio de una implementacion de un metodo publi
        public int Codigo { get; set; }


        public FormaPago(int codigo, string nombre)
        {
            this.codigo = codigo;//this.codigo, corresponde a la propiedad de la clase, mientras que codigo, es el parametro por valor que se pasa en el contructor
            this.nombre = nombre;//this.nombre, corresponde a la propiedad de la clase, mientras que codigo, es el parametro por valor que se pasa en el contructor
        }
        public void actualizar()
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["stringConexionVentas"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE TB_FORMA_PAGO SET FopNombre =@nombre WHERE FopCodigo= @codigo", cnx);
                    cmd.Parameters.AddWithValue("@nombre", this.nombre);
                    cmd.Parameters.AddWithValue("@codigo", this.codigo);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                { 
                }
                catch (Exception eEx)
                { 


                }
            }
        }
    }
}
