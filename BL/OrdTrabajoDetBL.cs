using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrdTrabajoDetBL
    {
        OrdTrabajoDetDAL ObjDeta = new OrdTrabajoDetDAL();
        public void ActualizarCantidadMateriales(decimal cantidad, int codigo, int id_Detalle)
        {
            ObjDeta.ActualizarCantidadMateriales(cantidad, codigo, id_Detalle);
        }

        public List<OrdTrabajoDetEL> ListarConductores()
        {
            return ObjDeta.ListarConductores();
        }

        public List<OrdTrabajoDetEL> ListarProveedores()
        {
            return ObjDeta.ListarProveedores();
        }
        public List<OrdTrabajoDetEL> ListarTareas(string id_codigo)
        {
            return ObjDeta.ListarTareas(id_codigo);
        }

        public List<OrdTrabajoDetEL> ListarMateriales(string id_codigo)
        {
            return ObjDeta.ListarMateriales(id_codigo);
        }
        public List<OrdTrabajoDetEL> ListarMaterialesTareas(string id_codigo, string id_tarea)
        {
            return ObjDeta.ListarMaterialesTareas(id_codigo, id_tarea);
        }

        public List<OrdTrabajoDetEL> ListarMaterialesOrden(int id_Orden)
        {
             return ObjDeta.ListarMaterialesOrden(id_Orden);
        }

        public List<OrdTrabajoDetEL> ListarMaterialesTareas(string id_codigo)
        {
            return ObjDeta.ListarMaterialesTareas(id_codigo);
        }

        public List<TransaccionEL> Registrar_DetalleOrdenTrabajo(OrdTrabajoDetEL objDet, string Usuario)
        {
            return ObjDeta.Registrar_DetalleOrdenTrabajo(objDet, Usuario);
        }

        public List<TransaccionEL> Registrar_DetalleOrdenTrabajoTarea(OrdTrabajoDetEL objDet, string Usuario)
        {
            return ObjDeta.Registrar_DetalleOrdenTrabajoTarea(objDet, Usuario);
        }

        public List<OrdTrabajoDetEL> Listar_DetalleOrdenesTrabajo_Sistemas_Tareas(int id_Orden) 
        {
            return ObjDeta.Listar_DetalleOrdenesTrabajo_Sistemas_Tareas(id_Orden);
        }

       
    }
}
