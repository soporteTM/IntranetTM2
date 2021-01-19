using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Alertas_Alertas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Perfil();

        }
    }

    public void Perfil()
    {
        HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        string perfil = "";
        if (authCookie != null)
        {
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            String dataUser = (authTicket.UserData != null && authTicket.UserData != "" ? authTicket.UserData : "");
            String[] data = dataUser.Split('|');
            perfil = data[3];
            ListarAlertas(perfil,data[4]);
            ActualizarAlertas(perfil);
        }        
    }
    protected void grvAlertas_PreRender(object sender, EventArgs e)
    {
        if (grvAlertas.Rows.Count > 0)
        {
            grvAlertas.UseAccessibleHeader = true;
            grvAlertas.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvAlertas.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    public void ListarAlertas(string ale_perfil,string ale_perfil2)
    {
        AlertaBL oAlertas = new AlertaBL();
        List<AlertaEL> lst = oAlertas.ListarAlertas(ale_perfil,ale_perfil2);
        grvAlertas.DataSource = lst;
        grvAlertas.DataBind();
        totalizar();
    }

    public int totalizar()
    {
        int suma = 0;

        //for (int i = 0; i < grvAlertas.Rows.Count; i++)
        //{

            suma += (int)grvAlertas.Rows.Count;
        //}

        lblmsg.Text = " " + suma + " ";

        return suma;
    }


    public void ActualizarAlertas(string ale_perfil)
    {
        AlertaBL oAlertas = new AlertaBL();
        List<AlertaEL> lst = oAlertas.ActualizarAlertas(ale_perfil);

    }
}