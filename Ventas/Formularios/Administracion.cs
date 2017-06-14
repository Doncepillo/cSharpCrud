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

        Negocio.Cliente cliente     = new Negocio.Cliente();
        Negocio.FormaPago formaPago = new Negocio.FormaPago();
    
        public Administracion()
        {
            InitializeComponent();
            
        }

        private void cargaRegistros(object sender, EventArgs e)
        { 
           
        }
        private void cargarGrillaClientes() {
            using (SqlConnection conn = new SqlConnection(stringConection))
            {
                try
                {
                    string query = "SELECT " +
                                            "TB_CLIENTE.CliRut, " +
                                            "CONCAT(TB_CLIENTE.CliNombre, ' ', TB_CLIENTE.CliApellido), " +
                                            "TB_FORMA_PAGO.FopNombre, " +
                                            "TB_CLIENTE.CliFechaIngreso " +
                                        "FROM TB_CLIENTE " +
                                            "LEFT JOIN TB_FORMA_PAGO ON TB_CLIENTE.FopCodigo = TB_FORMA_PAGO.FopCodigo";
                    SqlDataAdapter dAdap = new SqlDataAdapter(query, conn);
                    conn.Open(); 
                    DataSet dSet = new DataSet();
                    dAdap.Fill(dSet, "Clientes"); 

                    DataTable dt = dSet.Tables["Clientes"];

                    dgvClientes.Columns[0].HeaderText = "Rut";
                    dgvClientes.Columns[1].HeaderText = "Nombre Completo";
                    dgvClientes.Columns[2].HeaderText = "Forma Pago";
                    dgvClientes.Columns[3].HeaderText = "Fecha Ingreso";

                    foreach (DataRow fila in dt.Rows)
                    {
                    //    dgvClientes.Rows[ i ].Cells[0].Value = 
                    //    string valor1 = Convert.ToString(row["columna1"]);
                    //    int valor2 = Convert.ToString(row["columna2"]);

                    }




                     
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                           "Error al conectarse a la base de Datos : Al listar Alumno en Grilla" + ex,
                           ".: Sistema Alumnos :.",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error
                           );
                }
            }
        }
        private void cargarFormaPago() {

            //formaPago.listar();

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

        private void formateaRut(object sender, KeyEventArgs e)
        {
           cliente.formateaRut(txtRut); 
        }

        private void validaRut(object sender, CancelEventArgs e)
        {
            if ( !cliente.validaRut(txtRut.Text)) {
                MessageBox.Show(
                                "Rut ingresado no corresponde",
                                ".: Sistema de Ventas :.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                                );
                txtRut.Select();
                txtRut.Focus();
            } 
        } 
    }
}
