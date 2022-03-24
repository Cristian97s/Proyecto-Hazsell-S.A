using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_DetallePedido
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
            comando.CommandText = "usp_ObtenerDetallePedido";
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
        public void Insertar(int Id_Pedido, int cod_plato, string Menu)
        {
            ///PROCEDURE SQL

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_RegistrarDetallePedido";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id_Pedido", Id_Pedido);
            comando.Parameters.AddWithValue("@cod_plato", cod_plato);
            comando.Parameters.AddWithValue("@Menu", Menu);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(int Id_Pedido, int cod_plato, string Menu, int Id_DetallePedido)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ModificarDetallePedido";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id_Pedido", Id_Pedido);
            comando.Parameters.AddWithValue("@cod_plato", cod_plato);
            comando.Parameters.AddWithValue("@Menu", Menu);
            comando.Parameters.AddWithValue("@Id_DetallePedido", Id_DetallePedido);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int Id_DetallePedido)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_EliminarDetallePedido";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id_DetallePedido", Id_DetallePedido);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
