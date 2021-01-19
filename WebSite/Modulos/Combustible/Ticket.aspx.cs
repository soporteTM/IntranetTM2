using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Combustible_Ticket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id_cisterna = Convert.ToInt32(Request.QueryString["id_cisterna"]);
        int id_abastecimiento = Convert.ToInt32(Request.QueryString["id_abas"]);

        ListarDetalle(id_cisterna,0, id_abastecimiento);
    }

    public void ListarDetalle(int id_cisterna, int id_cliente,int id_abastecimiento)
    {
        AbastecimientoBL oDetalle = new AbastecimientoBL();
        List<AbastecimientoEL> lst = oDetalle.ConsultarDetalle(id_cisterna, id_cliente,id_abastecimiento);
        if (lst.Count > 0)
        {
            lblNroTicket.Text = lst[0].nro_despacho;
            lblFechaEmision.Text = lst[0].fecha_registro;
            lblRUC.Text = lst[0].cod_empresa;
            lblEmpresa.Text = lst[0].nom_empresa;
            lblUnidad.Text = lst[0].unidad;
            lblPlaca.Text = lst[0].nro_placa;
            lblConductor.Text = lst[0].nom_conductor;
            lblkm.Text = Convert.ToString(lst[0].km_unidad);
            lblHorometro.Text = Convert.ToString(lst[0].horometro);
            lblCantidad.Text = lst[0].cantidad_gl.ToString("#,###.00") + "gl.";
            lblPrecio.Text = lst[0].precio_galon_igv.ToString("#,###.00");
            lblImporte.Text = lst[0].total_venta.ToString("#,###.00");
        }
        
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Modulos/Combustible/default.aspx");
    }
}