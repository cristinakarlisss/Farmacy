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
    public partial class ReporteVentas : Form
    {
        public ReporteVentas()
        {
            InitializeComponent();
        }
        SQL_Connection connection = new SQL_Connection();
        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            LoadLista();
        }

        private void LoadLista()
        {
            connection.LoadData(dataGridView1, "SELECT A.Id,A.Fecha,A.ValorVenta,A.Subtotal,A.IGV,A.Total,B.UserName FROM Ventas A " +
                "INNER JOIN Usuarios B " +
                "ON A.UserId = B.Id " +
                "ORDER BY A.Fecha");
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
        public void LoadDetalles()
        {
            connection.LoadData(dataGridView2, "SELECT A.Id, B.Nombre AS Producto,B.CodigoBarras,B.Marca,A.Precio,A.Caducidad FROM Productos_Vendidos A " +
                "INNER JOIN Producto B ON " +
                "A.IdProducto = B.Id " +
                "INNER JOIN Ventas C " +
                "ON A.IdVenta = C.Id " +
                $"WHERE A.IdVenta = {Program._id}");
            if (dataGridView2.Columns.Count > 0)
            {
                dataGridView2.Columns["Id"].Visible = false;
                foreach (DataGridViewColumn col in dataGridView2.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            dataGridView2.Update();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
                try
                {
                    dataGridView1.ClearSelection();
                    Program._id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Selecciona una venta!!", "Error");
                }
            LoadDetalles();
        }
    }
}
