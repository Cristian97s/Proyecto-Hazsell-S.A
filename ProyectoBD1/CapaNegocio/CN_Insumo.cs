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
    public class CN_Insumo
    {
        private CD_Insumo objetoCD = new CD_Insumo();

        public DataTable MostrarIns()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarIns(string nombre_insumo, string cantidad_insumo, string unidad_medida_insumo)
        {
            objetoCD.Insertar(nombre_insumo, Convert.ToDecimal( cantidad_insumo), unidad_medida_insumo);
        }

        public void EditarIns(string nombre_insumo, string cantidad_insumo, string unidad_medida_insumo, string cod_Insumo)
        {
            objetoCD.Editar(nombre_insumo, Convert.ToDecimal(cantidad_insumo), unidad_medida_insumo, Convert.ToInt32(cod_Insumo));
        }

        public void EliminarIns(string cod_Insumo)
        {
            objetoCD.Eliminar(Convert.ToInt32(cod_Insumo));
        }
    }
}
