using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CisternaBL
    {
        public List<CisternaEL> ListarCisterna()
        {
            CisternaDAL oCisterna = new CisternaDAL();
            return oCisterna.ListarCisterna();
        }

        public List<CisternaEL> ListarCisterna(string cisterna, string fechaInicio, string fechaFin, string estado)
        {
            CisternaDAL oCisterna = new CisternaDAL();
            return oCisterna.ListarCisterna(cisterna, fechaInicio, fechaFin, estado);
        }

        public List<CisternaEL> ConsultarCisterna(CisternaEL oCisterna)
        {
            CisternaDAL objCisterna = new CisternaDAL();
            return objCisterna.ConsultarCisterna(oCisterna);
        }

        public List<ItemEL> TM_CisternaConsultar()
        {
            CisternaDAL objCisterna = new CisternaDAL();
            return objCisterna.TM_CisternaConsultar();
        }

        public List<TransaccionEL> RegistrarCisterna(CisternaEL oCisterna)
        {
            CisternaDAL objCisterna = new CisternaDAL();
            return objCisterna.RegistrarCisterna(oCisterna);
        }
        public List<TransaccionEL> RegistrarCisternaRemanente(int id_cisterna_nueva, int id_cisterna)
        {
            CisternaDAL objCisterna = new CisternaDAL();
            return objCisterna.RegistrarCisternaRemanente(id_cisterna_nueva, id_cisterna);
        }
    }
}
