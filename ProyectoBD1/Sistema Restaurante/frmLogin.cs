using Sistema_Restaurante.Entidad;
using Sistema_Restaurante.Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Restaurante
{
    public partial class frmLogin : Form
    {
        Controlador.Encriptar crip = new Controlador.Encriptar();
        CE_Usuario ce = new CE_Usuario();
        CN_Usuario cn = new CN_Usuario();
        FormMainMenu fm = new FormMainMenu();

        public static string cod;
        public frmLogin()
        {
            InitializeComponent();
            LblHora.Text = DateTime.Now.ToString();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToString();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            logueo();
        }

        void logueo()
        {
            DataTable dt = new DataTable();
            string usuario = crip.GetSHA1(TxtUsuario.Text);
            string contraseña = crip.GetSHA1(TxtPassword.Text);
            ce.usuario = usuario;
            ce.contraseña = contraseña;
            dt = cn.CN_User(ce);
            if (dt.Rows.Count > 0)
            {
                cod = dt.Rows[0][2].ToString();
                fm.ShowDialog();
                frmLogin fr = new frmLogin();
                if (fr.DialogResult == DialogResult.OK)
                    Application.Run(new FormMainMenu());
                TxtUsuario.Clear();
                TxtPassword.Clear();

            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
