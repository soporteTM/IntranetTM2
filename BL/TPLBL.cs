using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BL
{
    public class TPL_BL
    {
        TPL_DAL oTPL = new TPL_DAL();
        public DataTable BuscarSolicitud(int parTipoSOl, string parMovimiento, string parEstado, string parCliente, int parItem, int parRo, string parSeguimiento,
            DateTime parFecIni, DateTime parFecFin, string parEmp, string parAnal, string pContenedor)
        {
            return oTPL.BuscarSolicitud(parTipoSOl, parMovimiento, parEstado, parCliente, parItem, parRo, parSeguimiento, parFecIni, parFecFin, parEmp, parAnal, pContenedor);
        }

        public DataTable BuscarSolicitudMonitoreo (int parTipoSOl, string parMovimiento, string parEstado, string parCliente, int parItem, int parRo, string parSeguimiento,
            DateTime parFecIni, DateTime parFecFin, string parEmp, string parAnal, string pContenedor)
        {
            return oTPL.BuscarSolicitudMonitoreo(parTipoSOl, parMovimiento, parEstado, parCliente, parItem, parRo, parSeguimiento, parFecIni, parFecFin, parEmp, parAnal, pContenedor);
        }

        public DataTable ListarEmpresa()
        {
            return oTPL.ListarEmpresa();
        }

        public DataTable ListarEstados()
        {
            return oTPL.ListarEstados();
        }
        public DataTable ListarTipoMovimiento()
        {
            return oTPL.ListarTipoMovimiento();
        }
        public DataTable ListarTipoSolicitud()
        {
            return oTPL.ListarTipoSolicitud();
        }

        public DataTable ListarTipoContenedor()
        {
            return oTPL.ListarTipoContenedor();
        }
        public DataTable ListarCondicionEmbarque()
        {
            return oTPL.ListarCondicionEmbarque();
        }
        public DataTable ListarIncoterm()
        {
            return oTPL.ListarIncoterm();
        }
        public DataTable ListarAduana()
        {
            return oTPL.ListarAduana();
        }
        public DataTable ListarDeposito(string codigo)
        {
            return oTPL.ListarDeposito(codigo);
        }
        public DataTable ListarLocales(string codigo)
        {
            return oTPL.ListarLocales(codigo);
        }
        public DataTable ListarClientes(string codigo, string descripcion)
        {
            return oTPL.ListarClientes(codigo, descripcion);
        }
        public DataTable ListarTerminales()
        {
            return oTPL.ListarTerminales();
        }
        public DataTable ListarTransporte()
        {
            return oTPL.ListarTransporte();
        }

        public DataTable Registrar_RO(TMS_RoutingOrder r)
        {
            return oTPL.Registrar_RO(r);
        }
        public DataTable Registrar_Solicitud(TMS_Solicitud r)
        {
            return oTPL.Registrar_Solicitud(r);
        }
        public DataTable Registrar_SolicitudTransporte(TMS_Solicitud r)
        {
            return oTPL.Registrar_SolicitudTransporte(r);
        }


        public int Registrar_ROCarga(string tope, int al, string bulto, int cantidad, string tipo, int pies, decimal mon, string come, string usu)
        {
            return oTPL.Registrar_ROCarga(tope, al, bulto, cantidad, tipo, pies, mon, come, usu);
        }
        public int Registrar_ROCargaDetalle(TMS_Solicitud s)
        {
            return oTPL.Registrar_ROCargaDetalle(s);
        }
        public int Registrar_ROCargaContenedor(TMS_SolicitudDetalle s)
        {
            return oTPL.Registrar_ROCargaContenedor(s);
        }

        public int Registrar_SolicitudTransporteContenedor(TMS_SolicitudTPLDetalle c)
        {
            return oTPL.Registrar_SolicitudTransporteContenedor(c);
        }


        public int ObtenerKItem(int Bic_RO, int Bic_Pies, string Bic_Pref, string Nume)
        {
            return oTPL.ObtenerKItem(Bic_RO, Bic_Pies, Bic_Pref, Nume);
        }

        public int Anular_SolictudRO(TMS_Solicitud s)
        {
            return oTPL.Anular_SolictudRO(s);
        }
        public List<TransaccionEL> RegistrarTarifa(TarifaEL oTarifa)
        {
            TarifaDAL objTarifa = new TarifaDAL();
            return objTarifa.RegistrarTarifa(oTarifa);
        }
        public DataTable ExportarCTN_Contrans_Operativo(int anno, int nro_manifiesto, string movimiento, string viaje, string rumbo)
        {
            return oTPL.ExportarCTN_Contrans_Operativo(anno,  nro_manifiesto,  movimiento,  viaje,  rumbo);
        }
        public DataTable ExportarCTN_Contrans_Integral(string volante)
        {
            return oTPL.ExportarCTN_Contrans_Integral(volante);
        }

        public int Registrar_ROSeguimientoBasico(int RO, int ITEM, string MOVI, int SOLI, int TSOL, string CONT, string TIPO, int PIES, int UNID, int CHOF, int EMPR, string TER1, DateTime T1LL, string ENT1, int LOC1, DateTime C1LL, string ENT2, int LOC2, string TER2, string USER)
        {
            return oTPL.Registrar_ROSeguimientoBasico(RO, ITEM, MOVI, SOLI, TSOL, CONT, TIPO, PIES, UNID, CHOF, EMPR, TER1, T1LL, ENT1, LOC1, C1LL, ENT2, LOC2, TER2, USER);
        }
        public DataTable Programacion_ListarContenedores(string nro_solicitud)
        {
            return oTPL.Programacion_ListarContenedores(nro_solicitud);
        }
        public int Programacion_AsignacionBasico(int RO, int ITEM, int SOLI, int UNID, string UNID_PLACA, int CHOF, int EMPR, string USER, string CHOF_NOM)
        {
            return oTPL.Programacion_AsignacionBasico(RO, ITEM, SOLI, UNID, UNID_PLACA, CHOF, CHOF_NOM, EMPR, USER);
        }
    }
}
