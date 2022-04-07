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
        VentaDetailDTO detail = new VentaDetailDTO();
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
            dataGridView1.Columns[0].HeaderText = "Venta ID";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Nombre Cliente";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Descripcion producto";
            dataGridView1.Columns[5].HeaderText = "Cantidad";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (detail.VentaID == 0)
                MessageBox.Show("Seleccionar una venta de la tabla");
            else
            {
                FrmVenta frm = new FrmVenta();
                frm.detail = detail;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new VentaBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Ventas;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.VentaID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.ClienteID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.NombreCliente = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.ProductoID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            detail.DescripcionProducto = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            detail.Cantidad = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Está seguro de eliminar la venta?", "Warning!!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (bll.Delete(detail.ClienteID))
                {
                    MessageBox.Show("La venta fue eliminada.");
                    FillData();
                }
                else
                {
                    MessageBox.Show("Error al eliminar venta.");
                }
            }
        }
    }
}
