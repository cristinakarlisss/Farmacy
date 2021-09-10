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
    public partial class Create_Category : Form
    {
        public Create_Category()
        {
            InitializeComponent();
        }
        SQL_Connection connection = new SQL_Connection();
        private void Create_Category_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
                bool isValid = ValidateData();
                if (!isValid)
                    return;
                string query = "INSERT INTO Categorias (Nombre) " +
                    $"Values ('{txtNombre.Text}')";
                if (connection.ReturnQuery(query))
                {
                    MessageBox.Show("La categoría ha sido creada correctamente");
                }
                else
                {
                    MessageBox.Show("Datos inválidos. Intente nuevamenre!");
                }
            txtNombre.Clear();
            return; 
        }
        private bool ValidateData()
        {
            if(txtNombre.Text == null || txtNombre.Text == "")
            {
                lblMessage.Text = "Ingresa el nombre de la categoría.";
                lblMessage.Update();
                lblMessage.Visible = true;
                txtNombre.Focus();
                return false;
            }
            if (connection.ValidateData($"select * from Categorias where Nombre ='{txtNombre.Text}'"))
            {
                lblMessage.Text = $"La categoría {txtNombre.Text} ya existe.";
                lblMessage.Update();
                lblMessage.Visible = true;
                txtNombre.Focus();
                return false;
            }
            return true;

        }
    }
}
