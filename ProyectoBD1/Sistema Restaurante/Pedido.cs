using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class Pedido : Form
    {
        CN_Pedido objetoCN = new CN_Pedido();
        private string Id_Pedido = null;
        private bool Editar = false;
        public Pedido()
        {
            InitializeComponent();
        }

        private void Pedido_Load(object sender, EventArgs e)
        {
            MostrarPedido();
            MostrarClinete();
            MostrarMesa();
            MostrarMesero();
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
        private void MostrarPedido()
        {
            CN_Pedido objeto = new CN_Pedido();
            dataGridView1.DataSource = objeto.MostrarPed();
        }
        private void MostrarClinete()
        {
            CN_Pedido objeto = new CN_Pedido();
            comboBox1.DataSource = objeto.MostrarPed2();
            comboBox1.DisplayMember = "Nombre_Cliente";
            comboBox1.ValueMember = "Rut_Cliente";
        }
        private void MostrarMesa()
        {
            CN_Pedido objeto = new CN_Pedido();
            comboBox2.DataSource = objeto.MostrarPed3();
            comboBox2.DisplayMember = "Ubicacion";
            comboBox2.ValueMember = "Num_Mesa";
        }
        private void MostrarMesero()
        {
            CN_Pedido objeto = new CN_Pedido();
            comboBox3.DataSource = objeto.MostrarPed4();
            comboBox3.DisplayMember = "Nombre_Mesero";
            comboBox3.ValueMember = "Rut_Personal_Mesero";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ///INSERTAR
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarPed(Convert.ToInt32(comboBox1.SelectedValue), txtTipoPedido.Text, Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox3.SelectedValue), dtpFechaPedido.Value);
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarPedido();
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
                    objetoCN.EditarPed(Convert.ToInt32(comboBox1.SelectedValue), txtTipoPedido.Text, Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox3.SelectedValue), dtpFechaPedido.Value, Id_Pedido);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarPedido();
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
                txtTipoPedido.Text = dataGridView1.CurrentRow.Cells["Tipo_Pedido"].Value.ToString();
                dtpFechaPedido.Value.ToString("yyyy-MM-dd");
                Id_Pedido = dataGridView1.CurrentRow.Cells["Id_Pedido"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }

        private void limpiarFrom()
        {
            txtTipoPedido.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Id_Pedido = dataGridView1.CurrentRow.Cells["Id_Pedido"].Value.ToString();
                objetoCN.EliminarPed(Id_Pedido);
                MessageBox.Show("Eliminado Corectamente");
                MostrarPedido();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
