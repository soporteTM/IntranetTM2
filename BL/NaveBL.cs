using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class NaveBL
    {
        public List<NaveEL> ListarContenedorNave(string estado)
        {
            NaveDAL oNave = new NaveDAL();
            return oNave.ListarContenedorNave(estado);
        }

        public List<NaveExportarEL> ListarContenedorNaveExportar()
        {
            NaveDAL oNave = new NaveDAL();
            return oNave.ListarContenedorNaveExportar();
        }
        
        public List<TransaccionEL> RegistrarNave(NaveEL oNave)
        {
            NaveDAL objNave = new NaveDAL();
            return objNave.RegistrarNave(oNave);
        }

        public List<TransaccionEL> RegistrarNaveDescarga(NaveEL oNave)
        {
            NaveDAL objNave = new NaveDAL();
            return objNave.RegistrarNaveDescarga(oNave);
        }

        public List<NaveEL> ActualizarNave(NaveEL oNave)
        {
            NaveDAL objNave = new NaveDAL();
            return objNave.ActualizarNave(oNave);
        }

        public List<NaveEL> EliminarNave(NaveEL oNave)
        {
            NaveDAL objNave = new NaveDAL();
            return objNave.EliminarNave(oNave);
        }

        public List<NaveEL> ConsultarNave(NaveEL oNave)
        {
            NaveDAL objNave = new NaveDAL();
            return objNave.ConsultarNave(oNave);
        }

    }
}
