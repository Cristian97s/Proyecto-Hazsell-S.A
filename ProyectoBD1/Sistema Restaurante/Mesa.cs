using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class Mesa : Form
    {
        CN_Mesa objetoCN = new CN_Mesa();
        private string Num_Mesa = null;
        private bool Editar = false;
        public Mesa()
        {
            InitializeComponent();
        }

        private void Mesa_Load_1(object sender, EventArgs e)
        {
            MostrarMesa();
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
            label3.ForeColor = ThemeColor.PrimaryColor;
        }
        private void MostrarMesa()
        {
            CN_Mesa objeto = new CN_Mesa();
            dataGridView1.DataSource = objeto.MostrarMe();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ///INSERTAR
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarMe(Convert.ToInt16(txtComensales.Text), txtUbicacion.Text);
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarMesa();
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
                    objetoCN.EditarMe(Convert.ToInt16(txtComensales.Text), txtUbicacion.Text, Num_Mesa);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarMesa();
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
                txtComensales.Text = dataGridView1.CurrentRow.Cells["Cant_Max_Comensales"].Value.ToString();
                txtUbicacion.Text = dataGridView1.CurrentRow.Cells["Ubicacion"].Value.ToString();
                Num_Mesa = dataGridView1.CurrentRow.Cells["Num_Mesa"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }

        private void limpiarFrom()
        {
            txtComensales.Clear();
            txtUbicacion.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Num_Mesa = dataGridView1.CurrentRow.Cells["Num_Mesa"].Value.ToString();
                objetoCN.EliminarMe(Num_Mesa);
                MessageBox.Show("Eliminado Corectamente");
                MostrarMesa();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
