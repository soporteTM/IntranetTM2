using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Solicitud_ManttoEntidadesX : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            ListarCliente();
            Perfil();
            loadItems(ddlDocumento, "01");
            loadDepartamento();
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

    protected void lnkAgregar_Click(object sender, EventArgs e)
    {

        LimpiarCliente();
        hfAccion.Value = "registrar";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalCliente').modal('show');", true);

    }

    public void LimpiarCliente()
    {
        ddlDocumento.SelectedIndex = 0;
        txtNroDocumento.Text = "";
        txtRazon.Text = "";
        txtNomComercial.Text = "";
        txtDireccion.Text = "";
    }

    public void loadItems(DropDownList ddl, string id_catalogo)
    {
        ItemBL oItem = new ItemBL();
        ddl.DataSource = oItem.ListarItemOperaciones(id_catalogo);
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("", ""));

    }

    public void loadDepartamento()
    {
        MantenimientoBL oItem = new MantenimientoBL();
        ddlDepartamento.DataSource = oItem.ListarDepartamento();
        ddlDepartamento.DataTextField = "descripcion";
        ddlDepartamento.DataValueField = "id_descripcion";
        ddlDepartamento.DataBind();
        ddlDepartamento.Items.Insert(0, new ListItem("", ""));
    }

    public void loadProvincia(string cod_dep)
    {
        MantenimientoBL oItem = new MantenimientoBL();
        ddlProvincia.DataSource = oItem.ListarProvincia(cod_dep);
        ddlProvincia.DataTextField = "descripcion";
        ddlProvincia.DataValueField = "id_descripcion";
        ddlProvincia.DataBind();
        ddlProvincia.Items.Insert(0, new ListItem("", ""));
    }

    public void loadDistrito(string cod_dep, string cod_pro)
    {
        MantenimientoBL oItem = new MantenimientoBL();
        ddlDistrito.DataSource = oItem.ListarDistrito(cod_dep, cod_pro);
        ddlDistrito.DataTextField = "descripcion";
        ddlDistrito.DataValueField = "id_descripcion";
        ddlDistrito.DataBind();
        ddlDistrito.Items.Insert(0, new ListItem("", ""));
    }

    public void ListarCliente()
    {
        MantenimientoClienteBL oCliente = new MantenimientoClienteBL();
        List<MantenimientoClienteEL> lst = oCliente.ListarCliente();
        grvClientes.DataSource = lst;
        grvClientes.DataBind();
    }

    public void ListarLocal()
    {
            MantenimientoLocalBL oLocal = new MantenimientoLocalBL();
            List<MantenimientoLocalEL> lst = oLocal.ListarLocal(Convert.ToInt32(hfClienteID.Value));
            grvLocal.DataSource = lst;
            grvLocal.DataBind();
    }

    public void ListarContacto()
    {
        MantenimientoContactoBL oContacto = new MantenimientoContactoBL();
        MantenimientoContactoEL oContactoEL = new MantenimientoContactoEL();
        oContactoEL.codigo_cliente = Convert.ToInt32(hfClienteID.Value);
        List<MantenimientoContactoEL> lst = oContacto.ListarContacto(oContactoEL);
        grvContacto.DataSource = lst;
        grvContacto.DataBind();
    }

    public void RegistrarCliente()
    {
        MantenimientoClienteBL oCliente = new MantenimientoClienteBL();
        MantenimientoClienteEL ClienteEL = new MantenimientoClienteEL();
        ClienteEL.tipo_documento = ddlDocumento.SelectedValue;
        ClienteEL.nro_documento = txtNroDocumento.Text;
        ClienteEL.razon_social = txtRazon.Text;
        ClienteEL.nombre_comercial = txtNomComercial.Text;
        ClienteEL.direccion = txtDireccion.Text;
        ClienteEL.usuario_creacion = hfUsuario.Value;
        oCliente.InsertarCliente(ClienteEL);
    }

    public void RegistrarLocal()
    {
        string codUbigeo = "000000";

        if (ddlDistrito.SelectedIndex > 0)
        {
            codUbigeo = ddlDistrito.SelectedValue;
        }
        else if (ddlProvincia.SelectedIndex > 0)
        {
            codUbigeo = ddlProvincia.SelectedValue;
        }
        else if (ddlDepartamento.SelectedIndex > 0)
        {
            codUbigeo = ddlDepartamento.SelectedValue;
        }

        MantenimientoLocalBL oLocal = new MantenimientoLocalBL();
        MantenimientoLocalEL oLocalEL = new MantenimientoLocalEL();
        oLocalEL.codigo_cliente = Convert.ToInt32(hfClienteID.Value);
        oLocalEL.direccion = txtDireccionLocal.Text;

        
        

        oLocalEL.codigo_ubigeo = codUbigeo;
        oLocalEL.usuario_creacion = hfUsuario.Value;
        oLocal.InsertarLocal(oLocalEL);
    }

    public void RegistrarContacto()
    {
        MantenimientoContactoBL oContacto = new MantenimientoContactoBL();
        MantenimientoContactoEL ContactoEL = new MantenimientoContactoEL();
        ContactoEL.codigo_cliente = Convert.ToInt32(hfClienteID.Value);
        ContactoEL.nombre = txtNombre.Text;
        ContactoEL.apellido_pat = txtApePaterno.Text;
        ContactoEL.apellido_mat = txtApeMaterno.Text;
        ContactoEL.cargo = txtCargo.Text;
        ContactoEL.correo = txtCorreo.Text;
        ContactoEL.telefono = txtTelefono.Text;
        ContactoEL.anexo = txtAnexo.Text;
        ContactoEL.fecha_nacimiento = txtFchNacimiento.Text;
        ContactoEL.observacion = txtObservacion.Text;
        ContactoEL.usuario_creacion = hfUsuario.Value;
        oContacto.InsertarContacto(ContactoEL);
    }

    public void ModificarCliente()
    {
        MantenimientoClienteBL oCliente = new MantenimientoClienteBL();
        MantenimientoClienteEL ClienteEL = new MantenimientoClienteEL();
        ClienteEL.codigo_cliente = Convert.ToInt32(hfClienteID.Value);
        ClienteEL.tipo_documento = ddlDocumento.SelectedValue;
        ClienteEL.nro_documento = txtNroDocumento.Text;
        ClienteEL.razon_social = txtRazon.Text;
        ClienteEL.nombre_comercial = txtNomComercial.Text;
        ClienteEL.direccion = txtDireccion.Text;
        ClienteEL.usuario_modificacion = hfUsuario.Value;
        oCliente.ModificarCliente(ClienteEL);
    }
    public void ModificarLocal()
    {
        MantenimientoLocalBL oLocal = new MantenimientoLocalBL();
        MantenimientoLocalEL oLocalEL = new MantenimientoLocalEL();
        oLocalEL.codigo_cliente = Convert.ToInt32(hfClienteID.Value);
        oLocalEL.codigo_local = Convert.ToInt32(hfLocalID.Value);
        oLocalEL.direccion = txtDireccionLocal.Text;
        oLocalEL.codigo_ubigeo = ddlDepartamento.SelectedValue + ddlProvincia.SelectedValue + ddlDistrito.SelectedValue;
        oLocalEL.usuario_modificacion = hfUsuario.Value;

        



        //loadProvincia(codUbigeo.Substring(0, 2));

        oLocal.ModificarLocal(oLocalEL);
    }

    public void ModificarContacto()
    {
        MantenimientoContactoBL oContacto = new MantenimientoContactoBL();
        MantenimientoContactoEL ContactoEL = new MantenimientoContactoEL();
        ContactoEL.contacto_id = Convert.ToInt32(hfContactoID.Value);
        ContactoEL.codigo_cliente = Convert.ToInt32(hfClienteID.Value);
        ContactoEL.nombre = txtNombre.Text;
        ContactoEL.apellido_pat = txtApePaterno.Text;
        ContactoEL.apellido_mat = txtApeMaterno.Text;
        ContactoEL.cargo = txtCargo.Text;
        ContactoEL.correo = txtCorreo.Text;
        ContactoEL.telefono = txtTelefono.Text;
        ContactoEL.anexo = txtAnexo.Text;
        ContactoEL.fecha_nacimiento = txtFchNacimiento.Text;
        ContactoEL.observacion = txtObservacion.Text;
        ContactoEL.usuario_modificacion = hfUsuario.Value;
        oContacto.ModificarContacto(ContactoEL);
    }

    public void EliminarCliente(string cod)
    {
        MantenimientoClienteBL oCliente = new MantenimientoClienteBL();
        MantenimientoClienteEL ClienteEL = new MantenimientoClienteEL();
        ClienteEL.codigo_cliente = Convert.ToInt32(cod);
        ClienteEL.usuario_modificacion = hfUsuario.Value;
        oCliente.EliminarCliente(ClienteEL);
    }

    public void EliminarLocal(int cod_local)
    {
        MantenimientoLocalBL oLocal = new MantenimientoLocalBL();
        MantenimientoLocalEL oLocalEL = new MantenimientoLocalEL();
        oLocalEL.codigo_cliente = Convert.ToInt32(hfClienteID.Value);
        oLocalEL.codigo_local = cod_local;
        oLocalEL.usuario_modificacion = hfUsuario.Value;
        oLocal.EliminarLocal(oLocalEL);
    }

    public void EliminarContacto(int contacto_id)
    {
        MantenimientoContactoBL oContacto = new MantenimientoContactoBL();
        MantenimientoContactoEL ContactoEL = new MantenimientoContactoEL();
        ContactoEL.codigo_cliente = Convert.ToInt32(hfClienteID.Value);
        ContactoEL.contacto_id = contacto_id;
        ContactoEL.usuario_modificacion = hfUsuario.Value;
        oContacto.EliminarContacto(ContactoEL);
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


     protected string ValidacionRegstroCliente()
    {
        string rpt="0Se registró correctamente";
        try
        {
            
            if (ddlDocumento.SelectedIndex == 2 && txtNroDocumento.Text.Length > 9)
            {
                rpt = "1Ingrese el DNI correctamente.";
            }
            else if (ddlDocumento.SelectedIndex == 1 && txtNroDocumento.Text.Length > 12)
            {
                rpt = "1Ingrese el RUC correctamente.";
            }
            else if (ddlDocumento.SelectedIndex == 3 && txtNroDocumento.Text.Length > 10)
            {
                rpt = "1Ingrese el CE correctamente.";
            }

            foreach (GridViewRow gridView in this.grvClientes.Rows)
            {
                
                string numeroDocumento = grvClientes.Rows[gridView.RowIndex].Cells[3].Text;
                if (numeroDocumento.Equals(txtNroDocumento.Text))
                {
                    rpt = "1Numero de documento duplicado.";
                }
            }
        }
        catch (Exception ex) 
        {
            rpt = "1Ingresar datos correctamente.";
        }
        
        return rpt;
    }
    protected void lnkRegistrar_Click(object sender, EventArgs e)
    {
        try
        {
            switch (hfAccion.Value)
            {
                case "registrar":
                    string validacion = ValidacionRegstroCliente();
                    int codigomensaje = Convert.ToInt32(validacion.Substring(0, 1));
                    string mensaje = validacion.Substring(1, validacion.Length - 1);
                    if (codigomensaje==0)
                    {
                        RegistrarCliente();
                        ListarCliente();
                        
                    }
                    

                    MostrarMensaje(codigomensaje, mensaje);
                    break;

                case "editar":
                    ModificarCliente();
                    ListarCliente();
                    MostrarMensaje(0, "Se Modifico Correctamente");
                    break;
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se logro " + hfAccion.Value + " el registro");
        }
    }

    public void setTabs()
    {
        li1.Attributes.Add("class", "");
        li2.Attributes.Add("class", "");
    }

    protected void lnkLocal_Click(object sender, EventArgs e)
    {
        setTabs();
        li1.Attributes.Add("class", "current");
        li1.Attributes.Add("class", "active");
        PanelLocal.Visible = true;
        PanelContacto.Visible = false;
    }

    protected void lnkContacto_Click(object sender, EventArgs e)
    {
        setTabs();
        li2.Attributes.Add("class", "current");
        li2.Attributes.Add("class", "active");
        PanelContacto.Visible = true;
        PanelLocal.Visible = false;
    }

    protected void grvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "visualizar":
                string[] arg2 = new string[2];
                arg2 = e.CommandArgument.ToString().Split(';');
                hfClienteID.Value = arg2[0];
                lblDocumento.Text = arg2[1];
                lblNroDocumento.Text = arg2[2];
                lblRazonSoc.Text = arg2[3];
                lblNombreCom.Text = arg2[4];
                lblDireccion.Text = arg2[5];
                ListarLocal();
                ListarContacto();
                MultiView1.ActiveViewIndex = 1;
                PanelLocal.Visible = true;
                PanelContacto.Visible = false;
                
                setTabs();
                li1.Attributes.Add("class", "current");
                li1.Attributes.Add("class", "active");

                break;
            case "editar":
                string[] arg = new string[8];
                arg = e.CommandArgument.ToString().Split(';');
                hfClienteID.Value = arg[0].ToString();

                if (Convert.ToInt32(arg[1]) == 010100)
                    ddlDocumento.SelectedIndex = 1;
                else if (Convert.ToInt32(arg[1]) == 010200)
                    ddlDocumento.SelectedIndex = 2;
                else if (Convert.ToInt32(arg[1]) == 010300)
                    ddlDocumento.SelectedIndex = 3;

                txtNroDocumento.Text = arg[2].ToString();
                txtRazon.Text = arg[3].ToString();
                txtNomComercial.Text = arg[4].ToString();
                txtDireccion.Text = arg[5].ToString();
                hfAccion.Value = "editar";
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalCliente').modal('show');", true);
                break;
            case "eliminar":
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlertCliente').modal('show');", true);
                cod_cliente.Value = e.CommandArgument.ToString();
                break;

        }

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
    protected void grvClientes_PreRender(object sender, EventArgs e)
    {
        Prerender(grvClientes);
    }

    protected void grvContacto_PreRender(object sender, EventArgs e)
    {
        Prerender(grvContacto);
    }

    protected void grvLocal_PreRender(object sender, EventArgs e)
    {
        Prerender(grvLocal);
    }

    protected void btnAgregarLocal_Click(object sender, EventArgs e)
    {
        hfAccion.Value = "registrar";
        txtDireccionLocal.Text = "";
        ddlDepartamento.SelectedIndex = 0;
        ddlDepartamento.DataSource = null;
        ddlProvincia.DataSource = null;
        ddlDistrito.DataSource = null;
        //if (ddlProvincia.Text != "")
        //    ddlProvincia.SelectedIndex = 0;
        //if(ddlDistrito.Text != "")
        //    ddlDistrito.SelectedIndex = 0;

        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalLocal').modal('show');", true);
    }

    protected void btnAgregarContacto_Click(object sender, EventArgs e)
    {
        LimpiarContacto();
        hfAccion.Value = "registrar";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalContacto').modal('show');", true);
    }

    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadProvincia(ddlDepartamento.SelectedValue.Substring(0, 2));
        ddlDistrito.Items.Clear();
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalLocal').modal('show');", true);
    }

    protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadDistrito(ddlDepartamento.SelectedValue.Substring(0, 2), ddlProvincia.SelectedValue.Substring(2, 2));
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalLocal').modal('show');", true);
    }

    protected void lnkRegistrarLocal_Click(object sender, EventArgs e)
    {
        try
        {
            switch (hfAccion.Value)
            {
                case "registrar":
                    RegistrarLocal();
                    ListarLocal();
                    break;
                case "editar":
                    ModificarLocal();
                    ListarLocal();
                    break;
            }

            MostrarMensaje(0, "Se " + hfAccion.Value + " correctamente el local");

        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo completar la accion realizada");
        }
    }

    protected void grvLocal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "editar":
                string[] arg = new string[3];
                arg = e.CommandArgument.ToString().Split(';');
                hfLocalID.Value = arg[0].ToString();
                txtDireccionLocal.Text = arg[1].ToString();

                string distrito = arg[2].ToString();
                string provincia = distrito.Substring(0, 4)+"00";
                string departamento = provincia.Substring(0, 2)+"0000";

                ddlDepartamento.SelectedValue = departamento;
                loadProvincia(departamento);

                ddlProvincia.SelectedValue = provincia;
                loadDistrito(departamento.Substring(0, 2), provincia.Substring(2, 4));

                ddlDistrito.SelectedValue = distrito;

                hfAccion.Value = "editar";
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalLocal').modal('show');", true);
                break;
            case "eliminar":
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlertLocal').modal('show');", true);
                cod_local.Value = e.CommandArgument.ToString();
                break;

        }
    }

    public void LimpiarContacto()
    {
        txtNombre.Text = "";
        txtApePaterno.Text = "";
        txtApeMaterno.Text = "";
        txtCargo.Text = "";
        txtCorreo.Text = "";
        txtTelefono.Text = "";
        txtAnexo.Text = "";
        txtFchNacimiento.Text = "";
        txtObservacion.Text = "";
    }

    protected void lnkRegistrarContacto_Click(object sender, EventArgs e)
    {
        try
        {
            switch (hfAccion.Value)
            {
                case "registrar":
                    RegistrarContacto();
                    ListarContacto();
                    MostrarMensaje(0, "Se Registro Correctamente");
                    break;

                case "editar":
                    ModificarContacto();
                    ListarContacto();
                    MostrarMensaje(0, "Se Modificó Correctamente");
                    break;
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo " + hfAccion.Value + "correctamente.");
        }
    }

    protected void grvContacto_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "editar":
                string[] arg = new string[13];
                arg = e.CommandArgument.ToString().Split(';');
                hfContactoID.Value = arg[0].ToString();
                hfClienteID.Value = arg[1].ToString();
                txtNombre.Text = arg[2].ToString();
                txtApePaterno.Text = arg[3].ToString();
                txtApeMaterno.Text = arg[4].ToString();
                txtCargo.Text = arg[5].ToString();
                txtCorreo.Text = arg[6].ToString();
                txtTelefono.Text = arg[7].ToString();
                txtAnexo.Text = arg[8].ToString();
                txtFchNacimiento.Text = arg[9].ToString();
                txtObservacion.Text = arg[10].ToString();
                hfAccion.Value = "editar";
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalContacto').modal('show');", true);
                break;
            case "eliminar":
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert5').modal('show');", true);
                cod_id.Value = e.CommandArgument.ToString();
                break;
        }
    }



    protected void lnkRegresar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            EliminarContacto(Convert.ToInt32(cod_id.Value));
            ListarContacto();
            MostrarMensaje(0, "Se eliminó el contacto correctamente");
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo eliminar el contacto");
        }
    }

    protected void lnkEliminarLocal_Click(object sender, EventArgs e)
    {
        try
        {

            EliminarLocal(Convert.ToInt32(cod_local.Value));
            ListarLocal();
            MostrarMensaje(0, "Se elimino el local correctamente");
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo eliminar el cliente");
        }
    }
    protected void lnkEliminarCliente_Click(object sender, EventArgs e)
    {
        try
        {
            EliminarCliente(cod_cliente.Value);
            ListarCliente();
            MostrarMensaje(0, "Se elimino el cliente correctamente");
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo eliminar el cliente");
        }

    }

}