using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas.Negocio
{
    class Cliente
    {

        private string digitoVerificador(int rut)
        {
            int digito,contador,multiplo,acumulador;
            string rutDigito;

            contador = 2;
            acumulador = 0;

            while (rut != 0) {
                multiplo = (rut % 10) * contador;
                acumulador = acumulador + multiplo;
                rut = rut / 10;
                contador = contador + 1;
                if (contador == 8) {
                    contador = 2;
                } 
            }

            digito = 11 - (acumulador % 11);
            rutDigito = digito.ToString().Trim();
            if (digito == 10)
            {
                rutDigito = "K";
            }
            if (digito == 11)
            {
                rutDigito = "0";
            }
            return (rutDigito);
        }

        private int convierteRutNumerico(string rut, bool quitarUltimo) {
            if (quitarUltimo) {
                rut = rut.Substring(0, rut.Length - 1).Replace(".", "").Replace("-", "");
            }
            else{
                rut = rut.Replace(".", "").Replace("-", "");
            } 
            return Convert.ToInt32(rut);
        }
        public string formateaRut(int rut) {
                return rut.ToString("N0") + "-" + digitoVerificador(rut);
        }

        public void formateaRut(TextBox objeto)
        { 
            string run = objeto.Text;
            string rut = ""; 

            if (run.Length > 0) {
                int cont = 0;
                run = run.Replace(".", "").Replace("-", "");

                rut = "-" + run.Substring(run.Length - 1);
                for (int i = run.Length - 2; i >= 0; i--) {
                    rut = run.Substring(i, 1) + rut;
                    cont++;
                    if (cont == 3 && i != 0) {
                        rut = "." + rut;
                        cont = 0;
                    }
                } 

                objeto.Text = rut;
                objeto.SelectionStart = objeto.Text.Length;
            } 
        }
 
        public bool validaRut(string rut)
        {
            if (!rut.Equals("")) {
              string rutFormateado =  formateaRut( convierteRutNumerico(rut, true) );

                if (  rutFormateado.Equals(rut) ) {
                    return true;
                };
            }
            return false;
        }
    }
}
