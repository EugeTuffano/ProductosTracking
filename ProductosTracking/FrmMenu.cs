using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosTracking
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmListaClientes frm = new FrmListaClientes();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            FrmListaVentas frm = new FrmListaVentas();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
