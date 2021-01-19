using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class NombradaBL
    {

        public List<NombradaEL> ListarNombrada(NombradaEL objNombrada)
        {
            NombradaDAL oNombrada = new NombradaDAL();
            return oNombrada.ListarNombrada(objNombrada);
        }

        public List<NombradaExportarEL>ListarNombradaExportar(NombradaEL objNombrada)
        {
            NombradaDAL oNombrada = new NombradaDAL();
            return oNombrada.ListarNombradaExportar(objNombrada);
        }

        public List<NombradaEL> SeleccionarUnidad(NombradaEL objNombrada)
        {
            NombradaDAL oNombrada = new NombradaDAL();
            return oNombrada.SeleccionarUnidad(objNombrada);
        }

        public List<TransaccionEL> RegistrarNombrada(NombradaEL objNombrada)
        {
            NombradaDAL oNombrada = new NombradaDAL();
            return oNombrada.RegistrarNombrada(objNombrada);
        }

        public List<TransaccionEL> ActualizarNombrada(NombradaEL objNombrada)
        {
            NombradaDAL oNombrada = new NombradaDAL();
            return oNombrada.ActualizarNombrada(objNombrada);
        }

        public List<TransaccionEL> EliminarConductor(NombradaEL objNombrada)
        {
            NombradaDAL oNombrada = new NombradaDAL();
            return oNombrada.EliminarConductor(objNombrada);
        }

        public List<NombradaEL> ListarConductor()
        {
            NombradaDAL oNombrada = new NombradaDAL();
            return oNombrada.ListarConductores();
        }

        public List<NombradaEL> ListarUnidad()
        {
            NombradaDAL oNombrada = new NombradaDAL();
            return oNombrada.ListarUnidades();
        }

        public List<TransaccionEL> AgregarConductor(NombradaEL objNombrada)
        {
            NombradaDAL oNombrada = new NombradaDAL();
            return oNombrada.AgregarConductor(objNombrada);
        }


        public List<NombradaEL> VerificarConductor(NombradaEL objNombrada) {
            NombradaDAL oNombrada = new NombradaDAL();
            return oNombrada.VerificarConductor(objNombrada);
        }

        public List<NombradaEL> VerificarUnidad(NombradaEL objNombrada)
        {
            NombradaDAL oNombrada = new NombradaDAL();
            return oNombrada.VerificarUnidad(objNombrada);
        }





    }
}
