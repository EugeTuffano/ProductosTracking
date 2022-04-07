using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace ProductosTracking
{
    public partial class FrmListaClientes : Form
    {
        ClienteDTO dto = new ClienteDTO();
        ClienteBLL bll = new ClienteBLL();
        ClienteDetailDTO detail = new ClienteDetailDTO();

        public FrmListaClientes()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmCliente frm = new FrmCliente();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillData();
        }

        private void FrmListaClientes_Load(object sender, EventArgs e)
        {
            FillData();
            /*
            dto = bll.Select();
            dataGridView1.DataSource = dto.Clientes;
            dataGridView1.Columns[0].HeaderText = "Cliente ID";
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Direccion";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Provincia";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Tipo de documento";
            dataGridView1.Columns[7].HeaderText = "Numero de documento";
            */
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            List<ClienteDetailDTO> list = dto.Clientes;
            list = list.Where(x => x.Nombre.Contains(txtNombre.Text)).ToList();
            dataGridView1.DataSource = list;
        }

        void FillData()
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Clientes;
            dataGridView1.Columns[0].HeaderText = "Cliente ID";
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Direccion";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Provincia";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Tipo de documento";
            dataGridView1.Columns[7].HeaderText = "Numero de documento";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Está seguro de eliminar al cliente?", "Warning!!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (bll.Delete(detail.ClienteID))
                {
                    MessageBox.Show("El cliente fue eliminado");
                    FillData();
                }
                else
                {
                    MessageBox.Show("Error al eliminar cliente.");
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ClienteID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.Nombre = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.Direccion = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.Provincia = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            detail.NombreProvincia = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            detail.TipoDocumento = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.NombreTipoDoc = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            detail.NroDocumento = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (detail.ClienteID == 0)
                MessageBox.Show("Seleccionar cliente de la tabla");
            else
            {
                FrmCliente frm = new FrmCliente();
                frm.detail = detail;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new ClienteBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Clientes;
            }
        }
    }
}