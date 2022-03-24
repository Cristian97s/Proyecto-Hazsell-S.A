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
    public class CN_Pedido
    {
        private CD_Pedido objetoCD = new CD_Pedido();

        public DataTable MostrarPed()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public DataTable MostrarPed2()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar2();
            return tabla;
        }
        public DataTable MostrarPed3()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar3();
            return tabla;
        }
        public DataTable MostrarPed4()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar4();
            return tabla;
        }
        public void InsertarPed(int Rut_Cliente, string Tipo_Pedido, int Num_Mesa, int Rut_Personal_Mesero, DateTime Fecha_Pedido)
        {
            objetoCD.Insertar(Convert.ToInt32(Rut_Cliente),Tipo_Pedido, Convert.ToInt32(Num_Mesa), Convert.ToInt32(Rut_Personal_Mesero), Fecha_Pedido);
        }

        public void EditarPed(int Rut_Cliente, string Tipo_Pedido, int Num_Mesa, int Rut_Personal_Mesero, DateTime Fecha_Pedido, string Id_Pedido)
        {
            objetoCD.Editar(Convert.ToInt32(Rut_Cliente), Tipo_Pedido, Convert.ToInt32(Num_Mesa), Convert.ToInt32(Rut_Personal_Mesero), Fecha_Pedido, Convert.ToInt32(Id_Pedido));
        }

        public void EliminarPed(string Id_Pedido)
        {
            objetoCD.Eliminar(Convert.ToInt32(Id_Pedido));
        }
    }
}
