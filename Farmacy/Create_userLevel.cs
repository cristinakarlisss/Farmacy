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
    public partial class Create_userLevel : Form
    {
        public Create_userLevel()
        {
            InitializeComponent();
        }
        SQL_Connection connection = new SQL_Connection();
        private void Create_userLevel_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        private bool ValidateData()
        {
            if(txtNivel.Text == null || txtNivel.Text == "")
            {
                lblMessage.Text = "Ingresa el nombre del nivel";
                lblMessage.Update();
                lblMessage.Visible = true;
                return false;
            }
            if(txtNivel.Text.Length > 5)
            {
                lblMessage.Text = "El nivel no puede tener más de 5 carácteres";
                lblMessage.Update();
                lblMessage.Visible = true;
                return false;
            }
            if(connection.ValidateData($"SELECT * FROM UserLevel WHERE Level = '{txtNivel.Text}'"))
            {
                lblMessage.Text = "El nivel ya existe.";
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
            string query = "INSERT INTO UserLevel (Level) " +
                $"values ('{txtNivel.Text}') ";
            if (connection.ReturnQuery(query))
            {
                MessageBox.Show("El nivel se ha agregado correctamente");
                txtNivel.Clear();
            }
            else
            {
                MessageBox.Show("Algo ha sucedido, intente de nuevo!!");
            }
            return;
        }
    }
}
