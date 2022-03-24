using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_InsumoPlato
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
            comando.CommandText = "usp_ObtenerInsumoPlato";
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
            comando.CommandText = "usp_ObtenerInsumo";
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
            comando.CommandText = "usp_ObtenerPlato";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(int cod_plato, int cod_insumo, int cantidad_insumo_utilidado)
        {
            ///PROCEDURE SQL

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_RegistrarInsumoPlato";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cod_plato", cod_plato);
            comando.Parameters.AddWithValue("@cod_insumo", cod_insumo);
            comando.Parameters.AddWithValue("@cantidad_insumo_utilidado", cantidad_insumo_utilidado);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(int cod_plato, int cod_insumo, int cantidad_insumo_utilidado, int Id_InsumoPlato)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ModificarInsumoPlato";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cod_plato", cod_plato);
            comando.Parameters.AddWithValue("@cod_insumo", cod_insumo);
            comando.Parameters.AddWithValue("@cantidad_insumo_utilidado", cantidad_insumo_utilidado);
            comando.Parameters.AddWithValue("@Id_InsumoPlato", Id_InsumoPlato);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int Id_InsumoPlato)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_EliminarInsumoPlato";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id_InsumoPlato", Id_InsumoPlato);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
