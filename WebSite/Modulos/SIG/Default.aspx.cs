using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_SIG_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarEmpresa();
            LlenarTipo();
            //Perfil();
            
        }
    }
    
    //public void Perfil()
    //{
    //    HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
    //    if (authCookie != null)
    //    {
    //        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
    //        String dataUser = (authTicket.UserData != null && authTicket.UserData != "" ? authTicket.UserData : "");
    //        String[] data = dataUser.Split('|');
    //        string perfil = data[3];
    //        int tamaño = perfil.Length;
    //        lblTitulo.Text = perfil.Substring(3,tamaño-3); 
    //    }
    //}

    public void ListarEmpresa()
    {
        TerceroEmpresaBL oEmpresa = new TerceroEmpresaBL();
        List<TerceroEmpresaEL> lst = oEmpresa.ListarEmpresa();
        grvEmpresa.DataSource = lst;
        grvEmpresa.DataBind();
    }

    public void ListarConductor()
    {
        TerceroConductorBL oConductor = new TerceroConductorBL();
        TerceroConductorEL objConductor = new TerceroConductorEL();
        objConductor.id_emp = Convert.ToInt32(idemp.Text);
        List<TerceroConductorEL> lst = oConductor.ListarConductor(objConductor);
        grvConductor.DataSource = lst;
        grvConductor.DataBind();
    }

    public void ListarUnidad()
    {
        TerceroUnidadBL oUnidad = new TerceroUnidadBL();
        TerceroUnidadEL objUnidad = new TerceroUnidadEL();
        objUnidad.id_emp = Convert.ToInt32(idemp.Text);
        List<TerceroUnidadEL> lst = oUnidad.ListarUnidad(objUnidad);
        grvUnidad.DataSource = lst;
        grvUnidad.DataBind();
    }

    public void ListarDocumento()
    {
        TerceroDocumentacionBL oDocumento = new TerceroDocumentacionBL();
        TerceroDocuementacionEL objDocumento = new TerceroDocuementacionEL();
        objDocumento.tipo = txtTipo.Text;
        objDocumento.id = Convert.ToInt32(txtIdtipo.Text);
        List<TerceroDocuementacionEL> lst = oDocumento.ListarDocumentacion(objDocumento);
        grvDocumentacion.DataSource = lst;
        grvDocumentacion.DataBind();
    }


    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        AbrirPopUp("infoModalAlert2");
    }

    public void RegistrarEmpresa()
    {
        TerceroEmpresaBL oEmpresaBL = new TerceroEmpresaBL();
        TerceroEmpresaEL oEmpresaEL = new TerceroEmpresaEL();
        oEmpresaEL.Emp_Rsoc = txtRsoc.Text;
        oEmpresaEL.RUC = txtRuc.Text;
        oEmpresaEL.Contacto = txtContacto.Text;
        oEmpresaEL.telefono = txtTelefono.Text;
        List<TransaccionEL> lst = oEmpresaBL.RegistrarEmpresa(oEmpresaEL);

    }

    public void RegistrarConductor()
    {
        TerceroConductorBL oConductorBL = new TerceroConductorBL();
        TerceroConductorEL oConductorEL = new TerceroConductorEL();
        oConductorEL.id_emp = Convert.ToInt32(idemp.Text);
        oConductorEL.nombre = txtNombre.Text;
        oConductorEL.dni = txtDni.Text;
        oConductorEL.licencia = txtLicencia.Text;
        oConductorEL.cat_licencia = txtCatLic.Text;
        List<TransaccionEL> lst = oConductorBL.RegistrarConductor(oConductorEL);
    }

    public void RegistrarUnidad()
    {
        TerceroUnidadBL oUnidadrBL = new TerceroUnidadBL();
        TerceroUnidadEL oUnidadEL = new TerceroUnidadEL();
        oUnidadEL.id_emp = Convert.ToInt32(idemp.Text);
        oUnidadEL.placa = txtPlaca.Text;
        if (txtClasificacion.Text.Equals(""))
        {
            oUnidadEL.clasificacion = "";
        }
        else
        {
            oUnidadEL.clasificacion = txtClasificacion.Text;
        }
        if (txtConfiguracion.Text.Equals(""))
        {
            oUnidadEL.configuracion = "";
        }
        else
        {
            oUnidadEL.configuracion = txtConfiguracion.Text;
        }
        if (txtClasificacion.Text.Equals(""))
        {
            oUnidadEL.año_fabricacion = "";
        }
        else
        {
            oUnidadEL.año_fabricacion = txtAñoFab.Text;
        }
        List<TransaccionEL> lst = oUnidadrBL.RegistrarUnidad(oUnidadEL);
    }

    public void RegistrarDocumento()
    {
        TerceroDocumentacionBL oDocumentoBL = new TerceroDocumentacionBL();
        TerceroDocuementacionEL oDocumentoEL = new TerceroDocuementacionEL();
        oDocumentoEL.tipo_doc = ddlTipoDocu.SelectedValue.ToString();
        oDocumentoEL.tipo = txtTipo.Text;
        oDocumentoEL.id = Convert.ToInt32(txtIdtipo.Text);
        oDocumentoEL.fecha_registro = txtFechaRegistro.Text;
        oDocumentoEL.fecha_fin = txtFechaFin.Text;
        oDocumentoEL.documentacion = ArchivoDocumento(lblDocumentacion.Text.Substring(0, 6) + "_" + ddlTipoDocu.SelectedItem.ToString());
        oDocumentoBL.RegistrarDocumentacion(oDocumentoEL);
    }

    public string ArchivoDocumento(string nombreArchivo)
    {
        //DataTable ds = new DataTable();

        //string FileName = Path.GetFileName(fuArchivo.PostedFile.FileName);
        string Extension = Path.GetExtension(fuArchivo.PostedFile.FileName);
        string FolderPath = ConfigurationManager.AppSettings["folderDocumentos"];
        if (fuArchivo.HasFile)
        {
            if (Extension == ".pdf")
            {
                var pathDestino = Server.MapPath(FolderPath);
                //var carpetaDestino = new DirectoryInfo(pathDestino);
                //nombreArchivo = Path.GetFileName(fuArchivo.FileName);
                var PathFinal = Path.Combine(pathDestino, nombreArchivo + ".pdf");
                fuArchivo.SaveAs(PathFinal);
            }
        }
        return FolderPath + "/" + nombreArchivo + ".pdf";
    }

    public void loadItems(DropDownList ddl, string id_catalogo)
    {
        ItemBL oItem = new ItemBL();
        ddl.DataSource = oItem.ListarItemOpe(id_catalogo);
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Documentos --", ""));
        ddl.SelectedIndex = 0;
    }

    public void CargarItems(DropDownList ddl, string id_catalogo)
    {
        ItemBL oItem = new ItemBL();
        List<ItemEL> lst = oItem.ListarItemOpe(id_catalogo);
        string tabla = "";
        int y = 0;
        if (txtTipo.Text.Equals("U"))
        {
            tabla = "00";
        }
        else
        {
            tabla = "01";
        }
        ddl.Items.Clear();
        for (int i = 0; i < lst.Count; i++)
        {

            if (lst[i].id_descripcion.Substring(4, 2).Equals(tabla))
            {
                ddl.Items.Add(lst[i].descripcion);
                ddl.Items[y].Value = lst[i].id_descripcion;
                y++;
            }
        }
        ddl.Items.Insert(0, new ListItem("-- Documentos --", ""));
        ddl.SelectedIndex = 0;
    }


    public void ActualizarEmpresa()
    {
        TerceroEmpresaBL oEmpresaBL = new TerceroEmpresaBL();
        TerceroEmpresaEL oEmpresaEL = new TerceroEmpresaEL();
        oEmpresaEL.id = Convert.ToInt32(txtId.Text);
        oEmpresaEL.Emp_Rsoc = txtRsoc.Text;
        oEmpresaEL.RUC = txtRuc.Text;
        oEmpresaEL.Contacto = txtContacto.Text;
        oEmpresaEL.telefono = txtTelefono.Text;
        List<TransaccionEL> lst = oEmpresaBL.ActualizarEmpresa(oEmpresaEL);
    }

    public void ActualizarConductor()
    {
        TerceroConductorBL oConductorBL = new TerceroConductorBL();
        TerceroConductorEL oConductorEL = new TerceroConductorEL();
        oConductorEL.id_conductor = Convert.ToInt32(txtId.Text);
        oConductorEL.nombre = txtNombre.Text;
        oConductorEL.dni = txtDni.Text; ;
        oConductorEL.licencia = txtLicencia.Text;
        oConductorEL.cat_licencia = txtCatLic.Text;
        List<TransaccionEL> lst = oConductorBL.ActualizarConductor(oConductorEL);
    }

    public void ActualizarUnidad()
    {
        TerceroUnidadBL oUnidadBL = new TerceroUnidadBL();
        TerceroUnidadEL oUnidadEL = new TerceroUnidadEL();
        oUnidadEL.id_unidad = Convert.ToInt32(txtId.Text);
        oUnidadEL.placa = txtPlaca.Text;
        oUnidadEL.clasificacion = txtClasificacion.Text;
        oUnidadEL.configuracion = txtConfiguracion.Text;
        oUnidadEL.año_fabricacion = txtAñoFab.Text;
        List<TransaccionEL> lst = oUnidadBL.ActualizarUnidad(oUnidadEL);
    }

    public void EliminarEmpresa()
    {
        TerceroEmpresaBL oEmpresaBL = new TerceroEmpresaBL();
        TerceroEmpresaEL oEmpresaEL = new TerceroEmpresaEL();
        oEmpresaEL.id = Convert.ToInt32(txtId.Text);
        List<TransaccionEL> lst = oEmpresaBL.EliminarEmpresa(oEmpresaEL);
    }

    public void EliminarConductor()
    {
        TerceroConductorBL oConductorBL = new TerceroConductorBL();
        TerceroConductorEL oConductorEL = new TerceroConductorEL();
        oConductorEL.id_conductor = Convert.ToInt32(txtId.Text);
        List<TransaccionEL> lst = oConductorBL.EliminarConductor(oConductorEL);
    }

    public void EliminarUnidad()
    {
        TerceroUnidadBL oUnidadBL = new TerceroUnidadBL();
        TerceroUnidadEL oUnidadEL = new TerceroUnidadEL();
        oUnidadEL.id_unidad = Convert.ToInt32(txtId.Text);
        List<TransaccionEL> lst = oUnidadBL.EliminarUnidad(oUnidadEL);
    }

    public void EliminarDocumento()
    {
        TerceroDocumentacionBL DocumentoBL= new TerceroDocumentacionBL();
        TerceroDocuementacionEL DocumentoEL = new TerceroDocuementacionEL();
        DocumentoEL.id_doc = Convert.ToInt32(txtId.Text);
        List<TransaccionEL> lst = DocumentoBL.EliminarDocumentacion(DocumentoEL);
    }


    protected void btnAgregarEmpresa_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtId.Text.Length == 0)
            {
                RegistrarEmpresa();
                ListarEmpresa();
                MostrarMensaje(0, "Registrado Correctamente");
            }
            else
            {
                ActualizarEmpresa();
                ListarEmpresa();
                MostrarMensaje(0, "Actualizado Correctamente");
            }
        }
        catch
        {
            MostrarMensaje(1, "Algo sucedio, llame al administrador del sistema");
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            EliminarEmpresa();
            ListarEmpresa();
            MostrarMensaje(0, "Eliminado Correctamente");
        }
        catch
        {
            MostrarMensaje(1, "Algo sucedio, llame al administrador del sistema");
        }
    }

    public void LlenarTipo()
    {
        ddlTipo.Items.Clear();
        ddlTipo.Items.Add("--Seleccionar--");
        ddlTipo.Items.Add("Conductor");
        ddlTipo.Items.Add("Unidad");
    }

    protected void grvEmpresa_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Observar":
                string[] arg2 = new string[2];
                arg2 = e.CommandArgument.ToString().Split(';');
                idemp.Text = arg2[0];
                lblEmpresa.Text = "(" + arg2[1] + ")";
                MultiView1.ActiveViewIndex = 1;
                ddlTipo.SelectedIndex = 0;
                grvUnidad.DataSource = "";
                grvUnidad.DataBind();
                grvConductor.DataSource = "";
                grvConductor.DataBind();
                break;
            case "Actualizar":
                string[] arg = new string[5];
                arg = e.CommandArgument.ToString().Split(';');
                txtId.Text = arg[0];
                txtRsoc.Text = arg[1];
                txtRuc.Text = arg[2];
                txtContacto.Text = arg[3];
                txtTelefono.Text = arg[4];
                AbrirPopUp("infoModalAlert2");
                break;
            case "Eliminar":
                txtId.Text = e.CommandArgument.ToString();
                AbrirPopUp("infoModalAlert3");
                break;
        }
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        ListarEmpresa();
        MultiView1.ActiveViewIndex = MultiView1.ActiveViewIndex-1;
    }

    public void AbrirPopUp(string PopUp)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#" + PopUp + "').modal('show');", true);
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

    protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipo.SelectedIndex == 2)
        {
            grvConductor.Visible = false;
            ListarUnidad();
            grvUnidad.Visible = true;
        }
        else if (ddlTipo.SelectedIndex == 1)
        {
            grvUnidad.Visible = false;
            ListarConductor();
            grvConductor.Visible = true;
        }


    }

    public void LimpiartxtUnidad()
    {
        txtPlaca.Text = "";
        txtClasificacion.Text = "";
        txtConfiguracion.Text = "";
        txtAñoFab.Text = "";
    }

    public void LimpiartxtConductor()
    {
        txtNombre.Text = "";
        txtDni.Text = "";
        txtLicencia.Text = "";
        txtCatLic.Text = "";
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlTipo.SelectedIndex == 2)
            {
                AbrirPopUp("infoModalAlert5");
                LimpiartxtUnidad();
            }
            else if (ddlTipo.SelectedIndex == 1)
            {
                AbrirPopUp("infoModalAlert4");
                LimpiartxtConductor();
            }

        }
        catch
        {
            MostrarMensaje(1, "Algo sucedio, llame al administrador del sistema");
        }
    }

    protected void btnGrabarConductor_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtAccionConductor.Text.Equals(""))
            {
                RegistrarConductor();
                ListarConductor();
                MostrarMensaje(0, "Registrado Correctamente");
            }
            else
            {
                ActualizarConductor();
                ListarConductor();
                MostrarMensaje(0, "Actualizado Correctamente");
            }
            txtAccionConductor.Text = "";
        }
        catch
        {
            MostrarMensaje(1, "Algo sucedio, llame al administrador del sistema");
        }

    }

    protected void btnGrabarUnidad_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtAccionUnidad.Text.Equals(""))
            {
                if (!txtPlaca.Text.Equals(""))
                {
                    RegistrarUnidad();
                    ListarUnidad();
                    MostrarMensaje(0, "Registrado Correctamente");
                }
                else
                {
                    MostrarMensaje(1, "Debe llenar la placa");
                }
            }
            else
            {
                ActualizarUnidad();
                ListarUnidad();
                MostrarMensaje(0, "Actualizado Correctamente");
            }
            txtAccionUnidad.Text = "";
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "Algo sucedio, llame al administrador del sistema");
        }


    }

    protected void grvConductor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Observar":
                string[] arg2 = new string[3];
                arg2 = e.CommandArgument.ToString().Split(';');
                txtIdtipo.Text = arg2[0];
                doc1.Visible = false;
                lblDocumentacion.Text = arg2[2] + " (Documentacion)";
                doc2.Visible = true;
                lblDocumentacion2.Text = arg2[1] + " (Documentacion)";
                txtTipo.Text = "C";
                MultiView1.ActiveViewIndex = 2;
                CargarItems(ddlTipoDocu, "20");
                ListarDocumento();
                break;
            case "Actualizar":
                string[] arg = new string[5];
                arg = e.CommandArgument.ToString().Split(';');
                txtId.Text = arg[0];
                txtNombre.Text = arg[1];
                txtDni.Text = arg[2];
                txtLicencia.Text = arg[3];
                txtCatLic.Text = arg[4];
                txtAccionConductor.Text = "actualizar";
                AbrirPopUp("infoModalAlert4");
                break;
            case "Eliminar":
                txtId.Text = e.CommandArgument.ToString();
                txtEliTipo.Text = "conductor";
                AbrirPopUp("infoModalAlert6");
                break;
        }
    }

    protected void grvUnidad_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Observar":
                string[] arg2 = new string[2];
                arg2 = e.CommandArgument.ToString().Split(';');
                txtIdtipo.Text = arg2[0];
                lblDocumentacion.Text = arg2[1] + " (Documentacion)";
                doc1.Visible = true;
                doc2.Visible = false;
                txtTipo.Text = "U";
                MultiView1.ActiveViewIndex = 2;
                CargarItems(ddlTipoDocu, "20");
                ListarDocumento();
                break;
            case "Actualizar":
                string[] arg = new string[9];
                arg = e.CommandArgument.ToString().Split(';');
                txtId.Text = arg[0];
                txtPlaca.Text = arg[1];
                txtClasificacion.Text = arg[2];
                txtConfiguracion.Text = arg[3];
                txtAñoFab.Text = arg[4];
                txtAccionUnidad.Text = "actualizar";
                AbrirPopUp("infoModalAlert5");
                break;
            case "Eliminar":
                txtId.Text = e.CommandArgument.ToString();
                txtEliTipo.Text = "unidad";
                AbrirPopUp("infoModalAlert6");
                break;
        }
    }

    protected void btnEliminarTipo_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtEliTipo.Text.Equals("conductor"))
            {
                EliminarConductor();
                ListarConductor();
            }
            else if (txtEliTipo.Text.Equals("Doc"))
            {
                EliminarDocumento();
                ListarDocumento();
            }
            else
            {
                EliminarUnidad();
                ListarUnidad();
            }
            MostrarMensaje(0, "Eliminado Correctamente");
        }
        catch
        {
            MostrarMensaje(1, "Algo sucedio, llame al administrador del sistema");
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

    protected void grvUnidad_PreRender(object sender, EventArgs e)
    {
        Prerender(grvUnidad);
    }

    protected void grvConductor_PreRender(object sender, EventArgs e)
    {
        Prerender(grvConductor);
    }

    protected void grvEmpresa_PreRender(object sender, EventArgs e)
    {
        Prerender(grvEmpresa);
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        AbrirPopUp("infoModalAlert8");
        ddlTipoDocu.SelectedIndex = 0;
        txtFechaRegistro.Text = "";
        txtFechaFin.Text = "";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlTipoDocu.SelectedIndex==0)
            {
                MostrarMensaje(1,"Debe seleccionar el tipo de documento");
            }
            else
            {
                RegistrarDocumento();
                ListarDocumento();
                MostrarMensaje(0, "Se registro el Documento correctamente");
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "Ha ocurrido algo");
        }

    }

    protected void grvDocumentacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {

            case "Observar":
                Response.Redirect(e.CommandArgument.ToString());
                //Response.Write("<script> window.open('" + e.CommandArgument.ToString()+ "','_blank'); </script>");
                break; 
            case "Descargar":
                string filename = e.CommandArgument.ToString();
                if (!filename.Equals(""))
                {
                    Response.Clear();
                    //Response.AddHeader("content-disposition", string.Format("attachment;filename{0}", filename));
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + filename.Substring(13, filename.Length - 13));
                    Response.ContentType = "Application/pdf";
                    Response.WriteFile(Server.MapPath(filename));
                    Response.Flush();
                    Response.End();
                }
                break;
            case "Eliminar":
                txtId.Text = e.CommandArgument.ToString();
                txtEliTipo.Text = "Doc";
                AbrirPopUp("infoModalAlert7");
                break;

        }
    }
}