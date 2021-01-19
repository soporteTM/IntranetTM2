using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_SIG_Solicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Perfil();
        ListarSolicitud();
    }

    public void Perfil()
    {
        HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        if (authCookie != null)
        {
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            String dataUser = (authTicket.UserData != null && authTicket.UserData != "" ? authTicket.UserData : "");
            String[] data = dataUser.Split('|');
            hfNomUser.Value = data[0];
        }
    }

    public void ListarSolicitud()
    {
        SIG_EmpresaBL oEmp = new SIG_EmpresaBL();
        List<SIG_EmpresaEL> lst = oEmp.ListarSolicitud();
        grvEmpresa.DataSource = lst;
        grvEmpresa.DataBind();
    }

    protected void grvEmpresa_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        hfCodEmpresa.Value = e.CommandArgument.ToString();
        switch (e.CommandName.ToString())
        {
            case "Aceptar":
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModaAprobar').modal('show');", true);
                break;
            case "Rechazar":
                txtObservacion.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModaRechazar').modal('show');", true);
                break;
        }
    }

    public void MostrarMensaje(int error, string mensaje)
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

    protected void btnAprobar_Click(object sender, EventArgs e)
    {
        try
        {
            SIG_EmpresaBL EmpresaBL = new SIG_EmpresaBL();
            SIG_EmpresaEL oEmp = new SIG_EmpresaEL();
            oEmp.Estado = "1";
            oEmp.Observaciones = "";
            oEmp.Cod_Empresa = Convert.ToInt32(hfCodEmpresa.Value);
            oEmp.usuario_modificacion = hfNomUser.Value;
            EmpresaBL.RepuestaSolicitud(oEmp);
            MostrarMensaje(0, "Se aprobo la solicitud seleccionada");
            ListarSolicitud();

        }
        catch(Exception ex)
        {
            MostrarMensaje(1,"No se pudo realizar la operacion");
        }


    }

    protected void btnRechazar_Click(object sender, EventArgs e)
    {
        try
        {
            SIG_EmpresaBL EmpresaBL = new SIG_EmpresaBL();
            SIG_EmpresaEL oEmp = new SIG_EmpresaEL();
            oEmp.Estado = "3";
            oEmp.Observaciones = txtObservacion.Text;
            oEmp.Cod_Empresa = Convert.ToInt32(hfCodEmpresa.Value);
            oEmp.usuario_modificacion = hfNomUser.Value;
            EmpresaBL.RepuestaSolicitud(oEmp);
            MostrarMensaje(0, "Se rechazo la solicitud seleccionada");
            ListarSolicitud();
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo realizar la operacion");
        }
    }
}