using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Cocinero
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
            comando.CommandText = "usp_ObtenerPersonalCocinero";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable Mostrar2()
        {
            ///PROCEDURE SQL 
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ObtenerTipoPersona";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable Mostrar3()
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

        public void Insertar(string Nombre_Cocinero, string Apellido_Cocinero, string Telefono_Cocinero, string Direccion_Cocinero, int cod_Tipo, int cod_Turno)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_RegistrarPersonalCocinero";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre_Cocinero", Nombre_Cocinero);
            comando.Parameters.AddWithValue("@Apellido_Cocinero", Apellido_Cocinero);
            comando.Parameters.AddWithValue("@Telefono_Cocinero", Telefono_Cocinero);
            comando.Parameters.AddWithValue("@Direccion_Cocinero", Direccion_Cocinero);
            comando.Parameters.AddWithValue("@cod_Tipo", cod_Tipo);
            comando.Parameters.AddWithValue("@cod_Turno", cod_Turno);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string Nombre_Cocinero, string Apellido_Cocinero, string Telefono_Cocinero, string Direccion_Cocinero, int cod_Tipo, int cod_Turno, int Rut_Personal_Cocinero)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ModificarPersonalCocinero";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre_Cocinero", Nombre_Cocinero);
            comando.Parameters.AddWithValue("@Apellido_Cocinero", Apellido_Cocinero);
            comando.Parameters.AddWithValue("@Telefono_Cocinero", Telefono_Cocinero);
            comando.Parameters.AddWithValue("@Direccion_Cocinero", Direccion_Cocinero);
            comando.Parameters.AddWithValue("@Rut_Personal_Cocinero", Rut_Personal_Cocinero);
            comando.Parameters.AddWithValue("@cod_Tipo", cod_Tipo);
            comando.Parameters.AddWithValue("@cod_Turno", cod_Turno);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int Rut_Personal_Cocinero)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_EliminarPersonalCocinero";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Rut_Personal_Cocinero", Rut_Personal_Cocinero);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
