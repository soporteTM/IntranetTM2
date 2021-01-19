using BL;
using BL;
using DAL;
using EL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Vacaciones_aprobacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Perfil();
            ListarVacaciones(hfSolicitante.Value);
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
            hfSolicitante.Value = data[4];
        }
    }

    public void ListarVacaciones(string id)
    {
        VacacionesAprobacionBL oVacaciones3 = new VacacionesAprobacionBL();
        VacacionesSolicitudEL objVacaciones3 = new VacacionesSolicitudEL();
        objVacaciones3.id_empleado = Convert.ToInt32(id);
        List<VacacionesPendientesEL> lst3 = oVacaciones3.ListarPendientes(objVacaciones3);
        grvPendientes.DataSource = lst3;
        grvPendientes.DataBind();
        if (grvPendientes.Rows.Count > 0)
        {
            pnl1.Visible = true;
        }
        else
        {
            pnl1.Visible = false;
        }

    }

    public void EnviarMailAprobacion(int id_aprobacion,string nom_solicitante,string finicio,string ffin,string dias)
    {
        VacacionesEmailBL oVacaciones = new VacacionesEmailBL();
        List<VacacionesEmailEL> lst = oVacaciones.ConsultarEmailAprobacion(id_aprobacion);

        string correo = ConfigurationManager.AppSettings["correoAprobacionVacaciones"];
        StringBuilder emailHtml = new StringBuilder(File.ReadAllText(Server.MapPath("mails/Aprobado.html")));
        emailHtml.Replace("[%solicitante%]", nom_solicitante);
        emailHtml.Replace("[%finicio%]", finicio);
        emailHtml.Replace("[%ffin%]", ffin);
        emailHtml.Replace("[%dias%]", dias);

        VacacionesEmailBL oEmail = new VacacionesEmailBL();
        string from, body, sub,BC;
        from = lst[0].nom_user;
        BC = correo;
        body = emailHtml.ToString();
        sub = "Solicitud de Vacaciones Aprobada";

        List<VacacionesEmailEL> lst2 = oEmail.EnviarEMail(from, body, sub,BC);
    }

    public void EnviarMailRechazo(int id_aprobacion, string nom_solicitante, string finicio, string ffin, string dias)
    {
        VacacionesEmailBL oVacaciones = new VacacionesEmailBL();
        List<VacacionesEmailEL> lst = oVacaciones.ConsultarEmailAprobacion(id_aprobacion);


        string correo = ConfigurationManager.AppSettings["correoAprobacionVacaciones"];
        StringBuilder emailHtml = new StringBuilder(File.ReadAllText(Server.MapPath("mails/Rechazo.html")));
        emailHtml.Replace("[%solicitante%]", nom_solicitante);
        emailHtml.Replace("[%finicio%]", finicio);
        emailHtml.Replace("[%ffin%]", ffin);
        emailHtml.Replace("[%dias%]", dias);

        VacacionesEmailBL oEmail = new VacacionesEmailBL();
        string from, body, sub, BC;
        from = lst[0].nom_user;
        BC = correo;
        body = emailHtml.ToString();
        sub = "Solicitud de Vacaciones Rechazada";

        List<VacacionesEmailEL> lst2 = oEmail.EnviarEMail(from, body, sub, BC);
    }


    public void Prerender(GridView x)
    {
        if (x.Rows.Count > 0)
        {
            x.UseAccessibleHeader = true;
            x.HeaderRow.TableSection = TableRowSection.TableHeader;
            x.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    public void ReporteVacaciones()
    {
        VacacionesReporteBL VacacionesBL = new VacacionesReporteBL();
        VacacionesReporteEL VacacionesEL = new VacacionesReporteEL();
        var GridView1 = new GridView();

        GridView1.DataSource = VacacionesBL.ListarReporteExcel();
        GridView1.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attacNhment;filename=ReporteVacaciones_" + DateTime.Now.ToString("ddMMyyyy") + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            GridView1.AllowPaging = false;
            GridView1.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                cell.BackColor = GridView1.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GridView1.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            GridView1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }



    

    public string RespuestaAprobacion(int idApro, string estado)
    {
        VacacionesAprobacionBL oVacaciones = new VacacionesAprobacionBL();
        VacacionesAprobacionEL objVacaciones = new VacacionesAprobacionEL();
        objVacaciones.id_aprobacion = idApro;
        objVacaciones.estado = estado;
        List<TransaccionEL> lst = oVacaciones.RespuestaAprobacion(objVacaciones);
        return lst[0].mensaje;
    }

    public void EliminarVacaciones(string id)
    {
        VacacionesSolicitudBL oVacaciones = new VacacionesSolicitudBL();
        VacacionesSolicitudEL objVacaciones = new VacacionesSolicitudEL();
        objVacaciones.id_solicitud = Convert.ToInt32(id);
        List<VacacionesSolicitudEL> lst = oVacaciones.EliminarVacaciones(objVacaciones);
    }
    
    
    

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        ListarVacaciones(hfSolicitante.Value);
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
    

    protected void grvPendientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Aprobar":
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModaAprobar').modal('show');", true);
                hfRespuesta.Value = e.CommandArgument.ToString();
                break;
            case "Rechazar":
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModaRechazar').modal('show');", true);
                hfRespuesta.Value = e.CommandArgument.ToString();
                break;
        }
    }


    public void AprobarVacaciones(string respuesta)
    {
        string[] arg = new string[5];
        arg = respuesta.Split(';');
        if(RespuestaAprobacion(Convert.ToInt32(arg[0]), "320200").Equals("0"))
        {
            EnviarMailAprobacion(Convert.ToInt32(arg[0]), arg[1], arg[2], arg[3], arg[4]);
        }
        MostrarMensaje(0, "La solicitud fue Aprobada con exito");
        ListarVacaciones(hfSolicitante.Value);
    }

    public void RechazarVacaciones(string respuesta)
    {
        string[] arg = new string[5];
        arg = respuesta.Split(';');
        RespuestaAprobacion(Convert.ToInt32(arg[0]), "320300");
        MostrarMensaje(0, "La solicitud fue Rechazada con exito");
        EnviarMailRechazo(Convert.ToInt32(arg[0]), arg[1], arg[2], arg[3], arg[4]);
        ListarVacaciones(hfSolicitante.Value);
    }

    protected void grvPendientes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblEstado = (Label)e.Row.FindControl("lblEstado");
            LinkButton btnaprobar = (LinkButton)e.Row.FindControl("btnaprobar");
            LinkButton btnrechazar = (LinkButton)e.Row.FindControl("btnrechazar");

            if (lblEstado.Text == "PENDIENTE")
            {
                lblEstado.Text = "PENDIENTE";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-warning m-b-5";
                btnaprobar.Visible = true;
                btnrechazar.Visible = true;
            }
            else if (lblEstado.Text == "APROBADO")
            {
                lblEstado.Text = "APROBADO";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-teal m-b-5";
            }
            else if (lblEstado.Text == "RECHAZADO")
            {
                lblEstado.Text = "RECHAZADO";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-danger m-b-5";
            }
            else if (lblEstado.Text == "CANCELADO")
            {
                lblEstado.Text = "CANCELADO";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-brown m-b-5";
            }
        }
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        ReporteVacaciones();
    }
    

    protected void grvPendientes_PreRender(object sender, EventArgs e)
    {
        Prerender(grvPendientes);
    }

    protected void btnResumen_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalResumen').modal('show');", true);
    }

    protected void grvSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblEstado = (Label)e.Row.FindControl("lblEstado");
            LinkButton btnaprobar = (LinkButton)e.Row.FindControl("btnaprobar");
            LinkButton btnrechazar = (LinkButton)e.Row.FindControl("btnrechazar");

            if (lblEstado.Text == "PENDIENTE")
            {
                lblEstado.Text = "PENDIENTE";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-warning m-b-5";

            }
            else if (lblEstado.Text == "APROBADO")
            {
                lblEstado.Text = "APROBADO";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-teal m-b-5";

            }
            else if (lblEstado.Text == "RECHAZADO")
            {
                lblEstado.Text = "RECHAZADO";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-danger m-b-5";
            }
            else if (lblEstado.Text == "CANCELADO")
            {
                lblEstado.Text = "CANCELADO";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-brown m-b-5";
            }
        }
    }

    protected void btnAprobar_Click(object sender, EventArgs e)
    {
        AprobarVacaciones(hfRespuesta.Value);
    }

    protected void btnRechazar_Click(object sender, EventArgs e)
    {
        RechazarVacaciones(hfRespuesta.Value);
    }
}