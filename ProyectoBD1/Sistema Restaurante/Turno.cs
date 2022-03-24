using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class Turno : Form
    {
        CN_Turno objetoCN = new CN_Turno();
        private string cod_Turno = null;
        private bool Editar = false;
        public Turno()
        {
            InitializeComponent();
        }

        private void Turno_Load(object sender, EventArgs e)
        {
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
            label2.ForeColor = ThemeColor.PrimaryColor;
        }
        private void MostrarTurno()
        {
            CN_Turno objeto = new CN_Turno();
            dataGridView1.DataSource = objeto.MostrarTu();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ///INSERTAR
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarTu(txtDescripcion.Text);
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarTurno();
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
                    objetoCN.EditarTu(txtDescripcion.Text, cod_Turno);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarTurno();
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
                cod_Turno = dataGridView1.CurrentRow.Cells["cod_Turno"].Value.ToString();
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
                cod_Turno = dataGridView1.CurrentRow.Cells["cod_Turno"].Value.ToString();
                objetoCN.EliminarTu(cod_Turno);
                MessageBox.Show("Eliminado Corectamente");
                MostrarTurno();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
