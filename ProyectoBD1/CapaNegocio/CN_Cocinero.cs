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
    public class CN_Cocinero
    {
        private CD_Cocinero objetoCD = new CD_Cocinero();

        public DataTable MostrarCoc()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public DataTable MostrarCoc2()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar2();
            return tabla;
        }
        public DataTable MostrarCoc3()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar3();
            return tabla;
        }
        public void InsertarCoc(string Nombre_Cocinero, string Apellido_Cocinero, string Telefono_Cocinero, string Direccion_Cocinero, int cod_Tipo, int cod_Turno)
        {
            objetoCD.Insertar(Nombre_Cocinero, Apellido_Cocinero, Telefono_Cocinero, Direccion_Cocinero, Convert.ToInt32(cod_Tipo), Convert.ToInt32(cod_Turno));
        }

        public void EditarCoc(string Nombre_Cocinero, string Apellido_Cocinero, string Telefono_Cocinero, string Direccion_Cocinero, int cod_Tipo, int cod_Turno, string Rut_Personal_Cocinero)
        {
            objetoCD.Editar(Nombre_Cocinero, Apellido_Cocinero, Telefono_Cocinero, Direccion_Cocinero, Convert.ToInt32(cod_Tipo), Convert.ToInt32(cod_Turno), Convert.ToInt32(Rut_Personal_Cocinero));
        }

        public void EliminarCoc(string Rut_Personal_Cocinero)
        {
            objetoCD.Eliminar(Convert.ToInt32(Rut_Personal_Cocinero));
        }
    }
}
