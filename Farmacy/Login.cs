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
    public partial class Login : Form
    {
        public SQL_Connection connection = new SQL_Connection();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            txtPassword.Text = null;
            txtUser.Text = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Program._isLogin = false;
            Program._userName = null;
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            
            string password = string.Empty ;
            if(connection.GetPassword($"SELECT Password FROM USUARIOS WHERE UserName = '{txtUser.Text}'"))
            {
               password = Security.Desencripta(Usuarios.Password);
                if(password == txtPassword.Text)
                {
                    if (user.Length < 10)
                    {
                        if (password.Length == 8)
                        {
                            if (connection.login(user,Security.Encripta(txtPassword.Text)))
                            {
                                MessageBox.Show($"Bienvenido(a) {user}", "Bienvenido");
                                this.Hide();
                            }
                            else
                            {
                                lblMessage.Visible = true;
                                txtUser.Text = null;
                                txtPassword.Text = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Contraseña inválida. Intente nuevamente!!", "Error");
                            txtUser.Text = null;
                            txtPassword.Text = null;
                            txtUser.Update();
                            txtPassword.Update();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario inválido. Intente nuevamente!!", "Error");
                        txtUser.Text = null;
                        txtPassword.Text = null;
                        txtUser.Update();
                        txtPassword.Update();
                    }
                }
            }
        }
    }
}
