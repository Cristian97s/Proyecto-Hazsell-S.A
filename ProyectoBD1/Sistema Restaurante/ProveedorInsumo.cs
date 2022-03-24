using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class ProveedorInsumo : Form
    {
        CN_ProveedorInsumo objetoCN = new CN_ProveedorInsumo();
        private string Id_ProveedorInsumo = null;
        private bool Editar = false;
        public ProveedorInsumo()
        {
            InitializeComponent();
        }
        private void ProveedorInsumo_Load(object sender, EventArgs e)
        {
            MostrarProveedorInsumo();
            MostrarProveedor();
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
        private void MostrarProveedorInsumo()
        {
            CN_ProveedorInsumo objeto = new CN_ProveedorInsumo();
            dataGridView1.DataSource = objeto.MostrarPI();
        }
        private void MostrarProveedor()
        {
            CN_ProveedorInsumo objeto = new CN_ProveedorInsumo();
            comboBox1.DataSource = objeto.MostrarPI2();
            comboBox1.DisplayMember = "Nombre_Proveedor";
            comboBox1.ValueMember = "Rut_Proveedor";
        }
        private void MostrarInsumo()
        {
            CN_ProveedorInsumo objeto = new CN_ProveedorInsumo();
            comboBox2.DataSource = objeto.MostrarPI3();
            comboBox2.DisplayMember = "nombre_insumo";
            comboBox2.ValueMember = "cod_Insumo";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ///INSERTAR
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarPI(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), txtPrecio.Text);
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarProveedorInsumo();
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
                    objetoCN.EditarPI(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), txtPrecio.Text, Id_ProveedorInsumo);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarProveedorInsumo();
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
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio_insumo"].Value.ToString();
                Id_ProveedorInsumo = dataGridView1.CurrentRow.Cells["Id_ProveedorInsumo"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }

        private void limpiarFrom()
        {
            txtPrecio.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Id_ProveedorInsumo = dataGridView1.CurrentRow.Cells["Id_ProveedorInsumo"].Value.ToString();
                objetoCN.EliminarPI(Id_ProveedorInsumo);
                MessageBox.Show("Eliminado Corectamente");
                MostrarProveedorInsumo();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
