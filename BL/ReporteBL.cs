using DAL;
using EL;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ReporteBL
    {
        ReporteDAL oAlerta = new ReporteDAL();
        public DataTable ReporteSeguimiento(string contenedor, string placa, int empresa, string fchIni, string fchFin, string emp)
        {
            return oAlerta.ReporteSeguimiento(contenedor,  placa,  empresa,  fchIni,  fchFin,  emp);
        }

        public List<AlertaEL> ActualizarAlertas(string ale_perfil)
        {
            return oAlerta.ActualizarAlertas(ale_perfil);
        }
    }
}
