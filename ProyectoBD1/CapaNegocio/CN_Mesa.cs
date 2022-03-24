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
    public class CN_Mesa
    {
        private CD_Mesa objetoCD = new CD_Mesa();

        public DataTable MostrarMe()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarMe(int Cant_Max_Comensales, string Ubicacion)
        {
            objetoCD.Insertar(Cant_Max_Comensales,Ubicacion);
        }

        public void EditarMe(int Cant_Max_Comensales, string Ubicacion, string Num_Mesa)
        {
            objetoCD.Editar(Cant_Max_Comensales, Ubicacion, Convert.ToInt32(Num_Mesa));
        }

        public void EliminarMe(string Num_Mesa)
        {
            objetoCD.Eliminar(Convert.ToInt32(Num_Mesa));
        }
    }
}
