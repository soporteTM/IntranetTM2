using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EL;

namespace BL
{
    public class TMS_SeguimientoBL
    {
        public List<TMS_SeguimientoEL> ListarDepositos()
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.ListarDepositos();
        }

        public List<TMS_ChoferEL> getChoferSeguimiento(string cod_chof)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.getChoferSeguimiento(cod_chof);
        }

        public List<TMS_SeguimientoEL> GetEmpresaTransporte()
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.GetEmpresaTransporte();
        }

        public DataTable GetEvento()
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.GetEvento();
        }

        public DataTable GetCorreo()
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.GetCorreo();
        }

        public DataTable ListarTipoCont(int ROAL)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.ListarTipoCont(ROAL);
        }

        public DataTable ListarSolicitud(int ROAL)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.ListarSolicitud(ROAL);
        }

        public List<TMS_SeguimientoEL> UnidadxEmp(int idEmpresaTransporte)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.UnidadxEmp(idEmpresaTransporte);
        }

        public List<FlotaEL> UnidadxTM()
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.UnidadxTM();
        }

        public List<TMS_SeguimientoEL> UnidadxEmp(int idEmpresaTransporte, string UnidadPlaca)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.UnidadxEmp(idEmpresaTransporte,UnidadPlaca);
        }

        public DataTable GetContenedoresSeguimiento(string pSolicitud)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.GetContenedoresSeguimiento(pSolicitud);
        }

        public DataTable GetContenedores(string pSolicitud, string pItem)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.GetContenedores(pSolicitud, pItem);
        }

        public DataTable GetCorreoCliente(string pEmp)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.GetCorreoCliente(pEmp);
        }

        public DataTable GetCorreoCliente(string pEmp, string pMov)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.GetCorreoCliente(pEmp, pMov);
        }

        //public DataTable EnvioCorreo(string Cliente)
        //{
        //    TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
        //    return oSeguimiento.EnviarCorreo(Cliente);
        //}

        public DataTable EnvioCorreo(int pRO, int pItem, string Cliente)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.EnviarCorreo(pRO, pItem, Cliente);
        }

        public int ActualizarCorreo(int pRO, int pItem)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.ActualizarCorreo(pRO, pItem);
        }

        public List<TMS_ChoferEL> GetChoferxEmp(int idEmpresaTransporte)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.GetChoferxEmp(idEmpresaTransporte);
        }

        public List<TMS_ChoferEL> GetChoferxEmp(int idEmpresaTransporte, string raz_soc)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.GetChoferxEmp(idEmpresaTransporte,raz_soc);
        }

        public DataTable GetTipoSolicitud(int tipsol)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.GetTipoSolicitud(tipsol);
        }

        public DataTable ListarRo(string pRO, string pSolicitud)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.ListarRo(pRO, pSolicitud);
        }

        public List<TMS_SeguimientoEL> GetSeguimiento(int pRo, string pContenedor, int pItem)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.GetSeguimiento(pRo ,pContenedor , pItem );
        }

        public void EliminarContenedor(int Ro, string contenedor)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            oSeguimiento.EliminarContenedor(Ro ,contenedor);
        }

        public int EnvioMail(string pFrom, string pCC, string pBC, string pBody, string pPlaca, string pRo, string pCliente)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.EnvioMail(pFrom,pCC,pBC,pBody,pPlaca,pRo,pCliente);
        }
        public int EnvioMail(string pFrom, string pCC, string pBC, string pBody, string pAsunto)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.EnvioMail(pFrom, pCC, pBC, pBody, pAsunto);
        }
        public string ActualizarCont(string pPantalla,int pRO ,int pSolicitud , int pSolAnt ,string pContenedor ,string pAntCont , int pItem , string pTipo ,
                                     int pPies, int pTara, int pPeso,int pPayload, DateTime pFecCita , DateTime pHorCita , string pUsuario)
        {
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            return oSeguimiento.ActualizarCont(pPantalla, pRO, pSolicitud, pSolAnt, pContenedor, pAntCont, pItem, pTipo, pPies,
                                                    pTara, pPeso, pPayload, pFecCita, pHorCita, pUsuario);
        }

        public string ContenedorExpo(int pRO, int pSolicitud, string pTipo, int pPies, string pPref, string pNume, int pPyld, int pPeso,
                                   int pTara, string pUsuario, DateTime pfecha/*, DateTime phora*/)
        {
            TMS_SeguimientoDAL objSeguimiento = new TMS_SeguimientoDAL();
            return objSeguimiento.ContenedorExpo(pRO, pSolicitud, pTipo, pPies, pPref, pNume, pPyld, pPeso, pTara, pUsuario, pfecha/*, phora*/);
        }


        public string Proceso1(int pRo, int pItem, string pMovi, int pSoli, int pTSol, string pCont, string pTipo, int pPies, int pUnid, string pUnidPlaca, int pChof, string pChofNom, int pEmpr,
                               int pEven, string pTer1, DateTime pT1Ll, DateTime pT1Ig, DateTime pT1Sa, string pObT1, string pEnt1, int pLoc1, DateTime pC1Ll,
                               DateTime pC1Ig, DateTime pC1In, DateTime pC1Te, DateTime pC1Sa, string pObC1, string pEnt2, int pLoc2, DateTime pC2Ll, DateTime pC2Ig,
                               DateTime pC2In, DateTime pC2Te, DateTime pC2Sa, string pObC2, string pTer2, DateTime pT2Ll, DateTime pT2Ig, DateTime pT2Sa, string pObT2,
                               string pPCtn, string pPAdu, string pPLin, string pPTra, string pEsta, int pPern, int pDblc, string pUser)
        {
            string mensaje = "";
            TMS_SeguimientoDAL oSeguimiento = new TMS_SeguimientoDAL();
            mensaje = oSeguimiento.Proceso1( pRo,  pItem,  pMovi,  pSoli,  pTSol,  pCont,  pTipo,  pPies,  pUnid, pUnidPlaca,  pChof, pChofNom,  pEmpr,
                                             pEven,  pTer1,  pT1Ll,  pT1Ig,  pT1Sa,  pObT1,  pEnt1,  pLoc1,  pC1Ll,
                                             pC1Ig,  pC1In,  pC1Te,  pC1Sa,  pObC1,  pEnt2,  pLoc2,  pC2Ll,  pC2Ig,
                                             pC2In,  pC2Te,  pC2Sa,  pObC2,  pTer2,  pT2Ll,  pT2Ig,  pT2Sa,  pObT2,
                                             pPCtn,  pPAdu,  pPLin,  pPTra,  pEsta,  pPern,  pDblc,  pUser);

            return mensaje;
        }
    }
}
