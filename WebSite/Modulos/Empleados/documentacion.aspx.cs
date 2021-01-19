using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Empleados_documentacion : System.Web.UI.Page
{
    EmpleadoBL oEmpleado = new EmpleadoBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Vigencia();
            LoadFiltros();
            string cod = "";
            cod= Request.QueryString["cod"];
            hfCodId.Value = cod;
            if (!hfCodId.Value.Equals(""))
            {
                txtEmpleado_id.Text = hfCodId.Value;
                hfCodigoDoc.Value = "01";
                hfCodigoDoctxt.Value = "1. Personal";
                setTabs();
                li1.Attributes.Add("class", "current");
                li1.Attributes.Add("class", "active");
                PanelDocumento.Visible = true;
                ListarDocumento(hfCodigoDoc.Value);

                List<EmpleadoEL> lst = oEmpleado.Consultar_PorCodigo2(Convert.ToInt32(hfCodId.Value));
                txtEmpleado.Text= lst[0].nombre_emp;
            }
            
        }
    }

    public void ListarDocumento(string subCatalogo)
    {
        EmpleadoBL oDescanso = new EmpleadoBL();
        List<EmpleadoDocumento2EL> lst = oDescanso.ListarDocumentos(subCatalogo, Convert.ToInt32(txtEmpleado_id.Text));
        gvDocumento.DataSource = lst;
        gvDocumento.DataBind();
    }

    public void ListarDocumentoHistorico(string subCatalogo)
    {
        EmpleadoBL oDescanso = new EmpleadoBL();
        List<EmpleadoDocumento2EL> lst = oDescanso.ListarDocumentoHistorico(subCatalogo, Convert.ToInt32(txtEmpleado_id.Text));
        gvDocumentoHistorico.DataSource = lst;
        gvDocumentoHistorico.DataBind();
    }

    public void RegistrarDocumento()
    {
        EmpleadoBL oDocumentoBL = new EmpleadoBL();
        EmpleadoDocumentoRegistrar oDocumentoEL = new EmpleadoDocumentoRegistrar();
        oDocumentoEL.IDPersonal = Convert.ToInt32(txtEmpleado_id.Text);
        List<EmpleadoEL> lst = oDocumentoBL.Consultar_PorCodigo2(Convert.ToInt32(txtEmpleado_id.Text));
        oDocumentoEL.tipodocumento = hfCodTipoDocumento.Value;
        oDocumentoEL.documentacion = ArchivoDocumento(lst[0].nombre_emp+" "+lst[0].apellido_pat+" "+lst[0].apellido_mat, txtEmpleado.Text.Trim(), hfCodigoDoctxt.Value,lst[0].tipo_personal,lst[0].nro_documento);

        if (oDocumentoEL.documentacion.Equals("Archivo no valido"))
        {
            MostrarMensaje(1,"Archivo no valido");
        }
        else
        {
            oDocumentoEL.TieneVigencia = Convert.ToBoolean(ddlVigencia.SelectedValue);
            if (ddlVigencia.SelectedIndex == 0)
            {
                oDocumentoEL.FchInicioVigencia = txtFechaDesdeDocumento.Text;
                oDocumentoEL.FchFinVigencia = txtFechaHastaDocumento.Text;

            }
            else
            {
                oDocumentoEL.FchInicioVigencia = "01/01/1900";
                oDocumentoEL.FchFinVigencia = "01/01/1900";
            }

            oDocumentoEL.Observacion = txtObservacionDocumento.Text;

            oDocumentoBL.InsertarDocumentos(oDocumentoEL);
        }
    }

    public void ActualizarDocumento()
    {
        EmpleadoBL oDocumentoBL = new EmpleadoBL();
        EmpleadoDocumentoRegistrar oDocumentoEL = new EmpleadoDocumentoRegistrar();
        oDocumentoEL.IDDocumento = Convert.ToInt32(hfIDocuento.Value);
        oDocumentoEL.IDPersonal = Convert.ToInt32(txtEmpleado_id.Text);
        List<EmpleadoEL> lst = oDocumentoBL.Consultar_PorCodigo2(Convert.ToInt32(txtEmpleado_id.Text));
        oDocumentoEL.tipodocumento = hfCodTipoDocumento.Value;
        oDocumentoEL.documentacion = ArchivoDocumentoActualizar(txtNombreDocumento.Text, txtEmpleado.Text.Trim(), hfCodigoDoctxt.Value, lst[0].tipo_personal, lst[0].nro_documento);

        if (oDocumentoEL.documentacion.Equals("Archivo no valido"))
        {
            MostrarMensaje(1, "Archivo no valido");
        }
        else
        {
            oDocumentoEL.TieneVigencia = Convert.ToBoolean(ddlVigencia.SelectedValue);
            if (ddlVigencia.SelectedIndex == 0)
            {
                oDocumentoEL.FchInicioVigencia = txtFechaDesdeDocumento.Text;
                oDocumentoEL.FchFinVigencia = txtFechaHastaDocumento.Text;

            }
            else
            {
                oDocumentoEL.FchInicioVigencia = "01/01/1900";
                oDocumentoEL.FchFinVigencia = "01/01/1900";
            }

            oDocumentoEL.Observacion = txtObservacionDocumento.Text;

            oDocumentoBL.ActualizarDocumento(oDocumentoEL);
        }
    }

    public string ArchivoDocumento(string nombreArchivo,string Nombre, string tipo,string tipo_personal,string dni)
    {
        if (tipo_personal.Equals("220100"))
            tipo_personal = "Administrativo";
        else
            tipo_personal = "Conductores";


        string retorno = "Archivo no valido";

        nombreArchivo = nombreArchivo + "(" + txtFechaDesdeDocumento.Text.Replace("/", "-") + "_" + txtFechaHastaDocumento.Text.Replace("/", "-") + ")"+hfCodTipoDocumento.Value;
        string Extension = Path.GetExtension(FUArchivoDocumento.PostedFile.FileName);
        string FolderPath = ConfigurationManager.AppSettings["folderDocumentos2"];
        string path = FolderPath + "/" + tipo_personal + "/" + dni + "-" + Nombre + "/" + tipo;
        if (FUArchivoDocumento.HasFile)
        {
            if (Extension == ".pdf")
            {
                if (File.Exists(path))
                {
                    var pathDestino = Server.MapPath(path);
                    var PathFinal = Path.Combine(pathDestino, nombreArchivo + ".pdf");
                    FUArchivoDocumento.SaveAs(PathFinal);
                    retorno = path + "/" + nombreArchivo + ".pdf";
                }
                else
                {

                    var pathDestino = Server.MapPath(path);
                    Directory.CreateDirectory(pathDestino);
                    var PathFinal = Path.Combine(pathDestino, nombreArchivo + ".pdf");
                    FUArchivoDocumento.SaveAs(PathFinal);
                    retorno = path + "/" + nombreArchivo + ".pdf";
                }
            }
        }
        return retorno;
    }

    public string ArchivoDocumentoActualizar(string nombreArchivo, string Nombre, string tipo, string tipo_personal, string dni)
    {
        if (tipo_personal.Equals("220100"))
            tipo_personal = "Administrativo";
        else
            tipo_personal = "Conductores";


        string retorno="Archivo no valido";

        nombreArchivo = nombreArchivo + "(" + txtFechaDesdeDocumento.Text.Replace("/", "-") + "_" + txtFechaHastaDocumento.Text.Replace("/", "-") + ")"+hfCodTipoDocumento.Value+"("+gvDocumentoHistorico.Rows.Count+")";
        string Extension = Path.GetExtension(FUArchivoDocumento.PostedFile.FileName);
        string FolderPath = ConfigurationManager.AppSettings["folderDocumentos2"];
        string path = FolderPath + "/" + tipo_personal + "/" + dni + "-" + Nombre + "/" + tipo;
        if (FUArchivoDocumento.HasFile)
        {
            if (Extension == ".pdf")
            {
                if (File.Exists(path))
                {
                    var pathDestino = Server.MapPath(path);
                    var PathFinal = Path.Combine(pathDestino, nombreArchivo + ".pdf");
                    FUArchivoDocumento.SaveAs(PathFinal);
                    retorno= path + "/" + nombreArchivo + ".pdf";
                }
                else
                {

                    var pathDestino = Server.MapPath(path);
                    Directory.CreateDirectory(pathDestino);
                    var PathFinal = Path.Combine(pathDestino, nombreArchivo + ".pdf");
                    FUArchivoDocumento.SaveAs(PathFinal);
                    retorno=path + "/" + nombreArchivo + ".pdf";
                }
            }
        }
        return retorno;
    }

    public void setTabs()
    {
        li1.Attributes.Add("class", "");
        li2.Attributes.Add("class", "");
        li3.Attributes.Add("class", "");
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

    protected void btnBuscarEmpleadoDocumento_Click(object sender, EventArgs e)
    {
        if (!txtEmpleado_id.Text.Equals(""))
        {
            hfCodigoDoc.Value = "01";
            hfCodigoDoctxt.Value = "1. Personal";
            setTabs();
            li1.Attributes.Add("class", "current");
            li1.Attributes.Add("class", "active");
            PanelDocumento.Visible = true;
            ListarDocumento(hfCodigoDoc.Value);
        }
        else
        {
            MostrarMensaje(1,"Se debe selecciona un empleado");
        }
    }

    protected void lnkPersonal_Click(object sender, EventArgs e)
    {
        hfCodigoDoc.Value = "01";
        hfCodigoDoctxt.Value = "1. Personal";
        setTabs();
        li1.Attributes.Add("class", "current");
        li1.Attributes.Add("class", "active");
        ListarDocumento(hfCodigoDoc.Value);
    }

    protected void lnkRegistro_Click(object sender, EventArgs e)
    {
        hfCodigoDoc.Value = "02";
        hfCodigoDoctxt.Value = "2. Registro";
        setTabs();
        li2.Attributes.Add("class", "current");
        li2.Attributes.Add("class", "active");
        ListarDocumento(hfCodigoDoc.Value);
    }

    protected void lnkCapacitacion_Click(object sender, EventArgs e)
    {
        hfCodigoDoc.Value = "03";
        hfCodigoDoctxt.Value = "3. Capacitacion";
        setTabs();
        li3.Attributes.Add("class", "current");
        li3.Attributes.Add("class", "active");
        ListarDocumento(hfCodigoDoc.Value);
    }

    public void Vigencia()
    {
        ddlVigencia.Items.Clear();
        ddlVigencia.Items.Add("Si");
        ddlVigencia.Items[0].Value = "true";
        ddlVigencia.Items.Add("No");
        ddlVigencia.Items[1].Value = "false";
    }

    public void LoadFiltros()
    {
        ddlFitro.Items.Clear();
        ddlFitro.Items.Add("Exportar Licencias");
        ddlFitro.Items.Add("Exportar por Fechas");
    }

    protected void gvDocumento_PreRender(object sender, EventArgs e)
    {
        if (gvDocumento.Rows.Count > 0)
        {
            gvDocumento.UseAccessibleHeader = true;
            gvDocumento.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvDocumento.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void btnAgregarArchivo_Click(object sender, EventArgs e)
    {
        txtNombreDocumento.Text = txtEmpleado.Text;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalArchivo').modal('show');", true);
    }

    public string ValidaciondeDocumentoRegistro()
    {
        string validacion = "0El documento se registro Correctamente";

        if (ddlVigencia.SelectedIndex == 0)
        {
            if ((txtFechaHastaDocumento.Text.Equals("") || txtFechaDesdeDocumento.Text.Equals("")) && ddlVigencia.SelectedIndex == 0)
            {
                validacion = "1Se debe llenar la fecha inicio y la fecha fin del documento";
            }
            else
            {
                if (Convert.ToDateTime(txtFechaDesdeDocumento.Text) > Convert.ToDateTime(txtFechaHastaDocumento.Text))
                {
                    validacion = "1La fecha de inicio debe ser menor a la fecha fin";
                }
            }
        }

        return validacion;
    }

    protected void btnGuardarArchivo_Click(object sender, EventArgs e)
    {
        try
        {
            string validacion = ValidaciondeDocumentoRegistro();
            int codigomensaje = Convert.ToInt32(validacion.Substring(0, 1));
            string mensaje = validacion.Substring(1, validacion.Length - 1);

            if (codigomensaje == 0)
            {
                switch (hfOperacion.Value)
                {
                    case "Insertar":
                        RegistrarDocumento();
                        ListarDocumento(hfCodigoDoc.Value);
                        MostrarMensaje(codigomensaje, mensaje);
                        break;

                    case "Actualizar":
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalConfirmacionActualizacion').modal('show');", true);
                        ActualizarDocumento();
                        ListarDocumento(hfCodigoDoc.Value);
                        MostrarMensaje(0, "El documento se actualizo correctamente");
                        break;
                }
            }
            else
            {
                MostrarMensaje(codigomensaje,mensaje);
            }

        }
        catch (Exception ex)
        {
            MostrarMensaje(1, ex.Message.ToString());
        }
    }

    protected void ddlVigencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVigencia.SelectedIndex == 0)
        {
            txtFechaDesdeDocumento.Enabled = true;
            txtFechaHastaDocumento.Enabled = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalArchivo').modal('show');", true);
        }
        else
        {
            txtFechaDesdeDocumento.Enabled = false;
            txtFechaHastaDocumento.Enabled = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalArchivo').modal('show');", true);
        }
    }

    protected void gvDocumento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "registrar":
                hfIDocuento.Value = "";
                txtFechaDesdeDocumento.Text = "";
                txtFechaHastaDocumento.Text = "";
                txtObservacionDocumento.Text = "";

                string[] arg = new string[3];
                arg = e.CommandArgument.ToString().Split(';');
                hfIDocuento.Value = arg[0];
                hfCodTipoDocumento.Value = arg[1];
                txtNombreDocumento.Text = arg[2];

                if (hfIDocuento.Value.Equals(""))
                    hfOperacion.Value ="Insertar";
                else
                    hfOperacion.Value = "Actualizar";

                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalArchivo').modal('show');", true);

                break;
            case "Descargar":
                string[] arg2 = new string[4];
                
                arg2 = e.CommandArgument.ToString().Split(';');
                string filename = arg2[1];
                if (!filename.Equals(""))
                {
                    arg2[2]=Convert.ToDateTime(arg2[2]).ToString("yyyyMMdd");
                    arg2[3]=Convert.ToDateTime(arg2[3]).ToString("yyyyMMdd");
                      
                
                   
                    Response.Clear();
                    //Response.AddHeader("content-disposition", string.Format("attachment;filename{0}", filename));
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + arg2[0].Replace(" ","")+"("+arg2[2]+"-"+arg2[3]+")"+".pdf");
                    Response.ContentType = "Application/pdf";
                    Response.WriteFile(Server.MapPath(filename));
                    Response.Flush();
                    Response.End();
                }
                break;
            case "Visualizar":
                ListarDocumentoHistorico(e.CommandArgument.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalSeguimiento').modal('show');", true);
                break;
            case "editar":
                hfIDocuento.Value = "";
                txtFechaDesdeDocumento.Text = "";
                txtFechaHastaDocumento.Text = "";
                txtObservacionDocumento.Text = "";
                FUArchivoDocumento.Enabled = false;

                string[] arg3 = new string[5];
                arg3 = e.CommandArgument.ToString().Split(';');
                hfIDocuento.Value = arg3[0];
                hfCodTipoDocumento.Value = arg3[1];
                txtNombreDocumento.Text = arg3[2];

                if (hfIDocuento.Value.Equals(""))
                    hfOperacion.Value = "Insertar";
                else
                    hfOperacion.Value = "Actualizar";

                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalArchivo').modal('show');", true);

                break;
            case "Eliminar":
                hfIDocuento.Value = e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert3').modal('show');", true);
                break;

        }
    }

    protected void gvDocumento_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkVisualizar = (LinkButton)e.Row.FindControl("lnkVisualizar");
            Label lblVigencia = (Label)e.Row.FindControl("lblVigencia");
            Label lblEstado = (Label)e.Row.FindControl("lblEstado");
            Label lblFchIni = (Label)e.Row.FindControl("lblFchIni");
            Label lblFchFin = (Label)e.Row.FindControl("lblFchFin");

            if (lblVigencia.Text.Equals("1"))
            {
                lblVigencia.Text = "Si";
                lblVigencia.CssClass = "label label-icon waves-effect waves-light btn-teal m-b-5";
            }
            else if(lblVigencia.Text.Equals("0"))
            {
                lblVigencia.Text = "No";
                lblVigencia.CssClass = "label label-icon waves-effect waves-light btn-danger m-b-5";
                lblFchIni.Text = "";
                lblFchFin.Text = "";
                
            }
            if (lblEstado.Text.Equals("0"))
            {
                lblEstado.Text = "Entregado";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-teal m-b-5";
            }
            else if (lblEstado.Text.Equals("1"))
            {
                lblEstado.Text = "Vencido";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-danger m-b-5";

            }
            else if (lblEstado.Text.Equals("3"))
            {
                lblEstado.Text = "Pendiente";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-danger m-b-5";
                lnkVisualizar.Visible = false;
            }
        }
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            ActualizarDocumento();
            ListarDocumento(hfCodigoDoc.Value);
            MostrarMensaje(0,"El documento se actualizo correctamente");

        }
        catch(Exception ex)
        {
            MostrarMensaje(1, ex.Message.ToString());
        }
    }

    public void ExportarDocumentacionReporte(DateTime fchInicio, DateTime fchFin)
    {


        var GridView1 = new GridView();
        DataTable dt = oEmpleado.DocumentacionReporte(fchInicio, fchFin);

        if (dt.Rows.Count > 0)
        {
            for (int i = dt.Columns.Count - 1; i >= 0; i--)
            {
                Boolean vacio = true;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (!dt.Rows[j][i].Equals(""))
                    {
                        vacio = false;
                    }
                }

                if (vacio)
                {
                    dt.Columns.Remove(dt.Columns[i]);
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();



            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attacNhment;filename=ReporteDocumentos_" + fchInicio.ToShortDateString() + "_" + fchFin.ToShortDateString() + ".xls");
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
        else
        {
            MostrarMensaje(1,"No se encontro documentos con fecha de vencimiento en el rango seleccionado");
        }
    }

    public void ExportarLicencias()
    {


        var GridView1 = new GridView();
        DataTable dt = oEmpleado.ExportarLicencias();

        if (dt.Rows.Count > 0)
        {
            for (int i = dt.Columns.Count - 1; i >= 0; i--)
            {
                Boolean vacio = true;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (!dt.Rows[j][i].Equals(""))
                    {
                        vacio = false;
                    }
                }

                if (vacio)
                {
                    dt.Columns.Remove(dt.Columns[i]);
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();



            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attacNhment;filename=Reporte_licencias_activas.xls");
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
        else
        {
            MostrarMensaje(1, "No se encontro documentos con fecha de vencimiento en el rango seleccionado");
        }
    }

    protected void btnExportarDocumentacion_Click(object sender, EventArgs e)
    {
        fchInicioFiltro.Text = "";
        fchFinFiltro.Text="";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#DocumentoReporte').modal('show');", true);
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        if(ddlFitro.SelectedIndex == 0)
        {
            ExportarLicencias();
        }
        else if (ddlFitro.SelectedIndex == 1)
        {
            DateTime fchInicio = Convert.ToDateTime(fchInicioFiltro.Text);
            DateTime fchFin = Convert.ToDateTime(fchFinFiltro.Text);
            ExportarDocumentacionReporte(fchInicio, fchFin);
        }
    }

    public void EliminarDocumento()
    {
        EmpleadoBL oDocumentoBL = new EmpleadoBL();
        oDocumentoBL.EliminarDocumento(Convert.ToInt32(hfIDocuento.Value));
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        
            EliminarDocumento();
            ListarDocumento(hfCodigoDoc.Value);
            MostrarMensaje(0, "El documento se ha eliminado de manera correcta");
        
    }

    protected void ddlFitro_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFitro.SelectedIndex==1)
        {
            pnlFiltroFechas.Visible = true;
        }
        else
            pnlFiltroFechas.Visible = false;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#DocumentoReporte').modal('show');", true);
    }
}