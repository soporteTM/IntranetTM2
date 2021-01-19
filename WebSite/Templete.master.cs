using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Security;
using System.Data;
using BL;
using EL;

public partial class MasterPage : System.Web.UI.MasterPage
{
    //public BD_IntranetFIEntities CMScontext = new BD_IntranetFIEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtUsuario.Text = HttpContext.Current.User.Identity.Name;
            setValoresSesion();
        }
    }


    public void CargarAlertas(string ale_perfil, string ale_perfil2)
    {
        AlertaBL oAlertaBL = new AlertaBL();
        AlertaEL oAlertaEL = new AlertaEL();
        List<AlertaEL> lst1 = oAlertaBL.ListarAlertas(ale_perfil, ale_perfil2);

        if(lst1.Count > 0)
        {
            string menu = "";
            string codigo = lst1[0].ale_codigo;
            int nro_fila = 0;
            string rurl = ResolveClientUrl("~/Modulos/Alertas/Alertas.aspx");
            for (int i=0; i < lst1.Count; i++)
            {
                menu += "<li>" +
                      "<a href='" + rurl + "' class=\"user-list-item\">" +
                              "<div onclick=\"\" class=\"" + lst1[i].ale_clase + "\">" +
                                    "<i class=\"" + lst1[i].ale_icono + "\"></i>" +
                              "</div>" +
                              "<div class=\"user-desc\">" +
                                    "<span class=\"name\">" + lst1[i].ale_encabezado + "</span>" +
                                    "<span class=\"desc\">" + lst1[i].ale_mensaje + "</span>" +
                              "</div>" +
                      "</a>" +
                    "</li>";

                codigo = lst1[i].ale_codigo;
                nro_fila = i;
                noti.Text = i+1+"";
            }
            ltNotify.Text = menu.Replace("active", "");
        }

    }

    public void CargarMenu(string perfil)
    {
        EcoMenuBL oMenuBL = new EcoMenuBL();
        EcoMenuEL objMenu = new EcoMenuEL();
        objMenu.MEN_DESCRIPCION = perfil;
        List<EcoMenuEL> lst2 = oMenuBL.ListarMenu(objMenu);
        if(lst2.Count>0)
        { 
            string menu="";
            int cod_paterno = lst2[0].MEN_CODIGO_PADRE;
            int nro_fila = 0;
            string items = "";

            for(int i = 0; i < lst2.Count; i++)
            {
                if (cod_paterno == lst2[i].MEN_CODIGO_PADRE)
                {
                    string rurl = ResolveClientUrl(lst2[i].MEN_URL);
                    items += "<li><a href='"+ rurl + "'>"+lst2[i].MEN_DESCRIPCION+"</a></li>";
                    //items += "<li><a href='"+lst2[i].MEN_URL + "'" + lst2[i].MEN_DESCRIPCION + "</a></li>";
                    //items += "<li><a href=\"" + lst2[i].MEN_URL + "\">" + lst2[i].MEN_DESCRIPCION + "</a></li>";
                    //htmlBuilder.AppendLine(String.Format("<a href=\"{0}/articles/csharp/miscellaneous/asds.aspx\"> {1} </a>", Solicitud.ApplicationPath, featuredDataRow[4].ToString())); // eliminado: runat = servidor // agregado Request.ApplicationPath 
                }
                else
                {
                    if (cod_paterno == 1)
                    {
                        menu += "  <li class=\"has_sub\"><a href = \""+ResolveClientUrl("~/default.aspx") +"\" class=\"waves-effect\"><i class=\"mdi mdi-home\"></i> <span> Inicio</span> </a></li>";
                        items = "";
                        cod_paterno = lst2[i].MEN_CODIGO_PADRE;
                        nro_fila = i;
                    }
                    else
                    {
                        menu +="<li class=\"has_sub\">" +
                                    "<a href=\"javascript: void(0); \" class=\"waves-effect\"><i class=\"" + lst2[nro_fila].MEN_ICONO + "\"></i><span>" + lst2[nro_fila].MEN_DESCRIPCION + "</span> <span class=\"menu-arrow\"></span></a>" +
                                    "<ul class=\"list-unstyled\">" +
                                        items +
                                    "</ul>" +
                               "</li>";
                        items = "";
                        cod_paterno = lst2[i].MEN_CODIGO_PADRE;
                        nro_fila = i;
                    }
                }
            }
            menu +="<li class=\"has_sub\">" +
                        "<a href=\"javascript: void(0); \" class=\"waves-effect\"><i class=\"" + lst2[nro_fila].MEN_ICONO + "\"></i><span>" + lst2[nro_fila].MEN_DESCRIPCION + "</span> <span class=\"menu-arrow\"></span></a>" +
                        "<ul class=\"list-unstyled\">" +
                            items +
                        "</ul>" +
                    "</li>";
            lt.Text = menu.Replace("active","");
        }
    }

    public void setValoresSesion()
    {
        HttpCookie authCookie   = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        if ( authCookie!=null){
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            String dataUser   = ( authTicket.UserData != null && authTicket.UserData != ""?authTicket.UserData : "");
            String [] data = dataUser.Split('|');
            nomUser.InnerText = data[2];
            string perfil = data[3];
            CargarMenu(perfil);
            CargarAlertas(data[4],perfil);
        }
    }
    protected void btnAgregarConcepto_Click(object sender, EventArgs e)
    {
         HttpCookie authCookie   = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
         if (authCookie != null)
         {
             FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
             String dataUser = (authTicket.UserData != null && authTicket.UserData != "" ? authTicket.UserData : "");
             String[] data = dataUser.Split('|');
             int codigo = Convert.ToInt32(data[0]);
            
             //if (data[1] == "U")
             //{
             //    MAE_Usuarios entidad = (from cont in CMScontext.MAE_Usuarios where cont.IDUsuario == codigo select cont).FirstOrDefault();
             //    if (entidad != null)
             //    {
             //        entidad.Clave = txtNuevaContraseña.Text;
             //        CMScontext.SaveChanges();
             //        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("dmyHis"), "JAlert('Se cambio contraseña con éxito','','success');", true);

             //    }
             //    else
             //    {
             //        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("dmyHis"), "JAlert('Validación de usuario incorrecta','','error');", true);

             //    }
             //}
             if (data[1] == "P")
             {
                 //MAE_Personal entidad = (from cont in CMScontext.MAE_Personal where cont.IDPersonal == codigo select cont).FirstOrDefault();
                 //if (entidad != null)
                 //{
                 //    entidad.Clave = txtNuevaContraseña.Text;
                 //    CMScontext.SaveChanges();
                 //    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("dmyHis"), "JAlert('Se cambio contraseña con éxito','','success');", true);

                 //}
                 //else
                 //{
                 //    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("dmyHis"), "JAlert('Validación de usuario incorrecta','','error');", true);

                 //}
             }
         }
    }
}
