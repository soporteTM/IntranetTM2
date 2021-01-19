using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlertaBL
    {
        AlertaDAL oAlerta = new AlertaDAL();
        public List<AlertaEL> ListarAlertas(string ale_perfil, string ale_perfil2)
        {
            return oAlerta.ListarAlertas(ale_perfil,ale_perfil2);
        }

        public List<AlertaEL> ActualizarAlertas(string ale_perfil)
        {
            return oAlerta.ActualizarAlertas(ale_perfil);
        }
    }
}
