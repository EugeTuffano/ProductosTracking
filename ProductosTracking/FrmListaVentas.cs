using BLL;
using DTO;
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
        VentaBLL bll = new VentaBLL();
        VentaDTO dto = new VentaDTO();
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
            FillData();

        }

        private void FrmListaVentas_Load(object sender, EventArgs e)
        {
            FillData();
            /*
            dto = bll.Select();
            dataGridView1.DataSource = dto.Ventas;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre Cliente";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Descripcion producto";
            dataGridView1.Columns[4].HeaderText = "Cantidad";
            */

        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            List<VentaDetailDTO> list = dto.Ventas;
            list = list.Where(x => x.NombreCliente.Contains(txtBuscarCliente.Text)).ToList();
            dataGridView1.DataSource = list;
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            List<VentaDetailDTO> list = dto.Ventas;
            list = list.Where(x => x.DescripcionProducto.Contains(txtBuscarProducto.Text)).ToList();
            dataGridView1.DataSource = list;
        }

        void FillData()
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Ventas;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre Cliente";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Descripcion producto";
            dataGridView1.Columns[4].HeaderText = "Cantidad";
        }
    }
}
