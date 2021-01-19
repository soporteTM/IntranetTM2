using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using DAL;
using EL;
using System.IO;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Drawing;
using Newtonsoft.Json;
using System.Text;

public partial class Modulos_TMS_Default : System.Web.UI.Page
{
    TPL_BL objTPL = new TPL_BL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Iniciar();
        }
    }
    public void Iniciar()
    {
        CargarEmpresa();
        cargarEstados();
        CargarMovimiento();
        cargarTransporte();
        CargarTipoSol();
        CargarCondicionEmbarque();
        txtFechaHastaFiltro.Text = DateTime.Now.ToShortDateString();
        txtFechaDesdeFiltro.Text = DateTime.Now.AddDays(-1).ToShortDateString();
        CargarIncoterm();
        CargarTipoContenedor();
        cargarTerminales();
        CargarAduana();
        //cargarSolicitudTransporte()
        //****CargarEmpresaTransporte();
        txtFechaSolicitud.Text = DateTime.Now.ToShortDateString();
        CargarCliente();
        //txtSectorista.Text = User.Identity.Name

        //ddlTipoSolicitudFiltro.SelectedValue = "5"
        //ddlTipoSolicitudFiltro.Enabled = False

        //If Not Request.QueryString("codigo") Is Nothing Then
        //    Editar(Convert.ToInt32(Request.QueryString("codigo")))
        //End If

        //If Not Request.QueryString("Opcion") Is Nothing Then
        //    If Request.QueryString("Opcion") = "1" Then
        //        MultiView1.ActiveViewIndex = 1
        //        Limpiar()
        //    End If
        //End If
        txtALFiltro.Text = Request.QueryString["ExAL"];
        cargarSolicitudTransporte();
        //CargaDatos("A", "T", "", 0, 0, "A", Convert.ToDateTime("01/01/2021"), Convert.ToDateTime("04/01/2021"), "Todos", "");
    }
    string ObtenerDatosSesion(string tipo)
    {
        string dato = "";
        HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        if (authCookie != null)
        {
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            String dataUser = (authTicket.UserData != null && authTicket.UserData != "" ? authTicket.UserData : "");
            String[] data = dataUser.Split('|');
            if (tipo == "perfil")
            {
                dato = data[3];
            }
            if (tipo == "codigo")
            {
                dato = data[4];
            }
            if (tipo == "nombres")
            {
                dato = data[2];
            }
            if (tipo == "usuario")
            {
                dato = data[1];
            }
        }
        return dato;
    }

    public void CargarCliente()
    {
        ddlCliente.Items.Clear();
        TMS_ClientesBL oCliente = new TMS_ClientesBL();
        List<TMS_SubClientesEL> lista = oCliente.ListarSubClientes(ddlEmpresa.SelectedValue);
        ddlCliente.DataSource = lista;
        ddlCliente.DataTextField = "Raz_Soc";
        ddlCliente.DataValueField = "Cod_Empresa";
        ddlCliente.DataBind();
        ddlCliente.Items.Insert(0, new ListItem("[Seleccionar]", ""));

        //if (ddlCliente.Items.Count > 0)
        //{
        //    if (ddlCliente.Items[0].Value.ToString().Trim() == "")
        //    {
        //        ddlCliente.Items.RemoveAt(0);
        //    }

        //}
    }
    public void CargarEmpresa()
    {
        TMS_ClientesBL oCliente = new TMS_ClientesBL();
        List<TMS_ClientesEL> lista = oCliente.ListarClientes("*");
        ddlEmpresa.DataSource = lista;
        ddlEmpresa.DataTextField = "Raz_Soc";
        ddlEmpresa.DataValueField = "Cod_Empresa";
        ddlEmpresa.DataBind();
        ddlEmpresa.Items.Insert(0, new ListItem("[Seleccionar]", ""));

        //FILTRO
        ddlEmpresaFiltro.DataSource = lista;
        ddlEmpresaFiltro.DataTextField = "Raz_Soc";
        ddlEmpresaFiltro.DataValueField = "Cod_Empresa";
        ddlEmpresaFiltro.DataBind();
        ddlEmpresaFiltro.Items.Insert(0, new ListItem(" Todos", " Todos"));

        //ddlEmpresa.DataSource = objTPL.ListarEmpresa();
        //ddlEmpresa.DataTextField = "Ent_Rsoc";
        //ddlEmpresa.DataValueField = "Ent_Codi";
        //ddlEmpresa.DataBind();
        //ddlEmpresa.Items.Insert(0, new ListItem("[Seleccionar]", ""));

        //if (ddlEmpresaFiltro.Items.Count > 0) {
        //    if( ddlEmpresaFiltro.Items[0].Value.ToString().Trim() == "Todos")
        //    {
        //        ddlEmpresaFiltro.Items.RemoveAt(0);
        //    }
        //}
        //if (ddlEmpresa.Items.Count > 0)
        //{
        //    if (ddlEmpresa.Items[1].Value.ToString().Trim() == "Todos")
        //    {
        //        ddlEmpresa.Items.RemoveAt(1);
        //    }

        //}
    }
    public void cargarTransporte()
    {

        ddlTransporte.DataSource = objTPL.ListarTransporte();
        ddlTransporte.DataTextField = "EMPRETRANS_RAZONSOCIAL";
        ddlTransporte.DataValueField = "EMPRETRANS_CODIGO";
        ddlTransporte.DataBind();
        //ddlTransporte.Items.Insert(0, new ListItem("[Seleccionar]", ""));
        ddlTransporte.SelectedValue = "88";
    }

    public void cargarEstados()
    {

        ddlEstado.DataSource = objTPL.ListarEstados();
        ddlEstado.DataTextField = "Estado";
        ddlEstado.DataValueField = "ros_estado";
        ddlEstado.DataBind();
        ddlEstado.Items.RemoveAt(0);
        //ddlEstado.Items.Insert(0, New ListItem("[Seleccionar]", "0"))
        ddlEstado.SelectedValue = "P";

        ddlEstadoFiltro.DataSource = objTPL.ListarEstados();
        ddlEstadoFiltro.DataTextField = "Estado";
        ddlEstadoFiltro.DataValueField = "ros_estado";
        ddlEstadoFiltro.DataBind();

        //ddlEstadoFiltro.Items.Insert(0, New ListItem("MOSTRAR TODOS", "0"))
    }
    public void CargarTipoSol()
    {

        ddlTipoSolicitudFiltro.Items.Clear();
        ddlTipoSolicitudFiltro.Items.Add(new ListItem("Todos", "0"));
        ddlTipoSolicitudFiltro.DataSource = objTPL.ListarTipoSolicitud();
        ddlTipoSolicitudFiltro.DataTextField = "TS_Des";
        ddlTipoSolicitudFiltro.DataValueField = "TS_Cod";
        ddlTipoSolicitudFiltro.DataBind();

        ddlTipoSolicitud.DataSource = objTPL.ListarTipoSolicitud();

        ddlTipoSolicitud.DataTextField = "TS_Des";
        ddlTipoSolicitud.DataValueField = "TS_Cod";
        ddlTipoSolicitud.DataBind();
        // ddlTipoSolicitud.Items.Add(new ListItem("[Seleccionar]", ""));
        ddlTipoSolicitud.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        // ddlTipoSolicitud.Enabled = false;
        //  ddlTipoSolicitud.SelectedValue = "5";

    }
    public void CargarMovimiento()
    {
        ddlMovimientoFiltro.DataSource = objTPL.ListarTipoMovimiento();
        ddlMovimientoFiltro.DataTextField = "Movimiento";
        ddlMovimientoFiltro.DataValueField = "ro_tmov";
        ddlMovimientoFiltro.DataBind();
        ddlMovimientoFiltro.Items.RemoveAt(3);

        ddlMovimiento.DataSource = objTPL.ListarTipoMovimiento();
        ddlMovimiento.DataTextField = "Movimiento";
        ddlMovimiento.DataValueField = "ro_tmov";
        ddlMovimiento.DataBind();
        ddlMovimiento.Items.RemoveAt(0);
        ddlMovimiento.Items.RemoveAt(2);
        ddlMovimiento.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

    }
    public void CargarTipoContenedor()
    {
        dllTipoCTN.DataSource = objTPL.ListarTipoContenedor();
        dllTipoCTN.DataTextField = "Tipo";
        dllTipoCTN.DataValueField = "IDTipo";
        dllTipoCTN.DataBind();
        dllTipoCTN.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

        //ddlTipo2CTN.DataSource = objTPL.ListarTipoContenedor();
        //ddlTipo2CTN.DataTextField = "Tipo";
        //ddlTipo2CTN.DataValueField = "IDTipo";
        //ddlTipo2CTN.DataBind();
        //ddlTipo2CTN.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }
    public void cargarTerminales()
    {
        DataTable Data = objTPL.ListarTerminales();
        //DataTable DataTerminales = Data.AsEnumerable().Where(Function(p) p.Field(Of Boolean)(4) = True).CopyToDataTable()
        var DataTerminales = Data.AsEnumerable().Where(p => p.Field<bool>(4) == true).CopyToDataTable();
        ddlTerminal.DataSource = DataTerminales;
        ddlTerminal.DataValueField = "Codigo";
        ddlTerminal.DataTextField = "Descripcion";
        ddlTerminal.DataBind();
        ddlTerminal.Items.Insert(0, new ListItem("[Seleccionar]", ""));

        ddlTerminalRetiro.DataSource = DataTerminales;
        ddlTerminalRetiro.DataValueField = "Codigo";
        ddlTerminalRetiro.DataTextField = "Descripcion";
        ddlTerminalRetiro.DataBind();
        ddlTerminalRetiro.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

        ddlTerminalDevolucion.DataSource = DataTerminales;
        ddlTerminalDevolucion.DataValueField = "Codigo";
        ddlTerminalDevolucion.DataTextField = "Descripcion";
        ddlTerminalDevolucion.DataBind();
        ddlTerminalDevolucion.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

        //Dim viewTerminales As DataView = New DataView(DataTerminales)
        //viewTerminales.RowFilter = DataTerminales.Columns("Dep_Flre").ColumnName + " = 1"
        cargarPuertos(Data);
    }
    public void cargarPuertos(DataTable Data)
    {


        //DataTable DataTerminales = Data.AsEnumerable().Where(Function(p) p.Field(Of Boolean)(4) = True And(p.Field(Of String)(1).Contains("APM") Or p.Field(Of String)(1).Contains("DP"))).CopyToDataTable()
        DataTable DataTerminales = Data;
        ////Me.ddlPuerto.Items.Insert(0, New ListItem("APM", 2))
        ////Me.ddlPuerto.Items.Insert(0, New ListItem("DPW", 1))

        ddlPuerto.DataSource = DataTerminales;
        ddlPuerto.DataValueField = "Codigo";
        ddlPuerto.DataTextField = "Descripcion";
        ddlPuerto.DataBind();

        ddlPuerto.Items.Insert(0, new ListItem("[Seleccionar]", ""));
    }
    public void CargarCondicionEmbarque()
    {
        ddlCEmbarque.DataSource = objTPL.ListarCondicionEmbarque();
        ddlCEmbarque.DataTextField = "Desc";
        ddlCEmbarque.DataValueField = "Codi";
        ddlCEmbarque.DataBind();
        ddlCEmbarque.Items.Insert(0, new ListItem("[Seleccionar]", ""));

        if (ddlCEmbarque.Items.Count > 0)
        {
            if (ddlCEmbarque.Items[1].Value.ToString().Trim() == "")
            {
                ddlCEmbarque.Items.RemoveAt(1);
            }

        }
    }
    public void CargarIncoterm()
    {
        ddlIncoterm.DataSource = objTPL.ListarIncoterm();
        ddlIncoterm.DataTextField = "Name";
        ddlIncoterm.DataValueField = "Codi";
        ddlIncoterm.DataBind();
        ddlIncoterm.Items.Insert(0, new ListItem("[Seleccionar]", ""));

        if (ddlIncoterm.Items.Count > 0)
        {
            if (ddlIncoterm.Items[1].Value.ToString().Trim() == "")
            {
                ddlIncoterm.Items.RemoveAt(1);
            }

        }
    }
    public void CargarAduana()
    {
        ddlAduana.DataSource = objTPL.ListarAduana();
        ddlAduana.DataTextField = "Desc";
        ddlAduana.DataValueField = "Codi";
        ddlAduana.DataBind();
        ddlAduana.Items.Insert(0, new ListItem("[Seleccionar]", ""));

        if (ddlAduana.Items.Count > 0)
        {
            if (ddlAduana.Items[1].Value.ToString().Trim() == "")
            {
                ddlAduana.Items.RemoveAt(1);
            }

        }
    }
    public void CargarLocales(string cliente)
    {
        ddlLocal1.DataSource = objTPL.ListarLocales(cliente);
        ddlLocal1.DataTextField = "DIRECCION";
        ddlLocal1.DataValueField = "LOCAL_CODIGO";
        ddlLocal1.DataBind();
        ddlLocal1.Items.Insert(0, new ListItem("[Sin Especificar]", "0"));

        if (ddlLocal1.Items.Count > 0)
        {
            if (ddlLocal1.Items[1].Value.ToString().Trim() == "0")
            {
                ddlLocal1.Items.RemoveAt(1);
            }

        }

        ddlLocal2.DataSource = objTPL.ListarLocales(cliente);
        ddlLocal2.DataTextField = "DIRECCION";
        ddlLocal2.DataValueField = "LOCAL_CODIGO";
        ddlLocal2.DataBind();
        ddlLocal2.Items.Insert(0, new ListItem("[Sin Especificar]", "0"));

        if (ddlLocal2.Items.Count > 0)
        {
            if (ddlLocal2.Items[1].Value.ToString().Trim() == "0")
            {
                ddlLocal2.Items.RemoveAt(1);
            }

        }


        ddlLocal1Masivo.DataSource = objTPL.ListarLocales(cliente);
        ddlLocal1Masivo.DataTextField = "DIRECCION";
        ddlLocal1Masivo.DataValueField = "LOCAL_CODIGO";
        ddlLocal1Masivo.DataBind();
        ddlLocal1Masivo.Items.Insert(0, new ListItem("[Sin Especificar]", "0"));

        if (ddlLocal1Masivo.Items.Count > 0)
        {
            if (ddlLocal1Masivo.Items[1].Value.ToString().Trim() == "0")
            {
                ddlLocal1Masivo.Items.RemoveAt(1);
            }

        }


        ddlLocal2Masivo.DataSource = objTPL.ListarLocales(cliente);
        ddlLocal2Masivo.DataTextField = "DIRECCION";
        ddlLocal2Masivo.DataValueField = "LOCAL_CODIGO";
        ddlLocal2Masivo.DataBind();
        ddlLocal2Masivo.Items.Insert(0, new ListItem("[Sin Especificar]", "0"));

        if (ddlLocal2Masivo.Items.Count > 0)
        {
            if (ddlLocal2Masivo.Items[1].Value.ToString().Trim() == "0")
            {
                ddlLocal2Masivo.Items.RemoveAt(1);
            }

        }
    }

    private void RegistrarScript()
    {
        const string ScriptKey = "ScriptKey";
        if (!ClientScript.IsStartupScriptRegistered(this.GetType(), ScriptKey))
        {
            StringBuilder fn = new StringBuilder();
            fn.Append("function arregloGrilla() { ");
            fn.Append("gridViewScroll = new GridViewScroll({ " +
                        "elementID: 'GVPlaneamiento'," +
                        "width: 850," +
                        "height: 350," +
                        "freezeColumn: true," +
                        "freezeFooter: false," +
                        "freezeColumnCssClass: 'GridViewScrollItemFreeze'," +
                        "freezeHeaderRowCount: 1," +
                        "freezeColumnCount: 3)}");
            fn.Append("}");
            ClientScript.RegisterStartupScript(this.GetType(), ScriptKey, fn.ToString(), true);
        }
    }

    protected void btnFiltrarSolicitudes_Click(object sender, EventArgs e)
    {
        //RegistrarScript();
        this.btnFiltrarSolicitudes.Attributes.Add("OnClick", "javascript:return arregloGrilla();");
        cargarSolicitudTransporte();
    }
    public void cargarSolicitudTransporte()
    {
        int pAL, pSolicitud;
        string pFecIni, pContenedor;
        if (txtALFiltro.Text == "")
        {
            pAL = 0;
        }
        else
        {
            pAL = Convert.ToInt32(txtALFiltro.Text.Trim());
        }

        if (txtNroSolicitudFiltro.Text == "")
        {
            pSolicitud = 0;
        }
        else
        {
            pSolicitud = Convert.ToInt32(txtNroSolicitudFiltro.Text.Trim());
        }

        if (txtALFiltro.Text == "" && txtNroSolicitudFiltro.Text == "")
        {
            pFecIni = (String.IsNullOrEmpty(txtFechaDesdeFiltro.Text) ? "01/01/2011" : txtFechaDesdeFiltro.Text);
        }
        else
        {
            pFecIni = "01/01/2011";
        }

        if (txtContenedorFiltro.Text == "")
        {
            pContenedor = "";
        }
        else
        {
            pContenedor = txtContenedorFiltro.Text;
        }

        CargaDatos(ddlMovimientoFiltro.SelectedValue, ddlEstadoFiltro.SelectedValue, "", pSolicitud, pAL, ddlSeguimientoFiltro.SelectedValue, Convert.ToDateTime(pFecIni), Convert.ToDateTime(String.IsNullOrEmpty(txtFechaHastaFiltro.Text) ? "01/01/2011" : txtFechaHastaFiltro.Text), ddlEmpresaFiltro.SelectedItem.Text, pContenedor);

    }

    public void CargaDatos(string pMovimiento, string pEstado, string pCliente, int pSolicitud, int pAl, string pSeguimiento, DateTime pFecIni, DateTime pFecFin, string pEmp, string pContenedor)
    {
        try
        {
            TPL_BL objTPL = new TPL_BL();
            GVPlaneamiento.DataSource = objTPL.BuscarSolicitud(Convert.ToInt32(ddlTipoSolicitudFiltro.SelectedValue), pMovimiento, pEstado, pCliente, pSolicitud, pAl, pSeguimiento, pFecIni, pFecFin, pEmp, "Todos", pContenedor);
            GVPlaneamiento.DataBind();
            //Dim i As Integer
            //For i = 0 To GVPlaneamiento.Rows.Count - 1
            //    If GVPlaneamiento.Rows(i).Cells(9).Text = "Cerrado" Or GVPlaneamiento.Rows(i).Cells(9).Text = "Anulado" Or _
            //       GVPlaneamiento.Rows(i).Cells(5).Text = "Anulado" Or GVPlaneamiento.Rows(i).Cells(5).Text = "Cerrado" Then
            //        CType(GVPlaneamiento.Rows(i).Cells(1).FindControl("Checkbox1"), CheckBox).Enabled = False
            //        ' CType(GVPlaneamiento.Rows(i).Cells(1).FindControl("hplSolicitud"), LinkButton).Enabled = False
            //        CType(GVPlaneamiento.Rows(i).Cells(1).FindControl("hplSolicitud"), LinkButton).OnClientClick = "JAlertShow('Información','Solicitud anulada');return false; "
            //        'GVPlaneamiento.Rows(i).BackColor = Drawing.Color.Red
            //    End If
            //Next
        }
        catch (Exception ex1)
        {
            MostrarMensaje(1, "Error. Informar a Sistemas:" + ex1);
        }

    }

    protected void btnAgregarSolicitud_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        Limpiar();
        //GVDetalleSolicitud.Columns[8].Visible = false;


        setTabs();

    }

    protected void GVPlaneamiento_PreRender(object sender, EventArgs e)
    {
        Prerender(GVPlaneamiento);
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
    void Limpiar()
    {

        txtNroSolicitud.Text = String.Empty;
        txtAL.Text = String.Empty;
        ddlMovimiento.SelectedIndex = 0;
        txtObservacion.Text = "";
        ddlEmpresa.SelectedIndex = 0;
        ddlTipoSolicitud.SelectedIndex = 0;
        ddlEstado.SelectedValue = "P";
        ddlEstado.Enabled = false;
        txtBKG.Text = String.Empty;
        txtBL.Text = "";
        ddlIncoterm.SelectedIndex = 1;
        ddlPuerto.SelectedIndex = 0;
        ddlTerminal.SelectedIndex = 0;
        txtFechaSolicitud.Text = DateTime.Now.ToShortDateString();
        //txtNave.Text = String.Empty;
        HFCodigo.Value = "0";
        ddlCliente.SelectedIndex = 0;
        ddlCEmbarque.SelectedIndex = 0;
        ddlAduana.SelectedValue = "118";
        gvDetalleServicios.DataSource = null;
        gvDetalleServicios.DataBind();
        GVDetalleSolicitud.DataSource = null;
        GVDetalleSolicitud.DataBind();
        txtFechaSolicitud.Text = DateTime.Today.ToString("dd/MM/yyyy");
        //DetalleTotalTransporte.Clear();
        //DetalleTotalTransporteEliminar.Clear();
        //DetalleContenedores.Clear();
        //DetalleContenedoresEliminar.Clear();
        //btnImportarCTN.Visible = False
        ddlEmpresa.SelectedIndex = 0;
        HFCodigo.Value = "0";

        ddlTipo2CTN.Items.Clear();
        ddlTipo2CTN.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

    }
    protected void GVDetalleSolicitud_PreRender(object sender, EventArgs e)
    {
        Prerender(GVDetalleSolicitud);
    }
    protected void gvDetalleServicios_PreRender(object sender, EventArgs e)
    {
        Prerender(gvDetalleServicios);
    }
    protected void btnAgregarPopup_CTN_Click(object sender, EventArgs e)
    {
        IList<TMS_Solicitud_DetalleCarga> DetalleCarga = optenerDetalleCarga();

        if (HFIndexServicio.Value == "-1")
        {
            TMS_Solicitud_DetalleCarga entidad = new TMS_Solicitud_DetalleCarga();
            entidad.Cantidad = Convert.ToInt32(this.txtTotalCTN.Text);
            String[] valores = dllTipoCTN.SelectedValue.Split('|');
            entidad.TipoPies = Convert.ToInt32(valores[1]);
            entidad.TipoCTN = valores[0];
            entidad.TipoBulto = "19";
            entidad.Monto = 0;
            entidad.Come = "";

            var validar = DetalleCarga.AsQueryable().Where(n => n.TipoCTN == entidad.TipoCTN & n.TipoPies == entidad.TipoPies).ToList();

            if (validar.Count() == 0)
                DetalleCarga.Add(entidad);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Tipo y pies de contenedor ya se agregaron.','Información','danger');", true);
        }

        else
        {
            DetalleCarga[Convert.ToInt32(HFIndexServicio.Value)].Cantidad = Convert.ToInt32(this.txtTotalCTN.Text);
            string[] valores = dllTipoCTN.SelectedValue.Split('|');
            DetalleCarga[Convert.ToInt32(HFIndexServicio.Value)].TipoPies = Convert.ToInt32(valores[1]);
            DetalleCarga[Convert.ToInt32(HFIndexServicio.Value)].TipoCTN = valores[0];
        }

        ddlTipo2CTN.Items.Clear();
        foreach (TMS_Solicitud_DetalleCarga tipo in DetalleCarga)
        {
            ddlTipo2CTN.Items.Insert(0, new ListItem(tipo.TipoPies.ToString() + " - " + tipo.TipoCTN, tipo.TipoCTN + "|" + tipo.TipoPies.ToString()));
        }
        if (DetalleCarga.Count > 1)
            ddlTipo2CTN.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        //ddlTipo2CTN.DataSource = objTPL.ListarTipoContenedor();
        //ddlTipo2CTN.DataTextField = "Tipo";
        //ddlTipo2CTN.DataValueField = "IDTipo";
        //ddlTipo2CTN.DataBind();
        //ddlTipo2CTN.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

        gvDetalleServicios.DataSource = DetalleCarga;
        gvDetalleServicios.DataBind();
    }
    public IList<TMS_Solicitud_DetalleCarga> optenerDetalleCarga()
    {
        IList<TMS_Solicitud_DetalleCarga> DetalleCarga = new List<TMS_Solicitud_DetalleCarga>();
        if (gvDetalleServicios.Rows.Count > 0)
        {
            foreach (GridViewRow row in gvDetalleServicios.Rows)
            {
                TMS_Solicitud_DetalleCarga entidad = new TMS_Solicitud_DetalleCarga();
                entidad.TipoPies = Convert.ToInt32(((Label)row.FindControl("lblTipoPies")).Text);
                entidad.TipoCTN = ((Label)row.FindControl("lblTIPOCTN")).Text;
                entidad.Cantidad = Convert.ToInt32(((Label)row.FindControl("lblCantidad")).Text);
                entidad.TipoBulto = "19";
                entidad.Monto = 0;
                entidad.Come = "";
                DetalleCarga.Add(entidad);
            }
        }
        return DetalleCarga;
    }
    public IList<TMS_Solicitud_DetalleContenedores> optenerDetalleContenedor()
    {
        IList<TMS_Solicitud_DetalleContenedores> DetalleCarga = new List<TMS_Solicitud_DetalleContenedores>();
        if (GVDetalleSolicitud.Rows.Count > 0)
        {
            foreach (GridViewRow row in GVDetalleSolicitud.Rows)
            {
                //TMS_Solicitud_DetalleContenedores entidad = new TMS_Solicitud_DetalleContenedores();
                //entidad.Pies = 
                //entidad.Tipo = 

                TMS_Solicitud_DetalleContenedores Entidad = new TMS_Solicitud_DetalleContenedores();
                Entidad.Prefijo = ((Label)row.FindControl("lblPrefijo")).Text;
                Entidad.Numero = ((Label)row.FindControl("lblNumero")).Text;
                Entidad.Contenedor = Entidad.Prefijo + Entidad.Numero;

                Entidad.Pies = Convert.ToInt32(((Label)row.FindControl("lblItemPies")).Text);
                Entidad.Tipo = ((Label)row.FindControl("lblItemTipo")).Text;
                Entidad.Tara = 0;
                Entidad.Peso = 0;
                Entidad.Precinto = "";

                Entidad.Bultos = 19; // Contenedores
                Entidad.EsNuevo = (HFCodigo.Value == "0" ? true : false);
                Entidad.IDLocal1 = Convert.ToInt32(((Label)row.FindControl("lblIDLocal")).Text);
                Entidad.Local1 = ((Label)row.FindControl("lblLocal")).Text;
                Entidad.IDLocal2 = Convert.ToInt32(((Label)row.FindControl("lblIDLocal2")).Text);
                Entidad.Local2 = ((Label)row.FindControl("lblLocal2")).Text;
                Entidad.FechaCita = ((Label)row.FindControl("lblFechaCita")).Text;
                Entidad.HoraCita = ((Label)row.FindControl("lblHoraCita")).Text;
                Entidad.Transportista_ruc = ((Label)row.FindControl("lblIDTransporte")).Text;
                Entidad.Transportista = ((Label)row.FindControl("lblTransporte")).Text;

                DetalleCarga.Add(Entidad);
            }
        }
        return DetalleCarga;
    }

    protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlLocal1.Items.Clear();
        ddlLocal2.Items.Clear();
        if (ddlCliente.SelectedIndex > 0)
        {
            CargarLocales(ddlCliente.SelectedValue);
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        IList<TMS_Solicitud_DetalleCarga> DetalleCarga = optenerDetalleCarga();
        IList<TMS_Solicitud_DetalleContenedores> DetalleContenedores = optenerDetalleContenedor();

        TMS_Solicitud_DetalleContenedores Entidad = new TMS_Solicitud_DetalleContenedores();
        Entidad.Prefijo = txtPrefijo.Text;
        Entidad.Numero = txtNumero.Text;
        if (chkCargaSuelta.Checked)
        {
            Entidad.Prefijo = "CARG";
            Entidad.Numero = "SUELTA" + (DetalleContenedores.Count + 1).ToString();
        }

        Entidad.Contenedor = Entidad.Prefijo + Entidad.Numero;
        string[] valores = ddlTipo2CTN.SelectedValue.Split('|');
        Entidad.Pies = Convert.ToInt32(valores[1]);
        Entidad.Tara = 0;
        Entidad.Peso = 0;
        Entidad.Precinto = "";
        Entidad.Tipo = valores[0];
        Entidad.Bultos = 19; // Contenedores
        Entidad.EsNuevo = (HFCodigo.Value == "0" ? true : false);
        Entidad.IDLocal1 = Convert.ToInt32(ddlLocal1.SelectedValue);
        Entidad.Local1 = ddlLocal1.SelectedItem.Text;
        Entidad.IDLocal2 = Convert.ToInt32(ddlLocal2.SelectedValue);
        Entidad.Local2 = ddlLocal2.SelectedItem.Text;
        Entidad.FechaCita = txtFechaCita.Text;
        Entidad.HoraCita = txtHoraCita.Text;
        Entidad.Transportista_ruc = ddlTransporte.SelectedValue;
        Entidad.Transportista = ddlTransporte.SelectedItem.Text;

        if (HFCodigo.Value != "0")
        {
            Entidad.ROAL = Convert.ToInt32(txtAL.Text);
            Entidad.Solicitud = Convert.ToInt32(txtNroSolicitud.Text);
        }

        var validarNroContnedor = DetalleContenedores.AsQueryable().Where(n => n.Contenedor == Entidad.Contenedor).ToList();
        var validarTotal = DetalleCarga.AsQueryable().Where(n => n.TipoCTN.Trim() == Entidad.Tipo & n.TipoPies == Entidad.Pies).ToList();

        if (validarTotal.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Debe ingresar el detalle de carga','Información');", true);
            return;
        }

        if (validarNroContnedor.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('El contenedor " + Entidad.Contenedor + " ya fue agregado.','Información');", true);
        }
        else
        {
            var validarCTN = DetalleContenedores.AsQueryable().Where(n => n.Tipo == Entidad.Tipo & n.Pies == Entidad.Pies).ToList();
            if (validarTotal[0].Cantidad <= validarCTN.Count())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Lo sentimos, el numero maximo de contenedores es de " + validarTotal[0].Cantidad + " para los de tipo: " + Entidad.Tipo + " y pies: " + Entidad.Pies.ToString() + "','Información');", true);
            }
            else
            {
                DetalleContenedores.Add(Entidad);
                GVDetalleSolicitud.DataSource = DetalleContenedores;
                GVDetalleSolicitud.DataBind();
            }

        }
    }
    protected void btnCancelarSolicitud_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    public bool validacion()
    {
        bool valor = true;
        if (ddlTipoSolicitud.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Seleccionar tipo de solicitud.','Información','danger');", true);
            valor = false;
        }
        if (ddlEmpresa.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Seleccionar Cliente.','Información','danger');", true);
            valor = false;
        }
        if (ddlCliente.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Seleccionar Sub-Cliente.','Información','danger');", true);
            valor = false;
        }
        if (ddlMovimiento.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Seleccionar tipo de movimiento.','Información','danger');", true);
            valor = false;
        }

        if (ddlCEmbarque.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Seleccionar condición de embarque.','Información','danger');", true);
            valor = false;
        }
        if (ddlPuerto.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Seleccionar terminal (recojo).','Información','danger');", true);
            valor = false;
        }

        if (gvDetalleServicios.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Se debe ingresar el detalle de total de contenedores para generar la solicitud.','Información','danger');", true);
            valor = false;
        }
        return valor;
    }
    protected void btnGuardarSolicitud_Click(object sender, EventArgs e)
    {
        bool validar = validacion();
        if (!validar)
            return;

        string usu = User.Identity.Name;
        int RO = 0;

        TMS_Solicitud sol = new TMS_Solicitud();
        sol.ROS_KRO = RO;
        sol.ROS_KItem = Convert.ToInt32(HFCodigo.Value);
        sol.ROS_KConcepto = "OTR";
        sol.ROS_Proveedor = "MERIDI";
        sol.ROS_TipoCheque = "4";
        sol.ROS_TipoSolicitud = "6";// ddlTipoSolicitud.SelectedValue;
        sol.ROS_Estado = ddlEstado.SelectedValue;
        sol.ROS_DiasDiferido = 0;
        sol.ROS_Observacion = txtObservacion.Text;
        sol.ROS_kdoc = 0;
        sol.ROS_Moneda = " ";
        sol.ROS_ObservacionAnulacion = " ";
        sol.ROS_FechaRendicion = "01/01/1900";
        sol.ROS_Ucre = usu;
        sol.ROS_Umod = usu;
        sol.ROS_TipSolTrans = Convert.ToInt32(ddlTipoSolicitud.SelectedValue);
        if (ddlEmpresa.SelectedValue == "MERIDI")
            sol.ROS_Clie = ddlCliente.SelectedValue;
        else
            sol.ROS_Clie = ddlEmpresa.SelectedValue;
        sol.ROS_Monto = 0.0;
        sol.ROS_Base = 0; //ddlBase.SelectedValue '2-CONTRANS
        sol.ROS_FechaProDesde = txtFechaSolicitud.Text;
        sol.ROS_FechaProHasta = txtFechaSolicitud.Text;

        TMS_RoutingOrder R = new TMS_RoutingOrder();

        R.TSER = "TTE";
        R.TVIA = "T";
        R.TMOV = ddlMovimiento.SelectedValue;
        R.CLIE = ddlCliente.SelectedValue;
        R.KEMP = ddlEmpresa.SelectedValue;
        R.LINE = "";
        R.ADUA = ddlAduana.SelectedValue;
        R.TERM = ddlTerminal.SelectedValue;
        R.PTO = ddlPuerto.SelectedValue;
        R.CEMB = ddlCEmbarque.SelectedValue;
        R.ICOT = ddlIncoterm.SelectedValue;
        R.COTI = 0;
        R.USER = usu;
        R.NAVE = "";
        R.NBL = txtBL.Text;
        R.NBKG = txtBKG.Text;
        R.REF = txtRef.Text;

        if (HFCodigo.Value == "0")
        {

            //'***********************************
            //'******++**** REGISTRAR ****++******
            //'***********************************
            //'Generando RoutingOrder
            DataTable dataRO = objTPL.Registrar_RO(R);
            RO = Convert.ToInt32(dataRO.Rows[0]["cod"]);//.Item(0).RO_Codi
            txtAL.Text = RO.ToString();
            sol.ROS_KRO = RO;

            //'Generando Solicitud en Antares
            DataTable dataSolicitud = objTPL.Registrar_Solicitud(sol);

            sol.ROS_KItem = Convert.ToInt32(dataSolicitud.Rows[0]["ROS_KItem"]);
            txtNroSolicitud.Text = sol.ROS_KItem.ToString();

            //'Generando la Solicitud en Transportes - Vista
            DataTable dataSolicitudTransporte = objTPL.Registrar_SolicitudTransporte(sol);

            //'Registrar Totales de Contenedores
            IList<TMS_Solicitud_DetalleCarga> DetalleCarga = optenerDetalleCarga();
            foreach (TMS_Solicitud_DetalleCarga carga in DetalleCarga)
            {
                int r1 = objTPL.Registrar_ROCarga("N", RO, carga.TipoBulto, carga.Cantidad, carga.TipoCTN, carga.TipoPies, carga.Monto, carga.Come, usu);
            }


            //'Registrar Contenedores  DetalleContenedores = New List(Of SolicitudTransporteCTN)
            IList<TMS_Solicitud_DetalleContenedores> DetalleContenedores = optenerDetalleContenedor();
            foreach (TMS_Solicitud_DetalleContenedores contenedor in DetalleContenedores)
            {
                TMS_SolicitudDetalle Carga = new TMS_SolicitudDetalle();

                Carga.TOPE = "N";
                Carga.Corr = RO;
                Carga.KItem = 0;// (Carga.TOPE == "E" || Carga.TOPE == "M" ? contenedor.Item : 0);

                Carga.Pies = contenedor.Pies;
                Carga.Pref = contenedor.Prefijo;

                Carga.Tipo = contenedor.Tipo;
                string bulto = (Carga.Pref == "CARG" ? "20" : "19");

                Carga.Nume = contenedor.Numero;

                Carga.Solicitud = 0;// (Carga.TOPE == "E" || Carga.TOPE == "M" ? contenedor.Item : 0);  //IIf(tope = "E" Or tope = "M", codSolicitud, 0)
                Carga.ContAnt = "";
                Carga.Ocom = "";
                Carga.Fcom = "";

                Carga.Peso = contenedor.Peso; //'peso del contenedor 00.0
                Carga.Upes = "KG"; //'unidad de medida del peso del contendor KG

                Carga.Vol = 0; //'volumen del contendor
                Carga.Uvol = ""; //'unidad de medida del volumen del contenedor
                Carga.Tara = contenedor.Tara; //'tara del contenedor
                Carga.Vent = 0;
                Carga.Temp = 0;
                Carga.UTemp = "";
                Carga.Prli = contenedor.Precinto;// ' "" 'precinto de línea
                Carga.Prem = "";// 'precinto de línea
                Carga.Prad = "";// 'precinto de embarcador
                Carga.Prte = "";// 'precinto de aduana
                Carga.Aten = "0";// 'Atención del Contenedor(1=Atendido, 0=No Atendido) - Por defecto 0?
                Carga.Tpaq = "";//
                Carga.Cpaq = 0;//

                Carga.Tmer = "";//
                Carga.Lent = contenedor.IDLocal1.ToString();//'local del cliente (numérico)
                Carga.Lent2 = (contenedor.IDLocal2 == 0 ? "" : contenedor.IDLocal2.ToString());//'Segundo local del cliente(numérico)

                Carga.Flle = Convert.ToDateTime(contenedor.FechaCita);// 'Convert.ToDateTime("01/01/1900")
                //Carga.Flle = Convert.ToDateTime("01/01/1900")
                Carga.Fent = Convert.ToDateTime("01/01/1900");
                Carga.HoraLlegada = Convert.ToDateTime(contenedor.HoraCita);
                //Carga.HoraLlegada = Convert.ToDateTime("01/01/1900"

                Carga.HoraEntrega = Convert.ToDateTime("01/01/1900");
                DateTime fchCitaTracking = Convert.ToDateTime(contenedor.FechaCita + " " + contenedor.HoraCita);
                Carga.Calm = "";
                Carga.Imo = "";
                Carga.Unno = "";
                Carga.Pgrp = "";
                Carga.Cnfl = "";
                Carga.Fcar = "";
                Carga.Plan = "";
                Carga.Transportista = contenedor.Transportista_ruc;
                Carga.Serv = "";
                Carga.DbCarga = (contenedor.IDLocal2 == 0 ? 0 : 1);  //'doble carga (1=habilita segundo local)
                Carga.User = User.Identity.Name;

                Carga.CarSuelta = (bulto == "20" ? true : false);

                int result = objTPL.Registrar_ROCargaContenedor(Carga);
                //int result  = objTPL.Registrar_ROCargaContenedor(entidad, CInt(txtNroSolicitud.Text), IIf(HFCodigo.Value = "0", "N", "M"), CInt(RO))

                if (Carga.KItem <= 0)
                {
                    Carga.KItem = objTPL.ObtenerKItem(Carga.Corr, Carga.Pies, Carga.Pref.Trim(), Carga.Nume.Trim());
                }


                //'Registro de contenedor en detalle de solicitud de transporte
                TMS_SolicitudTPLDetalle detalle = new TMS_SolicitudTPLDetalle();
                detalle.TOPE = "N";
                detalle.ROT_KRO = Convert.ToInt32(sol.ROS_KRO);
                detalle.ROT_KITEM = Convert.ToInt32(sol.ROS_KItem);
                detalle.ROT_ContenedorCodigo = Carga.Pref + Carga.Nume;
                detalle.ROT_ContenedorTipo = Carga.Tipo;
                detalle.ROT_ContenedorPies = Carga.Pies;
                detalle.User = User.Identity.Name;
                detalle.ROT_Item = Carga.KItem;
                objTPL.Registrar_SolicitudTransporteContenedor(detalle);


                objTPL.Registrar_ROSeguimientoBasico(RO, Carga.KItem, R.TMOV, Convert.ToInt32(sol.ROS_KItem), Convert.ToInt32(sol.ROS_TipSolTrans),
                                                     Carga.Pref + Carga.Nume, Carga.Tipo, Carga.Pies, 0, 0, 0, R.TERM, Convert.ToDateTime(Carga.Flle.ToShortDateString()),
                                                     (Carga.Lent == "" ? "" : R.CLIE), (Carga.Lent == "" ? 0 : Convert.ToInt32(Carga.Lent)), fchCitaTracking,
                                                     (Carga.Lent2 == "" ? "" : R.CLIE), (Carga.Lent2 == "" ? 0 : Convert.ToInt32(Carga.Lent2)), R.PTO, User.Identity.Name);
                //    //'Registrar(Seguimiento)
                //If Not String.IsNullOrEmpty(contenedor.Transportista) Or Not String.IsNullOrEmpty(contenedor.Transportista_ruc) Or Not String.IsNullOrEmpty(contenedor.Chofer) Or _
                //        Not String.IsNullOrEmpty(contenedor.Brevete) Or Not String.IsNullOrEmpty(contenedor.Placa) Then

                //        Dim Pref As String = Left(entidad.NroContenedor, 4)
                //        Dim Nume As String = IIf(entidad.NroContenedor.Length > 4, Right(entidad.NroContenedor, entidad.NroContenedor.Length - 4), "")

                //        Dim KTIM As Integer = _BLLTpl.OptenerKItemContendorTPL(CInt(RO), contenedor.Pies, Pref, Nume)
                //        Dim Cod_Unid As Integer = _BLLTpl.OptenerCodUnid(contenedor.Placa)
                //        Dim Cod_Chofer As Integer = _BLLTpl.OptenerCodChofer(contenedor.Brevete)
                //        Dim Cod_Transporte As Integer = _BLLTpl.OptenerCodTransporte(contenedor.Placa)

                //        _lgOperaciones.Proceso_SeguimientoOperativo_ImportacionContrans(CInt(RO), KTIM, R.TMOV, CInt(txtNroSolicitud.Text), sol.ROS_TipoSolicitud, Cod_Unid, Cod_Chofer, Cod_Transporte, usu, IIf(ddlMovimiento.SelectedValue = "E", R.PTO, R.TERM), IIf(ddlMovimiento.SelectedValue = "I", R.PTO, R.TERM))

                //    End If


            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Se genero el AL" + txtAL.Text + " con éxito.','Información','success');", true);


        }
        else
        {

            //'***********************************
            //'*****++**** ACTUALIZAR ****++******
            //'***********************************
            //RO = CInt(txtAL.Text.Trim)
            //'Actualizar RO
            //R.RO_Codi = RO
            //_BLRoutingOrder.ActualizarRoutingOrder(R)


            //'Actualizando Solicitud en Antares
            //sol.ROS_KRO = RO
            //_BLSolicitud.ActualizarSolicitud(sol)

            //'Generando la Solicitud en Transportes - Vista
            //_BLSolicitud.RegistrarSolTranTOMSol(sol)


            //'Eliminando Totales
            //lgSolicitudTransTPL.MantenimientoTotalContenedores_TPL("A", RO, "", 0, "", 0, 0, "", usu)

            //'Registrar Totales de Contenedores
            //For Each total As solicitudTransporteTotalDetalleCE In DetalleTotalTransporte
            //    lgSolicitudTransTPL.MantenimientoTotalContenedores_TPL("N", RO, total.TipoBulto, total.Cantidad, total.TipoCTN, total.TipoPies, total.Monto, total.Come, usu)
            //Next


            //'Eliminando Contenedores
            //For Each contenedor As SolicitudTransporteCTN In DetalleContenedoresEliminar
            //    'Registro de Contenedor en TPL
            //    Dim entidad As New solicitudTransporteDetalleCE
            //    entidad.NroContenedor = contenedor.Contenedor
            //    entidad.TipContenedor = contenedor.Tipo
            //    entidad.TamContenedor = contenedor.Pies
            //    entidad.FechaCita = CDate("01/01/1990")
            //    entidad.Usuario.Usuario = User.Identity.Name
            //    entidad.Item = IIf(HFCodigo.Value = "0", 0, contenedor.Item)
            //    Dim result As Integer = _BLLTpl.RegistrarContenedoresSolicitudTransporteTPL(entidad, CInt(txtNroSolicitud.Text), "E", CInt(RO))
            //Next

            //'Registrar Contenedores
            //For Each contenedor As SolicitudTransporteCTN In DetalleContenedores
            //    Dim entidad As New solicitudTransporteDetalleCE
            //    entidad.NroContenedor = contenedor.Contenedor
            //    entidad.TipContenedor = contenedor.Tipo
            //    entidad.TamContenedor = contenedor.Pies
            //    entidad.FechaCita = CDate("01/01/1990")
            //    entidad.Usuario.Usuario = User.Identity.Name
            //    entidad.Item = IIf(HFCodigo.Value = "0", 0, contenedor.Item)

            //    'Agregado
            //    entidad.Prte = contenedor.Precinto
            //    entidad.Tara = contenedor.Tara
            //    entidad.Peso = contenedor.Peso

            //    If contenedor.Item = 0 Then
            //        'Registro de Contenedor en TPL
            //        Dim result As Integer = _BLLTpl.RegistrarContenedoresSolicitudTransporteTPL(entidad, CInt(txtNroSolicitud.Text), "N", CInt(RO))
            //        'Registro de contenedor en detalle de solicitud de transporte
            //        _BLLTpl.RegistrarContenedorSolicitudTransporte(entidad, CInt(sol.ROS_KItem), "N", CInt(RO))
            //    Else
            //        'Registro de Contenedor en Solicitud Transportes
            //        Dim result As Integer = _BLLTpl.RegistrarContenedoresSolicitudTransporteTPL(entidad, CInt(txtNroSolicitud.Text), "M", CInt(RO))
            //    End If

            //    'Registrar Seguimiento
            //    If Not String.IsNullOrEmpty(contenedor.Transportista) Or Not String.IsNullOrEmpty(contenedor.Transportista_ruc) Or Not String.IsNullOrEmpty(contenedor.Chofer) Or _
            //        Not String.IsNullOrEmpty(contenedor.Brevete) Or Not String.IsNullOrEmpty(contenedor.Placa) Then

            //        Dim Pref As String = Left(entidad.NroContenedor, 4)
            //        Dim Nume As String = IIf(entidad.NroContenedor.Length > 4, Right(entidad.NroContenedor, entidad.NroContenedor.Length - 4), "")

            //        Dim KTIM As Integer = _BLLTpl.OptenerKItemContendorTPL(CInt(RO), contenedor.Pies, Pref, Nume)
            //        Dim Cod_Unid As Integer = _BLLTpl.OptenerCodUnid(contenedor.Placa)
            //        Dim Cod_Chofer As Integer = _BLLTpl.OptenerCodChofer(contenedor.Brevete)
            //        Dim Cod_Transporte As Integer = _BLLTpl.OptenerCodTransporte(contenedor.Placa)

            //        _lgOperaciones.Proceso_SeguimientoOperativo_ImportacionContrans(CInt(RO), KTIM, R.TMOV, CInt(txtNroSolicitud.Text), sol.ROS_TipoSolicitud, Cod_Unid, Cod_Chofer, Cod_Transporte, usu, IIf(ddlMovimiento.SelectedValue = "E", R.PTO, R.TERM), IIf(ddlMovimiento.SelectedValue = "I", R.PTO, R.TERM))

            //    End If

            //Next

        }

        MultiView1.ActiveViewIndex = 0;
        cargarSolicitudTransporte();

    }
    void anular()
    {
        int pItem, pRo;
        string pUsuario = "";
        pUsuario = User.Identity.Name;
        foreach (GridViewRow row in GVPlaneamiento.Rows)
        {
            if (((CheckBox)row.FindControl("Checkbox1")).Checked)
            {
                pItem = Convert.ToInt32(((LinkButton)(row.FindControl("lkSolDistrib"))).Text);
                pRo = Convert.ToInt32(row.Cells[3].Text);
                TMS_Solicitud Sol = new TMS_Solicitud();
                Sol.ROS_KRO = pRo;
                Sol.ROS_KItem = pItem;

                objTPL.Anular_SolictudRO(Sol);
            }

        }

        cargarSolicitudTransporte();

    }


    protected void btnAnularSolicitud_Click(object sender, EventArgs e)
    {
        anular();
    }

    protected void GVPlaneamiento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Editar":
                Editar(e.CommandArgument.ToString());
                break;
        }
    }

    void Editar(string Codigo)
    {
        Limpiar();
        btnImportarCTN.Visible = true;
        string[] valores = Codigo.Split('|');

        TMS_Solicitud sol = new TMS_Solicitud();
        sol.ROS_KItem = Convert.ToDouble(valores[0]);
        sol.ROS_KRO = Convert.ToDouble(valores[1]); //'HFRO.Value
        sol.ROS_FCreDesde = "01/01/1900";
        sol.ROS_FCreHasta = "01/01/1900";
        sol.ROS_TipSolTrans = 0;// Convert.ToDouble( valores[2]);
        sol.ROS_Estado = "A";
        sol.ROS_Clie = "*";

        //    Dim lst = _BLSolicitud.GetSolicitudOperativo(sol)
        //    If lst.Count > 0 Then
        //        Dim Solicitud = lst.First()

        //        'Listando data de la Solicitud
        //        txtAL.Text = Solicitud.ROS_KRO
        //        txtNroSolicitud.Text = Solicitud.ROS_KItem
        //        ddlTipoSolicitud.SelectedValue = Solicitud.ROS_TipSolTrans

        //        ddlEstado.SelectedValue = Solicitud.ROS_Estado
        //        txtFechaSolicitud.Text = CDate(Solicitud.ROS_FechaProDesde).ToShortDateString()
        //        txtObservacion.Text = Solicitud.ROS_Observacion
        //        HFCodigo.Value = Solicitud.ROS_KItem

        //        'Listando datos del RO
        //        Dim RO_Entidad As RoutingOrder = _BLRoutingOrder.ObtenerRoutingOrder(Solicitud.ROS_KRO).First()
        //        ddlEmpresa.SelectedValue = RO_Entidad.CLIE
        //        If Not ddlTerminal.Items.FindByValue(RO_Entidad.TERM) Is Nothing Then
        //            ddlTerminal.SelectedValue = RO_Entidad.TERM
        //        End If

        //        If Not Me.ddlPuerto.Items.FindByValue(RO_Entidad.PTO) Is Nothing Then
        //            ddlPuerto.SelectedValue = RO_Entidad.PTO
        //        End If

        //        ddlMovimiento.SelectedValue = RO_Entidad.TMOV

        //        txtBKL.Text = IIf(ddlMovimiento.SelectedValue = "E", RO_Entidad.NBKG, RO_Entidad.NBL)

        //        'Listar total de contenedores
        //        DetalleTotalTransporte = _BLRoutingOrder.TotalDetalleContenedores(Solicitud.ROS_KRO)
        //        gvDetalleServicios.DataSource = DetalleTotalTransporte
        //        gvDetalleServicios.DataBind()


        //        'Listar contenedores
        //        Dim tabla As DataTable = Me._BLLTipoCTN.Listar_Contenedores(Solicitud.ROS_KRO) ' _lgOperaciones.GetContenedores(Solicitud.ROS_KItem).Tables(0)

        //        For Each fila As DataRow In tabla.Rows
        //            Dim rowCTN As New SolicitudTransporteCTN
        //            rowCTN.EsNuevo = True
        //            rowCTN.Solicitud = fila("Solicitud")
        //            rowCTN.ROAL = Solicitud.ROS_KRO
        //            rowCTN.Contenedor = fila("Bic_Pref").ToString().Trim() & fila("Bic_Nume").ToString().Trim()
        //            rowCTN.Item = fila("Bic_Kitem").ToString().Trim()
        //            rowCTN.Pies = fila("Bic_Pies").ToString().Trim()
        //            rowCTN.Tipo = fila("Bic_Tcnt").ToString().Trim()

        //            rowCTN.Peso = fila("Bic_Peso")
        //            rowCTN.Tara = fila("Bic_Tara")
        //            rowCTN.Pyload = 0 ' fila(8)
        //            rowCTN.Precinto = IIf(fila("Bic_PrLi") Is DBNull.Value, "", fila("Bic_PrLi"))

        //            'rowCTN.FechaCita = fila(9)
        //            'rowCTN.HoraCita = fila(10)
        //            'rowCTN.Placa = fila(11)
        //            'rowCTN.Evento = fila(12)
        //            'rowCTN.dbCarga = fila(13)
        //            'rowCTN.Servicio = fila(14)

        //            DetalleContenedores.Add(rowCTN)
        //        Next

        //        GVDetalleSolicitud.DataSource = DetalleContenedores
        //        GVDetalleSolicitud.DataBind()

        //        MultiView1.ActiveViewIndex = 1
        //    Else
        //        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "aler0099", "JAlertShow('Información','No se encontro información para esta solicitud.');", True)

        //    End If

        //    GVDetalleSolicitud.Columns(8).Visible = True


    }

    protected void gvDetalleServicios_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        switch (e.CommandName.ToString())
        {
            case "eliminar":

                IList<TMS_Solicitud_DetalleCarga> DetalleCarga = optenerDetalleCarga();
                int pos = Convert.ToInt32(e.CommandArgument);
                DetalleCarga.RemoveAt(pos);
                gvDetalleServicios.DataSource = DetalleCarga;
                gvDetalleServicios.DataBind();

                break;
        }
    }

    protected void GVDetalleSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        switch (e.CommandName.ToString())
        {
            case "eliminar":

                IList<TMS_Solicitud_DetalleContenedores> DetalleContenedores = optenerDetalleContenedor();
                int pos = Convert.ToInt32(e.CommandArgument);
                DetalleContenedores.RemoveAt(pos);
                GVDetalleSolicitud.DataSource = DetalleContenedores;
                GVDetalleSolicitud.DataBind();

                break;
        }
    }

    protected void btnImportarCTN_Click(object sender, EventArgs e)
    {
        setTabs();
        li1.Attributes.Add("class", "first current");
        li1.Attributes.Add("class", "active");
        MultiView2.ActiveViewIndex = 0;

        txtNroVolante.Text = "";
        txtAnno.Text = "";
        txtNunManifiesto.Text = "";
        ddlMovimientoIntegracion.SelectedIndex = 0;
        txtRumbo.Text = "";
        txtViaje.Text = "";

        chkAsignacionMasiva.Checked = false;
        ddlLocal1Masivo.SelectedIndex = 0;
        ddlLocal2Masivo.SelectedIndex = 0;

        gvContenedoresContrans.DataSource = null;
        gvContenedoresContrans.DataBind();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalImportarContenedor').modal('show');", true);
    }

    protected void btnBuscarContenedor_Click(object sender, EventArgs e)
    {


        gvContenedoresContrans.DataSource = objTPL.ExportarCTN_Contrans_Integral(txtNroVolante.Text);
        gvContenedoresContrans.DataBind();

        foreach (GridViewRow row in gvContenedoresContrans.Rows)
        {
            DropDownList local1 = (DropDownList)row.FindControl("ddlLocal1");
            DropDownList local2 = (DropDownList)row.FindControl("ddlLocal2");
            string cliente = ddlCliente.SelectedValue;

            local1.DataSource = objTPL.ListarLocales(cliente);
            local1.DataTextField = "DIRECCION";
            local1.DataValueField = "LOCAL_CODIGO";
            local1.DataBind();
            local1.Items.Insert(0, new ListItem("[Sin Especificar]", "0"));

            if (local1.Items.Count > 0)
            {
                if (local1.Items[1].Value.ToString().Trim() == "0")
                {
                    local1.Items.RemoveAt(1);
                }

            }

            local2.DataSource = objTPL.ListarLocales(cliente);
            local2.DataTextField = "DIRECCION";
            local2.DataValueField = "LOCAL_CODIGO";
            local2.DataBind();
            local2.Items.Insert(0, new ListItem("[Sin Especificar]", "0"));

            if (local2.Items.Count > 0)
            {
                if (local2.Items[1].Value.ToString().Trim() == "0")
                {
                    local2.Items.RemoveAt(1);
                }

            }

        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalImportarContenedor').modal('show');", true);
    }

    protected void gvContenedoresContrans_PreRender(object sender, EventArgs e)
    {
        Prerender(gvContenedoresContrans);
    }

    protected void btnTab1_Click(object sender, EventArgs e)
    {
        setTabs();
        li1.Attributes.Add("class", "first current");
        li1.Attributes.Add("class", "active");
        MultiView2.ActiveViewIndex = 0;

        chkAsignacionMasiva.Enabled = false;
        ddlLocal1Masivo.SelectedIndex = 0;
        ddlLocal1Masivo.Enabled = false;
        ddlLocal2Masivo.SelectedIndex = 0;
        ddlLocal2Masivo.Enabled = false;

        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalImportarContenedor').modal('show');", true);
    }
    public void setTabs()
    {
        li1.Attributes.Add("class", "");
        li2.Attributes.Add("class", "");
        li3.Attributes.Add("class", "");


    }

    protected void btnTab2_Click(object sender, EventArgs e)
    {
        setTabs();
        li2.Attributes.Add("class", "first current");
        li2.Attributes.Add("class", "active");
        MultiView2.ActiveViewIndex = 1;

        chkAsignacionMasiva.Enabled = false;
        ddlLocal1Masivo.SelectedIndex = 0;
        ddlLocal1Masivo.Enabled = false;
        ddlLocal2Masivo.SelectedIndex = 0;
        ddlLocal2Masivo.Enabled = false;

        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalImportarContenedor').modal('show');", true);
    }

    protected void btnTab3_Click(object sender, EventArgs e)
    {

        setTabs();
        li3.Attributes.Add("class", "first current");
        li3.Attributes.Add("class", "active");

        MultiView2.ActiveViewIndex = 2;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalImportarContenedor').modal('show');", true);
    }

    public static bool IsDate(Object obj)
    {
        string strDate = obj.ToString();
        try
        {
            DateTime dt = DateTime.Parse(strDate);
            //if ((dt.Month != System.DateTime.Now.Month) || (dt.Day < 1 && dt.Day > 31) || dt.Year != System.DateTime.Now.Year)
            // return false;
            //else
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void btnImportarExcel_Click(object sender, EventArgs e)
    {
        if (FU_ExcelContenedores.HasFile)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("CONTENEDOR");
            dt.Columns.Add("PRECINTO");
            dt.Columns.Add("TARA");
            dt.Columns.Add("SIZE_CTN");
            dt.Columns.Add("TIPO_CTN");
            dt.Columns.Add("BULTOS");
            dt.Columns.Add("PESO_NETO");
            dt.Columns.Add("PESO_BRUTO");
            dt.Columns.Add("PROV_TRANSPORTE");
            dt.Columns.Add("RUC_TRANSPORTE");
            dt.Columns.Add("PLACA_VEHICULO");
            dt.Columns.Add("CHOFER");
            dt.Columns.Add("BREVETE");
            dt.Columns.Add("FECHA");

            DataTable ds = new DataTable();
            string FileName = Path.GetFileName(FU_ExcelContenedores.PostedFile.FileName);
            string Extension = Path.GetExtension(FU_ExcelContenedores.PostedFile.FileName);
            string FolderPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];

            string FilePath = Server.MapPath(FolderPath + FileName);
            FU_ExcelContenedores.SaveAs(FilePath);
            ds = Util.Import_To_Grid(FilePath, Extension, "Yes");

            if (ds.Rows.Count > 0)
            {
                //IList<TMS_Solicitud_DetalleContenedores> DetalleContenedores = optenerDetalleContenedor();
                foreach (DataRow row in ds.Rows)
                {
                    if (row["Contenedor"] == null)
                        continue;
                    if (row["Contenedor"].ToString().Trim().Length < 11)
                        continue;

                    if (row["Tipo"] == null)
                        continue;
                    if (row["Tipo"].ToString().Trim().Length != 4)
                        continue;

                    if (row["FechaCita"] == null)
                        continue;
                    if (!IsDate(row["FechaCita"]))
                        continue;

                    if (row["HoraCita"] == null)
                        continue;
                    if (!IsDate(row["HoraCita"]))
                        continue;


                    DataRow r = dt.NewRow();
                    r["CONTENEDOR"] = row["Contenedor"].ToString().Trim();
                    r["PRECINTO"] = "";
                    r["TARA"] = "";
                    r["SIZE_CTN"] = row["Tipo"].ToString().Substring(0, 2);
                    r["TIPO_CTN"] = row["Tipo"].ToString().Substring(2, 2);
                    r["BULTOS"] = "";
                    r["PESO_NETO"] = "0";
                    r["PESO_BRUTO"] = "0";
                    r["PROV_TRANSPORTE"] = "";
                    r["RUC_TRANSPORTE"] = "";
                    r["PLACA_VEHICULO"] = "";
                    r["CHOFER"] = "";
                    r["BREVETE"] = "";
                    r["FECHA"] = Convert.ToDateTime(row["FechaCita"]).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row["HoraCita"]).ToString("HH:mm:ss");
                    dt.Rows.Add(r);
                }
                dt.AcceptChanges();
                gvContenedoresContrans.DataSource = dt;
                gvContenedoresContrans.DataBind();
                string cliente = ddlCliente.SelectedValue;
                DataTable dataLocales = objTPL.ListarLocales(cliente);
                foreach (GridViewRow row in gvContenedoresContrans.Rows)
                {
                    DropDownList local1 = (DropDownList)row.FindControl("ddlLocal1");
                    DropDownList local2 = (DropDownList)row.FindControl("ddlLocal2");

                    TextBox txtFechaCita = (TextBox)row.FindControl("txtFechaCita");
                    TextBox txtHoraCita = (TextBox)row.FindControl("txtHoraCita");

                    string strFecha = ((Label)row.FindControl("lblFecha")).Text.Trim();
                    txtFechaCita.Text = Convert.ToDateTime(strFecha).ToString("dd/MM/yyyy");

                    int hora = Convert.ToInt32(Convert.ToDateTime(strFecha).ToString("HH"));
                    if (hora > 11 && hora < 23)
                        txtHoraCita.Text = Convert.ToDateTime(strFecha).ToString("hh:mm") + " PM";
                    else
                        txtHoraCita.Text = Convert.ToDateTime(strFecha).ToString("hh:mm") + " AM";

                    local1.DataSource = dataLocales;
                    local1.DataTextField = "DIRECCION";
                    local1.DataValueField = "LOCAL_CODIGO";
                    local1.DataBind();
                    local1.Items.Insert(0, new ListItem("[Sin Especificar]", "0"));

                    if (local1.Items.Count > 0)
                    {
                        if (local1.Items[1].Value.ToString().Trim() == "0")
                        {
                            local1.Items.RemoveAt(1);
                        }

                    }

                    local2.DataSource = dataLocales;
                    local2.DataTextField = "DIRECCION";
                    local2.DataValueField = "LOCAL_CODIGO";
                    local2.DataBind();
                    local2.Items.Insert(0, new ListItem("[Sin Especificar]", "0"));

                    if (local2.Items.Count > 0)
                    {
                        if (local2.Items[1].Value.ToString().Trim() == "0")
                        {
                            local2.Items.RemoveAt(1);
                        }

                    }

                }

                chkAsignacionMasiva.Enabled = true;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalImportarContenedor').modal('show');", true);

            }

        }
    }

    protected void btnBuscarContenedor_Operativo_Click(object sender, EventArgs e)
    {

        gvContenedoresContrans.DataSource = objTPL.ExportarCTN_Contrans_Operativo(Convert.ToInt32(txtAnno.Text), Convert.ToInt32(txtNunManifiesto.Text), ddlMovimientoIntegracion.SelectedValue, txtViaje.Text, txtRumbo.Text);
        gvContenedoresContrans.DataBind();

        foreach (GridViewRow row in gvContenedoresContrans.Rows)
        {
            DropDownList local1 = (DropDownList)row.FindControl("ddlLocal1");
            DropDownList local2 = (DropDownList)row.FindControl("ddlLocal2");
            string cliente = ddlCliente.SelectedValue;

            local1.DataSource = objTPL.ListarLocales(cliente);
            local1.DataTextField = "DIRECCION";
            local1.DataValueField = "LOCAL_CODIGO";
            local1.DataBind();
            local1.Items.Insert(0, new ListItem("[Sin Especificar]", "0"));

            if (local1.Items.Count > 0)
            {
                if (local1.Items[1].Value.ToString().Trim() == "0")
                {
                    local1.Items.RemoveAt(1);
                }

            }

            local2.DataSource = objTPL.ListarLocales(cliente);
            local2.DataTextField = "DIRECCION";
            local2.DataValueField = "LOCAL_CODIGO";
            local2.DataBind();
            local2.Items.Insert(0, new ListItem("[Sin Especificar]", "0"));

            if (local2.Items.Count > 0)
            {
                if (local2.Items[1].Value.ToString().Trim() == "0")
                {
                    local2.Items.RemoveAt(1);
                }

            }

        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalImportarContenedor').modal('show');", true);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        bool proceso = false;
        if (gvContenedoresContrans.Rows.Count > 0)
        {
            IList<TMS_Solicitud_DetalleContenedores> DetalleContenedores = optenerDetalleContenedor();
            foreach (GridViewRow row in gvContenedoresContrans.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("chkSeleccionar");
                DropDownList Local1 = (DropDownList)row.FindControl("ddlLocal1");
                DropDownList Local2 = (DropDownList)row.FindControl("ddlLocal2");

                if (check.Checked)
                {
                    TMS_Solicitud_DetalleContenedores Entidad = new TMS_Solicitud_DetalleContenedores();
                    Entidad.Contenedor = ((Label)row.FindControl("lblContenedor")).Text;
                    Entidad.Prefijo = Entidad.Contenedor.Substring(0, 4);
                    Entidad.Numero = Entidad.Contenedor.Replace(Entidad.Prefijo, "");
                    //if (chkCargaSuelta.Checked)
                    //{
                    //    Entidad.Prefijo = "CARG";
                    //    Entidad.Numero = "SUELTA" + (DetalleContenedores.Count + 1).ToString();
                    //}
                    string[] valores = ddlTipo2CTN.SelectedValue.Split('|');
                    Entidad.Pies = Convert.ToInt32(((Label)row.FindControl("lblPies")).Text.ToLower().Replace("pies", "").Trim());
                    Entidad.Tara = 0;
                    Entidad.Peso = 0;
                    Entidad.Precinto = "";
                    Entidad.Tipo = ((Label)row.FindControl("lblTipo")).Text;
                    Entidad.Bultos = 19; // Contenedores
                    Entidad.EsNuevo = (HFCodigo.Value == "0" ? true : false);

                    if (chkAsignacionMasiva.Checked)
                    {
                        Entidad.IDLocal1 = Convert.ToInt32(ddlLocal1Masivo.SelectedValue);
                        Entidad.Local1 = ddlLocal1Masivo.SelectedItem.Text;
                        Entidad.IDLocal2 = Convert.ToInt32(ddlLocal2Masivo.SelectedValue);
                        Entidad.Local2 = ddlLocal2Masivo.SelectedItem.Text;
                    }
                    else
                    {
                        Entidad.IDLocal1 = Convert.ToInt32(Local1.SelectedValue);
                        Entidad.Local1 = Local1.SelectedItem.Text;
                        Entidad.IDLocal2 = Convert.ToInt32(Local2.SelectedValue);
                        Entidad.Local2 = Local2.SelectedItem.Text;
                    }

                    Entidad.FechaCita = ((TextBox)row.FindControl("txtFechaCita")).Text;
                    Entidad.HoraCita = ((TextBox)row.FindControl("txtHoraCita")).Text;

                    Entidad.Transportista_ruc = "88";//ddlTransporte.SelectedValue;
                    Entidad.Transportista = "TRANSPORTES MERIDIAN S.A.C.";// ddlTransporte.SelectedItem.Text;

                    //if (Entidad.FechaCita == "")
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('" + Entidad.Contenedor + ": fecha de cita es incorecta.','Información','danger'); $('#modalImportarContenedor').modal('show');", true);
                    //    break;
                    //}
                    //if (Entidad.HoraCita == "")
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('" + Entidad.Contenedor + ": fecha de cita es incorecta.','Información','danger'); $('#modalImportarContenedor').modal('show');", true);
                    //    break;
                    //}


                    DateTime dateValue;
                    if (!DateTime.TryParse(Entidad.FechaCita, out dateValue))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('" + Entidad.Contenedor + ": fecha de cita es incorecta.','Información','danger'); $('#modalImportarContenedor').modal('show');", true);
                        break;
                    }

                    DateTime dateValue2;
                    if (!DateTime.TryParse(Entidad.HoraCita, out dateValue2))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('" + Entidad.Contenedor + ": hora de cita es incorecta.','Información','danger'); $('#modalImportarContenedor').modal('show');", true);
                        break;
                    }

                    proceso = true;
                    DetalleContenedores.Add(Entidad);
                }
            }

            if (proceso)
            {
                GVDetalleSolicitud.DataSource = DetalleContenedores;
                GVDetalleSolicitud.DataBind();


                IList<TMS_Solicitud_DetalleCarga> DetalleCarga = new List<TMS_Solicitud_DetalleCarga>(); //optenerDetalleCarga();
                var validarTotal = DetalleContenedores.AsQueryable().Select(t => new { Tipo = t.Tipo, Pies = t.Pies }).Distinct();
                foreach (var carga in validarTotal)
                {
                    var validarCantidad = DetalleContenedores.AsQueryable().Where(n => n.Tipo == carga.Tipo & n.Pies == carga.Pies).ToList();

                    TMS_Solicitud_DetalleCarga entidad = new TMS_Solicitud_DetalleCarga();
                    entidad.Cantidad = validarCantidad.Count;
                    entidad.TipoPies = carga.Pies;
                    entidad.TipoCTN = carga.Tipo;
                    entidad.TipoBulto = "19";
                    entidad.Monto = 0;
                    entidad.Come = "";
                    DetalleCarga.Add(entidad);
                }
                gvDetalleServicios.DataSource = DetalleCarga;
                gvDetalleServicios.DataBind();

            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Debe seleccionar uno o más contenedores.','Información','danger');", true);

        }
    }

    protected void btnAgregarSeguimiento_Click(object sender, EventArgs e)
    {
        int flag = 0, soloDis = 0;
        IList<string> RowData_AL = new List<string>();
        lblMensaje.Value = "";
        string msjError = "";
        string pRO = "", pSolicitud = "", pEntidad = "", pSeguimiento = "";
        foreach (GridViewRow gvrAL in GVPlaneamiento.Rows)
        {
            CheckBox chkSelected = (CheckBox)gvrAL.FindControl("CheckBox1");
            LinkButton hplSolicitud = (LinkButton)gvrAL.FindControl("hplSolicitud");
            Label lblTipoSol = (Label)gvrAL.FindControl("lblTipoSol");

            if (chkSelected.Checked == true)
            {
                flag += 1;

                pRO = gvrAL.Cells[3].Text + "," + pRO;
                pSolicitud = hplSolicitud.Text + "," + pSolicitud;
                pEntidad = gvrAL.Cells[4].Text;
                if (lblTipoSol.Text == "Distribución")
                    soloDis = 1;

                string[] arr = hplSolicitud.CommandArgument.ToString().Split('|');
                Session["Movimiento"] = gvrAL.Cells[5].Text;
                RowData_AL.Add(arr[0]);
            }
            else //if(chkSelected.Checked==false)
            {
                if (flag > 1)
                {
                    lblMensaje.Value = "Para agregar seguimiento a una solicitud de tipo distribucion, la debe realizar una a la vez";
                    break;
                }
            }
            if (gvrAL.Cells[9].Text == "Pendiente")
            {
                lblMensaje.Value = "Las Solicitudes deben de estar en estado Recepcionado o Asignado";
            }

            //End If/for
        }
        if (RowData_AL.Count() == 0)
        {
            if (msjError == "")
                MostrarMensaje(2, "Debe seleccionar 1 o más filas");
            else
                MostrarMensaje(1, msjError);
        }
        else
        {

            lblentidad0.Value = pEntidad;
            if (pRO == "" || pSolicitud == "")
            {

                lblMensaje.Value = "Elija una Solicitud";

            }
            //Session["pRO"] = pRO.Substring(0, pRO.Length - 1);
            //Session["pSolicitud"] = pSolicitud.Substring(0, pSolicitud.Length - 1);
            //Session["pEntidad"] = lblentidad0.Value.ToString();
            Session["VALOR"] = 1;

            if (soloDis == 1)
                MostrarMensaje(1, "Comunicarse con Sistemas.");
            else
                Response.Redirect("SeguimientoTransportes.aspx?AL=" + pRO.Substring(0, pRO.Length - 1) +
                                                             // "&Mov=" + ddlMovimientoFiltro.SelectedValue.ToString() + 
                                                             // "&Enti=" + pEntidad + 
                                                             "&Soli=" + pSolicitud.Substring(0, pSolicitud.Length - 1));
        }

    }

    public void MostrarMensaje(int error, string mensaje)
    {
        if (error == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert_" + DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('" + mensaje + "','Ok','success');", true);
        }
        else if (error == 2)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert_" + DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('" + mensaje + "','Información','warning');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert_" + DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('" + mensaje + "','Error','danger');", true);
        }
    }

    protected void btnProgramacion_Click(object sender, EventArgs e)
    {
        string msjError = "";
        IList<string> RowData_AL = new List<string>();
        foreach (GridViewRow gvrAL in GVPlaneamiento.Rows)
        {
            CheckBox chkSelected = (CheckBox)gvrAL.FindControl("CheckBox1");
            LinkButton hplSolicitud = (LinkButton)gvrAL.FindControl("hplSolicitud");
            Label lblTipoSol = (Label)gvrAL.FindControl("lblTipoSol");

            if (chkSelected.Checked == true)
            {
                //if (gvrAL.Cells[7].Text != "Pendiente")
                //    msjError = "Las Solicitudes deben de estar en estado Recepcionado";
                //else
                //{
                string[] arr = hplSolicitud.CommandArgument.ToString().Split('|');
                RowData_AL.Add(arr[0]);
                //}
            }
        }


        if (RowData_AL.Count() == 0)
        {
            if (msjError == "")
                MostrarMensaje(2, "Debe seleccionar 1 o más filas");
            else
                MostrarMensaje(1, msjError);
        }
        else
        {
            MultiView1.ActiveViewIndex = 2;
            HFNroSolicitud.Value = string.Join(",", RowData_AL.ToArray());
            CargarContenedores();
        }
    }

    public void CargarContenedores()
    {
        DataTable dataContenedores = objTPL.Programacion_ListarContenedores(HFNroSolicitud.Value);
        gvProgramacion.DataSource = dataContenedores;
        gvProgramacion.DataBind();

        foreach (GridViewRow row in gvProgramacion.Rows)
        {
            DropDownList ddlEmpresaTransporte = (DropDownList)row.FindControl("ddlEmpresaTransporte");
            DropDownList ddlConductor = (DropDownList)row.FindControl("ddlConductor");
            DropDownList ddlUnidad = (DropDownList)row.FindControl("ddlUnidad");
            TextBox txtConductor = (TextBox)row.FindControl("txtConductor");
            TextBox txtConductor_id = (TextBox)row.FindControl("txtConductor_id");
            TextBox txtUnidad = (TextBox)row.FindControl("txtUnidad");
            TextBox txtUnidad_id = (TextBox)row.FindControl("txtUnidad_id");

            string IDPlaca = ((Label)row.FindControl("IDPlaca")).Text;
            string Placa = ((Label)row.FindControl("Placa")).Text;
            string IDConductor = ((Label)row.FindControl("Conductor")).Text;
            string DNIConductor = ((Label)row.FindControl("DNI_Conductor")).Text;
            string IDTransporte = ((Label)row.FindControl("Transporte")).Text;

            TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
            TMS_SeguimientoEL SeguimientoEL = new TMS_SeguimientoEL();

            ddlEmpresaTransporte.DataSource = oSeguimiento.GetEmpresaTransporte();
            ddlEmpresaTransporte.DataTextField = "EMPRETRANS_RAZONSOCIAL";
            ddlEmpresaTransporte.DataValueField = "EMPRETRANS_CODIGO";
            ddlEmpresaTransporte.DataBind();

            if (IDTransporte == "0")
                ddlEmpresaTransporte.SelectedValue = "88";
            else
                ddlEmpresaTransporte.SelectedValue = IDTransporte;

            //List<TMS_SeguimientoEL> lstUnidad = oSeguimiento.UnidadxEmp(Convert.ToInt32(ddlEmpresaTransporte.SelectedValue));
            //foreach (TMS_SeguimientoEL un in lstUnidad)
            //{
            //    if(un.UNIDAD_CODIGO.ToString() == txtUnidad_id.Text)
            //    {
            //        txtUnidad.Text = un.UNIDAD_PLACA;
            //    }
            //}
            //txtUnidad.Text = lstUnidad[0].UNIDAD_PLACA;
            //txtUnidad_id.Text = lstUnidad[0].UNIDAD_CODIGO.ToString();



            //List<TMS_ChoferEL> lstChofer = oSeguimiento.GetChoferxEmp(Convert.ToInt32(ddlEmpresaTransporte.SelectedValue));
            //foreach (TMS_ChoferEL un in lstChofer)
            //{
            //    if (un.CHOFER_CODIGO.ToString() == txtConductor_id.Text)
            //    {
            //        txtConductor.Text = un.CHOFER;
            //    }
            //}
            //txtConductor.Text = lstChofer[0].CHOFER;
            //txtConductor_id.Text = lstChofer[0].CHOFER_CODIGO.ToString();
            if (ddlEmpresaTransporte.SelectedValue == "88")
            {
                ServiceReferenceRRHH.apiSoapClient service = new ServiceReferenceRRHH.apiSoapClient();

                string strListaConductores = service.TM_ListarConductores();
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(strListaConductores, typeof(DataTable));
                ddlConductor.DataSource = dt;
                ddlConductor.DataTextField = "nom_conductor";
                ddlConductor.DataValueField = "nro_documento";

                ddlUnidad.DataSource = oSeguimiento.UnidadxTM();
                ddlUnidad.DataTextField = "nro_placa";
                ddlUnidad.DataValueField = "cod_flota";
            }
            else
            {
                ddlConductor.DataSource = oSeguimiento.GetChoferxEmp(Convert.ToInt32(ddlEmpresaTransporte.SelectedValue));
                ddlConductor.DataSource = oSeguimiento.GetChoferxEmp(Convert.ToInt32(ddlEmpresaTransporte.SelectedValue));
                ddlConductor.DataTextField = "CHOFER";
                ddlConductor.DataValueField = "CHOFER_CODIGO";

                ddlUnidad.DataSource = oSeguimiento.UnidadxEmp(Convert.ToInt32(ddlEmpresaTransporte.SelectedValue));
                ddlUnidad.DataTextField = "UNIDAD_PLACA";
                ddlUnidad.DataValueField = "UNIDAD_CODIGO";
            }
            ddlConductor.DataBind();
            ddlUnidad.DataBind();


            if (IDPlaca == "-1")
                ddlUnidad.SelectedItem.Text = Placa;
            else
                ddlUnidad.SelectedValue = IDPlaca;


            if (IDConductor == "-1")
                ddlConductor.SelectedValue = DNIConductor;
            else
                ddlConductor.SelectedValue = IDConductor;

        }
    }
    protected void gvProgramacion_PreRender(object sender, EventArgs e)
    {
        Prerender(gvProgramacion);
    }

    public void CargarEmpresaTransporte()
    {
        try
        {
            TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
            ddlEmpresa.DataSource = oSeguimiento.GetEmpresaTransporte();
            ddlEmpresa.DataTextField = "EMPRETRANS_RAZONSOCIAL";
            ddlEmpresa.DataValueField = "EMPRETRANS_CODIGO";
            ddlEmpresa.DataBind();
            ddlEmpresa.SelectedValue = "88";

        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "Error. Informar a Sistemas:" + ex);
        }
    }

    public void CargarUnidadTransporte(int pIdEmpresaTransporte, string pValue)
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
        ddlUnidadTransporte.DataSource = oSeguimiento.UnidadxEmp(pIdEmpresaTransporte);
        ddlUnidadTransporte.DataTextField = "UNIDAD_PLACA";
        ddlUnidadTransporte.DataValueField = "UNIDAD_CODIGO";
        ddlUnidadTransporte.DataBind();
        ddlUnidadTransporte.SelectedValue = pValue;
    }

    public void CargarChofer(int pIdEmpresaTransporte, string pValue)
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
        ddlChofer.DataSource = oSeguimiento.GetChoferxEmp(pIdEmpresaTransporte);
        ddlChofer.DataTextField = "CHOFER";
        ddlChofer.DataValueField = "CHOFER_CODIGO";
        ddlChofer.DataBind();
        ddlChofer.SelectedValue = pValue;
    }

    [System.Web.Services.WebMethod]
    public static string CargarChofer(int IDEmpresa)
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
        IList<TMS_ChoferEL> dataChofer = oSeguimiento.GetChoferxEmp(IDEmpresa);
        var data = from emp in dataChofer select new { id = emp.CHOFER_CODIGO, descripcion = emp.CHOFER };
        var json = new JavaScriptSerializer().Serialize(data.ToList());
        return json;
    }

    [System.Web.Services.WebMethod]
    public static string CargarUnidad(int IDEmpresa)
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
        IList<TMS_SeguimientoEL> dataChofer = oSeguimiento.UnidadxEmp(IDEmpresa);
        var data = from emp in dataChofer select new { id = emp.UNIDAD_CODIGO, descripcion = emp.UNIDAD_PLACA };
        var json = new JavaScriptSerializer().Serialize(data.ToList());
        return json;
    }
    protected void btnGuardarProgramacion_Click(object sender, EventArgs e)
    {
        string msjError = "";
        IList<string> RowData_AL = new List<string>();
        int flag = 0;
        foreach (GridViewRow row in gvProgramacion.Rows)
        {
            DropDownList ddlEmpresaTransporte = (DropDownList)row.FindControl("ddlEmpresaTransporte");
            DropDownList ddlConductor = (DropDownList)row.FindControl("ddlConductor");
            DropDownList ddlUnidad = (DropDownList)row.FindControl("ddlUnidad");
            //int IDConductor = Convert.ToInt32(((TextBox)row.FindControl("txtConductor")).Text);
            //int IDUnidad = Convert.ToInt32(((TextBox)row.FindControl("txtUnidad")).Text);
            int Item = Convert.ToInt32(((Label)row.FindControl("Item")).Text);
            int Al = Convert.ToInt32(((Label)row.FindControl("Al")).Text);
            int Sol = Convert.ToInt32(((Label)row.FindControl("Sol")).Text);
            int IDTransporte = Convert.ToInt32(ddlEmpresaTransporte.SelectedValue);
            //int IDConductor = Convert.ToInt32(txtConductor.Text);
            //int IDTransporte = Convert.ToInt32(txtUnidad.Text);

            int dataRespuesta = objTPL.Programacion_AsignacionBasico(Al, Item, Sol, Convert.ToInt32(ddlUnidad.SelectedValue), ddlUnidad.SelectedItem.ToString(), Convert.ToInt32(ddlConductor.SelectedValue), IDTransporte, User.Identity.Name, ddlConductor.SelectedItem.ToString());
            flag++;
        }

        if (flag == 0)
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Debe seleccionar uno o más contenedores.','Información','danger');", true);
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Programación realiza con éxito.','Ok','success');", true);
            CargarContenedores();
        }
    }
    protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarCliente();
    }
    protected void chkAsignacionMasiva_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAsignacionMasiva.Checked)
        {
            ddlLocal1Masivo.Enabled = true;
            ddlLocal2Masivo.Enabled = true;
        }
        else
        {
            ddlLocal1Masivo.Enabled = false;
            ddlLocal2Masivo.Enabled = false;

            ddlLocal1.Enabled = false;
            ddlLocal1.SelectedIndex = 0;
            ddlLocal2.Enabled = false;
            ddlLocal2.SelectedIndex = 0;

        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalImportarContenedor').modal('show');", true);
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        ReporteBL objReporte = new ReporteBL();
        DataTable dataExportar = objReporte.ReporteSeguimiento("", "", -1, txtFechaDesdeFiltro.Text, txtFechaHastaFiltro.Text, ddlEmpresaFiltro.SelectedValue);

        var GridView1 = new GridView();
        GridView1.DataSource = dataExportar;

        GridView1.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attacNhment;filename=ReporteSeguimientoSolicitud_" + DateTime.Now.ToString("ddMMyyyy") + ".xls");
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

    protected void btnFacturacion_Click(object sender, EventArgs e)
    {
        int flag = 0, soloDis = 0;
        IList<string> RowData_AL = new List<string>();
        lblMensaje.Value = "";
        string msjError = "";
        string pRO = "", pSolicitud = "", pEntidad = "", pSeguimiento = "";
        foreach (GridViewRow gvrAL in GVPlaneamiento.Rows)
        {
            CheckBox chkSelected = (CheckBox)gvrAL.FindControl("CheckBox1");
            LinkButton hplSolicitud = (LinkButton)gvrAL.FindControl("hplSolicitud");
            Label lblTipoSol = (Label)gvrAL.FindControl("lblTipoSol");

            if (chkSelected.Checked == true)
            {
                flag += 1;

                pRO = gvrAL.Cells[3].Text + "," + pRO;
                pSolicitud = hplSolicitud.Text + "," + pSolicitud;
                pEntidad = gvrAL.Cells[4].Text;
                if (lblTipoSol.Text == "Distribución")
                    soloDis = 1;

                string[] arr = hplSolicitud.CommandArgument.ToString().Split('|');
                Session["Movimiento"] = gvrAL.Cells[5].Text;
                RowData_AL.Add(arr[0]);

                //if(chkSelected.Checked==false)

                if (flag > 1)
                {
                    msjError = "Para agregar seguimiento a una solicitud de tipo distribucion, la debe realizar una a la vez";
                    break;
                }
                if (gvrAL.Cells[7].Text == "Pendiente")
                {
                    msjError = "Las Solicitudes deben de estar en estado Recepcionado o Asignado";
                    break;
                }

            }

            //End If/for
        }
        if (RowData_AL.Count() == 0 || msjError != "")
        {
            if (msjError == "")
                MostrarMensaje(2, "Debe seleccionar 1 o más filas");
            else
                MostrarMensaje(1, msjError);
        }
        else
        {
            lblMensaje.Value = "";
            FacturacionSap();
        }
    }

    public void FacturacionSap()
    {

        string lblMensaje = "";
        TMS_PreFacturacionBL oPreFacturacion = new TMS_PreFacturacionBL();

        try
        {
            int flag = 0;
            int soloDis = 0;


            string pRO = "", pSolicitud = "", pRucClientParc = "", pEmpresaCreo = "", pCliente = "", pCentroCosto = "", pFacturado = "", pRuc = "", pTipoMovimiento = "", pRucClientedelCLiente = "";



            for (int i = 0; i < GVPlaneamiento.Rows.Count - 1; i++)
            {
                CheckBox chkPlaneamiento = (CheckBox)GVPlaneamiento.Rows[i].FindControl("CheckBox1");
                if (chkPlaneamiento.Checked)
                {
                    flag = flag + 1;
                    if (GVPlaneamiento.Rows[i].Cells[7].Text == "Pendiente")
                    {
                        lblMensaje = "Las Solicitudes deben de estar en estado Recepcionado";
                        break;
                    }
                    pEmpresaCreo = GVPlaneamiento.Rows[i].Cells[4].Text;
                    Label lblCliente = (Label)GVPlaneamiento.Rows[i].FindControl("lblcliente");
                    pCliente = lblCliente.Text;
                    Label lblCentoCosto = (Label)GVPlaneamiento.Rows[i].FindControl("lblTipoSol");
                    pCentroCosto = lblCentoCosto.Text;
                    pFacturado = GVPlaneamiento.Rows[i].Cells[10].Text;
                    Label lblRuc = (Label)GVPlaneamiento.Rows[i].FindControl("lblRucCliente");
                    pRuc = lblRuc.Text;
                    //Label lblTipoMovimiento = (Label)GVPlaneamiento.Rows[i].FindControl("lblTipoMovimiento");
                    pTipoMovimiento = GVPlaneamiento.Rows[i].Cells[5].Text.Substring(0, 1);
                    Label lblRucClientedelCLiente = (Label)GVPlaneamiento.Rows[i].FindControl("lblRuc");
                    pRucClientedelCLiente = lblRucClientedelCLiente.Text;
                }



            }

            for (int i = 0; i < GVPlaneamiento.Rows.Count - 1; i++)
            {
                CheckBox chkPlaneamiento = (CheckBox)GVPlaneamiento.Rows[i].FindControl("CheckBox1");
                if (chkPlaneamiento.Checked)
                {
                    Label lblCentoCosto = (Label)GVPlaneamiento.Rows[i].FindControl("lblTipoSol");
                    if (lblCentoCosto.Text != pCentroCosto)
                    {
                        lblMensaje = "El Tipo de solicitud tiene que ser igual";
                        break;
                    }


                    if (GVPlaneamiento.Rows[i].Cells[10].Text != pFacturado)
                    {
                        lblMensaje = "La solicitud ya tiene facturación";
                        break;
                    }

                    if (GVPlaneamiento.Rows[i].Cells[4].Text == pEmpresaCreo ||
                        GVPlaneamiento.Rows[i].Cells[4].Text == "TRANSPORTES MERIDIAN S.A.C." ||
                        GVPlaneamiento.Rows[i].Cells[4].Text == "CONTRANS S.A.C.")
                    {
                        pRO = GVPlaneamiento.Rows[i].Cells[3].Text + "," + pRO;
                        LinkButton hplSolicitud = (LinkButton)GVPlaneamiento.Rows[i].FindControl("hplSolicitud");
                        pSolicitud = hplSolicitud.Text + "," + pSolicitud;
                        pEmpresaCreo = GVPlaneamiento.Rows[i].Cells[4].Text;
                        Label lblCliente = (Label)GVPlaneamiento.Rows[i].FindControl("lblcliente");
                        pCliente = lblCliente.Text;
                        pCentroCosto = lblCentoCosto.Text;
                        Label lblRuc = (Label)GVPlaneamiento.Rows[i].FindControl("lblRucCliente");
                        pRuc = lblRuc.Text;
                        //Label lblTipoMovimiento = (Label)GVPlaneamiento.Rows[i].FindControl("lblTipoMovimiento");
                        pTipoMovimiento = GVPlaneamiento.Rows[i].Cells[5].Text.Substring(0, 1);
                        Label lblRucClientedelCLiente = (Label)GVPlaneamiento.Rows[i].FindControl("lblRuc");
                        pRucClientedelCLiente = lblRucClientedelCLiente.Text;

                        if (pRucClientedelCLiente == "20514842079")
                        {
                            pRucClientParc = "20514842079";
                        }
                    }
                    else
                    {
                        lblMensaje = "El nombre del cliente tiene que ser igual";
                        break;

                    }
                }

            }

            if (pRO == "" || pSolicitud == "")
            {
                lblMensaje = "Elija una Solicitud";
                //break;
            }
            Session["pRO"] = pRO.Substring(0, pRO.Length - 1);
            Session["pSolicitud"] = pSolicitud.Substring(0, pSolicitud.Length - 1);
            Session["pCLienteCreacion"] = pEmpresaCreo;
            Session["pCLiente"] = pCliente;
            Session["pCentroCosto"] = pCentroCosto;
            Session["pRuc"] = pRuc;
            Session["pTipoMovimiento"] = pTipoMovimiento;
            Session["pRucClienteDelCliente"] = pRucClientedelCLiente;
            if (pRucClientParc == "20514842079")
            {
                Session["pRucClienteDelCliente"] = pRucClientParc;
            }

            string CadenaRO = Session["pRO"].ToString();
            string[] ArrCadenaRO = CadenaRO.Split(',');

            string CadenaSOL = Session["pSolicitud"].ToString();
            string[] ArrCadenaSOL = CadenaSOL.Split(',');
            DataTable dtZona;

            if (Session["pCentroCosto"].ToString() != "Operativo")
            {
                for (int n = 0; n < ArrCadenaRO.Length - 1; n++)
                {
                    if (ArrCadenaRO[n] != "")
                    {
                        dtZona = oPreFacturacion.ConsultarZona(Convert.ToInt32(ArrCadenaRO[n]), Convert.ToInt32(ArrCadenaSOL[n]));//.Tables(0);
                        for (int p = 0; p < dtZona.Rows.Count - 1; p++)
                        {
                            if (dtZona.Rows[p]["DISTRITO_CODIGO"].ToString() == "0")
                            {
                                lblMensaje = "No se puede Iniciar la facturación ya que no se tiene registrado un codigo de zona para la Solicitud : " + dtZona.Rows[p]["ROS_KItem"].ToString() + " y la AL: " + dtZona.Rows[p]["ROS_KRO"].ToString();
                                break;
                            }
                        }
                    }
                }
            }

            Response.Redirect("http://localhost:59559/Modulos/TMS/PreFacturacion.aspx");
        }
        catch (Exception ex)
        {
            lblMensaje = ex.Message;
        }
    }


}
