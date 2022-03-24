using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class Ventas : Form
    {
        CN_Ventas objetoCN = new CN_Ventas();
        private string Cod_Venta = null;
        private bool Editar = false;

        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            MostrarVentas();
            MostrarPedido();
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
        private void MostrarVentas()
        {
            CN_Ventas objeto = new CN_Ventas();
            dataGridView1.DataSource = objeto.MostrarVe();
        }
        private void MostrarPedido()
        {
            CN_Ventas objeto = new CN_Ventas();
            comboBox1.DataSource = objeto.MostrarVe2();
            comboBox1.DisplayMember = "Tipo_Pedido";
            comboBox1.ValueMember = "Id_Pedido";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarVe(txtTipoVenta.Text, txtPropina.Text, txtPagoCon.Text, dtpFechaVenta.Value, Convert.ToInt32(comboBox1.SelectedValue));
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarVentas();
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
                    objetoCN.EditarVe(txtTipoVenta.Text, txtPropina.Text, txtPagoCon.Text, dtpFechaVenta.Value, Convert.ToInt32(comboBox1.SelectedValue), Cod_Venta);
                    MessageBox.Show("Se Edito Correctamente");
                    MostrarVentas();
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
                txtTipoVenta.Text = dataGridView1.CurrentRow.Cells["Tipo_Venta"].Value.ToString();
                txtPropina.Text = dataGridView1.CurrentRow.Cells["Propina"].Value.ToString();
                txtPagoCon.Text = dataGridView1.CurrentRow.Cells["PagoCon"].Value.ToString();
                dtpFechaVenta.Value.ToString("yyyy-MM-dd");
                Cod_Venta = dataGridView1.CurrentRow.Cells["Cod_Venta"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }

        private void limpiarFrom()
        {
            txtTipoVenta.Clear();
            txtPropina.Clear();
            txtPagoCon.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Cod_Venta = dataGridView1.CurrentRow.Cells["Cod_Venta"].Value.ToString();
                objetoCN.EliminarVe(Cod_Venta);
                MessageBox.Show("Eliminado Corectamente");
                MostrarVentas();
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila Porfavor");
            }
        }
    }
}
