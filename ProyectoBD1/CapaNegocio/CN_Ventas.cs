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
    public class CN_Ventas
    {
        private CD_Ventas objetoCD = new CD_Ventas();

        public DataTable MostrarVe()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public DataTable MostrarVe2()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar2();
            return tabla;
        }
        public void InsertarVe(string Tipo_Venta, string Propina, string PagoCon, DateTime Fecha_Venta, int Id_Pedido)
        {
            objetoCD.Insertar(Tipo_Venta, Convert.ToDecimal(Propina), Convert.ToDecimal(PagoCon), Fecha_Venta, Convert.ToInt32(Id_Pedido));
        }

        public void EditarVe(string Tipo_Venta, string Propina, string PagoCon, DateTime Fecha_Venta, int Id_Pedido, string Cod_Venta)
        {
            objetoCD.Editar(Tipo_Venta, Convert.ToDecimal(Propina), Convert.ToDecimal(PagoCon), Fecha_Venta, Convert.ToInt32(Id_Pedido), Convert.ToInt32(Cod_Venta));
        }

        public void EliminarVe(string Cod_Venta)
        {
            objetoCD.Eliminar(Convert.ToInt32(Cod_Venta));
        }
    }
}
