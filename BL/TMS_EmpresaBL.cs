using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using DAL;

namespace BL
{
    public class TMS_EmpresaBL
    {
        public TMS_EmpresaEL ValoresGeneralesEmpresas()
        {
            TMS_EmpresaEL LocalesEL = new TMS_EmpresaEL();
            LocalesEL.ENT_CODI = "*";
            LocalesEL.ENT_DIRE = "*";
            LocalesEL.ENT_Empresa = "*";
            LocalesEL.ENT_NOMC = "*";
            LocalesEL.ENT_RSOC = "*";
            LocalesEL.ENT_RUC = "*";

            return LocalesEL;
        }

        public List<TMS_EmpresaEL> ListarEmpresas(TMS_EmpresaEL locales)
        {
            TMS_EmpresaDAL oNave = new TMS_EmpresaDAL();
            return oNave.ListarEmpresas(locales);
        }

    }
}
