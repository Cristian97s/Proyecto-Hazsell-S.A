using Sistema_Restaurante.Datos;
using Sistema_Restaurante.Entidad;
using System.Data;

namespace Sistema_Restaurante.Negocios
{
    public class CN_Usuario
    {
        CD_Usuario objd = new CD_Usuario();
        public DataTable CN_User(CE_Usuario obje)
        {
            return objd.Logear(obje);
        }
    }
}
