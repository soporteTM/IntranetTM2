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

public partial class cliente_default : System.Web.UI.Page
{
    //public BD_IntranetFIEntities CMScontext = new BD_IntranetFIEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //cargarClientes();
            loadFlota(0,"");
            loadItems(ddlVehiculo, "00");
            loadItems(ddlMarca, "01");
            loadItems(ddlConfiguracion, "02");
            loadItems(ddlModelo, "03");
            loadItems(ddlOperacion, "04");
            loadItems(ddlDocumentacion, "05");
        }
    }

    public void loadItems(DropDownList ddl , string id_catalogo)
    {
        ItemBL oItem = new ItemBL();
        ddl.DataSource = oItem.ListarItemOpe(id_catalogo);
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- TODOS --", ""));
        ddl.SelectedIndex = 0;
    }

    public void loadFlota(int cod_flota,string nro_placa)
    {
        FlotaBL oFlota = new FlotaBL();
        List<FlotaEL> lst = oFlota.ConsultarFlota(cod_flota,nro_placa);
        gvMarcas.DataSource = lst;
        gvMarcas.DataBind();
    }

    public void loadDocumentacion(int cod_flota)
    {
        DocumentacionBL oDocumentacion = new DocumentacionBL();
        List<DocumentacionEL> lstBL = oDocumentacion.ConsultarDocumentacion(cod_flota);
        if (lstBL.Count > 0)
        {
            gvDocumentacion.DataSource = lstBL;
            gvDocumentacion.DataBind();
            alerta.Visible = false;
        }
        else
        {
            alerta.Visible = true;
            gvDocumentacion.DataSource = null;
            gvDocumentacion.DataBind();
        }
    }

    public void registrarFlota(string ic_action)
    {
        FlotaBL oFlotaBL = new FlotaBL();
        FlotaEL oFlotaEL = new FlotaEL();
        List<TransaccionEL> lst = new List<TransaccionEL>();

        oFlotaEL.cod_interno = txtCodInterno.Text;
        oFlotaEL.nro_placa = txtNroPlaca.Text;
        oFlotaEL.cod_tipo_vehiculo = ddlVehiculo.SelectedValue;
        oFlotaEL.cod_marca = ddlMarca.SelectedValue;
        oFlotaEL.cod_modelo = ddlModelo.SelectedValue;
        oFlotaEL.color_unidad = txtColor.Text;
        oFlotaEL.cod_configuracion = ddlConfiguracion.SelectedValue;
        oFlotaEL.anio_unidad = Convert.ToInt32(txtAño.Text);
        oFlotaEL.cc_num = Convert.ToDecimal(txtCilindrada.Text);
        oFlotaEL.nro_cilindro = Convert.ToInt32(txtNroCilindros.Text);
        oFlotaEL.hp_rpm = "";
        oFlotaEL.nro_motor = txtNroMotor.Text;
        oFlotaEL.nro_chasis = txtNroChasis.Text;
        oFlotaEL.nro_rueda = Convert.ToInt32(txtNroRueda.Text);
        oFlotaEL.nro_eje = Convert.ToInt32(txtNroEje.Text);
        oFlotaEL.capacidad = Convert.ToInt32(txtCapacidad.Text);
        oFlotaEL.cod_operacion = ddlOperacion.SelectedValue;
        oFlotaEL.aud_usuario_creacion = "ABENDEZU";

        if (ic_action.Equals("N"))
        {
            lst = oFlotaBL.RegistrarFlota(oFlotaEL);
        }
        else
        {
            oFlotaEL.cod_flota = Convert.ToInt32(HFCodigo.Value);
            lst = oFlotaBL.ActualizarFlota(oFlotaEL);
        }

        
        if (lst[0].id_mensaje == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se registro con éxito','Alerta.','success');", true);
            MultiView1.ActiveViewIndex = 0;
        }
        else 
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('"+lst[0].mensaje+"','Alerta:','error');", true);
        }
    }

    public void registrarDocumentacion(string ic_action,int cod_doc)
    {
        DocumentacionBL oDocBL = new DocumentacionBL();
        DocumentacionEL oDocEL = new DocumentacionEL();
        List<TransaccionEL> lst = new List<TransaccionEL>();

        oDocEL.cod_flota = Convert.ToInt32(HFCodigo.Value);
        oDocEL.cod_documentacion = ddlDocumentacion.SelectedValue;
        oDocEL.fch_emision = txtEmision.Text;
        oDocEL.fch_vencimiento = txtVencimiento.Text;
        oDocEL.path_doc = "";

        //Path of the documents
        if (fuArchivo.HasFile)
        {
            var pathCarpetaDestino = Path.Combine(Server.MapPath("~/docs"), txtCodInternoDoc.Text);
            var carpetaDestino = new DirectoryInfo(pathCarpetaDestino);
            if (!carpetaDestino.Exists)
                carpetaDestino.Create();

            var nombreArchivo = Path.GetFileName(fuArchivo.FileName);
            var pathArchivoDestino = Path.Combine(pathCarpetaDestino, nombreArchivo);
            fuArchivo.SaveAs(pathArchivoDestino);
            oDocEL.path_doc = "~/docs/" + txtCodInternoDoc.Text + "/" + nombreArchivo;
        }
        

        oDocEL.aud_usuario_creacion = "ABENDEZU";

        if (ic_action.Equals("N"))
        {
            lst = oDocBL.RegistrarDocumentacion(oDocEL);
        }
        else
        {
            oDocEL.cod_doc = cod_doc;
            lst = oDocBL.ActualizarDocumentacion(oDocEL);
        }

       
        if (lst[0].id_mensaje == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se registro con éxito','Alerta.','success');", true);
        }
    }
  

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        txtCodInterno.Text = "";
        txtNroPlaca.Text = "";
        ddlVehiculo.SelectedIndex = 0;
        ddlMarca.SelectedIndex = 0;
        ddlModelo.SelectedIndex = 0;
        txtColor.Text = "";
        ddlConfiguracion.SelectedIndex = 0;
        txtNroMotor.Text = "";
        txtCilindrada.Text = "";
        txtNroCilindros.Text = "";
        txtNroChasis.Text = "";
        txtNroRueda.Text = "";
        txtNroEje.Text = "";
        txtAño.Text = "";
        txtCapacidad.Text = "";
        ddlOperacion.SelectedIndex = 0;
        HFCodigo.Value = "0";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
 
    
    protected void gvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int codigo = Convert.ToInt32(e.CommandArgument);

        switch (e.CommandName.ToString())
        {

            case "editar":
                this.HFCodigo.Value = e.CommandArgument.ToString();
                //Obteniendo datos
                FlotaBL oFlota = new FlotaBL();
                List<FlotaEL> lst = oFlota.ConsultarFlota(codigo, "");
                txtCodInterno.Text = lst[0].cod_interno.ToString();
                txtNroPlaca.Text = lst[1].nro_placa.ToString();
                ddlVehiculo.SelectedValue = lst[0].cod_tipo_vehiculo;
                ddlMarca.SelectedValue = lst[0].cod_marca;
                ddlModelo.SelectedValue = lst[0].cod_modelo;
                txtAño.Text= Convert.ToString(lst[0].anio_unidad);
                txtColor.Text = lst[0].color_unidad;
                ddlConfiguracion.SelectedValue = lst[0].cod_configuracion;
                txtNroMotor.Text = lst[0].nro_motor.ToString();
                txtNroChasis.Text = lst[0].nro_chasis.ToString();
                txtCilindrada.Text = Convert.ToString(lst[0].cc_num);
                txtNroCilindros.Text = Convert.ToString(lst[0].nro_cilindro);
                txtNroRueda.Text = Convert.ToString(lst[0].nro_rueda);
                txtNroEje.Text = Convert.ToString(lst[0].nro_eje);
                txtCapacidad.Text = Convert.ToString(lst[0].capacidad);
                ddlOperacion.SelectedValue = lst[0].cod_operacion;
                MultiView1.ActiveViewIndex = 1;
                break;
            case "ver":
                MultiView1.ActiveViewIndex = 2;
                HFCodDoc.Value = "";
                this.HFCodigo.Value = e.CommandArgument.ToString();
                //Obtener Informacion de la seleccion
                FlotaBL oFlotaDoc = new FlotaBL();
                List<FlotaEL> lstDoc = oFlotaDoc.ConsultarFlota(codigo, "");
                txtCodInternoDoc.Text = lstDoc[0].cod_interno.ToString();
                txtNroPlacaDoc.Text = lstDoc[0].nro_placa.ToString();
                //Get data of the documentation transports
                loadDocumentacion(codigo);

                /*
                MAE_Cliente entidadVer = (from cont in CMScontext.MAE_Cliente where cont.IDCliente == codigo select cont).First();
                TextBox1.Text = entidadVer.RazonSocial;
                TextBox2.Text = entidadVer.Giro;
                TextBox3.Text = entidadVer.RepresentanteLegal;
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalAlert').modal('show');", true);
                */
                break;
            case "eliminar":
                //MAE_Cliente entidadEliminar = (from cont in CMScontext.MAE_Cliente where cont.IDCliente == codigo select cont).First();
                //entidadEliminar.Estado = false;
                //CMScontext.SaveChanges();
                //loadFlota(0,"");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('Se elimino con éxito','Se elimino con éxito.','primary');", true);
                break;

        }
    }

    protected void gvMarcas_PreRender(object sender, EventArgs e)
    {
        if (gvMarcas.Rows.Count > 0)
        {
            gvMarcas.UseAccessibleHeader = true;
            gvMarcas.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvMarcas.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        


        var GridView1 = new GridView();
        FlotaBL oFlota = new FlotaBL();
        GridView1.DataSource = oFlota.ConsultarFlota(); ;
        GridView1.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=ReporteClientes_" + DateTime.Now.ToString("ddMMyyyy") + ".xls");
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

    protected void gvDocumentacion_PreRender(object sender, EventArgs e)
    {
        if (gvDocumentacion.Rows.Count > 0)
        {
            gvDocumentacion.UseAccessibleHeader = true;
            gvDocumentacion.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvDocumentacion.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (HFCodigo.Value == "0")
        {
            registrarFlota("N");
        }
        else
        {
            registrarFlota("A");
        }
        loadFlota(0, "");
    }

    protected void btnDocumentacion_Click(object sender, EventArgs e)
    {
        if (HFCodDoc.Value == "")
        {
            registrarDocumentacion("N", 0);
        }
        else
        {
            registrarDocumentacion("A", Convert.ToInt32(HFCodDoc.Value));
        }

        loadDocumentacion(Convert.ToInt32(HFCodigo.Value));
        ddlDocumentacion.SelectedIndex = 0;
        txtEmision.Text = "";
        txtVencimiento.Text = "";
        HFCodDoc.Value = "";
    }

    protected void gvDocumentacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "editar":
                
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvDocumentacion.Rows[index];
                ddlDocumentacion.SelectedValue = row.Cells[2].Text;
                txtEmision.Text = row.Cells[4].Text;
                txtVencimiento.Text = row.Cells[5].Text;
                HFCodDoc.Value = row.Cells[0].Text;
                break;

            case "descargar":

                string filename = e.CommandArgument.ToString();

                if (filename == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('No existe documento adjunto','Alerta.','error');", true);
                }
                else
                {
                    Response.Clear();
                    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", filename));
                    Response.ContentType = "application/octet-stream";
                    Response.WriteFile(Server.MapPath(filename));
                    Response.Flush();
                    Response.End();
                }
                
                break;

        }
    }

    protected void gvDocumentacion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //gvDocumentacion.Columns[1].Visible = false;
    }

    protected void gvDocumentacion_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
    }
}