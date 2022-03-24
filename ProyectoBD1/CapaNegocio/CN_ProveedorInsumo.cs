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
    public class CN_ProveedorInsumo
    {
        private CD_ProveedorInsumo objetoCD = new CD_ProveedorInsumo();

        public DataTable MostrarPI()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public DataTable MostrarPI2()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar2();
            return tabla;
        }
        public DataTable MostrarPI3()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar3();
            return tabla;
        }
        public void InsertarPI(int Rut_Proveedor, int cod_insumo, string Precio_Insumo)
        {
            objetoCD.Insertar(Convert.ToInt32(Rut_Proveedor), Convert.ToInt32(cod_insumo), Convert.ToDecimal(Precio_Insumo));
        }

        public void EditarPI(int Rut_Proveedor, int cod_Insumo, string Precio_Insumo, string Id_ProveedorInsumo)
        {
            objetoCD.Editar(Convert.ToInt32(Rut_Proveedor),Convert.ToInt32(cod_Insumo), Convert.ToDecimal(Precio_Insumo), Convert.ToInt32(Id_ProveedorInsumo));
        }

        public void EliminarPI(string Id_ProveedorInsumo)
        {
            objetoCD.Eliminar(Convert.ToInt32(Id_ProveedorInsumo));
        }
    }
}
