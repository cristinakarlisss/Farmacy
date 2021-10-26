using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data;

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
            txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
            txtVenta.Text = Convert.ToString(connection.NoVenta() + 1);
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns.Add("Codigo", "CodigoDeBarras");
            dataGridView1.Columns.Add("Product", "Producto");
            dataGridView1.Columns.Add("Qty", "Cantidad");
            dataGridView1.Columns.Add("Precio", "Precio");
            dataGridView1.Columns.Add("Total", "Total");
            btnAdd.Enabled = false;
            btnRecibo.Enabled = false;
            btnImporte.Enabled = false;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }
        private bool SearchProduct(string codigo)
        {
            string query = $"SELECT * FROM Producto WHERE CodigoBarras = '{codigo}'";
            if (connection.GetProducts(query))
            {

                return true;
            }
            else
                return false;
        }
        private void LoadInventary(string codigo)
        {
            string query = $"SELECT A.ID,A.ProductName,A.IdCategoria,A.Stock,A.Last_upd FROM Inventario A " +
                $"inner join Producto B " +
                $"on A.ProductName = B.Nombre " +
                $"WHERE B.CodigoBarras = '{codigo}'";
            connection.GetInventory(query);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            if (txtCodigo.Text != null && txtCodigo.Text != "")
            {

                if (SearchProduct(txtCodigo.Text))
                {
                    string query = $"SELECT * FROM Productos_Vendidos WHERE IdProducto = {Producto.Id}";
                    if (!connection.BuscarProductoVendido(query))
                    {
                        LoadInventary(txtCodigo.Text);
                        if (Producto.Caducidad >= DateTime.Now)
                        {
                            if (Producto.Caducidad <= DateTime.Now.AddDays(15))
                            {
                                MessageBox.Show($"La fecha de caducidad del producto es {Producto.Caducidad.ToString("dd/MM/yyyy")}","ALERTA");

                            }
                            
                                txtName.Text = Producto.Nombre;
                                txtPrice.Text = Convert.ToString(Producto.Precio);
                                txtStock.Text = Convert.ToString(Inventarios.Stock);
                                numQty.Value = 1;
                                decimal total = Producto.Precio * numQty.Value;
                                txtTotal.Text = Convert.ToString(total);
                                btnAdd.Enabled = true;
                        }
                       
                        else
                        {
                            MessageBox.Show("No puedes vender este producto por que esta caducado");
                            txtCodigo.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este producto ya fue vendido");
                        txtCodigo.Clear();
                    }
                        
                }
                else
                {
                    MessageBox.Show("Producto no encontrado");
                    txtCodigo.Clear();
                    txtCodigo.Focus();
                }
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
            if (txtCodigo.Text != null && txtCodigo.Text != "")
            {
                if (Inventarios.Stock > 0)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow r in dataGridView1.Rows)
                        {
                            if (txtCodigo.Text == Convert.ToString(r.Cells["Codigo"].Value))
                            {
                                MessageBox.Show("Escanea un producto diferente");
                                txtCodigo.Clear();
                                txtName.Clear();
                                txtPrice.Clear();
                                txtStock.Clear();
                                numQty.Value = 0;
                                txtTotal.Clear();
                                //CalculateData();
                                btnAdd.Enabled = false;
                                btnImporte.Enabled = false;
                                btnRecibo.Enabled = false;
                                return;
                            }
                        }
                    }
                    int row = dataGridView1.Rows.Count + 1;

                    dataGridView1.Rows.Add(row, $"{txtCodigo.Text}", $"{txtName.Text}", $"{numQty.Value}", $"{txtPrice.Text}", $"{txtTotal.Text}");
                    txtCodigo.Clear();
                    txtName.Clear();
                    txtPrice.Clear();
                    txtStock.Clear();
                    numQty.Value = 0;
                    txtTotal.Clear();
                    CalculateData();
                    btnAdd.Enabled = false;
                    btnImporte.Enabled = true;
                    btnRecibo.Enabled = false;
                }

            }
            else
                MessageBox.Show("Ingresa un producto");


        }



        private void CalculateData()
        {
            double valorventa = 0;
            double subtotal = 0;
            double igv = 0;
            double total = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
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
            else
            {
                txtValorVenta.Clear();
                txtSubtotal.Clear();
                txtIgv.Clear();
                txtTotalPagar.Text = "";
                txtImporte.Value = 0;
                txtCambio.Text = "";
            }
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program._id > 0)
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[item.Index]);
                }
                CalculateData();

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
            txtImporte.Value = 0;
            txtCambio.Text = "";
            txtSubtotal.Clear();
            txtIgv.Clear();
            txtTotalPagar.Text = "";
        }

        decimal cambio = 0;
        private void btnImporte_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (txtImporte.Value > 0 && txtImporte.Value >= Convert.ToDecimal(txtTotalPagar.Text))
                {
                    cambio = txtImporte.Value - Convert.ToDecimal(txtTotalPagar.Text);
                    txtCambio.Text = Convert.ToString(cambio);
                    btnAdd.Enabled = false;
                    FinishSale();
                    btnNuevo.Enabled = true;
                    btnRecibo.Enabled = true;
                }
                else
                    MessageBox.Show("Ingresa un importe válido");
            }

        }

        private void txtCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
                e.IsInputKey = true;
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                Search();
            }
        }

        private void FinishSale()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string fecha = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
                string query = $"INSERT INTO Ventas (Cantidad,Fecha,UserId,ValorVenta,Subtotal,IGV,Total) " +
                    $"Values({dataGridView1.Rows.Count},'{fecha}',{Usuarios.Id},{txtValorVenta.Text},{txtSubtotal.Text},{txtIgv.Text},{txtTotalPagar.Text})";
                if (connection.ReturnQuery(query))
                {
                    int venta = connection.GetVenta(dataGridView1.Rows.Count, fecha, Usuarios.Id);
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        if (SearchProduct(Convert.ToString(r.Cells["Codigo"].Value)))
                        {
                            string query2 = $"INSERT INTO Productos_Vendidos (IdProducto,Precio,Caducidad,Marca,IdVenta,Fecha,IdUsuario) " +
                                $"Values({Producto.Id},{Producto.Precio},'{Producto.Caducidad}','{Producto.Marca}',{venta},'{fecha}',{Usuarios.Id})";
                            connection.ReturnQuery(query2);
                        }
                        LoadInventary(Producto.CodigoBarras);
                        string query3 = $"UPDATE Inventario SET " +
                            $"Stock = {Inventarios.Stock - 1}, " +
                            $"Last_upd = '{fecha}'" +
                            $"WHERE Id = {Inventarios.Id}";
                        connection.ReturnQuery(query3);
                    }
                    MessageBox.Show("La compra ha sido terminada exitosamente");
                }

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:m tt");
            txtVenta.Text = Convert.ToString(connection.NoVenta() + 1);

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
            txtImporte.Value = 0;
            txtCambio.Text = "";
            txtSubtotal.Clear();
            txtIgv.Clear();
            txtTotalPagar.Text = "";

            btnAdd.Enabled = false;
        }

        private void btnRecibo_Click(object sender, EventArgs e)
        {
            Program._importe = txtImporte.Value;
            Print_Preview preview = new Print_Preview();
            preview.ShowDialog();
        }

    }
}
