using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Combustible_tarifas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarTarifa();
            ListarCliente();
        }    
    }

    public void ListarTarifa()
    {
        TarifaBL oCisterna = new TarifaBL();
        List<TarifaEL> lst = oCisterna.ListarTarifa();
        gvTarifas.DataSource = lst;
        gvTarifas.DataBind();
    }

    public void ListarCliente()
    {
        ClienteBL oCliente = new ClienteBL();
        List<ClienteEL> lst = oCliente.ListarCliente();
        ddlCliente.DataSource = lst;
        ddlCliente.DataValueField = "id_empresa";
        ddlCliente.DataTextField = "nom_empresa";
        ddlCliente.DataBind();
        ddlCliente.Items.Insert(0, new ListItem("-- TODOS --", ""));
        ddlCliente.SelectedIndex = 0;
    }

    protected void RegistrarTarifa(int id, decimal precio, decimal precio_igv)
    {
        TarifaBL oTarifaBL = new TarifaBL();
        TarifaEL oTarifaEL = new TarifaEL();
        oTarifaEL.id_cliente = id;
        oTarifaEL.precio_tarifa_igv = precio_igv;
        oTarifaEL.precio_tarifa_no_igv = precio;

        List<TransaccionEL> lst = oTarifaBL.RegistrarTarifa(oTarifaEL);

        if (lst[0].id_mensaje == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se registro la tarifa con exito.','Alerta:','success');", true);
        }

    }

    protected void gvTarifas_PreRender(object sender, EventArgs e)
    {
        if (gvTarifas.Rows.Count > 0)
        {
            gvTarifas.UseAccessibleHeader = true;
            gvTarifas.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvTarifas.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void lnkTarifa_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalAlert').modal('show');", true);
    }

    protected void lnkRegistrar_Click(object sender, EventArgs e)
    {
        int id_cliente = int.Parse(ddlCliente.SelectedValue);
        decimal precio = decimal.Parse(txtVenta.Text);
        decimal precio_igv = decimal.Parse(txtVentaIGV.Text);
        RegistrarTarifa(id_cliente, precio, precio_igv);
        ListarTarifa();
    }
}