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
    public class CN_Mesero
    {
        private CD_Mesero objetoCD = new CD_Mesero();

        public DataTable MostrarMese()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public DataTable MostrarMese2()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar2();
            return tabla;
        }
        public DataTable MostrarMese3()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar3();
            return tabla;
        }
        public void InsertarMese(string Nombre_Mesero, string Apellido_Mesero, string Telefono_Mesero, string Direccion_Mesero, int cod_Tipo, int cod_Turno)
        {
            objetoCD.Insertar(Nombre_Mesero, Apellido_Mesero, Telefono_Mesero, Direccion_Mesero, Convert.ToInt32(cod_Tipo), Convert.ToInt32(cod_Turno));
        }

        public void EditarMese(string Nombre_Mesero, string Apellido_Mesero, string Telefono_Mesero, string Direccion_Mesero, int cod_Tipo, int cod_Turno, string Rut_Personal_Mesero)
        {
            objetoCD.Editar(Nombre_Mesero, Apellido_Mesero, Telefono_Mesero, Direccion_Mesero, Convert.ToInt32(cod_Tipo), Convert.ToInt32(cod_Turno), Convert.ToInt32(Rut_Personal_Mesero));
        }

        public void EliminarMese(string Rut_Personal_Mesero)
        {
            objetoCD.Eliminar(Convert.ToInt32(Rut_Personal_Mesero));
        }
    }
}
