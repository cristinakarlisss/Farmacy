using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacy
{
    public partial class Ventas : Form
    {
        SQL_Connection connection = new SQL_Connection();
        
        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtVenta.Text = "0000"+Convert.ToString(connection.NoVenta()+1);
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns.Add("Codigo", "CodigoDeBarras");
            dataGridView1.Columns.Add("Product", "Producto");
            dataGridView1.Columns.Add("Qty", "Cantidad");
            dataGridView1.Columns.Add("Precio", "Precio");
            dataGridView1.Columns.Add("Total", "Total");
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
           
        }
        private void SearchProduct()
        {
            string query = $"SELECT * FROM Producto WHERE CodigoBarras = '{txtCodigo.Text}'";
            connection.GetProducts(query);
        }
        private void LoadInventary()
        {
            string query = $"SELECT A.ID,A.ProductName,A.IdCategoria,A.Stock,A.Last_upd FROM Inventario A " +
                $"inner join Producto B " +
                $"on A.ProductName = B.Nombre " +
                $"WHERE B.CodigoBarras = '{txtCodigo.Text}'";
            connection.GetInventory(query);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != null || txtCodigo.Text != "")
            {
                SearchProduct();
                LoadInventary();
                
                txtName.Text = Producto.Nombre;
                txtPrice.Text = Convert.ToString(Producto.Precio);
                txtStock.Text = Convert.ToString(Inventarios.Stock);
                numQty.Value = 1;
                decimal total = Producto.Precio * numQty.Value;
                txtTotal.Text = Convert.ToString(total);
            }
            else
                MessageBox.Show("Ingresa un código de barras");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            numQty.ResetText();
            txtTotal.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                foreach(DataGridViewRow r in dataGridView1.Rows)
                {
                    if(txtCodigo.Text == Convert.ToString(r.Cells["Codigo"].Value))
                    {
                        MessageBox.Show("Escanea un producto diferente");
                        txtCodigo.Clear();
                        txtName.Clear();
                        txtPrice.Clear();
                        txtStock.Clear();
                        numQty.Value = 0;
                        txtTotal.Clear();
                        CalculateData();
                        return;
                    }
                }
            }
            int row = dataGridView1.Rows.Count+1;
            dataGridView1.Rows.Add(row,$"{txtCodigo.Text}",$"{txtName.Text}", $"{numQty.Value}", $"{txtPrice.Text}", $"{txtTotal.Text}");
            txtCodigo.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            numQty.Value = 0;
            txtTotal.Clear();
            CalculateData();
            
        }
        double valorventa = 0;
        double subtotal = 0;
        double igv = 0;
        double total= 0;
       

        private void CalculateData()
        {
            if(dataGridView1.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    valorventa = valorventa + Convert.ToDouble(row.Cells["Total"].Value);
                    subtotal = valorventa;
                    igv = subtotal * 0.16;
                    total = subtotal + igv;
                }
                txtValorVenta.Text = Convert.ToString(valorventa);
                txtSubtotal.Text = Convert.ToString(subtotal);
                txtIgv.Text = Convert.ToString(igv);
                txtTotalPagar.Text = Convert.ToString(total);
            }
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Program._id > 0)
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                      dataGridView1.Rows.Remove(dataGridView1.Rows[item.Index]);
                }
              
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    //dataGridView1.ClearSelection();
                    Program._id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Selección no válida.", "Error");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            numQty.Value = 0;
            txtTotal.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Update();
            txtImporte.Value = 0;
            lblCambio.Clear();
            txtValorVenta.Clear();
           
            txtSubtotal.Clear();
            txtIgv.Clear();
            txtTotalPagar.Text = "";
        }

        decimal cambio = 0;
        private void btnImporte_Click(object sender, EventArgs e)
        {
            if (txtImporte.Value > 0 && txtImporte.Value >= Convert.ToDecimal(txtTotalPagar.Text))
            {
                cambio = txtImporte.Value - Convert.ToDecimal(txtTotalPagar.Text);
                txtCambio.Text = Convert.ToString(cambio);
            }
            else
                MessageBox.Show("Ingresa un importe válido");
          
        }
    }
}
