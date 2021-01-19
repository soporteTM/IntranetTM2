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
    public class GrifoBL
    {
        public List<TransaccionEL> RegistrarGrifo(GrifoEL oGrifo)
        {
            GrifoDAL objCisterna = new GrifoDAL();
            return objCisterna.RegistarGrifo(oGrifo);
        }

        public List<GrifoEL> ListarGrifo()
        {
            GrifoDAL objCisterna = new GrifoDAL();
            return objCisterna.ListarGrifo();
        }
        public List<GrifoEL> CerrarGrifo(int cod)
        {
            GrifoDAL objCisterna = new GrifoDAL();
            return objCisterna.CerrarGrifo(cod);
        }
    }

    public class GrifoDetBL
    {
        public List<TransaccionEL> RegistrarGrifoDet(GrifoDetEL oGrifo)
        {
            GrifoDetDAL objCisterna = new GrifoDetDAL();
            return objCisterna.RegistarGrifoDet(oGrifo);
        }

        public List<GrifoDetEL> ListarGrifoDet(int cod)
        {
            GrifoDetDAL objCisterna = new GrifoDetDAL();
            return objCisterna.ListarGrifoDet(cod);
        }

        public List<GrifoDetEL> EliminarGrifoDet(int cod)
        {
            GrifoDetDAL objCisterna = new GrifoDetDAL();
            return objCisterna.EliminarGrifoDet(cod);
        }

        public List<GrifoDetEL> ListarGrifoDet(int cod,int cli)
        {
            GrifoDetDAL objCisterna = new GrifoDetDAL();
            return objCisterna.ListarGrifoDet(cod,cli);
        }

        public DataTable ReporteGrifoDet(int cod)
        {
            GrifoDetDAL objCisterna = new GrifoDetDAL();
            return objCisterna.ReporteGrifoDet(cod);
        }
    }
}
