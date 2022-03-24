using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Sistema_Restaurante.Controlador
{
    class Encriptar
    {
        public string GetSHA1(string str)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public void menu(string num)
        {
            FormMainMenu fr = new FormMainMenu();
            if (num == "2")//Cocinero
            {
                fr.btnCliente.Enabled = false;
                fr.btnMesa.Enabled = false;
                fr.btnPedido.Enabled = false;
            }
            else if (num == "1")//Mesero
            {
                fr.btnInsumo.Enabled = false;
                fr.btnDetalleInsumo.Enabled = false;
                fr.btnProveedor.Enabled = false;
            }
            else if (num == "3")
            {
                MessageBox.Show("Mi rey, Usted es ADMIN... SU CORONA");
            }
        }
    }
}
