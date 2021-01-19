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
using System.Net;

public partial class login : System.Web.UI.Page
{
    //public BD_IntranetFIEntities CMScontext = new BD_IntranetFIEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext.Current.Response.Cookies.Clear();
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
        }
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        //Buscar en Personal
        string usuario = txtUsuario.Text;
        string clave = txtContraseña.Text;

        UsuarioBL oUsuarioBL = new UsuarioBL();
        List<UsuarioEL> lst = oUsuarioBL.ValidarUsuario(usuario, clave);

        if (lst.Count > 0)
        {

            if (lst[0].estado_pwd == 0)
            {
                MultiView1.ActiveViewIndex = 2;
                txtActUsuario.Text = txtUsuario.Text;
            }
            else
            {

                foreach (UsuarioEL entidad in lst)
                {

                    string x = entidad.perfil.Substring(0,3);


                    String DataUsuario = entidad.nom_user + "|U|" + entidad.nom_usuario + "|" + entidad.perfil + "|" + entidad.id_empleado + "|" + entidad.id_usuario;
                    FormsAuthenticationTicket ticket1 = new FormsAuthenticationTicket(1, usuario.Trim().ToUpper(), DateTime.Now, DateTime.Now.AddMinutes(30), true, DataUsuario, FormsAuthentication.FormsCookiePath);
                    String encryptedTicket = FormsAuthentication.Encrypt(ticket1);
                    HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Current.Response.Cookies.Add(cookie1);
                    String returnUrl1;
                    //the login is successful
                    

                    if (HttpContext.Current.Request.QueryString["ReturnUrl"] == null)
                        returnUrl1 = FormsAuthentication.DefaultUrl;
                    else
                        returnUrl1 = HttpContext.Current.Request.QueryString["ReturnUrl"];

                    if (x.Equals("EXT"))
                    {
                        HttpContext.Current.Response.Redirect("http://localhost:59553/Modulos/SIG/Externo.aspx");
                    }

                    HttpContext.Current.Response.Redirect(returnUrl1);

                    
                }
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert....", "alert('Por favor, verifique que sus datos ingresados son correctos');", true);
        }
        
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        //Buscar en Personal
        string usuario = txtActUsuario.Text;
        string clave = txtActContraseña.Text;
        string nuevaClave = txtActNuevaContraseña.Text;
        string repetirNueva = txtActRepetir.Text;

        
            UsuarioBL oUsuarioBL = new UsuarioBL();
            List<UsuarioEL> lst = oUsuarioBL.ValidarUsuario(usuario, clave);

            if (lst.Count > 0)
            {
                if (nuevaClave.Equals(repetirNueva))
                {
                    oUsuarioBL.ActualizarContraseña(usuario, clave, nuevaClave);


                foreach (UsuarioEL entidad in lst)
                {

                    String DataUsuario = entidad.nom_user + "|U|" + entidad.nom_usuario + "|" + entidad.perfil + "|" + entidad.id_empleado + "|" + entidad.id_usuario;
                    FormsAuthenticationTicket ticket1 = new FormsAuthenticationTicket(1, usuario.Trim().ToUpper(), DateTime.Now, DateTime.Now.AddMinutes(30), true, DataUsuario, FormsAuthentication.FormsCookiePath);
                    String encryptedTicket = FormsAuthentication.Encrypt(ticket1);
                    HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Current.Response.Cookies.Add(cookie1);
                    String returnUrl1;
                    //the login is successful
                    if (HttpContext.Current.Request.QueryString["ReturnUrl"] == null)
                        returnUrl1 = FormsAuthentication.DefaultUrl;
                    else
                        returnUrl1 = HttpContext.Current.Request.QueryString["ReturnUrl"];

                    HttpContext.Current.Response.Redirect(returnUrl1);
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert....", "alert('Por favor, verifique que sus datos ingresados son correctos');", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Por favor, verifique que sus datos ingresados son correctos','Alerta:','error');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert....", "alert('Por favor, verifique que sus datos ingresados son correctos');", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Por favor, verifique que sus datos ingresados son correctos','Alerta:','error');", true);
        }
        
        
    }
}