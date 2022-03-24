using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Insumo
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
            comando.CommandText = "usp_ObtenerInsumo";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre_insumo, Decimal cantidad_insumo, string unidad_medida_insumo)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_RegistrarInsumo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre_insumo", nombre_insumo);
            comando.Parameters.AddWithValue("@cantidad_insumo", cantidad_insumo);
            comando.Parameters.AddWithValue("@unidad_medida_insumo", unidad_medida_insumo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string nombre_insumo, Decimal cantidad_insumo, string unidad_medida_insumo, int cod_Insumo)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ModificarInsumo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre_insumo", nombre_insumo);
            comando.Parameters.AddWithValue("@cantidad_insumo", cantidad_insumo);
            comando.Parameters.AddWithValue("@unidad_medida_insumo", unidad_medida_insumo);
            comando.Parameters.AddWithValue("@cod_Insumo", cod_Insumo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int cod_Insumo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_EliminarInsumo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cod_Insumo", cod_Insumo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
