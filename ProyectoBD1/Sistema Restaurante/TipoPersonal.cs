using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class TipoPersonal : Form
    {
        CN_Tipo_Personal objetoCN = new CN_Tipo_Personal();
        private string cod_Tipo = null;
        private bool Editar = false;
        public TipoPersonal()
        {
            InitializeComponent();
        }

        private void TipoPersonal_Load(object sender, EventArgs e)
        {
            MostrarTipoPersonal();
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
            label2.ForeColor = ThemeColor.PrimaryColor;
        }
        private void MostrarTipoPersonal()
        {
            CN_Tipo_Personal objeto = new CN_Tipo_Personal();
            dataGridView1.DataSource = objeto.MostrarTP();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ///INSERTAR
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarTP(txtDescripcion.Text);
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarTipoPersonal();
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
                    objetoCN.EditarTP(txtDescripcion.Text, cod_Tipo);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarTipoPersonal();
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
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                cod_Tipo = dataGridView1.CurrentRow.Cells["cod_Tipo"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
        private void limpiarFrom()
        {
            txtDescripcion.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                cod_Tipo = dataGridView1.CurrentRow.Cells["cod_Tipo"].Value.ToString();
                objetoCN.EliminarTP(cod_Tipo);
                MessageBox.Show("Eliminado Corectamente");
                MostrarTipoPersonal();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
