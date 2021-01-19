using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EstadisticaOPEL
    {
        public DateTime fchIni { get; set; }
        public DateTime fchFin { get; set; }
    }
    public class EstadisticasServiciosOP
    {
        public string fecha { get; set; }
        public int total { get; set; }
        public int servicios_APM { get; set; }
        public int servicios_DPW { get; set; }
        public int embarque { get; set; }
        public int embarque_APM { get; set; }
        public int embarque_DPW { get; set; }
        public int embarque_vacio { get; set; }
        public int embarque_vacio_APM { get; set; }
        public int embarque_vacio_DPW { get; set; }
        public int descarga { get; set; }
        public int descarga_APM { get; set; }
        public int descarga_DPW { get; set; }
        public int descarga_vacio { get; set; }
        public int descarga_vacio_APM { get; set; }
        public int descarga_vacio_DPW { get; set; }
    }

    public class EstadisticasTercerosOP
    {
        public string fecha { get; set; }
        public int servicios_terceros { get; set; }
        public int servicios_propios { get; set; }
        public int embarque_vacio_propio { get; set; }
        public int embarque_vacio_tercero { get; set; }
        public int descarga_vacio_propio { get; set; }
        public int descarga_vacio_tercero { get; set; }
        public int embarque_APM_tercero { get; set; }
        public int embarque_APM_propio { get; set; }
        public int descarga_APM_tercero { get; set; }
        public int descarga_APM_propio { get; set; }
        public int descarga_vacio_APM_tercero { get; set; }
        public int descarga_vacio_APM_propio { get; set; }
        public int embarque_vacio_APM_tercero { get; set; }
        public int embarque_vacio_APM_propio { get; set; }
        public int embarque_DPW_tercero { get; set; }
        public int embarque_DPW_propio { get; set; }
        public int descarga_DPW_tercero { get; set; }
        public int descarga_DPW_propio { get; set; }
        public int descarga_vacio_DPW_tercero { get; set; }
        public int descarga_vacio_DPW_propio { get; set; }
        public int embarque_vacio_DPW_tercero { get; set; }
        public int embarque_vacio_DPW_propio { get; set; }


        //public int APM_embarque_tercero { get; set; }
        //public int APM_embarque_propio { get; set; }
        //public int APM_descarga_tercero { get; set; }
        //public int APM_descarga_propio { get; set; }
        //public int APM_vacio_descarga_tercero { get; set; }
        //public int APM_vacio_descarga_propio { get; set; }
        //public int APM_vacio_embarque_tercero { get; set; }
        //public int APM_vacio_embarque_propio { get; set; }
        //public int DPW_embarque_tercero { get; set; }
        //public int DPW_embarque_propio { get; set; }
        //public int DPW_descarga_tercero { get; set; }
        //public int DPW_descarga_propio { get; set; }
        //public int DPW_vacio_descarga_tercero { get; set; }
        //public int DPW_vacio_descarga_propio { get; set; }
        //public int DPW_vacio_embarque_tercero { get; set; }
        //public int DPW_vacio_embarque_propio { get; set; }

    }
}
