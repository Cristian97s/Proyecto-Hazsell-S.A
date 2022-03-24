using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Cliente
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        ///Rut_Cliente,Nombre_Cliente,Direccion_Cliente,Telefono_Cliente,Tipo_Cliente,Fecha_Nac_Cliente,Observaciones_Cliente
        public DataTable Mostrar()
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

        public void Insertar(string Nombre_Cliente, string Apellido_Cliente, string Direccion_Cliente, string Telefono_Cliente, string Tipo_Cliente, DateTime Fecha_Nac_Cliente,string Observaciones_Cliente)
        {
            ///PROCEDURE SQL
            
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_RegistrarCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre_Cliente", Nombre_Cliente);
            comando.Parameters.AddWithValue("@Apellido_Cliente", Apellido_Cliente);
            comando.Parameters.AddWithValue("@Direccion_Cliente", Direccion_Cliente);
            comando.Parameters.AddWithValue("@Telefono_Cliente", Telefono_Cliente);
            comando.Parameters.AddWithValue("@Tipo_Cliente", Tipo_Cliente);
            comando.Parameters.AddWithValue("@Fecha_Nac_Cliente", Fecha_Nac_Cliente);
            comando.Parameters.AddWithValue("@Observaciones_Cliente", Observaciones_Cliente);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string Nombre_Cliente, string Apellido_Cliente, string Direccion_Cliente, string Telefono_Cliente, string Tipo_Cliente, DateTime Fecha_Nac_Cliente, string Observaciones_Cliente, int Rut_Cliente)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ModificarCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre_Cliente", Nombre_Cliente);
            comando.Parameters.AddWithValue("@Apellido_Cliente", Apellido_Cliente);
            comando.Parameters.AddWithValue("@Direccion_Cliente", Direccion_Cliente);
            comando.Parameters.AddWithValue("@Telefono_Cliente", Telefono_Cliente);
            comando.Parameters.AddWithValue("@Tipo_Cliente", Tipo_Cliente);
            comando.Parameters.AddWithValue("@Fecha_Nac_Cliente", Fecha_Nac_Cliente);
            comando.Parameters.AddWithValue("@Observaciones_Cliente", Observaciones_Cliente);
            comando.Parameters.AddWithValue("@Rut_Cliente", Rut_Cliente);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int Rut_Cliente)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_EliminarCliente";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Rut_Cliente", Rut_Cliente);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}
