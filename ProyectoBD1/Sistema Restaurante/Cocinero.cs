using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class Cocinero : Form
    {
        CN_Cocinero objetoCN = new CN_Cocinero();
        private string Rut_Personal_Cocinero = null;
        private bool Editar = false;

        public Cocinero()
        {
            InitializeComponent();
        }

        private void Cocinero_Load(object sender, EventArgs e)
        {
            MostrarCocinero();
            MostrarTipoPersonal();
            MostrarTurno();
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            label4.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.SecondaryColor;
            label6.ForeColor = ThemeColor.SecondaryColor;
            label7.ForeColor = ThemeColor.PrimaryColor;
        }

        private void MostrarCocinero()
        {
            CN_Cocinero objeto = new CN_Cocinero();
            dataGridView1.DataSource = objeto.MostrarCoc();
        }
        private void MostrarTipoPersonal()
        {
            CN_Cocinero objeto = new CN_Cocinero();
            comboBox1.DataSource = objeto.MostrarCoc2();
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "cod_Tipo";
        }
        private void MostrarTurno()
        {
            CN_Cocinero objeto = new CN_Cocinero();
            comboBox2.DataSource = objeto.MostrarCoc3();
            comboBox2.DisplayMember = "Descripcion";
            comboBox2.ValueMember = "cod_Turno";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarCoc(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue));
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarCocinero();
                    limpiarFrom();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se Puedo Insertar Datos Por:" + ex);
                }
            }
            ///EDITAR
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarCoc(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), Rut_Personal_Cocinero);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarCocinero();
                    limpiarFrom();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se Puedo Editar Datos Por:" + ex);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre_Cocinero"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["Apellido_Cocinero"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["Telefono_Cocinero"].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells["Direccion_Cocinero"].Value.ToString();
                Rut_Personal_Cocinero = dataGridView1.CurrentRow.Cells["Rut_Personal_Cocinero"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }

        private void limpiarFrom()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Rut_Personal_Cocinero = dataGridView1.CurrentRow.Cells["Rut_Personal_Cocinero"].Value.ToString();
                objetoCN.EliminarCoc(Rut_Personal_Cocinero);
                MessageBox.Show("Eliminado Corectamente");
                MostrarCocinero();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
