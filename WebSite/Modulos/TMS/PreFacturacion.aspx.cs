using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_TMS_PreFacturacion : System.Web.UI.Page
{
    TMS_PreFacturacionBL oPreFacturacion = new TMS_PreFacturacionBL();
    string CentroCosto = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //'CrearXml("OrdenVenta")
            //'Return
            DataTable dt = null;
            DataTable dtam;
            string CadenaRO = Session["pRO"].ToString();
            string[] ArrCadenaRO = CadenaRO.Split(',');
            string RucCliente = "";
            string CadenaSOL = Session["pSolicitud"].ToString();
            string[] ArrCadenaSOL = CadenaSOL.Split(',');
            DataTable dtZona;

            //btnEntrega_Venta.Attributes.Add("onclick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(btnEntrega_Venta, Nothing) + ";")

            switch (Session["pCentroCosto"].ToString())
            {
                case "Logística Local":
                    CentroCosto = "UN0001";
                    break;
                case "Operativo":
                    CentroCosto = "UN0002";
                    break;
                case "Distribución Lurin":
                    CentroCosto = "UN0003";
                    break;
                case "Distribución Callao":
                    CentroCosto = "UN0004";
                    break;
                default:
                    break;
            }

            //LimpiarControles();

            for (int i = 0; i < ArrCadenaRO.Length - 1; i++)
            {
                if (ArrCadenaRO[i] != "")
                {
                    dt = oPreFacturacion.GetCabecera(Convert.ToInt32(ArrCadenaRO[i]), Convert.ToInt32(ArrCadenaSOL[i]));
                    if (dt.Rows.Count != 0)
                    {
                        txtDocumento.Text = dt.Rows[0]["Fac_Id"].ToString();
                    }
                }
            }

            if (dt.Rows.Count == 0)
            {
                if (Session["pCentroCosto"].ToString() == "Operativo")
                {
                    CargarCliente();
                    InsertarCabecera();
                    InsertarDetalle();
                    ObtenerCabeceraFactura();
                    CargarDetalleFacturacion();
                    ActualizarZona();
                    grvDetalleContenedores.Columns[14].Visible = false;
                }
                else
                {
                    CargarCliente();
                    InsertarCabecera();
                    InsertarDetalleUN();
                    ObtenerCabeceraFactura();
                    CargarDetalleFacturacion();
                    ActualizarZona();
                    grvDetalleContenedores.Columns[14].Visible = false;
                }
            }
            else
            {

                CargarCliente();
                //InsertarZonaTipoCont();
                ObtenerCabeceraFactura();
                CargarDetalleFacturacion();
                ActualizarZona();
                CargarDetalleFacturacion();
                grvDetalleContenedores.Columns[14].Visible = false;
                //CargarResumenVentas(CInt(txtDocumento.Text));
                //CargarResumenCompras(CInt(txtDocumento.Text));



            }

            if (Session["pCLienteCreacion"].ToString() == "TRANSPORTES MERIDIAN S.A.C.")
            {
                RucCliente = "C" + Session["pRucClienteDelCliente"].ToString();
            }
            else
            {
                RucCliente = "C" + Session["pRuc"].ToString();
            }
            //CargarServicios(RucCliente, CentroCosto)
            if (grvServicios.Rows.Count == 0)
            {

                lblMensaje.Value = "No se cargo el detalle de los servicios ya que no se tiene registrado una tarifa en sap para este cliente";
            }
            //btnActualizar_OV.Enabled = True
            //btn_ActualizarEM.Enabled = True
            //rbtVentas.Checked = True

        }
    }

    private void CargarCliente() {
        try
        {
            string RucCliente = "";
            switch (Session["pCentroCosto"].ToString()) {
                case "Logística Local":
                    CentroCosto = "UN0001";
                    break;
                case "Operativo":
                    CentroCosto = "UN0002";
                    break;
                case "Distribución Lurin":
                    CentroCosto = "UN0003";
                    break;
                case "Distribución Callao":
                    CentroCosto = "UN0004";
                    break;
                default:
                    break;
            }

            if (Session["pCLienteCreacion"].ToString() == "TRANSPORTES MERIDIAN S.A.C.") {
                RucCliente = "C" + Session["pRucClienteDelCliente"].ToString();
            }
            else {
                RucCliente = "C" + Session["pRuc"].ToString();
            }

            //revisar el caso
            //if (ddlCliente.Items == null) {
            //    ddlCliente.Items.Clear();
            //    ddlCliente.Items.Add(new ListItem("--Seleccione--", "0"));
            //    ddlCliente.DataSource = oPreFacturacion.listarCliente(CentroCosto);
            //    ddlCliente.DataTextField = "U_CTS_NSN";
            //    ddlCliente.DataValueField = "U_CTS_CSN";
            //    ddlCliente.DataBind();
            //    if (RucCliente == "C0") {
            //        ddlCliente.SelectedValue = "0";
            //    }
            //    else {
            //        ddlCliente.SelectedValue = RucCliente;
            //    }
            //}

        } catch (Exception ex)
        {

        }

    }

    //private void CargarServiciosCompras(string centroCosto)
    //{
    //    grvServicios.DataSource = oPreFacturacion.ListarServiciosCompras(centroCosto);
    //    grvServicios.DataBind();
    //}

    public void InsertarCabecera() {
        string pSol, pRo, mensaje = "", pUsuario = "";
        string pApellido = "";
        string ClienteFacturar = "";
        string ClienteDelCliente = "";
        pUsuario = User.Identity.Name;
        string RucCliente = "";
        //'pApellido = Mid(pUsuarioCompleta, InStr(1, pUsuarioCompleta, ".") + 1, 20)
        //'pNombre = Mid(Me.User.Identity.Name, 10, 1)
        //'pUsuario = pNombre + pApellido

        pRo = Session["pRO"].ToString().Replace(",", "/");
        pSol = Session["pSolicitud"].ToString().Replace(",", "/");

        if (Session["pCLienteCreacion"].ToString() == "TRANSPORTES MERIDIAN S.A.C.") {
            ClienteFacturar = Session["pCLiente"].ToString();
            ClienteDelCliente = Session["pCLienteCreacion"].ToString();
            RucCliente = Session["pRucClienteDelCliente"].ToString();
        } else {
            ClienteFacturar = Session["pCLienteCreacion"].ToString();
            ClienteDelCliente = Session["pCLiente"].ToString();
            RucCliente = Session["pRuc"].ToString();
        }



        DataTable dt = oPreFacturacion.ActualizarFacturacion(pRo, ClienteFacturar, ClienteDelCliente, pUsuario, Session["pCentroCosto"].ToString(),
                                                                  pSol, RucCliente, Session["pTipoMovimiento"].ToString());
        txtDocumento.Text = dt.Rows[0][0].ToString();
    }

    public void InsertarDetalle() {
        try
        {
            string mensaje = "", pUsuario = "";
            string pApellido = "";
            pUsuario = User.Identity.Name;
            //'pApellido = Mid(pUsuarioCompleta, InStr(1, pUsuarioCompleta, ".") + 1, 20)
            //'pNombre = Mid(Me.User.Identity.Name, 10, 1)
            //'pUsuario = pNombre + pApellido

            string CadenaRO = Session["pRO"].ToString();
            string[] ArrCadenaRO = CadenaRO.Split(',');

            string CadenaSOL = Session["pSolicitud"].ToString();
            string[] ArrCadenaSOL = CadenaSOL.Split(',');

            //'pRo = CInt(Cache("pRO"))
            //'pSol = CInt(Cache("pSolicitud"))

            for (int i = 0; i < ArrCadenaRO.Length - 1; i++) {
                if (ArrCadenaRO[i] != "") {
                    oPreFacturacion.ActualizarDetalleFacturacion(Convert.ToInt32(ArrCadenaRO[i]), Convert.ToInt32(ArrCadenaSOL[i]), pUsuario, Convert.ToInt32(txtDocumento.Text));
                }
            }

            //'mensaje = objClsOperaciones.ActualizarDetalleFacturacion(pRo, pSol, pUsuario)
            //'lblMensaje.Text = "Se registro el detalle de la facturación"

        } catch (Exception ex)
        {
            lblMensaje.Value = ex.Message;
        }
    }

    private void ObtenerCabeceraFactura() {
        try
        {
            DataTable dt;

            dt = oPreFacturacion.GetCabeceraFacturacion(Convert.ToInt32(txtDocumento.Text));

            if (dt.Rows.Count != 0) {
                txtDocumento.Text = dt.Rows[0]["Fac_Id"].ToString();
                txtAL.Text = dt.Rows[0]["Fac_Ro"].ToString();
                txtFechaCreacion.Text = dt.Rows[0]["Fac_FechaCreacion"].ToString();
                txtCentroCostos.Text = dt.Rows[0]["Fac_CentroCosto"].ToString();
                ddlCliente.SelectedValue = dt.Rows[0]["Fac_Clie"].ToString();
                //'txtCliente.Text = dt.Rows(0)("Fac_Clie")
                txtCodigoCliente.Text = "C" + dt.Rows[0]["Fac_RucCliente"].ToString();
                //'txtClienteDelCliente.Text = dt.Rows(0)("Fac_CliendelCliente")
            }

        } catch (Exception ex){
            lblMensaje.Value = ex.Message;
        }
    }

    private void CargarDetalleFacturacion() {
        //'If Not Page.IsPostBack Then

        try
        {
            DataTable dt;
            DataTable dta;
            int j;
            int DetFac_Id;

            grvDetalleContenedores.DataSource = oPreFacturacion.ListarDetalleFacturacion(Convert.ToInt32(txtDocumento.Text));
            grvDetalleContenedores.DataBind();

            //dt = objClsOperaciones.ListarDetalleFacturacion(CInt(lblDocumento.Text)).Tables(0);

        } catch (Exception ex) {
            lblMensaje.Value = ex.Message;
        }
        //'End If

    }

    private void ActualizarZona() {
        string DetFac_Id;
        int Zona;
        int TipoContenedor;
        int AL;
        int Sol;
        string pContenedor = "";
        string pUsuario = "";

        for (int i = 0; i < grvDetalleContenedores.Rows.Count - 1; i++) {
            Label lblLote = (Label)grvDetalleContenedores.FindControl("lblLote");

            DetFac_Id = grvDetalleContenedores.Rows[i].Cells[1].Text;
            Zona = Convert.ToInt32(grvDetalleContenedores.Rows[i].Cells[21].Text);

            pUsuario = User.Identity.Name;

            if (lblLote.Text != "") {
                TipoContenedor = Convert.ToInt32(lblLote.Text);
            }
            else {
                TipoContenedor = 0;
            }

            AL = Convert.ToInt32(grvDetalleContenedores.Rows[i].Cells[2].Text);
            Sol = Convert.ToInt32(grvDetalleContenedores.Rows[i].Cells[3].Text);
            pContenedor = grvDetalleContenedores.Rows[i].Cells[12].Text;

            oPreFacturacion.ActualizarCodigoZona(AL, Sol, pUsuario, pContenedor);
        }

    }

    private void InsertarDetalleUN() {
        try
        {
            string mensaje = "", pUsuario = "";
            string pApellido = "";
            pUsuario = User.Identity.Name;
            //'pApellido = Mid(pUsuarioCompleta, InStr(1, pUsuarioCompleta, ".") + 1, 20)
            //'pNombre = Mid(Me.User.Identity.Name, 10, 1)
            //'pUsuario = pNombre + pApellido

            string CadenaRO = Session["pRO"].ToString();
            string[] ArrCadenaRO = CadenaRO.Split(',');

            string CadenaSOL = Session["pSolicitud"].ToString();
            string[] ArrCadenaSOL = CadenaSOL.Split(',');

            for (int i = 0; i < ArrCadenaRO.Length - 1; i++) {
                if (ArrCadenaRO[i] != "") {
                    oPreFacturacion.ActualizarDetalleFacturacionUN(Convert.ToInt32(ArrCadenaRO[i]), Convert.ToInt32(ArrCadenaSOL[i]),
                                                                   pUsuario, Convert.ToInt32(txtDocumento.Text));
                }
            }


        } catch (Exception ex) {
            lblMensaje.Value = ex.Message;
        }
    }

    private void InsertarZonaTipoCont() {
        int DetFac_Id;
        int Zona;
        int TipoContenedor;

        for (int i = 0; i < grvDetalleContenedores.Rows.Count - 1; i++) {
            Label lblLote = (Label)grvDetalleContenedores.Rows[i].FindControl("lblLote");

            DetFac_Id = Convert.ToInt32(grvDetalleContenedores.Rows[i].Cells[1].Text);
            Zona = Convert.ToInt32(grvDetalleContenedores.Rows[i].Cells[21].Text);

            if (lblLote.Text != "") {
                TipoContenedor = Convert.ToInt32(lblLote.Text);
            }
            else {
                TipoContenedor = 0;
            }

            oPreFacturacion.ActualizarZona(DetFac_Id, Zona, TipoContenedor);
        }

    }

    protected void grvServicios_PreRender(object sender, EventArgs e)
    {

    }


    protected void btnModificarCliente_Click(object sender, EventArgs e)
    {
        //panelDetalleTarifaSAP.Attributes.Add();
    }

    protected void btnAnularDocumento_Click(object sender, EventArgs e)
    {

    }

    protected void btnConsultarTarifa_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalDetalleTarifaSAP').modal('show');", true);
    }

    protected void btnExportarDetalle_Click(object sender, EventArgs e)
    {

    }

    protected void grvDetalleTarifaSAP_PreRender(object sender, EventArgs e)
    {

    }

    protected void btnCerrarDetalleTarifa_Click(object sender, EventArgs e)
    {

    }

    protected void grvDetalleContenedores_PreRender(object sender, EventArgs e)
    {

    }

    protected void btnAgregarServicio_Click(object sender, EventArgs e)
    {

    }

    protected void btnEliminarServicio_Click(object sender, EventArgs e)
    {

    }
}