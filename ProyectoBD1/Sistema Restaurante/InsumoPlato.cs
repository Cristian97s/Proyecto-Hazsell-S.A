using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class InsumoPlato : Form
    {
        CN_InsumoPlato objetoCN = new CN_InsumoPlato();
        private string Id_InsumoPlato = null;
        private bool Editar = false;

        public InsumoPlato()
        {
            InitializeComponent();
        }

        private void InsumoPlato_Load(object sender, EventArgs e)
        {
            MostrarInsumoPlato();
            MostrarInsumo();
            MostrarPlato();
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
            label4.ForeColor = ThemeColor.PrimaryColor;
        }
        private void MostrarInsumoPlato()
        {
            CN_InsumoPlato objeto = new CN_InsumoPlato();
            dataGridView1.DataSource = objeto.MostrarInspla();
        }
        private void MostrarInsumo()
        {
            CN_InsumoPlato objeto = new CN_InsumoPlato();
            comboBox1.DataSource = objeto.MostrarInspla2();
            comboBox1.DisplayMember = "nombre_insumo";
            comboBox1.ValueMember = "cod_Insumo";
        }
        private void MostrarPlato()
        {
            CN_InsumoPlato objeto = new CN_InsumoPlato();
            comboBox2.DataSource = objeto.MostrarInspla3();
            comboBox2.DisplayMember = "Nombre_Plato";
            comboBox2.ValueMember = "cod_plato";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ///INSERTAR
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarInspla(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), txtCantidad.Text);
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarInsumoPlato();
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
                    objetoCN.EditarInspla(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), txtCantidad.Text, Id_InsumoPlato);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarInsumoPlato();
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
                txtCantidad.Text = dataGridView1.CurrentRow.Cells["cantidad_insumo_utilizado"].Value.ToString();
                Id_InsumoPlato = dataGridView1.CurrentRow.Cells["Id_InsumoPlato"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }

        private void limpiarFrom()
        {
            txtCantidad.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Id_InsumoPlato = dataGridView1.CurrentRow.Cells["Id_InsumoPlato"].Value.ToString();
                objetoCN.EliminarInspla(Id_InsumoPlato);
                MessageBox.Show("Eliminado Corectamente");
                MostrarInsumoPlato();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
