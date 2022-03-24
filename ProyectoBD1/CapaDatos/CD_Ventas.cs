using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Ventas
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
            comando.CommandText = "usp_ObtenerVenta";
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
            comando.CommandText = "usp_ObtenerPedido";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(string Tipo_Venta, Decimal Propina, Decimal PagoCon, DateTime Fecha_Venta, int Id_Pedido)
        {
            ///PROCEDURE SQL

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_RegistrarVenta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Tipo_Venta", Tipo_Venta);
            comando.Parameters.AddWithValue("@Propina", Propina);
            comando.Parameters.AddWithValue("@PagoCon", PagoCon);
            comando.Parameters.AddWithValue("@Fecha_Venta", Fecha_Venta);
            comando.Parameters.AddWithValue("@Id_Pedido", Id_Pedido);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string Tipo_Venta, Decimal Propina, Decimal PagoCon, DateTime Fecha_Venta, int Id_Pedido, int Cod_Venta)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ModificarVenta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Tipo_Venta", Tipo_Venta);
            comando.Parameters.AddWithValue("@Propina", Propina);
            comando.Parameters.AddWithValue("@PagoCon", PagoCon);
            comando.Parameters.AddWithValue("@Fecha_Venta", Fecha_Venta);
            comando.Parameters.AddWithValue("@Id_Pedido", Id_Pedido);
            comando.Parameters.AddWithValue("@Cod_Venta", Cod_Venta);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int Cod_Venta)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_EliminarVenta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cod_Venta", Cod_Venta);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
