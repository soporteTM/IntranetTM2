using BL;
using DAL;
using EL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Solicitud_Default : System.Web.UI.Page
{
    string extension;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            loadItems(ddlVia, "02");
            loadItems2(ddlUnidad, "00");
            loadItems(ddlMovimiento, "03");
            loadItems(ddlServicio, "04");
            loadItems(ddlIncoterm, "05");
            loadItems(ddlCEmb, "06");
            loadItems(ddlAduanas, "07");
            loadItems(ddlTipoCont, "08");
            loadItems(ddlOperacion, "09");
            ListarSolicitud();
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

    public void Limpiar()
    {
        hfIdSolicitud.Value= "";
        ddlVia.SelectedIndex = 0;
        ddlMovimiento.SelectedIndex = 0;
        ddlServicio.SelectedIndex = 0;
        txtCliente.Text = "";
        txtCliente_id.Text = "";
        ddlAduanas.SelectedIndex = 0;
        ddlIncoterm.SelectedIndex = 0;
        ddlCEmb.SelectedIndex = 0;
        ddlRecojo.Items.Clear();
        ddlDevolucion.Items.Clear();
        //gvDetalle.DataSource = "";
        //gvDetalle.DataBind();
        gvContenedorDetalle.DataSource = "";
        gvContenedorDetalle.DataBind();
        //gvContenedor.DataSource = "";
        //gvContenedor.DataBind();
        ddlOperacion.SelectedIndex = 0;
        chkProveedor.Checked = false;
        txtObservacion.Text = "";

    }

    public void ListarSolicitud()
    {
        SolicitudBL oSolicitud = new SolicitudBL();
        List<SolicitudEL> lst = oSolicitud.ListarSolicitud();
        gvSolicitud.DataSource = lst;
        gvSolicitud.DataBind();
    }

    public void ListarDetalleContenedor()
    {
        SolicitudDetalleContenedorBL oSolicitud = new SolicitudDetalleContenedorBL();
        List<SolicitudDetalleContenedorEL> lst = oSolicitud.ListarDetalleContenedor(Convert.ToInt32(hfIdSolicitud.Value));
        gvContenedorDetalle.DataSource = lst;
        gvContenedorDetalle.DataBind();

        //gvContenedor.DataSource = lst;
        //gvContenedor.DataBind();

    }

    public void ListarDetalle()
    {
        SolicitudDetalleBL oSolicitud = new SolicitudDetalleBL();
        List<SolicitudDetalleEL> lst = oSolicitud.ListarDetalle(Convert.ToInt32(hfIdSolicitud.Value));
        gvDetalle.DataSource = lst;
        gvDetalle.DataBind();
    }

    public void RegistrarSolicitud()
    {
        SolicitudBL oSolicitud = new SolicitudBL();
        SolicitudEL objSolicitud = new SolicitudEL();
        objSolicitud.cd_cliente2 = Convert.ToInt32(txtCliente_id.Text);
        objSolicitud.cd_tipo_aduana = ddlAduanas.SelectedValue;
        objSolicitud.cd_tipo_mov = ddlMovimiento.SelectedValue;
        objSolicitud.cd_tipo_via = ddlVia.SelectedValue;
        objSolicitud.cd_tipo_incoterm = ddlIncoterm.SelectedValue;
        objSolicitud.cd_tipo_servicio = ddlServicio.SelectedValue;
        objSolicitud.cd_tipo_cond_emb = ddlCEmb.SelectedValue;
        objSolicitud.cd_alm_entrada = ddlRecojo.SelectedValue;
        objSolicitud.cd_alm_devolucion = ddlDevolucion.SelectedValue;
        objSolicitud.aud_usuario_creacion = hfUsuario.Value;
        objSolicitud.cd_proveedor = 1;
        objSolicitud.observaciones = txtObservacion.Text;
        objSolicitud.cd_tipo_solicitud = ddlOperacion.SelectedValue;
        objSolicitud.cd_emp_creacion = "100100";
        List<TransaccionEL> lst = oSolicitud.RegistrarSolicitud(objSolicitud);
        hfIdSolicitud.Value=lst[0].mensaje;
    }

    public void RegistrarSolicitudDst()
    {
        SolicitudDstBL oSolicitud = new SolicitudDstBL();
        SolicitudDstEL objSolicitud = new SolicitudDstEL();
        objSolicitud.or_viaje = Convert.ToInt32(txtorden.Text);
        objSolicitud.fch_programada = Convert.ToDateTime(txtfch_programada.Text);
        objSolicitud.cd_cliente = Convert.ToInt32(txtCliente2_id.Text);
        objSolicitud.origen = ddlOrigen.SelectedValue;
        objSolicitud.destino = ddlDestino.SelectedValue;
        objSolicitud.gr_transporte = txtgrtransporte.Text;
        objSolicitud.gr_sodimac = txtgrsodimac.Text;
        objSolicitud.cd_tipo_unidad = ddlUnidad.SelectedValue;
        objSolicitud.picket_ticket = txtticket.Text;
        objSolicitud.contenedor = txtcontenedor.Text;
        objSolicitud.observaciones = txtObservaciones.Text;
        objSolicitud.aud_usuario_creacion = hfUsuario.Value;
        //objSolicitud.cod_emp_creacion = "1";
        List<TransaccionEL> lst = oSolicitud.RegistrarSolicitud(objSolicitud);
    }

    public void RegistrarSolicitudTransporte()
    {
        SolicitudBL oSolicitud = new SolicitudBL();
        SolicitudEL objSolicitud = new SolicitudEL();
        objSolicitud.cd_sol = Convert.ToInt32(hfIdSolicitud.Value);
        objSolicitud.cd_tipo_solicitud = ddlOperacion.SelectedValue;
        if (chkProveedor.Checked)
            objSolicitud.cd_proveedor = 1;
        else
            objSolicitud.cd_proveedor = 0;
        objSolicitud.observaciones = txtObservacion.Text;
        List<SolicitudEL> lst = oSolicitud.RegistrarSolicitudTransporte(objSolicitud);
    }
    public void LimpiarCampos()
    {
        txtorden.Text = "";
        txtfch_programada.Text = "";
        txtCliente2.Text = "";
        ddlOrigen.SelectedIndex = 0;
        ddlDestino.SelectedIndex = 0;
        txtgrtransporte.Text = "";
        txtgrsodimac.Text = "";
        ddlUnidad.SelectedIndex = 0;
        txtticket.Text = "";
        txtcontenedor.Text = "";
        txtObservaciones.Text = "";
    }

    public void RegistrarContenedor()
    {
        SolicitudDetalleContenedorBL oCont = new SolicitudDetalleContenedorBL();
        SolicitudDetalleContenedorEL cont = new SolicitudDetalleContenedorEL();
        cont.cd_sol = Convert.ToInt32(hfIdSolicitud.Value);
        cont.cd_item = gvContenedorDetalle.Rows.Count + 1;
        cont.cd_tipo_contenedor = ddlTipoCont.SelectedValue;
        cont.pies = Convert.ToInt32(txtPies.Text);
        cont.prefijo = txtPrefijo.Text;
        cont.num_cnt = txtNumeroCont.Text;
        if (ddlDescarga1.SelectedIndex == 0)
            cont.st1_descarga = "";
        else
            cont.st1_descarga = ddlDescarga1.SelectedValue;
        if (ddlDescarga2.SelectedIndex == 0)
            cont.st2_descarga = "";
        else
            cont.st2_descarga = ddlDescarga2.SelectedValue;
        if (chkCargaSuelta.Checked)
            cont.carga_suelta = "Y";
        else
            cont.carga_suelta = "N";
        if (txtFechaCita.Text.Equals(""))
        {
            cont.sol_det_fecha_cita = Convert.ToDateTime("1900-01-01 00:00:00.000");
            cont.sol_det_hora_cita = Convert.ToDateTime("1900-01-01 00:00:00.000");
        }
        else
        {
            cont.sol_det_fecha_cita = Convert.ToDateTime(txtFechaCita.Text + " " + txtHoraCita.Text);
            cont.sol_det_hora_cita = Convert.ToDateTime(txtFechaCita.Text + " " + txtHoraCita.Text);
        }
        cont.aud_usuario_creacion = hfUsuario.Value;
        oCont.RegistrarDetalleContenedor(cont);

    }

    //protected void btnAgregarSolicitud_Click(object sender, EventArgs e)
    //{
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
    //    //MultiView1.ActiveViewIndex = 1;
    //    Limpiar();
    //}

    public void CargarCombo(DropDownList ddl, string cod)
    {
        ItemBL oItem = new ItemBL();
        CatalogoBL objCatalogo = new CatalogoBL();
        List<ItemEL> oItemEL = oItem.ConsultarCatalogoOperaciones(cod);
        ddl.SelectedItem.Text = oItemEL[0].descripcion;
        ddl.SelectedValue = oItemEL[0].id_tabla;

        ddl.DataSource = objCatalogo.ListarItemOperaciones(cod.Substring(0, 2));
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("", ""));
    }

    public void loadItems(DropDownList ddl, string id_catalogo)
    {
        ItemBL oItem = new ItemBL();
        ddl.DataSource = oItem.ListarItemOperaciones(id_catalogo);
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECCIONAR--", ""));
        ddl.SelectedIndex = 0;
    }
    public void loadItems2(DropDownList ddl, string id_catalogo)
    {
        ItemBL oItem = new ItemBL();
        ddl.DataSource = oItem.ListarItemFlota(id_catalogo);
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--SELECCIONE--", ""));
        ddl.SelectedIndex = 0;
    }



    protected void btnRefrescar_Click(object sender, EventArgs e)
    {
        MantenimientoLocalBL objCatalogo = new MantenimientoLocalBL();
        ddlRecojo.DataSource = objCatalogo.ListarLocal(Convert.ToInt32(txtCliente_id.Text));
        ddlRecojo.DataTextField = "direccion";
        ddlRecojo.DataValueField = "codigo_local";
        ddlRecojo.DataBind();
        ddlRecojo.Items.Insert(0, new ListItem("", ""));

        
        ddlDevolucion.DataSource = objCatalogo.ListarLocal(Convert.ToInt32(txtCliente_id.Text));
        ddlDevolucion.DataTextField = "direccion";
        ddlDevolucion.DataValueField = "codigo_local";
        ddlDevolucion.DataBind();
        ddlDevolucion.Items.Insert(0, new ListItem("", ""));
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
    }

    protected void gvSolicitud_PreRender(object sender, EventArgs e)
    {
        if (gvSolicitud.Rows.Count > 0)
        {
            gvSolicitud.UseAccessibleHeader = true;
            gvSolicitud.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvSolicitud.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    
    protected void btnAgregarContenedor_Click(object sender, EventArgs e)
    {
        RegistrarContenedor();
        ListarDetalleContenedor();
        ListarDetalle();
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert3').modal('show');", true);
    }

    //public void setTabs()
    //{
    //    li1.Attributes.Add("class", "");
    //    li2.Attributes.Add("class", "");
    //}

    protected void lnkLocal_Click(object sender, EventArgs e)
    {
        //setTabs();
        //li1.Attributes.Add("class", "current");
        //li1.Attributes.Add("class", "active");
        //PanelLocal.Visible = true;
        PanelContacto.Visible = false;
    }

    protected void lnkContacto_Click(object sender, EventArgs e)
    {
        //setTabs();
        //li2.Attributes.Add("class", "current");
        //li2.Attributes.Add("class", "active");
        //PanelContacto.Visible = true;
        //PanelLocal.Visible = false;
    }

    public string ValidaciondeSolicitudTransporte()
    {
        string validacion = "0La solicitud de transporte se registro Correctamente";

        if (hfIdSolicitud.Value.Equals(""))
        {
            validacion = "1Se debe generar el numero de la solicitud";
            return validacion;
        }
        if (ddlOperacion.SelectedIndex == 0)
        {
            validacion = "1Se debe seleccionar el tipo de solicitud";
            return validacion;
        }
        
        return validacion;
    }

    public string ValidacionSolicitudTransporteDst()
    {
        string validacion = "0La solicitud de transporte se registro Correctamente";

        if (ddlOrigen.SelectedValue == ddlDestino.SelectedValue)
        {
            validacion = "1El campo origen no puede ser igual destino";
        }
        if (ddlUnidad.SelectedIndex == 0)
        {
            validacion = "1El campo Tipo Unidad es obligatorio";
        }
        if (txtorden.Text.Equals(""))
        {
            validacion = "1El campo orden viaje es obligatorio";
        }

        if (txtfch_programada.Text.Equals(""))
        {
            validacion = "1El campo fecha programada es obligatorio";
        }

        if (txtcontenedor.Text.Equals(""))
        {
            validacion = "1El campo contenedor es obligatorio";
        }

        return validacion;
    }


    public string ValidaciondeSolicitud()
    {
        string validacion = "0La solicitud "+ hfIdSolicitud.Value + " se registro Correctamente";

        if(ddlVia.SelectedIndex == 0)
        {
            validacion = "1El campo Tipo Via es obligatorio";
            return validacion;
        }
        if (ddlMovimiento.SelectedIndex == 0)
        {
            validacion = "1El campo Movimiento es obligatorio";
            return validacion;
        }
        if (ddlServicio.SelectedIndex == 0)
        {
            validacion = "1El campo Servicio es obligatorio";
            return validacion;
        }
        if (txtCliente.Text.Equals(""))
        {
            validacion = "1Se debe seleccionar un cliente";
            return validacion;
        }
        if (txtCliente_id.Text.Equals(""))
        {
            validacion = "1Se debe seleccionar un cliente";
            return validacion;
        }
        if (ddlAduanas.SelectedIndex == 0)
        {
            validacion = "1El campo Aduanas es obligatorio";
            return validacion;
        }
        if (ddlIncoterm.SelectedIndex == 0)
        {
            validacion = "1El campo Incoterm es obligatorio";
            return validacion;
        }
        if (ddlCEmb.SelectedIndex == 0)
        {
            validacion = "1El campo C Emb. es obligatorio";
            return validacion;
        }


        return validacion;
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

    protected void lnkSolicitud_Click(object sender, EventArgs e)
    {
        //setTabs();
        //li1.Attributes.Add("class", "current");
        //li1.Attributes.Add("class", "active");
    }

    protected void lnkDetalleContenedor_Click(object sender, EventArgs e)
    {
        try
        {
            string validacion = ValidaciondeSolicitud();
            int codigomensaje = Convert.ToInt32(validacion.Substring(0, 1));
            string mensaje = validacion.Substring(1, validacion.Length - 1);

            if (codigomensaje == 0)
            {
                if (hfIdSolicitud.Value.Equals(""))
                {
                    RegistrarSolicitud();
                    MostrarMensaje(codigomensaje, mensaje);
                }
            }
            else
            {
                MostrarMensaje(codigomensaje, mensaje);
            }

            if (!hfIdSolicitud.Value.Equals(""))
            {
                //setTabs();
                //li2.Attributes.Add("class", "current");
                //li2.Attributes.Add("class", "active");
            }
            
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo registrar la solicitud");
        }
    }

    protected void lnkSolicitudTransporte_Click(object sender, EventArgs e)
    {
        //setTabs();
    }

    protected void gvSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Observar":
                string cod_Sol = e.CommandArgument.ToString();

                SolicitudBL oSolicitud = new SolicitudBL();
                List<SolicitudEL> lst = oSolicitud.ConsultarSolicitud(Convert.ToInt32(cod_Sol));
                CargarCombo(ddlVia,lst[0].cd_tipo_via);
                CargarCombo(ddlMovimiento,lst[0].cd_tipo_mov);
                CargarCombo(ddlServicio,lst[0].cd_tipo_servicio);

                CargarCombo(ddlAduanas, lst[0].cd_tipo_aduana);
                CargarCombo(ddlIncoterm, lst[0].cd_tipo_incoterm);
                CargarCombo(ddlCEmb, lst[0].cd_tipo_cond_emb);

                txtCliente.Text = lst[0].nom_cliente;
                txtCliente_id.Text = lst[0].cd_cliente2+"";

                ddlRecojo.Items.Insert(0, new ListItem(lst[0].direccion_entrada, lst[0].cd_alm_entrada));
                ddlRecojo.SelectedIndex = 0;

                ddlDevolucion.Items.Insert(0, new ListItem(lst[0].direccion_devolucion, lst[0].cd_alm_devolucion));
                ddlDevolucion.SelectedIndex = 0;

                if (!lst[0].cd_tipo_solicitud.Equals(""))
                {
                    CargarCombo(ddlOperacion, lst[0].cd_tipo_solicitud);
                }
                else
                {
                    ddlOperacion.SelectedIndex = 0;
                }
                txtObservacion.Text = lst[0].observaciones;
                if (lst[0].cd_proveedor == 1)
                    chkProveedor.Checked = true;
                else
                    chkProveedor.Checked = false;

                hfIdSolicitud.Value = cod_Sol;
                ListarDetalleContenedor();
                ListarDetalle();

                MultiView1.ActiveViewIndex = 1;

                //setTabs();
                //li1.Attributes.Add("class", "current");
                //li1.Attributes.Add("class", "active");
                break;
            case "DetalleContenedor":
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                hfIdSolicitud.Value = "";
                hfIdSolicitud.Value = arg[0].ToString();
                lblSolicitud.Text = arg[0].ToString();
                lblCliente.Text = arg[1].ToString();
                ListarDetalleContenedor();
                ListarDetalle();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert3').modal('show');", true);
                MultiView1.ActiveViewIndex = 1;
                //PanelLocal.Visible = true;

                //setTabs();
                //li1.Attributes.Add("class", "current");
                //li1.Attributes.Add("class", "active");

                break;
            case "SolicitudTransporte":
                string cod_sol2 = e.CommandArgument.ToString();
                hfIdSolicitud.Value = cod_sol2;
                SolicitudBL oSolicitud2 = new SolicitudBL();
                List<SolicitudEL> lst2 = oSolicitud2.ConsultarSolicitud(Convert.ToInt32(cod_sol2));
                if (!lst2[0].cd_tipo_solicitud.Equals(""))
                {
                    CargarCombo(ddlOperacion, lst2[0].cd_tipo_solicitud);
                }
                else
                {
                    ddlOperacion.SelectedIndex = 0;
                }
                txtObservacion.Text = lst2[0].observaciones;
                if (lst2[0].cd_proveedor == 1)
                    chkProveedor.Checked = true;
                else
                    chkProveedor.Checked = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert4').modal('show');", true);
                break;
        }
    }

    protected void btnGuardarSolicitud_Click(object sender, EventArgs e)
    {
        try
        {
            string validacion = ValidaciondeSolicitud();
            int codigomensaje = Convert.ToInt32(validacion.Substring(0, 1));
            string mensaje = validacion.Substring(1, validacion.Length - 1);

            if (codigomensaje == 0)
            {
                    RegistrarSolicitud();
                    ListarSolicitud();
            }

            MostrarMensaje(codigomensaje, mensaje);
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo registrar la solicitud");
        }
    }

    protected void btnSolicitudTransporte_Click(object sender, EventArgs e)
    {
        try
        {
            string validacion = ValidaciondeSolicitudTransporte();
            int codigomensaje = Convert.ToInt32(validacion.Substring(0, 1));
            string mensaje = validacion.Substring(1, validacion.Length - 1);

            if (codigomensaje == 0)
            {
                RegistrarSolicitudTransporte();
                MultiView1.ActiveViewIndex = 0;
                ListarSolicitud();
            }
            MostrarMensaje(codigomensaje, mensaje);
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo registrar la solicitud de transporte");
        }
    }

    protected void lnkImportar_Click(object sender, EventArgs e)
    {
        ImportarPedidos();
    }

    public void ImportarPedidos()
    {
        DataTable ds = new DataTable();
        SolicitudDetalleContenedorBL oContenedorBL = new SolicitudDetalleContenedorBL();
        ArrayList ContenedorA = new ArrayList();
        string FileName = Path.GetFileName(fuImportar.PostedFile.FileName);
        string Extension = Path.GetExtension(fuImportar.PostedFile.FileName);
        string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
        extension = Extension;
        if (Extension == ".xls" || Extension == ".xlsx")
        {
            string FilePath = Server.MapPath(FolderPath + FileName);
            fuImportar.SaveAs(FilePath);
            ds = Util.Import_To_Grid2(FilePath, Extension, "Yes");
            for (int i = 0; i <= ds.Rows.Count - 1; i++)
            {
                
                if (!String.IsNullOrEmpty(ds.Rows[i][0].ToString()))
                {
                    try
                    {
                        //Orden Pedido
                        SolicitudDetalleContenedorEL objContenedor = new SolicitudDetalleContenedorEL();
                        objContenedor.cd_sol =Convert.ToInt32(hfIdSolicitud.Value);
                        objContenedor.cd_item =i+1;
                        objContenedor.prefijo = ds.Rows[i][0].ToString();
                        objContenedor.num_cnt = ds.Rows[i][1].ToString();
                        objContenedor.cd_tipo_contenedor = ds.Rows[i][2].ToString();
                        objContenedor.pies = Convert.ToInt32(ds.Rows[i][3].ToString());
                        objContenedor.aud_usuario_creacion = hfUsuario.Value;
                        oContenedorBL.ImportarContenedor(objContenedor);
                    }
                    catch (Exception e)
                    {
                        
                    }
                }
            }

            
        }
        else
            MostrarMensaje(1, "Se debe seleccionar un archivo excel");
    }

    protected void btnImportar_Click(object sender, EventArgs e)
    {

    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert3').modal('show');", true);
    }

    protected void btnImpo_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert7').modal('show');", true);
    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        ListarSolicitud();
    }

    protected void gvSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnDetalle = (LinkButton)e.Row.FindControl("btnDetalleContenedor");
            Label lblServicio = (Label)e.Row.FindControl("lblServicio");

            if (lblServicio.Text.Contains("Distribucion"))
            {
                btnDetalle.CssClass = "btn btn-icon waves-effect waves-light btn-primary disabled m-b-5";
            }
        }
    }

    protected void btnrefresh_Click(object sender, EventArgs e)
    {
        MantenimientoLocalBL objCatalogo = new MantenimientoLocalBL();
        ddlOrigen.DataSource = objCatalogo.ListarLocal(Convert.ToInt32(txtCliente2_id.Text));
        ddlOrigen.DataTextField = "direccion";
        ddlOrigen.DataValueField = "codigo_local";
        ddlOrigen.DataBind();
        ddlOrigen.Items.Insert(0, new ListItem("", ""));

        ddlDestino.DataSource = objCatalogo.ListarLocal(Convert.ToInt32(txtCliente2_id.Text));
        ddlDestino.DataTextField = "direccion";
        ddlDestino.DataValueField = "codigo_local";
        ddlDestino.DataBind();
        ddlDestino.Items.Insert(0, new ListItem("", ""));
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert5').modal('show');", true);
    }

    protected void btnAsignar_Click(object sender, EventArgs e)
    {
        try
        {
            string validacion = ValidacionSolicitudTransporteDst();
            int codigomensaje = Convert.ToInt32(validacion.Substring(0, 1));
            string mensaje = validacion.Substring(1, validacion.Length - 1);
            if (codigomensaje == 0)
            {
                RegistrarSolicitudDst();
                ListarSolicitud();
                LimpiarCampos();
            }
            MostrarMensaje(codigomensaje, mensaje);
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo registrar la solicitud de transporte");
        }
    }
}