using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Security;
using System.Data;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using BL;
using EL;
using System.Web.UI.HtmlControls;

public partial class Modulos_OT_Default : System.Web.UI.Page
{

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

    public void listarOT(int id_orden)
    {
        OrdenTrabajoBL OT = new OrdenTrabajoBL();
        gvOT.DataSource = OT.ListarOT(id_orden);
        gvOT.DataBind();
    }

    public void listarServicio(int id_orden)
    {
        OrdenServicioBL oServicio = new OrdenServicioBL();
        List<OrdenServicioEL> lstBL = oServicio.ListarServicio(id_orden);
        if (lstBL.Count > 0)
        {
            gvServicio.DataSource = lstBL;
            gvServicio.DataBind();
            alerta.Visible = false;
        }
        else
        {
            alerta.Visible = true;
            gvServicio.DataSource = null;
            gvServicio.DataBind();
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadItems(ddlMantenimiento, "07");
            loadItems(ddlTipoServicio, "08");
            loadItems(ddlMotivoServicio, "11");
            loadItems(ddlTaller, "10");
            listarOT(0);
            //GenerarID();
            //Bloquear las fechas de termino
            txtfchFin.Enabled = false;
            txtHoraFin.Enabled = false;
        }
    }

    public void GenerarID()
    {
        ItemBL oItem = new ItemBL();
        List<TransaccionEL> lst = new List<TransaccionEL>();
        lst = oItem.ObtenerID();
        txtNroOrden.Text = lst[0].id_mensaje.ToString();
    }

    public void registrarOT(string ic_action)
    {
        
        OrdenTrabajoBL oOrdenBL = new OrdenTrabajoBL();
        OrdenTrabajoEL oOrdenEL = new OrdenTrabajoEL();
        List<TransaccionEL> lst = new List<TransaccionEL>();

        oOrdenEL.nro_orden = txtNroOrden.Text;
        oOrdenEL.cod_proveedor = "";
        oOrdenEL.nom_proveedor = "";
        
        oOrdenEL.hora_inicio = Convert.ToDateTime(txtfchEmision.Text + " " + txtHoraEmision.Text);
        oOrdenEL.hora_fin = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        oOrdenEL.cod_flota = Convert.ToInt32(txtUnidad_id.Text);
        oOrdenEL.km_flota = Convert.ToDecimal(txtKm.Text);
        oOrdenEL.cod_conductor = 2;
        oOrdenEL.cod_tipo_servicio = ddlTipoServicio.SelectedValue;
        oOrdenEL.cod_mantenimiento = ddlMantenimiento.SelectedValue;
        oOrdenEL.cod_taller = ddlTaller.SelectedValue;
        oOrdenEL.horometro_flota = Convert.ToDecimal(txtHorometro.Text);
        oOrdenEL.aud_usuario_creacion = "JTORRES";

        if (ic_action.Equals("N"))
        {
            oOrdenEL.fch_emision = DateTime.Now;
            lst = oOrdenBL.RegistrarOT(oOrdenEL);
        }
        else
        {
            oOrdenEL.id_orden = Convert.ToInt32(HFCodigo.Value);
            oOrdenEL.fch_emision = Convert.ToDateTime(txtfchEmision.Text + " " + txtHoraEmision.Text);

            if (txtfchFin.Text=="" || txtHoraFin.Text == "")
            {
                oOrdenEL.hora_fin = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
            else
            {
                oOrdenEL.hora_fin = Convert.ToDateTime(txtfchFin.Text + " " + txtHoraFin.Text);
            }            
            lst = oOrdenBL.ActualizarOT(oOrdenEL);
        }
        
        if (lst[0].id_mensaje == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se registro con éxito','Alerta.','success');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se ha producido un error','Alerta.','error');", true);
        }
    }

    public void RegistrarServicio()
    {
        OrdenServicioEL oOrdenEL = new OrdenServicioEL();
        oOrdenEL.id_orden = Convert.ToInt32(HFCodigo.Value);
        oOrdenEL.cod_servicio = ddlMotivoServicio.SelectedValue;
        oOrdenEL.costo = Convert.ToDecimal(txtCosto.Text);
        oOrdenEL.obs = txtObs.Text;

        OrdenServicioBL oOrdenBL = new OrdenServicioBL();
        List<TransaccionEL> lst = new List<TransaccionEL>();

        lst = oOrdenBL.RegistrarServicio(oOrdenEL);

        if (lst[0].id_mensaje == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se registro con éxito','Alerta.','success');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se ha producido un error','Alerta.','error');", true);
        }
    }


    protected void lnkNuevo_Click(object sender, EventArgs e)
    {
        GenerarID();
        txtUnidad.Text = "";
        txtUnidad_id.Text = "";
        ddlTaller.SelectedIndex = 0;
        txtfchEmision.Text = "";
        txtHoraEmision.Text = "";
        txtfchFin.Text = "";
        txtHoraFin.Text = "";
        txtKm.Text = "";
        txtHorometro.Text = "";
        ddlTipoServicio.SelectedIndex = 0;
        ddlMantenimiento.SelectedIndex = 0;
        HFCodigo.Value = "0";
        MultiView1.ActiveViewIndex = 1;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (HFCodigo.Value == "0")
        {
            registrarOT("N");
        }
        else
        {
            registrarOT("A");
        }
        MultiView1.ActiveViewIndex = 0;
        listarOT(0);

    }

    protected void gvOT_PreRender(object sender, EventArgs e)
    {
        if (gvOT.Rows.Count > 0)
        {
            gvOT.UseAccessibleHeader = true;
            gvOT.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvOT.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void gvOT_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "editar":

                HFCodigo.Value = e.CommandArgument.ToString();
                OrdenTrabajoBL oOrden = new OrdenTrabajoBL();
                List<OrdenTrabajoEL> lst = oOrden.ListarOT(Convert.ToInt32(HFCodigo.Value));
                //Gets values of the list OrdenTrabajoEL
                txtNroOrden.Text = lst[0].nro_orden;
                txtUnidad.Text = lst[0].nro_placa;
                txtUnidad_id.Text = Convert.ToString(lst[0].cod_flota);
                ddlTaller.SelectedValue = lst[0].cod_taller;
                txtfchEmision.Text = lst[0].hora_inicio.ToString("dd/MM/yyyy");
                txtHoraEmision.Text = lst[0].hora_inicio.ToString("HH:mm");
                txtfchFin.Text = "";
                txtHoraFin.Text = "";
                txtKm.Text = Convert.ToString(lst[0].km_flota);
                txtHorometro.Text = Convert.ToString(lst[0].horometro_flota);
                ddlTipoServicio.SelectedValue = lst[0].cod_tipo_servicio;
                ddlMantenimiento.SelectedValue = lst[0].cod_mantenimiento;
                MultiView1.ActiveViewIndex = 1;
                txtfchFin.Enabled = true;
                txtHoraFin.Enabled = true;
                break;

            case "servicios":
                
                HFCodigo.Value = e.CommandArgument.ToString();
                MultiView1.ActiveViewIndex = 2;
                listarServicio(Convert.ToInt32(HFCodigo.Value));
                break;
        }
    }

    protected void btnServicio_Click(object sender, EventArgs e)
    {
        RegistrarServicio();
        listarServicio(Convert.ToInt32(HFCodigo.Value));
    }

    protected void btnServicioRegresar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void gvOT_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblFechaFin = (Label)e.Row.FindControl("lblFechaFin");
            Label lblHoraFin = (Label)e.Row.FindControl("lblHoraFin");
            Label lblEstado = (Label)e.Row.FindControl("lblEstado");

            HtmlControl control = (HtmlControl)e.Row.FindControl("spanlbl");

            DateTime dtHora = Convert.ToDateTime(lblFechaFin.Text);
            if (dtHora.ToString("dd/MM/yyyy").Equals("01/01/1753"))
            {
                lblFechaFin.Text = "N/A";
                lblHoraFin.Text = "00:00";                
                control.Attributes["class"] = "btn btn-icon waves-effect waves-light btn-danger m-b-5";
                
            }
            else
            {
                lblFechaFin.Text = dtHora.ToString("dd/MM/yyyy");
                lblHoraFin.Text = dtHora.ToString("HH:mm");
                
            }

            //
            if (lblEstado.Text == "P")
            {
                lblEstado.Text = "PENDIENTE";
                lblEstado.CssClass = "btn btn-icon waves-effect waves-light btn-danger m-b-5";
            }
            else
            {
                lblEstado.Text = "FINALIZADO";
                lblEstado.CssClass = "btn btn-icon waves-effect waves-light btn-teal m-b-5";
            }            
        }
    }
}
