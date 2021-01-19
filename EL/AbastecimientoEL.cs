using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class AbastecimientoEL
    {
        public int id_abastecimiento { get; set; }
        public int id_cisterna { get; set; }
        public string cod_empresa { get; set; }
        public string nom_empresa { get; set; }
        public string fecha_registro { get; set; }
        /*********/
        public string cod_unidad { get; set; }
        /*********/
        public string unidad { get; set; }
        public string nro_placa { get; set; }
        public decimal cnt_inicial { get; set; }
        public decimal cnt_final { get; set; }
        public decimal km_unidad { get; set; }
        public decimal horometro { get; set; }
        public string nom_conductor { get; set; }
        public decimal cantidad_gl { get; set; }
        public decimal precio_galon_igv { get; set; }
        public decimal total_venta { get; set; }
        public string estado { get; set; }
        public string nro_despacho { get; set; }
        public int id_liquidacion { get; set; }
        public DateTime fecha_liquidacion { get; set; }

        public int abastecedor { get; set; }
        public string nom_abastecedor { get; set; }

        public string descripcion { get; set; }
        public string valor1 { get; set; }

        public string usuario { get; set; }

        public string OPERACION { get; set; }
        public string CONSUMO { get; set; }
        public decimal KmGalon { get;set;}
        public decimal Km_Mayor { get; set; }
        public decimal KM_Menor { get; set; }
        public decimal Km_recorrido { get; set; }

        //REPORTE VENTAS
        public decimal VentaDeGalones { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal Ganancia { get; set; }
        public decimal Variacion { get; set; }
        public decimal precio_compra { get; set; }
        public decimal Ahorro { get; set; }
        public decimal PrecioGrifo { get; set; }
        public decimal PrecioCisterna { get; set; }
    }

    public class AbasteciminetoDisponibleEL
    {
        public int id_TV { get; set; }
        public int id_cliente { get; set; }
        public DateTime fch_inicio { get; set; }
        public DateTime fch_fin { get; set; }
    }
}
