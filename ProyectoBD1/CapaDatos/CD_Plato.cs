using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Plato
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
            comando.CommandText = "usp_ObtenerPlato";
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
            comando.CommandText = "usp_ObtenerPersonalCocinero";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(string Nombre_Plato, Decimal Precio_Plato, string Descripcion_Plato, int Rut_Personal_Cocinero)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_RegistrarPlato";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre_Plato", Nombre_Plato);
            comando.Parameters.AddWithValue("@Precio_Plato", Precio_Plato);
            comando.Parameters.AddWithValue("@Descripcion_Plato", Descripcion_Plato);
            comando.Parameters.AddWithValue("@Rut_Personal_Cocinero", Rut_Personal_Cocinero);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string Nombre_Plato, Decimal Precio_Plato, string Descripcion_Plato, int Rut_Personal_Cocinero, int cod_plato)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ModificarPlato";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre_Plato", Nombre_Plato);
            comando.Parameters.AddWithValue("@Precio_Plato", Precio_Plato);
            comando.Parameters.AddWithValue("@Descripcion_Plato", Descripcion_Plato);
            comando.Parameters.AddWithValue("@Rut_Personal_Cocinero", Rut_Personal_Cocinero);
            comando.Parameters.AddWithValue("@cod_plato", cod_plato);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int cod_plato)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_EliminarPlato";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cod_plato", cod_plato);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
