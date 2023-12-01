using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQLCRUD
{
    public partial class FormEstudianteinfo : Form
    {
        FormEstudiante ventana;
        public FormEstudianteinfo()
        {
            InitializeComponent();
            ventana = new FormEstudiante(this);
        }
        public void Buscar()
        {
            DbEstudiante.MostrarEstudiante("SELECT ID, Nombre, Region, Clase, Seccion FROM estudiantes_tabla", dataGridView);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ventana.limpiar();
            ventana.ShowDialog();
        }

        private void StudenInfo_Show(object sender, EventArgs e)
        {
            Buscar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            DbEstudiante.MostrarEstudiante("SELECT ID, Nombre, Region, Clase, Seccion FROM estudiantes_tabla WHERE Nombre LIKE'%" + txtBuscar.Text + "%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {//Metodo editar no completo
            if (e.ColumnIndex == 0)
            {   

                ventana.limpiar();
                return;
            }
            //Metodo borrar
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("¿Quieres eliminar este estduiante?", "Información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbEstudiante.EliminarEstudiante(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Buscar();
                }
                return;
            }
        }
    }
}
