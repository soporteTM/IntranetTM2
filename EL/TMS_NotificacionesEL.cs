using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class TMS_NotificacionesEL
    {
        public string Ent_Codi { get; set; }

        public string Movimiento { get; set; }

        public bool Ntf_RLlegada { get; set; }
        public bool Ntf_RIngreso { get; set; }
        public bool Ntf_RSalida { get; set; }
        public bool Ntf_RObs { get; set; }

        public bool Ntf_CLlegada { get; set; }
        public bool Ntf_CIngreso { get; set; }
        public bool Ntf_CInicio { get; set; }
        public bool Ntf_CTermino { get; set; }
        public bool Ntf_CSalida { get; set; }
        public bool Ntf_CObs { get; set; }

        public bool Ntf_DLlegada { get; set; }
        public bool Ntf_DIngreso { get; set; }
        public bool Ntf_DSalida { get; set; }
        public bool Ntf_DObs { get; set; }

        public bool Ntf_InfoEmpresa { get; set; }
        public bool Ntf_InfoUnidad { get; set; }
        public bool Ntf_InfoChofer { get; set; }
        public bool Ntf_InfoKmInicial { get; set; }
        public bool Ntf_InfoKmFinal { get; set; }
        public bool Ntf_InfoPCTNVacio { get; set; }
        public bool Ntf_InfoPLinea { get; set; }
        public bool Ntf_InfoPAduana { get; set; }
        public bool Ntf_InfoPTrans { get; set; }

        public string Usuario_Creacion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Usuario_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }

        public string Mail { get; set; }
        public string Estado_Mail { get; set; }
    }
}
