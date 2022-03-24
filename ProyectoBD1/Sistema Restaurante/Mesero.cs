using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class Mesero : Form
    {
        CN_Mesero objetoCN = new CN_Mesero();
        private string Rut_Personal_Mesero = null;
        private bool Editar = false;

        public Mesero()
        {
            InitializeComponent();
        }

        private void Mesero_Load(object sender, EventArgs e)
        {
            MostrarMesero();
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
        private void MostrarMesero()
        {
            CN_Mesero objeto = new CN_Mesero();
            dataGridView1.DataSource = objeto.MostrarMese();
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
                    objetoCN.InsertarMese(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue));
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarMesero();
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
                    objetoCN.EditarMese(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), Rut_Personal_Mesero);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarMesero();
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
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre_Mesero"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["Apellido_Mesero"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["Telefono_Mesero"].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells["Direccion_Mesero"].Value.ToString();
                Rut_Personal_Mesero = dataGridView1.CurrentRow.Cells["Rut_Personal_Mesero"].Value.ToString();
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
                Rut_Personal_Mesero = dataGridView1.CurrentRow.Cells["Rut_Personal_Mesero"].Value.ToString();
                objetoCN.EliminarMese(Rut_Personal_Mesero);
                MessageBox.Show("Eliminado Corectamente");
                MostrarMesero();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
