using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BL
{
    public class DescansoMedicoBL
    {
       

        DescansoMedicoDAL objDescanso = new DescansoMedicoDAL();
        public List<DescansoMedicoEL> ListarDescanso(int id , int id_emp, string estadoDM)
        {     
            return objDescanso.ListaDescanso(id , id_emp, estadoDM);
        }

        public List<TransaccionEL> RegistrarDescanso(DescansoMedicoEL DM)
        {
            return objDescanso.RegistrarDescanso(DM);
        }

        public List<TransaccionEL> EliminarDescanso(int id)
        {
            return objDescanso.EliminarDM(id);
        }

        public DataTable ExportarDM(DescansoMedicoEL DM)
        {
            return objDescanso.ExportarDM(DM);
        }

        public List<DescansoMedicoEL> ConsultarFecha(int id_emp, string fecha_inicio, string fecha_fin)
        {
            return objDescanso.ConsultarFecha(id_emp, fecha_inicio, fecha_fin);
        }

        public List<DescansoMedicoEL> BuscarClinica()
        {
            return objDescanso.BuscarClinica();
        }

        //METODO AGREGADO POR RODRIGO ROJAS:
        public List<TransaccionEL> ConsultarDescanso(DescansoMedicoEL oDescanso)
        {
            DescansoMedicoDAL objDescanso = new DescansoMedicoDAL();
            return objDescanso.ConsultarDescanso(oDescanso);
        }


    }
}
