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
    public class CN_Plato
    {
        private CD_Plato objetoCD = new CD_Plato();

        public DataTable MostrarPla()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public DataTable MostrarPla2()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar2();
            return tabla;
        }

        public void InsertarPla(string Nombre_Plato, string Precio_Plato, string Descripcion_Plato, int Rut_Personal_Cocinero)
        {
            objetoCD.Insertar(Nombre_Plato, Convert.ToDecimal(Precio_Plato), Descripcion_Plato, Convert.ToInt32(Rut_Personal_Cocinero));
        }

        public void EditarPla(string Nombre_Plato, string Precio_Plato, string Descripcion_Plato, int Rut_Personal_Cocinero, string cod_plato)
        {
            objetoCD.Editar(Nombre_Plato, Convert.ToDecimal(Precio_Plato), Descripcion_Plato, Convert.ToInt32(Rut_Personal_Cocinero), Convert.ToInt32(cod_plato));
        }

        public void EliminarPla(string cod_plato)
        {
            objetoCD.Eliminar(Convert.ToInt32(cod_plato));
        }
    }
}
