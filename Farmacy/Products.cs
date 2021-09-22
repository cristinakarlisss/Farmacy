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
    public partial class Products : Form
    {
        SQL_Connection connection = new SQL_Connection();
        public Products()
        {
            InitializeComponent();
        }
       
        private void Products_Load(object sender, EventArgs e)
        {
            LoadProducts();
            if (cad != 0 && prox != 0)
            {
                MessageBox.Show($"Exiten {cad} productos caducados y {prox} productos proximos a caducar!!", "ATENCIÓN");
            }
            else if (cad != 0 && prox == 0)
            {
                MessageBox.Show($"Exiten {cad} productos caducados!!", "ATENCIÓN");
            }
            else if (cad == 0 && prox != 0)
            {
                MessageBox.Show($"Exiten {prox} productos proximos a caducar!!", "ATENCIÓN");
            }
        }
        
        private void LoadProducts()
        {
            try
            {
                connection.LoadData(dataGridView1, "SELECT A.Id,A.CodigoBarras,A.Nombre,B.Nombre As Categoria,A.Precio,A.Marca,A.Caducidad FROM Producto A " +
                    "INNER JOIN Categorias B " +
                    "ON A.IdCategoria = B.Id " +
                    "WHERE A.Id not in (SELECT IdProducto FROM Productos_Vendidos) " +
                    "ORDER BY A.Caducidad");
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["Id"].Visible = false;
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                   
                }
                dataGridView1.Update();
            }
            catch(Exception ex)
            {
              
            }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                connection.LoadData(dataGridView1, "SELECT A.Id,A.CodigoBarras,A.Nombre,B.Nombre As Categoria,A.Precio,A.Marca,A.Caducidad FROM Producto A " +
                "INNER JOIN Categorias B " +
                "ON A.IdCategoria = B.Id " +
                $"WHERE A.Nombre LIKE '%{txtProducto.Text}%' ORDER BY A.Nombre");
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["Id"].Visible = false;
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                }
                dataGridView1.Update();
            }
            catch(Exception ex)
            {
                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Program._isLogin == true)
            {
                Create_Product create = new Create_Product();
                create.ShowDialog();
            }
            else
                MessageBox.Show("Debes iniciar sesión primero.","Atención");
            LoadProducts();
        }
        //private void comboCategoria_Click(object sender, EventArgs e)
        //{
        //    LoadCategorias();
        //}

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                try
                {
                    dataGridView1.ClearSelection();
                    Program._id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                }
                catch( Exception ex)
                {
                    MessageBox.Show("Selecciona un producto!!","Error");
                }
            }
        }
        private void ProductClear()
        {
            Producto.Id = 0;
            Producto.CodigoBarras = string.Empty;
            Producto.Nombre = string.Empty;
            Producto.Marca = string.Empty;
            Producto.Descripcion = string.Empty;
            Producto.IdCategoria = 0;
            Producto.Precio = 0;
            Producto.Caducidad = default;
        }
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Program._isLogin == true)
            {
                if(Program._id > 0)
                {
                    ProductClear();
                    connection.GetProducts($"SELECT * FROM Producto WHERE Id = {Program._id}");
                    if (!string.IsNullOrEmpty(Producto.CodigoBarras))
                    {
                        Edit_product edit = new Edit_product();
                        edit.ShowDialog();
                        LoadProducts();
                    }
                }
            }
            else
                MessageBox.Show("Debes iniciar sesión primero.", "Atención");
            LoadProducts();


        }

        private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program._id > 0)
            {
                ProductClear();
                connection.GetProducts($"SELECT * FROM Producto WHERE Id = {Program._id}");
                if (!string.IsNullOrEmpty(Producto.CodigoBarras))
                {
                    Details_product details = new Details_product();
                    details.ShowDialog();
                    LoadProducts();
                }
            }
           
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Program._isLogin == true)
            {
                if (Program._id > 0)
                {
                    ProductClear();
                    connection.GetProducts($"SELECT * FROM Producto WHERE Id = {Program._id}");
                    if (!string.IsNullOrEmpty(Producto.CodigoBarras))
                    {
                        Delete delete = new Delete();
                        delete.ShowDialog();
                        if (Program._delete == true)
                        {
                            string query = $"DELETE FROM Producto WHERE Id = '{Program._id}'";
                            if (connection.ReturnQuery(query))
                            {
                                MessageBox.Show("El producto ha sido eliminado exitosamente!", "Ok");
                            }
                            else
                            {
                                MessageBox.Show("Algo ha salido mal, intente nuevamente", "Atención");
                            }
                        }
                    }
                   
                }
            }
            else
                MessageBox.Show("Debes iniciar sesión primero.", "Atención");
            LoadProducts();

        }

        private void dataGridView1_CellStyleChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
            int cad = 0;
            int prox = 0;
        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            cad = 0;
            prox = 0;
            DateTime date = DateTime.Now;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToDateTime(row.Cells["Caducidad"].Value) <= DateTime.Now)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.White;
                    row.DefaultCellStyle.SelectionForeColor = Color.Red;
                    cad = cad + 1;
                }
                else if(Convert.ToDateTime(row.Cells["Caducidad"].Value) <= date.AddDays(15))
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.White;
                    row.DefaultCellStyle.SelectionForeColor = Color.Orange;
                    prox = prox + 1;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.White;
                    row.DefaultCellStyle.SelectionForeColor = Color.Green;
                }

            }
            dataGridView1.Update();
            
        }
    }
}
