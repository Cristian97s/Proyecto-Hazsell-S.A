using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class DetallePedido : Form
    {
        CN_DetallePedido objetoCN = new CN_DetallePedido();
        private string Id_DetallePedido = null;
        private bool Editar = false;

        public DetallePedido()
        {
            InitializeComponent();
        }

        private void DetallePedido_Load(object sender, EventArgs e)
        {
            MostrarDetallePedido();
            MostrarPedido();
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

        private void MostrarDetallePedido()
        {
            CN_DetallePedido objeto = new CN_DetallePedido();
            dataGridView1.DataSource = objeto.MostrarDP();
        }
        private void MostrarPedido()
        {
            CN_DetallePedido objeto = new CN_DetallePedido();
            comboBox1.DataSource = objeto.MostrarDP2();
            comboBox1.DisplayMember = "Tipo_Pedido";
            comboBox1.ValueMember = "Id_Pedido";
        }
        private void MostrarPlato()
        {
            CN_DetallePedido objeto = new CN_DetallePedido();
            comboBox2.DataSource = objeto.MostrarDP3();
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
                    objetoCN.InsertarDP(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), txtMenu.Text);
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarDetallePedido();
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
                    objetoCN.EditarDP(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), txtMenu.Text, Id_DetallePedido);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarDetallePedido();
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
                txtMenu.Text = dataGridView1.CurrentRow.Cells["Menu"].Value.ToString();
                Id_DetallePedido = dataGridView1.CurrentRow.Cells["Id_DetallePedido"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }

        private void limpiarFrom()
        {
            txtMenu.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Id_DetallePedido = dataGridView1.CurrentRow.Cells["Id_DetallePedido"].Value.ToString();
                objetoCN.EliminarDP(Id_DetallePedido);
                MessageBox.Show("Eliminado Corectamente");
                MostrarDetallePedido();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
