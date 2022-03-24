using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class Plato : Form
    {
        CN_Plato objetoCN = new CN_Plato();
        private string cod_plato = null;
        private bool Editar = false;

        public Plato()
        {
            InitializeComponent();
        }

        private void Plato_Load(object sender, EventArgs e)
        {
            MostrarPlato();
            MostrarCocinero();
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
            label5.ForeColor = ThemeColor.PrimaryColor;
        }
        private void MostrarPlato()
        {
            CN_Plato objeto = new CN_Plato();
            dataGridView1.DataSource = objeto.MostrarPla();
        }
        private void MostrarCocinero()
        {
            CN_Plato objeto = new CN_Plato();
            comboBox1.DataSource = objeto.MostrarPla2();
            comboBox1.DisplayMember = "Nombre_Cocinero";
            comboBox1.ValueMember = "Rut_Personal_Cocinero";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarPla(txtNombre.Text, txtPrecio.Text, txtDescripcion.Text, Convert.ToInt32(comboBox1.SelectedValue));
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarPlato();
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
                    objetoCN.EditarPla(txtNombre.Text, txtPrecio.Text, txtDescripcion.Text, Convert.ToInt32(comboBox1.SelectedValue), cod_plato);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarPlato();
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
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre_Plato"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio_Plato"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion_Plato"].Value.ToString();
                cod_plato = dataGridView1.CurrentRow.Cells["cod_plato"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }

        private void limpiarFrom()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtDescripcion.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                cod_plato = dataGridView1.CurrentRow.Cells["cod_plato"].Value.ToString();
                objetoCN.EliminarPla(cod_plato);
                MessageBox.Show("Eliminado Corectamente");
                MostrarPlato();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
