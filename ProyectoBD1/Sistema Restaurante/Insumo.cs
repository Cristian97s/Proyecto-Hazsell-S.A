using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class Insumo : Form
    {
        CN_Insumo objetoCN = new CN_Insumo();
        private string cod_Insumo = null;
        private bool Editar = false;
        public Insumo()
        {
            InitializeComponent();
        }

        private void Insumo_Load(object sender, EventArgs e)
        {
            MostrarInsumo();
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
        private void MostrarInsumo()
        {
            CN_Insumo objeto = new CN_Insumo();
            dataGridView1.DataSource = objeto.MostrarIns();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ///INSERTAR
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarIns(txtNombre.Text, txtCantidad.Text, txtUnidadMedida.Text);
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarInsumo();
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
                    objetoCN.EditarIns(txtNombre.Text, txtCantidad.Text, txtUnidadMedida.Text, cod_Insumo);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarInsumo();
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
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre_insumo"].Value.ToString();
                txtCantidad.Text = dataGridView1.CurrentRow.Cells["cantidad_insumo"].Value.ToString();
                txtUnidadMedida.Text = dataGridView1.CurrentRow.Cells["unidad_medida_insumo"].Value.ToString();
                cod_Insumo = dataGridView1.CurrentRow.Cells["cod_Insumo"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
        private void limpiarFrom()
        {
            txtNombre.Clear();
            txtCantidad.Clear();
            txtUnidadMedida.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                cod_Insumo = dataGridView1.CurrentRow.Cells["cod_Insumo"].Value.ToString();
                objetoCN.EliminarIns(cod_Insumo);
                MessageBox.Show("Eliminado Corectamente");
                MostrarInsumo();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
