using BL;
using EL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Modulos_TMS_DefaultMonitoreo : System.Web.UI.Page
{
    TPL_BL objTPL = new TPL_BL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Iniciar();
        }
    }

    protected void Iniciar()
    {
        txtFechaHastaFiltro.Text = DateTime.Now.ToShortDateString();
        txtFechaDesdeFiltro.Text = DateTime.Now.AddDays(-1).ToShortDateString();

        CargarEmpresa();
        CargarMovimiento();
        cargarEstados();
        CargarTipoSol();
        CargarDeposito();

        //CargarChoferes_Prueba();

        txtALFiltro.Text = Request.QueryString["ExAL"];
        cargarSolicitudTransporte();
    }

    //public void CargarChoferes_Prueba()
    //{
    //    ServiceReferenceRRHH.apiSoapClient service = new ServiceReferenceRRHH.apiSoapClient();

    //    string strListaConductores = service.TM_ListarConductores();
    //    DataTable dt = (DataTable)JsonConvert.DeserializeObject(strListaConductores, typeof(DataTable));
    //    ddlChoferesWS.DataSource = dt;
    //    ddlChoferesWS.DataTextField = "nom_conductor";
    //    ddlChoferesWS.DataValueField = "nro_documento";
    //    ddlChoferesWS.DataBind();
    //}

    public void CargarTipoSol()
    {
        ddlTipoSolicitudFiltro.Items.Clear();
        ddlTipoSolicitudFiltro.Items.Add(new ListItem("Todos", "0"));
        ddlTipoSolicitudFiltro.DataSource = objTPL.ListarTipoSolicitud();
        ddlTipoSolicitudFiltro.DataTextField = "TS_Des";
        ddlTipoSolicitudFiltro.DataValueField = "TS_Cod";
        ddlTipoSolicitudFiltro.DataBind();

    }

    public void cargarEstados()
    {

        ddlEstadoFiltro.DataSource = objTPL.ListarEstados();
        ddlEstadoFiltro.DataTextField = "Estado";
        ddlEstadoFiltro.DataValueField = "ros_estado";
        ddlEstadoFiltro.DataBind();

        //ddlEstadoFiltro.Items.Insert(0, New ListItem("MOSTRAR TODOS", "0"))
    }

    public void CargarMovimiento()
    {
        ddlMovimientoFiltro.DataSource = objTPL.ListarTipoMovimiento();
        ddlMovimientoFiltro.DataTextField = "Movimiento";
        ddlMovimientoFiltro.DataValueField = "ro_tmov";
        ddlMovimientoFiltro.DataBind();
        ddlMovimientoFiltro.Items.RemoveAt(3);

    }

    public void CargarEmpresa()
    {
        TMS_ClientesBL oCliente = new TMS_ClientesBL();
        List<TMS_ClientesEL> lista = oCliente.ListarClientes("*");

        //FILTRO
        ddlEmpresaFiltro.DataSource = lista;
        ddlEmpresaFiltro.DataTextField = "Raz_Soc";
        ddlEmpresaFiltro.DataValueField = "Cod_Empresa";
        ddlEmpresaFiltro.DataBind();
        ddlEmpresaFiltro.Items.Insert(0, new ListItem(" Todos", " Todos"));

        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
        ddlEmpresaInfo.DataSource = oSeguimiento.GetEmpresaTransporte();
        ddlEmpresaInfo.DataTextField = "EMPRETRANS_RAZONSOCIAL";
        ddlEmpresaInfo.DataValueField = "EMPRETRANS_CODIGO";
        ddlEmpresaInfo.DataBind();
        ddlEmpresaInfo.SelectedValue = "88";
        //ddlEmpresaInfo.Items.Insert(0, new ListItem("[Seleccionar]", ""));

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
            GVPlaneamiento.DataSource = objTPL.BuscarSolicitudMonitoreo(Convert.ToInt32(ddlTipoSolicitudFiltro.SelectedValue), pMovimiento, pEstado, pCliente, pSolicitud, pAl, pSeguimiento, pFecIni, pFecFin, pEmp, "Todos", pContenedor);
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

    protected void btnFiltrarSolicitudes_Click(object sender, EventArgs e)
    {
        cargarSolicitudTransporte();
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

    protected void btnProgramacion_Click(object sender, EventArgs e)
    {

    }

    protected void btnAgregarSeguimiento_Click(object sender, EventArgs e)
    {
        int flag = 0, soloDis = 0;
        IList<string> RowData_AL = new List<string>();
        lblMensaje.Value = "";
        string msjError = "";
        string pRO = "", pSolicitud = "", pEntidad = "", pSeguimiento = "", pcontenedor="", pItem="", pFechaCita="", pCliente="";

        foreach (GridViewRow gvrAL in GVPlaneamiento.Rows)
        {
            CheckBox chkSelected = (CheckBox)gvrAL.FindControl("CheckBox1");
            LinkButton hplSolicitud = (LinkButton)gvrAL.FindControl("hplSolicitud");
            Label lblTipoSol = (Label)gvrAL.FindControl("lblTipoSol");
            Label lblContenedor = (Label)gvrAL.FindControl("lblContenedor");
            Label lblItem = (Label)gvrAL.FindControl("lblItem");
            Label lblMovimiento = (Label)gvrAL.FindControl("lblMovimiento");
            Label lblFechaCita = (Label)gvrAL.FindControl("lblFechaCita");
            Label lblItemROAL = (Label)gvrAL.FindControl("lblItemROAL");
            Label lblsubcliencod = (Label)gvrAL.FindControl("lblsubcliencod");
            Label lblcliencod = (Label)gvrAL.FindControl("lblcliencod");

            if (chkSelected.Checked == true)
            {
                flag += 1;

                pRO = lblItemROAL.Text + "," + pRO;
                pSolicitud = hplSolicitud.Text + "," + pSolicitud;
                pEntidad = lblsubcliencod.Text;
                pCliente = lblcliencod.Text;
                pcontenedor = lblContenedor.Text;
                pItem = lblItem.Text;
                pFechaCita = lblFechaCita.Text;
                if (lblTipoSol.Text == "Distribución")
                    soloDis = 1;

                CargarLocal(pEntidad);

                string[] arr = hplSolicitud.CommandArgument.ToString().Split('|');
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
            Session["pRO"] = pRO.Substring(0, pRO.Length - 1);
            Session["pSolicitud"] = pSolicitud.Substring(0, pSolicitud.Length - 1);
            Session["pEntidad"] = lblentidad0.Value.ToString();
            Session["VALOR"] = 1;

            if (soloDis == 1)
            {
                MostrarMensaje(1, "Comunicarse con Sistemas.");
                //Session["op"] = "op";
                //Response.Redirect("UISolicitudDistribucion.aspx?IdMenu=4&tipou=1");
            }
            else
            {
                //Limpiar();
                //limpiar2();

                getSeguimiento(pItem, pcontenedor, pRO);

                lblTittle.Text = pcontenedor.ToString();
                hfContenedor.Value = pcontenedor.ToString();
                hfFechaSoli.Value = pFechaCita;
                //hfEvento.Value = arg[2].ToString();
                hfAL.Value = pRO;
                hfMovimiento.Value = "I"; //revisar

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalAsignacion').modal('show');", true);

                //Response.Redirect("SeguimientoTransportes.aspx?AL=" + pRO.Substring(0, pRO.Length - 1) +
                //                                             "&Mov=" + ddlMovimientoFiltro.SelectedValue.ToString() +
                //                                             "&Enti=" + pEntidad +
                //                                             "&Soli=" + pSolicitud.Substring(0, pSolicitud.Length - 1));
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalAsignacion').modal('show');", true);
            }
        }
    }

    public void getSeguimiento(string kitem, string ctn, string ro)
    {

        try
        {
            ro=ro.Substring(0, 6);
            TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
            List<TMS_SeguimientoEL> lst = oSeguimiento.GetSeguimiento(Convert.ToInt32(ro), ctn/*.Trim()*/, Convert.ToInt32(kitem));
            //List<TMS_ChoferEL> lstChofer = oSeguimiento.getChoferSeguimiento(lst[0].Chofer.ToString());

            if (ddlTerminalRetiro.Items.FindByValue(lst[0].Ter1.ToString()) != null)
            {
                ddlTerminalRetiro.SelectedValue = lst[0].Ter1.ToString();
            }
            else
            {
                ddlTerminalRetiro.SelectedIndex = 0;
            }


            dtpRetiroLlegadaFecha.Text = lst[0].FechaLlTR.ToString();
            txtRetiroLlegadaHora.Text = lst[0].HoraLlTR.ToString();
            dtpRetiroIngresoFecha.Text = lst[0].FechaInTR.ToString();
            txtRetiroIngresoHora.Text = lst[0].HoraInTR.ToString();
            dtpRetiroSalidaFecha.Text = lst[0].FechaSaTR.ToString();
            txtRetiroSalidaHora.Text = lst[0].HoraSaTR.ToString();
            txtRetiroObservacion.Text = lst[0].ObsTR.ToString();

            if (ddlClienteLocal.Items.FindByValue(lst[0].Loc1.ToString()) != null)
            {
                ddlClienteLocal.SelectedValue = lst[0].Loc1.ToString();
            }
            else
            {
                ddlClienteLocal.SelectedIndex = 0;
            }

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


            if (ddlTerminalDevolucion.Items.FindByValue(lst[0].Ter2.ToString()) != null)
            {
                ddlTerminalDevolucion.SelectedValue = lst[0].Ter2.ToString();
            }
            else
            {
                ddlTerminalDevolucion.SelectedIndex = 0;
            }

            dtpDevolucionLlegadaFecha.Text = lst[0].FechaLlTD.ToString();
            txtDevolucionLlegadaHora.Text = lst[0].HoraLlTD.ToString();
            dtpDevolucionIngresoFecha.Text = lst[0].FechaInTD.ToString();
            txtDevolucionIngresoHora.Text = lst[0].HoraInTD.ToString();
            dtpDevolucionSalidaFecha.Text = lst[0].FechaSaTD.ToString();
            txtDevolucionSalidaHora.Text = lst[0].HoraSaTD.ToString();
            txtObservacionDevolucion.Text = lst[0].ObsTD.ToString();

            if (ddlEmpresaInfo.Items.FindByValue(lst[0].Empresa.ToString()) != null)
            {
                ddlEmpresaInfo.SelectedValue = lst[0].Empresa.ToString();
            }
            else
            {
                ddlEmpresaInfo.SelectedIndex = 0;
            }

            

            if (lst[0].Empresa.ToString() == "88")
            {
                CargarChofer(Convert.ToInt32(ddlEmpresaInfo.SelectedValue), lst[0].DNI_Chofer.ToString());
                CargarUnidadTransporte(Convert.ToInt32(ddlEmpresaInfo.SelectedValue), lst[0].UNIDAD_PLACA.ToString());
            }
            else
            {
                CargarChofer(Convert.ToInt32(ddlEmpresaInfo.SelectedValue), lst[0].Chofer.ToString());
                CargarUnidadTransporte(Convert.ToInt32(ddlEmpresaInfo.SelectedValue), lst[0].Unidad.ToString());
            }
                


            //CargarChofer(Convert.ToInt32(ddlEmpresaInfo.SelectedValue), lstChofer[0].CHOFER_CODIGO.ToString());

            if (ddlUnidadInfo.Items.FindByValue(lst[0].Unidad.ToString()) != null)
            {
                //CargarUnidadTransporte(Convert.ToInt32(ddlEmpresaInfo.SelectedValue), lst[0].Unidad.ToString());
                ddlUnidadInfo.SelectedValue = lst[0].Unidad.ToString();
            }
            else
            {
                ddlUnidadInfo.SelectedIndex = 0;
            }

            //if (ddlChoferInfo.Items.FindByValue(lst[0].Chofer.ToString()) != null)
            //{
            //    //CargarChofer(Convert.ToInt32(ddlEmpresaInfo.SelectedValue), lst[0].Chofer.ToString());
            //    ddlChoferInfo.SelectedValue = lst[0].Chofer.ToString();
            //}
            //else
            //{
            //    ddlChoferInfo.SelectedIndex = 0;
            //}

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




        }
        catch (Exception ex)
        {
            MostrarMensaje(1, ex.Message);
        }

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
        }
        else
        {
            ddlChoferInfo.DataSource = oSeguimiento.GetChoferxEmp(Convert.ToInt32(ddlEmpresaInfo.SelectedValue));
            ddlChoferInfo.DataSource = oSeguimiento.GetChoferxEmp(Convert.ToInt32(ddlEmpresaInfo.SelectedValue));
            ddlChoferInfo.DataTextField = "CHOFER";
            ddlChoferInfo.DataValueField = "CHOFER_CODIGO";
        }
        ddlChoferInfo.Items.Add(new ListItem("--Seleccione--", "-1"));
        ddlChoferInfo.DataBind();
        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "$('#modalAsignacion').modal('show');", true);
    }

    protected void btnGuardarAsignacion_Click(object sender, EventArgs e)
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
        TMS_NotificacionesBL oNotificaciones = new TMS_NotificacionesBL();

        int AL = 0, item = 0, solicitud = 0, pies = 0, pernocte;
        string movimiento = "", itemTipo = "", ent1 = "", pCliente="";

        string msjHTML = "";
        string msjHTML2 = "";

        foreach (GridViewRow gvr in GVPlaneamiento.Rows)
        {
            Label lblContenedor = (Label)gvr.FindControl("lblContenedor");


            if (lblContenedor.Text == lblTittle.Text)
            {
                Label lblAL = (Label)gvr.FindControl("lblItemROAL");
                Label lblItem = (Label)gvr.FindControl("lblItem");
                Label lblTipo = (Label)gvr.FindControl("lblTipoSol");
                Label lblPies = (Label)gvr.FindControl("lblItemPies");
                Label lblMovimiento = (Label)gvr.FindControl("lblMovimiento");
                Label lblSubCliente = (Label)gvr.FindControl("lblsubcliencod"); //Si es que cae en error con subcliente -> //Label lblCliente = (Label)gvr.FindControl("lblClienteCliente");
                Label lblCliente = (Label)gvr.FindControl("lblClienteCliente");
                Label lblSolicitud = (Label)gvr.FindControl("lblKItem");
                //DropDownList ddlEvento = (DropDownList)gvr.FindControl("ddlEvento");


                AL = Convert.ToInt32(lblAL.Text);
                item = Convert.ToInt32(lblItem.Text);
                itemTipo = lblTipo.Text;
                pies = Convert.ToInt32(lblPies.Text.Substring(3));
                hfEvento.Value = "Ninguno";
                solicitud = Convert.ToInt32(lblSolicitud.Text);
                movimiento = lblMovimiento.Text.Substring(0,1);
                ent1 = lblSubCliente.Text;
                pCliente = lblSubCliente.Text;
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
            if (dtpClienteLlegadaFecha.Text == "" || dtpClienteSalidaFecha.Text == "")
            {
                msjHTML += "<li>Ingrese la Llegada y/o Salida del Cliente para el Pernocte, No se envio correo y los datos no fueron registrados</li>";
                codigo = 0;
            }
            if (hfTipSol.Value == "4")
            { // Or dobleCarga = 1
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

            if (dtpClienteSalidaFecha.Text != "" && dtpClienteLlegadaFecha.Text != "")
            {
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
        else
        {
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

                //solicitud = Convert.ToInt32(lbl);

                //string CodCliente = grvSolicitudes.Rows[0].Cells[6].Text;


                if (dtpRetiroLlegadaFecha.Text.Trim() == "") { SeguimientoEL.FechaLlTR = "01/01/1900"; SeguimientoEL.HoraLlTR = "00:00"; } else { SeguimientoEL.FechaLlTR = dtpRetiroLlegadaFecha.Text; SeguimientoEL.HoraLlTR = txtRetiroLlegadaHora.Text; }
                if (dtpRetiroIngresoFecha.Text.Trim() == "") { SeguimientoEL.FechaInTR = "01/01/1900"; SeguimientoEL.HoraInTR = "00:00"; } else { SeguimientoEL.FechaInTR = dtpRetiroIngresoFecha.Text; SeguimientoEL.HoraInTR = txtRetiroIngresoHora.Text; }
                if (dtpRetiroSalidaFecha.Text.Trim() == "") { SeguimientoEL.FechaSaTR = "01/01/1900"; SeguimientoEL.HoraSaTR = "00:00"; } else { SeguimientoEL.FechaSaTR = dtpRetiroSalidaFecha.Text; SeguimientoEL.HoraSaTR = txtRetiroSalidaHora.Text; }

                if (dtpClienteLlegadaFecha.Text.Trim() == "") { SeguimientoEL.FechaLlCL1 = "01/01/1900"; SeguimientoEL.HoraLlCL1 = "00:00"; } else { SeguimientoEL.FechaLlCL1 = dtpClienteLlegadaFecha.Text; SeguimientoEL.HoraLlCL1 = txtClienteLlegadaHora.Text; }
                if (dtpClienteIngresoFecha.Text.Trim() == "") { SeguimientoEL.FechaIngCL1 = "01/01/1900"; SeguimientoEL.HoraIngCL1 = "00:00"; } else { SeguimientoEL.FechaIngCL1 = dtpClienteIngresoFecha.Text; SeguimientoEL.HoraIngCL1 = txtClienteIngresoHora.Text; }
                if (dtpClienteInicioFecha.Text.Trim() == "") { SeguimientoEL.FechaInCL1 = "01/01/1900"; SeguimientoEL.HoraInCL1 = "00:00"; } else { SeguimientoEL.FechaInCL1 = dtpClienteInicioFecha.Text; SeguimientoEL.HoraInCL1 = txtClienteInicioHora.Text; }
                if (dtpClienteTerminoFecha.Text.Trim() == "") { SeguimientoEL.FechaTeCL1 = "01/01/1900"; SeguimientoEL.HoraTeCL1 = "00:00"; } else { SeguimientoEL.FechaTeCL1 = dtpClienteTerminoFecha.Text; SeguimientoEL.HoraTeCL1 = txtClienteTerminoHora.Text; }
                if (dtpClienteSalidaFecha.Text.Trim() == "") { SeguimientoEL.FechaSaCL1 = "01/01/1900"; SeguimientoEL.HoraSaCL1 = "00:00"; } else { SeguimientoEL.FechaSaCL1 = dtpClienteSalidaFecha.Text; SeguimientoEL.HoraSaCL1 = txtClienteSalidaHora.Text; }

                //if (llegadaCliente2.Trim() == "") { LleCli2 = "01/01/1900 00:00" ; } else { LleCli2 = llegadaCliente2; }
                //if (ingresoCliente2.Trim() == "") { IngCli2 = "01/01/1900 00:00" ; } else { IngCli2 = ingresoCliente2; }
                //if (inicioCliente2.Trim() == "") { IniCar2 = "01/01/1900 00:00" ; } else { IniCar2 = inicioCliente2; }
                //if (terminoCliente2.Trim() == "") { TerCar2 = "01/01/1900 00:00" ; } else { TerCar2 = terminoCliente2; }
                //if (salidaCliente2.Trim() == "") { SalCli2 = "01/01/1900 00:00" ; } else { SalCli2 = salidaCliente2; }

                if (dtpDevolucionLlegadaFecha.Text.Trim() == "") { SeguimientoEL.FechaLlTD = "01/01/1900"; SeguimientoEL.HoraLlTD = "00:00"; } else { SeguimientoEL.FechaLlTD = dtpDevolucionLlegadaFecha.Text; SeguimientoEL.HoraLlTD = txtDevolucionLlegadaHora.Text; }
                if (dtpDevolucionIngresoFecha.Text.Trim() == "") { SeguimientoEL.FechaInTD = "01/01/1900"; SeguimientoEL.HoraInTD = "00:00"; } else { SeguimientoEL.FechaInTD = dtpDevolucionIngresoFecha.Text; SeguimientoEL.HoraInTD = txtDevolucionIngresoHora.Text; }
                if (dtpDevolucionSalidaFecha.Text.Trim() == "") { SeguimientoEL.FechaSaTD = "01/01/1900"; SeguimientoEL.HoraSaTD = "00:00"; } else { SeguimientoEL.FechaSaTD = dtpDevolucionSalidaFecha.Text; SeguimientoEL.HoraSaTD = txtDevolucionSalidaHora.Text; }

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

                if (codigo == 1)
                {

                    if (chkPernocteInfo.Checked == true)
                    {
                        pernocte = 1;
                    }
                    else
                    {
                        pernocte = 0;
                    }

                    mensaje = oSeguimiento.Proceso1(AL, item, movimiento, solicitud, 1, lblTittle.Text, itemTipo, pies, Convert.ToInt32(ddlUnidadInfo.SelectedValue), ddlUnidadInfo.SelectedItem.ToString(),
                                                    Convert.ToInt32(ddlChoferInfo.SelectedValue), ddlChoferInfo.SelectedItem.ToString(), Convert.ToInt32(ddlEmpresaInfo.SelectedValue),
                                                    0, //ddlEvefnto.value,
                                                    ddlTerminalRetiro.SelectedValue, Convert.ToDateTime(SeguimientoEL.FechaLlTR + " " + SeguimientoEL.HoraLlTR), Convert.ToDateTime(SeguimientoEL.FechaInTR + " " + SeguimientoEL.HoraInTR), Convert.ToDateTime(SeguimientoEL.FechaSaTR + " " + SeguimientoEL.HoraSaTR), txtRetiroObservacion.Text, ent1,
                                                    Convert.ToInt32(ddlClienteLocal.SelectedValue), Convert.ToDateTime(SeguimientoEL.FechaLlCL1 + " " + SeguimientoEL.HoraLlCL1), Convert.ToDateTime(SeguimientoEL.FechaIngCL1 + " " + SeguimientoEL.HoraIngCL1), Convert.ToDateTime(SeguimientoEL.FechaInCL1 + " " + SeguimientoEL.HoraInCL1), Convert.ToDateTime(SeguimientoEL.FechaTeCL1 + " " + SeguimientoEL.HoraTeCL1), Convert.ToDateTime(SeguimientoEL.FechaSaCL1 + " " + SeguimientoEL.HoraSaCL1), txtClienteObservacion.Text,
                                                    /*de aqui todo lo que va con el doble carga*/ "", 0, Convert.ToDateTime("01/01/1990"), Convert.ToDateTime("01/01/1990"),
                                                    Convert.ToDateTime("01/01/1990"), Convert.ToDateTime("01/01/1990"), Convert.ToDateTime("01/01/1990"), "",/*hasta aqui*/
                                                    ddlTerminalDevolucion.SelectedValue, Convert.ToDateTime(SeguimientoEL.FechaLlTD + " " + SeguimientoEL.HoraLlTD), Convert.ToDateTime(SeguimientoEL.FechaInTD + " " + SeguimientoEL.HoraInTD), Convert.ToDateTime(SeguimientoEL.FechaSaTD + " " + SeguimientoEL.HoraSaTD), txtObservacionDevolucion.Text,
                                                    txtPrecintoVacioInfo.Text, txtPrecintoAduanaInfo.Text, txtPrecintoLineaInfo.Text, txtPrecintoTransitoInfo.Text, pEstado,/*pernocte*/ pernocte, 0/*chk doble carga*/, SeguimientoEL.Usuario);

                    if (flag == 1)
                        EnviarCorreoWS(AL.ToString(), item.ToString(), lstNotificaciones, pCliente);
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
        if (dtpDevolucionSalidaFecha.Text.Trim() != "")
        {
            pEstado = "Servicio Concluido";
        }
        else if (dtpDevolucionIngresoFecha.Text.Trim() != "" && dtpDevolucionLlegadaFecha.Text.Trim() != "")
        {
            pEstado = "Completando Ruta";
        }
        else if (dtpClienteSalidaFecha.Text.Trim() != "")
        {
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
        else if (dtpClienteTerminoFecha.Text.Trim() != "")
        {
            //if (chkdoble == 1)
            //{
            //    pEstado = "Termino Carga en 1° Local";
            //}
            //else
            //{
            pEstado = "Termino Carga";
            //}
        }
        else if (dtpClienteInicioFecha.Text.Trim() != "")
        {
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

        //string pBodyCab = "", pBodyDetTR = "", pBodyDetC1 = "", pBodyDetC2 = "", pBodyDetTD = "",
        //    mensaje = "", Encabezado = "", pBody = "", pEstado = "", pBodyPie = "" ;

        string pBC = "", pFrom = "", pCC = "";

        try
        {
            DataTable dtCorreo = objClsOperaciones.GetCorreo();
            DataTable pTabEnvio = objClsOperaciones.EnvioCorreo(Convert.ToInt32(pRo), Convert.ToInt32(pItem),Cliente);
            if (pTabEnvio.Rows.Count > 0)
            {

                StringBuilder tabla_head = new StringBuilder();
                StringBuilder tabla_row = new StringBuilder();
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
                if (pTabEnvio.Rows[0]["Emp"].ToString().Trim() != pTabEnvio.Rows[0]["CodCli"].ToString().Trim())
                {
                    for (int k = 0; k < lstMailClientes.Count; k++)
                    {
                        pFrom += lstMailClientes[k].Mail_MC + ";";
                    }
                }

                //pCC = "soporte@tmeridian.com.pe;";
                //pFrom = "fcamacho@meridian.com.pe;";

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
                    tabla_head.AppendLine("<td>" + (pTabEnvio.Rows[i]["Placa"].ToString().Trim().ToLower() == "seleccione" ? "" : pTabEnvio.Rows[i]["Placa"].ToString().ToLower()) + "</td>");
                    tabla_head.AppendLine("<td>" + (pTabEnvio.Rows[i]["Conductor"].ToString().Trim().ToLower() == "seleccione" ? "" : pTabEnvio.Rows[i]["Placa"].ToString().ToUpper()) + "</td>");
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

                    tabla_head.AppendLine("<td>" + pTabEnvio.Rows[0]["Local1"].ToString() + "</td>");
                    tabla_head.AppendLine("<td>" + pTabEnvio.Rows[0]["ObsTR"].ToString() + (pTabEnvio.Rows[0]["ObsC1"].ToString()) + pTabEnvio.Rows[0]["ObsTD"].ToString() + "</td>");
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
                objClsOperaciones.EnvioMail(pFrom, pCC, pBC, html, "ALERTA DE MONITOREO: " + pTabEnvio.Rows[0]["Placa"].ToString() + "//" + pTabEnvio.Rows[0]["Cliente"].ToString());
                //objClsOperaciones.EnvioMail("carlos.mejia@tmeridian.com.pe", "carlos.mejia@tmeridian.com.pe", "carlos.mejia@tmeridian.com.pe", pBody, pTabEnvio.Rows(0)("Placa"), pRo, pTabEnvio.Rows(0)("Cliente"))

                objClsOperaciones.ActualizarCorreo(Convert.ToInt32(pRo), Convert.ToInt32(pItem));

            }

        }
        catch (Exception ex)
        {
            MostrarMensaje(1, ex.Message);
        }
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

    public void CargarLocal(string pCliente)
    {
        TMS_LocalBL oLocal = new TMS_LocalBL();

        ddlClienteLocal.DataSource = oLocal.GetLocal(pCliente);
        ddlClienteLocal.DataTextField = "DIRECCION";
        ddlClienteLocal.DataValueField = "LOCAL_CODIGO";
        ddlClienteLocal.DataBind();

    }

    public void CargarUnidadTransporte(int pIdEmpresaTransporte, string pValue)
    {
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();

        if (ddlEmpresaInfo.SelectedValue == "88")
        {
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
        }
        else
        {
            ddlChoferInfo.DataSource = oSeguimiento.GetChoferxEmp(Convert.ToInt32(ddlEmpresaInfo.SelectedValue));
            ddlChoferInfo.DataSource = oSeguimiento.GetChoferxEmp(Convert.ToInt32(ddlEmpresaInfo.SelectedValue));
            ddlChoferInfo.DataTextField = "CHOFER";
            ddlChoferInfo.DataValueField = "CHOFER_CODIGO";
        }
        ddlChoferInfo.DataBind();
        //ddlChoferInfo.Items.Add(new ListItem("--Seleccione--", "-1"));
        ddlChoferInfo.SelectedValue = pValue;
    }


    public void ExportarSolicitudMonitoreo()
    {
        TPL_BL objTPL = new TPL_BL();

        //INICIO
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
        //FIN

        var GridView1 = new GridView();

        GridView1.DataSource = objTPL.BuscarSolicitudMonitoreo(Convert.ToInt32(ddlTipoSolicitudFiltro.SelectedValue), ddlMovimientoFiltro.SelectedValue, 
                                                        ddlEstadoFiltro.SelectedValue, "", pSolicitud, pAL, ddlSeguimientoFiltro.SelectedValue,
                                                        Convert.ToDateTime(pFecIni), Convert.ToDateTime(String.IsNullOrEmpty(txtFechaHastaFiltro.Text) ? "01/01/2011" : txtFechaHastaFiltro.Text),
                                                        ddlEmpresaFiltro.SelectedItem.Text, "Todos", pContenedor);
        GridView1.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attacNhment;filename=Reporte_" + DateTime.Now.ToString("ddMMyyyy") + ".xls");
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


    protected void btnExportar_Click(object sender, EventArgs e)
    {
        ExportarSolicitudMonitoreo();
    }

    
}