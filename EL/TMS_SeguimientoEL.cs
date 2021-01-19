using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class TMS_SeguimientoEL
    {
        public string Solicitud { get; set; }
        public string ROAL { get; set; }
        public string CODCLI1 { get; set; }
        public string Cliente { get; set; }
        public string CODCLI2 { get; set; }

        public int RO { get; set; }
        public int ITEM { get; set; }
        public string Ter1 { get; set; }
        public string FechaLlTR { get; set; }
		public string HoraLlTR { get; set; }
		public string FechaInTR { get; set; }
		public string HoraInTR{ get; set; }
        public string FechaSaTR { get; set; }
        public string HoraSaTR { get; set; }
        public string ObsTR { get; set; }
        public string Ent1 { get; set; }
        public int Loc1 { get; set; }
        public string FechaLlCL1 { get; set; }
        public string HoraLlCL1 { get; set; }
        public string FechaIngCL1 { get; set; }
        public string HoraIngCL1 { get; set; }
        public string FechaInCL1 { get; set; }
        public string HoraInCL1 { get; set; }
        public string FechaTeCL1 { get; set; }
        public string HoraTeCL1 { get; set; }
        public string FechaSaCL1 { get; set; }
        public string HoraSaCL1 { get; set; }
        public string ObsCL1 { get; set; }
        public string Ent2 { get; set; }
        public int Loc2 { get; set; }
        public string FechaLlCL2 { get; set; }
        public string HoraLlCL2 { get; set; }
        public string FechaIngCL2 { get; set; }
        public string HoraIngCL2 { get; set; }
        public string FechaInCL2 { get; set; }
        public string HoraInCL2 { get; set; }
        public string FechaTeCL2 { get; set; }
        public string HoraTeCL2 { get; set; }
        public string FechaSaCL2 { get; set; }
        public string HoraSaCL2 { get; set; }
        public string ObsCL2 { get; set; }
        public string Ter2 { get; set; }
        public string FechaLlTD { get; set; }
        public string HoraLlTD { get; set; }
        public string FechaInTD { get; set; }
        public string HoraInTD { get; set; }
        public string FechaSaTD { get; set; }
        public string HoraSaTD { get; set; }
        public string ObsTD { get; set; }
        public int Unidad { get; set; }
        public int Chofer { get; set; }
        public string DNI_Chofer { get; set; }
        public int Evento { get; set; }
        public int Empresa { get; set; }
        public string PreCtn { get; set; }
        public string PreLin { get; set; }
        public string PreAdu { get; set; }
        public string PreTra { get; set; }
        public int Pernoc { get; set; }
        public int DblCar { get; set; }
        //public Boolean Seg_GpsT1E { get; set; }
        //public Boolean Seg_GpsT1S { get; set; }
        //public Boolean Seg_GpsC1E { get; set; }
        //public Boolean Seg_GpsC1S { get; set; }
        //public Boolean Seg_GpsT2E { get; set; }
        //public Boolean Seg_GpsT2S { get; set; }

        //campos para llenar ddl's
        public string Dep_Desc { get; set; }
        public string Dep_Codi { get; set; }

        public string Usuario { get; set; }

        public string EMPRETRANS_RAZONSOCIAL { get; set; }
        public int EMPRETRANS_CODIGO { get; set; }

        public int UNIDAD_CODIGO { get; set; }
        public string UNIDAD_PLACA { get; set; }

        
    }
}
