using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_ProveedorInsumo
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
            comando.CommandText = "usp_ObtenerProveedorInsumo";
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
            comando.CommandText = "usp_ObtenerProveedores";
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
            comando.CommandText = "usp_ObtenerInsumo";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(int Rut_Proveedor, int cod_insumo, Decimal Precio_Insumo)
        {
            ///PROCEDURE SQL

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_RegistrarProveedorInsumo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Rut_Proveedor", Rut_Proveedor);
            comando.Parameters.AddWithValue("@cod_Insumo", cod_insumo);
            comando.Parameters.AddWithValue("@Precio_Insumo", Precio_Insumo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(int Rut_Proveedor, int cod_Insumo, Decimal Precio_Insumo, int Id_ProveedorInsumo)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ModificarProveedorInsumo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Rut_Proveedor", Rut_Proveedor);
            comando.Parameters.AddWithValue("@cod_Insumo", cod_Insumo);
            comando.Parameters.AddWithValue("@Precio_Insumo", Precio_Insumo);
            comando.Parameters.AddWithValue("@Id_ProveedorInsumo", Id_ProveedorInsumo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int Id_ProveedorInsumo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_EliminarProveedorInsumo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id_ProveedorInsumo", Id_ProveedorInsumo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
