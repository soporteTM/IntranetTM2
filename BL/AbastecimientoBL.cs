using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AbastecimientoBL
    {
        public List<AbastecimientoEL> ConsultarDetalle(int id_cisterna, int id_cliente, int id_abastecimiento)
        {
            AbastecimientoDAL oAbas = new AbastecimientoDAL();
            return oAbas.ConsultarAbastecimiento(id_cisterna, id_cliente,id_abastecimiento);
        }

        public List<TransaccionEL> GenerarLiquidacion(AbastecimientoEL oAbastecimiento)
        {
            AbastecimientoDAL oAbas = new AbastecimientoDAL();
            return oAbas.GenerarLiquidacion(oAbastecimiento);
        }

        public List<TransaccionEL> ActualizarAbastecimiento(AbastecimientoEL oAbastecimiento)
        {
            AbastecimientoDAL oAbas = new AbastecimientoDAL();
            return oAbas.ActualizarAbastecimiento(oAbastecimiento);
        }

        public List<TransaccionEL> RegistrarConsumo(AbastecimientoEL oAbastecimiento)
        {
            AbastecimientoDAL oAbas = new AbastecimientoDAL();
            return oAbas.RegistrarConsumo(oAbastecimiento);
        }

        public List<AbastecimientoEL> AbastecimientoDisponible(AbasteciminetoDisponibleEL oaba)
        {
            AbastecimientoDAL oAbas = new AbastecimientoDAL();
            return oAbas.AbastecimientoDisponible(oaba);
        }

        public List<AbastecimientoEL> ActualizarLiquidacion(AbastecimientoEL oaba)
        {
            AbastecimientoDAL oAbas = new AbastecimientoDAL();
            return oAbas.ActualizarLiquidacion(oaba);
        }

        public List<AbastecimientoEL> ListarAbastecedor()
        {
            AbastecimientoDAL oAbas = new AbastecimientoDAL();
            return oAbas.ListarAbastecedor();
        }

        //REPORTE COMBUSTIBLE

        public List<AbastecimientoEL> ListarReportePlaca(int Año, int mes, string placa,string cliente)
        {
            AbastecimientoDAL oAbas = new AbastecimientoDAL();
            return oAbas.ListarReportePlaca(Año,mes,placa, cliente);
        }

        public List<AbastecimientoEL> ListarReporteOperacion(int Año, int mes)
        {
            AbastecimientoDAL oAbas = new AbastecimientoDAL();
            return oAbas.ListarReporteOperacion(Año,mes);
        }

        public List<AbastecimientoEL> ListarReporteOperacionAnual(int Año)
        {
            AbastecimientoDAL oAbas = new AbastecimientoDAL();
            return oAbas.ListarReporteOperacionAnual(Año);
        }

        public List<AbastecimientoEL> ListarReporteVentas(int Año, int mes)
        {
            AbastecimientoDAL oAbas = new AbastecimientoDAL();
            return oAbas.ListarReporteVentas(Año, mes);
        }

        public List<CombustibleCompraEL> VariacionDieselMensual(int Año, int mes)
        {
            AbastecimientoDAL oAbas = new AbastecimientoDAL();
            return oAbas.VariacionDieselMensual(Año, mes);
        }

        public List<CombustibleCompraEL> VariacionDieselAnual(int Año)
        {
            AbastecimientoDAL oAbas = new AbastecimientoDAL();
            return oAbas.VariacionDieselAnual(Año);
        }
    }
}
