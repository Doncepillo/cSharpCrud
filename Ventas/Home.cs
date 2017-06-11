using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void adminitraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente.Administracion ad = new Cliente.Administracion();
            ad.MdiParent = this;
            ad.Show();

        }
    }
}
