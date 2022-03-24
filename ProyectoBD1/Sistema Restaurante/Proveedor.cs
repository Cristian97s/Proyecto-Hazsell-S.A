using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class Proveedor : Form
    {
        CN_Proveedor objetoCN = new CN_Proveedor();
        private string Rut_Proveedor = null;
        private bool Editar = false;
        public Proveedor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProveedor();
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
            label6.ForeColor = ThemeColor.PrimaryColor;
        }

        private void MostrarProveedor()
        {
            CN_Proveedor objeto = new CN_Proveedor();
            dataGridView1.DataSource = objeto.MostrarProve();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ///INSERTAR
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarProve(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text, txtFax.Text);
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarProveedor();
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
                    objetoCN.EditarProve(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text, txtFax.Text, Rut_Proveedor);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarProveedor();
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
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre_Proveedor"].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells["Direccion_Proveedor"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["Telefono_Proveedor"].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells["Email_Proveedor"].Value.ToString();
                txtFax.Text = dataGridView1.CurrentRow.Cells["Fax_Proveedor"].Value.ToString();
                Rut_Proveedor = dataGridView1.CurrentRow.Cells["Rut_Proveedor"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }

        private void limpiarFrom()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtFax.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Rut_Proveedor = dataGridView1.CurrentRow.Cells["Rut_Proveedor"].Value.ToString();
                objetoCN.EliminarProve(Rut_Proveedor);
                MessageBox.Show("Eliminado Corectamente");
                MostrarProveedor();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
