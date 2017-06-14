using System;
using System.Configuration;
using System.Data.SqlClient; 

namespace Ventas.Negocio
{
    public class FormaPago 
    {
        public FormaPago() { 

        }

        public void actualizar(int codigo, string nombre) {

            if (existeSegunNombre(nombre)) {


            }
        }

        private bool existeSegunNombre(string nombre) {
            bool estado = false;
            if (    buscaNombre(nombre).Length > 0) {
                estado = true;
            }
            return estado;
        }

        public string[,] buscaNombre(string nombre) {

            string[,] nombres = new String[0,1];

            return nombres;
        }

    }
}