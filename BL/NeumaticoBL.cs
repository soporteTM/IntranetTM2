using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class NeumaticoBL
    {
        public List<NeumaticoEL> ConsultarNeumatico(string nro_placa)
        {
            NeumaticoDAL oNeumatico = new NeumaticoDAL();
            return oNeumatico.ConsultarNeumatico(nro_placa);
        }
        public List<NeumaticoEL> ListarNeumatico(int id)
        {
            NeumaticoDAL oNeumatico = new NeumaticoDAL();
            return oNeumatico.ListarNeumatico(id);
        }

        public List<NeumaticoEL> ListarNeumaticosReporte(int estado, string fechaInicio, string fechaFin)
        {
            NeumaticoDAL oNeumatico = new NeumaticoDAL();
            return oNeumatico.ListarNeumaticosReporte(estado, fechaInicio, fechaFin);
        }

        public List<NeumaticoEL> ListarNeumaticoHistorico(string Nserie)
        {
            NeumaticoDAL oNeumatico = new NeumaticoDAL();
            return oNeumatico.ListarNeumaticoHistorico(Nserie);
        }
        public List<TransaccionEL> RegistrarNeumatico(NeumaticoEL obj)
        {
            NeumaticoDAL oNeumatico = new NeumaticoDAL();
            return oNeumatico.RegistrarNeumatico(obj);
        }
        public List<TransaccionEL> EditarNeumatico(NeumaticoEL obj,int cod)
        {
            NeumaticoDAL oNeumatico = new NeumaticoDAL();
            return oNeumatico.EditarNeumatico(obj,cod);
        }
        
        public List<TransaccionEL> RegistrarNeumaticoFlota(NeumaticoEL obj,int estado)
        {
            NeumaticoDAL oNeumatico = new NeumaticoDAL();
            return oNeumatico.RegistrarNeumaticoFlota(obj,estado);
        }

        public List<NeumaticoEL> RegistrarReencauche(NeumaticoEL obj)
        {
            NeumaticoDAL oNeumatico = new NeumaticoDAL();
            return oNeumatico.RegistrarReencauche(obj);
        }

        
        public List<RendimientoEL> RendimientoNeumatico(string nro_placa)
        {
            NeumaticoDAL oNeumatico = new NeumaticoDAL();
            return oNeumatico.RendimientoNeumatico(nro_placa);
        }

        public List<NeumaticoEL> EliminarNeumatico(int id_nm,string usuario)
        {
            NeumaticoDAL oNeumatico = new NeumaticoDAL();
            return oNeumatico.EliminarNeumatico(id_nm, usuario);
        }

        public List<NeumaticoEL> EliminarNeumatico(int id_nm, string usuario, string cod_motivo, string R1, string R2, string R3, double kilometraje, string obs)
        {
            NeumaticoDAL oNeumatico = new NeumaticoDAL();
            return oNeumatico.EliminarNeumatico(id_nm, usuario, cod_motivo, R1, R2, R3, kilometraje, obs);
        }
    }
}
