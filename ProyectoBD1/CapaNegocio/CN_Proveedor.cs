using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
     public class CN_Proveedor
    {
        private CD_Proveedor objetoCD = new CD_Proveedor();

        public DataTable MostrarProve()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarProve (string Nombre_Proveedor, string Direccion_Proveedor, string Telefono_Proveedor, string Email_Proveedor, string Fax_Proveedor)
        {
            objetoCD.Insertar(Nombre_Proveedor,Direccion_Proveedor,Telefono_Proveedor,Email_Proveedor,Fax_Proveedor);
        }

        public void EditarProve (string Nombre_Proveedor, string Direccion_Proveedor, string Telefono_Proveedor, string Email_Proveedor, string Fax_Proveedor, string Rut_Proveedor)
        {
            objetoCD.Editar(Nombre_Proveedor, Direccion_Proveedor, Telefono_Proveedor, Email_Proveedor, Fax_Proveedor,Convert.ToInt32( Rut_Proveedor));
        }

        public void EliminarProve(string Rut_Proveedor)
        {
            objetoCD.Eliminar(Convert.ToInt32(Rut_Proveedor));
        }
    }
}

