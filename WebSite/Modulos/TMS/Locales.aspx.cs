using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL;
using BL;
using System.Web.Security;

public partial class Modulos_TMS_Mantenimiento_Locales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (ObtenerDatosSesion("usuario") != "")
            {
                loadItemsProvincia();
                txtUsuarioCreacion.Enabled = false;
                txtUsuarioModificacion.Enabled = false;
                txtFechaCreacion.Enabled = false;
                txtFechaModificacion.Enabled = false;
                loadItemAtencion();
            }
            else
            {
                //Response.Redirect("~/login.aspx");
            }
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


    public void loadItemsProvincia()
    {
        ddlProvincia.Items.Clear();

        TMS_LocalBL oLocalBL = new TMS_LocalBL();
        ddlProvincia.DataSource = oLocalBL.ListarProvincias();
        ddlProvincia.DataTextField = "PROVINCIA_DESCRIPCION";
        ddlProvincia.DataValueField = "PROVINCIA_CODIGO";
        ddlProvincia.DataBind();
        ddlProvincia.SelectedIndex = 0;
    }

    public void loadItemsDistrito()
    {
        ddlDistrito.Items.Clear();

        int ProvinciaID = Convert.ToInt32(ddlProvincia.SelectedValue);

        TMS_LocalBL oLocalBL = new TMS_LocalBL();
        ddlDistrito.DataSource = oLocalBL.ListarDistritos(ProvinciaID);
        ddlDistrito.DataTextField = "DISTRITO_DESCRIP";
        ddlDistrito.DataValueField = "DISTRITO_CODIGO";
        ddlDistrito.DataBind();
        
    }

    public void loadItemAtencion()
    {
        ddlAtencion.Items.Clear();
        ddlAtencion.Items.Add("--Seleccione--");
        ddlAtencion.Items[0].Value = "0";
        ddlAtencion.Items.Add("Mañana");
        ddlAtencion.Items[1].Value = "1";
        ddlAtencion.Items.Add("Tarde");
        ddlAtencion.Items[2].Value = "2";
        ddlAtencion.Items.Add("Noche");
        ddlAtencion.Items[2].Value = "3";
        ddlAtencion.SelectedIndex = 0;
    }

    protected void ListarLocales()
    {
        if (txtEmpresa_id.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler0099", "JAlert('Debe seleccionar un cliente válido.','Información','danger');", true);
        }
        else
        {
            TMS_LocalBL oLocal = new TMS_LocalBL();
            List<TMS_LocalesEL> lst = oLocal.ListarLocales(txtEmpresa_id.Text);
            gvLocales.DataSource = lst;
            gvLocales.DataBind();
        }
    }

    protected void ListarEmpresas()
    {
        TMS_EmpresaBL oEmpresas = new TMS_EmpresaBL();
        List<TMS_EmpresaEL> lista = oEmpresas.ListarEmpresas(oEmpresas.ValoresGeneralesEmpresas());
        gvLocales.DataSource = lista;
        gvLocales.DataBind();

    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        ListarLocales();
        btnAgregar.Visible = true;
    }

    protected void gvLocales_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] arg = new string[2];
        arg = e.CommandArgument.ToString().Split(';');
        switch (e.CommandName.ToString())
        {
            case "Editar":
                //btnAgregarLocal.Text = "Actualizar";
                TMS_LocalBL oLocal = new TMS_LocalBL();
                List<TMS_LocalesEL> lista = oLocal.ListarLocales(arg[0], Convert.ToInt32(arg[1]));
                txtCliente.Text = txtEmpresa.Text;
                txtCliente.Enabled = false;
                txtCodigoCliente.Text = txtEmpresa_id.Text;
                txtCodigoCliente.Enabled = false;
                HFCodigo.Value = arg[1];
                //txtCodigoClienteMant.Text = arg[1];
                //txtCodigoClienteMant.Enabled = false;
                ddlProvincia.SelectedItem.Text = lista[0].PROVINCIA;
                loadItemsDistrito();
                ddlDistrito.SelectedItem.Text = lista[0].DISTRITO;
                txtDireccion.Text = lista[0].DIRECCION;
                txtGeocerca.Text = lista[0].LOCAL_GEOCERCA;
                txtDescripcionLocal.Text = lista[0].LOCAL_DESCRIPCION;

                btnAgregarLocal.Visible = false;
                btnActualizarLocal.Visible = true;

                MultiView1.ActiveViewIndex = 1;

                break;
            default:
                break;
        }

    }

    protected void gvLocales_PreRender(object sender, EventArgs e)
    {
        if (gvLocales.Rows.Count > 0)
        {
            gvLocales.UseAccessibleHeader = true;
            gvLocales.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvLocales.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        txtCliente.Text = txtEmpresa.Text;
        txtCliente.Enabled = false;
        txtCodigoCliente.Text = txtEmpresa_id.Text;
        txtCodigoCliente.Enabled = false;
        hfAction.Value = (gvLocales.Rows.Count + 1).ToString();
        //txtCodigoClienteMant.Text = (gvLocales.Rows.Count+1).ToString();
        //txtCodigoClienteMant.Enabled = false;

        //btnAgregarLocal.Text = "Agregar";

        btnActualizarLocal.Visible = false;

        MultiView1.ActiveViewIndex = 1;
        
    }

    protected void btnAgregarLocal_Click(object sender, EventArgs e)
    {
        try
        {
            
            TMS_LocalesEL oLocalEL = new TMS_LocalesEL();
            oLocalEL.Ent_Codi = txtEmpresa_id.Text;
            oLocalEL.LOCAL_CODIGO = Convert.ToInt32(HFCodigo.Value);
            oLocalEL.CLIENTE = txtCliente.Text;
            oLocalEL.PROVINCIA = ddlProvincia.SelectedValue;
            oLocalEL.DISTRITO_CODIGO = Convert.ToInt32(ddlDistrito.SelectedValue);
            oLocalEL.LOCAL_DIRECCION = txtDireccion.Text;
            oLocalEL.LOCAL_GEOCERCA = txtGeocerca.Text;
            oLocalEL.LOCAL_DESCRIPCION = txtDescripcionLocal.Text;
            if (chkDeshabilitar.Checked == true)
                oLocalEL.ESTADO = "T";
            else
                oLocalEL.ESTADO = "F";
            oLocalEL.LOCAL_USUARIO_CREACION = User.Identity.Name;
            oLocalEL.LOCAL_CODINT = "";
            oLocalEL.LOCAL_HORARIODESDE = txtHoraAtenciónInicio.Text;
            oLocalEL.LOCAL_HORARIOHASTA = txtHoraAtenciónFin.Text;
            oLocalEL.LOCAL_MAILALMACEN = txtMail1.Text;
            oLocalEL.LOCAL_MAILSUBGER = txtMail2.Text;
            oLocalEL.LOCAL_OBSERVACION = txtObservaciones.Text;
            oLocalEL.LOCAL_ATENCION = "0";
            oLocalEL.LOCAL_ALIAS = "";

            TMS_LocalBL oLocalBL = new TMS_LocalBL();
            string Mensaje = "";
            Mensaje = oLocalBL.InsertarLocal(oLocalEL);

            MostrarMensaje(0,"Se agregó el local con éxito.");
            limpiar();
            ListarLocales();
            MultiView1.ActiveViewIndex = 0;

        }catch(Exception ex)
        {
            MostrarMensaje(1, "Ocurrió un problema. Indicar a Sistemas: " + ex.ToString());
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

    protected void btnConfirmación_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModaAprobar').modal('show');", true);
    }

    protected void btnConfirmarActualizar_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModaActualizar').modal('show');", true);
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        btnActualizarLocal.Visible = false;
        btnAgregarLocal.Visible = true;
        limpiar();
    }

    protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadItemsDistrito();
    }

    protected void limpiar()
    {
        txtCliente.Text = "";
        txtCodigoCliente.Text = "";
        //txtCodigoClienteMant.Text = "";
        txtDescripcionLocal.Text = "";
        txtDireccion.Text = "";
        txtFechaCreacion.Text = "";
        txtFechaModificacion.Text = "";
        txtGeocerca.Text = "";
        txtHoraAtenciónFin.Text = "";
        txtHoraAtenciónInicio.Text = "";
        txtMail1.Text = "";
        txtMail2.Text = "";
        txtObservaciones.Text = "";
        txtUsuarioCreacion.Text = "";
        txtUsuarioModificacion.Text = "";
        ddlProvincia.SelectedIndex = 0;
        ddlDistrito.Items.Clear();
        chkDeshabilitar.Checked = false;
    }


    protected void btnActualizarLocal_Click(object sender, EventArgs e)
    {
        //TMS_LocalesEL LocalEL = new TMS_LocalesEL();
        //TMS_LocalBL oLocal = new TMS_LocalBL();

        //List<TransaccionEL> lstTransaccion = oLocal.ActualizarLocal(LocalEL);
        //List<TMS_LocalesEL> lstLocal = oLocal.ListarLocales(gvLocal.Rows(vFila).Cells(0).Text, gvLocal.Rows(vFila).Cells(1).Text).Tables(0)
    }
}