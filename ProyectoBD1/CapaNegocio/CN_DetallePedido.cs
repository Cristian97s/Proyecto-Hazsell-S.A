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
    public class CN_DetallePedido
    {
        private CD_DetallePedido objetoCD = new CD_DetallePedido();

        public DataTable MostrarDP()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public DataTable MostrarDP2()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar2();
            return tabla;
        }
        public DataTable MostrarDP3()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar3();
            return tabla;
        }
        public void InsertarDP(int Id_Pedido, int cod_plato, string Menu)
        {
            objetoCD.Insertar(Convert.ToInt32(Id_Pedido), Convert.ToInt32(cod_plato), Menu);
        }

        public void EditarDP(int Id_Pedido, int cod_plato, string Menu, string Id_DetallePedido)
        {
            objetoCD.Editar(Convert.ToInt32(Id_Pedido), Convert.ToInt32(cod_plato), Menu, Convert.ToInt32(Id_DetallePedido));
        }

        public void EliminarDP(string Id_DetallePedido)
        {
            objetoCD.Eliminar(Convert.ToInt32(Id_DetallePedido));
        }
    }
}
