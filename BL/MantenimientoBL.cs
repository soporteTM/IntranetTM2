using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MantenimientoBL
    {
        public List<ItemEL> ListarDepartamento()
        {
            MantenimientoDAL oItem = new MantenimientoDAL();
            return oItem.ListarDepartamento();
        }

        public List<ItemEL> ListarProvincia(string cod_dep)
        {
            MantenimientoDAL oItem = new MantenimientoDAL();
            return oItem.ListarProvincia(cod_dep);
        }

        public List<ItemEL> ListarDistrito(string cod_dep,string cod_pro)
        {
            MantenimientoDAL oItem = new MantenimientoDAL();
            return oItem.ListarDistrito(cod_dep,cod_pro);
        }
    }

    public class MantenimientoClienteBL
    {
        public List<MantenimientoClienteEL> ListarCliente()
        {
            MantenimientoClienteDAL Cliente = new MantenimientoClienteDAL();
            return Cliente.ListarCliente();
        }

        public List<MantenimientoClienteEL> InsertarCliente(MantenimientoClienteEL oCliente)
        {
            MantenimientoClienteDAL Cliente = new MantenimientoClienteDAL();
            return Cliente.InsertarCliente(oCliente);
        }

        public List<MantenimientoClienteEL> ModificarCliente(MantenimientoClienteEL oCliente)
        {
            MantenimientoClienteDAL Cliente = new MantenimientoClienteDAL();
            return Cliente.ModificarCliente(oCliente);
        }

        public List<MantenimientoClienteEL> EliminarCliente(MantenimientoClienteEL oCliente)
        {
            MantenimientoClienteDAL Cliente = new MantenimientoClienteDAL();
            return Cliente.EliminarCliente(oCliente);
        }
    }
    public class MantenimientoLocalBL
    {
        public List<MantenimientoLocalEL> ListarLocal(int oLocal)
        {
            MantenimientoLocalDAL Local = new MantenimientoLocalDAL();
            return Local.ListarLocal(oLocal);
        }

        public List<MantenimientoLocalEL> InsertarLocal(MantenimientoLocalEL oLocal)
        {
            MantenimientoLocalDAL Local = new MantenimientoLocalDAL();
            return Local.InsertarLocal(oLocal);
        }

        public List<MantenimientoLocalEL> ModificarLocal(MantenimientoLocalEL oLocal)
        {
            MantenimientoLocalDAL Local = new MantenimientoLocalDAL();
            return Local.ModificarLocal(oLocal);
        }

        public List<MantenimientoLocalEL> EliminarLocal(MantenimientoLocalEL oLocal)
        {
            MantenimientoLocalDAL Local = new MantenimientoLocalDAL();
            return Local.EliminarLocal(oLocal);
        }
    }
    public class MantenimientoContactoBL
    {
        MantenimientoContactoDAL Contacto = new MantenimientoContactoDAL();
        public List<MantenimientoContactoEL> ListarContacto(MantenimientoContactoEL oContacto)
        {
            return Contacto.ListarContacto(oContacto);
        }

        public List<TransaccionEL> InsertarContacto(MantenimientoContactoEL oContacto)
        {
            return Contacto.InsertarContacto(oContacto);
        }

        public List<TransaccionEL> ModificarContacto(MantenimientoContactoEL oContacto)
        {
            return Contacto.ModificarContacto(oContacto);
        }

        public List<TransaccionEL> EliminarContacto(MantenimientoContactoEL oContacto)
        {
            return Contacto.EliminarContacto(oContacto);
        }
    }

}
