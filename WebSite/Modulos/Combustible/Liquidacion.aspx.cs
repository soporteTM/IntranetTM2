using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Combustible_Liquidacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarLiquidacion();
            ListarCliente();
            loadItems(ddlTipoVehiculo, "22");
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

    public void ListarLiquidacion()
    {
        LiquidacionBL oLiquidacion = new LiquidacionBL();
        List<LiquidacionEL> lst = oLiquidacion.ListarLiquidacion();
        grvLiquidacion.DataSource = lst;
        grvLiquidacion.DataBind();
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
    }

    public void LiquidacionDetalle(int id)
    {
        LiquidacionBL oLiquidacion = new LiquidacionBL();
        LiquidacionEL objLiquidacion = new LiquidacionEL();
        objLiquidacion.id_liquidacion = id;
        List<AbastecimientoEL> lst = oLiquidacion.LiquidacionDetalle(objLiquidacion);
        gvDetalleMod.DataSource = lst;
        gvDetalleMod.DataBind();
    }

    public void ListarAbastecimiento()
    {
        gvDetalle.Columns[1].Visible = true;
        AbastecimientoBL oDetalle = new AbastecimientoBL();
        AbasteciminetoDisponibleEL oaba = new AbasteciminetoDisponibleEL();
        if (ddlTipoVehiculo.SelectedIndex == 0)
            oaba.id_TV = 0;
        else
            oaba.id_TV = Convert.ToInt32(ddlTipoVehiculo.SelectedValue);
        if (ddlCliente.SelectedIndex == 0)
            oaba.id_cliente = 0;
        else
            oaba.id_cliente = Convert.ToInt32(ddlCliente.SelectedValue);
        oaba.fch_inicio = Convert.ToDateTime(txtfchInicio.Text);
        oaba.fch_fin= Convert.ToDateTime(txtfchFin.Text);
        List<AbastecimientoEL> lst = oDetalle.AbastecimientoDisponible(oaba);
        gvDetalle.DataSource = lst;
        gvDetalle.DataBind();
        gvDetalle.Columns[1].Visible = false;
    }

    public void RegistrarDetalle(int codLiquidacion)
    {
        int cantAbastecimiento = 0;
        decimal consumototal = 0;

        foreach (GridViewRow dtgItem in this.gvDetalle.Rows)
        {
            CheckBox Sel = ((CheckBox)gvDetalle.Rows[dtgItem.RowIndex].FindControl("chkLiquidacion"));
            int id = Convert.ToInt32(gvDetalle.Rows[dtgItem.RowIndex].Cells[1].Text);
            string consumocadena = gvDetalle.Rows[dtgItem.RowIndex].Cells[15].Text;
            consumocadena = consumocadena.Substring(3, consumocadena.Length - 3);
            decimal consumo = Convert.ToDecimal(consumocadena);

            bool valor = Sel.Checked;
            if (valor)
            {
                ActualizarLiquidacionAbastecimiento(codLiquidacion, id);
                consumototal += consumo;
                cantAbastecimiento++;
            }
        }
    }
    
    public void RegistrarLiquidacion()
    {
        LiquidacionBL oLiquidacion = new LiquidacionBL();
        LiquidacionEL objLiquidacion = new LiquidacionEL();
        objLiquidacion.cod_empresa = Convert.ToInt32(ddlCliente.SelectedValue);
        objLiquidacion.maquinaria = ddlTipoVehiculo.SelectedValue.ToString();
        objLiquidacion.fch_liquidacion_inicio2 = Convert.ToDateTime(txtfchInicio.Text);
        objLiquidacion.fch_liquidacion_fin2 = Convert.ToDateTime(txtfchFin.Text);
        objLiquidacion.usuario = hfUsuario.Value;
        List<TransaccionEL> lst = oLiquidacion.RegistrarLiquidacion(objLiquidacion);
        int codLiquidacion = Convert.ToInt32(lst[0].mensaje);

        RegistrarDetalle(codLiquidacion);
    }

    public void ActualizarLiquidacionAbastecimiento(int liqui, int aba)
    {
        AbastecimientoBL oAbastecimiento = new AbastecimientoBL();
        AbastecimientoEL objAbastecimiento = new AbastecimientoEL();
        objAbastecimiento.id_liquidacion = liqui;
        objAbastecimiento.id_abastecimiento = aba;
        List<AbastecimientoEL> lst = oAbastecimiento.ActualizarLiquidacion(objAbastecimiento);
    }

    public void EliminarLiquidacion(int idliqui)
    {
        LiquidacionBL oLiquidacion = new LiquidacionBL();
        LiquidacionEL objLiquidacion = new LiquidacionEL();
        objLiquidacion.id_liquidacion = idliqui;
        List<TransaccionEL> lst = oLiquidacion.EliminarLiquidacion(objLiquidacion);
    }

    public void EliminarDetalle(int idliqui)
    {
        LiquidacionBL oLiquidacion = new LiquidacionBL();
        AbastecimientoEL objLiquidacion = new AbastecimientoEL();
        objLiquidacion.id_abastecimiento = idliqui;
        List<AbastecimientoEL> lst = oLiquidacion.EliminarDetalle(objLiquidacion);
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
    }
    
    public string validacionRegistrar()
    {
        int cantidad = 0;
        foreach (GridViewRow dtgItem in this.gvDetalle.Rows)
        {
            CheckBox Sel = ((CheckBox)gvDetalle.Rows[dtgItem.RowIndex].FindControl("chkLiquidacion"));
            bool valor = Sel.Checked;
            if (valor)
            {
                cantidad++;
            }
        }

        string respuesta="0Se registro la liquidacion correctamente";

        if (ddlCliente.SelectedIndex == 0)
        {
            respuesta = "1Se debe seleccionar una empresa";
        }
        else if (ddlTipoVehiculo.SelectedIndex == 0)
        {
            respuesta = "1Se debe seleccionar un tipo de vehiculo";
        }
        else if (txtfchInicio.Text.Equals("") || txtfchFin.Text.Equals(""))
        {
            respuesta = "1Se debe ingresar ambas fechas";
        }

        else if (cantidad == 0)
        {
            respuesta = "1Se debe seleccionar al menos un registro";
        }

        return respuesta;
    }

    public string validacionBuscar()
    {
       
        string respuesta = "0Se realizo la busqueda correctamente";
        
        if (txtfchInicio.Text.Equals("") || txtfchFin.Text.Equals(""))
        {
            respuesta = "1Se debe ingresar ambas fechas para realizar una busqueda";
        }

        return respuesta;
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

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        ListarLiquidacion();
        MultiView1.ActiveViewIndex = 0;

    }


    protected void lnkGenerar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        
        ddlCliente.Enabled = true;
        ddlCliente.SelectedIndex = 0;
        ddlTipoVehiculo.Enabled = true;
        ddlTipoVehiculo.SelectedIndex = 0;
        txtfchInicio.Enabled = true;
        txtfchInicio.Text = "";
        txtfchFin.Enabled = true;
        txtfchFin.Text = "";
        gvDetalle.DataSource = "";
        gvDetalle.DataBind();
        gvDetalleMod.DataSource = "";
        gvDetalleMod.DataBind();
        hfIdLiquidacion.Value= "";
    }

    protected void lnkBuscar_Click(object sender, EventArgs e)
    {
        string validacion = validacionBuscar();
        int codigomensaje = Convert.ToInt32(validacion.Substring(0, 1));
        string mensaje = validacion.Substring(1, validacion.Length - 1);

        if (codigomensaje == 0)
        {
            ListarAbastecimiento();
        }
        else
        {
            MostrarMensaje(codigomensaje, mensaje);
        }
        if (gvDetalle.Rows.Count == 0)
            MostrarMensaje(1,"No se han encontrado registros disponibles en la fecha seleccionada");


    }

    protected void lnkGuardar_Click(object sender, EventArgs e)
    {

        string validacion = validacionRegistrar();
        int codigomensaje = Convert.ToInt32(validacion.Substring(0, 1));
        string mensaje = validacion.Substring(1, validacion.Length - 1);

        try
        {
            if (hfIdLiquidacion.Value.Equals(""))
            {
                if (codigomensaje == 0)
                {
                    RegistrarLiquidacion();
                    ListarLiquidacion();
                }
            }
            else
            {
                RegistrarDetalle(Convert.ToInt32(hfIdLiquidacion.Value));
                ListarLiquidacion();
            }

            MostrarMensaje(codigomensaje,mensaje);
            ddlCliente.Enabled = false;
            ddlTipoVehiculo.Enabled = false;
            txtfchInicio.Enabled = false;
            txtfchFin.Enabled = false;
            MultiView1.ActiveViewIndex = 0;
            hfIdLiquidacion.Value = "";
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void grvLiquidacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Modificar":
                string[] arg = new string[7];
                arg = e.CommandArgument.ToString().Split(';');
                hfIdLiquidacion.Value = arg[0].ToString();
                LiquidacionDetalle(Convert.ToInt32(hfIdLiquidacion.Value));
                txtfchInicio.Text = arg[1];
                txtfchFin.Text = arg[2];
                ddlCliente.SelectedValue = arg[3];
                ddlCliente.SelectedItem.Text = arg[4];
                ddlTipoVehiculo.SelectedValue = arg[5];
                ddlTipoVehiculo.SelectedItem.Text = arg[6];
                MultiView1.ActiveViewIndex = 1;
                gvDetalle.DataSource = "";
                gvDetalle.DataBind();
                ddlCliente.Enabled = false;
                ddlTipoVehiculo.Enabled = false;
                txtfchInicio.Enabled = false;
                txtfchFin.Enabled = false;

                break;
            case "eliminar":
                hfEliminarLiqui.Value = e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#ModalDelete').modal('show');", true);
                break;
        }
    }

    protected void gvDetalleMod_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "eliminar":
                hfEliminarDetalle.Value = e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#ModalDelete').modal('show');", true);
                break;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvDetalleMod.Rows.Count > 0)
            {
                EliminarDetalle(Convert.ToInt32(hfEliminarDetalle.Value));
                LiquidacionDetalle(Convert.ToInt32(hfIdLiquidacion.Value));
                MostrarMensaje(0, "Se elimino el registro correctamente");
            }
            else
            {
                EliminarLiquidacion(Convert.ToInt32(hfEliminarLiqui.Value));
                MostrarMensaje(0, "Se elimino el registro correctamente");
                ListarLiquidacion();
            }
        }
        catch(Exception ex)
        {
        }

    }

    protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCliente.SelectedValue.Equals("1") || ddlCliente.SelectedValue.Equals("2"))
        {
            ddlTipoVehiculo.Enabled = true;
        }
        else
        {
            ddlTipoVehiculo.Enabled = false;
            ddlTipoVehiculo.SelectedIndex = 1;       
        }
        gvDetalle.DataSource = "";
        gvDetalle.DataBind();
        MultiView1.ActiveViewIndex = 1;
    }

    protected void ddlTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvDetalle.DataSource = "";
        gvDetalle.DataBind();
        MultiView1.ActiveViewIndex = 1;
    }

    protected void txtfchInicio_TextChanged(object sender, EventArgs e)
    {
        gvDetalle.DataSource = "";
        gvDetalle.DataBind();
        MultiView1.ActiveViewIndex = 1;
    }

    protected void txtfchFin_TextChanged(object sender, EventArgs e)
    {
        gvDetalle.DataSource = "";
        gvDetalle.DataBind();
        MultiView1.ActiveViewIndex = 1;
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

    protected void grvLiquidacion_PreRender(object sender, EventArgs e)
    {
        if (grvLiquidacion.Rows.Count > 0)
        {
            grvLiquidacion.UseAccessibleHeader = true;
            grvLiquidacion.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvLiquidacion.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void gvDetalleMod_PreRender(object sender, EventArgs e)
    {
        if (gvDetalleMod.Rows.Count > 0)
        {
            gvDetalleMod.UseAccessibleHeader = true;
            gvDetalleMod.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvDetalleMod.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void chkLiquidacionALL_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow dtgItem in this.gvDetalle.Rows)
        {
            CheckBox Sel = ((CheckBox)gvDetalle.Rows[dtgItem.RowIndex].FindControl("chkLiquidacion"));
            Sel.Checked = true;
            
        }
    }
}