using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EquipoProteccionBL
    {
        EquipoProteccionDAL oEquipo = new EquipoProteccionDAL();

        public List<EquipoProteccionEL> ListarProteccion(int idPersonal,string tabla)
        {
            return oEquipo.ListarProteccion(idPersonal,tabla);
        }

        public DataTable ExportarEPP(int idPersonal)
        {
            return oEquipo.ExportarEPP(idPersonal);
        }

        public List<TransaccionEL> RegistrarEPP(EquipoProteccionEL EquipoEl)
        {
            return oEquipo.RegistrarEPP(EquipoEl);
        }
        public List<EquipoProteccionEL> ListarProteccionHistorico(int idPersonal,string cod_equipo)
        {
            return oEquipo.ListarProteccionHistorico(idPersonal,cod_equipo);
        }

    }
}
