using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Acceso
{
    interface ICrud
    { 
        void guardar();
        void eliminar();
        void actualizar();
        string[,] listar();
        string[,] listar(string query);

    }
}
