﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Proveedor
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
            comando.CommandText = "usp_ObtenerProveedores";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string Nombre_Proveedor, string Direccion_Proveedor, string Telefono_Proveedor, string Email_Proveedor, string Fax_Proveedor)
        {
            ///PROCEDURE SQL
            
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_RegistrarProveedor";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre_Proveedor", Nombre_Proveedor);
            comando.Parameters.AddWithValue("@Direccion_Proveedor", Direccion_Proveedor);
            comando.Parameters.AddWithValue("@Telefono_Proveedor", Telefono_Proveedor);
            comando.Parameters.AddWithValue("@Email_Proveedor", Email_Proveedor);
            comando.Parameters.AddWithValue("@Fax_Proveedor", Fax_Proveedor);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string Nombre_Proveedor, string Direccion_Proveedor, string Telefono_Proveedor, string Email_Proveedor, string Fax_Proveedor,int Rut_Proveedor)
        {
            ///PROCEDURE SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_ModificarProveedor";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre_Proveedor", Nombre_Proveedor);
            comando.Parameters.AddWithValue("@Direccion_Proveedor", Direccion_Proveedor);
            comando.Parameters.AddWithValue("@Telefono_Proveedor", Telefono_Proveedor);
            comando.Parameters.AddWithValue("@Email_Proveedor", Email_Proveedor);
            comando.Parameters.AddWithValue("@Fax_Proveedor", Fax_Proveedor);
            comando.Parameters.AddWithValue("@Rut_Proveedor", Rut_Proveedor);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int Rut_Proveedor)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "usp_EliminarProveedor";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Rut_Proveedor", Rut_Proveedor);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}
