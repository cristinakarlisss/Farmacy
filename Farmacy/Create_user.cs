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
    public partial class Create_user : Form
    {
        SQL_Connection connection = new SQL_Connection();
        public Create_user()
        {
            InitializeComponent();
            LoadNiveles();
        }

        private void Create_user_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        private void LoadNiveles()
        {
            string query = "SELECT * FROM UserLevel ORDER BY Level";
            connection.ComboNiveles(comboNiveles, query);
        }

        private bool ValidateData()
        {
            if(txtUser.Text == null || txtUser.Text == "")
            {
                lblMessage.Text = "Ingresa un nombre de usuario";
                lblMessage.Update();
                lblMessage.Visible = true;
                return false;
            }
            if(txtUser.Text.Length > 10)
            {
                lblMessage.Text = "El usuario no debe contener más de 10 carácteres";
                lblMessage.Update();
                lblMessage.Visible = true;
                return false;
            }
            if(Convert.ToInt32(comboNiveles.SelectedValue) < 0)
            {
                lblMessage.Text = "Selecciona un nivel de usuario";
                lblMessage.Update();
                lblMessage.Visible = true;
                return false;
            }
            if(txtPassword.Text == null || txtPassword.Text == "")
            {
                lblMessage.Text = "Ingresa una contraseña";
                lblMessage.Update();
                lblMessage.Visible = true;
                return false;
            }
            if(txtPassword.Text.Length != 8)
            {
                lblMessage.Text = "La contraseña debe tener 10 carácteres";
                lblMessage.Update();
                lblMessage.Visible = true;
                return false;
            }
            if(connection.ValidateData($"SELECT * FROM Usuarios WHERE UserName = '{txtUser.Text}'"))
            {
                lblMessage.Text = "El usuario ya existe. Intente con uno diferente";
                lblMessage.Update();
                lblMessage.Visible = true;
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateData();
            if (!isValid)
                return;

            string password = Security.Encripta(txtPassword.Text);

            string query = "INSERT INTO Usuarios(UserName,Password,Last_upd,UserLevel) VALUES " +
                $"('{txtUser.Text}','{password}','{DateTime.Now.Date}',{comboNiveles.SelectedValue})";

            if (connection.ReturnQuery(query))
            {
                MessageBox.Show("El usuario ha sido creado correctamente");
                txtUser.Clear();
                txtPassword.Clear();
                LoadNiveles();
            }
            else
            {
                MessageBox.Show("Algo ha sucedido, intente nuevamente");
                txtUser.Focus();
            }
            return;
        }
    }
}
