using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TMS_NotificacionesBL
    {
        TMS_NotificacionesDAL oNotificaciones = new TMS_NotificacionesDAL();

        public List<TMS_NotificacionesEL> ListarNotificacionesXCliente(string Ent_Codi, string movimiento)
        {
            
            return oNotificaciones.ListarNotificacionesXCliente(Ent_Codi, movimiento);
        }

        public List<TransaccionEL> ActualizarNotificaciones(TMS_NotificacionesEL ntf)
        {
            
            return oNotificaciones.ActualizarNotificaciones(ntf);
        }

        public void CrearNotificacionesXCliente(string Ent_Codi, string usuario)
        {
            
            oNotificaciones.CrearNotificacionesXCliente(Ent_Codi, usuario);
        }
    }
}
