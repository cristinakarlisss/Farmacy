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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hideSubMenu();
            hideUser();
         
        }
        private void hideSubMenu()
        {
            panelSubmenu1.Visible = false;
            //panelSubmenu2.Visible = false;
            panelSubmenu3.Visible = false;
            //if (Usuarios.UserLevel != 1)
            //{ 
            //    //panelSubmenu4.Visible = false;
            //    btnOpUsuarios.Visible = false;
            //}
            
            


        }
        private void hideMenu()
        {
            panelMenuOptions.Visible = false;
            lblAppName.Visible = false;
            label1.Visible = false;
            lblReloj.Visible = false;
            lblUser.Visible = false;
        }
        private void hideUser()
        {
            if (Program._isLogin != false)
            {
                btnLogin.Text = "Cerrar Sesión";
                btnLogin.Update();
                lblUser.Text =Usuarios.UserName;
                lblUser.Update();
                //if (Usuarios.UserLevel == 1)
                //{
                //    btnOpUsuarios.Visible = true;
                //}  
            }
            else
            {
                btnLogin.Text = "Iniciar Sesión";
                btnLogin.Update();
                panelUser.Visible = false;
            }
        }
        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void showMenu(Panel menu)
        {
            if (menu.Visible == false)
            {
                hideSubMenu();
                menu.Visible = true;
                lblAppName.Visible = true;
               
                lblReloj.Visible = true;
                hideUser();
                panelMenu.Dock = DockStyle.Left;
                panelMenu.Size = new Size(200, 605);
                panelChildForm.Size = new Size(855, 605);
            }
            else
            {
                menu.Visible = false;
                lblAppName.Visible = false;
                lblReloj.Visible = false;
                hideUser();
               // panelMenu.Size = new Size(145, 0);
                panelMenu.Size = buttonHideMenu.Size;
                panelChildForm.Size = new Size(1000, 605);
                
            }
                
        }
        private void buttonOpcion1_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSubmenu1);
        }

        private void buttonOpcion2_Click(object sender, EventArgs e)
        {
            //showSubmenu(panelSubmenu2);
        }

        private Form activeForm = null;
       

        private void buttonHideMenu_Click(object sender, EventArgs e)
        {
            showMenu(panelMenuOptions);
        }

        private void btnOpVentas_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSubmenu3);
        }

        private void btnOpUsuarios_Click(object sender, EventArgs e)
        {
            if (Program._isLogin)
            {
                if (Usuarios.UserLevel == 1)
                {
                    Program._option = "User";
                    openChildFormInPanel(new Usuario());
                }
                else
                    MessageBox.Show("No tienes permiso de acceder a esta opción");
            }
            else
                MessageBox.Show("Debes iniciar sesión primero");
            //showSubmenu(panelSubmenu4);
            //showSubmenu(panelUsuariosbotones);
        }
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        
        private void btnProductos_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Products());
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Categorias());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblReloj.Text = DateTime.Now.ToString("T");
            lblReloj.Update();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Inventario());
        }

        private void btnProdVendidos_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new ProductosVendidos());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            //if (Program._isLogin == true)
                openChildFormInPanel(new Ventas());
            //else
            //    MessageBox.Show("Debes iniciar sesión primero");
            //openChildFormInPanel(new Ventas());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (Program._isLogin)
            {
                if (Usuarios.UserLevel == 1)
                {
                    Program._option = "User";
                    openChildFormInPanel(new Usuario());
                }
                else
                    MessageBox.Show("No tienes permiso de acceder a esta opción");
            }
            else
                MessageBox.Show("Debes iniciar sesión primero");
        }

        //private void btnUserLevel_Click(object sender, EventArgs e)
        //{
        //    openChildFormInPanel(new UserLevel());
        //}

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(Program._isLogin == false)
            {
                Login login = new Login();
                login.ShowDialog();
                if(Program._isLogin == true)
                {
                    hideUser();
                    panelUser.Visible = true;
                    hideSubMenu();

                }

            }
            else if(Program._isLogin == true)
            {
                Program._isLogin = false;
                Program._userName = null;
                Program._userId = 0;
                UserClear();
                hideUser();
                hideSubMenu();
            }
        }

        private void UserClear()
        {
            Usuarios.Id = 0;
            Usuarios.UserName = string.Empty;
            Usuarios.Password = string.Empty;
            Usuarios.UserLevel = 0;
            if(activeForm != null)
            activeForm.Close();
        }

        private void btnReporteVentas_Click(object sender, EventArgs e)
        {
            if (Program._isLogin)
            {
                
                    openChildFormInPanel(new ReporteVentas());
            }
            else
                    MessageBox.Show("Debes iniciar sesión primero");
        }
    }
}
