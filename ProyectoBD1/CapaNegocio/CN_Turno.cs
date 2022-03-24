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
    public class CN_Turno
    {
        private CD_Turno objetoCD = new CD_Turno();

        public DataTable MostrarTu()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarTu(string Descripcion)
        {
            objetoCD.Insertar(Descripcion);
        }

        public void EditarTu(string Descripcion, string cod_Turno)
        {
            objetoCD.Editar(Descripcion, Convert.ToInt32(cod_Turno));
        }

        public void EliminarTu(string cod_Turno)
        {
            objetoCD.Eliminar(Convert.ToInt32(cod_Turno));
        }
    }
}
