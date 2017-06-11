using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas.Cliente
{
    public partial class Administracion : Form
    {
        string stringConection = ConfigurationManager.ConnectionStrings["stringConexionVentas"].ConnectionString;


        public Administracion()
        {
            InitializeComponent();
        }

        private void cargaRegistros(object sender, EventArgs e)
        {
            MessageBox.Show("Hola mundo");
            cargarFormaPago();
            cargarGrillaClientes();
        }
        private void cargarGrillaClientes() {

        }
        private void cargarFormaPago() {
            //coneccion exitosa
            Console.Write("voy por aca");

            using (SqlConnection cnx = new SqlConnection(stringConection)) {
                //me conecte perfect
                try
                {
                    string query = "SELECT FopCodigo, FopNombre FROM TB_FORMA_PAGO";
                    SqlDataAdapter sAdap = new SqlDataAdapter(query, cnx);
                    DataSet dSet = new DataSet();
                    sAdap.Fill(dSet, "FormasPago");
                    cbxFormaPago.DisplayMember = "FopNombre";
                    cbxFormaPago.ValueMember = "FopCodigo";
                    cbxFormaPago.DataSource = dSet.Tables["FormasPago"];

                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);

                }
        
            }
        }
    }
}
