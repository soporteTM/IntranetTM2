using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ContenedorBL
    {
        public List<TransaccionEL> RegistarContenedor(ContenedorEL oContenedor)
        {
            ContenedorDAL objContenedor = new ContenedorDAL();
            return objContenedor.RegistrarContenedor(oContenedor);
        }

        public List<ContenedorEL> ListarContenedor(ContenedorEL oContenedorEL)
        {
            ContenedorDAL oContenedor = new ContenedorDAL();
            return oContenedor.ListarContenedor(oContenedorEL);
        }

        public List<ContenedorExportaEL> ListarContenedorExportar(ContenedorEL oContenedorEL)
        {
            ContenedorDAL oContenedor = new ContenedorDAL();
            return oContenedor.ListarContenedorExportar(oContenedorEL);
        }

        public List<ContenedorExportaEL> ListarContenedorExportarxFecha(ContenedorExportaEL oContenedorEL)
        {
            ContenedorDAL oContenedor = new ContenedorDAL();
            return oContenedor.ListarContenedorExportarxFecha(oContenedorEL);
        }

        public List<TransaccionEL> ConsultarNaveSeguimiento(ContenedorEL oContenedorEL)
        {
            ContenedorDAL oContenedor = new ContenedorDAL();
            return oContenedor.ConsultaSeguimiento(oContenedorEL);
        }

        public List<ContenedorEL> EliminarContenedor(ContenedorEL oContenedorEL)
        {
            ContenedorDAL oContenedor = new ContenedorDAL();
            return oContenedor.EliminarContenedor(oContenedorEL);
        }


        public List<TransaccionEL> ConfirmarContenedor(ContenedorEL contenedorEL)
        {
            ContenedorDAL oContenedor = new ContenedorDAL();
            return oContenedor.VerificarContenedor(contenedorEL);
        }

        public List<TransaccionEL> ConsultarSeguimiento(ContenedorEL contenedorEL)
        {
            ContenedorDAL oContenedor = new ContenedorDAL();
            return oContenedor.ConsultarSeguimiento(contenedorEL);
        }

        public List<ContenedorEL> ContenedoresDescarga(NaveEL naveEL)
        {
            ContenedorDAL oContenedor = new ContenedorDAL();
            return oContenedor.ContenedoresDescarga(naveEL);
        }

        public List<ContenedorEL> ActualizarContenedor(ContenedorEL oContenedorEL)
        {
            ContenedorDAL oContenedor = new ContenedorDAL();
            return oContenedor.ActualizarContenedor(oContenedorEL);
        }


    }
}
