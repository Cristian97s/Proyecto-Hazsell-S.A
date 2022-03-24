using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class Cliente : Form
    {
        CN_Cliente objetoCN = new CN_Cliente();
        private string Rut_Cliente = null;
        private bool Editar = false;
        public Cliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            MostrarCliente();
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
            txTelefono.ForeColor = ThemeColor.SecondaryColor;
            txtTipo.ForeColor = ThemeColor.SecondaryColor;
            txtFechaN.ForeColor = ThemeColor.SecondaryColor;
            txtObserva.ForeColor = ThemeColor.SecondaryColor;
            label4.ForeColor = ThemeColor.PrimaryColor;
        }

        private void MostrarCliente()
        {
            CN_Cliente objeto = new CN_Cliente();
            dataGridView1.DataSource = objeto.MostrarCli();
        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            ///INSERTAR
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarCli(txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text, txtTipoC.Text, dtpFechaNac.Value, txtObse.Text);
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarCliente();
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
                    objetoCN.EditarCli(txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text, txtTipoC.Text, dtpFechaNac.Value, txtObse.Text, Rut_Cliente);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarCliente();
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
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre_Cliente"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["Apellido_Cliente"].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells["Direccion_Cliente"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["Telefono_Cliente"].Value.ToString();
                txtTipoC.Text = dataGridView1.CurrentRow.Cells["Tipo_Cliente"].Value.ToString();
                dtpFechaNac.Value.ToString("yyyy-MM-dd");
                txtObse.Text = dataGridView1.CurrentRow.Cells["Observaciones_Cliente"].Value.ToString();
                Rut_Cliente = dataGridView1.CurrentRow.Cells["Rut_Cliente"].Value.ToString();
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
            txtTipoC.Clear();
            txtObse.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Rut_Cliente = dataGridView1.CurrentRow.Cells["Rut_Cliente"].Value.ToString();
                objetoCN.EliminarCli(Rut_Cliente);
                MessageBox.Show("Eliminado Corectamente");
                MostrarCliente();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
