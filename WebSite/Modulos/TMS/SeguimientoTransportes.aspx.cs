using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using EL;
using System.Text;
using System.IO;
using Newtonsoft.Json;

public partial class Modulos_TMS_SeguimientoTransportes : System.Web.UI.Page
{
    
    int valor = 0;
    DataTable tabExpo = null, tabla = null;
    string nombcont = "", fchCita = "", Evento = "";
    TPL_BL objTPL = new TPL_BL();

    protected void Page_Load(object sender, EventArgs e)
    {      

        if (!IsPostBack)
        {

            btnGrabar.Visible = false;
            btnEnviarCorreo.Enabled = false;

            if (Request.QueryString["AL"] != null && Request.QueryString["Soli"] != null)
            {
                CargarDeposito();
                CargarEmpresa();
                string pRO = Request.QueryString["AL"];
                string pSolicitud = Request.QueryString["Soli"];
                if (pRO != "" || pSolicitud != "")
                {
                    CargarSolicitud(pRO, pSolicitud);
                }
                else
                {
                    MostrarMensaje(1, "No hay nada en la URL.");
                }
                valor = 1;
            }
            else
            {
                //CargarSeguimientoMonitoreo();
            }

            //loadItemsMovimiento();
            //loadItemsddlEstadoAL();
            //loadItemsEmpresa();
            //loadItemsTipoSolicitud();
            //loadItemsAnalista();

            cargarROALMant();
            Limpiar();
            CargarDetalle();
        }
        else{}

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

    public void CargarDeposito()
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
        ddlTerminalRetiro.DataSource = oSeguimiento.ListarDepositos();
        ddlTerminalRetiro.DataTextField = "Dep_Desc";
        ddlTerminalRetiro.DataValueField = "Dep_Codi";
        ddlTerminalRetiro.DataBind();

        ddlTerminalDevolucion.DataSource = oSeguimiento.ListarDepositos();
        ddlTerminalDevolucion.DataTextField = "Dep_Desc";
        ddlTerminalDevolucion.DataValueField = "Dep_Codi";
        ddlTerminalDevolucion.DataBind();
    }

    public void CargarEmpresa()
    {
        try {
            TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
            ddlEmpresaInfo.DataSource = oSeguimiento.GetEmpresaTransporte();
            ddlEmpresaInfo.DataTextField = "EMPRETRANS_RAZONSOCIAL";
            ddlEmpresaInfo.DataValueField = "EMPRETRANS_CODIGO";
            ddlEmpresaInfo.DataBind();
            ddlEmpresaInfo.SelectedValue = "88";

        } catch (Exception ex)
        {
            MostrarMensaje(1, "Error. Informar a Sistemas:" + ex);
        }
    }

    public void CargarUnidadTransporte(int pIdEmpresaTransporte, string pValue)
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();

        if (ddlEmpresaInfo.SelectedValue == "88") {
            ddlUnidadInfo.DataSource = oSeguimiento.UnidadxTM();
            ddlUnidadInfo.DataTextField = "nro_placa";
            ddlUnidadInfo.DataValueField = "cod_flota";

        }
        else
        {
            ddlUnidadInfo.DataSource = oSeguimiento.UnidadxEmp(pIdEmpresaTransporte);
            ddlUnidadInfo.DataTextField = "UNIDAD_PLACA";
            ddlUnidadInfo.DataValueField = "UNIDAD_CODIGO";

        }

        ddlUnidadInfo.DataBind();
        ddlUnidadInfo.SelectedItem.Text = pValue;
    }

    public void CargarChofer(int pIdEmpresaTransporte, string pValue)
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();

        if (ddlEmpresaInfo.SelectedValue == "88")
        {
            ServiceReferenceRRHH.apiSoapClient service = new ServiceReferenceRRHH.apiSoapClient();

            string strListaConductores = service.TM_ListarConductores();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(strListaConductores, typeof(DataTable));
            ddlChoferInfo.DataSource = dt;
            ddlChoferInfo.DataTextField = "nom_conductor";
            ddlChoferInfo.DataValueField = "nro_documento";
            ddlChoferInfo.Items.Add(new ListItem("--Seleccione--", "-1"));
        }
        else
        {
            ddlChoferInfo.DataSource = oSeguimiento.GetChoferxEmp(Convert.ToInt32(ddlEmpresaInfo.SelectedValue));
            ddlChoferInfo.DataSource = oSeguimiento.GetChoferxEmp(Convert.ToInt32(ddlEmpresaInfo.SelectedValue));
            ddlChoferInfo.DataTextField = "CHOFER";
            ddlChoferInfo.DataValueField = "CHOFER_CODIGO";
        }
        ddlChoferInfo.DataBind();
        ddlChoferInfo.SelectedValue = pValue;
    }

    public void CargarSolicitud(string pRO, string pSolicitud)
    {
        try
        {
            TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
            grvSolicitudes.DataSource = oSeguimiento.ListarRo(pRO, pSolicitud);
            grvSolicitudes.DataBind();

            //grvSolicitudes.Columns[4].Visible = false;
            //grvSolicitudes.Columns[6].Visible = false;
            //grvSolicitudes.Columns[8].Visible = false;

            //grvSolicitudes.HeaderRow.Cells[4].Visible = false;
            //grvSolicitudes.HeaderRow.Cells[6].Visible = false;
            //grvSolicitudes.HeaderRow.Cells[8].Visible = false;
            //for (int i = 0; grvSolicitudes.Rows.Count - 1 > i; i++) {
            //    grvSolicitudes.Rows[i].Cells[4].Visible = false;
            //    grvSolicitudes.Rows[i].Cells[6].Visible = false;
            //    grvSolicitudes.Rows[i].Cells[8].Visible = false;
            //    if (grvSolicitudes.Rows[i].Cells[8].Text != "4")
            //    {
            //        grvSolicitudes.HeaderRow.Cells[7].Visible = false;
            //        grvSolicitudes.Rows[i].Cells[7].Visible = false;
            //    }
            //}
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "Error. Informar a Sistemas:" + ex.Message.ToString().Replace("'", ""));
        }

    }

    public void cargarSolicitudMant()
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();

        ddlMantSolicitud.DataSource = oSeguimiento.ListarTipoCont(Convert.ToInt32(ddlMantROAL.SelectedValue));
        ddlMantSolicitud.DataTextField = "Bic_tcnt";
        ddlMantSolicitud.DataValueField = "Bic_tcnt";
        ddlMantSolicitud.DataBind();
    }

    public void cargarTipoMant()
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
        
        ddlMantTipo.DataSource = oSeguimiento.ListarSolicitud(Convert.ToInt32(ddlMantROAL.SelectedValue));
        ddlMantTipo.DataTextField = "Item";
        ddlMantTipo.DataValueField = "KItem";
        ddlMantTipo.DataBind();
    }

    public void cargarROALMant()
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();

        string RO = Request.QueryString["AL"].ToString();

        string[] arg;
        arg = RO.Split(',');
        ddlMantROAL.Items.Add(new ListItem("--Seleccione--", "0"));

        for(int i = 0; i < arg.Length; i++)
        {
            ddlMantROAL.Items.Add(new ListItem(arg[i], arg[i]));
        }
        
    }

    protected void ddlMantROAL_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarSolicitudMant();
        cargarTipoMant();
        //hfAction.Value ="AGREGAR_CONTENEDOR";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalAgregarContenedor').modal('show');", true);
    }

    public void CargarLocal(string pCliente, string pClienteD) {
        TMS_LocalBL oLocal = new TMS_LocalBL();

        ddlClienteLocal.DataSource = oLocal.GetLocal(pCliente);
        ddlClienteLocal.DataTextField = "DIRECCION";
        ddlClienteLocal.DataValueField = "LOCAL_CODIGO";
        ddlClienteLocal.DataBind();

        //ddlLocal2.DataSource = oLocal.GetLocal(pClienteD);
        //ddlLocal2.DataTextField = "DIRECCION";
        //ddlLocal2.DataValueField = "LOCAL_CODIGO";
        //ddlLocal2.DataBind();
    }

    private void Limpiar() {
        txtClienteIngresoHora.Text = "";
        txtClienteInicioHora.Text = "";
        txtClienteLlegadaHora.Text = "";
        txtClienteObservacion.Text = "";
        txtClienteSalidaHora.Text = "";
        txtClienteTerminoHora.Text = "";
        txtDevolucionIngresoHora.Text = "";
        txtDevolucionLlegadaHora.Text = "";
        txtDevolucionSalidaHora.Text = "";
        txtKmFinalInfo.Text = "";
        txtKmInicialInfo.Text = "";
        txtObservacionDevolucion.Text = "";
        txtPrecintoAduanaInfo.Text = "";
        txtPrecintoLineaInfo.Text = "";
        txtPrecintoTransitoInfo.Text = "";
        txtPrecintoVacioInfo.Text = "";
        txtRetiroIngresoHora.Text = "";
        txtRetiroLlegadaHora.Text = "";
        txtRetiroObservacion.Text = "";
        txtRetiroSalidaHora.Text = "";

        ddlChoferInfo.SelectedIndex = 0;
        ddlClienteLocal.SelectedIndex = 0;
        ddlEmpresaInfo.SelectedIndex = 0;
        ddlTerminalDevolucion.SelectedIndex = 0;
        ddlTerminalRetiro.SelectedIndex = 0;
        ddlUnidadInfo.SelectedIndex = 0;

        dtpClienteIngresoFecha.Text = "";
        dtpClienteInicioFecha.Text = "";
        dtpClienteLlegadaFecha.Text = "";
        dtpClienteSalidaFecha.Text = "";
        dtpClienteTerminoFecha.Text = "";
        dtpDevolucionIngresoFecha.Text = "";
        dtpDevolucionLlegadaFecha.Text = "";
        dtpDevolucionSalidaFecha.Text = "";
        dtpRetiroIngresoFecha.Text = "";
        dtpRetiroLlegadaFecha.Text = "";
        dtpRetiroSalidaFecha.Text = "";

    }

    void limpiar2() {

        ddlMantROAL.SelectedIndex = 0;
        ddlMantSolicitud.SelectedIndex = 0;
        ddlMantTipo.SelectedIndex = 0;
        txtMantFchCita.Text = "";
        txtMantHoraCita.Text = "";
        txtMantPayload.Text = "";
        txtMantPeso.Text = "";
        txtMantPies.Text = "";
        txtMantPrefijoCont.Text = "";
        txtMantSufijoCont.Text = "";
        txtMantTara.Text = "";

    }

    private void CargarDetalle()
    {
        try
        {
            Limpiar();
            //chkdoble.Checked = false;
            //Local2(true); //***** FALSE
            //tabExpo.Columns.Add("Solicitud",typeof(string));
            //tabExpo.Columns.Add("AL",typeof(string));
            grvContenedores.DataSource = null;
            grvContenedores.DataBind();
            //Panel1.Visible = True;

            int tipsol, sol;
            string pSolicitud = "";//, tiposolicitud = "";
            DataTable tblsol;
            TMS_SeguimientoBL oSeguimientoBL = new TMS_SeguimientoBL();

            for (int i = 0; i < grvSolicitudes.Rows.Count; i++)
            {
                Title = "AL" + grvSolicitudes.Rows[i].Cells[2].Text;
                lblTittle.Text = "AL" + grvSolicitudes.Rows[i].Cells[2].Text;
                pSolicitud = grvSolicitudes.Rows[i].Cells[1].Text + "," + pSolicitud;
                tipsol = Convert.ToInt32(grvSolicitudes.Rows[i].Cells[8].Text);
                //lblMovi.Text = grvSolicitudes.Rows[i].Cells[3].Text.Substring(0, 1);
                hfSoli.Value = grvSolicitudes.Rows[i].Cells[1].Text;
                hfEnt1.Value = grvSolicitudes.Rows[i].Cells[4].Text;
                hfEnt2.Value = grvSolicitudes.Rows[i].Cells[6].Text;
                hfsol.Value = grvSolicitudes.Rows[i].Cells[2].Text;
                //lblcliente.Text = grvSolicitudes.Rows[i].Cells[4].Text;

                tblsol = oSeguimientoBL.GetTipoSolicitud(tipsol);
                sol = Convert.ToInt32(tblsol.Rows[0]["TS_COD"]);

                switch (sol) {
                    case 1:
                        hfTSol.Value = tblsol.Rows[0]["Transporte"].ToString();
                        hfTipSol.Value = sol.ToString();
                        Terminal1(true);
                        Terminal2(true);
                        Cliente1(true);
                        //Cliente2(true);
                        break;
                    case 2:
                        hfTSol.Value = tblsol.Rows[0]["Transporte"].ToString();
                        hfTipSol.Value = sol.ToString();
                        Terminal1(true);
                        Terminal2(true);
                        Cliente1(false);
                        //Cliente2(false);
                        break;
                    case 3:
                        hfTSol.Value = tblsol.Rows[0]["Transporte"].ToString();
                        hfTipSol.Value = sol.ToString();
                        break;
                    case 4:
                    case 7:
                    case 8:
                        hfTSol.Value = tblsol.Rows[0]["Transporte"].ToString();
                        hfTipSol.Value = sol.ToString();
                        Terminal1(true);
                        Terminal2(false);
                        Cliente1(true);
                        //Cliente2(true);
                        break;
                    case 5:
                        hfTSol.Value = tblsol.Rows[0]["Transporte"].ToString();
                        hfTipSol.Value = sol.ToString();
                        Terminal1(true);
                        Terminal2(true);
                        Cliente1(false);
                        //Cliente2(false);
                        break;
                    case 6:
                        hfTSol.Value = tblsol.Rows[0]["Transporte"].ToString();
                        hfTipSol.Value = sol.ToString();
                        Terminal1(true);
                        Terminal2(true);
                        Cliente1(true);
                        //Cliente2(true);
                        break;
                }
                //DataRow row;
                //row = tabExpo.NewRow();
                //row[0] = grvSolicitudes.Rows[i].Cells[1].Text;
                //row[1] = grvSolicitudes.Rows[i].Cells[2].Text;
                //tabExpo.Rows.Add(row);
                CargarLocal(hfEnt1.Value + "%26", hfEnt2.Value);

            }

            DataTable tabla = null;

            if (pSolicitud.Length > 1)
            {
                pSolicitud = pSolicitud.Substring(0, pSolicitud.Length - 1);

                if (Convert.ToInt32(Session["VALOR"]) == 1)
                {
                    if (pSolicitud != "")
                    {
                        tabla = oSeguimientoBL.GetContenedoresSeguimiento(pSolicitud);
                    }
                }
                else
                {
                    tabla = oSeguimientoBL.GetContenedores(pSolicitud, Session["ITEM"].ToString());
                    valor = 0;
                }

                if (tabla.Rows.Count > 0) {
                    grvContenedores.DataSource = tabla;
                    grvContenedores.DataBind();
                    //Session["Export"] = tabExpo;
                }
                else
                {
                    //grvSolicitudes.Visible = false;
                    MostrarMensaje(1, "La Solicitud no tiene Contenedores");

                }

            }

        } catch (Exception ex) {
            MostrarMensaje(1, "Error. Informar a Sistemas:" + ex);
        }
    }

    //public void Local2(bool op) {
    //    ddlLocal2.Visible = op;
    //    txtFecLleCli2.Visible = op;
    //    txtFecIngCli2.Visible = op;
    //    txtFecIniCli2.Visible = op;
    //    txtFecTerCli2.Visible = op;
    //    txtFecSalCli2.Visible = op;
    //    txtHoraLleCli2.Visible = op;
    //    txtHoraIngCli2.Visible = op;
    //    txtHoraIniCli2.Visible = op;
    //    txtHoraTerCli2.Visible = op;
    //    txtHoraSalCli2.Visible = op;
    //    txtObsClie2.Visible = op;
    //}
    public void Terminal1(bool pHabilitar) {
        ddlTerminalRetiro.Enabled = pHabilitar;
        dtpRetiroIngresoFecha.Enabled = pHabilitar;
        dtpRetiroLlegadaFecha.Enabled = pHabilitar;
        dtpRetiroSalidaFecha.Enabled = pHabilitar;
        txtRetiroObservacion.Enabled = pHabilitar;
    }
    public void Terminal2(bool pHabilitar) {
        ddlTerminalDevolucion.Enabled = pHabilitar;
        dtpDevolucionIngresoFecha.Enabled = pHabilitar;
        dtpDevolucionLlegadaFecha.Enabled = pHabilitar;
        dtpDevolucionSalidaFecha.Enabled = pHabilitar;
        txtObservacionDevolucion.Enabled = pHabilitar;
    }
    public void Cliente1(bool pHabilitar) {
        ddlClienteLocal.Enabled = pHabilitar;
        dtpClienteIngresoFecha.Enabled = pHabilitar;
        dtpClienteInicioFecha.Enabled = pHabilitar;
        dtpClienteLlegadaFecha.Enabled = pHabilitar;
        dtpClienteSalidaFecha.Enabled = pHabilitar;
        dtpClienteTerminoFecha.Enabled = pHabilitar;
        txtRetiroObservacion.Enabled = pHabilitar;
    }
    //public void Cliente2(bool phabilitar) {
    //    ddlLocal2.Enabled = phabilitar;
    //    txtFecLleCli2.Enabled = phabilitar;
    //    txtFecIngCli2.Enabled = phabilitar;
    //    txtFecIniCli2.Enabled = phabilitar;
    //    txtFecTerCli2.Enabled = phabilitar;
    //    txtFecSalCli2.Enabled = phabilitar;
    //    txtObsClie2.Enabled = phabilitar;
    //}

    //public void loadItemSeguimiento()
    //{
    //    ddlSeguimiento.Items.Clear();
    //    ddlSeguimiento.Items.Add("Ambos");
    //    ddlSeguimiento.Items[0].Value = "A";
    //    ddlSeguimiento.Items.Add("Si");
    //    ddlSeguimiento.Items[1].Value = "S";
    //    ddlSeguimiento.Items.Add("No");
    //    ddlSeguimiento.Items[2].Value = "N";
    //    ddlSeguimiento.SelectedIndex = 0;
    //}

    //public void loadItemsMovimiento()
    //{
    //    ddlMovimiento.Items.Clear();

    //    TMS_SolicitudBL oSolicitudBL = new TMS_SolicitudBL();
    //    ddlMovimiento.DataSource = oSolicitudBL.ListarMovimiento();
    //    ddlMovimiento.DataTextField = "Movimiento";
    //    ddlMovimiento.DataValueField = "ro_tmov";
    //    ddlMovimiento.DataBind();
    //    ddlMovimiento.SelectedIndex = 0;
    //}

    //public void loadItemsddlEstadoAL()
    //{
    //    ddlEstadoAL.Items.Clear();

    //    TMS_SolicitudBL oSolicitudBL = new TMS_SolicitudBL();
    //    ddlEstadoAL.DataSource = oSolicitudBL.ListarEstadosAL();
    //    ddlEstadoAL.DataTextField = "ESTADO";
    //    ddlEstadoAL.DataValueField = "ros_estado";
    //    ddlEstadoAL.DataBind();
    //    ddlEstadoAL.SelectedIndex = 0;
    //}

    //public void loadItemsEmpresa()
    //{
    //    ddlEmpresa.Items.Clear();

    //    TMS_SolicitudBL oSolicitudBL = new TMS_SolicitudBL();
    //    ddlEmpresa.DataSource = oSolicitudBL.ListarEmpresasAL();
    //    ddlEmpresa.DataTextField = "Ent_Rsoc";
    //    ddlEmpresa.DataValueField = "Ent_Codi";
    //    ddlEmpresa.DataBind();
    //    ddlEmpresa.SelectedIndex = 0;
    //}

    //public void loadItemsTipoSolicitud()
    //{
    //    ddlTipoSolicitud.Items.Clear();

    //    TMS_SolicitudBL oSolicitudBL = new TMS_SolicitudBL();
    //    ddlTipoSolicitud.DataSource = oSolicitudBL.ListarTipoSolicitud();
    //    ddlTipoSolicitud.DataTextField = "TS_Des";
    //    ddlTipoSolicitud.DataValueField = "TS_Cod";
    //    ddlTipoSolicitud.DataBind();
    //    ddlTipoSolicitud.SelectedIndex = 0;
    //}

    //public void loadItemsAnalista()
    //{
    //    ddlAnalista.Items.Clear();

    //    TMS_SolicitudBL oSolicitudBL = new TMS_SolicitudBL();
    //    ddlAnalista.DataSource = oSolicitudBL.ListarAnalista();
    //    ddlAnalista.DataTextField = "Nombre";
    //    ddlAnalista.DataValueField = "Usu_Codi";
    //    ddlAnalista.DataBind();
    //    ddlAnalista.SelectedIndex = 0;
    //}

    //protected void gvAL_PreRender(object sender, EventArgs e)
    //{
    //    if (gvAL.Rows.Count > 0)
    //    {
    //        gvAL.UseAccessibleHeader = true;
    //        gvAL.HeaderRow.TableSection = TableRowSection.TableHeader;
    //        gvAL.FooterRow.TableSection = TableRowSection.TableFooter;
    //    }
    //}
    //}



    protected void btnGrabar_Click(object sender, EventArgs e)
    {

    }

    protected void btnAgregarContenedor_Click(object sender, EventArgs e)
    {
        hfAction.Value = "AGREGAR_CONTENEDOR";
        limpiar2();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalAgregarContenedor').modal('show');", true);
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        string AL = Request.QueryString["AL"];

        if (ObtenerDatosSesion("perfil") == "CMN")
        {
            if(AL.Contains(",") || AL.Contains("/"))
                Response.Redirect("DefaultMonitoreo.aspx");
            else
                Response.Redirect("DefaultMonitoreo.aspx?ExAL=" + AL);
        }
            
        else
        {
            if(AL.Contains(",") || AL.Contains("/"))
                Response.Redirect("default.aspx");
            else
                Response.Redirect("default.aspx?ExAL=" + AL);
        }
    }

    protected void btnMonitoreo_Click(object sender, EventArgs e)
    {

    }

    protected void btnEnviarCorreo_Click(object sender, EventArgs e)
    {

    }

    protected void btnRegistrarContenedor_Click(object sender, EventArgs e)
    {
        try
        {
            
            int pPeso = 0, pPyld = 0, pTara = 0, pPies = 0;
            if (txtMantTara.Text.Trim() == "") {
                pTara = 0;
            }
            else {
                pTara = Convert.ToInt32(txtMantTara.Text.Trim());
            }

            if (txtMantPeso.Text.Trim() == "") {
                pPeso = 0;
            }
            else {
                pPeso = Convert.ToInt32(txtMantPeso.Text.Trim());
            }

            if (txtMantPies.Text.Trim() == "")
                pPies = 0;
            else
                pPies = Convert.ToInt32(txtMantPies.Text.Trim());

            if (txtMantPayload.Text.Trim() == "")
                pPyld = 0;
            else
                pPyld = Convert.ToInt32(txtMantPayload.Text.Trim());

            TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
            string pUsuario = ObtenerDatosSesion("codigo");


            string mensaje = oSeguimiento.ContenedorExpo(Convert.ToInt32(ddlMantROAL.SelectedValue), Convert.ToInt32(ddlMantTipo.SelectedValue),
                                                        ddlMantSolicitud.SelectedValue.ToString(), pPies,txtMantPrefijoCont.Text.Trim(), txtMantSufijoCont.Text.Trim(),
                                                        pPyld, pPeso, pTara, pUsuario,Convert.ToDateTime(txtMantFchCita.Text+" "+txtMantHoraCita.Text));
            if (mensaje == "I")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalAgregarContenedor').modal('close');", true);
                MostrarMensaje(0, "Contenedor Ingresado");
            }
            else if (mensaje == "E") {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalAgregarContenedor').modal('close');", true);
                MostrarMensaje(1, "El Contenedor ya Existe");
            }
            else if (mensaje == "N") {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalAgregarContenedor').modal('close');", true);
                MostrarMensaje(1, "Se ha Excedido el número de Contenedores Permitidos");
            }
            else {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalAgregarContenedor').modal('close');", true);
                MostrarMensaje(1, "No se han ingresado datos correctos");
            }

            //objTPL.Registrar_ROSeguimientoBasico(Convert.ToInt32(ddlMantROAL.SelectedValue), Convert.ToInt32(ddlMantTipo.SelectedValue), Session["Movimiento"].ToString(),
            //                                     Convert.ToInt32(ddlMantTipo.SelectedValue), Convert.ToInt32(ddlMantSolicitud.SelectedValue), txtMantPrefijoCont.Text.Trim() + txtMantSufijoCont.Text.Trim(),
            //                                     ddlMantSolicitud.SelectedValue.ToString(), pPies, 0, 0, 0, "", Convert.ToDateTime("01/01/1990"), "", 0, Convert.ToDateTime("01/01/1990"),
            //                                     "", 0, "", User.Identity.Name);

            //TMS_SolicitudTPLDetalle detalle = new TMS_SolicitudTPLDetalle();
            //detalle.TOPE = "N";
            //detalle.ROT_KRO = Convert.ToInt32(ddlMantROAL.SelectedValue);
            //detalle.ROT_KITEM = Convert.ToInt32(ddlMantTipo.SelectedValue.ToString());
            //detalle.ROT_ContenedorCodigo = txtMantPrefijoCont.Text.Trim() + txtMantSufijoCont.Text.Trim();
            //detalle.ROT_ContenedorTipo = ddlMantSolicitud.SelectedValue;
            //detalle.ROT_ContenedorPies = pPies;
            //detalle.User = User.Identity.Name;
            //detalle.ROT_Item = Convert.ToInt32(ddlMantTipo.SelectedValue);
            //objTPL.Registrar_SolicitudTransporteContenedor(detalle);

            //LlenarGrilla();

            CargarDetalle();
        }
        catch (Exception ex) {
            MostrarMensaje(1,ex.Message);
        }
    }

    public void MostrarMensaje(int error, string mensaje)
    {
        if (error == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert_" + DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('Ok','" + mensaje + "','success');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert_" + DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('Error','" + mensaje + "','error');", true);
        }
    }

    protected void lnkbtn_Click(object sender, EventArgs e)
    {
        int rou, soli;//, conte;
        string enti;//, cli;// zona, seguimi;

        rou = Convert.ToInt32(hfsol.Value);
        soli = Convert.ToInt32(hfSoli.Value);
        //nombcont = lblcotnomb.Text;
        //if (lblcot.Text == "")
        //    conte = 0;
        //else 
        //    conte = Convert.ToInt32(lblcot.Text);


        //cli = lblcliente.Text;
        //string entidadser = Convert.ToString(Request.QueryString["Enti"]);

        //if (Request.QueryString["Enti"] != "") {
        //    if (Request.QueryString["Enti"] == "ANTARES LOGISTICS S.A.C." || Request.QueryString["Enti"] == "ANTARE")
        //        enti = "ANTARE";
        //    else if (Request.QueryString["Enti"] == "ANTARES ADUANAS S.A.C." || Request.QueryString["Enti"] == "ANDUAA")
        //        enti = "ANDUAA";
        //    else if (Request.QueryString["Enti"] == "CONTRANS S.A.C." || Request.QueryString["Enti"] == "COTRSA")
        //        enti = "COTRSA";
        //    else if (Request.QueryString["Enti"] == "TRANSPORTES MERIDIAN S.A.C." || Request.QueryString["Enti"] == "MERIDI")
        //        enti = "MERIDI";
        //    else
        //        MostrarMensaje(1, "Error, no se encuentra Código Entidad.");

        //}
        //else {
        //    enti = Request.QueryString["empresa"];
        //}

        //seguimi = Request.QueryString("Segui");
        //zona = objClsOperaciones.GetLocal(rou, conte, lblcliente.Text, enti);
        //for (int i = 0; i < grvContenedores.Rows.Count - 1; i++) {
        //    if (CType(grvContenedores.Rows(i).Cells(0).FindControl("chkSelect"), CheckBox).Checked) {
        //        Response.Redirect("ServiciosContenedor.aspx?Id=Servicios&Sol=" & rou & "&RO=" & soli & "&Cont=" _
        //                          & conte & "&NomCont=" & nombcont & "&Zon=" & zona & "&clie=" & cli & "&empresa=" & enti & "&Segui=" & seguimi)
        //    }
        //    else
        //        MostrarMensaje(1, "Seleccione un contenedor.");
        //}
    }


    protected void grvContenedores_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();

            GridViewRow rowEvento = (GridViewRow)e.Row.Cells[12].NamingContainer;
            DropDownList ddlEvento = (DropDownList)rowEvento.FindControl("ddlEvento");

            ddlEvento.ClearSelection();

            if (ddlEvento.DataSource == null)
            {

                ddlEvento.DataSource = oSeguimiento.GetEvento();
                ddlEvento.DataTextField = "EVENTO_DESCRIPCION";
                ddlEvento.DataValueField = "EVENTO_CODIGO";
                ddlEvento.DataBind();
            }

            ddlEvento.SelectedValue = ((Label)rowEvento.FindControl("lblNum")).Text;

            //GridViewRow rowTipo = (GridViewRow)e.Row.Cells[4].NamingContainer;
            //DropDownList ddlTipo = (DropDownList)rowTipo.FindControl("ddlTipo");

            //if (ddlTipo.DataSource == null)
            //{
            //    ddlTipo.ClearSelection();
            //    ddlTipo.DataSource = oSeguimiento.ListarTipoCont(Convert.ToInt32(e.Row.Cells[2].FindControl("lblItemROAL").ToString()));
            //    ddlTipo.DataTextField = "Bic_Tcnt";
            //    ddlTipo.DataValueField = "Bic_Tcnt";
            //    ddlTipo.DataBind();
            //}

        }
    }

    protected void grvContenedores_RowEditing(object sender, GridViewEditEventArgs e)
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();

        grvContenedores.EditIndex = e.NewEditIndex;
        string roal = "";

        for (int i = 0; i < grvSolicitudes.Rows.Count; i++)
        {
            roal = grvSolicitudes.Rows[i].Cells[1].Text + "," + roal;
        }
        roal = roal.Substring(0, roal.Length - 1);
        tabla = oSeguimiento.GetContenedoresSeguimiento(roal);
        grvContenedores.DataSource = tabla;
        grvContenedores.DataBind();

        DropDownList ddlTip = (DropDownList)grvContenedores.Rows[e.NewEditIndex].FindControl("ddlTipo");

        ddlTip.Items.Clear();
        ddlTip.Items.Add(new ListItem("HC", "HC"));
        ddlTip.Items.Add(new ListItem("ST", "ST"));
        ddlTip.Items.Add(new ListItem("RH", "RH"));
        ddlTip.Items.Add(new ListItem("RF", "RF"));
        
        
    }

    protected void grvContenedores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();

        grvContenedores.EditIndex = -1;
        string roal = "";
        for (int i = 0; i < grvSolicitudes.Rows.Count; i++)
        {
            roal = grvSolicitudes.Rows[i].Cells[1].Text + "," + roal;
        }

        roal = roal.Substring(0, roal.Length - 1);
        tabla = oSeguimiento.GetContenedoresSeguimiento(roal);
        grvContenedores.DataSource = tabla;
        grvContenedores.DataBind();
    }

    protected void grvContenedores_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] arg = new string[5];
        arg = e.CommandArgument.ToString().Split(';');
        switch (e.CommandName.ToString())
        {
            case "Asignar":

                Limpiar();
                limpiar2();

                getSeguimiento(arg[4], arg[0], arg[3]);

                lblTittle.Text = arg[0].ToString();
                hfContenedor.Value = arg[0].ToString();
                hfFechaSoli.Value = arg[1].ToString();
                //hfEvento.Value = arg[2].ToString();
                hfAL.Value = arg[3].ToString();
                hfMovimiento.Value = "I"; //revisar

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalAsignacion').modal('show');", true);
                //hfAction.Value = "SEGUIMIENTO";

                break;
            case "Eliminar":
                hfAL.Value = arg[0].ToString();
                hfContenedor.Value = arg[1].ToString();
                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalConfirmarEliminarContenedor').modal('show');", true);
                
                break;
            default:
                break;
        }
    }

    //[System.Web.Services.WebMethod()]
    protected void btnGuardarAsignacion_Click(object sender, EventArgs e)
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
        TMS_NotificacionesBL oNotificaciones = new TMS_NotificacionesBL();

        int AL = 0, item = 0, solicitud = 0, pies = 0, pernocte;
        string movimiento = "", itemTipo = "", ent1 = "";

        string msjHTML = "";
        string msjHTML2 = "";

        foreach (GridViewRow gvr in grvContenedores.Rows)
        {
            Label lblContenedor = (Label)gvr.FindControl("lblContenedor");


            if (lblContenedor.Text == lblTittle.Text)
            {
                Label lblAL = (Label)gvr.FindControl("lblItemROAL");
                Label lblItem = (Label)gvr.FindControl("lblItem");
                Label lblTipo = (Label)gvr.FindControl("lblItemTipo");
                Label lblPies = (Label)gvr.FindControl("lblItemPies");
                Label lblSolicitud = (Label)grvSolicitudes.FindControl("lblSolicitud");
                DropDownList ddlEvento = (DropDownList)gvr.FindControl("ddlEvento");


                AL = Convert.ToInt32(lblAL.Text);
                item = Convert.ToInt32(lblItem.Text);
                itemTipo = lblTipo.Text;
                pies = Convert.ToInt32(lblPies.Text);
                hfEvento.Value = ddlEvento.SelectedValue;
                break;
            }
            else
            {
                continue;
            }
            //MostrarMensaje(1, "El contenedor seleccionado no coincide con el consultado.");
        }

        int codigo = 1;
        if (dtpClienteLlegadaFecha.Text != "")
        {
            if (hfFechaSoli.Value == "0" && hfEvento.Value == "0")
            {
                if (dtpClienteLlegadaFecha.Text != "")
                {
                    if (Convert.ToDateTime(hfFechaSoli) < Convert.ToDateTime(dtpClienteLlegadaFecha.Text))
                    {
                        msjHTML += "<li>Fecha de Ingreso al Cliente diferente a Fecha de Cita, No se envio correo y los datos no fueron registrados</li>";
                        codigo = 0;
                    }
                }
            }
            //if (Convert.ToDateTime(hfFechaSoli) != null && hfEvento.Value == "0"){
            //    if (dtpClienteLlegadaFecha.Text != "")
            //    {
            //        if (Convert.ToDateTime(pHora) < CDate(CDate(llegadaCliente).ToShortTimeString()))
            //        {
            //            msjHTML += "<li>Hora de Ingreso al Cliente diferente a Hora de Cita, Si se envio correo y los datos fueron registrados</li>";
            //            codigo = 1;
            //        }
            //    }
            //}
        }

        if (chkPernocteInfo.Checked)
        {
            if (dtpClienteLlegadaFecha.Text == "" || dtpClienteSalidaFecha.Text == "") {
                msjHTML += "<li>Ingrese la Llegada y/o Salida del Cliente para el Pernocte, No se envio correo y los datos no fueron registrados</li>";
                codigo = 0;
            }
            if (hfTipSol.Value == "4") { // Or dobleCarga = 1
                //if (llegadaCliente2 = "" Or salidaCliente2 = ""){
                //    msjHTML += "<li>Ingrese la Llegada y/o Salida del Cliente para el Pernocte, No se envio correo y los datos no fueron registrados</li>";
                //    codigo = 0;
                //}
                //if (IsDate(salidaCliente2) And IsDate(llegadaCliente2)){
                //    if (CDate(salidaCliente2) <= CDate(llegadaCliente2))
                //    {
                //        msjHTML += "<li>Para que exista Pernocte la Fecha de Salida debe ser mayor a la Fecha de Llegada, No se envio correo y los datos no fueron registrados</li>";
                //        codigo = 0;
                //    }
                //}
            }

            if (dtpClienteSalidaFecha.Text != "" && dtpClienteLlegadaFecha.Text != "") {
                if (Convert.ToDateTime(dtpClienteSalidaFecha.Text) <= Convert.ToDateTime(dtpClienteLlegadaFecha.Text))
                {
                    msjHTML += "<li>Para que exista Pernocte la Fecha de Salida debe ser mayor a la Fecha de Llegada, No se envio correo y los datos no fueron registrados</li>";
                    codigo = 0;
                }
            }
        }
        if (msjHTML != "")
        {
            MostrarMensaje(1, msjHTML);
        }
        else {
            //Proceso Registrar Seguimiento
            try
            {
                TMS_SeguimientoEL SeguimientoEL = new TMS_SeguimientoEL();
                SeguimientoEL.Usuario = "";
                SeguimientoEL.FechaLlTR = ""; SeguimientoEL.FechaInTR = ""; SeguimientoEL.FechaSaTR = "";
                SeguimientoEL.HoraLlTR = ""; SeguimientoEL.HoraInTR = ""; SeguimientoEL.HoraSaTR = "";
                SeguimientoEL.FechaLlCL1 = ""; SeguimientoEL.FechaIngCL1 = ""; SeguimientoEL.FechaInCL1 = ""; SeguimientoEL.FechaTeCL1 = ""; SeguimientoEL.FechaSaCL1 = "";
                SeguimientoEL.HoraLlCL1 = ""; SeguimientoEL.HoraIngCL1 = ""; SeguimientoEL.HoraInCL1 = ""; SeguimientoEL.HoraTeCL1 = ""; SeguimientoEL.HoraSaCL1 = "";
                SeguimientoEL.FechaLlTD = ""; SeguimientoEL.FechaInTD = ""; SeguimientoEL.FechaSaTD = "";
                SeguimientoEL.HoraLlTD = ""; SeguimientoEL.HoraInTD = ""; SeguimientoEL.HoraSaTD = "";
                
                string mensaje = "", pEstado = "";

                pEstado = SacarEstadoWS(dtpRetiroSalidaFecha.Text, dtpRetiroIngresoFecha.Text, dtpRetiroLlegadaFecha.Text, dtpClienteSalidaFecha.Text, /* txtFecSalCli2,
                                         txtFecTerCli2,  txtFecIniCli2,  txtFecIngCli2,  txtFecLleCli2,*/ dtpClienteTerminoFecha.Text, dtpClienteInicioFecha.Text,
                                         dtpClienteIngresoFecha.Text, dtpClienteLlegadaFecha.Text, dtpDevolucionSalidaFecha.Text, dtpDevolucionIngresoFecha.Text, dtpDevolucionLlegadaFecha.Text);

                //pArray = HttpContext.Current.Cache("Lista")

                solicitud = Convert.ToInt32(grvSolicitudes.Rows[0].Cells[1].Text.Trim());
                movimiento = grvSolicitudes.Rows[0].Cells[3].Text;
                ent1 = grvSolicitudes.Rows[0].Cells[4].Text;
                //string Cliente = grvSolicitudes.Rows[0].Cells[7].Text;
                string CodCliente = grvSolicitudes.Rows[0].Cells[6].Text;
                
                if (dtpRetiroLlegadaFecha.Text.Trim() == "" ) { SeguimientoEL.FechaLlTR = "01/01/1900"; SeguimientoEL.HoraLlTR = "00:00"; } else { SeguimientoEL.FechaLlTR = dtpRetiroLlegadaFecha.Text; SeguimientoEL.HoraLlTR = txtRetiroLlegadaHora.Text; }
                if (dtpRetiroIngresoFecha.Text.Trim() == "" ) { SeguimientoEL.FechaInTR = "01/01/1900"; SeguimientoEL.HoraInTR = "00:00"; } else { SeguimientoEL.FechaInTR = dtpRetiroIngresoFecha.Text; SeguimientoEL.HoraInTR = txtRetiroIngresoHora.Text; }
                if (dtpRetiroSalidaFecha.Text.Trim() == "" ) { SeguimientoEL.FechaSaTR = "01/01/1900"; SeguimientoEL.HoraSaTR = "00:00"; } else { SeguimientoEL.FechaSaTR = dtpRetiroSalidaFecha.Text; SeguimientoEL.HoraSaTR = txtRetiroSalidaHora.Text; }

                if (dtpClienteLlegadaFecha.Text.Trim() == "" ) { SeguimientoEL.FechaLlCL1 = "01/01/1900"; SeguimientoEL.HoraLlCL1 = "00:00"; } else { SeguimientoEL.FechaLlCL1 = dtpClienteLlegadaFecha.Text; SeguimientoEL.HoraLlCL1 = txtClienteLlegadaHora.Text; }
                if (dtpClienteIngresoFecha.Text.Trim() == "" ) { SeguimientoEL.FechaIngCL1 = "01/01/1900"; SeguimientoEL.HoraIngCL1 = "00:00"; } else { SeguimientoEL.FechaIngCL1 = dtpClienteIngresoFecha.Text; SeguimientoEL.HoraIngCL1 = txtClienteIngresoHora.Text; }
                if (dtpClienteInicioFecha.Text.Trim() == "" ) { SeguimientoEL.FechaInCL1 = "01/01/1900"; SeguimientoEL.HoraInCL1 = "00:00"; } else { SeguimientoEL.FechaInCL1 = dtpClienteInicioFecha.Text; SeguimientoEL.HoraInCL1 = txtClienteInicioHora.Text; }
                if (dtpClienteTerminoFecha.Text.Trim() == "" ) { SeguimientoEL.FechaTeCL1 = "01/01/1900"; SeguimientoEL.HoraTeCL1 = "00:00"; } else { SeguimientoEL.FechaTeCL1 = dtpClienteTerminoFecha.Text; SeguimientoEL.HoraTeCL1 = txtClienteTerminoHora.Text; }
                if (dtpClienteSalidaFecha.Text.Trim() == "" ) { SeguimientoEL.FechaSaCL1 = "01/01/1900"; SeguimientoEL.HoraSaCL1 = "00:00"; } else { SeguimientoEL.FechaSaCL1 = dtpClienteSalidaFecha.Text; SeguimientoEL.HoraSaCL1 = txtClienteSalidaHora.Text; }

                //if (llegadaCliente2.Trim() == "") { LleCli2 = "01/01/1900 00:00" ; } else { LleCli2 = llegadaCliente2; }
                //if (ingresoCliente2.Trim() == "") { IngCli2 = "01/01/1900 00:00" ; } else { IngCli2 = ingresoCliente2; }
                //if (inicioCliente2.Trim() == "") { IniCar2 = "01/01/1900 00:00" ; } else { IniCar2 = inicioCliente2; }
                //if (terminoCliente2.Trim() == "") { TerCar2 = "01/01/1900 00:00" ; } else { TerCar2 = terminoCliente2; }
                //if (salidaCliente2.Trim() == "") { SalCli2 = "01/01/1900 00:00" ; } else { SalCli2 = salidaCliente2; }

                if (dtpDevolucionLlegadaFecha.Text.Trim() == "" ) { SeguimientoEL.FechaLlTD = "01/01/1900"; SeguimientoEL.HoraLlTD = "00:00"; } else { SeguimientoEL.FechaLlTD = dtpDevolucionLlegadaFecha.Text; SeguimientoEL.HoraLlTD = txtDevolucionLlegadaHora.Text; }
                if (dtpDevolucionIngresoFecha.Text.Trim() == "" ) { SeguimientoEL.FechaInTD = "01/01/1900"; SeguimientoEL.HoraInTD = "00:00"; } else { SeguimientoEL.FechaInTD = dtpDevolucionIngresoFecha.Text; SeguimientoEL.HoraInTD = txtDevolucionIngresoHora.Text; }
                if (dtpDevolucionSalidaFecha.Text.Trim() == "" ) { SeguimientoEL.FechaSaTD = "01/01/1900"; SeguimientoEL.HoraSaTD = "00:00"; } else { SeguimientoEL.FechaSaTD = dtpDevolucionSalidaFecha.Text; SeguimientoEL.HoraSaTD = txtDevolucionSalidaHora.Text; }

                SeguimientoEL.Usuario = User.Identity.Name;

                //List<TMS_SeguimientoEL> lst = oSeguimiento.GetSeguimiento(AL, lblTittle.Text, item);

                List<TMS_NotificacionesEL> lstNotificaciones = oNotificaciones.ListarNotificacionesXCliente(ent1, movimiento);

                int flag = 0;

                if (dtpDevolucionSalidaFecha.Text.Trim() != "" && txtDevolucionSalidaHora.Text.Trim() != "" && lstNotificaciones[0].Ntf_DSalida == true) { flag += 1; }
                else if (dtpDevolucionIngresoFecha.Text.Trim() != "" && txtDevolucionIngresoHora.Text.Trim() != "" && lstNotificaciones[0].Ntf_DIngreso == true) { flag += 1; }
                else if (dtpDevolucionLlegadaFecha.Text.Trim() != "" && txtDevolucionLlegadaHora.Text.Trim() != "" && lstNotificaciones[0].Ntf_DLlegada == true) { flag += 1; }

                else if (dtpClienteSalidaFecha.Text.Trim() != "" && txtClienteSalidaHora.Text.Trim() != "" && lstNotificaciones[0].Ntf_CSalida == true) { flag += 1; }
                else if (dtpClienteTerminoFecha.Text.Trim() != "" && txtClienteTerminoHora.Text.Trim() != "" && lstNotificaciones[0].Ntf_CTermino == true) { flag += 1; }
                else if (dtpClienteInicioFecha.Text.Trim() != "" && txtClienteInicioHora.Text.Trim() != "" && lstNotificaciones[0].Ntf_CInicio == true) { flag += 1; }
                else if (dtpClienteIngresoFecha.Text.Trim() != "" && txtClienteIngresoHora.Text.Trim() != "" && lstNotificaciones[0].Ntf_CIngreso == true) { flag += 1; }
                else if (dtpClienteLlegadaFecha.Text.Trim() != "" && txtClienteLlegadaHora.Text.Trim() != "" && lstNotificaciones[0].Ntf_CLlegada == true) { flag += 1; }

                else if (dtpRetiroSalidaFecha.Text.Trim() != "" && txtRetiroSalidaHora.Text.Trim() != "" && lstNotificaciones[0].Ntf_RSalida == true) { flag += 1; }
                else if (dtpRetiroIngresoFecha.Text.Trim() != "" && txtRetiroIngresoHora.Text.Trim() != "" && lstNotificaciones[0].Ntf_RIngreso == true) { flag += 1; }
                else if (dtpRetiroLlegadaFecha.Text.Trim() != "" && txtRetiroLlegadaHora.Text.Trim() != "" && lstNotificaciones[0].Ntf_RLlegada == true) { flag += 1; }

                else { flag = -1; }

                if (codigo == 1) {

                    if (chkPernocteInfo.Checked == true)
                    {
                        pernocte = 1;
                    }
                    else
                    {
                        pernocte = 0;
                    }

                    mensaje = oSeguimiento.Proceso1(AL, item, movimiento, solicitud, 1, lblTittle.Text, itemTipo, pies, Convert.ToInt32(ddlUnidadInfo.SelectedValue), ddlUnidadInfo.SelectedItem.ToString(),
                                                    Convert.ToInt32(ddlChoferInfo.SelectedValue),ddlChoferInfo.SelectedItem.ToString(), Convert.ToInt32(ddlEmpresaInfo.SelectedValue),
                                                    Convert.ToInt32(hfEvento.Value), 
                                                    ddlTerminalRetiro.SelectedValue, Convert.ToDateTime(SeguimientoEL.FechaLlTR+" "+ SeguimientoEL.HoraLlTR),Convert.ToDateTime(SeguimientoEL.FechaInTR+" "+ SeguimientoEL.HoraInTR), Convert.ToDateTime(SeguimientoEL.FechaSaTR+" "+SeguimientoEL.HoraSaTR), txtRetiroObservacion.Text, ent1,
                                                    Convert.ToInt32(ddlClienteLocal.SelectedValue), Convert.ToDateTime(SeguimientoEL.FechaLlCL1+" "+ SeguimientoEL.HoraLlCL1), Convert.ToDateTime(SeguimientoEL.FechaIngCL1+" "+ SeguimientoEL.HoraIngCL1),Convert.ToDateTime(SeguimientoEL.FechaInCL1+" "+ SeguimientoEL.HoraInCL1), Convert.ToDateTime(SeguimientoEL.FechaTeCL1+" "+ SeguimientoEL.HoraTeCL1), Convert.ToDateTime(SeguimientoEL.FechaSaCL1+" "+ SeguimientoEL.HoraSaCL1), txtClienteObservacion.Text,
                                                    /*de aqui todo lo que va con el doble carga*/ "", 0, Convert.ToDateTime("01/01/1990"), Convert.ToDateTime("01/01/1990"),
                                                    Convert.ToDateTime("01/01/1990"), Convert.ToDateTime("01/01/1990"), Convert.ToDateTime("01/01/1990"), "",/*hasta aqui*/
                                                    ddlTerminalDevolucion.SelectedValue, Convert.ToDateTime(SeguimientoEL.FechaLlTD + " " + SeguimientoEL.HoraLlTD), Convert.ToDateTime(SeguimientoEL.FechaInTD + " " + SeguimientoEL.HoraInTD), Convert.ToDateTime(SeguimientoEL.FechaSaTD + " " + SeguimientoEL.HoraSaTD), txtObservacionDevolucion.Text,
                                                    txtPrecintoVacioInfo.Text, txtPrecintoAduanaInfo.Text, txtPrecintoLineaInfo.Text, txtPrecintoTransitoInfo.Text, pEstado,/*pernocte*/ pernocte, 0/*chk doble carga*/, SeguimientoEL.Usuario);

                    if(flag==1)
                        EnviarCorreoWS(AL.ToString(), item.ToString(), lstNotificaciones, CodCliente);
                }

                MostrarMensaje(0, "Asignación exitosa!");
            }
            catch (Exception ex)
            {
                MostrarMensaje(1, ex.Message); 
            }
        } 

    }

    public string SacarEstadoWS(string txtFecSalTerDI, string txtFecIngTerDI, string txtFecLlegTerDI, string txtFecSalCli, /*string txtFecSalCli2,
                              string txtFecTerCli2, string txtFecIniCli2, string txtFecIngCli2, string txtFecLleCli2,*/ string txtFecTerCli, string txtFecIniCli,
                              string txtFecIngCli, string txtFecLleCli, string txtFecSalTerRV, string txtFecIngTerRV, string txtFecLleTerRV)
    {
        string pEstado = "";
        if (dtpDevolucionSalidaFecha.Text.Trim() != "") {
            pEstado = "Servicio Concluido";
        }
        else if (dtpDevolucionIngresoFecha.Text.Trim() != "" && dtpDevolucionLlegadaFecha.Text.Trim() != "") {
            pEstado = "Completando Ruta";
        }
        else if (dtpClienteSalidaFecha.Text.Trim() != "") {
            //if (chkdoble == 1) {
            //    if (txtFecSalCli2<> " " Then
            //        pEstado = "Atendido y Retornando a Clx";
            //    ElseIf txtFecTerCli2<> " " Then
            //       pEstado = "Terminando Carga en 2° Local";
            //    ElseIf txtFecIniCli2<> " " Then
            //       pEstado = "Iniciando Carga en 2° Local";
            //    ElseIf txtFecIngCli2<> " " Then
            //       pEstado = "Atencion en 2° Local";
            //    ElseIf txtFecLleCli2<> " " Then
            //       pEstado = "En Espera de Atencion en 2° Local";
            //    Else
            //        pEstado = "Atendido en 1° Local Llendo a 2° Local";
            //    End If
            //}
            //else{
            pEstado = "Atendido y Retornando a Clx";
            //}
        }
        else if (dtpClienteTerminoFecha.Text.Trim() != "") {
            //if (chkdoble == 1)
            //{
            //    pEstado = "Termino Carga en 1° Local";
            //}
            //else
            //{
            pEstado = "Termino Carga";
            //}
        }
        else if (dtpClienteInicioFecha.Text.Trim() != "") {
            //    If chkdoble = 1 Then
            //        pEstado = "Inicio Carga en 1° Local"
            //    Else
            //        pEstado = "Inicio Carga"
            //    End If
            //ElseIf txtFecIngCli<> " " Then
            //   If chkdoble = 1 Then
            //       pEstado = "Atencion en 1° Local"
            //    Else
            //        pEstado = "Atencion en Cliente"
            //    End If
            //ElseIf txtFecLleCli<> " " Then
            //   If chkdoble = 1 Then
            //       pEstado = "En Espera de Atencion en 1° Local"
            //    Else
            //        pEstado = "En Espera de Atencion"
            //    End If
            //ElseIf txtFecSalTerRV<> " " Then
            //   pEstado = "En Ruta"
            //ElseIf txtFecIngTerRV<> " " Then
            //   pEstado = "En Cola"
            //ElseIf txtFecLleTerRV<> " " Then
            //   pEstado = "En Cola"
            //Else
            //    pEstado = "Asignacion"
        }
        return pEstado;
    }

    public void getSeguimiento(string kitem, string ctn, string ro) {

        try {

            TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
            List<TMS_SeguimientoEL> lst = oSeguimiento.GetSeguimiento(Convert.ToInt32(ro), ctn, Convert.ToInt32(kitem));

            if(ddlTerminalRetiro.Items.FindByValue(lst[0].Ter1) != null)
                ddlTerminalRetiro.SelectedValue = lst[0].Ter1.ToString();
            else
                ddlTerminalRetiro.SelectedIndex = 0;
            
            dtpRetiroLlegadaFecha.Text = lst[0].FechaLlTR.ToString();
            txtRetiroLlegadaHora.Text = lst[0].HoraLlTR.ToString();
            dtpRetiroIngresoFecha.Text = lst[0].FechaInTR.ToString();
            txtRetiroIngresoHora.Text = lst[0].HoraInTR.ToString();
            dtpRetiroSalidaFecha.Text = lst[0].FechaSaTR.ToString();
            txtRetiroSalidaHora.Text = lst[0].HoraSaTR.ToString();
            txtRetiroObservacion.Text = lst[0].ObsTR.ToString();

            if(ddlClienteLocal.Items.FindByValue(lst[0].Loc1.ToString()) != null)
                ddlClienteLocal.SelectedValue = lst[0].Loc1.ToString();
            else
                ddlClienteLocal.SelectedIndex = 0;

            dtpClienteLlegadaFecha.Text = lst[0].FechaLlCL1.ToString();
            txtClienteLlegadaHora.Text = lst[0].HoraLlCL1.ToString();
            dtpClienteIngresoFecha.Text = lst[0].FechaIngCL1.ToString();
            txtClienteIngresoHora.Text = lst[0].HoraIngCL1.ToString();
            dtpClienteInicioFecha.Text = lst[0].FechaInCL1.ToString();
            txtClienteInicioHora.Text = lst[0].HoraInCL1.ToString();
            dtpClienteTerminoFecha.Text = lst[0].FechaTeCL1.ToString();
            txtClienteTerminoHora.Text = lst[0].HoraTeCL1.ToString();
            dtpClienteSalidaFecha.Text = lst[0].FechaSaCL1.ToString();
            txtClienteSalidaHora.Text = lst[0].HoraSaCL1.ToString();
            txtClienteObservacion.Text = lst[0].ObsCL1.ToString();


            if (ddlTerminalDevolucion.Items.FindByValue(lst[0].Ter2) != null)
                ddlTerminalDevolucion.SelectedValue = lst[0].Ter2.ToString();
            else
                ddlTerminalDevolucion.SelectedIndex = 0;
            
            dtpDevolucionLlegadaFecha.Text = lst[0].FechaLlTD.ToString();
            txtDevolucionLlegadaHora.Text = lst[0].HoraLlTD.ToString();
            dtpDevolucionIngresoFecha.Text = lst[0].FechaInTD.ToString();
            txtDevolucionIngresoHora.Text = lst[0].HoraInTD.ToString(); 
            dtpDevolucionSalidaFecha.Text = lst[0].FechaSaTD.ToString();
            txtDevolucionSalidaHora.Text = lst[0].HoraSaTD.ToString();
            txtObservacionDevolucion.Text = lst[0].ObsTD.ToString();

            if (ddlEmpresaInfo.Items.FindByValue(lst[0].Empresa.ToString()) != null)
                ddlEmpresaInfo.SelectedValue = lst[0].Empresa.ToString();
            else
                ddlEmpresaInfo.SelectedIndex = 0;
            

            if (lst[0].Empresa.ToString() == "88") {
                CargarChofer(Convert.ToInt32(ddlEmpresaInfo.SelectedValue), lst[0].DNI_Chofer.ToString());
                CargarUnidadTransporte(Convert.ToInt32(ddlEmpresaInfo.SelectedValue), lst[0].UNIDAD_PLACA.ToString());
            }
            else {
                CargarChofer(Convert.ToInt32(ddlEmpresaInfo.SelectedValue), lst[0].Chofer.ToString());
                CargarUnidadTransporte(Convert.ToInt32(ddlEmpresaInfo.SelectedValue), lst[0].Unidad.ToString());
            }

            //if (lst[0].Empresa.ToString() == "88")
            //    ddlUnidadInfo.SelectedItem = lst[0].UNIDAD_PLACA.ToString();
            //else
            //    ddlUnidadInfo.SelectedIndex = 0;

            //if (ddlChoferInfo.Items.FindByValue(lst[0].Chofer.ToString()) != null)
            //    ddlChoferInfo.SelectedValue = lst[0].Chofer.ToString();
            //else
            //    ddlChoferInfo.SelectedIndex = 0;

            txtPrecintoVacioInfo.Text = lst[0].PreCtn.ToString();
            txtPrecintoLineaInfo.Text = lst[0].PreLin.ToString();
            txtPrecintoAduanaInfo.Text = lst[0].PreAdu.ToString();
            txtPrecintoTransitoInfo.Text = lst[0].PreTra.ToString();

            chkPernocteInfo.Checked = (lst[0].Pernoc == 1 ? true : false);

            //if (Convert.ToInt32(lst[53]) == 1)
            //{
            //    chkDobleCarga.Checked = true;
            //}
            //else
            //    chkDobleCarga.Checked = false;

            


        } catch (Exception ex) {
            MostrarMensaje(1, ex.Message);
        }

    }

    public void EnviarCorreoWS(string pRo, string pItem, List<TMS_NotificacionesEL> lstNotificaciones, string Cliente)
    {
        TMS_SeguimientoBL objClsOperaciones = new TMS_SeguimientoBL();
        string html = "";
        string pUsuario = User.Identity.Name;
        string path_html = Server.MapPath("~/Formatos/notificacion/alerta_monitoreo.html");
        if (File.Exists(path_html))
        {
            html = File.ReadAllText(path_html);
        }

        string pBodyCab = "", pBodyDetTR = "", pBodyDetC1 = "", pBodyDetC2 = "", pBodyDetTD = "",
            mensaje = "", Encabezado = "", pBody = "", pFrom = "", pCC = "", pEstado = "", pBodyPie = "", pBC = "";
        
        try
        {
            DataTable dtCorreo = objClsOperaciones.GetCorreo(); 
            DataTable pTabEnvio = objClsOperaciones.EnvioCorreo(Convert.ToInt32(pRo), Convert.ToInt32(pItem), Cliente);
            //DataTable pTabEnvio2 = objClsOperaciones.EnvioCorreo(Convert.ToInt32(pRo), Convert.ToInt32(pItem), Cliente);
            if (pTabEnvio.Rows.Count > 0) {

                StringBuilder tabla_head = new StringBuilder();
                StringBuilder tabla_row = new StringBuilder();
                pFrom = pTabEnvio.Rows[0]["Usuario"].ToString()+";";

                for (int i = 0; i < dtCorreo.Rows.Count; i++) {

                    string correo = dtCorreo.Rows[i]["Empr"].ToString();
                    if (correo == "TRANSP" || correo == pTabEnvio.Rows[0]["Emp"].ToString()) {
                        pCC = pCC + dtCorreo.Rows[i]["Mail"].ToString();
                    }
                    else if (correo == "SISTEM") {
                        pBC = pBC + dtCorreo.Rows[i]["Mail"].ToString();
                    }

                }

                //pCC = "";
                //pFrom = "";

                DataTable dtCorreoCliente = objClsOperaciones.GetCorreoCliente(pTabEnvio.Rows[0]["CodCli"].ToString(), pTabEnvio.Rows[0]["CodMov"].ToString());
                for (int j = 0; j < dtCorreoCliente.Rows.Count; j++)
                {
                    pFrom += dtCorreoCliente.Rows[j]["Mail_MC"].ToString() + ";";
                }

                TMS_EmailClienteBL oEmail = new TMS_EmailClienteBL();
                List<TMS_EmailClienteEL> lstMailClientes = oEmail.GetCorreoCliente(pTabEnvio.Rows[0]["Emp"].ToString(), pTabEnvio.Rows[0]["CodMov"].ToString());
                if (pTabEnvio.Rows[0]["Emp"].ToString().Trim() != pTabEnvio.Rows[0]["CodCli"].ToString().Trim())
                {
                    for (int k = 0; k < lstMailClientes.Count; k++)
                    {
                        pFrom += lstMailClientes[k].Mail_MC + ";";
                    }
                }

                //pCC = "elpoderdelamente2013@gmail.com;";


                TMS_NotificacionesBL oNotificaciones = new TMS_NotificacionesBL();
                List<TMS_NotificacionesEL> lstNoti = new List<TMS_NotificacionesEL>();
                lstNoti = oNotificaciones.ListarNotificacionesXCliente(pTabEnvio.Rows[0]["CodCli"].ToString(), pTabEnvio.Rows[0]["CodMov"].ToString());

                html = html.Replace("{cliente}", pTabEnvio.Rows[0]["Cliente"].ToString());
                
                //INICIO DE CABECERA
                tabla_head.AppendLine("<table class='label'>");
                tabla_head.AppendLine("<tr>");
                tabla_head.AppendLine("<td class='bg1'>Terminal Retiro</td>");
                tabla_head.AppendLine("<td class='bg1'>Movimiento</td>");
                tabla_head.AppendLine("<td class='bg1'>Contenedor</td>");
                tabla_head.AppendLine("<td class='bg1'>Cita</td>");
                tabla_head.AppendLine("<td class='bg1'>Placa</td>");
                tabla_head.AppendLine("<td class='bg1'>Conductor</td>");

                if (lstNoti.Count() > 0)
                {
                    //Terminal
                    if (lstNoti[0].Ntf_RLlegada)
                        tabla_head.AppendLine("<td class='bg1'>Llegada al terminal de retiro</td>");

                    if (lstNoti[0].Ntf_RIngreso)
                        tabla_head.AppendLine("<td class='bg1'>Ingreso al terminal de retiro</td>");

                    if (lstNoti[0].Ntf_RSalida)
                        tabla_head.AppendLine("<td class='bg1'>Salida del terminal de retiro</td>");

                    //Cliente 1
                    if (lstNoti[0].Ntf_CLlegada)
                        tabla_head.AppendLine("<td class='bg1'>Llegada al cliente</td>");

                    if (lstNoti[0].Ntf_CIngreso)
                        tabla_head.AppendLine("<td class='bg1'>Ingreso al cliente</td>");

                    if (lstNoti[0].Ntf_CInicio)
                        tabla_head.AppendLine("<td class='bg1'>Incio de descarga</td>");

                    if (lstNoti[0].Ntf_CTermino)
                        tabla_head.AppendLine("<td class='bg1'>Termino de descarga</td>");

                    if (lstNoti[0].Ntf_CSalida)
                        tabla_head.AppendLine("<td class='bg1'>Salida del cliente</td>");

                    //Vacios
                    if (lstNoti[0].Ntf_DLlegada)
                        tabla_head.AppendLine("<td class='bg1'>Llegada al terminal de devolución</td>");

                    if (lstNoti[0].Ntf_DIngreso)
                        tabla_head.AppendLine("<td class='bg1'>Ingreso al terminal de devolución</td>");

                    if (lstNoti[0].Ntf_DSalida)
                        tabla_head.AppendLine("<td class='bg1'>Salida del terminal de devolución</td>");

                }

                tabla_head.AppendLine("<td class='bg1'>Dirección</td>");
                tabla_head.AppendLine("<td class='bg1'>Observaciones</td>");
                tabla_head.AppendLine("</tr>");
                //FIN DE CABECERA

                //INICIO DE CONTENIDO
                for (int i = 0; i < pTabEnvio.Rows.Count; i++)
                {
                    tabla_head.AppendLine("<tr>");
                    tabla_head.AppendLine("<td>" + pTabEnvio.Rows[i]["TerminalR"].ToString() + "</td>");
                    tabla_head.AppendLine("<td>" + pTabEnvio.Rows[i]["Movimiento"].ToString() + "</td>");
                    tabla_head.AppendLine("<td>" + pTabEnvio.Rows[i]["Contenedor"].ToString() + "</td>");
                    tabla_head.AppendLine("<td>" + pTabEnvio.Rows[i]["Cita"].ToString() + "</td>");
                    tabla_head.AppendLine("<td>" + (pTabEnvio.Rows[i]["Placa"].ToString().Trim().ToLower() == "seleccione" ? "" : pTabEnvio.Rows[i]["Placa"].ToString().ToUpper()) + "</td>");
                    tabla_head.AppendLine("<td>" + (pTabEnvio.Rows[i]["Conductor"].ToString().Trim().ToLower() == "seleccione" ? "" : pTabEnvio.Rows[i]["Conductor"].ToString().ToUpper()) + "</td>");
                    if (lstNoti.Count() > 0)
                    {
                        //Terminal
                        if (lstNoti[0].Ntf_RLlegada)
                            tabla_head.AppendLine("<td>" + pTabEnvio.Rows[0]["FechaLlTR"] + "</td>");

                        if (lstNoti[0].Ntf_RIngreso)
                            tabla_head.AppendLine("<td>" + pTabEnvio.Rows[0]["FechaIgTR"] + "</td>");

                        if (lstNoti[0].Ntf_RSalida)
                            tabla_head.AppendLine("<td>" + pTabEnvio.Rows[0]["FechaSaTR"] + "</td>");

                        //Cliente 1
                        if (lstNoti[0].Ntf_CLlegada)
                            tabla_head.AppendLine("<td>" + pTabEnvio.Rows[0]["FechaLlC1"] + "</td>");

                        if (lstNoti[0].Ntf_CIngreso)
                            tabla_head.AppendLine("<td>" + pTabEnvio.Rows[0]["FechaIgC1"] + "</td>");

                        if (lstNoti[0].Ntf_CInicio)
                            tabla_head.AppendLine("<td>" + pTabEnvio.Rows[0]["FechaInC1"] + "</td>");

                        if (lstNoti[0].Ntf_CTermino)
                            tabla_head.AppendLine("<td>" + pTabEnvio.Rows[0]["FechaTeC1"] + "</td>");

                        if (lstNoti[0].Ntf_CSalida)
                            tabla_head.AppendLine("<td>" + pTabEnvio.Rows[0]["FechaSaC1"] + "</td>");

                        //Vacios
                        if (lstNoti[0].Ntf_DLlegada)
                            tabla_head.AppendLine("<td>" + pTabEnvio.Rows[0]["FechaLlTD"] + "</td>");

                        if (lstNoti[0].Ntf_DIngreso)
                            tabla_head.AppendLine("<td>" + pTabEnvio.Rows[0]["FechaIgTD"] + "</td>");

                        if (lstNoti[0].Ntf_DSalida)
                            tabla_head.AppendLine("<td>" + pTabEnvio.Rows[0]["FechaSaTD"] + "</td>");

                    }

                    tabla_head.AppendLine("<td>" + pTabEnvio.Rows[i]["Local1"].ToString() + "</td>");
                    tabla_head.AppendLine("<td>" + pTabEnvio.Rows[i]["ObsTR"].ToString() + (pTabEnvio.Rows[i]["ObsC1"].ToString()) + pTabEnvio.Rows[i]["ObsTD"].ToString() + "</td>");
                    tabla_head.AppendLine("</tr>");
                }
                //FIN DE CONTENIDO

                tabla_head.AppendLine("</table>");
                //CIERRE DE TABLA

                //INICIO DE PIE DE PAGINA
                html = html.Replace("{fecha}", DateTime.Today.ToShortDateString());
                html = html.Replace("{detalle}", tabla_head.ToString());
                //FIN DE PIE DE PAGINA

                //Dim i As String = pTabEnvio.Rows(0]["NSol")
                //Dim j As String = pTabEnvio.Rows(0]["DblCar")
                //if ((pTabEnvio.Rows[0]["NSol"].ToString() == "1") && (pTabEnvio.Rows[0]["DblCar"].ToString() == "0")) {
                //    pBody = pBody + pBodyDetTR + pBodyDetC1 + pBodyDetTD;
                //}
                //else if ((Convert.ToInt32(pTabEnvio.Rows[0]["NSol"]) == 1) && Convert.ToInt32(pTabEnvio.Rows[0]["DblCar"]) == 1) {
                //    pBody = pBody + pBodyDetTR + pBodyDetC1 + pBodyDetC2 + pBodyDetTD;
                //}
                //else if (Convert.ToInt32(pTabEnvio.Rows[0]["NSol"]) == 2) {
                //    pBody = pBody + pBodyDetTR + pBodyDetTD;
                //}
                //else if (Convert.ToInt32(pTabEnvio.Rows[0]["NSol"]) == 3 || Convert.ToInt32(pTabEnvio.Rows[0]["NSol"]) == 4) {
                //    pBody = pBody + pBodyDetC1 + pBodyDetC2;
                //}
                //else
                //{
                //    MostrarMensaje(1, "Error, informar a Sistemas.");
                //}

                //pBody = pBody + "</Tr></Table></Td></Tr></Table><bR>" + pBodyPie + "</body></html>";

                //objClsOperaciones.EnvioMail("fcamacho@meridian.com.pe", "", "", html, pTabEnvio.Rows[0]["Placa"].ToString(), pRo, pTabEnvio.Rows[0]["Cliente"].ToString());

                //objClsOperaciones.EnvioMail("fcamacho@meridian.com.pe", "", "", html, "ALERTA DE MONITOREO: " + pTabEnvio.Rows[0]["Placa"].ToString() + "//" + pTabEnvio.Rows[0]["Cliente"].ToString());

                objClsOperaciones.EnvioMail(pFrom, pCC, pBC, html, "ALERTA DE MONITOREO: " + pTabEnvio.Rows[0]["Placa"].ToString() + "//" + pTabEnvio.Rows[0]["Cliente"].ToString());

                //objClsOperaciones.EnvioMail("carlos.mejia@tmeridian.com.pe", "carlos.mejia@tmeridian.com.pe", "carlos.mejia@tmeridian.com.pe", pBody, pTabEnvio.Rows(0)("Placa"), pRo, pTabEnvio.Rows(0)("Cliente"))

                objClsOperaciones.ActualizarCorreo(Convert.ToInt32(pRo), Convert.ToInt32(pItem));

            }
            
        } catch (Exception ex)
        {
            MostrarMensaje(1, ex.Message);
        }
    }

    public void EnviarCorreoWS_backup(string pRo, string pItem, List<TMS_NotificacionesEL> lstNotificaciones)
    {
        TMS_SeguimientoBL objClsOperaciones = new TMS_SeguimientoBL();
        //string myMessage;
        string pUsuario = ObtenerDatosSesion("usuario");

        string pBodyCab = "", pBodyDetTR = "", pBodyDetC1 = "", pBodyDetC2 = "", pBodyDetTD = "",
            mensaje = "", Encabezado = "", pBody = "", pFrom = "", pCC = "", pEstado = "", pBodyPie = "", pBC = "";

        try
        {
            DataTable dtCorreo = objClsOperaciones.GetCorreo();
            DataTable pTabEnvio = objClsOperaciones.EnvioCorreo(Convert.ToInt32(pRo), Convert.ToInt32(pItem),"");
            if (pTabEnvio.Rows.Count > 0)
            {
                pFrom = pTabEnvio.Rows[0]["Usuario"].ToString() + ";";

                for (int i = 0; i < dtCorreo.Rows.Count; i++)
                {

                    string correo = dtCorreo.Rows[i]["Empr"].ToString();
                    if (correo == "TRANSP" || correo == pTabEnvio.Rows[0]["Emp"].ToString())
                    {
                        pCC = pCC + dtCorreo.Rows[i]["Mail"].ToString();
                    }
                    else if (correo == "SISTEM")
                    {
                        pBC = pBC + dtCorreo.Rows[i]["Mail"].ToString();
                    }

                }

                //pCC = "";
                //pFrom = "";

                DataTable dtCorreoCliente = objClsOperaciones.GetCorreoCliente(pTabEnvio.Rows[0]["CodCli"].ToString(), pTabEnvio.Rows[0]["CodMov"].ToString());
                for (int j = 0; j < dtCorreoCliente.Rows.Count; j++)
                {
                    pFrom += dtCorreoCliente.Rows[j]["Mail_MC"].ToString() + ";";
                }

                TMS_EmailClienteBL oEmail = new TMS_EmailClienteBL();
                List<TMS_EmailClienteEL> lstMailClientes = oEmail.GetCorreoCliente(pTabEnvio.Rows[0]["Emp"].ToString(), pTabEnvio.Rows[0]["CodMov"].ToString());
                //oEmail.GetCorreoCliente(pTabEnvio.Rows[0]["CodCli"].ToString());
                for (int k = 0; k < lstMailClientes.Count; k++)
                {
                    pFrom += lstMailClientes[k].Mail_MC + ";";
                }

                //pCC = "elpoderdelamente2013@gmail.com;";


                TMS_NotificacionesBL oNotificaciones = new TMS_NotificacionesBL();
                List<TMS_NotificacionesEL> lstNoti = new List<TMS_NotificacionesEL>();
                lstNoti = oNotificaciones.ListarNotificacionesXCliente(pTabEnvio.Rows[0]["CodCli"].ToString(), pTabEnvio.Rows[0]["CodMov"].ToString());

                Encabezado = "Seguimiento Asignado al Routing Order AL" + pRo;
                pBodyCab = "<Table width='100%' border='0' bordercolor='#3D9BDA' cellspacing='0' " +
                           "style='font-family: MS Sans Serif; font-size: xx-small ; color: #006699'>" +
                            "<Tr bgcolor='#DBE5F1'><Td><b>Movimiento</b></Td><Td>" + pTabEnvio.Rows[0]["Movimiento"] + "</Td></Tr>" +
                            "<Tr><Td width='20%'><b>Transportista</b></Td><Td>" + pTabEnvio.Rows[0]["Empresa"] + "</Td></Tr>" +
                            "<Tr bgcolor='#DBE5F1'><Td><b>Cliente</b></Td><Td>" + pTabEnvio.Rows[0]["Cliente"] + "</Td></Tr>" +
                            "<Tr><Td><b>Conductor</b></Td><Td>" + pTabEnvio.Rows[0]["Conductor"] + "</Td></Tr>" +
                            "<Tr bgcolor='#DBE5F1'><Td><b>Placa</b></Td><Td>" + pTabEnvio.Rows[0]["Placa"] + "</Td></Tr>" +
                            "<Tr><Td><b>Routing</b></Td><Td>" + pTabEnvio.Rows[0]["RO/Al"] + "</Td></Tr>" +
                            "<Tr bgcolor='#DBE5F1'><Td><b>Ref. SINTAD</b></Td><Td>" + pTabEnvio.Rows[0]["Sintad"] + "</Td></Tr>" +
                            "<Tr><Td><b>Booking</b></Td><Td>" + pTabEnvio.Rows[0]["Booking"] + "</Td></Tr>" +
                            "<Tr bgcolor='#DBE5F1'><Td><b>Cita</b></Td><Td>" + pTabEnvio.Rows[0]["Cita"] + "</Td></Tr>" +
                            "<Tr><Td><b>Contenedor</b></Td><Td>" + pTabEnvio.Rows[0]["Contenedor"] + "</Td></Tr>" +
                            "<Tr bgcolor='#DBE5F1'><Td><b>Tara</b></Td><Td>" + pTabEnvio.Rows[0]["Tara"] + "</Td></Tr>" +
                            "<Tr><Td><b>Payload</b></Td><Td>" + pTabEnvio.Rows[0]["Pyload"] + "</Td></Tr>" +
                            "<Tr bgcolor='#DBE5F1'><Td><b>Precinto CTN</b></Td><Td>" + pTabEnvio.Rows[0]["PreCtn"] + "</Td></Tr>" +
                            "<Tr><Td><b>Precinto Transito</b></Td><Td>" + pTabEnvio.Rows[0]["PreTra"] + "</Td></Tr>" +
                            "<Tr bgcolor='#DBE5F1'><Td><b>Precinto Linea</b></Td><Td>" + pTabEnvio.Rows[0]["PreLin"] + "</Td></Tr>" +
                            "<Tr><Td><b>Precinto Aduana</b></Td><Td>" + pTabEnvio.Rows[0]["PreAdu"] + "</Td></Tr>" +
                            "<Tr bgcolor='#DBE5F1'><Td><b>Estado</b></Td><Td>" + pTabEnvio.Rows[0]["Estado"] + "</Td></Tr>" +
                            "<Tr><Td><b>Pernocte</b></Td><Td>" + pTabEnvio.Rows[0]["Pernoc"] + "</Td></Tr>" +
                            "<Tr bgcolor='#DBE5F1'><Td><b>Tipo de Transporte</b></Td><Td>" + pTabEnvio.Rows[0]["TSol"] + "</Td></Tr>" +
                            "<Tr><Td colspan='2'><Table width='100%' style='border:1px solid #006699'cellspacing='0'><Tr>";



                pBodyDetTR = "<Td valign='Top' style='border-right:1px solid #006699'>" +
                                "<Table width='100%' cellspacing='0' " +
                                "style='font-family: MS Sans Serif; font-size: xx-small ; color: #006699'>" +
                                "<Tr><Td><b>Terminal</b></Td><Td>" + pTabEnvio.Rows[0]["TerminalR"] + "</Td></Tr>" +
                                "<Tr bgcolor='#DBE5F1'><Td><b>+nbsp</b></Td><Td>+nbsp</Td></Tr>";
                if (lstNoti[0].Ntf_RLlegada == true)
                {
                    pBodyDetTR += "<Tr><Td><b>Llegada</b></Td><Td>" + pTabEnvio.Rows[0]["FechaLlTR"] + "</Td></Tr>";
                }
                else
                {
                    pBodyDetTR += "<Tr><Td><b>Llegada</b></Td><Td>" + "</Td></Tr>";
                }

                if (lstNoti[0].Ntf_RIngreso == true)
                    pBodyDetTR += "<Tr bgcolor='#DBE5F1'><Td><b>Ingreso</b></Td><Td>" + pTabEnvio.Rows[0]["FechaIgTR"] + "</Td></Tr>";
                else
                    pBodyDetTR += "<Tr bgcolor='#DBE5F1'><Td><b>Ingreso</b></Td><Td>" + "</Td></Tr>";

                if (lstNoti[0].Ntf_RSalida == true)
                    pBodyDetTR += "<Tr><Td><b>Salida</b></Td><Td>" + pTabEnvio.Rows[0]["FechaSaTR"] + "</Td></Tr>";
                else
                    pBodyDetTR += "<Tr><Td><b>Salida</b></Td><Td>" + "</Td></Tr>";

                pBodyDetTR += "<Tr bgcolor='#DBE5F1'><Td><b>+nbsp</b></Td><Td>+nbsp</Td></Tr>" +
                            "<Tr><Td><b>Observacion</b></Td><Td>" + pTabEnvio.Rows[0]["ObsTR"] + "</Td></Tr>" +
                            "</Table>" +
                           "</Td>";


                pBodyDetC1 = "<Td valign='Top' style='border-right:1px solid #006699'>" +
                              "<Table width='100%' cellspacing='0' " +
                              "style='font-family: MS Sans Serif; font-size: xx-small ; color: #006699'>" +
                               "<Tr><Td><b>Local del Cliente</b></Td><Td>" + pTabEnvio.Rows[0]["Local1"] + "</Td></Tr>";
                if (lstNoti[0].Ntf_CLlegada == true)
                    pBodyDetC1 += "<Tr bgcolor='#DBE5F1'><Td><b>Llegada</b></Td><Td>" + pTabEnvio.Rows[0]["FechaLlC1"] + "</Td></Tr>";
                else
                    pBodyDetC1 += "<Tr bgcolor='#DBE5F1'><Td><b>Llegada</b></Td><Td>" + "</Td></Tr>";

                if (lstNoti[0].Ntf_CIngreso == true)
                    pBodyDetC1 += "<Tr><Td><b>Ingreso</b></Td><Td>" + pTabEnvio.Rows[0]["FechaIgC1"] + "</Td></Tr>";
                else
                    pBodyDetC1 += "<Tr><Td><b>Ingreso</b></Td><Td>" + "</Td></Tr>";

                if (lstNoti[0].Ntf_CInicio == true)
                    pBodyDetC1 += "<Tr bgcolor='#DBE5F1'><Td><b>Inicio</b></Td><Td>" + pTabEnvio.Rows[0]["FechaInC1"] + "</Td></Tr>";
                else
                    pBodyDetC1 += "<Tr bgcolor='#DBE5F1'><Td><b>Inicio</b></Td><Td>" + "</Td></Tr>";

                if (lstNoti[0].Ntf_CTermino == true)
                    pBodyDetC1 += "<Tr><Td><b>Termino</b></Td><Td>" + pTabEnvio.Rows[0]["FechaTeC1"] + "</Td></Tr>";
                else
                    pBodyDetC1 += "<Tr><Td><b>Termino</b></Td><Td>" + "</Td></Tr>";

                if (lstNoti[0].Ntf_CSalida == true)
                    pBodyDetC1 += "<Tr bgcolor='#DBE5F1'><Td><b>Salida</b></Td><Td>" + pTabEnvio.Rows[0]["FechaSaC1"] + "</Td></Tr>";
                else
                    pBodyDetC1 += "<Tr bgcolor='#DBE5F1'><Td><b>Salida</b></Td><Td>" + "</Td></Tr>";

                pBodyDetC1 += "<Tr><Td><b>Observacion</b></Td><Td>" + pTabEnvio.Rows[0]["ObsC1"] + "</Td></Tr>" +
                            "</Table>" +
                           "</Td>";



                pBodyDetC2 = "<Td valign='Top' style='border-right:1px solid #006699'>" +
                              "<Table width='100%' cellspacing='0' " +
                              "style='font-family: MS Sans Serif; font-size: xx-small ; color: #006699'>" +
                               "<Tr><Td><b>Local del Cliente</b></Td><Td>" + pTabEnvio.Rows[0]["Local2"] + "</Td></Tr>" +
                               "<Tr bgcolor='#DBE5F1'><Td><b>Llegada</b></Td><Td>" + pTabEnvio.Rows[0]["FechaLlC2"] + "</Td></Tr>" +
                               "<Tr><Td><b>Ingreso</b></Td><Td>" + pTabEnvio.Rows[0]["FechaIgC2"] + "</Td></Tr>" +
                               "<Tr bgcolor='#DBE5F1'><Td><b>Inicio</b></Td><Td>" + pTabEnvio.Rows[0]["FechaInC2"] + "</Td></Tr>" +
                               "<Tr><Td><b>Termino</b></Td><Td>" + pTabEnvio.Rows[0]["FechaTeC2"] + "</Td></Tr>" +
                               "<Tr bgcolor='#DBE5F1'><Td><b>Salida</b></Td><Td>" + pTabEnvio.Rows[0]["FechaSaC2"] + "</Td></Tr>" +
                               "<Tr><Td><b>Observacion</b></Td><Td>" + pTabEnvio.Rows[0]["ObsC2"] + "</Td></Tr>" +
                              "</Table>" +
                             "</Td>";



                pBodyDetTD = "<Td valign='Top' style='border-right:1px solid #006699'>" +
                               "<Table width='100%' cellspacing='0' " +
                               "style='font-family: MS Sans Serif; font-size: xx-small ; color: #006699'>" +
                                "<Tr><Td><b>Terminal</b></Td><Td>" + pTabEnvio.Rows[0]["TerminalD"] + "</Td></Tr>" +
                                "<Tr bgcolor='#DBE5F1'><Td><b>+nbsp</b></Td><Td>+nbsp</Td></Tr>";

                if (lstNoti[0].Ntf_DLlegada == true)
                {
                    pBodyDetTD += "<Tr><Td><b>Llegada</b></Td><Td>" + pTabEnvio.Rows[0]["FechaLlTD"] + "</Td></Tr>";
                }
                else
                    pBodyDetTD += "<Tr><Td><b>Llegada</b></Td><Td>" + "</Td></Tr>";

                if (lstNoti[0].Ntf_DIngreso == true)
                {
                    pBodyDetTD += "<Tr bgcolor='#DBE5F1'><Td><b>Ingreso</b></Td><Td>" + pTabEnvio.Rows[0]["FechaIgTD"] + "</Td></Tr>";
                }
                else
                    pBodyDetTD += "<Tr bgcolor='#DBE5F1'><Td><b>Ingreso</b></Td><Td>" + pTabEnvio.Rows[0]["FechaIgTD"] + "</Td></Tr>";

                if (lstNoti[0].Ntf_DSalida == true)
                {
                    pBodyDetTD += "<Tr><Td><b>Salida</b></Td><Td>" + pTabEnvio.Rows[0]["FechaSaTD"] + "</Td></Tr>";
                }
                else
                    pBodyDetTD += "<Tr><Td><b>Salida</b></Td><Td>" + pTabEnvio.Rows[0]["FechaSaTD"] + "</Td></Tr>";

                pBodyDetTD += "<Tr bgcolor='#DBE5F1'><Td><b>+nbsp</b></Td><Td>+nbsp</Td></Tr>" +
                                "<Tr><Td><b>Observacion</b></Td><Td>" + pTabEnvio.Rows[0]["ObsTD"] + "</Td></Tr>" +
                               "</Table>" +
                              "</Td>";

                pBodyPie = "<b>Creacion : " + pTabEnvio.Rows[0]["UCre"] + " " + pTabEnvio.Rows[0]["FCre"] + "</b><Br>" +
                           "<b>Modificacion : " + pTabEnvio.Rows[0]["UMod"] + " " + pTabEnvio.Rows[0]["FMod"] + "</b><Br><Br>" +
                           "Reporte Enviado Automaticamente por Web Transportes";
                pBody = "<html><body style='font-family: MS Sans Serif; font-size: xx-small ; color: #006699'>" + Encabezado + "<Br><Br>" + pBodyCab;

                //Dim i As String = pTabEnvio.Rows(0]["NSol")
                //Dim j As String = pTabEnvio.Rows(0]["DblCar")
                if ((pTabEnvio.Rows[0]["NSol"].ToString() == "1") && (pTabEnvio.Rows[0]["DblCar"].ToString() == "0"))
                {
                    pBody = pBody + pBodyDetTR + pBodyDetC1 + pBodyDetTD;
                }
                else if ((Convert.ToInt32(pTabEnvio.Rows[0]["NSol"]) == 1) && Convert.ToInt32(pTabEnvio.Rows[0]["DblCar"]) == 1)
                {
                    pBody = pBody + pBodyDetTR + pBodyDetC1 + pBodyDetC2 + pBodyDetTD;
                }
                else if (Convert.ToInt32(pTabEnvio.Rows[0]["NSol"]) == 2)
                {
                    pBody = pBody + pBodyDetTR + pBodyDetTD;
                }
                else if (Convert.ToInt32(pTabEnvio.Rows[0]["NSol"]) == 3 || Convert.ToInt32(pTabEnvio.Rows[0]["NSol"]) == 4)
                {
                    pBody = pBody + pBodyDetC1 + pBodyDetC2;
                }
                else
                {
                    MostrarMensaje(1, "Error, informar a Sistemas.");
                }

                pBody = pBody + "</Tr></Table></Td></Tr></Table><bR>" + pBodyPie + "</body></html>";

                //objClsOperaciones.EnvioMail("juan.gutierrez@tmeridian.com.pe", "", "", pBody, pTabEnvio.Rows[0]["Placa"].ToString(), pRo, pTabEnvio.Rows[0]["Cliente"].ToString());
                objClsOperaciones.EnvioMail(pFrom, pCC, pBC, pBody, pTabEnvio.Rows[0]["Placa"].ToString(), pRo, pTabEnvio.Rows[0]["Cliente"].ToString());
                //objClsOperaciones.EnvioMail("carlos.mejia@tmeridian.com.pe", "carlos.mejia@tmeridian.com.pe", "carlos.mejia@tmeridian.com.pe", pBody, pTabEnvio.Rows(0)("Placa"), pRo, pTabEnvio.Rows(0)("Cliente"))

                objClsOperaciones.ActualizarCorreo(Convert.ToInt32(pRo), Convert.ToInt32(pItem));

            }

        }
        catch (Exception ex)
        {
            MostrarMensaje(1, ex.Message);
        }
    }
    protected void grvContenedores_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow grv = (GridViewRow)grvContenedores.Rows[e.RowIndex];

        string pApellido = "", pNombre = "", pUsuarioCompleta = "", pUsuario = "";

        pUsuarioCompleta = ObtenerDatosSesion("usuario");
        string[] arg = new string[2];
        arg = ObtenerDatosSesion("nombres").Split(' ');
        pApellido = arg[0];
        pNombre = arg[1];
        pUsuario = ObtenerDatosSesion("usuario");

        TMS_SeguimientoBL objClsOperaciones = new TMS_SeguimientoBL();

        TextBox txtFecCita = (TextBox)grvContenedores.Rows[grv.DataItemIndex].Cells[9].FindControl("txtFecCita");
        TextBox txtHoraCita = (TextBox)grvContenedores.Rows[grv.DataItemIndex].Cells[10].FindControl("txtHoraCita");
        TextBox txtEditContenedor = (TextBox)grvContenedores.Rows[grv.DataItemIndex].Cells[3].FindControl("txtEditContenedor");
        Label lblEditROAL = (Label)grvContenedores.Rows[grv.DataItemIndex].Cells[2].FindControl("lblEditROAL");
        Label lblSolicitud = (Label)grvContenedores.Rows[grv.DataItemIndex].Cells[2].FindControl("lblSolicitud");
        Label lblAntCont = (Label)grvContenedores.Rows[grv.DataItemIndex].Cells[3].FindControl("lblAntCont");
        Label lblItem = (Label)grvContenedores.Rows[grv.DataItemIndex].Cells[3].FindControl("lblItem");
        DropDownList ddlTipo = (DropDownList)grvContenedores.Rows[grv.DataItemIndex].Cells[5].FindControl("ddlTipo");
        TextBox txtPies = (TextBox)grvContenedores.Rows[grv.DataItemIndex].Cells[4].FindControl("txtPies");
        TextBox txtTara = (TextBox)grvContenedores.Rows[grv.DataItemIndex].Cells[6].FindControl("txtTara");
        TextBox txtPeso = (TextBox)grvContenedores.Rows[grv.DataItemIndex].Cells[7].FindControl("txtPeso");
        TextBox txtPyload = (TextBox)grvContenedores.Rows[grv.DataItemIndex].Cells[8].FindControl("txtPyload");

        string Fec = "", Hor = "", Contenedor = "", Pref = "", Nume = "";
        if (grvContenedores.Rows[grv.DataItemIndex].Cells[9].FindControl("txtFecCita").ToString() == "--")
        {
            Fec = "01/01/1900";
        }
        else
        {
            Fec = txtFecCita.Text;
        }

        if (grvContenedores.Rows[grv.DataItemIndex].Cells[10].FindControl("txtHoraCita").ToString() == "--")
        {
            Hor = "00:00";
        }
        else
        {
            Hor = txtHoraCita.Text;
        }
        Contenedor = txtEditContenedor.Text;
        Pref = Contenedor.Substring(0, 4);
        Nume = Contenedor.Substring(4, Contenedor.Length - 4);
        string men = "", cont = Pref + Nume;
        men = objClsOperaciones.ActualizarCont("I", Convert.ToInt32(lblEditROAL.Text),
                                          Convert.ToInt32(lblSolicitud.Text),
                                          Convert.ToInt32(lblSolicitud.Text),
                                          cont,
                                          lblAntCont.Text,
                                          Convert.ToInt32(lblItem.Text),
                                          ddlTipo.SelectedItem.Text,
                                          Convert.ToInt32(txtPies.Text),
                                          Convert.ToInt32(txtTara.Text),
                                          Convert.ToInt32(txtPeso.Text),
                                          Convert.ToInt32(txtPyload.Text),
                                          Convert.ToDateTime(Fec), Convert.ToDateTime("01/01/1900 " + Hor), pUsuario);
        grvContenedores.EditIndex = -1;
        string roal = "";

        roal = grvSolicitudes.Rows[0].Cells[1].Text + "," + roal;
        roal = roal.Substring(0, roal.Length - 1);
        tabla = objClsOperaciones.GetContenedoresSeguimiento(roal);
        if (men == "E")
        {
            MostrarMensaje(0, "El Contenedor Ya Existe");
        }
        else if (men == "A")
        {
            MostrarMensaje(0, "El contenedor Fue Actualizado");
        }
        else
        {
            MostrarMensaje(0, "Error al Actualizar");
        }
        grvContenedores.DataSource = tabla;
        grvContenedores.DataBind();
    }



    protected void ddlEmpresaInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
        ddlUnidadInfo.DataSource = oSeguimiento.UnidadxEmp(Convert.ToInt32(ddlEmpresaInfo.SelectedValue));
        ddlUnidadInfo.DataTextField = "UNIDAD_PLACA";
        ddlUnidadInfo.DataValueField = "UNIDAD_CODIGO";
        ddlUnidadInfo.DataBind();
        ddlUnidadInfo.SelectedValue = "0";

        if (ddlEmpresaInfo.SelectedValue == "88")
        {
            ServiceReferenceRRHH.apiSoapClient service = new ServiceReferenceRRHH.apiSoapClient();
            string strListaConductores = service.TM_ListarConductores();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(strListaConductores, typeof(DataTable));
            ddlChoferInfo.DataSource = dt;
            ddlChoferInfo.DataTextField = "nom_conductor";
            ddlChoferInfo.DataValueField = "nro_documento";
            ddlChoferInfo.Items.Add(new ListItem("--Seleccione--", "-1"));
        }
        else
        {
            ddlChoferInfo.DataSource = oSeguimiento.GetChoferxEmp(Convert.ToInt32(ddlEmpresaInfo.SelectedValue));
            ddlChoferInfo.DataSource = oSeguimiento.GetChoferxEmp(Convert.ToInt32(ddlEmpresaInfo.SelectedValue));
            ddlChoferInfo.DataTextField = "CHOFER";
            ddlChoferInfo.DataValueField = "CHOFER_CODIGO";
            
        }
        
        ddlChoferInfo.DataBind();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalAsignacion').modal('show');", true);
    }

    protected void btnConfirmarEliminarContenedor_Click(object sender, EventArgs e)
    {
        try
        {
            TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();

            oSeguimiento.EliminarContenedor(Convert.ToInt32(hfAL.Value), hfContenedor.Value);

            CargarDetalle();

            MostrarMensaje(0, "El contenedor se eliminó con éxito.");
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "Error. Informar a Sistemas:" + ex);
        }
        
    }
}

