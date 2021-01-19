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

public partial class Modulos_Empleados_indumentaria : System.Web.UI.Page
{

    EquipoProteccionBL oEquipo = new EquipoProteccionBL();
    EquipoProteccionEL EquipoEL = new EquipoProteccionEL();
    EmpleadoBL oEmpleado = new EmpleadoBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Perfil();
            txtFchEntrega.Text = DateTime.Now.ToString("dd/MM/yyyy");
            string cod = "";
            cod = Request.QueryString["cod"];
            hfCodId.Value = cod;
            if (!hfCodId.Value.Equals(""))
            {
                txtEmpleado_id.Text = hfCodId.Value;
                List<EmpleadoEL> lst = oEmpleado.Consultar_PorCodigo2(Convert.ToInt32(hfCodId.Value));
                txtEmpleado.Text = lst[0].nombre_emp;
                PanelEPP.Visible = true;
                hfCodigoDoc.Value = "01";
                setTabs();
                li1.Attributes.Add("class", "current");
                li1.Attributes.Add("class", "active");
                ListarProteccion(hfCodigoDoc.Value);
            }
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

    public void ListarProteccion(string tabla)
    {
        List<EquipoProteccionEL> lst = oEquipo.ListarProteccion(Convert.ToInt32(txtEmpleado_id.Text), tabla);
        grvEPP.DataSource = lst;
        grvEPP.DataBind();
    }

    public void ListarHistorico(string cod_equipo)
    {
        List<EquipoProteccionEL> lst = oEquipo.ListarProteccionHistorico(Convert.ToInt32(txtEmpleado_id.Text), cod_equipo);
        gvHistorico.DataSource = lst;
        gvHistorico.DataBind();
    }
    public void ListarHistoricoDevolucion(string codTipo)
    {
        //List<EquipoProteccionEL> lst = oEquipo.ListarEPPDevolucionHistorico(codTipo,Convert.ToInt32(txtEmpleado_id.Text));
        //gvHistoricoDevolucion.DataSource = lst;
        //gvHistoricoDevolucion.DataBind();
    }

    public void setTabs()
    {
        li1.Attributes.Add("class", "");
        li2.Attributes.Add("class", "");
    }
    protected void btnBuscarEmpleado_Click(object sender, EventArgs e)
    {
        if (!txtEmpleado_id.Text.Equals(""))
        {
            hfCodigoDoc.Value = "01";
            setTabs();
            li1.Attributes.Add("class", "current");
            li1.Attributes.Add("class", "active");
            PanelEPP.Visible = true;
            ListarProteccion(hfCodigoDoc.Value);
        }
        else
        {
            MostrarMensaje(1, "Se debe seleccionar un empleado");
        }
    }

    protected void grvEntrega_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "registrar":

                hfIDEquipo.Value = "";
                hfEquipo.Value = "";

                txtCanEntrega.Text = "";
                txtObsEntrega.Text = "";
                rbDevolucion.Checked = false;
                rbEntrega.Checked = true;


                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                hfIDEquipo.Value = arg[0];
                lblEquipo.Text = arg[1];

                if(hfCodigoDoc.Value == "01" && (hfIDEquipo.Value != "330201" && hfIDEquipo.Value != "330301"))
                {
                    txtTalla.Enabled = false;
                }
                else
                {
                    txtTalla.Enabled = true;
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalRegistroEPP').modal('show');", true);

                break;
            case "historial":
                ListarHistorico(e.CommandArgument.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalHistorico').modal('show');", true);

                break;
        }
    }

    protected void grvEntrega_PreRender(object sender, EventArgs e)
    {
        if (grvEPP.Rows.Count > 0)
        {
            grvEPP.UseAccessibleHeader = true;
            grvEPP.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvEPP.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }


    public void RegistrarEPP()
    {
        EquipoProteccionBL EquipoBL = new EquipoProteccionBL();
        EquipoProteccionEL EquipoEL = new EquipoProteccionEL();
        EquipoEL.id_emp = Convert.ToInt32(txtEmpleado_id.Text);
        EquipoEL.cod_equipo = hfIDEquipo.Value;
        EquipoEL.cantidad = Convert.ToInt32(txtCanEntrega.Text);
        EquipoEL.fecha_entrega = txtFchEntrega.Text;
        EquipoEL.talla = txtTalla.Text;
        EquipoEL.observacion = txtObsEntrega.Text;
        if (rbEntrega.Checked)
        {
            EquipoEL.Tipo = "E";
        }
        else if (rbDevolucion.Checked)
        {
            EquipoEL.Tipo = "D";
        }
        EquipoEL.aud_usuario_creacion = hfUsuario.Value;
        List<TransaccionEL> lst = EquipoBL.RegistrarEPP(EquipoEL);
        if (lst[0].id_mensaje == 1)
        {
            MostrarMensaje(1, lst[0].mensaje);
        }
        else
        {
            MostrarMensaje(0, "Se registro correctamente");
        }
    }

    public void ListarHistorico()
    {

    }

    protected void lnkRegistrarEPP_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCanEntrega.Text.Equals(""))
            {
                MostrarMensaje(1, "Se debe indicar una cantidad para poder registrarlo.");
            }
            else
            {
                RegistrarEPP();
                ListarProteccion(hfCodigoDoc.Value);
            }

        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se logró realizar la acción.");
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {

            //ListarHistoricoEntrega();
            MostrarMensaje(0, "Se eliminó la entrega correctamente");

        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se logró eliminar el registro.");
        }
    }

    protected void gvHistoricoEntrega_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "eliminar":
                hfEntrega.Value = "";
                hfEquiEntrega.Value = "";

                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                hfEntrega.Value = arg[0];
                hfEquiEntrega.Value = arg[1];
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert3').modal('show');", true);
                break;
        }
    }

    protected void gvHistoricoDevolucion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "eliminar":
                hfDevolucion.Value = "";
                hfEquiDevolucion.Value = "";

                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                hfDevolucion.Value = arg[0];
                hfEquiDevolucion.Value = arg[1];
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert4').modal('show');", true);
                break;
        }
    }

    protected void btnEliminarDevolucion_Click(object sender, EventArgs e)
    {
        try
        {

            //ListarHistoricoDevolucion();
            MostrarMensaje(0, "Se eliminó la devolución correctamente");

        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se logró eliminar el registro.");
        }
    }



    protected void gvHistorico_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gvHistorico_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbltipo = (Label)e.Row.FindControl("lbltipo");
            Label lblEstado = (Label)e.Row.FindControl("lblEstado");

            if (lbltipo.Text == "E")
            {
                lbltipo.Text = "ENTREGA";
                lbltipo.CssClass = "label label-icon waves-effect waves-light btn-success m-b-5";
            }
            else if (lbltipo.Text == "Entrega")
            {
                lbltipo.Text = "ENTREGA";
                lbltipo.CssClass = "label label-icon waves-effect waves-light btn-success m-b-5";
            }
            else if (lbltipo.Text == "Devolucion")
            {
                lbltipo.Text = "DEVOLUCION";
                lbltipo.CssClass = "label label-icon waves-effect waves-light btn-orange m-b-5";
            }
            else if (lbltipo.Text == "D")
            {
                lbltipo.Text = "DEVOLUCION";
                lbltipo.CssClass = "label label-icon waves-effect waves-light btn-orange m-b-5";
            }

            if (lblEstado.Text == "1")
            {
                lblEstado.Text = "Cambio";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-orange center-block m-b-5";
            }
            else if (lblEstado.Text == "0")
            {
                lblEstado.Text = "OK";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-success m-b-5";
            }
            else if (lblEstado.Text == "2")
            {
                lblEstado.Text = "Vencido";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-danger m-b-5";
            }
        }
    }

    protected void lnkEPP_Click(object sender, EventArgs e)
    {
        hfCodigoDoc.Value = "01";
        setTabs();
        li1.Attributes.Add("class", "current");
        li1.Attributes.Add("class", "active");
        ListarProteccion(hfCodigoDoc.Value);
    }

    protected void lnkIndumentaria_Click(object sender, EventArgs e)
    {
        hfCodigoDoc.Value = "02";
        setTabs();
        li2.Attributes.Add("class", "current");
        li2.Attributes.Add("class", "active");
        ListarProteccion(hfCodigoDoc.Value);
    }

    protected void btnExportarEPP_Click(object sender, EventArgs e)
    {

        EquipoProteccionBL oEPP = new EquipoProteccionBL();
        var GridView1 = new GridView();

        if (txtEmpleado_id.Text.Equals(""))
        {
            txtEmpleado_id.Text = "0";
        }

        DataTable dt = oEPP.ExportarEPP(Convert.ToInt32(txtEmpleado_id.Text));

        if (dt.Rows.Count > 0)
        {
            for (int i = dt.Columns.Count - 1; i >= 0; i--)
            {
                Boolean vacio = true;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (!dt.Rows[j][i].Equals(""))
                    {
                        vacio = false;
                    }
                }

                if (vacio)
                {
                    dt.Columns.Remove(dt.Columns[i]);
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();



            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attacNhment;filename=ReporteEPP.xls");
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
    }
}