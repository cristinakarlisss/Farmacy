using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacy
{
    public class SQL_Connection
    {
        public string conexion = "Password=tooling;Persist Security Info=True;User ID=tooling;Initial Catalog=OnSale2;Data Source = 10.20.254.44";

        public void SQLQuery(string query)
        {
            SqlConnection cnn = new SqlConnection(conexion);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            try
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();

                cnn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
            }
            catch(Exception ex)
            {
                cmd.Dispose();
                cnn.Close();
            }
        }

        public void LoadData(DataGridView dataGrid, string query)
        {
            using (SqlConnection cnn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                try
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();

                    cnn.Open();

                    dataGrid.DataSource = null;
                    if (da.Fill(dataSet, "logn") > 0)
                    {
                        BindingSource bindingSource = new BindingSource(dataSet.Tables[0], null);
                        dataGrid.DataSource = bindingSource;

                        if (dataGrid.DataSource is null)
                            return;
                    }
                }
                catch (Exception ex)
                {
                    cnn.Close();
                }
                cnn.Close();
            }
        }

        public bool login(string user, string password)
        {
            bool ok = false;
            using (SqlConnection cnn = new SqlConnection(conexion))
            {
                try
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand($"SELECT * FROM Usuarios WHERE UserName = '{user}' and Password = '{password}'", cnn) { CommandType = CommandType.Text };
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ok = true;
                        Program._isLogin = true;
                        //Program._userName = user;
                        Usuarios.Id = reader.GetInt32(0);
                        Usuarios.UserName = reader.GetString(1);
                        Usuarios.Password = reader.GetString(2);
                        Usuarios.LastUpd = reader.GetDateTime(3);
                        Usuarios.UserLevel = reader.GetInt32(4);
                        Program._userId = Usuarios.Id;
                    }

                }
                catch (Exception ex)
                {
                    ok = false;
                    cnn.Close();
                }
                cnn.Close();
                return ok;
            }
        }
        public void GetUserData(string query)
        {
            using (SqlConnection cnn = new SqlConnection(conexion))
            {
                try
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(query, cnn) { CommandType = CommandType.Text };
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                       
                        Usuarios.Id = reader.GetInt32(0);
                        Usuarios.UserName = reader.GetString(1);
                        Usuarios.Password = reader.GetString(2);
                        Usuarios.LastUpd = reader.GetDateTime(3);
                        Usuarios.UserLevel = reader.GetInt32(4);
                       
                    }

                }
                catch (Exception ex)
                {
                  
                    cnn.Close();
                }
                cnn.Close();
               
            }

        }
        public bool GetPassword(string query)
        {
            using (SqlConnection cnn = new SqlConnection(conexion))
            {
                try
                {

                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn) { CommandType = CommandType.Text };
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Usuarios.Password = reader.GetString(0);
                        cnn.Close();
                        return true;
                    }
                    else
                    {
                        cnn.Close();
                        return false;
                    }
                        
                    
                }

                catch (Exception ex)
                {
                    cnn.Close();
                    return false;
                }
            }
        }
        public string GetUser(string query)
        {
            using (SqlConnection cnn = new SqlConnection(conexion))
            { 
                string user = string.Empty;
                try
                {
                    
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn) { CommandType = CommandType.Text };
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = reader.GetString(0);
                    }
                }

                catch (Exception ex)
                {
                    cnn.Close();
                    
                }
                cnn.Close();
                return user;
            }
        }
        public void ComboCategorias(ComboBox combo, string query)
        {
            DataSet dataSet = new DataSet();
            using(SqlConnection cnn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                combo.DataSource = dataSet.Tables[0];
                combo.ValueMember = "Id";
                combo.DisplayMember = "Nombre";
               
              
                cnn.Close();
            }
        }
        public void ComboNiveles(ComboBox combo, string query)
        {
            DataSet dataSet = new DataSet();
            using(SqlConnection cnn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                combo.DataSource = dataSet.Tables[0];
                combo.ValueMember = "Id";
                combo.DisplayMember = "Level";
            }
        }
        public bool ReturnQuery(string query)
        {
            SqlConnection cnn = new SqlConnection(conexion);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            try
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();

                cnn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                cnn.Close();
                return false;
            }
        }

        public bool GetProducts(string query)
        {
            using(SqlConnection cnn = new SqlConnection(conexion))
            {
                bool ok = false;
                try
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();

                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(query, cnn) { CommandType = CommandType.Text };
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Producto.Id = reader.GetInt32(0);
                        Producto.CodigoBarras = reader.GetString(1);
                        Producto.Nombre = reader.GetString(2);
                        Producto.IdCategoria = reader.GetInt32(3);
                        Producto.Precio = Convert.ToDecimal(reader.GetDouble(4));
                        Producto.Marca = reader.GetString(5);
                        Producto.Caducidad = reader.GetDateTime(6);
                        Producto.Descripcion = reader.GetString(7);
                        ok = true;
                    }
                }
                catch(Exception ex)
                {
                    ok = false;
                    cnn.Close();
                }
                cnn.Close();
                return ok;
            }
        }

        public bool ValidateData(string query)
        {
            using(SqlConnection cnn = new SqlConnection(conexion))
            {
                try
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(query, cnn) { CommandType = CommandType.Text };
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        cnn.Close();
                        return true;
                    }
                    else
                    {
                        cnn.Close();
                        return false;
                    }
                }
                catch(Exception ex)
                {
                   
                    cnn.Close(); 
                    return false;
                }
              
            }
        }
        public void GetCategory(string query)
        {
            using (SqlConnection cnn = new SqlConnection(conexion))
            {
                try
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();

                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(query, cnn) { CommandType = CommandType.Text };
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Categoria.Id = reader.GetInt32(0);
                        Categoria.Nombre = reader.GetString(1);
                        
                    }
                }
                catch (Exception ex)
                {
                    cnn.Close();
                }
                cnn.Close();
            }
        }
        
        public bool GetInventory(string query)
        {
            using(SqlConnection cnn = new SqlConnection(conexion))
            {
                try
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();

                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn) { CommandType = CommandType.Text };
                    SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            Inventarios.Id = reader.GetInt32(0);
                            Inventarios.ProductName = reader.GetString(1);
                            Inventarios.IdCategoria = reader.GetInt32(2);
                            Inventarios.Stock = reader.GetInt32(3);
                            Inventarios.Last_upd = reader.GetDateTime(4);
                            cnn.Close();
                            return true;
                        }
                        else
                        {
                            cnn.Close();
                            return false;
                        }
                }
                catch(Exception ex)
                {
                    cnn.Close();
                    return false;
                }
                
            }
        }

        public bool GetUserLevel(string query)
        {
            using(SqlConnection cnn = new SqlConnection(conexion))
            {
                bool ok = false;
                try
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn) { CommandType = CommandType.Text };
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Levels.Id = reader.GetInt32(0);
                        Levels.Level = reader.GetString(1);
                        ok = true;
                    }
                }
                catch (Exception ex)
                {
                    ok = false;
                    cnn.Close();
                }
                cnn.Close();
                return ok;
            }
        }

        public int NoVenta()
        { 
            using(SqlConnection cnn = new SqlConnection(conexion))
            {
                int v = 0;
                try
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Ventas", cnn) { CommandType = CommandType.Text };
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                        v = reader.GetInt32(0);

                }
                catch(Exception ex)
                {
                    cnn.Close();
                }
                cnn.Close();
                return v;
            }
        }

        public int GetVenta(int cantidad, string fecha, int userId)
        {
            using (SqlConnection cnn = new SqlConnection(conexion))
            {
                int venta = 0;
                try
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT Id FROM Ventas WHERE CANTIDAD = {cantidad} AND Fecha = '{fecha}' AND UserId = {userId}", cnn) { CommandType = CommandType.Text };
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                        venta = reader.GetInt32(0);
                }
                catch(Exception ex)
                {
                    cnn.Close();
                }
                cnn.Close();
                return venta;

            }
        }

        public bool BuscarProductoVendido(string query)
        {
            using (SqlConnection cnn = new SqlConnection(conexion))
            {
                bool ok = false;
                try
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn) { CommandType = CommandType.Text };
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                        ok = true;
                }
                catch(Exception ex)
                {
                    cnn.Close();
                }
                cnn.Close();
                return ok;
            }
        }

        public bool LoadVenta(string query)
        {
            using(SqlConnection cnn = new SqlConnection(conexion))
            {
                bool ok = false;
                try
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn) { CommandType = CommandType.Text };
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ok = true;
                        Venta.Id = reader.GetInt32(0); 
                        Venta.Cantidad = reader.GetInt32(1);
                        Venta.Fecha = reader.GetDateTime(2);
                        Venta.UserId = reader.GetInt32(3);
                        Venta.ValorVenta = reader.GetDouble(4);
                        Venta.Subtotal = reader.GetDouble(5);
                        Venta.IGV = reader.GetDouble(6);
                        Venta.Total = reader.GetDouble(7);

                    }
                }
                catch(Exception ex)
                {
                    cnn.Close();
                }
                cnn.Close();
                return ok;
            }

        }
    }
}
