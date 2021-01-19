using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TMS_PreFacturacionBL
    {
        public DataTable ConsultarZona(int pRo, int pSolicitud)
        {
            TMS_PreFacturacionDAL oPF = new TMS_PreFacturacionDAL();
            return oPF.ConsultarZona(pRo, pSolicitud);
        }

        public DataTable GetCabecera(int pRo, int pSolicitud)
        {
            TMS_PreFacturacionDAL oPF = new TMS_PreFacturacionDAL();
            return oPF.GetCabecera(pRo, pSolicitud);
        }

        public DataTable ActualizarFacturacion(string pRo, string pClienteCreacion, string pCliente, string pUsuario, string pCentroCosto, string pSolicitud,
                                            string pRucCliente, string pTipoMovimiento)
        {
            TMS_PreFacturacionDAL oPF = new TMS_PreFacturacionDAL();
            return oPF.ActualizarFacturacion(pRo, pClienteCreacion, pCliente, pUsuario, pCentroCosto, pSolicitud, pRucCliente, pTipoMovimiento);
        }

        public DataTable ActualizarDetalleFacturacion(int pRo, int pSolicitud, string pUsuario, int pDocumento)
        {
            TMS_PreFacturacionDAL oPF = new TMS_PreFacturacionDAL();
            return oPF.ActualizarDetalleFacturacion(pRo, pSolicitud, pUsuario, pDocumento);
        }

        public DataTable GetCabeceraFacturacion(int pDocumento)
        {
            TMS_PreFacturacionDAL oPF = new TMS_PreFacturacionDAL();
            return oPF.GetCabeceraFacturacion(pDocumento);
        }

        public DataTable ListarDetalleFacturacion(int pFacId)
        {
            TMS_PreFacturacionDAL oPF = new TMS_PreFacturacionDAL();
            return oPF.ListarDetalleFacturacion(pFacId);
        }

        public DataTable ActualizarCodigoZona(int pAl, int pSol, string pUsuario, string pContenedor)
        {
            TMS_PreFacturacionDAL oPF = new TMS_PreFacturacionDAL();
            return oPF.ActualizarCodigoZona(pAl, pSol, pUsuario, pContenedor);
        }

        public DataTable ActualizarDetalleFacturacionUN(int pRo, int pSolicitud, string pUsuario, int pDocumento)
        {
            TMS_PreFacturacionDAL oPF = new TMS_PreFacturacionDAL();
            return oPF.ActualizarDetalleFacturacionUN(pRo, pSolicitud, pUsuario, pDocumento);
        }

        public DataTable ActualizarZona(int pDetFacId, int pZona, int pTipoContenedor)
        {
            TMS_PreFacturacionDAL oPF = new TMS_PreFacturacionDAL();
            return oPF.ActualizarZona(pDetFacId, pZona, pTipoContenedor);
        }


        
    }
}
