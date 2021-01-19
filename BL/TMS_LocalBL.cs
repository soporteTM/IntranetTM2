using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using DAL;

namespace BL
{
    public class TMS_LocalBL
    {
        public List<TMS_LocalesEL> ListarLocales(string cod_cliente)
        {
            TMS_LocalDAL oLocal = new TMS_LocalDAL();
            return oLocal.ListarLocales(cod_cliente);
        }

        public List<TMS_LocalesEL> GetLocal(string pCliente)
        {
            TMS_LocalDAL oLocal = new TMS_LocalDAL();
            return oLocal.GetLocal(pCliente);
        }

        public List<TMS_LocalesEL> ListarLocales(string cod_cliente,int cod_local)
        {
            TMS_LocalDAL oLocal = new TMS_LocalDAL();
            return oLocal.ListarLocales(cod_cliente,cod_local);
        }
        public string InsertarLocal(TMS_LocalesEL localesEL)
        {
            TMS_LocalDAL oLocal = new TMS_LocalDAL();
            return oLocal.InsertarLocal(localesEL);
        }
        public List<TMS_LocalesEL> ListarProvincias()
        {
            TMS_LocalDAL oLocal = new TMS_LocalDAL();
            return oLocal.ListarProvincias();
        }
        public List<TMS_LocalesEL> ListarDistritos(int cod_provincia)
        {
            TMS_LocalDAL oLocal = new TMS_LocalDAL();
            return oLocal.ListarDistritos(cod_provincia);
        }
    }
}
