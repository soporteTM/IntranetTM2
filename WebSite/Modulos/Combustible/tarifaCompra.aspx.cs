using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Combustible_tarifaCompra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarTarifa();
            Perfil();
        }
    }

    public void Perfil()
    {
        HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        if (authCookie != null)
        {
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            String dataUser = (authTicket.UserData != null && authTicket.UserData != "" ? authTicket.UserData : "");
            String[] data = dataUser.Split('|');
            hfUsuario.Value = data[0];
        }
    }

    protected void lnkTarifa_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalAlert').modal('show');", true);
    }

    protected void lnkRegistrar_Click(object sender, EventArgs e)
    {
        try
        {
            RegistrarTarifa();
            ListarTarifa();
            MostrarMensaje(0, "se realizo el registro de la tarifa correctamente");
        }
        catch(Exception ex)
        {
            MostrarMensaje(1,"No se pudo realizar el registro de la tarifa");
        }
    }

    public void MostrarMensaje(int error,string mensaje)
    {
        if (error == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('" + mensaje + "','Alerta:','success');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('" + mensaje + "','Alerta:','error');", true);
        }
    }
    protected void RegistrarTarifa()
    {
        CombustibleCompraBL oTarifaBL = new CombustibleCompraBL();
        CombustibleCompraEL oTarifaEL = new CombustibleCompraEL();
        oTarifaEL.precio_compra_cisterna = Convert.ToDecimal(txtCisterna.Text);
        oTarifaEL.precio_compra_grifo = Convert.ToDecimal(txtGrifo.Text);
        oTarifaEL.fecha_registro = txtFecha.Text;
        oTarifaEL.usuario= hfUsuario.Value;
        oTarifaBL.RegistrarCompraCombustible(oTarifaEL);
    }

    protected void EliminarTarifa(string id)
    {
        CombustibleCompraBL oTarifaBL = new CombustibleCompraBL();
        CombustibleCompraEL oTarifaEL = new CombustibleCompraEL();
        oTarifaEL.id_PC = Convert.ToInt32(id);
        oTarifaBL.EliminarCompraCombustible(oTarifaEL);
    }

    public void ListarTarifa()
    {
        CombustibleCompraBL oCisterna = new CombustibleCompraBL();
        List<CombustibleCompraEL> lst = oCisterna.ListarCompraCombustible();
        gvTarifas.DataSource = lst;
        gvTarifas.DataBind();
    }

    protected void gvTarifas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "eliminar":
                try
                {
                    EliminarTarifa(e.CommandArgument.ToString());
                    ListarTarifa();
                    MostrarMensaje(0, "se elimino correctamente");
                }
                catch(Exception ex)
                {
                    MostrarMensaje(1,"No se pudo eliminar correctamente");
                }
                
                break;
        }
    }
}