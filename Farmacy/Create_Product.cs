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
    public partial class Create_Product : Form
    {
        SQL_Connection connection = new SQL_Connection();
        public Create_Product()
        {
            InitializeComponent();
            lblMessage.Visible = false;
            LoadCategorias();
            
        }
        public void LoadCategorias()
        {
            connection.ComboCategorias(comboCategoria, "SELECT Id,Nombre FROM CATEGORIAS ORDER BY Nombre");
        }
        private bool ValidateData()
        {
          
            
            if(txtCodigo.Text == null || txtCodigo.Text == "")
            {
              
                lblMessage.Text = "Ingresa el código de barras.";
                lblMessage.Update();
                lblMessage.Visible = true;
                txtCodigo.Focus(); 
                return false;
            }
            else if(txtCodigo.Text.Length > 50)
            {
               
                lblMessage.Text = "Código de barras inválido, no debe ser mayor a 50 dígitos.";
                lblMessage.Update();
                lblMessage.Visible = true;
                txtCodigo.Focus();
                return false;
            }
            if(txtNombre.Text == null || txtNombre.Text == "")
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
            if(Convert.ToInt32(comboCategoria.SelectedValue) <= 0)
            {
              
                lblMessage.Text = "Selecciona una categoría.";
                lblMessage.Update();
                lblMessage.Visible = true;
                comboCategoria.Focus(); 
                return false;
            }
            if(numPrecio.Value < 0 || numPrecio.Value == 0)
            {
              
                lblMessage.Text = "Ingresa un precio válido.";
                lblMessage.Update();
                lblMessage.Visible = true;
                comboCategoria.Focus(); 
                return false;
            }
            if(txtMarca.Text == null || txtMarca.Text == "")
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
            if(txtDescripcion.Text.Length > 300)
            {
              
                lblMessage.Text = "La descripción del producto no puede tener más de 300 cáracteres.";
                lblMessage.Update();
                lblMessage.Visible = true;
                txtDescripcion.Focus(); 
                return false;
            }
            if (connection.ValidateData($"Select * FROM Producto WHERE CodigoBarras = '{txtCodigo.Text}'"))
            {
                lblMessage.Text = "El producto ya existe.";
                lblMessage.Update();
                lblMessage.Visible = true;
                txtCodigo.Focus();
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateData();
            if (!isValid)
                return;
            
            string query = $"INSERT INTO PRODUCTO (CodigoBarras,Nombre,IdCategoria,Precio,Marca,Caducidad,Descripcion) " +
                $"VALUES ('{txtCodigo.Text}','{txtNombre.Text}','{comboCategoria.SelectedValue}','{numPrecio.Value}','{txtMarca.Text}','{pickerCaducidad.Value}','{txtDescripcion.Text}') ";
            if (connection.ReturnQuery(query))
            {
                MessageBox.Show("Se ha añadido correctamente el producto!!", "OK");
                string query2 = $"SELECT A.Id,A.ProductName,B.Nombre,A.Stock,A.Last_upd FROM Inventario A " +
                    $"INNER JOIN Categorias B " +
                    $"ON A.IdCategoria = B.Id " +
                    $"WHERE A.ProductName = '{txtNombre.Text}' and IdCategoria = {comboCategoria.SelectedValue}";
                if (connection.ValidateData(query2))
                {
                    string query3 = $"SELECT * FROM Inventario WHERE ProductName = '{txtNombre.Text}' and IdCategoria = {comboCategoria.SelectedValue}";
                    //getinventario //Aumentar stock
                    connection.GetInventory(query3);
                    if(Inventarios.Id > 0)
                    {
                        string query4 = "UPDATE Inventario " +
                            $"SET Stock = {Inventarios.Stock}+1," +
                            $"Last_upd = '{DateTime.Now.Date}' " +
                            $"WHERE Id = {Inventarios.Id}";
                        if (connection.ReturnQuery(query4))
                        {
                            MessageBox.Show("Inventario actualizado!", "Ok");
                        }
                        else
                        {
                            MessageBox.Show("Error tratando de actualizar inventario.", "Error");
                        }
                    }
                   
                }
                else
                {
                    //getinventatio
                    //insertar en inventario
                    string query5 = $"INSERT INTO Inventario (ProductName,IdCategoria,Stock,Last_upd) " +
                        $"VALUES ('{txtNombre.Text}',{comboCategoria.SelectedValue},1,'{DateTime.Now.Date}')";
                    if (connection.ReturnQuery(query5))
                    {
                        MessageBox.Show("Inventario actualizado!");
                    }
                    else
                    {
                        MessageBox.Show("Error tratando de actualizar inventario.");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Datos inválidos. Intenta nuevamente!", "Error");
            }
            txtNombre.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            numPrecio.ResetText();
            LoadCategorias();
            pickerCaducidad.ResetText();
            return;
        }

        private void Create_Product_Load(object sender, EventArgs e)
        {

        }
    }
}
