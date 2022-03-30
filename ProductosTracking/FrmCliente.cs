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
using BLL.DTO;

namespace ProductosTracking
{
    public partial class FrmCliente : Form
    {
        public ClienteDTO dto = new ClienteDTO();
        ClienteBLL bll = new ClienteBLL();
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            /*
            cmbProvincia.DataSource = dto.Provincias;
            cmbProvincia.DisplayMember = "Provincias";
            cmbProvincia.ValueMember = "ID";
            cmbProvincia.SelectedIndex = -1;
            */
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreCliente.Text.Trim() == "")
                MessageBox.Show("El nombre del cliente está vacio");
            else if (txtDireccion.Text.Trim() == "")
                MessageBox.Show("La dirección está está vacia");
            else if (cmbProvincia.SelectedIndex == -1)
                MessageBox.Show("Seleccionar provincia");
            else if (cmbTipoDoc.SelectedIndex == -1)
                MessageBox.Show("Seleccionar tipo de documento");
            else if (txtNroDoc.Text.Trim() == "")
                MessageBox.Show("El número del documento está vacio");
            else
            {
                ClienteDetailDTO product = new ClienteDetailDTO();
                product.Nombre = txtNombreCliente.Text;
                product.Provincia = Convert.ToInt32(cmbProvincia.SelectedValue);
                product.TipoDocumento = Convert.ToInt32(cmbTipoDoc.SelectedValue);
                product.NroDocumento = Convert.ToInt32(txtNroDoc);
                if (bll.Insert(product))
                {
                    MessageBox.Show("Product was added");
                    txtNombreCliente.Clear();
                    txtDireccion.Clear();
                    cmbProvincia.SelectedIndex = -1;
                    cmbTipoDoc.SelectedIndex = -1;
                    txtNroDoc.Clear();
                }
            }
        }
    }
}
