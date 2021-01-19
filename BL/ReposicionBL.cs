using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using DAL;

namespace BL
{
   public  class ReposicionBL
    {
       

        public List<ReposicionEL> ListarReposicion(ReposicionEL oReposicion1)
        {
            ReposicionDAL oReposicion = new ReposicionDAL();
            return oReposicion.ListarReposicion(oReposicion1);
        }

        public List<TransaccionEL> Eliminar_Reposicion(ReposicionEL oReposicion)
        {
            ReposicionDAL reposicionDAL = new ReposicionDAL();
            return reposicionDAL.Eliminar_Reposicion(oReposicion);
        }

        public List<ReposicionEL> ListarReposicion_ADM()
        {
            ReposicionDAL oReposicion = new ReposicionDAL();
            return oReposicion.ListarReposicion_ADM();
        }

        public List<ReposicionEL> RegistrarReposicion(ReposicionEL oReposicion)
        {
            ReposicionDAL oRep = new ReposicionDAL();
            return oRep.RegistrarReposicion(oReposicion);
        }

       

        public List<ReposicionEL> ActualizarReposicion(ReposicionEL oReposicion)
        {
            ReposicionDAL oRep = new ReposicionDAL();
            return oRep.ActualizarReposicion(oReposicion);
        }

        public List<ReposicionEL> Asignar_Equipo(ReposicionEL oEntidad)
        {
            ReposicionDAL reposicionDAL = new ReposicionDAL();
            return reposicionDAL.Asignar_Equipo(oEntidad);
        }



    }
}
