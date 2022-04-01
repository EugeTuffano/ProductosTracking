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
    public partial class FrmListaClientes : Form
    {
        ClienteDTO dto = new ClienteDTO();
        ClienteBLL bll = new ClienteBLL();

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
        }

        private void FrmListaClientes_Load(object sender, EventArgs e)
        {
            List<ClienteDetailDTO> listdto = ClienteBLL.Select();
            dataGridView1.DataSource = listdto;
            dataGridView1.Columns[0].HeaderText = "Cliente ID";
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Direccion";
            dataGridView1.Columns[3].HeaderText = "Provincia";
            dataGridView1.Columns[4].HeaderText = "Tipo de documento";
            dataGridView1.Columns[5].HeaderText = "Numero de documento";

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            List<ClienteDetailDTO> list = ClienteBLL.Select();
            list = list.Where(x => x.Nombre.Contains(txtNombre.Text)).ToList();
            dataGridView1.DataSource = list;
        }
    }
}
