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
    public partial class FrmCliente : Form
    {
        public ClienteDTO dto = new ClienteDTO();
        public ClienteBLL bll = new ClienteBLL();
        public ClienteDetailDTO detail = new ClienteDetailDTO();
        public bool isUpdate = false;
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
            dto = bll.Select();
            cmbProvincia.DataSource = dto.Provincias;
            cmbProvincia.DisplayMember = "Descripcion";
            cmbProvincia.ValueMember = "ProvinciaID";
            cmbProvincia.SelectedIndex = -1;
            cmbTipoDoc.DataSource = dto.TipoDocumentos;
            cmbTipoDoc.DisplayMember = "Descripcion";
            cmbTipoDoc.ValueMember = "IDTipoDoc";
            cmbTipoDoc.SelectedIndex = -1;

            if (isUpdate)
            {
                txtNombreCliente.Text = detail.Nombre;
                txtDireccion.Text = detail.Direccion;
                cmbProvincia.SelectedValue = detail.Provincia;
                cmbTipoDoc.SelectedValue = detail.TipoDocumento;
                txtNroDoc.Text = detail.NroDocumento.ToString();
            }
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
                if (!isUpdate)
                {
                    ClienteDetailDTO cliente = new ClienteDetailDTO();
                    cliente.Nombre = txtNombreCliente.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Provincia = Convert.ToInt32(cmbProvincia.SelectedValue);
                    cliente.TipoDocumento = Convert.ToInt32(cmbTipoDoc.SelectedValue);
                    cliente.NroDocumento = Convert.ToInt32(txtNroDoc.Text);
                    if (bll.Insert(cliente))
                    {
                        MessageBox.Show("El cliente fue añadido");
                        txtNombreCliente.Clear();
                        txtDireccion.Clear();
                        cmbProvincia.SelectedIndex = -1;
                        cmbTipoDoc.SelectedIndex = -1;
                        txtNroDoc.Clear();
                        this.Close();
                    }
                }
                else
                {
                    detail.Nombre = txtNombreCliente.Text;
                    detail.Direccion = txtDireccion.Text;
                    detail.Provincia = Convert.ToInt32(cmbProvincia.SelectedValue);
                    detail.TipoDocumento = Convert.ToInt32(cmbTipoDoc.SelectedValue);
                    detail.NroDocumento = Convert.ToInt32(txtNroDoc.Text);
                    if (bll.Update(detail))
                    {
                        MessageBox.Show("Cliente actualizado");
                        this.Close();
                    }
                }
            }
        }
    }
}