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
    public partial class Edit_category : Form
    {
        public Edit_category()
        {
            InitializeComponent();
        }
        SQL_Connection connection = new SQL_Connection();
        private void Edit_category_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            lblMessage.Text = null;
            lblMessage.Visible = false;
            txtNombre.Text = Categoria.Nombre;
        }
        private bool ValidateData()
        {
            if (txtNombre.Text == null || txtNombre.Text == "")
            {
                lblMessage.Text = "Ingresa el nombre de la categoría.";
                lblMessage.Update();
                lblMessage.Visible = true;
                txtNombre.Focus();
                return false;
            }
            
            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateData();
            if (!isValid)
                return;
            string query = $"UPDATE Categorias SET " +
                $"Nombre = '{txtNombre.Text}' " +
                $"WHERE Id = {Program._id}";
            if (connection.ReturnQuery(query))
            {
                MessageBox.Show("La categoría ha sido editada éxitosamente");
            }
            else
            {
                MessageBox.Show("No se pudo editar. Intenta nuevamente");
            }
        }
    }
}
