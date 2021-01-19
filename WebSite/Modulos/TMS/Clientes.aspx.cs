using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using DAL;
using EL;

public partial class Modulos_TMS_Clientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (ObtenerDatosSesion("usuario") != "")
            //{
                ListarClientes();
            //}
            //else
            //    Response.Redirect("~/login.aspx");
            
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

    protected void limpiar()
    {
        txtEmpresa_id.Text = "";
        txtEmpresa.Text = "";
        txtCliente.Text = "";
        txtRUC.Text = "";

        txtSubEmpresa.Text = "";
        txtSubEmpresa_id.Text = "";
        txtSubCliente.Text = "";
        txtRUC_SubCliente.Text = "";

        btnAgregar.Visible = true;
        btnActualizar.Visible = false;
        btnCancelar.Visible = false;

        btnAgregar_SubCliente.Visible = true;
        btnActualizar_SubCliente.Visible = false;
        btnCancelar_SubCliente.Visible = false;

        txtMailCliente.Text = "";
        
        //chkAdicionalChofer.Checked = false;
        //chkAdicionalEmpresa.Checked = false;
        //chkAdicionalPctAduana.Checked = false;
        //chkAdicionalPctLinea.Checked = false;
        //chkAdicionalPctTransito.Checked = false;
        //chkAdicionalPctVacio.Checked = false;
        //chkAdicionalPernocte.Checked = false;
        //chkAdicionalUnidad.Checked = false;

        chkHeredarAsignacion.Visible = true;
        chkHeredarAsignacion.Checked = false;

        chkConsolidarAsignacion.Visible = true;
        chkConsolidarAsignacion.Checked = false;

        chkDevolucionIngreso.Checked = false;
        chkDevolucionLlegada.Checked = false;
        chkDevolucionObservacion.Checked = false;
        chkDevolucionSalida.Checked = false;

        chkLocalIngreso.Checked = false;
        chkLocalInicio.Checked = false;
        chkLocalLlegada.Checked = false;
        chkLocalObservacion.Checked = false;
        chkLocalSalida.Checked = false;
        chkLocalTermino.Checked = false;

        chkRetiroIngreso.Checked = false;
        chkRetiroLlegada.Checked = false;
        chkRetiroObservacion.Checked = false;
        chkRetiroSalida.Checked = false;
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            TMS_ClientesBL oClientes = new TMS_ClientesBL();
            List<TransaccionEL> lst = oClientes.AgregarCliente(txtEmpresa_id.Text, txtEmpresa.Text, txtRUC.Text, User.Identity.Name);
            limpiar();
            MostrarMensaje(lst[0].id_mensaje, lst[0].mensaje);
            ListarClientes();
        }
        catch(Exception ex)
        {
            MostrarMensaje(1, "Error. " + ex);
        }
    }

    protected void ListarClientes()
    {
        TMS_ClientesBL oCliente = new TMS_ClientesBL();
        List<TMS_ClientesEL> lista = oCliente.Listar_ClientesSAP("",txtFiltroCliente.Text.Trim(),Convert.ToInt32(ddlFiltroEstadoCliente.SelectedValue));
        gvClientes.DataSource = lista;
        gvClientes.DataBind();
    }

    protected void ListarSubClientes(string cod_cliente)
    {
        TMS_ClientesBL oCliente = new TMS_ClientesBL();
        List<TMS_SubClientesEL> lista = oCliente.ListarSubClientes(cod_cliente);
        gvSubClientes.DataSource = lista;
        gvSubClientes.DataBind();
    }

    protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] arg = new string[2];
        arg = e.CommandArgument.ToString().Split(';');

        TMS_ClientesBL oCliente = new TMS_ClientesBL();

        switch (e.CommandName.ToString())
        {
            case "Retirar":
                txtEmpresa_id.Text = arg[0].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModaAprobar').modal('show');", true);
                break;
            case "Agregar":

                try
                {
                    TMS_ClientesBL oClientes = new TMS_ClientesBL();
                    List<TMS_ClientesEL> lstEditar = oClientes.Listar_ClientesSAP(e.CommandArgument.ToString(), "", -1);
                    if (lstEditar.Count() > 0)
                    {
                        List<TransaccionEL> lst = oClientes.AgregarCliente(lstEditar[0].Cod_Empresa, lstEditar[0].Raz_Soc, lstEditar[0].Ruc, User.Identity.Name);
                        MostrarMensaje(lst[0].id_mensaje, lst[0].mensaje);
                        ListarClientes();
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje(1, "Error. " + ex);
                }

                break;

            case "Editar":
                limpiar();

                btnAgregar.Visible = false;
                btnActualizar.Visible = true;
                btnCancelar.Visible = true;

                txtEmpresa.Visible = false;
                txtCliente.Visible = true;

                List<TMS_ClientesEL> listaEditar = oCliente.ListarClientes(arg[0].ToString());

                txtEmpresa_id.Text = listaEditar[0].Cod_Empresa;
                txtRUC.Text = listaEditar[0].Ruc;
                txtCliente.Text = listaEditar[0].Raz_Soc;
                
                break;
            case "Detalles":

                limpiar();
                lblTituloCliente.Text = arg[1].ToString();
                HFIDCliente.Value = arg[0].ToString();
                MultiView1.ActiveViewIndex = 1;
                ListarSubClientes(arg[0].ToString());
                
                //Response.Redirect("SeguimientoTransportes.aspx?IdMenu=2&Mov=" + ddlMovimiento.SelectedValue.ToString() + "&Enti=" + pEntidad + "&Segui=" + pSeguimiento);
                break;
            case "Eliminar":
                HFIDEliminar.Value = arg[0].ToString();
                txtEmpresa_id.Text = arg[0].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModaAprobar').modal('show');", true);
                break;
            case "Asignacion_Horas":
                Session["CodCliente"] = arg[0].ToString();
                limpiar();
                ddlMovimientoCorreo.SelectedIndex = 0;
                lblTittle.Text = Session["CodCliente"].ToString();
                ValidarAsignaciones(arg[0].ToString());
                if (chkHeredarAsignacion.Checked)
                {
                    chkConsolidarAsignacion.Enabled = true;
                }
                else
                {
                    chkConsolidarAsignacion.Enabled = false;
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAsignarHoras').modal('show');", true);
                break;
            case "Asignacion_Correos":
                lblTitle.Text = arg[0].ToString();
                chkHeredarAsignacion.Visible = false;
                chkConsolidarAsignacion.Visible = false;
                CargarCorreosDestino(arg[0].ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAsignarCorreos').modal('show');", true);
                break;
            default:
                break;
        }
    }

    private void CargarCorreosDestino(string Ent_Codi)
    {
        TMS_EmailClienteBL oEmailCliente = new TMS_EmailClienteBL();
        List<TMS_EmailClienteEL> lista = oEmailCliente.GetCorreoCliente(Ent_Codi);
        gvDestinatarios.DataSource = lista;
        gvDestinatarios.DataBind();
    }

    protected void gvClientes_PreRender(object sender, EventArgs e)
    {
        if (gvClientes.Rows.Count > 0)
        {
            gvClientes.UseAccessibleHeader = true;
            gvClientes.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvClientes.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void ddlMovimientoAsignacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAsignarHoras').modal('show');", true);
        ValidarAsignaciones(lblTittle.Text);
        
    }

    private void ValidarAsignaciones(string Ent_Codi)
    {
        try
        {

            TMS_NotificacionesBL oNotificaciones = new TMS_NotificacionesBL();
            List<TMS_NotificacionesEL> lstNotificaciones = oNotificaciones.ListarNotificacionesXCliente(Ent_Codi,ddlMovimientoAsignacion.SelectedValue);

            TMS_ClientesBL oCliente = new TMS_ClientesBL();
            List<TMS_ClientesEL> lstClientes = oCliente.ListarClientes(lblTittle.Text);

            if (lstNotificaciones.Count == 0)
            {
                //oNotificaciones.CrearNotificacionesXCliente(Ent_Codi, User.Identity.Name);
                chkRetiroLlegada.Checked = true;
                chkRetiroIngreso.Checked = true;
                chkRetiroSalida.Checked = true;
                chkRetiroObservacion.Checked = true;

                chkLocalLlegada.Checked = true;
                chkLocalIngreso.Checked = true;
                chkLocalInicio.Checked = true;
                chkLocalTermino.Checked = true;
                chkLocalSalida.Checked = true;
                chkLocalObservacion.Checked = true;

                chkDevolucionLlegada.Checked = true;
                chkDevolucionIngreso.Checked = true;
                chkDevolucionSalida.Checked = true;
                chkDevolucionObservacion.Checked = true;

                chkHeredarAsignacion.Checked = false;
                chkConsolidarAsignacion.Checked = false;
                
            }
            else
            {
                chkRetiroLlegada.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_RLlegada);
                chkRetiroIngreso.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_RIngreso);
                chkRetiroSalida.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_RSalida);
                chkRetiroObservacion.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_RObs);

                chkLocalLlegada.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_CLlegada);
                chkLocalIngreso.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_CIngreso);
                chkLocalInicio.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_CInicio);
                chkLocalTermino.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_CTermino);
                chkLocalSalida.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_CSalida);
                chkLocalObservacion.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_CObs);

                chkDevolucionLlegada.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_DLlegada);
                chkDevolucionIngreso.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_DIngreso);
                chkDevolucionSalida.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_DSalida);
                chkDevolucionObservacion.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_DObs);

                //chkAdicionalEmpresa.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_InfoEmpresa);
                //chkAdicionalUnidad.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_InfoUnidad);
                //chkAdicionalChofer.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_InfoChofer);
                //chkAdicionalPctLinea.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_InfoPLinea);
                //chkAdicionalPctAduana.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_InfoPAduana);
                //chkAdicionalPctVacio.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_InfoPCTNVacio);
                //chkAdicionalPctTransito.Checked = Convert.ToBoolean(lstNotificaciones[0].Ntf_InfoPTrans);

                //TMS_SeguimientoBL objClsOperaciones = new TMS_SeguimientoBL();
                //DataTable tbCorreos = objClsOperaciones.GetCorreoCliente(Session["CodCliente"].ToString());
                //for (int i = 0; i < tbCorreos.Rows.Count; i++)
                //{
                //    txtContactosDestino.Text += tbCorreos.Rows[i]["Mail"].ToString() + " ; ";
                //}

                chkConsolidarAsignacion.Enabled = false;

                if (lstClientes.Count==1 && lstClientes[0].Herencia=="1")
                    chkHeredarAsignacion.Checked = true;
                if(lstClientes.Count==1 && lstClientes[0].ConsolidarAsignacion == "1")
                {
                    chkConsolidarAsignacion.Checked = true;
                    chkConsolidarAsignacion.Enabled = true;
                }
                
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "Error:" + ex.Message);
        }
    }

    protected void btnGuardarAsignacion_Click(object sender, EventArgs e)
    {
        try
        {
            TMS_NotificacionesBL oNotificaciones = new TMS_NotificacionesBL();
            TMS_NotificacionesEL NotificacionesEL = new TMS_NotificacionesEL();
            TMS_ClientesBL oCliente = new TMS_ClientesBL();

            NotificacionesEL.Ent_Codi = lblTittle.Text;

            NotificacionesEL.Ntf_RLlegada = chkRetiroLlegada.Checked;
            NotificacionesEL.Ntf_RIngreso = chkRetiroIngreso.Checked;
            NotificacionesEL.Ntf_RSalida = chkRetiroSalida.Checked;
            NotificacionesEL.Ntf_RObs = false;

            NotificacionesEL.Ntf_CLlegada = chkLocalLlegada.Checked;
            NotificacionesEL.Ntf_CIngreso = chkLocalIngreso.Checked;
            NotificacionesEL.Ntf_CInicio = chkLocalInicio.Checked;
             NotificacionesEL.Ntf_CTermino = chkLocalTermino.Checked;
            NotificacionesEL.Ntf_CSalida = chkLocalSalida.Checked;
            NotificacionesEL.Ntf_CObs = false;

            if (chkDevolucionLlegada.Checked) NotificacionesEL.Ntf_DLlegada = chkDevolucionLlegada.Checked;
            if (chkDevolucionIngreso.Checked) NotificacionesEL.Ntf_DIngreso = chkDevolucionIngreso.Checked;
            if (chkDevolucionSalida.Checked) NotificacionesEL.Ntf_DSalida = chkDevolucionSalida.Checked;
            NotificacionesEL.Ntf_DObs = false;

            //if (chkAdicionalEmpresa.Checked) NotificacionesEL.Ntf_InfoEmpresa = true; else NotificacionesEL.Ntf_InfoEmpresa = false;
            //if (chkAdicionalUnidad.Checked) NotificacionesEL.Ntf_InfoUnidad = true; else NotificacionesEL.Ntf_InfoUnidad = false;
            //if (chkAdicionalChofer.Checked) NotificacionesEL.Ntf_InfoChofer = true; else NotificacionesEL.Ntf_InfoChofer = false;
            //if (chkAdicionalPctLinea.Checked) NotificacionesEL.Ntf_InfoPLinea = true; else NotificacionesEL.Ntf_InfoPLinea = false;
            //if (chkAdicionalPctAduana.Checked) NotificacionesEL.Ntf_InfoPAduana = true; else NotificacionesEL.Ntf_InfoPAduana = false;
            //if (chkAdicionalPctVacio.Checked) NotificacionesEL.Ntf_InfoPCTNVacio = true; else NotificacionesEL.Ntf_InfoPCTNVacio = false;
            //if (chkAdicionalPctTransito.Checked) NotificacionesEL.Ntf_InfoPTrans = true; else NotificacionesEL.Ntf_InfoPTrans = false;

            //NotificacionesEL.Ntf_InfoEmpresa = false;
            //NotificacionesEL.Ntf_InfoUnidad = false;
            //NotificacionesEL.Ntf_InfoChofer = false;
            //NotificacionesEL.Ntf_InfoPLinea = false;
            //NotificacionesEL.Ntf_InfoPAduana = false;
            //NotificacionesEL.Ntf_InfoPCTNVacio = false;
            //NotificacionesEL.Ntf_InfoPTrans = false;

            NotificacionesEL.Usuario_Modificacion = User.Identity.Name;

            if (chkHeredarAsignacion.Checked)
            {
                oCliente.ActualizarHerencia(NotificacionesEL.Ent_Codi,true);
            }
            else
            {
                oCliente.ActualizarHerencia(NotificacionesEL.Ent_Codi, false);
            }

            oCliente.ActualizarConsolidado(NotificacionesEL.Ent_Codi, chkConsolidarAsignacion.Checked);

            NotificacionesEL.Movimiento = ddlMovimientoAsignacion.SelectedValue;
            
            oNotificaciones.ActualizarNotificaciones(NotificacionesEL);

            MostrarMensaje(0,"Se actualizaron las notificaciones.");
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "Error:" + ex.Message);
        }

    }

    protected void btnAgregarCorreo_Click(object sender, EventArgs e)
    {
        try
        {
            TMS_EmailClienteBL oEmail = new TMS_EmailClienteBL();
            oEmail.InsertarCorreo(lblTitle.Text, txtMailCliente.Text, ddlMovimientoCorreo.SelectedValue, User.Identity.Name);
            CargarCorreosDestino(lblTitle.Text);

            txtMailCliente.Text = "";
            ddlMovimientoCorreo.SelectedIndex = 0;

            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAsignarCorreos').modal('show');", true);
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "Error:" + ex.Message);
        }
        
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            TMS_ClientesBL oCliente = new TMS_ClientesBL();
            List<TransaccionEL> lista = oCliente.ActualizarCliente(txtEmpresa_id.Text, txtCliente.Text, txtRUC.Text, User.Identity.Name);
            limpiar();
            MostrarMensaje(lista[0].id_mensaje, lista[0].mensaje);
            
            txtCliente.Visible = false;
            txtEmpresa.Visible = true;

            limpiar();

            ListarClientes();

        }
        catch(Exception ex)
        {
            MostrarMensaje(1, "Error. " + ex);
        }
        
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            TMS_ClientesBL oCliente = new TMS_ClientesBL();
            List<TransaccionEL> listaEliminar = oCliente.EliminarCliente(txtEmpresa_id.Text, User.Identity.Name);
            MostrarMensaje(listaEliminar[0].id_mensaje, listaEliminar[0].mensaje);
            ListarClientes();
        }
        catch(Exception ex)
        {
            MostrarMensaje(1, "Error. " + ex);
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        txtCliente.Visible = false;
        txtEmpresa.Visible = true;

        limpiar();

        ListarClientes();
    }

    protected void btnAgregar_SubCliente_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtRUC_SubCliente.Text.Trim() == "" || txtRUC_SubCliente.Text.Trim().Length < 11)
            {
                MostrarMensaje(1, "Ruc incorrecto");
                return;
            }
            if (txtSubEmpresa.Text.Trim() == ""  )
            {
                MostrarMensaje(1, "Ingresar razon social");
                return;
            }

            TMS_ClientesBL oClientes = new TMS_ClientesBL();
            List<TransaccionEL> lst = oClientes.AgregarSubCliente( txtSubEmpresa_id.Text, HFIDCliente.Value, txtSubEmpresa.Text, txtRUC_SubCliente.Text, txtDireccion_SubCliente.Text, User.Identity.Name);
            limpiar();
            MostrarMensaje(lst[0].id_mensaje, lst[0].mensaje);
            ListarSubClientes(HFIDCliente.Value);
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "Error. " + ex.Message.ToString().Replace("'",""));
        }
    }

    protected void btnActualizar_SubCliente_Click(object sender, EventArgs e)
    {
        try
        {
            TMS_ClientesBL oSubCliente = new TMS_ClientesBL();
            List<TransaccionEL> lista = oSubCliente.ActualizarSubCliente(txtSubEmpresa_id.Text, txtSubCliente.Text, txtRUC_SubCliente.Text, User.Identity.Name);
            limpiar();

            txtSubCliente.Visible = false;
            txtSubEmpresa.Visible = true;

            MostrarMensaje(lista[0].id_mensaje, lista[0].mensaje);

            ListarSubClientes(Session["Codigo_Cliente"].ToString());
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "Error. " + ex);
        }
    }

    protected void btnEliminar_SubCliente_Click(object sender, EventArgs e)
    {
        try
        {
            TMS_ClientesBL oCliente = new TMS_ClientesBL();
            List<TransaccionEL> listaEliminar = oCliente.EliminarSubCliente(txtSubEmpresa_id.Text, User.Identity.Name);
            MostrarMensaje(listaEliminar[0].id_mensaje, listaEliminar[0].mensaje);
            ListarSubClientes(HFIDCliente.Value);
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "Error. " + ex);
        }

    }

    protected void gvSubClientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] arg = new string[2];
        arg = e.CommandArgument.ToString().Split(';');

        TMS_ClientesBL oCliente = new TMS_ClientesBL();

        switch (e.CommandName.ToString())
        {
            case "Editar":
                limpiar();

                btnAgregar_SubCliente.Visible = false;
                btnActualizar_SubCliente.Visible = true;
                btnCancelar_SubCliente.Visible = true;

                txtSubEmpresa.Visible = false;
                txtSubCliente.Visible = true;

                List<TMS_SubClientesEL> listaEditar = oCliente.ListarSubClientes(Session["Codigo_Cliente"].ToString(), arg[1].ToString());

                txtSubEmpresa_id.Text = listaEditar[0].Cod_Empresa;
                txtRUC_SubCliente.Text = listaEditar[0].RUC;
                txtSubCliente.Text = listaEditar[0].Raz_Soc;
                txtEmpresa_id.Text = listaEditar[0].Cod_Empresa_Padre;
                break;

            case "Eliminar":
                HFIDEliminar.Value = arg[0].ToString();
                txtSubEmpresa_id.Text = arg[0].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModaEliminar_SubCliente').modal('show');", true);
                break;
            case "Asignacion_Horas":

                Session["CodCliente"] = arg[0].ToString();
                limpiar();
                lblTittle.Text = Session["CodCliente"].ToString();
                ddlMovimientoCorreo.SelectedIndex = 0;
                
                chkHeredarAsignacion.Visible = false;

                ValidarAsignaciones(arg[0].ToString());
                
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAsignarHoras').modal('show');", true);
                break;
            case "Asignacion_Correos":
                lblTitle.Text = arg[0].ToString();
                chkHeredarAsignacion.Visible = false;
                CargarCorreosDestino(arg[0].ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAsignarCorreos').modal('show');", true);
                break;
            default:
                break;
        }
    }

    protected void gvSubClientes_PreRender(object sender, EventArgs e)
    {
        if (gvSubClientes.Rows.Count > 0)
        {
            gvSubClientes.UseAccessibleHeader = true;
            gvSubClientes.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvSubClientes.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }


    protected void btnCancelar_SubCliente_Click(object sender, EventArgs e)
    {
        limpiar();
        ddlMovimientoCorreo.SelectedIndex = 0;
        txtSubEmpresa.Visible = true;
        txtSubCliente.Visible = false;
    }



    protected void gvDestinatarios_PreRender(object sender, EventArgs e)
    {
        if (gvDestinatarios.Rows.Count > 0)
        {
            gvDestinatarios.UseAccessibleHeader = true;
            gvDestinatarios.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvDestinatarios.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void gvDestinatarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] arg = new string[3];
        arg = e.CommandArgument.ToString().Split(';');

        TMS_ClientesBL oCliente = new TMS_ClientesBL();

        switch (e.CommandName.ToString())
        {
            //case "Editar":
            //    limpiar();

            //    btnAgregar_SubCliente.Visible = false;
            //    btnActualizar_SubCliente.Visible = true;
            //    btnCancelar_SubCliente.Visible = true;

            //    txtSubEmpresa.Visible = false;
            //    txtSubCliente.Visible = true;

            //    List<TMS_SubClientesEL> listaEditar = oCliente.ListarSubClientes(Session["Codigo_Cliente"].ToString(), arg[1].ToString());

            //    txtSubEmpresa_id.Text = listaEditar[0].Cod_Empresa;
            //    txtRUC_SubCliente.Text = listaEditar[0].RUC;
            //    txtSubCliente.Text = listaEditar[0].Raz_Soc;

            //    break;

            case "Eliminar":
                EliminarCorreoCliente(arg[0].ToString(),arg[2].ToString(),arg[1].ToString());
                CargarCorreosDestino(arg[0].ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAsignarCorreos').modal('show');", true);
                break;
            default:
                break;
        }
    }
    protected void EliminarCorreoCliente(string Ent_Codi, string Movimiento, string correo)
    {
        TMS_EmailClienteBL oEmail = new TMS_EmailClienteBL();
        List<TransaccionEL> lst = oEmail.EliminarCorreoCliente(Ent_Codi, Movimiento, correo);
        MostrarMensaje(lst[0].id_mensaje, lst[0].mensaje);
    }
    
    protected void gvDestinatarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();

            GridViewRow rowEvento = (GridViewRow)e.Row.Cells[2].NamingContainer;
            Label lblMovimiento_MC = (Label)rowEvento.FindControl("lblMovimiento_MC");

            if (lblMovimiento_MC.Text == "I" || lblMovimiento_MC.Text == "i")
            {
                lblMovimiento_MC.Text = "Importacion";
                lblMovimiento_MC.CssClass = "label btn-info";
            }

            if (lblMovimiento_MC.Text == "E" || lblMovimiento_MC.Text == "e")
            {
                lblMovimiento_MC.Text = "Exportacion";
                lblMovimiento_MC.CssClass = "label btn-success";
            }

        }
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        ddlMovimientoCorreo.SelectedIndex = 0;
        limpiar();
    }

    protected void btnBuscarCliente_Click(object sender, EventArgs e)
    {
        ListarClientes();
    }

    protected void chkHeredarAsignacion_CheckedChanged(object sender, EventArgs e)
    {
        if (chkHeredarAsignacion.Checked)
        {
            chkConsolidarAsignacion.Enabled = true;
            chkConsolidarAsignacion.Checked = false;
        }
        else
        {
            chkConsolidarAsignacion.Enabled = false;
            chkConsolidarAsignacion.Checked = false;
        }
        

        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAsignarHoras').modal('show');", true);
    }
}