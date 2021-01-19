using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CorreoBL
    {
        public List<TransaccionEL> InsertarCorreo(CorreoEL objEmail)
        {
            CorreoDAL oMail = new CorreoDAL();
            return oMail.InsertarCorreo(objEmail);
        }
        
    }
}
