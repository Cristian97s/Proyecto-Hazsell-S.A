using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Turno
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
            comando.CommandText = "usp_ObtenerTurno";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string Descripcion)
        {
            ///PROCEDURE SQL

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_RegistrarTurno";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string Descripcion, int cod_Turno)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ModificarTurno";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@cod_Turno", cod_Turno);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int cod_Turno)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_EliminarTurno";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cod_Turno", cod_Turno);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
