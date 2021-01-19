using EL;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TPL_DAL
    {
        public DataTable BuscarSolicitud( int parTipoSOl, string parMovimiento,string parEstado, string parCliente, int parItem, int parRo, string parSeguimiento,
            DateTime parFecIni, DateTime parFecFin, string parEmp, string parAnal, string pContenedor)
        {
            SqlParameter[] arParams = new SqlParameter[12];
            arParams[0] = new SqlParameter("@Sol_TSol", SqlDbType.Int);
            arParams[0].Value = parTipoSOl;
            arParams[1] = new SqlParameter("@RO_TMOV", SqlDbType.VarChar, 1);
            arParams[1].Value = parMovimiento;
            arParams[2] = new SqlParameter("@ROS_ESTADO", SqlDbType.VarChar, 1);
            arParams[2].Value = parEstado;
            arParams[3] = new SqlParameter("@CLIENTE", SqlDbType.VarChar,8000);
            arParams[3].Value = parCliente;
            arParams[4] = new SqlParameter("@ROS_KITEM", SqlDbType.Int);
            arParams[4].Value = parItem;
            arParams[5] = new SqlParameter("@ROS_KRO", SqlDbType.Int);
            arParams[5].Value = parRo; 
            arParams[6] = new SqlParameter("@SEGUIMIENTO", SqlDbType.VarChar,1);
            arParams[6].Value = parSeguimiento;
            arParams[7] = new SqlParameter("@FECINI", SqlDbType.DateTime);
            arParams[7].Value = parFecIni;
            arParams[8] = new SqlParameter("@FECFIN", SqlDbType.DateTime);
            arParams[8].Value = parFecFin;
            arParams[9] = new SqlParameter("@EMP", SqlDbType.VarChar,50);
            arParams[9].Value = parEmp;
            arParams[10] = new SqlParameter("@ANALISTA", SqlDbType.VarChar, 50);
            arParams[10].Value = parAnal;
            arParams[11] = new SqlParameter("@CONTENEDOR", SqlDbType.VarChar, 14);
            arParams[11].Value = pContenedor;

            DataTable dt  = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_TransSolicitudesProgramacion_ROSolicitud_V6", arParams);
            return dt;
        }

        public DataTable BuscarSolicitudMonitoreo( int parTipoSOl, string parMovimiento,string parEstado, string parCliente, int parItem, int parRo, string parSeguimiento,
            DateTime parFecIni, DateTime parFecFin, string parEmp, string parAnal, string pContenedor)
        {
            SqlParameter[] arParams = new SqlParameter[12];
            arParams[0] = new SqlParameter("@Sol_TSol", SqlDbType.Int);
            arParams[0].Value = parTipoSOl;
            arParams[1] = new SqlParameter("@RO_TMOV", SqlDbType.VarChar, 1);
            arParams[1].Value = parMovimiento;
            arParams[2] = new SqlParameter("@ROS_ESTADO", SqlDbType.VarChar, 1);
            arParams[2].Value = parEstado;
            arParams[3] = new SqlParameter("@CLIENTE", SqlDbType.VarChar,8000);
            arParams[3].Value = parCliente;
            arParams[4] = new SqlParameter("@ROS_KITEM", SqlDbType.Int);
            arParams[4].Value = parItem;
            arParams[5] = new SqlParameter("@ROS_KRO", SqlDbType.Int);
            arParams[5].Value = parRo; 
            arParams[6] = new SqlParameter("@SEGUIMIENTO", SqlDbType.VarChar,1);
            arParams[6].Value = parSeguimiento;
            arParams[7] = new SqlParameter("@FECINI", SqlDbType.DateTime);
            arParams[7].Value = parFecIni;
            arParams[8] = new SqlParameter("@FECFIN", SqlDbType.DateTime);
            arParams[8].Value = parFecFin;
            arParams[9] = new SqlParameter("@EMP", SqlDbType.VarChar,50);
            arParams[9].Value = parEmp;
            arParams[10] = new SqlParameter("@ANALISTA", SqlDbType.VarChar, 50);
            arParams[10].Value = parAnal;
            arParams[11] = new SqlParameter("@CONTENEDOR", SqlDbType.VarChar, 14);
            arParams[11].Value = pContenedor;

            DataTable dt  = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TMS_Consultar_Solicud_xMonitoreo", arParams);
            return dt;
        }
        public DataTable ListarEmpresa()
        {
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_Empresas");
            return dt;
        }
        public DataTable ListarEstados()
        {
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_TransEstado");
            return dt;
        }
        public DataTable ListarTipoSolicitud()
        {
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "[TMS_TipoSolicutud]");
            return dt;
        }
        public DataTable ListarTipoMovimiento()
        {
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_TransMovimiento");
            return dt;
        }
        public DataTable ListarTipoContenedor()
        {
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxAntaresLogistics, CommandType.StoredProcedure, "usp_ListarTipoContenedor");
            return dt;
        }
        public DataTable ListarCondicionEmbarque()
        {
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxAntaresLogistics, CommandType.StoredProcedure, "USP_CondicionEmbarque");
            return dt;
        }
        public DataTable ListarIncoterm()
        {
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxAntaresLogistics, CommandType.StoredProcedure, "USP_ListaIncoterm");
            return dt;
        }
        public DataTable ListarAduana()
        {
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxAntaresLogistics, CommandType.StoredProcedure, "USP_FWD_ListaAduana");
            return dt;
        }
        public DataTable ListarDeposito(string codigo)
        {
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CODI", SqlDbType.Char,3);
            arParams[0].Value = codigo;
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetDeposito", arParams);
            return dt;
        }
        public DataTable ListarLocales(string codigo)
        {
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CLIENTE", SqlDbType.VarChar, 100);
            arParams[0].Value = codigo;
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetLocal", arParams);
            return dt;
        }
        public DataTable ListarClientes(string codigo, string descripcion)
        {
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@ENT_CODI", SqlDbType.VarChar, 6);
            arParams[0].Value = codigo;
            arParams[1] = new SqlParameter("@ENT_RSOC", SqlDbType.VarChar, 90);
            arParams[1].Value = descripcion;
            arParams[2] = new SqlParameter("@ENT_NOMC", SqlDbType.VarChar, 80);
            arParams[2].Value = "*";
            arParams[3] = new SqlParameter("@ENT_RUC", SqlDbType.VarChar, 11);
            arParams[3].Value = "*";
            arParams[4] = new SqlParameter("@ENT_DIRE", SqlDbType.VarChar, 200);
            arParams[4].Value = "*";
            arParams[5] = new SqlParameter("@Ent_Empresa", SqlDbType.VarChar, 6);
            arParams[5].Value = "*";
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_Dst_listaEntidades", arParams);
            return dt;
        }     
        public DataTable ListarTerminales()
        {
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxAntaresLogistics, CommandType.StoredProcedure, "SP_ListarDepositos");
            return dt;
        }
        public DataTable ListarTransporte()
        {
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetEmpresaTransporte");
            return dt;
        }
        public DataTable Registrar_RO(TMS_RoutingOrder r)
        {
            SqlParameter[] arParams = new SqlParameter[17];
            arParams[0] = new SqlParameter("@TSER", SqlDbType.Char, 3);
            arParams[0].Value = r.TSER;
            arParams[1] = new SqlParameter("@TVIA", SqlDbType.Char, 1);
            arParams[1].Value = r.TVIA;
            arParams[2] = new SqlParameter("@TMOV", SqlDbType.Char, 2);
            arParams[2].Value = r.TMOV;
            arParams[3] = new SqlParameter("@CLIE", SqlDbType.Char, 6);
            arParams[3].Value = r.CLIE;
            arParams[4] = new SqlParameter("@KEMP", SqlDbType.Char, 6);
            arParams[4].Value = r.KEMP;
            arParams[5] = new SqlParameter("@LINE", SqlDbType.Char, 3);
            arParams[5].Value = r.LINE;
            arParams[6] = new SqlParameter("@ADUA", SqlDbType.Char, 6);
            arParams[6].Value = r.ADUA;
            arParams[7] = new SqlParameter("@TERM", SqlDbType.Char, 3);
            arParams[7].Value = r.TERM;
            arParams[8] = new SqlParameter("@PTO", SqlDbType.VarChar, 20);
            arParams[8].Value = r.PTO;
            arParams[9] = new SqlParameter("@CEMB", SqlDbType.Char, 3);
            arParams[9].Value = r.CEMB;
            arParams[10] = new SqlParameter("@COTI", SqlDbType.Int);
            arParams[10].Value = r.COTI;
            arParams[11] = new SqlParameter("@USER", SqlDbType.VarChar, 20);
            arParams[11].Value = r.USER;
            arParams[12] = new SqlParameter("@NAVE", SqlDbType.VarChar, 20);
            arParams[12].Value = r.NAVE;
            arParams[13] = new SqlParameter("@BLL", SqlDbType.VarChar, 20);
            arParams[13].Value = r.NBL;
            arParams[14] = new SqlParameter("@BKNG", SqlDbType.VarChar, 20);
            arParams[14].Value = r.NBKG;
            arParams[15] = new SqlParameter("@ICOT", SqlDbType.Char, 3);
            arParams[15].Value = r.ICOT;
            arParams[16] = new SqlParameter("@REF", SqlDbType.VarChar, 20);
            arParams[16].Value = r.REF;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TMS_CreacionRO_Transporte", arParams);
            return dt;
        }
        public DataTable Registrar_Solicitud(TMS_Solicitud s)
        {
            SqlParameter[] arParams = new SqlParameter[19];
            arParams[0] = new SqlParameter("@ROS_KRO", SqlDbType.Int);
            arParams[0].Value = s.ROS_KRO;
            arParams[1] = new SqlParameter("@ROS_KConcepto", SqlDbType.VarChar, 80);
            arParams[1].Value = s.ROS_KConcepto;
            arParams[2] = new SqlParameter("@ROS_Proveedor", SqlDbType.Char, 6);
            arParams[2].Value = s.ROS_Proveedor;
            arParams[3] = new SqlParameter("@ROS_TipoCheque", SqlDbType.VarChar, 3);
            arParams[3].Value = s.ROS_TipoCheque;
            arParams[4] = new SqlParameter("@ROS_TipoSolicitud", SqlDbType.VarChar, 3);
            arParams[4].Value = s.ROS_TipoSolicitud;
            arParams[5] = new SqlParameter("@ROS_Estado", SqlDbType.VarChar, 1);
            arParams[5].Value = s.ROS_Estado;
            arParams[6] = new SqlParameter("@ROS_DiasDiferido", SqlDbType.Int);
            arParams[6].Value = s.ROS_DiasDiferido;
            arParams[7] = new SqlParameter("@ROS_Observacion", SqlDbType.VarChar, 300);
            arParams[7].Value = s.ROS_Observacion;
            arParams[8] = new SqlParameter("@ROS_kdoc", SqlDbType.BigInt);
            arParams[8].Value = s.ROS_kdoc;
            arParams[9] = new SqlParameter("@ROS_Moneda", SqlDbType.VarChar, 3);
            arParams[9].Value = s.ROS_Moneda;
            arParams[10] = new SqlParameter("@ROS_ObservacionAnulacion", SqlDbType.VarChar, 300);
            arParams[10].Value = s.ROS_ObservacionAnulacion;
            arParams[11] = new SqlParameter("@ROS_FechaRendicion", SqlDbType.DateTime);
            arParams[11].Value = s.ROS_FechaRendicion;
            arParams[12] = new SqlParameter("@ROS_Ucre", SqlDbType.VarChar, 30);
            arParams[12].Value = s.ROS_Ucre;
            arParams[13] = new SqlParameter("@ROS_TipSolTrans", SqlDbType.Int);
            arParams[13].Value = s.ROS_TipSolTrans;
            arParams[14] = new SqlParameter("@ROS_Clie", SqlDbType.VarChar, 8);
            arParams[14].Value = s.ROS_Clie;
            arParams[15] = new SqlParameter("@ROS_Monto", SqlDbType.Decimal);
            arParams[15].Value = s.ROS_Monto;
            arParams[16] = new SqlParameter("@ROS_Base", SqlDbType.Int);
            arParams[16].Value = s.ROS_Base;
            arParams[17] = new SqlParameter("@ROS_FechaProDesde", SqlDbType.DateTime);
            DateTime fch1 = Convert.ToDateTime(s.ROS_FechaProDesde);//.ToString("yyyy-MM-dd");
            arParams[17].Value = fch1;
            arParams[18] = new SqlParameter("@ROS_FechaProHasta", SqlDbType.DateTime);
            DateTime fch2 = Convert.ToDateTime(s.ROS_FechaProHasta);//.ToString("yyyy-MM-dd");
            arParams[18].Value = fch2; 

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_Dst_ins_Solicitud", arParams);
            return dt;
        }
        public DataTable Registrar_SolicitudTransporte(TMS_Solicitud s)
        {
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ROS_KRO", SqlDbType.Int);
            arParams[0].Value = s.ROS_KRO;
            arParams[1] = new SqlParameter("@ROS_Kitem", SqlDbType.Int);
            arParams[1].Value = s.ROS_KItem; 
    
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_Dst_ins_SolTransTOMSol", arParams);
            return dt;
        }     
        public int Registrar_SolicitudTransporteContenedor(TMS_SolicitudTPLDetalle c)
        { 
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@TOPE", SqlDbType.VarChar,1);
            arParams[0].Value = c.TOPE;
            arParams[1] = new SqlParameter("@ROT_RO", SqlDbType.Int);
            arParams[1].Value = c.ROT_KRO;
            arParams[2] = new SqlParameter("@ROT_Kitem", SqlDbType.Int);
            arParams[2].Value = c.ROT_KITEM;
            arParams[3] = new SqlParameter("@ROT_ContenedorCodigo", SqlDbType.VarChar,14);
            arParams[3].Value = c.ROT_ContenedorCodigo;
            arParams[4] = new SqlParameter("@ROT_ContenedorTipo", SqlDbType.VarChar,2);
            arParams[4].Value = c.ROT_ContenedorTipo;
            arParams[5] = new SqlParameter("@ROT_ContenedorPies", SqlDbType.Int);
            arParams[5].Value = c.ROT_ContenedorPies;
            arParams[6] = new SqlParameter("@User", SqlDbType.VarChar,30);
            arParams[6].Value = c.User;
            arParams[7] = new SqlParameter("@ROT_Item", SqlDbType.Int);
            arParams[7].Value = c.ROT_Item;

            int dt = SqlServerHelper.ExecuteNonQuery(SqlServerHelper.cnxAntaresLogistics, CommandType.StoredProcedure, "TPL_Mantener_ROSolicitudTransporte", arParams); 
            return Convert.ToInt32(dt);
        }
        public int Registrar_ROCarga(string tope , int al, string bulto, int cantidad ,string tipo, int pies, decimal mon, string come , string usu)
        {
            int dt;
            SqlParameter[] arParams = new SqlParameter[9];
            arParams[0] = new SqlParameter("@TOPE", SqlDbType.Char, 1);
            arParams[0].Value = tope;
            arParams[1] = new SqlParameter("@Corr", SqlDbType.Int);
            arParams[1].Value = al;
            arParams[2] = new SqlParameter("@TBul", SqlDbType.Char,2);
            arParams[2].Value = bulto;
            arParams[3] = new SqlParameter("@Cant", SqlDbType.Int);
            arParams[3].Value = cantidad;
            arParams[4] = new SqlParameter("@Tipo", SqlDbType.Char, 4);
            arParams[4].Value = tipo;
            arParams[5] = new SqlParameter("@Pies", SqlDbType.Int);
            arParams[5].Value = pies;
            arParams[6] = new SqlParameter("@Mont", SqlDbType.Float);
            arParams[6].Value = mon;
            arParams[7] = new SqlParameter("@Come", SqlDbType.NVarChar,200);
            arParams[7].Value = come;
            arParams[8] = new SqlParameter("@User", SqlDbType.NVarChar,30);
            arParams[8].Value = usu;

            dt = SqlServerHelper.ExecuteNonQuery(SqlServerHelper.cnxAntaresLogistics, CommandType.StoredProcedure, "RoutingOrderDetalleProducto", arParams);
            return dt;
        }
        public int Registrar_ROCargaDetalle(TMS_Solicitud s)
        {
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ROS_KRO", SqlDbType.Int);
            arParams[0].Value = s.ROS_KRO;
            arParams[1] = new SqlParameter("@ROS_Kitem", SqlDbType.Int);
            arParams[1].Value = s.ROS_KItem;

            int dt = SqlServerHelper.ExecuteNonQuery(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_Dst_ins_SolTransTOMSol", arParams);
            return dt;
        }
        public int Registrar_ROCargaContenedor(TMS_SolicitudDetalle s)
        {
            SqlParameter[] arParams = new SqlParameter[47];
            arParams[0] = new SqlParameter("@TOPE", SqlDbType.Char,1);
            arParams[0].Value = s.TOPE;
            arParams[1] = new SqlParameter("@Corr", SqlDbType.Int);
            arParams[1].Value = s.Corr;
            arParams[2] = new SqlParameter("@KItem", SqlDbType.Int);
            arParams[2].Value = s.KItem;
            arParams[3] = new SqlParameter("@Tipo", SqlDbType.Char,4);
            arParams[3].Value = s.Tipo;
            arParams[4] = new SqlParameter("@Pies", SqlDbType.Int);
            arParams[4].Value = s.Pies;
            arParams[5] = new SqlParameter("@Pref", SqlDbType.Char,4);
            arParams[5].Value = s.Pref;
            arParams[6] = new SqlParameter("@Nume", SqlDbType.Char,10);
            arParams[6].Value = s.Nume;
            arParams[7] = new SqlParameter("@Solicitud", SqlDbType.Int);
            arParams[7].Value = s.Solicitud;
            arParams[8] = new SqlParameter("@ContAnt", SqlDbType.NVarChar,20);
            arParams[8].Value = s.ContAnt;
            arParams[9] = new SqlParameter("@Ocom", SqlDbType.NVarChar,100);
            arParams[9].Value = s.Ocom;
            arParams[10] = new SqlParameter("@Fcom", SqlDbType.NVarChar,100);
            arParams[10].Value = s.Fcom;
            arParams[11] = new SqlParameter("@Peso", SqlDbType.Float);
            arParams[11].Value = s.Peso;
            arParams[12] = new SqlParameter("@Upes", SqlDbType.Char,3);
            arParams[12].Value = s.Upes;
            arParams[13] = new SqlParameter("@Vol", SqlDbType.Float);
            arParams[13].Value = s.Vol;
            arParams[14] = new SqlParameter("@Uvol", SqlDbType.VarChar,10);
            arParams[14].Value = s.Uvol;
            arParams[15] = new SqlParameter("@Tara", SqlDbType.Float);
            arParams[15].Value = s.Tara;
            arParams[16] = new SqlParameter("@Vent", SqlDbType.Float);
            arParams[16].Value = s.Vent;
            arParams[17] = new SqlParameter("@Temp", SqlDbType.Float);
            arParams[17].Value = s.Temp;
            arParams[18] = new SqlParameter("@UTemp", SqlDbType.Char, 10);
            arParams[18].Value = s.UTemp;
            arParams[19] = new SqlParameter("@Prli", SqlDbType.NVarChar,40);
            arParams[19].Value = s.Prli;
            arParams[20] = new SqlParameter("@Prem", SqlDbType.NVarChar,10);
            arParams[20].Value = s.Prem;
            arParams[21] = new SqlParameter("@Prad", SqlDbType.NVarChar, 10);
            arParams[21].Value = s.Prad;
            arParams[22] = new SqlParameter("@Prte", SqlDbType.NVarChar, 10);
            arParams[22].Value = s.Prte;
            arParams[23] = new SqlParameter("@Aten", SqlDbType.Char,1);
            arParams[23].Value = s.Aten;
            arParams[24] = new SqlParameter("@Tpaq", SqlDbType.Char,5);
            arParams[24].Value = s.Tpaq;
            arParams[25] = new SqlParameter("@Cpaq", SqlDbType.Int);
            arParams[25].Value = s.Cpaq;
            arParams[26] = new SqlParameter("@Tmer", SqlDbType.Char,5);
            arParams[26].Value = s.Tmer;
            arParams[27] = new SqlParameter("@Lent", SqlDbType.NVarChar,150);
            arParams[27].Value = s.Lent;
            arParams[28] = new SqlParameter("@Lent2", SqlDbType.NVarChar,10);
            arParams[28].Value = s.Lent2;
            arParams[29] = new SqlParameter("@Flle", SqlDbType.DateTime);
            arParams[29].Value = s.Flle;
            arParams[30] = new SqlParameter("@Fent", SqlDbType.DateTime);
            arParams[30].Value = s.Fent;
            arParams[31] = new SqlParameter("@HoraLlegada", SqlDbType.DateTime);
            arParams[31].Value = s.HoraLlegada;
            arParams[32] = new SqlParameter("@HoraEntrega", SqlDbType.DateTime);
            arParams[32].Value = s.HoraEntrega;
            arParams[33] = new SqlParameter("@Calm", SqlDbType.Char,3);
            arParams[33].Value = s.Calm;
            arParams[34] = new SqlParameter("@Imo", SqlDbType.NVarChar,20);
            arParams[34].Value = s.Imo;
            arParams[35] = new SqlParameter("@Unno", SqlDbType.NVarChar,20);
            arParams[35].Value = s.Unno;
            arParams[36] = new SqlParameter("@Pgrp", SqlDbType.NVarChar,10);
            arParams[36].Value = s.Pgrp;
            arParams[37] = new SqlParameter("@Cnfl", SqlDbType.NVarChar,15);
            arParams[37].Value = s.Cnfl;
            arParams[38] = new SqlParameter("@Fcar", SqlDbType.NVarChar,10);
            arParams[38].Value = s.Fcar;
            arParams[39] = new SqlParameter("@Plan", SqlDbType.NVarChar,15);
            arParams[39].Value = s.Plan;
            arParams[40] = new SqlParameter("@Transportista", SqlDbType.VarChar,6);
            arParams[40].Value = s.Transportista;
            arParams[41] = new SqlParameter("@Serv", SqlDbType.VarChar,1000);
            arParams[41].Value = s.Serv;
            arParams[42] = new SqlParameter("@DbCarga", SqlDbType.Int);
            arParams[42].Value = s.DbCarga;
            arParams[43] = new SqlParameter("@User", SqlDbType.NVarChar,100);
            arParams[43].Value = s.User;
            arParams[44] = new SqlParameter("@CarSuelta", SqlDbType.Bit);
            arParams[44].Value = s.CarSuelta;
            arParams[45] = new SqlParameter("@NroPedido1", SqlDbType.VarChar,30);
            arParams[45].Value = "";
            arParams[46] = new SqlParameter("@NroPedido2", SqlDbType.VarChar, 30);
            arParams[46].Value = "";

            string valor = SqlServerHelper.ExecuteScalar(SqlServerHelper.cnxAntaresLogistics, CommandType.StoredProcedure, "ROxDetallexCargaTPL", arParams).ToString();
            int iResult = (valor == "I" || valor == "E" || valor == "M" ? 1 : 0);
            return iResult;
        }
        public int ObtenerKItem(int Bic_RO   , int Bic_Pies  , string Bic_Pref  , string Nume)
        {
           
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@Bic_RO", SqlDbType.Int);
            arParams[0].Value = Bic_RO;
            arParams[1] = new SqlParameter("@Bic_Pies", SqlDbType.Int);
            arParams[1].Value = Bic_Pies;
            arParams[2] = new SqlParameter("@Bic_Pref", SqlDbType.Char, 4);
            arParams[2].Value = Bic_Pref;
            arParams[3] = new SqlParameter("@Nume", SqlDbType.Char,10);
            arParams[3].Value = Nume; 

            string dt = SqlServerHelper.ExecuteScalar(SqlServerHelper.cnxAntaresLogistics, CommandType.StoredProcedure, "TPL_BlsImpoROContenedorxRO_ObtenerKItem", arParams).ToString();
            return Convert.ToInt32(dt);
        }
        public int Anular_SolictudRO(TMS_Solicitud s)
        {
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ROS_KRO", SqlDbType.Int);
            arParams[0].Value = s.ROS_KRO;
            //arParams[1] = new SqlParameter("@ROS_Kitem", SqlDbType.Int);
            //arParams[1].Value = s.ROS_KItem;

            int dt = SqlServerHelper.ExecuteNonQuery(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TMS_AnularSolicitud", arParams);
            return dt;
        }
        public DataTable ExportarCTN_Contrans_Operativo(int anno,int nro_manifiesto , string movimiento, string viaje, string rumbo)
        {
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@pchr_manianio", SqlDbType.Char, 4);
            arParams[0].Value = anno;
            arParams[1] = new SqlParameter("@pchr_maninumero", SqlDbType.Char, 6);
            arParams[1].Value = nro_manifiesto;
            arParams[2] = new SqlParameter("@pchr_rubro", SqlDbType.Char, 1);
            arParams[2].Value = movimiento;
            arParams[3] = new SqlParameter("@pchr_numviaje", SqlDbType.VarChar, 10);
            arParams[3].Value = viaje;
            arParams[4] = new SqlParameter("@pchr_rumbo", SqlDbType.Char, 3);
            arParams[4].Value = rumbo;
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.CnxContrans, CommandType.StoredProcedure, "imp_manifiesto_lista_ctn", arParams);
            return dt;
        }
        public DataTable ExportarCTN_Contrans_Integral( string volante)
        {
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@pchr_volante", SqlDbType.Char, 6);
            arParams[0].Value = volante; 
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.CnxContrans, CommandType.StoredProcedure, "imp_manifiesto_lista_ctn_integral", arParams);
            return dt;
        }

        /*   
			
            */
        public int Registrar_ROSeguimientoBasico(int RO, int ITEM, string MOVI, int SOLI, int TSOL,    string CONT, string TIPO, int PIES, int UNID, int CHOF, int EMPR, string TER1,             DateTime T1LL, string ENT1, int LOC1, DateTime C1LL, string ENT2, int LOC2, string TER2, string USER)
        {
            int dt;
            SqlParameter[] arParams = new SqlParameter[20];
            arParams[0] = new SqlParameter("@RO", SqlDbType.Int);
            arParams[0].Value = RO;
            arParams[1] = new SqlParameter("@ITEM", SqlDbType.Int);
            arParams[1].Value = ITEM;
            arParams[2] = new SqlParameter("@MOVI", SqlDbType.Char, 1);
            arParams[2].Value = MOVI;
            arParams[3] = new SqlParameter("@SOLI", SqlDbType.Int);
            arParams[3].Value = SOLI;
            arParams[4] = new SqlParameter("@TSOL", SqlDbType.Int);
            arParams[4].Value = TSOL;
            arParams[5] = new SqlParameter("@CONT", SqlDbType.VarChar,20);
            arParams[5].Value = CONT;
            arParams[6] = new SqlParameter("@TIPO", SqlDbType.Char,3);
            arParams[6].Value = TIPO;
            arParams[7] = new SqlParameter("@PIES", SqlDbType.Int);
            arParams[7].Value = PIES;
            arParams[8] = new SqlParameter("@UNID", SqlDbType.Int);
            arParams[8].Value = UNID;
            arParams[9] = new SqlParameter("@CHOF", SqlDbType.Int);
            arParams[9].Value = CHOF;
            arParams[10] = new SqlParameter("@EMPR", SqlDbType.Int);
            arParams[10].Value = EMPR;
            arParams[11] = new SqlParameter("@TER1", SqlDbType.Char, 3);
            arParams[11].Value = TER1;
            arParams[12] = new SqlParameter("@T1LL", SqlDbType.DateTime);
            arParams[12].Value = T1LL;
            arParams[13] = new SqlParameter("@ENT1", SqlDbType.VarChar, 6);
            arParams[13].Value = ENT1;
            arParams[14] = new SqlParameter("@LOC1", SqlDbType.Int);
            arParams[14].Value = LOC1;
            arParams[15] = new SqlParameter("@C1LL", SqlDbType.DateTime);
            arParams[15].Value = C1LL;
            arParams[16] = new SqlParameter("@ENT2", SqlDbType.VarChar, 6);
            arParams[16].Value = ENT2;
            arParams[17] = new SqlParameter("@LOC2", SqlDbType.Int);
            arParams[17].Value = LOC2;
            arParams[18] = new SqlParameter("@TER2", SqlDbType.Char, 3);
            arParams[18].Value = TER2;
            arParams[19] = new SqlParameter("@USER", SqlDbType.VarChar, 20);
            arParams[19].Value = USER;

            dt = SqlServerHelper.ExecuteNonQuery(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TMS_Seguimiento_RO_Transporte", arParams);
            return dt;
        }

        public int Programacion_AsignacionBasico(int RO, int ITEM, int SOLI, int UNID, string UNID_PLACA, int CHOF, string CHOF_NOM, int EMPR, string USER)
        {
            int dt;
            SqlParameter[] arParams = new SqlParameter[9];
            arParams[0] = new SqlParameter("@RO", SqlDbType.Int);
            arParams[0].Value = RO;
            arParams[1] = new SqlParameter("@SOLI", SqlDbType.Int);
            arParams[1].Value = SOLI;
            arParams[2] = new SqlParameter("@ITEM", SqlDbType.Int);
            arParams[2].Value = ITEM;
            arParams[3] = new SqlParameter("@UNID", SqlDbType.Int);
            arParams[3].Value = UNID;
            arParams[4] = new SqlParameter("@CHOF", SqlDbType.Int);
            arParams[4].Value = CHOF;
            arParams[5] = new SqlParameter("@EMPR", SqlDbType.Int);
            arParams[5].Value = EMPR;
            arParams[6] = new SqlParameter("@USER", SqlDbType.VarChar, 20);
            arParams[6].Value = USER;
            arParams[7] = new SqlParameter("@CHOF_NOM", SqlDbType.VarChar, 200);
            arParams[7].Value = CHOF_NOM;
            arParams[8] = new SqlParameter("@UNID_PLACA", SqlDbType.VarChar, 10);
            arParams[8].Value = UNID_PLACA;

            dt = SqlServerHelper.ExecuteNonQuery(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TMS_Programacion_Asignacion", arParams);
            return dt;
        }


        public DataTable Programacion_ListarContenedores(string nro_solicitud)
        {
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@SOLICITUD", SqlDbType.VarChar);
            arParams[0].Value = nro_solicitud;
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_Programacion_ListarContenedores", arParams);
            return dt;
        }
    }
}
