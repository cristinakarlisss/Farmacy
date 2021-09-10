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
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
            btnAddLevel.Visible = false;
            LoadUsuarios();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }
        SQL_Connection connection = new SQL_Connection();
        private void LoadUsuarios()
        {
            btnAddU.Visible = false;
            btnAddU.Visible = true;
            connection.LoadData(dataGridView1, "SELECT A.Id, A.UserName, B.Level, A.Last_Upd FROM Usuarios A " +
                "INNER JOIN UserLevel B " +
                "ON A.UserLevel = B.Id");
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["Id"].Visible = false;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

            }
            dataGridView1.Update();
        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //aplicar el abrir formulario y desde ahi hacer todo.
            //intentar de la manera normal
            Program._option = "User";
            LoadUsuarios();
        }

        private void nivelesDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program._option = "Level";
            LoadNivelUsuarios();
        }

        private void LoadNivelUsuarios()
        {
            btnAddLevel.Visible = true;
            btnAddU.Visible = false;
            connection.LoadData(dataGridView1, "SELECT * FROM UserLevel");
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["Id"].Visible = false;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

            }
            dataGridView1.Update();
        }

        private void btnAddLevel_Click(object sender, EventArgs e)
        {
            Create_userLevel level = new Create_userLevel();
            level.ShowDialog();
            LoadNivelUsuarios();
        }

        private void btnAddU_Click(object sender, EventArgs e)
        {
            Create_user user = new Create_user();
            user.ShowDialog();
            LoadUsuarios();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //dataGridView1.ClearSelection();
                Program._id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selección incorrecta!!", "Error");
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program._isLogin == true)
            {
                if (Program._option == "User")
                {
                    if (Program._id > 0)
                    {

                        Edit_user user = new Edit_user();
                        user.ShowDialog();
                        LoadUsuarios();
                    }
                }
                else if (Program._option == "Level")
                {
                    if (Program._id > 0)
                    {
                        Edit_userLevel level = new Edit_userLevel();
                        level.ShowDialog();
                        LoadNivelUsuarios();
                    }
                }
            }
            else
                MessageBox.Show("Debes iniciar sesión primero");
            
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program._option == "User")
            {

            }
            else if (Program._option == "Level")
            {

            }
        }
    }
}
