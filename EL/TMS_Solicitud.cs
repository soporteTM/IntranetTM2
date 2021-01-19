using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    
    public class TMS_Solicitud_DetalleCarga
    {
        public int Item
        { get; set; }
        public UsuarioEL Usuario
        { get; set; }
        public int RO
        { get; set; }
        public int Cantidad
        { get; set; }
        public string TipoBulto
        { get; set; }
        public string TipoCTN
        { get; set; }
        public int TipoPies
        { get; set; }
        public decimal Monto
        { get; set; }
        public string Come
        { get; set; }
        public string Activo
        { get; set; }
    }
    public class TMS_Solicitud_DetalleContenedores
    {
     
        public int Solicitud { get; set; }
        public int ROAL { get; set; }
        public string Contenedor { get; set; }
        public string Prefijo { get; set; }
        public string Numero { get; set; }
        public string Precinto { get; set; }
        public int Item { get; set; }
        public int Pies { get; set; }
        public int Bultos { get; set; } 
        public string Tipo { get; set; }
        public decimal Peso { get; set; }
         public decimal Peso_bruto { get; set; }
        public decimal Tara
        { get; set; }
        public int Pyload { get; set; }
        public string FechaCita { get; set; }
        public string HoraCita { get; set; }
        public string Placa { get; set; }
        public int Evento { get; set; }
        public int dbCarga { get; set; }
        public string Servicio { get; set; }
        public bool EsNuevo { get; set; }
        public string Transportista { get; set; }
        public string Transportista_ruc { get; set; }
        public string Chofer { get; set; }
        public string Brevete { get; set; }
        public string Local1 { get; set; }
        public string Local2 { get; set; }
        public int IDLocal1 { get; set; }
        public int IDLocal2 { get; set; }
    }
    public class TMS_Solicitud
    { 
        public double ROS_KRO { get; set; } 
        public double ROS_KItem { get; set; } 
        public string ROS_KConcepto { get; set; } 
        public string ROS_Proveedor { get; set; } 
        public string ROS_TipoCheque { get; set; } 
        public string ROS_TipoSolicitud { get; set; } 
        public string ROS_Estado { get; set; } 
        public double ROS_DiasDiferido { get; set; } 
        public string ROS_Observacion { get; set; } 
        public double ROS_kdoc { get; set; } 
        public string ROS_Moneda { get; set; } 
        public string ROS_ObservacionAnulacion { get; set; } 
        public double ROS_KCOD { get; set; } 
        public string ROS_FechaRendicion { get; set; } 
        public string ROS_Ucre { get; set; } 
        public string ROS_Fcre { get; set; } 
        public string ROS_Umod { get; set; } 
        public string ROS_Fmod { get; set; } 
        public double ROS_TipSolTrans { get; set; } 
        public string ROS_Clie { get; set; } 
        public string ROS_ClieDescripcion { get; set; } 
        public double ROS_Monto { get; set; } 
        public double ROS_Base { get; set; } 
        public string ROS_FechaProDesde { get; set; } 
        public string ROS_FechaProHasta { get; set; } 
        public string ROS_FCreDesde { get; set; } 
        public string ROS_FCreHasta { get; set; }
    }
    public class TMS_RoutingOrder
    {
        public double RO_Codi { get; set; }
        public string TSER { get; set; }
        public string TVIA { get; set; }
        public string TMOV { get; set; }
        public string CLIE { get; set; }
        public string KEMP { get; set; }
        public string LINE { get; set; }
        public string ADUA { get; set; }
        public string TERM { get; set; }
        public string CEMB { get; set; }
        public string ICOT { get; set; } 
        public double COTI { get; set; } 
        public string USER { get; set; }
        public string NAVE { get; set; }         
        public string NBL { get; set; }       
        public string NBKG { get; set; }       
        public string PTO { get; set; }
        public string REF { get; set; }
    }
    public class xxxxxTMS_SolicitudDetalle1
    {
 
        public int Item { get; set; } 
        public string PesoContenedor { get; set; } 
        public string CodDeposito { get; set; } 
        public int CodLocal { get; set; } 
        public string CodTerminal { get; set; }


       
        public UsuarioEL Usuario { get; set; }

        public int CodDetalle { get; set; }
        public int CodSolicitud { get; set; }
        public string NroContenedor { get; set; }
        public string TamContenedor { get; set; }
        public string TipContenedor { get; set; }
        public string TerminalRetiro { get; set; }
        public string LugarEntrega { get; set; }
        public DateTime FechaCita { get; set; }
        public string DepositosVacios { get; set; }
        public string RucCliente { get; set; }
        public string Activo { get; set; }       
        public decimal Peso { get; set; }               
        public decimal Tara { get; set; }        
        public string Prte { get; set; }
    }
    public class TMS_SolicitudDetalle
    {
        //Tipod de Operacion (N=Nuevo,E=Eliminar,M=Modificar)  
        public string TOPE { get; set; }
        //Numero de Routing Order(AL12345)
        public int Corr { get; set; }
        //Codigo Correlativo por Routing order cuando es nuevo mada 0 por defecto
        public int KItem { get; set; }
        // Tipo de Contenedor (HC, ST, RF, etc.)
        public string Tipo { get; set; }
        // Pies del Contenedor (20, 40)
        public int Pies { get; set; }
        //Prefijo del Contenedor los primeros 4 caracteres(NYKU)
        public string Pref { get; set; }
        //Los número siguientes al prefijo(123456)
        public string Nume { get; set; }
        //no se utiliza por defecto 0
        public int Solicitud { get; set; }
        // no se utiliza por defecto vacío
        public string ContAnt { get; set; }
        // no se utiliza por defecto vacío  
        public string Ocom { get; set; }
        // no se utiliza por defecto vacío
        public string Fcom { get; set; }
        //peso del contenedor 
        public decimal Peso { get; set; }
        //unidad de medida del peso del contendor
        public string Upes { get; set; }
        //volumen del contendor
        public double Vol { get; set; }
        // unidad de medida del volumen del contenedor
        public string Uvol { get; set; }
        //tara del contenedor
        public decimal Tara { get; set; }
        //por defecto 0
        public double Vent { get; set; }
        // ,      por defecto 0Public 
        public double Temp { get; set; }
        // por defecto vacío
        public string UTemp { get; set; }
        // precinto de línea
        public string Prli { get; set; }
        // precinto de embarcador
        public string Prem { get; set; }
        // precinto de aduana
        public string Prad { get; set; }
        // precinto de transporte
        public string Prte { get; set; }
        // Atención del Contenedor(1=Atendido, 0=No Atendido)
        public string Aten { get; set; }
        // por defecto vacío  
        public string Tpaq { get; set; }
        // ,      por defecto 0
        public int Cpaq { get; set; }
        // por defecto vacío  
        public string Tmer { get; set; }
        // local del cliente (numérico)
        public string Lent { get; set; }
        // Segundo local del cliente(numérico)
        public string Lent2 { get; set; }
        // ,      Fecha de Cita al ClientePublic
        public DateTime Flle { get; set; }
        // ,      no se utiliza por defecto 01/01/1900
        public DateTime Fent { get; set; }
        // = '00:00:00',      Hora de llegada al Cliente
        public DateTime HoraLlegada { get; set; }
        // = '00:00:00',      no se utiliza por defecto 01/01/1900
        public DateTime HoraEntrega { get; set; }
        // por defecto vacío
        public string Calm { get; set; }
        // por defecto vacío
        public string Imo { get; set; }
        // por defecto vacío
        public string Unno { get; set; }
        // por defecto vacío
        public string Pgrp { get; set; }
        // por defecto vacío
        public string Cnfl { get; set; }
        // por defecto vacío
        public string Fcar { get; set; }
        // por defecto vacío
        public string Plan { get; set; }
        // Código del transportista (numérico)
        public string Transportista { get; set; }
        // servicios vacío por defecto
        public string Serv { get; set; }
        // ,  doble carga (1=habilita segundo local)
        public int DbCarga { get; set; }
        // Usuario de creacion
        public string User { get; set; }
        // por defecto 0 cuando es contenedor
        public bool CarSuelta { get; set; }
    }
    public class TMS_SolicitudTPLDetalle
    {
        public string TOPE { get; set; }
        public int ROT_KRO { get; set; }
        public int ROT_KITEM { get; set; }
        public string ROT_ContenedorCodigo { get; set; }
        public string ROT_ContenedorTipo { get; set; }
        public int ROT_ContenedorPies { get; set; }
        public string User { get; set; }
        public int ROT_Item { get; set; }
    }


}
