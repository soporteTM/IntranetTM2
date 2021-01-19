using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FlotaBL
    {
        public List<TransaccionEL> RegistrarFlota(FlotaEL oFlota)
        {
            FlotaDAL oUnidad = new FlotaDAL();
            return oUnidad.RegistrarFlota(oFlota);
        }

        public List<TransaccionEL> ActualizarFlota(FlotaEL oFlota)
        {
            FlotaDAL oUnidad = new FlotaDAL();
            return oUnidad.ActualizarFlota(oFlota);
        }

        public List<FlotaEL> ConsultarFlota(int cod_flota,string nro_placa)
        {
            FlotaDAL oFlota = new FlotaDAL();
            return oFlota.ConsultarFlota(cod_flota,nro_placa);
        }

        public List<FlotaEL> ConsultarFlota_v2()
        {
            FlotaDAL oFlota = new FlotaDAL();
            return oFlota.ConsultarFlota_v2();
        }
        public List<NeumaticoEL> ConsultarFlotaNeumatico(int cod_flota)
        {
            FlotaDAL oFlota = new FlotaDAL();
            return oFlota.ConsultarFlotaNeumatico(cod_flota);
        }
        
        public DataTable ConsultarFlota()
        {
            FlotaDAL oFlota = new FlotaDAL();
            return oFlota.ConsultarFlota();
        }
    }
}
