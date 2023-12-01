using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQLCRUD
{
    internal class DbEstudiante
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=estudiante";
            MySqlConnection conn = new MySqlConnection(sql);

            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Conexión fallida\n"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
            return conn;
        }
        public static void AgregarEstudiante(Estudiante std)
        {
            string sql = "INSERT INTO estudiantes_tabla VALUES (NULL, @EstudianteNombre, @EstudianteRegion, @EstudianteClase, @EstudianteSeccion, NULL)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@EstudianteNombre", MySqlDbType.VarChar).Value = std.Nombre;
            cmd.Parameters.Add("@EstudianteRegion", MySqlDbType.VarChar).Value = std.Region;
            cmd.Parameters.Add("@EstudianteClase", MySqlDbType.VarChar).Value = std.Clase;
            cmd.Parameters.Add("@EstudianteSeccion", MySqlDbType.VarChar).Value = std.Seccion;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Agregado Correctamente.\n", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No se agregó el estudiante.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            conn.Close();
        }
        public static void ActualizarEstudiante(Estudiante std, string id)
        {
            string sql = "UPDATE estudiantes_tabla SET Nombre = @EstudianteNombre, @EstudianteRegion, @EstudianteClase, @EstudianteSeccion WHERE ID = @EstudianteID";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@EstudianteNombre", MySqlDbType.VarChar).Value = std.Nombre;
            cmd.Parameters.Add("@EstudianteRegion", MySqlDbType.VarChar).Value = std.Region;
            cmd.Parameters.Add("@EstudianteClase", MySqlDbType.VarChar).Value = std.Clase;
            cmd.Parameters.Add("@EstudianteSeccion", MySqlDbType.VarChar).Value = std.Seccion;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizado Correctamente.\n", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No se pudo actualizar el estudiante.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            conn.Close();
        }
        public static void EliminarEstudiante(string id)
        {
            string sql = "DELETE FROM estudiantes_tabla WHERE ID = @EstudianteID";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@EstudianteID", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se eliminó Correctamente.\n", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No se pudo eliminar el estudiante.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            conn.Close();
        }
        public static void MostrarEstudiante(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            conn.Close();
        }
    }
}
