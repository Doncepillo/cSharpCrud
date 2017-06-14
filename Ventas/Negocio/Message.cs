using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Ventas.Negocio
{
    struct Message
    {

        public string mensaje;
        public string encabezado;
        public MessageBoxButtons btn;
        public MessageBoxIcon icon;


        public Message generaMensaje(string[] mensaje) {
            this.mensaje = mensaje[0].ToString();
            this.encabezado = mensaje[1].ToString();

            this.btn = seleccionaButton( Convert.ToInt16( mensaje[2].ToString() ) );
            this.icon = seleccionaIcono( Convert.ToInt16( mensaje[3].ToString() ) );
            return this;
        }
        public MessageBoxButtons seleccionaButton(int tipo) {
            MessageBoxButtons buton = new MessageBoxButtons();
            switch (tipo) {
                case 0:
                    buton = MessageBoxButtons.OK;
                    break;
                case 1:
                    buton = MessageBoxButtons.OKCancel;
                    break;
                case 2:
                    buton = MessageBoxButtons.RetryCancel;
                    break;
                case 3:
                    buton = MessageBoxButtons.YesNo;
                    break;
                case 4:
                    buton = MessageBoxButtons.YesNoCancel;
                    break;
                case 5:
                    buton = MessageBoxButtons.AbortRetryIgnore;
                    break; 
            }
            return buton;
        }
        public MessageBoxIcon seleccionaIcono(int tipo) {
            MessageBoxIcon icono = new MessageBoxIcon();
            switch (tipo)
            {
                case 0:
                    icono = MessageBoxIcon.Information;
                    break;
                case 1:
                    icono = MessageBoxIcon.Warning;
                    break;
                case 2:
                    icono = MessageBoxIcon.Error;
                    break;
                case 3:
                    icono = MessageBoxIcon.Exclamation;
                    break;
                case 4:
                    icono = MessageBoxIcon.Question;
                    break;
                case 5:
                    icono = MessageBoxIcon.Stop;
                    break;
                case 6:
                    icono = MessageBoxIcon.Asterisk;
                    break;
                case 7:
                    icono = MessageBoxIcon.None;
                    break;
                case 8:
                    icono = MessageBoxIcon.Hand;
                    break;
            }
            return icono;

        }
    }
}
