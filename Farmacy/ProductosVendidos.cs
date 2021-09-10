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
    public partial class ProductosVendidos : Form
    {
        public ProductosVendidos()
        {
            InitializeComponent();
            LoadProductosVendidos();
        }

        private void ProductosVendidos_Load(object sender, EventArgs e)
        {

        }
        SQL_Connection connection = new SQL_Connection();
        private void LoadProductosVendidos()
        {
            connection.LoadData(dataGridView1, "SELECT A.Id,B.CodigoBarras,B.Nombre, C.Fecha, D.UserName FROM Productos_Vendidos A " +
                "INNER JOIN Producto B " +
                "ON A.IdProducto = B.Id " +
                "INNER JOIN Ventas C " +
                "ON A.IdVenta = C.Id " +
                "INNER JOIN Usuarios D " +
                "ON A.IdUsuario = D.Id " +
                "ORDER BY A.FECHA DESC");
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

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            connection.LoadData(dataGridView1, "SELECT A.Id,B.CodigoBarras,B.Nombre, C.Fecha, D.UserName FROM Productos_Vendidos A " +
                "INNER JOIN Producto B " +
                "ON A.IdProducto = B.Id " +
                "INNER JOIN Ventas C " +
                "ON A.IdVenta = C.Id " +
                "INNER JOIN Usuarios D " +
                "ON A.IdUsuario = D.Id " +
                $"WHERE B.Nombre LIKE'%{txtProducto.Text}%' " +
                "ORDER BY A.Fecha DESC");
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
    }
}
