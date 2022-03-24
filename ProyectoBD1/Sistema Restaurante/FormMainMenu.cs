using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class FormMainMenu : Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        //Constructor
        public FormMainMenu()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Proveedor(), sender);
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btnCloseChildForm_Click_1(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void bntMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Cliente(), sender);
        }

        private void btnMesa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Mesa(), sender);
        }

        private void btnTurno_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Turno(), sender);
        }
        private void btnTipo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TipoPersonal(), sender);
        }

        private void btnInsumo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Insumo(), sender);
        }

        private void btnCocinero_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Cocinero(), sender);
        }

        private void btnMesero_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Mesero(), sender);
        }

        private void btnPlato_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Plato(), sender);
        }

        private void btnDetalleInsumo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProveedorInsumo(), sender);
        }

        private void btnDetallePlato_Click(object sender, EventArgs e)
        {
            OpenChildForm(new InsumoPlato(), sender);
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Pedido(), sender);
        }

        private void btnDetallePedido_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DetallePedido(), sender);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Ventas(), sender);
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            Controlador.Encriptar encrip = new Controlador.Encriptar();
            if (frmLogin.cod == "2")//Cocinero
            {
                btnCliente.Enabled = false;
                btnCocinero.Enabled = false;
                btnMesero.Enabled = false;
                btnTipo.Enabled = false;
                btnTurno.Enabled = false;
                btnMesa.Enabled = false;
                btnPedido.Enabled = false;
                btnMesero.Enabled = false;
                btnMesa.Enabled = false;
                btnPedido.Enabled = false;
                btnVentas.Enabled = false;
                button1.Enabled = false;
            }
            else if (frmLogin.cod == "1")//Mesero
            {
                btnProveedor.Enabled = false;
                btnCocinero.Enabled = false;
                btnMesero.Enabled = false;
                btnTipo.Enabled = false;
                btnTurno.Enabled = false;
                btnMesero.Enabled = false;
                btnInsumo.Enabled = false;
                btnDetalleInsumo.Enabled = false;
                button1.Enabled = false;
            }
            else if (frmLogin.cod == "3")//Admin(Carita Fachera)
            {
                MessageBox.Show("Mi Reina, Usted es ADMIN... SU CORONA");
            }
            else if (frmLogin.cod == "4")//RRHH
            {
                btnProveedor.Enabled = false;
                btnCliente.Enabled = false;
                btnMesa.Enabled = false;
                btnDetallePlato.Enabled = false;
                btnInsumo.Enabled = false;
                btnPlato.Enabled = false;
                btnDetalleInsumo.Enabled = false;
                btnDetallePedido.Enabled = false;
                btnPedido.Enabled = false;
                btnDetallePedido.Enabled = false;
                btnVentas.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Reporte(), sender);
        }
    }
}
