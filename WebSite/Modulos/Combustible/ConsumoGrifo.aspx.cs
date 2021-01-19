using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Combustible_ConsumoGrifo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Perfil();
            Listargrifo();
            ListarAbastecedor();
            ListarCliente();
            loadItems(ddlTipoVehiculoAdd,"22");
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

    public void loadItems(DropDownList ddl, string id_catalogo)
    {
        ItemBL oItem = new ItemBL();
        ddl.DataSource = oItem.ListarItemOpe(id_catalogo);
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- TODOS --", ""));
        ddl.SelectedIndex = 0;

        if (ddl == ddlTipoVehiculoAdd)
        {
            ddl.SelectedIndex = 1;
        }
        else
        {
            ddl.SelectedIndex = 0;
        }
    }

    public void RegistrarGrifo()
    {
        GrifoBL oGrifoBL = new GrifoBL();
        GrifoEL oGrifoEL = new GrifoEL();
        oGrifoEL.Estacion_nom = txtNomEstacion.Text;
        oGrifoEL.Fecha_Inicio= Convert.ToDateTime(txtFechaInicio.Text);
        oGrifoEL.Fecha_Fin = Convert.ToDateTime(txtFechaFin.Text);
        oGrifoEL.aud_usuario_creacion = hfUsuario.Value;

        List<TransaccionEL> lst = oGrifoBL.RegistrarGrifo(oGrifoEL);
    }

    public void RegistrarConsumo()
    {
        GrifoDetBL oGrifoBL = new GrifoDetBL();
        GrifoDetEL oGrifoEL = new GrifoDetEL();

        oGrifoEL.id_Estacion = Convert.ToInt32(hdCisterna.Value);
        oGrifoEL.cod_cliente = Convert.ToInt32(ddlClienteAdd.SelectedValue.ToString());
        oGrifoEL.fecha_registro = Convert.ToDateTime(txtFecha.Text);
        oGrifoEL.nro_despacho = txtTicket.Text;
        oGrifoEL.id_abastecedor = Convert.ToInt32(ddlAbastecedor.SelectedValue.ToString());
        oGrifoEL.nom_conductor = txtConductor.Text;
        oGrifoEL.cod_unidad = ddlTipoVehiculoAdd.SelectedValue.ToString();
        oGrifoEL.unidad = txtVehiculo.Text;
        oGrifoEL.nro_placa = txtVehiculo_id.Text;
        oGrifoEL.km_unidad = Convert.ToDecimal(txtkm.Text);
        oGrifoEL.horometro = Convert.ToDecimal(txtHorometro.Text);
        oGrifoEL.cantidad_gl = Convert.ToDecimal(txtGl.Text);
        oGrifoEL.precio_galon_igv = Convert.ToDecimal(txtPrecioGl.Text);
        oGrifoEL.aud_usuario_creacion = hfUsuario.Value;
        oGrifoEL.NDS = txtNDS.Text;
        oGrifoEL.nom_estacion = txtNomEstacion2.Text;

        List<TransaccionEL> lst = oGrifoBL.RegistrarGrifoDet(oGrifoEL);
    }

    protected void ActualizarAbastecimiento(int id_abastecimiento)
    {
        AbastecimientoBL oAbasBL = new AbastecimientoBL();
        AbastecimientoEL oAbasEL = new AbastecimientoEL();
        oAbasEL.id_abastecimiento = id_abastecimiento;
        List<TransaccionEL> lst = oAbasBL.ActualizarAbastecimiento(oAbasEL);
        if (lst[0].id_mensaje == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se elimino el registro seleccionado.','Alerta:','success');", true);
        }
    }

    protected void ActualizarGrifo(int id_abastecimiento)
    {
        try
        {
            GrifoDetBL oAbasBL = new GrifoDetBL();
            oAbasBL.EliminarGrifoDet(id_abastecimiento);
            MostrarMensaje(0, "Se elimino corretamente el registro");
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo eliminar");
        }
        
    }

    protected int validarSeleccion()
    {
        int sel = 0;
        GridViewRow item;

        for (int i = 0; i <= gvDetalle.Rows.Count - 1; i++)
        {
            item = gvDetalle.Rows[i];
            CheckBox chk = (CheckBox)item.FindControl("chk");
            if (chk.Checked == true)
            {
                sel++;
            }
        }
        return sel;
    }

    public void ListarCliente()
    {
        ClienteBL oCliente = new ClienteBL();
        List<ClienteEL> lst = oCliente.ListarCliente();
        ddlCliente.DataSource = lst;
        ddlCliente.DataValueField = "id_empresa";
        ddlCliente.DataTextField = "nom_empresa";
        ddlCliente.DataBind();
        ddlCliente.Items.Insert(0, new ListItem("-- TODOS --", "0"));
        ddlCliente.SelectedIndex = 0;

        ddlClienteAdd.DataSource = lst;
        ddlClienteAdd.DataValueField = "id_empresa";
        ddlClienteAdd.DataTextField = "nom_empresa";
        ddlClienteAdd.DataBind();
        ddlClienteAdd.Items.Insert(0, new ListItem("-- TODOS --", "0"));
        ddlClienteAdd.SelectedIndex = 0;
    }

    public void ListarAbastecedor()
    {
        AbastecimientoBL oCliente = new AbastecimientoBL();
        List<AbastecimientoEL> lst = oCliente.ListarAbastecedor();
        ddlAbastecedor.DataSource = lst;
        ddlAbastecedor.DataValueField = "valor1";
        ddlAbastecedor.DataTextField = "descripcion";
        ddlAbastecedor.DataBind();
        ddlAbastecedor.Items.Insert(0, new ListItem("-- TODOS --", ""));
        ddlAbastecedor.SelectedIndex = 0;
    }

    public void Listargrifo()
    {
        GrifoBL ogrifo = new GrifoBL();
        List<GrifoEL> lst = ogrifo.ListarGrifo();
        gvConsumo.DataSource = lst;
        gvConsumo.DataBind();

    }

    public void ConsultarCisterna(int cod)
    {
        //CisternaEL objCisterna = new CisternaEL();
        //CisternaBL oCisterna = new CisternaBL();
        //objCisterna.cod_cisterna = Convert.ToString(cod);
        //List<CisternaEL> lst = oCisterna.ConsultarCisterna(objCisterna);
        //string tipo = lst[0].cod_cisterna;
        //hdTipoCisterna.Value = tipo;
        //txtGalones.Text = Convert.ToString(lst[0].cantidad_gl);
        //txtConsumo.Text = Convert.ToString(lst[0].consumo_gl);

        //decimal saldo = Convert.ToDecimal(txtGalones.Text) - Convert.ToDecimal(txtConsumo.Text);
        //hfSaldo.Value = saldo + "";

        //string literal = "";

        //if (saldo <= 100 && (tipo.Equals("150100") || tipo.Equals("150200")))
        //{
        //    literal = "<div class=\"col-lg-12 m-t-10\"> " +
        //                           "<div class=\"alert alert-icon alert-danger alert-dismissible fade in\" role=\"alert\">" +
        //                                       "<i class=\"mdi mdi-information\"></i>" +
        //                                       "<strong>Saldo disponible en la Cisterna</strong> <asp:Label ID=\"lblcis\" runat=\"server\" Font-Bold=\"true\" Font-Size=\"15\" >" + Convert.ToString(saldo) + "</asp:Label>" +
        //                                   "</div>" +
        //               "</div>";
        //}
        //else
        //{
        //    literal = "<div class=\"col-lg-12 m-t-10\"> " +
        //                             "<div class=\"alert alert-icon alert-info alert-dismissible fade in\" role=\"alert\">" +
        //                                         "<i class=\"mdi mdi-information\"></i>" +
        //                                         "<strong>Saldo disponible en la Cisterna</strong> <asp:Label ID=\"lblcis\" runat=\"server\" Font-Bold=\"true\" Font-Size=\"15\" >" + Convert.ToString(saldo) + "</asp:Label>" +
        //                                     "</div>" +
        //                 "</div>";
        //}

        //ltCisterna.Text = literal;
    }

    public void ListarDetalle(int id_cisterna)
    {
        GrifoDetBL oGrifoBL = new GrifoDetBL();
        List<GrifoDetEL> lst = oGrifoBL.ListarGrifoDet(id_cisterna);
        gvDetalle.DataSource = lst;
        gvDetalle.DataBind();
        
    }

    public void ListarDetalle(int id_cisterna,int cliente)
    {
        //AbastecimientoBL oDetalle = new AbastecimientoBL();
        //List<AbastecimientoEL> lst = oDetalle.ConsultarDetalle(id_cisterna, id_cliente, id_abastecimiento);
        //gvDetalle.DataSource = lst;
        //gvDetalle.DataBind();

        GrifoDetBL oGrifoBL = new GrifoDetBL();

        List<GrifoDetEL> lst = oGrifoBL.ListarGrifoDet(id_cisterna,cliente);
        gvDetalle.DataSource = lst;
        gvDetalle.DataBind();

    }

    protected void gvConsumo_PreRender(object sender, EventArgs e)
    {
        if (gvConsumo.Rows.Count > 0)
        {
            gvConsumo.UseAccessibleHeader = true;
            gvConsumo.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvConsumo.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void gvConsumo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            LinkButton LinkButton3 = (LinkButton)e.Row.FindControl("LinkButton3");
            LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
            Label lblEstado = (Label)e.Row.FindControl("lblEstado");

            if (lblEstado.Text == "0")
            {
                lblEstado.Text = "ABIERTO";
                lblEstado.CssClass = "btn btn-icon waves-effect waves-light btn-teal w-md m-b-5";
            }
            else if (lblEstado.Text == "1")
            {
                lblEstado.Text = "CERRADO";
                lblEstado.CssClass = "btn btn-icon waves-effect waves-light btn-danger w-md m-b-5";
                //LinkButton3.Enabled = false;
                LinkButton1.Enabled = false;
            }
        }
    }

    protected void gvConsumo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string codigo = e.CommandArgument.ToString();
        switch (e.CommandName.ToString())
        {
            case "detalle":
                string[] arg = new string[2];
                arg = codigo.ToString().Split(';');
                ListarDetalle(Convert.ToInt32(arg[0]));
                hdCisterna.Value = arg[0];
                MultiView1.ActiveViewIndex = 1;
                ConsultarCisterna(Convert.ToInt32(arg[0]));
                if (arg[1].Equals("1"))
                {
                    lnkAgregar.Enabled = false;
                }

                break;
            case "cerrar":
                hdCisterna.Value = codigo;
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert3').modal('show');", true);
                break;
        }
    }

    protected void gvDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void lnkBuscar_Click(object sender, EventArgs e)
    {
        int _id = ddlCliente.SelectedIndex;
        if (_id == 0)
        {
            //ListarDetalle(Convert.ToInt32(hdCisterna.Value), 0, 0);
            //ConsultarCisterna(Convert.ToInt32(hdCisterna.Value));
            ListarDetalle(Convert.ToInt32(hfCodCisterna.Value),Convert.ToInt32(ddlCliente.SelectedValue));

        }
        else
        {
            //ListarDetalle(Convert.ToInt32(hdCisterna.Value), Convert.ToInt32(ddlCliente.SelectedValue), 0);
            //ConsultarCisterna(Convert.ToInt32(hdCisterna.Value));
            ListarDetalle(Convert.ToInt32(hfCodCisterna.Value), Convert.ToInt32(ddlCliente.SelectedValue));
        }
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        GrifoBL oGrifoBL = new GrifoBL();
        oGrifoBL.CerrarGrifo(Convert.ToInt32(hdCisterna.Value));
        MostrarMensaje(0, "Se cerro la estacion correctamente.");
        Listargrifo();
    }


    public void Exportar()
    {

        GrifoDetBL ogrifo = new GrifoDetBL();
        var GridView1 = new GridView();
        DataTable dt = ogrifo.ReporteGrifoDet(Convert.ToInt32(hdCisterna.Value));

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
            Response.AddHeader("content-disposition", "attacNhment;filename=ReporteGrifo.xls");
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
        else
        {
            MostrarMensaje(1, "No se encontro documentos con fecha de vencimiento en el rango seleccionado");
        }
    }
    protected void gvDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int codigo = Convert.ToInt32(e.CommandArgument);

        switch (e.CommandName.ToString())
        {
            case "print":
                Response.Redirect("Ticket.aspx?id_cisterna=" + hdCisterna.Value + "&id_abas=" + codigo);
                break;
            case "eliminar":
                ActualizarAbastecimiento(codigo);
                //ListarDetalle(int.Parse(hdCisterna.Value), 0, 0);
                ConsultarCisterna(Convert.ToInt32(hdCisterna.Value));
                Listargrifo();
                ActualizarGrifo(codigo);
                ListarDetalle(int.Parse(hdCisterna.Value));
                break;
        }
    }



    protected void gvDetalle_PreRender(object sender, EventArgs e)
    {
        if (gvDetalle.Rows.Count > 0)
        {
            gvDetalle.UseAccessibleHeader = true;
            gvDetalle.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvDetalle.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void lnkCisterna_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Debe seleccionar al menos un detalle','Alerta!','error');", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
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

    protected void lnkRegistrar_Click(object sender, EventArgs e)
    {
        try
        {
            RegistrarGrifo();
            Listargrifo();
            MostrarMensaje(0,"Se registro Correctamente.");
            //ListarCisterna();
            //LimpiarFormCisterna();
        }
        catch
        {
            MostrarMensaje(1,"No se pudo realizar el registro.");
        }

    }

    protected void lnkAgregar_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlertAdd').modal('show');", true);
    }

    protected void lnkAddConsumo_Click(object sender, EventArgs e)
    {
        try
        {

        
        RegistrarConsumo();
        LimpiarFormAbastecimiento();
        ListarDetalle(Convert.ToInt32(hdCisterna.Value));
        lnkBuscar_Click(sender, e);
        MostrarMensaje(0,"Se registro Correctamente.");
        }
        catch (Exception EX)
        {
            MostrarMensaje(1, "No se pudo realizar el registro.");
        }
    }

    protected void lnkRegresar_Click(object sender, EventArgs e)
    {
        //ListarCisterna();
        MultiView1.ActiveViewIndex = 0;

    }

    protected void ddlCisterna_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void btnInsertarR_Click(object sender, EventArgs e)
    {
        CisternaBL objCisterna = new CisternaBL();
        List<TransaccionEL> lst = new List<TransaccionEL>();

        lst = objCisterna.RegistrarCisternaRemanente(int.Parse(ddlCisternaR.SelectedValue), int.Parse(hdfCisterna.Value));
        if (lst[0].id_mensaje == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se traslado los registros con existo','Alerta:','success');", true);
        }
        //ListarCisterna();
    }

    public void LimpiarFormCisterna()
    {
        
    }

    public void LimpiarFormAbastecimiento()
    {
        hdfCisterna.Value = "0";
        ddlClienteAdd.SelectedIndex = 0;
        ddlTipoVehiculoAdd.SelectedIndex = 1;
        txtVehiculo.Text = "";
        txtVehiculo_id.Text = "";
        txtkm.Text = "";
        txtHorometro.Text = "";
        txtConductor.Text = "";
        txtGl.Text = "";
        //txtNroDespacho.Text = "";
    }

    public void LimpiarFormRemanente()
    {
        ddlCisternaR.SelectedIndex = 0;
    }

    protected void ddlClienteAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClienteAdd.SelectedValue.Equals("1"))
        {
            ddlTipoVehiculoAdd.Enabled = true;
            txtConductor.CssClass = "form-control";
            txtVehiculo.CssClass = "form-control";
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalAlertAdd').modal('show');", true);
        }
        else if (ddlClienteAdd.SelectedValue.Equals("2"))
        {
            ddlTipoVehiculoAdd.Enabled = false;
            txtConductor.CssClass = "form-control autocomplete";
            txtVehiculo.CssClass = "form-control autocomplete";
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalAlertAdd').modal('show');", true);
        }
        else
        {
            ddlTipoVehiculoAdd.Enabled = false;
            txtConductor.CssClass = "form-control";
            txtVehiculo.CssClass = "form-control";
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalAlertAdd').modal('show');", true);
        }
    }

    protected void lnkexportar_Click(object sender, EventArgs e)
    {
        Exportar();
    }
}

