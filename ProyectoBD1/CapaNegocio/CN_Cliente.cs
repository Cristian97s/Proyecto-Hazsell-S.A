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
     public class CN_Cliente
     {
        private CD_Cliente objetoCD = new CD_Cliente();

        public DataTable MostrarCli()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarCli(string Nombre_Cliente, string Apellido_Cliente, string Direccion_Cliente, string Telefono_Cliente, string Tipo_Cliente, DateTime Fecha_Nac_Cliente, string Observaciones_Cliente)
        {
            objetoCD.Insertar(Nombre_Cliente, Apellido_Cliente, Direccion_Cliente, Telefono_Cliente, Tipo_Cliente, Fecha_Nac_Cliente, Observaciones_Cliente);
        }

        public void EditarCli(string Nombre_Cliente, string Apellido_Cliente, string Direccion_Cliente, string Telefono_Cliente, string Tipo_Cliente, DateTime Fecha_Nac_Cliente, string Observaciones_Cliente, string Rut_Cliente)
        {
            objetoCD.Editar(Nombre_Cliente, Apellido_Cliente, Direccion_Cliente, Telefono_Cliente, Tipo_Cliente, Fecha_Nac_Cliente, Observaciones_Cliente, Convert.ToInt32( Rut_Cliente));
        }

        public void EliminarCli(string Rut_Cliente)
        {
            objetoCD.Eliminar(Convert.ToInt32(Rut_Cliente));
        }
     }
}

