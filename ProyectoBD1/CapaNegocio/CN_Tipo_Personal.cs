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
    public class CN_Tipo_Personal
    {
        private CD_Tipo_Personal objetoCD = new CD_Tipo_Personal();

        public DataTable MostrarTP()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarTP(string Descripcion)
        {
            objetoCD.Insertar(Descripcion);
        }

        public void EditarTP(string Descripcion, string cod_Tipo)
        {
            objetoCD.Editar(Descripcion, Convert.ToInt32(cod_Tipo));
        }

        public void EliminarTP(string cod_Tipo)
        {
            objetoCD.Eliminar(Convert.ToInt32(cod_Tipo));
        }
    }
}
