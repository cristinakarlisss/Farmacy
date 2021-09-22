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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
            LoadInventary();
        }
        public SQL_Connection connection = new SQL_Connection();
        public void LoadInventary()
        {
            connection.LoadData(dataGridView1, "SELECT A.Id,A.ProductName as Producto,B.Nombre as Categoría,A.Stock,A.Last_upd FROM Inventario A " +
                "INNER JOIN Categorias B ON A.IdCategoria = B.Id");
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

        private void Inventario_Load(object sender, EventArgs e)
        {

        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            connection.LoadData(dataGridView1, "SELECT A.Id,A.ProductName as Producto,B.Nombre as Categoría,A.Stock,A.Last_upd FROM Inventario A " +
               "INNER JOIN Categorias B ON A.IdCategoria = B.Id " +
               $"WHERE A.ProductName LIKE '%{txtProducto.Text}%'");
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

        private void Inventario_Paint(object sender, PaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToInt32(row.Cells["Stock"].Value) == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.White;
                    row.DefaultCellStyle.SelectionForeColor = Color.Red;
                }
                else if(Convert.ToInt32(row.Cells["Stock"].Value) <10)
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.White;
                    row.DefaultCellStyle.SelectionForeColor = Color.Orange;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.White;
                    row.DefaultCellStyle.SelectionForeColor = Color.Green;
                }
            }
        }
    }
}
