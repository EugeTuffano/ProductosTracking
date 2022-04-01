using BLL;
using BLL.DTO;
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
    public partial class FrmListaVentas : Form
    {
        public FrmListaVentas()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmVenta frm = new FrmVenta();
            //this.Visible = false;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void FrmListaVentas_Load(object sender, EventArgs e)
        {
            List<VentaDetailDTO> dto = VentaBLL.Select();
            dataGridView1.DataSource = dto;
            dataGridView1.Columns[0].HeaderText = "Cliente ID";
            dataGridView1.Columns[1].HeaderText = "Nombre Cliente";
            dataGridView1.Columns[2].HeaderText = "Producto ID";
            dataGridView1.Columns[3].HeaderText = "Descripcion producto";
            dataGridView1.Columns[4].HeaderText = "Cantidad";

        }
    }
}
