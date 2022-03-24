using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Mesero
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
            comando.CommandText = "usp_ObtenerPersonalMesero";
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
        public void Insertar(string Nombre_Mesero, string Apellido_Mesero, string Telefono_Mesero, string Direccion_Mesero, int cod_Tipo, int cod_Turno)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_RegistrarPersonalMesero";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre_Mesero", Nombre_Mesero);
            comando.Parameters.AddWithValue("@Apellido_Mesero", Apellido_Mesero);
            comando.Parameters.AddWithValue("@Telefono_Mesero", Telefono_Mesero);
            comando.Parameters.AddWithValue("@Direccion_Mesero", Direccion_Mesero);
            comando.Parameters.AddWithValue("@cod_Tipo", cod_Tipo);
            comando.Parameters.AddWithValue("@cod_Turno", cod_Turno);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string Nombre_Mesero, string Apellido_Mesero, string Telefono_Mesero, string Direccion_Mesero, int cod_Tipo, int cod_Turno, int Rut_Personal_Mesero)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ModificarPersonalMesero";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre_Mesero", Nombre_Mesero);
            comando.Parameters.AddWithValue("@Apellido_Mesero", Apellido_Mesero);
            comando.Parameters.AddWithValue("@Telefono_Mesero", Telefono_Mesero);
            comando.Parameters.AddWithValue("@Direccion_Mesero", Direccion_Mesero);
            comando.Parameters.AddWithValue("@Rut_Personal_Mesero", Rut_Personal_Mesero);
            comando.Parameters.AddWithValue("@cod_Tipo", cod_Tipo);
            comando.Parameters.AddWithValue("@cod_Turno", cod_Turno);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int Rut_Personal_Mesero)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_EliminarPersonalMesero";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Rut_Personal_Mesero", Rut_Personal_Mesero);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
