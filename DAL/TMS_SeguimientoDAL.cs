using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using SQLHelper;

namespace DAL
{
    public class TMS_SeguimientoDAL
    {
        public List<TMS_SeguimientoEL> ListarDepositos()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_ListarDepositos");

            List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            return lstItem;
        }

        public List<TMS_ChoferEL> getChoferSeguimiento(string cod_chof)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CHOF", SqlDbType.VarChar, 10);
            arParams[0].Value = cod_chof;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetChofer2", arParams);

            List<TMS_ChoferEL> lstItem = new List<TMS_ChoferEL>();
            lstItem = Util.ConvertDataTable<TMS_ChoferEL>(dt);

            return lstItem;
        }

        public List<TMS_SeguimientoEL> GetEmpresaTransporte()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetEmpresaTransporte");

            List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            return lstItem;
        }

        public DataTable GetEvento()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetEvento");
            
            return dt;
        }

        public DataTable GetCorreo()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetCorreo");
            
            return dt;
        }

        public List<TMS_SeguimientoEL> UnidadxEmp(int idEmpresaTransporte)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@EMP", SqlDbType.Int);
            arParams[0].Value = idEmpresaTransporte;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_UnidadxEmpresa", arParams);

            List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            return lstItem;
        }

        public List<FlotaEL> UnidadxTM()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Consultar_Flota");

            List<FlotaEL> lstItem = new List<FlotaEL>();
            lstItem = Util.ConvertDataTable<FlotaEL>(dt);

            return lstItem;
        }

        public List<TMS_SeguimientoEL> UnidadxEmp(int idEmpresaTransporte, string UnidadPlaca)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@EMP", SqlDbType.Int);
            arParams[0].Value = idEmpresaTransporte;

            arParams[1] = new SqlParameter("@PLACA", SqlDbType.VarChar, 25);
            arParams[1].Value = UnidadPlaca;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_UnidadxEmpresa2", arParams);

            List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            return lstItem;
        }

        public DataTable GetContenedoresSeguimiento(string pSolicitud)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@SOLICITUD", SqlDbType.VarChar, 1000);
            arParams[0].Value = pSolicitud;

            return dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_ContenedoresSolicitud_OLD", arParams);

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }

        public List<TMS_SeguimientoEL> GetSeguimiento(int pRo, string pContenedor, int pItem)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@RO", SqlDbType.Int);
            arParams[0].Value = pRo;

            arParams[1] = new SqlParameter("@CONTENEDOR", SqlDbType.VarChar, 20);
            arParams[1].Value = pContenedor;

            arParams[2] = new SqlParameter("@ITEM", SqlDbType.Int);
            arParams[2].Value = pItem;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetSeguimiento", arParams);

            List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            return lstItem;
        }

        public void EliminarContenedor(int Ro, string contenedor)
        {
            //DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@BICRO", SqlDbType.Int);
            arParams[0].Value = Ro;

            arParams[1] = new SqlParameter("@BICCONT", SqlDbType.VarChar, 14);
            arParams[1].Value = contenedor;

            SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_EliminarExpoContenedor", arParams);

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }

        public DataTable ListarTipoCont(int ROAL)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@RO", SqlDbType.Int);
            arParams[0].Value = ROAL;

            return dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_ListarTipoCont", arParams);

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }

        public DataTable ListarSolicitud(int ROAL)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@RO", SqlDbType.Int);
            arParams[0].Value = ROAL;

            return dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_ListarSolicitud", arParams);

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }

        public List<TMS_ChoferEL> GetChoferxEmp(int idEmpresaTransporte)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@EMP", SqlDbType.Int);
            arParams[0].Value = idEmpresaTransporte;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_ChoferxEmpresa", arParams);

            List<TMS_ChoferEL> lstItem = new List<TMS_ChoferEL>();
            lstItem = Util.ConvertDataTable<TMS_ChoferEL>(dt);

            return lstItem;
        }

        public List<TMS_ChoferEL> GetChoferxEmp(int idEmpresaTransporte, string raz_soc)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@EMP", SqlDbType.Int);
            arParams[0].Value = idEmpresaTransporte;

            arParams[1] = new SqlParameter("@NOMBRE", SqlDbType.VarChar , 50);
            arParams[1].Value = raz_soc;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_ChoferxEmpresa2", arParams);

            List<TMS_ChoferEL> lstItem = new List<TMS_ChoferEL>();
            lstItem = Util.ConvertDataTable<TMS_ChoferEL>(dt);

            return lstItem;
        }

        public DataTable GetTipoSolicitud(int tipsol)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@TSOLCOD", SqlDbType.Int);
            arParams[0].Value = tipsol;

            return SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "USP_TipoSolicitud", arParams);

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }

        public DataTable ListarRo(string pRO, string pSolicitud)
        {
            //DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@RO", SqlDbType.VarChar, 600);
            arParams[0].Value = pRO;

            arParams[1] = new SqlParameter("@SOLICITUD", SqlDbType.VarChar);
            arParams[1].Value = pSolicitud;

            return SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_ListarRO", arParams);

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }

        public int ActualizarCorreo(int pRO, int pItem)
        {
            //DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@RO", SqlDbType.Int);
            arParams[0].Value = pRO;

            arParams[1] = new SqlParameter("@ITEM", SqlDbType.Int);
            arParams[1].Value = pItem;

            return SqlServerHelper.ExecuteNonQuery(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_ACtualizarCorreo", arParams);

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }

        public DataTable EnviarCorreo(string Cliente)
        {
            //DataTable dt;

            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ROAL", SqlDbType.Int);
            arParams[0].Value = 0;

            arParams[1] = new SqlParameter("@ITEM", SqlDbType.VarChar, 600);
            arParams[1].Value = "0";

            arParams[2] = new SqlParameter("@Cliente", SqlDbType.VarChar, 600);
            arParams[2].Value = Cliente;

            return SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_EnvioCorreo", arParams);

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }

        public DataTable EnviarCorreo(int pRO, int pItem, string Cliente)
        {
            //DataTable dt;

            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ROAL", SqlDbType.Int);
            arParams[0].Value = pRO;

            arParams[1] = new SqlParameter("@ITEM", SqlDbType.VarChar, 600);
            arParams[1].Value = pItem;

            arParams[2] = new SqlParameter("@Cliente", SqlDbType.VarChar);
            arParams[2].Value = Cliente;

            return SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_EnvioCorreo", arParams);

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }

        public DataTable GetCorreoCliente(string pEmp, string pMov)
        {
            //DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@EMP", SqlDbType.Char, 6);
            arParams[0].Value = pEmp;

            arParams[1] = new SqlParameter("@MOV", SqlDbType.Char, 1);
            arParams[1].Value = pMov;

            return SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetCorreoCliente_v2", arParams);

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }

        public DataTable GetCorreoCliente(string pEmp)
        {
            //DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@EMP", SqlDbType.Char, 6);
            arParams[0].Value = pEmp;
            
            return SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetCorreoCliente", arParams);

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }

        public DataTable GetContenedores(string pSolicitud, string pItem)
        {
            //DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@SOLICITUD", SqlDbType.VarChar, 600);
            arParams[0].Value = pSolicitud;

            arParams[1] = new SqlParameter("@ITEM", SqlDbType.VarChar);
            arParams[1].Value = pItem;

            return SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_ListarRO", arParams);

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }

        public int EnvioMail(string pFrom, string pCC, string pBC, string pBody, string pPlaca, string pRo, string pCliente)
        {
            //DataTable dt;

            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@BODY", SqlDbType.VarChar);
            arParams[0].Value = pBody;

            arParams[1] = new SqlParameter("@FROM", SqlDbType.VarChar, 6000);
            arParams[1].Value = pFrom;

            arParams[2] = new SqlParameter("@CC", SqlDbType.VarChar, 6000);
            arParams[2].Value = pCC;

            arParams[3] = new SqlParameter("@BC", SqlDbType.VarChar, 6000);
            arParams[3].Value = pBC;
            
            arParams[4] = new SqlParameter("@PLACA", SqlDbType.VarChar, 10);
            arParams[4].Value = pPlaca;

            arParams[5] = new SqlParameter("@AL", SqlDbType.VarChar, 10);
            arParams[5].Value = pRo;

            arParams[6] = new SqlParameter("@CLIENTE", SqlDbType.VarChar, 10);
            arParams[6].Value = pCliente;

            return SqlServerHelper.ExecuteNonQuery(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_EnivarMail", arParams);
            //return SqlServerHelper.ExecuteNonQuery(SqlServerHelper.cnxTransportes_2, CommandType.StoredProcedure, "SP_EnivarMail", arParams);

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }
        public int EnvioMail(string pFrom, string pCC, string pBC, string pBody, string pAsunto)
        {
            //DataTable dt;

            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@BODY", SqlDbType.VarChar);
            arParams[0].Value = pBody;

            arParams[1] = new SqlParameter("@FROM", SqlDbType.VarChar, 6000);
            arParams[1].Value = pFrom;

            arParams[2] = new SqlParameter("@CC", SqlDbType.VarChar, 6000);
            arParams[2].Value = pCC;

            arParams[3] = new SqlParameter("@BC", SqlDbType.VarChar, 6000);
            arParams[3].Value = pBC;

            arParams[4] = new SqlParameter("@ASUNTO", SqlDbType.VarChar);
            arParams[4].Value = pAsunto; 

            return SqlServerHelper.ExecuteNonQuery(SqlServerHelper.cnxTransportes_2, CommandType.StoredProcedure, "UP_EnviarCorreo", arParams);
           
        }
        public string ActualizarCont(string pPantalla, int pRO, int pSolicitud, int pSolAnt, string pContenedor, string pAntCont, int pItem, string pTipo,
                                     int pPies, int pTara, int pPeso, int pPayload, DateTime pFecCita, DateTime pHorCita, string pUsuario)
        {
            //DataTable dt;

            SqlParameter[] arParams = new SqlParameter[15];
            arParams[0] = new SqlParameter("@PANTALLA", SqlDbType.VarChar, 1);
            arParams[0].Value = pPantalla;

            arParams[1] = new SqlParameter("@ROAL", SqlDbType.Int);
            arParams[1].Value = pRO;

            arParams[2] = new SqlParameter("@SOLICITUD", SqlDbType.Int);
            arParams[2].Value = pSolicitud;

            arParams[3] = new SqlParameter("@SOLANT", SqlDbType.Int);
            arParams[3].Value = pSolAnt;
            
            arParams[4] = new SqlParameter("@CONTENEDOR", SqlDbType.VarChar, 15);
            arParams[4].Value = pContenedor;

            arParams[5] = new SqlParameter("@ANTCONT", SqlDbType.VarChar, 20);
            arParams[5].Value = pAntCont;

            arParams[6] = new SqlParameter("@ITEM", SqlDbType.Int);
            arParams[6].Value = pItem;

            arParams[7] = new SqlParameter("@TIPO", SqlDbType.Char, 4);
            arParams[7].Value = pTipo;

            arParams[8] = new SqlParameter("@PIES", SqlDbType.Int);
            arParams[8].Value = pPies;

            arParams[9] = new SqlParameter("@TARA", SqlDbType.Int);
            arParams[9].Value = pTara;

            arParams[10] = new SqlParameter("@PESO", SqlDbType.Int);
            arParams[10].Value = pPeso;

            arParams[11] = new SqlParameter("@PYLOAD", SqlDbType.Int);
            arParams[11].Value = pPayload;

            arParams[12] = new SqlParameter("@FECCITA", SqlDbType.DateTime);
            arParams[12].Value = pFecCita;

            arParams[13] = new SqlParameter("@HORCITA", SqlDbType.DateTime);
            arParams[13].Value = pHorCita;

            arParams[14] = new SqlParameter("@USUARIO", SqlDbType.VarChar, 20);
            arParams[14].Value = pUsuario;

            return SqlServerHelper.ExecuteScalar(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_ActualizarContenedor", arParams).ToString();

            //List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
            //lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

            //return lstItem;
        }

        public string Proceso1(int pRo, int pItem, string pMovi, int pSoli, int pTSol, string pCont , string pTipo , int pPies , int pUnid , string pUnidPlaca , int pChof , string pChofNom , int pEmpr ,
                               int pEven , string pTer1 , DateTime pT1Ll , DateTime pT1Ig ,DateTime pT1Sa , string pObT1 , string pEnt1 , int pLoc1 , DateTime pC1Ll , 
                               DateTime pC1Ig , DateTime pC1In , DateTime pC1Te , DateTime pC1Sa , string pObC1 , string pEnt2 , int pLoc2 , DateTime pC2Ll , DateTime pC2Ig ,
                               DateTime pC2In , DateTime pC2Te ,DateTime pC2Sa , string pObC2 , string pTer2 , DateTime pT2Ll , DateTime pT2Ig , DateTime pT2Sa , string pObT2 ,
                               string pPCtn , string pPAdu , string pPLin , string pPTra , string pEsta , int pPern , int pDblc , string pUser)
        {
            SqlParameter[] arParams = new SqlParameter[48];
            arParams[0] = new SqlParameter("@RO", SqlDbType.Int);
            arParams[0].Value = pRo;

            arParams[1] = new SqlParameter("@ITEM", SqlDbType.Int);
            arParams[1].Value = pItem;

            arParams[2] = new SqlParameter("@MOVI", SqlDbType.Char, 1);
            arParams[2].Value = pMovi;

            arParams[3] = new SqlParameter("@SOLI", SqlDbType.Int);
            arParams[3].Value = pSoli;

            arParams[4] = new SqlParameter("@TSOL", SqlDbType.Int);
            arParams[4].Value = pTSol;

            arParams[5] = new SqlParameter("@CONT", SqlDbType.VarChar, 20);
            arParams[5].Value = pCont;

            arParams[6] = new SqlParameter("@TIPO", SqlDbType.Char, 2);
            arParams[6].Value = pTipo;
            
            arParams[7] = new SqlParameter("@PIES", SqlDbType.Int);
            arParams[7].Value = pPies;

            arParams[8] = new SqlParameter("@UNID", SqlDbType.Int);
            arParams[8].Value = pUnid;

            arParams[9] = new SqlParameter("@CHOF", SqlDbType.Int);
            arParams[9].Value = pChof;

            arParams[10] = new SqlParameter("@EMPR", SqlDbType.Int);
            arParams[10].Value = pEmpr;

            arParams[11] = new SqlParameter("@EVEN", SqlDbType.Int);
            arParams[11].Value = pEven;

            arParams[12] = new SqlParameter("@TER1", SqlDbType.Char, 3);
            arParams[12].Value = pTer1;

            arParams[13] = new SqlParameter("@T1LL", SqlDbType.DateTime);
            arParams[13].Value = pT1Ll;

            arParams[14] = new SqlParameter("@T1IG", SqlDbType.DateTime);
            arParams[14].Value = pT1Ig;

            arParams[15] = new SqlParameter("@T1SA", SqlDbType.DateTime);
            arParams[15].Value = pT1Sa;

            arParams[16] = new SqlParameter("@OBT1", SqlDbType.VarChar, 300);
            arParams[16].Value = pObT1;

            arParams[17] = new SqlParameter("@ENT1", SqlDbType.Char, 6);
            arParams[17].Value = pEnt1;

            arParams[18] = new SqlParameter("@LOC1", SqlDbType.Int);
            arParams[18].Value = pLoc1;

            arParams[19] = new SqlParameter("@C1LL", SqlDbType.DateTime);
            arParams[19].Value = pC1Ll;

            arParams[20] = new SqlParameter("@C1IG", SqlDbType.DateTime);
            arParams[20].Value = pC1Ig;

            arParams[21] = new SqlParameter("@C1IN", SqlDbType.DateTime);
            arParams[21].Value = pC1In;

            arParams[22] = new SqlParameter("@C1TE", SqlDbType.DateTime);
            arParams[22].Value = pC1Te;

            arParams[23] = new SqlParameter("@C1SA", SqlDbType.DateTime);
            arParams[23].Value = pC1Sa;

            arParams[24] = new SqlParameter("@OBC1", SqlDbType.VarChar, 300);
            arParams[24].Value = pObC1;

            arParams[25] = new SqlParameter("@ENT2", SqlDbType.Char, 6);
            arParams[25].Value = pEnt2;

            arParams[26] = new SqlParameter("@LOC2", SqlDbType.Int);
            arParams[26].Value = pLoc2;

            arParams[27] = new SqlParameter("@C2LL", SqlDbType.DateTime);
            arParams[27].Value = pC2Ll;

            arParams[28] = new SqlParameter("@C2IG", SqlDbType.DateTime);
            arParams[28].Value = pC2Ig;

            arParams[29] = new SqlParameter("@C2IN", SqlDbType.DateTime);
            arParams[29].Value = pC2In;

            arParams[30] = new SqlParameter("@C2TE", SqlDbType.DateTime);
            arParams[30].Value = pC2Te;

            arParams[31] = new SqlParameter("@C2SA", SqlDbType.DateTime);
            arParams[31].Value = pC2Sa;

            arParams[32] = new SqlParameter("@OBC2", SqlDbType.VarChar, 300);
            arParams[32].Value = pObC2;

            arParams[33] = new SqlParameter("@TER2", SqlDbType.Char, 3);
            arParams[33].Value = pTer2;

            arParams[34] = new SqlParameter("@T2LL", SqlDbType.DateTime);
            arParams[34].Value = pT2Ll;

            arParams[35] = new SqlParameter("@T2IG", SqlDbType.DateTime);
            arParams[35].Value = pT2Ig;

            arParams[36] = new SqlParameter("@T2SA", SqlDbType.DateTime);
            arParams[36].Value = pT2Sa;

            arParams[37] = new SqlParameter("@OBT2", SqlDbType.VarChar, 300);
            arParams[37].Value = pObT2;

            arParams[38] = new SqlParameter("@PCTN", SqlDbType.VarChar, 20);
            arParams[38].Value = pPCtn;

            arParams[39] = new SqlParameter("@PADU", SqlDbType.VarChar, 20);
            arParams[39].Value = pPAdu;

            arParams[40] = new SqlParameter("@PLIN", SqlDbType.VarChar, 20);
            arParams[40].Value = pPLin;

            arParams[41] = new SqlParameter("@PTRA", SqlDbType.VarChar, 20);
            arParams[41].Value = pPTra;

            arParams[42] = new SqlParameter("@ESTA", SqlDbType.VarChar, 20);
            arParams[42].Value = pEsta;

            arParams[43] = new SqlParameter("@PERN", SqlDbType.Bit);
            arParams[43].Value = pPern;

            arParams[44] = new SqlParameter("@DBLC", SqlDbType.Bit);
            arParams[44].Value = pDblc;

            arParams[45] = new SqlParameter("@USER", SqlDbType.VarChar, 20);
            arParams[45].Value = pUser;

            arParams[46] = new SqlParameter("@CHOF_NOM", SqlDbType.VarChar, 200);
            arParams[46].Value = pChofNom;

            arParams[47] = new SqlParameter("@UNID_PLACA", SqlDbType.VarChar, 10);
            arParams[47].Value = pUnidPlaca;

            string mensaje = SqlServerHelper.ExecuteScalar(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_Proc1AsignarSeguimiento_Auditado", arParams).ToString();

            return mensaje;
        }

        public string ContenedorExpo(int pRO, int pSolicitud, string pTipo, int pPies, string pPref, string pNume, int pPyld, int pPeso,
                                   int pTara, string pUsuario, DateTime pfecha /*, DateTime phora*/)
        {
            
            SqlParameter[] arParams = new SqlParameter[11];

            arParams[0] = new SqlParameter("@BICRO", SqlDbType.Int);
            arParams[0].Value = pRO;

            arParams[1] = new SqlParameter("@SOLICITUD", SqlDbType.Int);
            arParams[1].Value = pSolicitud;

            arParams[2] = new SqlParameter("@BICTCNT", SqlDbType.VarChar, 4);
            arParams[2].Value = pTipo;

            arParams[3] = new SqlParameter("@BICPIES", SqlDbType.Int);
            arParams[3].Value = pPies;

            arParams[4] = new SqlParameter("@BICPREF", SqlDbType.VarChar, 4);
            arParams[4].Value = pPref;

            arParams[5] = new SqlParameter("@BICNUME", SqlDbType.VarChar, 10);
            arParams[5].Value = pNume;

            arParams[6] = new SqlParameter("@BICPYLD", SqlDbType.Float);
            arParams[6].Value = pPyld;

            arParams[7] = new SqlParameter("@BICPESO", SqlDbType.Float);
            arParams[7].Value = pPeso;

            arParams[8] = new SqlParameter("@BICTARA", SqlDbType.Float);
            arParams[8].Value = pTara;

            arParams[9] = new SqlParameter("@USUARIO", SqlDbType.VarChar, 15);
            arParams[9].Value = pUsuario;

            arParams[10] = new SqlParameter("@BICFCH", SqlDbType.DateTime);
            arParams[10].Value = pfecha;

            //arParams[11] = new SqlParameter("@HORA", SqlDbType.VarChar, 100);
            //arParams[11].Value = phora;

            return SqlServerHelper.ExecuteScalar(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "[SP_IngresarExpoContenedor_v2]", arParams).ToString();
        }
    }
}
