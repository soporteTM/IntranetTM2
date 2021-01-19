using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Neumaticos_Mantto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarNeumaticos();
            Perfil();
            //loadItems(ddlMarca, "13");
            loadItems(ddlModelo, "14");
            loadItems(ddlProveedor, "25");
            loadItems(ddlTipoMoneda, "26");
            loadItems(ddlMotivo, "27");
            ListarEstadosReporte();
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

    public void ListarNeumaticos()
    {    
        NeumaticoBL oNeumatico = new NeumaticoBL();
        List<NeumaticoEL> lst = oNeumatico.ListarNeumatico(0);
        gvNeumatico.DataSource = lst;
        gvNeumatico.DataBind();
    }

    public void ListarNeumaticoHistorico(string Nserie)
    {
        NeumaticoBL oNeumatico = new NeumaticoBL();
        List<NeumaticoEL> lst = oNeumatico.ListarNeumaticoHistorico(Nserie);
        gvHistorico.DataSource = lst;
        gvHistorico.DataBind();
    }

    public void ListarEstadosReporte()
    {
        ddlEstadoNeumaticoReporte.Items.Clear();
        ddlEstadoNeumaticoReporte.Items.Add("--Seleccione--");
        ddlEstadoNeumaticoReporte.Items[0].Value = "0";
        ddlEstadoNeumaticoReporte.Items.Add("Activo");
        ddlEstadoNeumaticoReporte.Items[1].Value = "1";
        ddlEstadoNeumaticoReporte.Items.Add("De Baja");
        ddlEstadoNeumaticoReporte.Items[2].Value = "2";
        ddlEstadoNeumaticoReporte.SelectedIndex = 0;
    }

    public void loadItems(DropDownList ddl, string id_catalogo)
    {
        ItemBL oItem = new ItemBL();
        ddl.DataSource = oItem.ListarItemOpe(id_catalogo);
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Seleccione--", ""));
        ddl.SelectedIndex = 0;
    }

    protected void gvNeumatico_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        NeumaticoBL oNeumatico = new NeumaticoBL();
        switch (e.CommandName.ToString())
        {
            case "Reencauche":
                
                List<NeumaticoEL> lst = oNeumatico.ListarNeumatico(Convert.ToInt32(e.CommandArgument.ToString())); 
                txtNroSerie.Text = lst[0].nro_serie;
                //ddlMarca.SelectedValue = lst[0].cod_marca;
                txtMarca.Text = lst[0].cod_marca;
                ddlModelo.SelectedValue = lst[0].cod_modelo;
                ddlProveedor.SelectedItem.Text = lst[0].Proveedor;
                txtDOT.Text = lst[0].DOT;
                txtMedida.Text = lst[0].medida;
                txtDiseño.Text = lst[0].diseño;
                txtNroSerie.Enabled = false;
                txtMarca.Enabled = false;
                ddlModelo.Enabled = false;
                txtDOT.Enabled = false;
                ddlProveedor.Enabled = false;
                txtMedida.Enabled = false;
                txtDiseño.Enabled = false;
                hfAccion.Value = "reencauche";
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
                break;
            case "Historial":
                ListarNeumaticoHistorico(e.CommandArgument.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#modalHistorico').modal('show');", true);
                break;
            case "Editar":
                hfCodNeumatico.Value = e.CommandArgument.ToString();
                List<NeumaticoEL> lst2 = oNeumatico.ListarNeumatico(Convert.ToInt32(e.CommandArgument.ToString()));
                hfAccion.Value = "Editar";
                txtNroSerie.Enabled = true;
                txtMarca.Enabled = true;
                ddlModelo.Enabled = true;
                txtDOT.Enabled = true;
                txtMedida.Enabled = true;
                txtDiseño.Enabled = true;
                ddlProveedor.Enabled = true;

                txtNroSerie.Text = lst2[0].nro_serie;
                txtDOT.Text = lst2[0].DOT;
                txtMarca.Text = lst2[0].cod_marca;
                ddlModelo.SelectedValue = lst2[0].cod_modelo;
                txtMedida.Text = lst2[0].medida;
                txtDiseño.Text = lst2[0].diseño;
                txtPrecio.Text = Convert.ToString(lst2[0].precio_costo);
                txtR1.Text = Convert.ToString(lst2[0].R1);
                txtR2.Text = Convert.ToString(lst2[0].R2);
                txtR3.Text = Convert.ToString(lst2[0].R3);
                txtFCompra.Text = lst2[0].fecha_compra;

                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
                break;
            case "eliminar":
                try
                {
                    hfCodNeumatico.Value = e.CommandArgument.ToString();
                    txtObservacion.Text = "";
                    txtR1Baja.Text = "";
                    txtR2Baja.Text = "";
                    txtR3Baja.Text = "";
                    ddlMotivo.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalBaja').modal('show');", true);
                    
                }
                catch
                {
                    MostrarMensaje(1,"No se pudo eliminar el neumatico");
                }
                
                break;
        }
    }

    protected void gvNeumatico_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblreencauche = (Label)e.Row.FindControl("lblreencauche");

            if (lblreencauche.Text == "0")
            {
                lblreencauche.Text = "Nueva";                
            }
            else
            {
                lblreencauche.Text = "Reencauche "+lblreencauche.Text;
            }
        }
    }

    protected void gvNeumatico_PreRender(object sender, EventArgs e)
    {
        if (gvNeumatico.Rows.Count > 0)
        {
            gvNeumatico.UseAccessibleHeader = true;
            gvNeumatico.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvNeumatico.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void lnkRegistrar_Click(object sender, EventArgs e)
    {
        if (hfAccion.Value.Equals("reencauche"))
        {
            RegistrarReencauche();
            ListarNeumaticos();
            hfAccion.Value = "";
        }
        else if (hfAccion.Value.Equals(""))
        {
            RegistrarNeumatico();
            ListarNeumaticos();
        }
        else if (hfAccion.Value.Equals("Editar"))
        {
            EditarNeumatico();
            ListarNeumaticos();
        }


    }

    public void EditarNeumatico()
    {
        try
        {
            NeumaticoBL oNeumaticos = new NeumaticoBL();
            NeumaticoEL objNeumaticos = new NeumaticoEL();
            objNeumaticos.nro_serie = txtNroSerie.Text;
            objNeumaticos.cod_marca = txtMarca.Text;
            objNeumaticos.cod_modelo = ddlModelo.SelectedValue;
            objNeumaticos.precio_costo = Convert.ToDecimal(txtPrecio.Text);
            objNeumaticos.R1 = Convert.ToInt32(txtR1.Text);
            objNeumaticos.R2 = Convert.ToInt32(txtR2.Text);
            objNeumaticos.R3 = Convert.ToInt32(txtR3.Text);
            //objNeumaticos.estado_cd = txtEstado.Text;
            objNeumaticos.aud_usuario_creacion = hfUsuario.Value;
            objNeumaticos.DOT = txtDOT.Text;
            objNeumaticos.medida = txtMedida.Text;
            objNeumaticos.diseño = txtDiseño.Text;
            objNeumaticos.fecha_compra = txtFCompra.Text;
            objNeumaticos.Proveedor = ddlProveedor.SelectedValue;
            objNeumaticos.reencauche = Convert.ToInt32(rbtReencauche.Checked);
            List<TransaccionEL> lst = oNeumaticos.EditarNeumatico(objNeumaticos,Convert.ToInt32(hfCodNeumatico.Value));
            MostrarMensaje(0,"Se modifico correctamente");
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo realizar la modificacion");
        }
    }
    public void RegistrarNeumatico()
    {
        try
        {
            NeumaticoBL oNeumaticos = new NeumaticoBL();
            NeumaticoEL objNeumaticos = new NeumaticoEL();
            objNeumaticos.nro_serie = txtNroSerie.Text;
            objNeumaticos.cod_marca = txtMarca.Text;
            objNeumaticos.cod_modelo = ddlModelo.SelectedValue;
            objNeumaticos.precio_costo = Convert.ToDecimal(txtPrecio.Text);
            objNeumaticos.R1 = Convert.ToInt32(txtR1.Text);
            objNeumaticos.R2 = Convert.ToInt32(txtR2.Text);
            objNeumaticos.R3 = Convert.ToInt32(txtR3.Text);
            //objNeumaticos.estado_cd = txtEstado.Text;
            objNeumaticos.aud_usuario_creacion = hfUsuario.Value;
            objNeumaticos.DOT = txtDOT.Text;
            objNeumaticos.medida = txtMedida.Text;
            objNeumaticos.diseño = txtDiseño.Text;
            objNeumaticos.fecha_compra= txtFCompra.Text;
            objNeumaticos.Proveedor = ddlProveedor.SelectedValue;
            objNeumaticos.tipo_moneda = ddlTipoMoneda.SelectedValue;
            if (rbtNuevo.Checked)
            {
                objNeumaticos.reencauche = 0;
            }
            else if (rbtReencauche.Checked)
            {
                objNeumaticos.reencauche = Convert.ToInt32(txtReencauche.Text);
            }
            List<TransaccionEL> lst = oNeumaticos.RegistrarNeumatico(objNeumaticos);
            MostrarMensaje(lst[0].id_mensaje, lst[0].mensaje);
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo realizar el registro");
        }
    }

    public void RegistrarReencauche()
    {
        try
        {
            NeumaticoBL oNeumaticos = new NeumaticoBL();
            NeumaticoEL objNeumaticos = new NeumaticoEL();
            objNeumaticos.nro_serie = txtNroSerie.Text;
            objNeumaticos.cod_marca = txtMarca.Text;
            objNeumaticos.cod_modelo = ddlModelo.SelectedValue;
            objNeumaticos.precio_costo = Convert.ToDecimal(txtPrecio.Text);
            objNeumaticos.R1 = Convert.ToInt32(txtR1.Text);
            objNeumaticos.R2 = Convert.ToInt32(txtR2.Text);
            objNeumaticos.R3 = Convert.ToInt32(txtR3.Text);
            //objNeumaticos.estado_cd = txtEstado.Text;
            objNeumaticos.aud_usuario_creacion = hfUsuario.Value;
            objNeumaticos.DOT = txtDOT.Text;
            objNeumaticos.medida = txtMedida.Text;
            objNeumaticos.diseño = txtDiseño.Text;
            objNeumaticos.fecha_compra = txtFCompra.Text;
            objNeumaticos.Proveedor = ddlProveedor.SelectedValue;

            oNeumaticos.RegistrarReencauche(objNeumaticos);
            MostrarMensaje(0, "Se registro el reencauche correctamente");
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "No se pudo realizar el registro."+ex.ToString());
        }
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
    protected void lnkAgregar_Click(object sender, EventArgs e)
    {
        hfAccion.Value = "";
        txtNroSerie.Enabled = true;
        txtMarca.Enabled = true;
        ddlModelo.Enabled = true;
        txtDOT.Enabled = true;
        txtMedida.Enabled = true;
        txtDiseño.Enabled = true;
        ddlProveedor.Enabled = true;

        txtNroSerie.Text = "";
        txtDOT.Text = "";
        txtMarca.Text = "";
        ddlModelo.Text = "";
        txtMedida.Text = "";
        txtDiseño.Text = "";
        ddlProveedor.Text = "";
        txtPrecio.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtFCompra.Text = "";


        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
    }


    protected void gvHistorico_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Eliminar":
                try
                {
                    NeumaticoBL oNeumatico = new NeumaticoBL();
                    oNeumatico.EliminarNeumatico(Convert.ToInt32(e.CommandArgument.ToString()),hfUsuario.Value);
                    ListarNeumaticos();
                    MostrarMensaje(0,"Se elimino correctamente");
                } catch (Exception ex)
                {
                    MostrarMensaje(1, "No se pudo eliminar");
                }
                
                break;
        }
    }

    protected void gvHistorico_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblreencauche = (Label)e.Row.FindControl("lblreencauche");
            LinkButton btnEliminar = (LinkButton)e.Row.FindControl("btnEliminar");
            
            if (lblreencauche.Text == "0")
            {
                lblreencauche.Text = "Nueva";
                btnEliminar.Visible = false;
            }
            else
            {
                lblreencauche.Text = "Reencauche " + lblreencauche.Text;
            }

            
        }
    }

    protected void rbtReencauche_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtNuevo.Checked)
        {
            txtReencauche.Visible = false;
        }
        else
        {
            txtReencauche.Visible = true;
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalBaja').modal('show');", true);
       // JConfirm('Debe estar seguro antes de eliminar información del sistema', '¿Desea eliminar este Neumatico?', this); return false;
    }

    protected void ddlMotivo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMotivo.SelectedItem.Text == "OTROS")
        {
            txtObservacion.Visible = true;
        }
        else
        {
            txtObservacion.Visible = false;
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalBaja').modal('show');", true);
    }

    protected void btnRechazar_Click(object sender, EventArgs e)
    {
        NeumaticoBL oNeumatico = new NeumaticoBL();
        
        oNeumatico.EliminarNeumatico(Convert.ToInt32(hfCodNeumatico.Value), hfUsuario.Value, 
            ddlMotivo.SelectedValue,txtR1Baja.Text,txtR2Baja.Text,txtR3Baja.Text,
             Convert.ToDouble(txtKilometrajeBaja.Text),txtObservacion.Text);
        ListarNeumaticos();
        MostrarMensaje(0, "Se elimino el neumatico correctamente");
    }

    protected void grvReporteNeumaticos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
        }
    }


    protected void btnReporte_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#modalReporte').modal('show');", true);
    }

    protected void btnListarReporte_Click(object sender, EventArgs e)
    {
        NeumaticoBL oNeumatico = new NeumaticoBL();
        List<NeumaticoEL> lst = oNeumatico.ListarNeumaticosReporte(Convert.ToInt32(ddlEstadoNeumaticoReporte.SelectedValue),dtpFechaInicioReporte.Text,dtpFechaFinReporte.Text);
        gvNeumatico.DataSource = lst;
        gvNeumatico.DataBind();
    }
}