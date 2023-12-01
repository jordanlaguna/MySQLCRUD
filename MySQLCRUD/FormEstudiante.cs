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
    public partial class FormEstudiante : Form
    {
        private readonly FormEstudianteinfo _parent;
        string id, nombre, region, @clase, seccion;

        public FormEstudiante(FormEstudianteinfo parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void ActualizarInformacion()
        {
            lbltext.Text = "Actualizar estudiante";
            btnGuardar.Text = "Actualizar";
            txtNombre.Text = nombre;
            txtRegion.Text = region;
            txtClase.Text = clase;
            txtSeccion.Text = seccion;
        }


        public void limpiar()
        {
            txtNombre.Text = txtRegion.Text = txtClase.Text = txtSeccion.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Trim().Length < 3)
            {
                MessageBox.Show("Estudiante nombre is Empty ( > 3).");
                return;
            }
            if (txtRegion.Text.Trim().Length < 1)
            {
                MessageBox.Show("Estudiante region is Empty ( > 1).");
                return;
            }
            if (txtClase.Text.Trim().Length == 0)
            {
                MessageBox.Show("Estudiante clase is Empty ( > 1).");
                return;
            }
            if (txtSeccion.Text.Trim().Length == 0)
            {
                MessageBox.Show("Estudiante seccion is Empty ( > 1).");
                return;
            }
            if (btnGuardar.Text == "Guardar")
            {
                Estudiante std = new Estudiante(txtNombre.Text.Trim(), txtRegion.Text.Trim(), txtClase.Text.Trim(), txtSeccion.Text.Trim());
                DbEstudiante.AgregarEstudiante(std);
                limpiar();
            }
            if (btnGuardar.Text == "Actualizar")
            {
                Estudiante std = new Estudiante(txtNombre.Text.Trim(), txtRegion.Text.Trim(), txtClase.Text.Trim(), txtSeccion.Text.Trim());
                DbEstudiante.ActualizarEstudiante(std, id);
            }
            _parent.Buscar();
        }
    }
}
