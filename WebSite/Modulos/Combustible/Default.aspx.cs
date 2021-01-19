using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Combustible_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Perfil();
            ListarAbastecedor();
            ListarCisterna();
            ListarCliente();
            loadItems(ddlCisterna, "15");
            CargarItemsCisternaFiltro();
            CargarItemsEstadoFiltro();
            //loadItems(ddlTipoVehiculo, "22");
            loadItems(ddlTipoVehiculoAdd, "22");
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

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

    public void CargarItemsCisternaFiltro()
    {
        CisternaBL oCisterna = new CisternaBL();

        List<CisternaEL> lst = oCisterna.ListarCisterna();
        ddlCisternasFiltro.DataSource = lst;
        ddlCisternasFiltro.DataTextField = "cod_cisterna";
        ddlCisternasFiltro.DataValueField = "id_cisterna";
        ddlCisternasFiltro.DataBind();
        ddlCisternasFiltro.Items.Insert(0, new ListItem("-- TODOS --", ""));
        ddlCisternasFiltro.SelectedIndex = 0;
    }

    public void CargarItemsEstadoFiltro()
    {
        CisternaBL oCisterna = new CisternaBL();

        ddlEstadoFiltro.Items.Clear();
        ddlEstadoFiltro.Items.Add("--TODOS--");
        ddlEstadoFiltro.Items[0].Value = "";
        ddlEstadoFiltro.Items.Add("Vigente");
        ddlEstadoFiltro.Items[1].Value = "1";
        ddlEstadoFiltro.Items.Add("Consumido");
        ddlEstadoFiltro.Items[2].Value = "0";
        ddlEstadoFiltro.SelectedIndex = 0;
        
    }

    public void RegistrarCisterna()
    {
        CisternaBL oCisternaBL = new CisternaBL();
        CisternaEL oCisternaEL = new CisternaEL();
        oCisternaEL.cod_cisterna = ddlCisterna.SelectedValue;
        oCisternaEL.cantidad_gl = decimal.Parse(txtCapacidad.Text);
        oCisternaEL.cantidad_rm_gl = decimal.Parse(txtRem.Text);
        oCisternaEL.precio_compra = decimal.Parse(txtPrecioCompra.Text);
        oCisternaEL.subtotal = decimal.Parse(txtTotalCarga.Text);
        oCisternaEL.total = decimal.Parse(txtTotalCargaIGV.Text);
        oCisternaEL.fecha_registro = txtFchRegistro.Text;
        oCisternaEL.fecha_vencimiento = txtFchVencimiento.Text;
        oCisternaEL.nro_factura = txtFactura.Text;
        oCisternaEL.numero_scop = txtScop.Text;
        List<TransaccionEL> lst = oCisternaBL.RegistrarCisterna(oCisternaEL);
        if (lst[0].id_mensaje == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se registro la cisterna correctamente.','Alerta:','success');", true);
        }
    }

    public void RegistrarConsumo()
    {
        AbastecimientoBL oAbasBL = new AbastecimientoBL();
        AbastecimientoEL oAbasEL = new AbastecimientoEL();

        oAbasEL.id_cisterna = int.Parse(hdCisterna.Value);
        oAbasEL.cod_empresa = ddlClienteAdd.SelectedValue;
        oAbasEL.cod_unidad = ddlTipoVehiculoAdd.SelectedValue;
        oAbasEL.unidad = txtVehiculo.Text;
        oAbasEL.nro_placa = txtVehiculo_id.Text;
        oAbasEL.cnt_inicial = Decimal.Parse(txtcntInicial.Text);
        oAbasEL.cnt_final = Decimal.Parse(txtcntFinal.Text);
        oAbasEL.km_unidad = Decimal.Parse(txtkm.Text);
        oAbasEL.horometro = Decimal.Parse(txtHorometro.Text);
        oAbasEL.nom_conductor = txtConductor.Text;
        oAbasEL.cantidad_gl = Decimal.Parse(txtGl.Text);
        oAbasEL.nro_despacho = txtNroDespacho.Text;
        oAbasEL.fecha_liquidacion = Convert.ToDateTime(txtFecha.Text);
        oAbasEL.abastecedor = Convert.ToInt32(ddlAbastecedor.SelectedValue.ToString());
        oAbasEL.nro_despacho = txtTicket.Text;
        oAbasEL.usuario = hfUsuario.Value;

        List<TransaccionEL> lst = oAbasBL.RegistrarConsumo(oAbasEL);
        if (lst[0].id_mensaje == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se registro el consumo correctamente.','Alerta:','success');", true);
        }
        else if (lst[0].id_mensaje == 2)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('"+lst[0].mensaje+"','Alerta:','error');", true);
        }
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
        ddlCliente.Items.Insert(0, new ListItem("-- TODOS --", ""));
        ddlCliente.SelectedIndex = 0;

        ddlClienteAdd.DataSource = lst;
        ddlClienteAdd.DataValueField = "id_empresa";
        ddlClienteAdd.DataTextField = "nom_empresa";
        ddlClienteAdd.DataBind();
        ddlClienteAdd.Items.Insert(0, new ListItem("-- TODOS --", ""));
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

    public void ListarCisterna()
    {
        CisternaBL oCisterna = new CisternaBL();
        List<CisternaEL> lst = oCisterna.ListarCisterna();
        gvConsumo.DataSource = lst;
        gvConsumo.DataBind();

        List<CisternaEL> lista = lst.Where(x => x.estado.Equals("1") && !x.cod_cisterna.Contains("REMANENTE")).ToList();

        ddlCisternaR.DataSource = lista;
        ddlCisternaR.DataValueField = "id_cisterna";
        ddlCisternaR.DataTextField = "cod_cisterna";
        ddlCisternaR.DataBind();
        ddlCisternaR.Items.Insert(0, new ListItem("-- TODOS --", ""));
        ddlCisternaR.SelectedIndex = 0;    
    }

    public void ConsultarCisterna(int cod)
    {
        CisternaEL objCisterna = new CisternaEL();
        CisternaBL oCisterna = new CisternaBL();
        objCisterna.cod_cisterna = Convert.ToString(cod);
        List<CisternaEL> lst = oCisterna.ConsultarCisterna(objCisterna);
        string tipo = lst[0].cod_cisterna;
            hdTipoCisterna.Value = tipo;
        txtGalones.Text = Convert.ToString(lst[0].cantidad_gl);
        txtConsumo.Text = Convert.ToString(lst[0].consumo_gl);

        decimal saldo = Convert.ToDecimal(txtGalones.Text) - Convert.ToDecimal(txtConsumo.Text);
        hfSaldo.Value = saldo+"";

        string literal = "";

        if(saldo<= 100 && (tipo.Equals("150100") || tipo.Equals("150200")))
        {
            literal = "<div class=\"col-lg-12 m-t-10\"> " +
                                   "<div class=\"alert alert-icon alert-danger alert-dismissible fade in\" role=\"alert\">" +
                                               "<i class=\"mdi mdi-information\"></i>" +
                                               "<strong>Saldo disponible en la Cisterna</strong> <asp:Label ID=\"lblcis\" runat=\"server\" Font-Bold=\"true\" Font-Size=\"15\" >" + Convert.ToString(saldo) + "</asp:Label>" +
                                           "</div>" +
                       "</div>";
        }
        //else
        //{
        //    literal = "<div class=\"col-lg-12 m-t-10\"> " +
        //                             "<div class=\"alert alert-icon alert-info alert-dismissible fade in\" role=\"alert\">" +
        //                                         "<i class=\"mdi mdi-information\"></i>" +
        //                                         "<strong>Saldo disponible en la Cisterna</strong> <asp:Label ID=\"lblcis\" runat=\"server\" Font-Bold=\"true\" Font-Size=\"15\" >" + Convert.ToString(saldo) + "</asp:Label>" +
        //                                     "</div>" +
        //                 "</div>";
        //}

        ltCisterna.Text = literal;
    }

    public void ListarDetalle(int id_cisterna,int id_cliente,int id_abastecimiento)
    {
        AbastecimientoBL oDetalle = new AbastecimientoBL();
        List<AbastecimientoEL> lst = oDetalle.ConsultarDetalle(id_cisterna,id_cliente,id_abastecimiento);
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
            LinkButton lnkRemanente = (LinkButton)e.Row.FindControl("lnkRemanente");
            Label lblcisterna = (Label)e.Row.FindControl("lblcisterna");

            if (!lblcisterna.Text.Contains("REMANENTE"))
            {
                lnkRemanente.CssClass = "btn btn-icon waves-effect waves-light btn-danger disabled m-b-5";
            }

            Label lblEstado = (Label)e.Row.FindControl("lblEstado");                        

            if (lblEstado.Text == "1")
            {
                lblEstado.Text = "VIGENTE";
                lblEstado.CssClass = "btn btn-icon waves-effect waves-light btn-teal w-md m-b-5";
            }
            else
            {
                lblEstado.Text = "CONSUMIDO";
                lblEstado.CssClass = "btn btn-icon waves-effect waves-light btn-danger w-md m-b-5";
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
                txtNroScop.Text = arg[1];
                ListarDetalle(Convert.ToInt32(arg[0]),0,0);
                hdCisterna.Value = arg[0];
                MultiView1.ActiveViewIndex = 1;
                ConsultarCisterna(Convert.ToInt32(arg[0]));
                break;
            case "remanente":
                LimpiarFormRemanente();
                hdfCisterna.Value = e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalRemanente').modal('show');", true);
                break;           
        }
        ListarCisterna();
    }

    protected void gvDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void lnkBuscar_Click(object sender, EventArgs e)
    {
        int _id = ddlCliente.SelectedIndex;       
        if (_id == 0 )
        {
            ListarDetalle(Convert.ToInt32(hdCisterna.Value), 0,0);
            ConsultarCisterna(Convert.ToInt32(hdCisterna.Value));

        }else
        {
            ListarDetalle(Convert.ToInt32(hdCisterna.Value), Convert.ToInt32(ddlCliente.SelectedValue),0);
            ConsultarCisterna(Convert.ToInt32(hdCisterna.Value));
        }
    }

    public void Exportar()
    {
        //Invocando al metodo de busqueda
        AbastecimientoBL oDetalle = new AbastecimientoBL();
        List<AbastecimientoEL> lst;

        int _id = ddlCliente.SelectedIndex;
        if (_id == 0)
        {            
            lst = oDetalle.ConsultarDetalle(Convert.ToInt32(hdCisterna.Value),0,0);
        }
        else
        {            
            lst = oDetalle.ConsultarDetalle(Convert.ToInt32(hdCisterna.Value), Convert.ToInt32(ddlCliente.SelectedValue),0);
        }

        //Iniciar exportacion
        var GridView1 = new GridView();
        GridView1.DataSource = lst;
        GridView1.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Reporte_Abastecimiento_" + DateTime.Now.ToString("ddMMyyyy") + ".xls");
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
                cell.BackColor = System.Drawing.Color.FromArgb(15,36,62);
                cell.ForeColor = System.Drawing.Color.White;
                switch (cell.Text)
                {
                    case "nom_empresa":
                        cell.Text = "Cliente";
                        break;
                    case "fecha_registro":
                        cell.Text = "Fecha Registro";
                        break;
                    case "nro_placa":
                        cell.Text = "Nro. Placa";
                        break;
                    case "km_unidad":
                        cell.Text = "Km.";
                        break;
                    case "nom_conductor":
                        cell.Text = "Conductor";
                        break;
                    case "cantidad_gl":
                        cell.Text = "Cantidad(Gl.)";
                        break;
                    case "precio_galon_igv":
                        cell.Text = "Precio (S/.)";
                        break;
                    case "total_venta":
                        cell.Text = "Total Venta(S/.)";
                        break;
                    case "nro_factura":
                        cell.Text = "Nro. Factura";
                        break;
                    case "fecha_facturacion":
                        cell.Text = "Fecha Facturacion";
                        break;
                }
                
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

                    if (cell.Text.Equals("01/01/1900"))
                    {
                        cell.Text = "N/A";
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

    protected void lnkExportar_Click(object sender, EventArgs e)
    {
        Exportar();
    }

    protected void gvDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int codigo = Convert.ToInt32(e.CommandArgument);

        switch (e.CommandName.ToString())
        {
            case "print":
                Response.Redirect("Ticket.aspx?id_cisterna="+hdCisterna.Value + "&id_abas="+codigo);
                break;
            case "eliminar":
                ActualizarAbastecimiento(codigo);
                ListarDetalle(int.Parse(hdCisterna.Value),0,0);
                ConsultarCisterna(Convert.ToInt32(hdCisterna.Value));
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

    protected void lnkRegistrar_Click(object sender, EventArgs e)
    {
        try
        {
            RegistrarCisterna();
            ListarCisterna();
            LimpiarFormCisterna();
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','No se pudo realizar el registro','error');", true);
        }
        
    }

    protected void lnkAgregar_Click(object sender, EventArgs e)
    {
        if (!hfSaldo.Value.Equals("0.00"))
        {
            LimpiarFormAbastecimiento();
            ConsultarCisterna(Convert.ToInt32(hdCisterna.Value));
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalAlertAdd').modal('show');", true);
        }
        else
        {
            if (hdTipoCisterna.Value.Equals("150300") || hdTipoCisterna.Value.Equals("150400"))
            {
                LimpiarFormAbastecimiento();
                ConsultarCisterna(Convert.ToInt32(hdCisterna.Value));
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalAlertAdd').modal('show');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','No queda saldo disponible','error');", true);
            }
        }                   
    }

    protected void lnkAddConsumo_Click(object sender, EventArgs e)
    {       
        RegistrarConsumo();
        LimpiarFormAbastecimiento();
        lnkBuscar_Click(sender, e);
        
    }

    protected void lnkRegresar_Click(object sender, EventArgs e)
    {
        ListarCisterna();
        MultiView1.ActiveViewIndex = 0;

    }

    protected void ddlCisterna_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCisterna.SelectedValue.Equals("150300") || ddlCisterna.SelectedValue.Equals("150400"))
        {
            txtCapacidad.Text = "0";
            txtRem.Text = "0";
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalAlert2').modal('show');", true);
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
        ListarCisterna();
    }

    public void LimpiarFormCisterna()
    {
        //hdCisterna.Value = "0";
        ddlCisterna.SelectedIndex = 0;
        txtCapacidad.Text = "";
        txtRem.Text = "";
        txtPrecioCompra.Text = "";
        txtTotalCarga.Text = "";
        txtTotalCargaIGV.Text = "";
        txtFactura.Text = "";
        txtFchRegistro.Text = "";
        txtFchVencimiento.Text = "";
    }

    public void LimpiarFormAbastecimiento()
    {
        hdfCisterna.Value = "0";
        ddlClienteAdd.SelectedIndex = 0;
        ddlTipoVehiculoAdd.SelectedIndex = 1;
        txtVehiculo.Text = "";
        txtVehiculo_id.Text = "";
        txtcntInicial.Text = "";
        txtcntFinal.Text = "";
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
        else if(ddlClienteAdd.SelectedValue.Equals("2"))
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

    public void ListarCisternaFiltro()
    {
        string cisterna = ddlCisternasFiltro.SelectedValue;
        string fechaInicio = dtpFechaInicioFiltro.Text;
        string fechaFin = dtpFechaFinFilro.Text;
        string estado = ddlEstadoFiltro.SelectedValue;

        CisternaBL oCisterna = new CisternaBL();
        List<CisternaEL> lst = oCisterna.ListarCisterna(cisterna,fechaInicio,fechaFin,estado);
        gvConsumo.DataSource = lst;
        gvConsumo.DataBind();
    }

    protected void lnkFiltrar_Click(object sender, EventArgs e)
    {
        ListarCisternaFiltro();
    }
}
