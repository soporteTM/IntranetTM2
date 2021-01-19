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
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Modulos_Vacaciones_Vacaciones : System.Web.UI.Page
{
    public CatalogoBL objCatalogo = new CatalogoBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Perfil();
            loadItems(ddlEstado, "32");
            ListarVacaciones(hfSolicitante.Value,ddlEstado.SelectedValue);
            PanelConductores(txtEmpleado_id.Text);
        }
        if (grvSolicitud.Rows.Count > 0)
            pnlObs.Visible = false;
    }

    public void loadItems(DropDownList ddl, string id_catalogo)
    {
        ItemBL oItem = new ItemBL();
        ddl.DataSource = oItem.ListarItem(id_catalogo);
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
    }

    public void PanelConductores(string id)
    {
        string permisos = ConfigurationManager.AppSettings["VacacionesConductores"];
        string permisosADM = ConfigurationManager.AppSettings["VacacionesAdministrativos"];


        List<String> list = permisos.Split(';').ToList();
        List<String> list2 = permisosADM.Split(';').ToList();
        if (list.Contains(id))
        {
            txtEmpleado.Enabled = true;
            txtemp_adm.Visible = false;


        }
        else if(list2.Contains(id))
        {
            txtEmpleado.Visible = false;
            
            txtemp_adm.Visible = true;
            
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
            txtEmpleado.Text = data[2];
            txtEmpleado_id.Text = data[4];
            hfSolicitante.Value = data[4];
        }
    }

    public void ListarVacaciones(string id, string estado)
    {
        VacacionesSolicitudBL oVacaciones = new VacacionesSolicitudBL();
        VacacionesSolicitudEL objVacaciones = new VacacionesSolicitudEL();
        objVacaciones.id_empleado = Convert.ToInt32(id);
        objVacaciones.estado = estado;
        List<VacacionesSolicitudEL> lst = oVacaciones.ListarVacaciones(objVacaciones);
        grvSolicitud.DataSource = lst;
        grvSolicitud.DataBind();

        VacacionesAprobacionBL oVacaciones3 = new VacacionesAprobacionBL();
        VacacionesSolicitudEL objVacaciones3 = new VacacionesSolicitudEL();
        objVacaciones3.id_empleado = Convert.ToInt32(id);
        List<VacacionesPendientesEL> lst3 = oVacaciones3.ListarPendientes(objVacaciones3);
        //grvPendientes.DataSource = lst3;
        //grvPendientes.DataBind();
        //if (grvPendientes.Rows.Count > 0)
        //{
        //    pnl1.Visible = true;
        //}
        //else
        //{
        //    pnl1.Visible = false;
        //}


        VacacionesReporteBL oReporte = new VacacionesReporteBL();
        VacacionesSolicitudEL objReporte = new VacacionesSolicitudEL();
        objReporte.id_empleado = Convert.ToInt32(id);
        List<VacacionesReporteEL> lst4 = oReporte.ListarReporte(objVacaciones);
        txtVencidos.Text = Convert.ToString(lst4[0].diasVencidos);
        txtPendientes.Text = Convert.ToString(lst4[0].diasPendientes);
        txtDisponibles.Text = Convert.ToString(lst4[0].total);
        txtTruncos.Text = Convert.ToString(lst4[0].diasTruncos);
        txtTomados.Text = Convert.ToString(lst4[0].diasTomados);

        
    }

    public void ListarSeguimiento(string id)
    {
        VacacionesAprobacionBL oVacaciones2 = new VacacionesAprobacionBL();
        VacacionesSolicitudEL objVacaciones2 = new VacacionesSolicitudEL();
        objVacaciones2.id_empleado = Convert.ToInt32(id);
        List<VacacionesAprobacionEL> lst2 = oVacaciones2.ListarAprobacion(objVacaciones2);
        grvAprobacion.DataSource = lst2;
        grvAprobacion.DataBind();
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
        Response.AddHeader("content-disposition", "attacNhment;filename=ReporteVacaciones_"+ DateTime.Now.ToString("ddMMyyyy") + ".xls");
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

   
    

    public void RegistrarVacaciones()
    {
        if (hfSolicitante.Value.Equals("165"))
        {
            VacacionesSolicitudBL oVacaciones = new VacacionesSolicitudBL();
            VacacionesSolicitudEL objVacaciones = new VacacionesSolicitudEL();
            objVacaciones.id_empleado = Convert.ToInt32(txtemp_adm_id.Text);
            objVacaciones.id_solicitante = Convert.ToInt32(hfSolicitante.Value);
            objVacaciones.fch_inicio2 = Convert.ToDateTime(fch_inicio.Text);
            objVacaciones.fch_fin2 = Convert.ToDateTime(fch_fin.Text);
            objVacaciones.total_dias = Convert.ToInt32((objVacaciones.fch_fin2 - objVacaciones.fch_inicio2).Days) + 1;
            objVacaciones.observaciones = txtObservaciones.Text;
            List<TransaccionEL> lst = oVacaciones.RegistrarVacaciones(objVacaciones);
            hfidSolicitud.Value = Convert.ToString(lst[0].id_mensaje);
        }
        else
        {
            VacacionesSolicitudBL oVacaciones = new VacacionesSolicitudBL();
            VacacionesSolicitudEL objVacaciones = new VacacionesSolicitudEL();
            objVacaciones.id_empleado = Convert.ToInt32(txtEmpleado_id.Text);
            objVacaciones.id_solicitante = Convert.ToInt32(hfSolicitante.Value);
            objVacaciones.fch_inicio2 = Convert.ToDateTime(fch_inicio.Text);
            objVacaciones.fch_fin2 = Convert.ToDateTime(fch_fin.Text);
            objVacaciones.total_dias = Convert.ToInt32((objVacaciones.fch_fin2 - objVacaciones.fch_inicio2).Days) + 1;
            objVacaciones.observaciones = txtObservaciones.Text;
            List<TransaccionEL> lst = oVacaciones.RegistrarVacaciones(objVacaciones);
            hfidSolicitud.Value = Convert.ToString(lst[0].id_mensaje);
        }

        
    }

    public void ActualizarVacaciones()
    {
        VacacionesSolicitudBL oVacaciones = new VacacionesSolicitudBL();
        VacacionesSolicitudEL objVacaciones = new VacacionesSolicitudEL();
        objVacaciones.id_solicitud = Convert.ToInt32(txtIdSolicitud.Text);
        objVacaciones.fch_inicio2 = Convert.ToDateTime(fch_inicio.Text);
        objVacaciones.fch_fin2 = Convert.ToDateTime(fch_fin.Text);
        objVacaciones.total_dias = Convert.ToInt32((objVacaciones.fch_fin2 - objVacaciones.fch_inicio2).Days)+1;
        objVacaciones.observaciones = txtObservaciones.Text;
        List<VacacionesSolicitudEL> lst = oVacaciones.ActualizarVacaciones(objVacaciones);
    }

    public void RespuestaAprobacion(int idApro,string estado)
    {
        VacacionesAprobacionBL oVacaciones = new VacacionesAprobacionBL();
        VacacionesAprobacionEL objVacaciones = new VacacionesAprobacionEL();
        objVacaciones.id_aprobacion = idApro;
        objVacaciones.estado = estado;
        List<TransaccionEL> lst = oVacaciones.RespuestaAprobacion(objVacaciones);
    }

    public void EliminarVacaciones(string id)
    {
        VacacionesSolicitudBL oVacaciones = new VacacionesSolicitudBL();
        VacacionesSolicitudEL objVacaciones = new VacacionesSolicitudEL();
        objVacaciones.id_solicitud = Convert.ToInt32(id);
        List<VacacionesSolicitudEL> lst = oVacaciones.EliminarVacaciones(objVacaciones);
    }

    public string ConsultarVacaciones()
    {
        
        VacacionesSolicitudBL oVacacionesBL = new VacacionesSolicitudBL();
        VacacionesSolicitudEL oVacacionesEL = new VacacionesSolicitudEL();
        oVacacionesEL.fch_inicio2 = Convert.ToDateTime(fch_inicio.Text);
        oVacacionesEL.id_empleado = Convert.ToInt32(txtEmpleado_id.Text);

        List<TransaccionEL> lst = oVacacionesBL.BuscarSolicitud(oVacacionesEL);

        return Convert.ToString(lst[0].id_mensaje);
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        fch_inicio.Text = "";
        fch_fin.Text = "";
        txtDias.Text = "";
        txtObservaciones.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalConductor').modal('show');", true);
    }

    public string ValidaciondeSolicitudRegistro()
    {
        string validacion="";

        if (ConsultarVacaciones() == "0")
        {
            if (Convert.ToDateTime(fch_inicio.Text) > Convert.ToDateTime(fch_fin.Text))
            {
                validacion = "1La fecha de inicio debe ser menor a la fecha fin";
            }
            else
            {
                if (hfSolicitante.Value.Equals("165"))
                {
                    validacion = "0La solicitud se registro Correctamente";
                }
                else
                {
                    if (Convert.ToDateTime(fch_inicio.Text) >= Convert.ToDateTime(System.DateTime.Now.ToShortDateString()) && Convert.ToDateTime(fch_fin.Text) >= Convert.ToDateTime(System.DateTime.Now.ToShortDateString()))
                    {
                        validacion = "0La solicitud se registro Correctamente";
                    }
                    else
                    {
                        validacion = "1La fecha de inicio o fin debe ser mayor o igual a la fecha actual";
                    }
                }
                

            }
        }
        else { 
            validacion ="1Ya se ha registrado una solicitud para la fecha seleccionada";
        }

        return validacion;
    }


    protected void btnAsignar_Click(object sender, EventArgs e)
    {
        string validacion = ValidaciondeSolicitudRegistro();
        int codigomensaje = Convert.ToInt32(validacion.Substring(0, 1));
        string mensaje = validacion.Substring(1,validacion.Length-1);
        try
        {
            if (txtIdSolicitud.Text.Equals(""))
            {
                if (codigomensaje == 0)
                {
                    RegistrarVacaciones();
                    //EnviarMailSolicitud();
                }
            }
            else
            {
                ActualizarVacaciones();
                MostrarMensaje(0, "La solicitud se actualizo Correctamente");
            }
            ListarVacaciones(hfSolicitante.Value, ddlEstado.SelectedValue);
            MostrarMensaje(codigomensaje, mensaje);
        }
        catch(Exception ex)
        {

        }
    }


    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            EliminarVacaciones(txtObservaciones.Text);
            ListarVacaciones(hfSolicitante.Value, ddlEstado.SelectedValue);
            MostrarMensaje(0, "La solicitud se ha eliminado de manera correcta");
        }
        catch(Exception ex)
        {

        }
    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        ListarVacaciones(hfSolicitante.Value, ddlEstado.SelectedValue);
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

    protected void grVacaciones_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Observar":
                ListarSeguimiento(e.CommandArgument.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalSeguimiento').modal('show');", true);
                ListarVacaciones(hfSolicitante.Value, ddlEstado.SelectedValue);

                break;
            case "Modificar":
                string[] arg = new string[5];
                arg = e.CommandArgument.ToString().Split(';');
                txtIdSolicitud.Text = arg[0];
                fch_inicio.Text = arg[1];
                fch_fin.Text = arg[2];
                txtDias.Text = arg[3];
                txtObservaciones.Text = arg[4];
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalConductor').modal('show');", true);
                break;
            case "eliminar":
                string[] arg2 = new string[2];
                arg2 = e.CommandArgument.ToString().Split(';');
                if (arg2[1].Equals("PENDIENTE"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert3').modal('show');", true);
                    txtObservaciones.Text = arg2[0];
                }
                else
                {
                    MostrarMensaje(1,"No se puede cancelar esta solicitud");
                }
                break;
        }
    }

    protected void grVacaciones_PreRender(object sender, EventArgs e)
    {
        if (grvSolicitud.Rows.Count > 0)
        {
            grvSolicitud.UseAccessibleHeader = true;
            grvSolicitud.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvSolicitud.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }



    protected void grvPendientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Aprobar":
                RespuestaAprobacion(Convert.ToInt32(e.CommandArgument.ToString()), "320200");
                MostrarMensaje(0,"La solicitud fue Aprobada con exito");
                ListarVacaciones(hfSolicitante.Value, ddlEstado.SelectedValue);
                break;
            case "Rechazar":
                RespuestaAprobacion(Convert.ToInt32(e.CommandArgument.ToString()), "320300");
                MostrarMensaje(0, "La solicitud fue Rechazada con exito");
                ListarVacaciones(hfSolicitante.Value, ddlEstado.SelectedValue);
                break;
        }
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
            else if(lblEstado.Text == "APROBADO")
            {
                lblEstado.Text = "APROBADO";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-teal m-b-5";
                //btnaprobar.Visible = false;
                //btnrechazar.Visible = false;
            }
            else if(lblEstado.Text=="RECHAZADO")
            {
                lblEstado.Text = "RECHAZADO";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-danger m-b-5";
                //btnaprobar.Visible = false;
                //btnrechazar.Visible = false;
            }
            else if (lblEstado.Text == "CANCELADO")
            {
                lblEstado.Text = "CANCELADO";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-brown m-b-5";
                //btnaprobar.Visible = false;
                //btnrechazar.Visible = false;
            }
        }
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        ReporteVacaciones();
    }

    protected void grvSolicitud_PreRender(object sender, EventArgs e)
    {
        Prerender(grvSolicitud);
    }

    protected void grvPendientes_PreRender(object sender, EventArgs e)
    {
        //Prerender(grvPendientes);
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

            else if (lblEstado.Text == "INVALIDO")
            {
                lblEstado.Text = "INVALIDO";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-brown m-b-5";

            }
        }
    }

   
    protected void grvAprobacion_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarVacaciones(hfSolicitante.Value, ddlEstado.SelectedValue);
    }
}