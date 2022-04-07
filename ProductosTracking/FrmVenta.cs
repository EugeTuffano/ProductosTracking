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
    public partial class FrmVenta : Form
    {
        VentaBLL bll = new VentaBLL();
        VentaDTO dto = new VentaDTO();
        public VentaDetailDTO detail = new VentaDetailDTO();
        public bool isUpdate = false;
        
        public FrmVenta()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text.Trim() == "")
                MessageBox.Show("Seleccionar cliente de la tabla");
            else if (txtCantidad.Text.Trim() == "")
                MessageBox.Show("Ingresar cantidad de productos vendidos");
            else if (cmbProducto.SelectedIndex == -1)
                MessageBox.Show("Seleccionar producto");
            else
            {
                if (!isUpdate)
                {
                    VentaDetailDTO venta = new VentaDetailDTO();
                    venta.ClienteID = detail.ClienteID;
                    venta.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    venta.ProductoID = Convert.ToInt32(cmbProducto.SelectedValue);
                    if (bll.Insert(venta))
                    {
                        MessageBox.Show("La venta fue añadida");
                        txtCliente.Clear();
                        txtCantidad.Clear();
                        cmbProducto.SelectedIndex = -1;
                        //this.Close();
                    }
                }
                else
                {
                    detail.ProductoID = Convert.ToInt32(cmbProducto.SelectedValue);
                    detail.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    if (bll.Update(detail))
                    {
                        MessageBox.Show("Venta actualizada");
                        this.Close();
                    }
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ClienteID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.NombreCliente = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCliente.Text = detail.NombreCliente;
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            FillData();
            cmbProducto.DataSource = dto.Productos;
            cmbProducto.DisplayMember = "Descripcion";
            cmbProducto.ValueMember = "ProductoID";
            cmbProducto.SelectedIndex = -1;

            if (isUpdate)
            {
                
                txtCliente.Text = detail.NombreCliente;
                txtCantidad.Text = detail.Cantidad.ToString();
                cmbProducto.SelectedValue = detail.ProductoID;
            }
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            List<VentaDetailDTO> list = dto.Ventas;
            list = list.Where(x => x.NombreCliente.Contains(txtBuscarCliente.Text)).ToList();
            dataGridView1.DataSource = list;
        }

        void FillData()
        {
            dataGridView1.DataSource = dto.Clientes;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Direccion";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Provincia";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Tipo de documento";
            dataGridView1.Columns[7].HeaderText = "Numero de documento";
            
        }
    }
}
