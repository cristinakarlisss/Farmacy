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
    public partial class Edit_product : Form
    {
        SQL_Connection connection = new SQL_Connection();
        public Edit_product()
        {
            InitializeComponent();
        }
        public void LoadCategorias()
        {
            connection.ComboCategorias(comboCategoria, "SELECT Id,Nombre FROM CATEGORIAS ORDER BY Nombre");

        }
        private void Edit_product_Load(object sender, EventArgs e)
        {
            LoadCategorias();
            lblMessage.Text = null;
            lblMessage.Visible = false;
            txtCodigo.Text = Producto.CodigoBarras;
            txtNombre.Text = Producto.Nombre;
            comboCategoria.SelectedValue = Producto.IdCategoria;
            numPrecio.Value = Producto.Precio;
            txtMarca.Text = Producto.Marca;
            pickerCaducidad.Value = Producto.Caducidad;
            txtDescripcion.Text = Producto.Descripcion;
        }
        private bool ValidateData()
        {


            if (txtCodigo.Text == null || txtCodigo.Text == "")
            {

                lblMessage.Text = "Ingresa el código de barras.";
                lblMessage.Update();
                lblMessage.Visible = true;
                txtCodigo.Focus();
                return false;
            }
            else if (txtCodigo.Text.Length > 50)
            {

                lblMessage.Text = "Código de barras inválido, no debe ser mayor a 50 dígitos.";
                lblMessage.Update();
                lblMessage.Visible = true;
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Text == null || txtNombre.Text == "")
            {

                lblMessage.Text = "ingresa el nombre del producto.";
                lblMessage.Update();
                lblMessage.Visible = true;
                txtNombre.Focus();
                return false;
            }
            else if (txtNombre.Text.Length > 50)
            {

                lblMessage.Text = "Nombre de producto inválido, no debe ser mayor a 50 dígitos.";
                lblMessage.Update();
                lblMessage.Visible = true;
                txtNombre.Focus();
                return false;
            }
            if (Convert.ToInt32(comboCategoria.SelectedValue) <= 0)
            {

                lblMessage.Text = "Selecciona una categoría.";
                lblMessage.Update();
                lblMessage.Visible = true;
                comboCategoria.Focus();
                return false;
            }
            if (numPrecio.Value < 0 || numPrecio.Value == 0)
            {

                lblMessage.Text = "Ingresa un precio válido.";
                lblMessage.Update();
                lblMessage.Visible = true;
                comboCategoria.Focus();
                return false;
            }
            if (txtMarca.Text == null || txtMarca.Text == "")
            {

                lblMessage.Text = "Ingresa la marca/patente del producto.";
                lblMessage.Update();
                lblMessage.Visible = true;
                txtMarca.Focus();
                return false;
            }
            if (pickerCaducidad.Value < DateTime.Now.Date)
            {

                lblMessage.Text = "Ingresa una fecha de caducidad válida.";
                lblMessage.Update();
                lblMessage.Visible = true;
                pickerCaducidad.Focus();
                return false;
            }
            if (txtDescripcion.Text.Length > 300)
            {

                lblMessage.Text = "La descripción del producto no puede tener más de 300 cáracteres.";
                lblMessage.Update();
                lblMessage.Visible = true;
                txtDescripcion.Focus();
                return false;
            }
            //if (connection.ReturnQuery($"Select * FROM Producto WHERE CodigoBarras = '{txtCodigo.Text}'"))
            //{
            //    lblMessage.Text = "El producto ya existe.";
            //    lblMessage.Update();
            //    lblMessage.Visible = true;
            //    txtCodigo.Focus();
            //    return false;
            //}
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateData();
            if (!isValid)
                return;

            string query = $"UPDATE Producto SET " +
                $"CodigoBarras = '{txtCodigo.Text}', " +
                $"Nombre = '{txtNombre.Text}', " +
                $"IdCategoria = {comboCategoria.SelectedValue}, " +
                $"Precio = {numPrecio.Value} , " +
                $"Marca = '{txtMarca.Text}', " +
                $"Caducidad = '{pickerCaducidad.Value}', " +
                $"Descripcion = '{txtDescripcion.Text}' " +
                $"WHERE Id = {Program._id}";
            if (connection.ReturnQuery(query))
            {
                MessageBox.Show("El producto fue editado exitosamente!!", "Ok");
            }
            else
            {
                MessageBox.Show("Algo ha sucedido. Revisa tus datos e intenta de nuevo!!", "Error");
            }
        }
    }
}
