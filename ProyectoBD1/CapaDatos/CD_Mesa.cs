using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Mesa
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            ///PROCEDURE SQL 
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ObtenerMesa";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(int Cant_Max_Comensales,string Ubicacion)
        {
            ///PROCEDURE SQL

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_RegistrarMesa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cant_Max_Comensales", Cant_Max_Comensales);
            comando.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(int Cant_Max_Comensales, string Ubicacion, int Num_Mesa)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ModificarMesa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cant_Max_Comensales", Cant_Max_Comensales);
            comando.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            comando.Parameters.AddWithValue("@Num_Mesa", Num_Mesa);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int Num_Mesa)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_EliminarMesa";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Num_Mesa", Num_Mesa);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}
