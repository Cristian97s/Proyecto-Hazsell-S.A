using CapaDatos;
using Sistema_Restaurante.Entidad;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_Restaurante.Datos
{
    public class CD_Usuario
    {
        private CD_Conexion conexion = new CD_Conexion();
        DataTable dt = new DataTable();
        public DataTable Logear(CE_Usuario obje)
        {
            SqlCommand cmd = new SqlCommand("SP_VerificarUsuario", conexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Usuario", obje.usuario));
            cmd.Parameters.Add(new SqlParameter("@Pass", obje.contraseña));
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }
    }
}
