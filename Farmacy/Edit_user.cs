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
    public partial class Edit_user : Form
    {
        public Edit_user()
        {
            InitializeComponent();
        }
        SQL_Connection connection = new SQL_Connection();
        private void Edit_user_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            LoadNiveles();
            LoadUser();

        }
        private void LoadNiveles()
        {
            string query = "SELECT * FROM UserLevel ORDER BY Level";
            connection.ComboNiveles(comboNiveles, query);
        }
        private void UserClear()
        {
            Usuarios.Id = 0;
            Usuarios.UserName = string.Empty;
            Usuarios.Password = string.Empty;
            Usuarios.UserLevel = 0;
            
        }
        private bool LoadUser()
        {
            string user = connection.GetUser($"SELECT UserName FROM Usuarios WHERE Id = {Program._id}");
            if (user == Usuarios.UserName)//|| Usuarios.UserLevel == 1)
            {
                txtUser.Text = Usuarios.UserName;
                txtUser.Update();
                txtPassword.Text = Security.Desencripta(Usuarios.Password);
                txtPassword.Update();
                comboNiveles.SelectedValue = Usuarios.UserLevel;
                if (Usuarios.UserLevel != 1)
                    comboNiveles.Enabled = false;
                return true;
            }
            else if (Usuarios.UserLevel == 1)
            {
                Program._userId = Usuarios.Id;
                UserClear();
                string query = $"SELECT * FROM Usuarios WHERE Id={Program._id}";
                connection.GetUserData(query);
                txtUser.Text = Usuarios.UserName;
                txtUser.Update();
                txtPassword.Text = Security.Desencripta(Usuarios.Password);
                txtPassword.Update();
                comboNiveles.SelectedValue = Usuarios.UserLevel;
               
                return true;
            }
            else
            {
                MessageBox.Show("No puedes editar este usuario.");
                return false;
            }
        }
        private bool ValidateData()
        {
            if (Convert.ToInt32(comboNiveles.SelectedValue) < 0)
            {
                lblMessage.Text = "Selecciona un nivel de usuario";
                lblMessage.Update();
                lblMessage.Visible = true;
                return false;
            }
            if (txtPassword.Text == null || txtPassword.Text == "")
            {
                lblMessage.Text = "Ingresa una contraseña";
                lblMessage.Update();
                lblMessage.Visible = true;
                return false;
            }
            if (txtPassword.Text.Length != 8)
            {
                lblMessage.Text = "La contraseña debe tener 10 carácteres";
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
            if (txtPassword.Text != Security.Desencripta(Usuarios.Password) || Convert.ToInt32(comboNiveles.SelectedValue) != Usuarios.UserLevel)
            {
                string query = $"UPDATE USUARIOS SET " +
                $"Password = '{Security.Encripta(txtPassword.Text)}', UserLevel = {comboNiveles.SelectedValue} , Last_upd = '{DateTime.Now.Date}'" +
                $"WHERE Id = {Usuarios.Id}";
                if (connection.ReturnQuery(query))
                {
                    
                    MessageBox.Show("El usuario ha sido actualizado exitosamente!!");
                }
                else
                {
                   
                    MessageBox.Show("Algo ha ocurrido, intente nuevamente!!");
                }

            }
            UserClear();
            connection.GetUserData($"SELECT * FROM Usuarios WHERE Id={Program._userId}");
            return;
        }
    }
}
