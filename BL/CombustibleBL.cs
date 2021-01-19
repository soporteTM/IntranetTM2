using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CombustibleBL
    {
        CombustibleDAL objCombustible = new CombustibleDAL();

        public List<TransaccionEL> Registrar_Combustible(CombustibleEL oCab)
        {
            return objCombustible.Registar_Combustible(oCab);
        }

        public List<CombustibleEL> Listar_Cabecera()
        {           
            return objCombustible.Listar_Cabecera();
        }

        public List<TransaccionEL> EliminarCabeceraDetalle(CombustibleEL oCombustible)
        {            
            return objCombustible.EliminarCabeceraDetalle(oCombustible);
        }
        public List<CombustibleEL> ConsultarFecha(string fecha_inicio, string fecha_corte)
        {
            return objCombustible.ConsultarFecha(fecha_inicio, fecha_corte);
        }

    }

    public class CombustibleCompraBL
    {
        CombustibleCompraDAL objCombustible = new CombustibleCompraDAL();
        public List<CombustibleCompraEL> RegistrarCompraCombustible(CombustibleCompraEL oCab)
        {
            return objCombustible.RegistrarCompraCombustible(oCab);
        }

        public List<CombustibleCompraEL> ListarCompraCombustible()
        {
            return objCombustible.ListarCompraCombustible();
        }

        public List<CombustibleCompraEL> EliminarCompraCombustible(CombustibleCompraEL oCab)
        {
            return objCombustible.EliminarCompraCombustible(oCab);
        }
    }
}
