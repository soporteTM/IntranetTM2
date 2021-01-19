using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrdTrabajoBL
    {
        OrdTrabajoDAL objDeta = new OrdTrabajoDAL();

        public List<TransaccionEL> Registrar_OrdTrabajo(OrdTrabajoEL oTarEL, string Usuario)
        {
            return objDeta.Registrar_OrdTrabajo(oTarEL, Usuario);
        }

        public List<TransaccionEL> Editar_OrdenTrabajo(OrdTrabajoEL oTarEL, int id_Orden, string Usuario)
        {
            return objDeta.Editar_OrdenTrabajo(oTarEL, id_Orden, Usuario);
        }

        public List<OrdTrabajoEL> Eliminar_OrdenTrabajo(int id_Orden)
        {
            return objDeta.Eliminar_OrdenTrabajo(id_Orden);
        }

        public List<OrdTrabajoEL> Listar_OrdenesTrabajo()
        {
            return objDeta.Listar_OrdenesTrabajo();
        }

        public List<OrdTrabajoEL> Listar_DetalleOrdenesTrabajos(int id_Orden)
        {
            return objDeta.Listar_DetalleOrdenesTrabajos(id_Orden);
        }


    }
}
