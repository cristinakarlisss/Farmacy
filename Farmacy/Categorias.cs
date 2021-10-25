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
    public partial class Categorias : Form
    {
        SQL_Connection conexion = new SQL_Connection();
        public Categorias()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadCategories()
        {
            conexion.LoadData(dataGridView1, "SELECT * FROM CATEGORIAS ORDER BY Nombre");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Program._isLogin == true)
            {
                if (Usuarios.UserLevel == 1)
                {
                    Create_Category create = new Create_Category();
                    create.ShowDialog();
                    LoadCategories();
                }
                else
                    MessageBox.Show("No tienes permiso de acceder a esta opción", "Alerta");
                }
            else
                MessageBox.Show("Debes iniciar sesión primero", "Alerta");
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    dataGridView1.ClearSelection();
                    Program._id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Selecciona una categoria!!", "Error");
                }
            }
        }
        private void CategoryClean()
        {
            Categoria.Id = 0;
            Categoria.Nombre = string.Empty;
        }
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program._isLogin == true)
            {
                if (Program._id > 0)
                {
                    CategoryClean();
                    conexion.GetCategory($"SELECT * FROM Categorias WHERE Id = {Program._id}");
                    if (!string.IsNullOrEmpty(Categoria.Nombre))
                    {
                        Edit_category edit = new Edit_category();
                        edit.ShowDialog();
                        LoadCategories();
                    }
                }
            }
            else
                MessageBox.Show("Debes iniciar sesión primero", "Alerta");
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program._isLogin == true)
            {
                if (Program._id > 0)
                {
                    CategoryClean();
                    conexion.GetCategory($"SELECT * FROM Categorias WHERE Id = {Program._id}");
                    if (!string.IsNullOrEmpty(Categoria.Nombre))
                    {
                        Delete delete = new Delete();
                        delete.ShowDialog();
                        if (Program._delete == true)
                        {
                            string query = $"DELETE FROM Categorias where Id = {Program._id}";
                            if (conexion.ReturnQuery(query))
                            {
                                MessageBox.Show("La categoría ha sido eliminada exitosamente", "OK");
                            }
                            else
                                MessageBox.Show("Algo ha pasado, intenta nuevamente","Error");
                        }
                    }
                    LoadCategories();
                }
            }
            else
                MessageBox.Show("Debes iniciar sesión primero");
        }
    }
}
