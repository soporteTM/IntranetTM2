using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CombustibleDetBL
    {
        public List<TransaccionEL> Registrar_Detalle(CombustibleDetEL oDet)
        {
            CombustibleDetDAL objDet = new CombustibleDetDAL();
            return objDet.Registar_Detalle(oDet);
        }

        public List<CombustibleDetEL> Listar_Detalle(int id_cabecera)
        {
            CombustibleDetDAL objDeta = new CombustibleDetDAL();
            return objDeta.Listar_Detalle(id_cabecera);
        }
    }
}
