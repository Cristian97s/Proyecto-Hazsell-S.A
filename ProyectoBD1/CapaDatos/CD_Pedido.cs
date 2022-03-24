using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Pedido
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
            comando.CommandText = "usp_ObtenerPedido";
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
            comando.CommandText = "usp_ObtenerCliente";
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
            comando.CommandText = "usp_ObtenerMesa";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable Mostrar4()
        {
            ///PROCEDURE SQL 
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ObtenerPersonalMesero";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(int Rut_Cliente, string Tipo_Pedido, int Num_Mesa, int Rut_Personal_Mesero, DateTime Fecha_Pedido)
        {
            ///PROCEDURE SQL

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_RegistrarPedido";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Rut_Cliente", Rut_Cliente);
            comando.Parameters.AddWithValue("@Tipo_Pedido", Tipo_Pedido);
            comando.Parameters.AddWithValue("@Num_Mesa", Num_Mesa);
            comando.Parameters.AddWithValue("@Rut_Personal_Mesero", Rut_Personal_Mesero);
            comando.Parameters.AddWithValue("@Fecha_Pedido", Fecha_Pedido);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(int Rut_Cliente, string Tipo_Pedido, int Num_Mesa, int Rut_Personal_Mesero, DateTime Fecha_Pedido, int Id_Pedido)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ModificarPedido";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Rut_Cliente", Rut_Cliente);
            comando.Parameters.AddWithValue("@Tipo_Pedido", Tipo_Pedido);
            comando.Parameters.AddWithValue("@Num_Mesa", Num_Mesa);
            comando.Parameters.AddWithValue("@Rut_Personal_Mesero", Rut_Personal_Mesero);
            comando.Parameters.AddWithValue("@Fecha_Pedido", Fecha_Pedido);
            comando.Parameters.AddWithValue("@Id_Pedido", Id_Pedido);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int Id_Pedido)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_EliminarPedido";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id_Pedido", Id_Pedido);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
