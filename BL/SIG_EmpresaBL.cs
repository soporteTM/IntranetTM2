using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SIG_EmpresaBL
    {
        public List<SIG_EmpresaEL> ListarSolicitud()
        {
            SIG_EmpresaDAL oEmp = new SIG_EmpresaDAL();
            return oEmp.ListarSolicitud();
        }
        public List<SIG_EmpresaEL> RepuestaSolicitud(SIG_EmpresaEL oEmpresa)
        {
            SIG_EmpresaDAL oEmp = new SIG_EmpresaDAL();
            return oEmp.RepuestaSolicitud(oEmpresa);
        }
    }
}
