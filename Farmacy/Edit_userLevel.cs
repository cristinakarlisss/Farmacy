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
    public partial class Edit_userLevel : Form
    {
        public Edit_userLevel()
        {
            InitializeComponent();
        }
        SQL_Connection connection = new SQL_Connection();
        private void Edit_userLevel_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            GetNivel();
        }
        private void GetNivel() 
        {
            string query = $"SELECT * FROM UserLevel WHERE Id= {Program._id}";
            if (connection.GetUserLevel(query))
            {
                txtNivel.Text = Levels.Level;
                txtNivel.Focus();
            }
        }

        private bool ValidateData()
        {
            if(txtNivel.Text == null || txtNivel.Text == "")
            {
                MessageBox.Show("Ingresa el nombre del nivel!!","Alerta");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateData();
            if (!isValid)
                return;

            if (txtNivel.Text != Levels.Level)
            {
                string query = $"UPDATE UserLevel SET "  +
                    $"Level = '{txtNivel.Text}' WHERE Id = {Levels.Id}";
                if (connection.ReturnQuery(query))
                {
                    MessageBox.Show("El nivel fue editado exitosamente!!", "OK");
                }
                else
                    MessageBox.Show("Algo ha sucedido. Intenta nuevamente.", "Error");
            }
            else
                MessageBox.Show("Cambios guardados!!", "OK");
        }
    }
}
