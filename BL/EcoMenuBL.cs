using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EcoMenuBL
    {
        
        public List<EcoMenuEL> ListarMenu(EcoMenuEL menuEL)
        {
            EcoMenuDAL menuDAL = new EcoMenuDAL();
            return menuDAL.ListarMenu(menuEL);
        }
    }

    public class EcoPerfilBL
    {
        public List<EcoPerfilEL> ListarPefil()
        {
            EcoPerfilDAL perfilDAL = new EcoPerfilDAL();
            return perfilDAL.ListarPerfil();
        }
    }
}
