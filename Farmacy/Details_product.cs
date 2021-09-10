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
    public partial class Details_product : Form
    {
        SQL_Connection connection = new SQL_Connection();
        public Details_product()
        {
            InitializeComponent();
        }
        public void LoadCategorias()
        {
            connection.ComboCategorias(comboCategoria, "SELECT Id,Nombre FROM CATEGORIAS ORDER BY Nombre");

        }
        private void Details_product_Load(object sender, EventArgs e)
        {
            LoadCategorias();
            txtCodigo.Text = Producto.CodigoBarras;
            txtCodigo.Enabled = false;
            txtNombre.Text = Producto.Nombre;
            txtNombre.Enabled = false;
            comboCategoria.SelectedValue = Producto.IdCategoria;
            comboCategoria.Enabled = false;
            numPrecio.Value = Producto.Precio;
            numPrecio.Enabled = false;
            txtMarca.Text = Producto.Marca;
            txtMarca.Enabled = false;
            pickerCaducidad.Value = Producto.Caducidad;
            pickerCaducidad.Enabled = false;
            txtDescripcion.Text = Producto.Descripcion;
            txtDescripcion.Enabled = false;
        }
    }
}
