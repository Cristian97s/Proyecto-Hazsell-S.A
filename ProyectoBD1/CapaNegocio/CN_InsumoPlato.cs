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
    public class CN_InsumoPlato
    {
        private CD_InsumoPlato objetoCD = new CD_InsumoPlato();

        public DataTable MostrarInspla()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public DataTable MostrarInspla2()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar2();
            return tabla;
        }
        public DataTable MostrarInspla3()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar3();
            return tabla;
        }
        public void InsertarInspla(int cod_plato, int cod_insumo, string cantidad_insumo_utilidado)
        {
            objetoCD.Insertar(Convert.ToInt32(cod_plato), Convert.ToInt32(cod_insumo), Convert.ToInt32(cantidad_insumo_utilidado));
        }

        public void EditarInspla(int cod_plato, int cod_insumo, string cantidad_insumo_utilidado, string Id_InsumoPlato)
        {
            objetoCD.Editar(Convert.ToInt32(cod_plato), Convert.ToInt32(cod_insumo), Convert.ToInt32(cantidad_insumo_utilidado), Convert.ToInt32(Id_InsumoPlato));
        }

        public void EliminarInspla(string Id_InsumoPlato)
        {
            objetoCD.Eliminar(Convert.ToInt32(Id_InsumoPlato));
        }
    }
}
