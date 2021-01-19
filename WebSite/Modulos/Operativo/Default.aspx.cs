using BL;
using DAL;
using EL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Operativo_Prueba : System.Web.UI.Page
{
    int id;
    string extension="";
    int CantContenedores;
    int error = 0;
    string mensaje = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarEstado();
            ListarNaveContenedor();
            llenarPuerto();
            llenarOperacion();
            loadItems(ddlExportar, "21");
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
            hfNomUser.Value = data[0];
        }
    }
    
    public void ListarNaveContenedor()
    {
        NaveBL oNave = new NaveBL();
        List<NaveEL> lst = oNave.ListarContenedorNave(ddlEstadoNave.SelectedValue);
        grvNave.DataSource = lst;
        grvNave.DataBind();
    }

    public void registrarNave(DateTime fecha)
    {
        if (txtNave.Text.Length > 1)
        {
            NaveBL oNaveBL = new NaveBL();
            NaveEL oNaveEL = new NaveEL();
            oNaveEL.nave = txtNave.Text;
            oNaveEL.puerto = ddlPuerto.SelectedItem.Text;
            oNaveEL.fecha_registro = fecha;
            List<TransaccionEL> lst = oNaveBL.RegistrarNave(oNaveEL);
            if (lst[0].id_mensaje == 1)
            {
                id = Convert.ToInt32(lst[0].mensaje);
            }
        }
        else
        {
            mensaje = "Falto ingresar el nombre de la nave";
        }
    }

    public int ConsultarSeguimiento(int id, int id_cnt)
    {

        ContenedorBL oContenedorBL = new ContenedorBL();
        ContenedorEL oContenedorEL = new ContenedorEL();
        oContenedorEL.id = id;
        oContenedorEL.id_cnt = id_cnt;
        List<TransaccionEL> lst = oContenedorBL.ConsultarSeguimiento(oContenedorEL);

        return Convert.ToInt32(lst[0].id_mensaje);

    }

    public int ConsultarNaveSeguimiento(int id)
    {

        ContenedorBL oContenedorBL = new ContenedorBL();
        ContenedorEL oContenedorEL = new ContenedorEL();
        oContenedorEL.id = id;
        List<TransaccionEL> lst = oContenedorBL.ConsultarNaveSeguimiento(oContenedorEL);

        return Convert.ToInt32(lst[0].id_mensaje);

    }
    public int registrarNaveDescarga()
    {
        int rpt = 0;
        DateTime fecha;
        DateTime d;
        bool tf = false;
        NaveBL oNaveBL = new NaveBL();
        List<NaveEL> lst2 = oNaveBL.ListarContenedorNave(ddlEstadoNave.SelectedValue);

        for (int i = 0; i < lst2.Count; i++)
        {
            if (txtNmanifiesto.Text.Equals(lst2[i].nro_manifiesto) && lst2[i].anio_manifiesto == txtAmanifiesto.Text)
            {
                tf = true;
                break;
            }

        }

        if (tf == false)
        {
            NaveEL oNaveEL = new NaveEL();
            oNaveEL.anio_manifiesto = txtAmanifiesto.Text;
            oNaveEL.nro_manifiesto = txtNmanifiesto.Text;
            oNaveEL.puerto = ddlPuerto.SelectedItem.Text;
            oNaveEL.nave = txtNave.Text;
            if (txtFecha.Text.Length == 0)
            {
                fecha = System.DateTime.Now;
            }
            else
            {
                if (txtHora.Text.Length == 0)
                {
                    fecha = Convert.ToDateTime(txtFecha.Text + ' ' + System.DateTime.Now.Hour + ':' + System.DateTime.Now.Minute);
                }
                else
                {
                    fecha = Convert.ToDateTime(txtFecha.Text + ' ' + txtHora.Text);
                }
            }

            oNaveEL.fecha_registro = fecha;
            List<TransaccionEL> lst = oNaveBL.RegistrarNaveDescarga(oNaveEL);
            if (lst[0].id_mensaje == 1)
            {
                id = Convert.ToInt32(lst[0].mensaje);
            }
            error = 0;
            mensaje = "Se registro correctamente la nave de Descarga";
            rpt = 1;

        }
        else
        {
            rpt = 0;
            error = 1;
            mensaje = "El numero de manifiesto ya ha sido registrado";
        }


        return rpt;
    }

    public void Limpiar()
    {
        txtNave.Text = "";
    }

    public void RegistrarContenedor()
    {
        try
        {
            ContenedorBL oContenedorBL = new ContenedorBL();
            ContenedorEL objContenedor = new ContenedorEL();
            objContenedor.id = Convert.ToInt32(txtCodNave.Text);
            objContenedor.contenedor = txtContenedor.Text;
            objContenedor.tipo = txtTipo.Text;
            if (chk.Checked)
            {
                objContenedor.vacio = "x";
            }
            else
            {
                objContenedor.vacio = "";
            }
            List<TransaccionEL> lst2 = oContenedorBL.RegistarContenedor(objContenedor);
            error = 0;
            mensaje = "Se registro el contenedor correctamente";
        }
        catch
        {
            error = 1;
            mensaje = "Porfavor ingrese los datos correctamnete1";
        }
    }


    public void ImportarContenedores()
    {
        DataTable ds = new DataTable();
        ContenedorBL oContenedorBL = new ContenedorBL();
        ArrayList ContenedorA = new ArrayList();
        string FileName = Path.GetFileName(fuImportar.PostedFile.FileName);
        string Extension = Path.GetExtension(fuImportar.PostedFile.FileName);
        string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
        extension = Extension;
        if (Extension == ".xls" || Extension == ".xlsx")
        {
            string FilePath = Server.MapPath(FolderPath + FileName);
            fuImportar.SaveAs(FilePath);
            ds = Util.Import_To_Grid(FilePath, Extension, "Yes");
            for (int i = 0; i <= ds.Rows.Count - 1; i++)
            {
                if (!String.IsNullOrEmpty(ds.Rows[i][0].ToString()))
                {
                    ContenedorEL objContenedor = new ContenedorEL();
                    objContenedor.id = id;
                    objContenedor.contenedor = ds.Rows[i][0].ToString();
                    objContenedor.tipo = ds.Rows[i][1].ToString();
                    objContenedor.vacio = ds.Rows[i][2].ToString();
                    if (ContenedorA.Count > 0)
                    {
                        if (ContenedorA.Contains(objContenedor.contenedor))
                        {
                            mensaje = "No se debe repetir";
                        }
                        else
                        {

                            CantContenedores++;
                            List<TransaccionEL> lst2 = oContenedorBL.RegistarContenedor(objContenedor);
                            ContenedorA.Add(objContenedor.contenedor);
                            mensaje = "Se registro Correctamente la nave de embarque: " + txtNave.Text + " con " + CantContenedores + " Contenedores";
                        }
                    }
                    else
                    {
                        CantContenedores++;
                        List<TransaccionEL> lst2 = oContenedorBL.RegistarContenedor(objContenedor);
                        ContenedorA.Add(objContenedor.contenedor);
                    }
                }
            }
        }
        if (ContenedorA.Count <= 0)
        {
            EliminarNave(id);
            error = 1;
            mensaje = "No se ha econtrado ningun contenedor para la nave";
        }
    }

    public void ImportarContenedores2()
    {
        DataTable ds = new DataTable();
        ContenedorBL oContenedorBL = new ContenedorBL();
        ArrayList ContenedorA = new ArrayList();
        string FileName = Path.GetFileName(fuImportar2.PostedFile.FileName);
        string Extension = Path.GetExtension(fuImportar2.PostedFile.FileName);
        string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
        extension = Extension;
        if (Extension == ".xls" || Extension == ".xlsx")
        {
            string FilePath = Server.MapPath(FolderPath + FileName);
            fuImportar2.SaveAs(FilePath);
            ds = Util.Import_To_Grid(FilePath, Extension, "Yes");
            for (int i = 0; i <= ds.Rows.Count - 1; i++)
            {
                if (!String.IsNullOrEmpty(ds.Rows[i][1].ToString()))
                {
                    ContenedorEL objContenedor = new ContenedorEL();
                    objContenedor.id = id;
                    objContenedor.contenedor = ds.Rows[i][0].ToString();
                    objContenedor.tipo = ds.Rows[i][1].ToString();
                    objContenedor.vacio = ds.Rows[i][2].ToString();
                    if (ContenedorA.Count > 0)
                    {
                        if (ContenedorA.Contains(objContenedor.contenedor))
                        {
                            mensaje = "No se debe repetir";
                        }
                        else
                        {

                            CantContenedores++;
                            List<TransaccionEL> lst2 = oContenedorBL.RegistarContenedor(objContenedor);
                            ContenedorA.Add(objContenedor.contenedor);
                            mensaje = "Se registro Correctamente los " + CantContenedores + " Contenedores";
                        }
                    }
                    else
                    {
                        CantContenedores++;
                        List<TransaccionEL> lst2 = oContenedorBL.RegistarContenedor(objContenedor);
                        ContenedorA.Add(objContenedor.contenedor);
                    }
                }
            }
        }
    }


    public void ComprobarExcel()
    {
        string Extension = Path.GetExtension(fuImportar.PostedFile.FileName);
        extension = Extension;
    }

    public void ContenedorDescarga()
    {
        ArrayList ContenedorA = new ArrayList();
        DataTable ds = new DataTable();
        ContenedorBL oContenedorBL = new ContenedorBL();
        NaveEL objNave = new NaveEL();
        objNave.anio_manifiesto = txtAmanifiesto.Text;
        string mani = "";
        mani = txtNmanifiesto.Text;
        if (txtNmanifiesto.Text.Length < 4)
        {
            
            for (int i = mani.Length; i <4 ; i++)
            {
                mani = "0"+mani;
            }
        }
        

        objNave.nro_manifiesto = mani;
        List<ContenedorEL> lst = oContenedorBL.ContenedoresDescarga(objNave);

        for (int i = 0; i < lst.Count; i++)
        {
            ContenedorEL oContenedoEl = new ContenedorEL();
            oContenedoEl.id = id;
            oContenedoEl.contenedor = lst[i].CONTENEDOR;
            oContenedoEl.tipo = lst[i].TIPO_CTN;
            oContenedoEl.vacio = "";
            if (ContenedorA.Count > 0)
            {
                if (ContenedorA.Contains(oContenedoEl.contenedor))
                {
                    mensaje = "No se debe repetir";
                }
                else
                {

                    CantContenedores++;
                    List<TransaccionEL> lst2 = oContenedorBL.RegistarContenedor(oContenedoEl);
                    ContenedorA.Add(oContenedoEl.contenedor);
                    mensaje = "Se registro Correctamente la nave de embarque: " + txtNave.Text + " con " + CantContenedores + " Contenedores";
                }
            }
            else
            {
                CantContenedores++;
                List<TransaccionEL> lst2 = oContenedorBL.RegistarContenedor(oContenedoEl);
                ContenedorA.Add(oContenedoEl.contenedor);
            }

        }

    }

    public void ContenedorDescargaRefrescar()
    {
        ArrayList ContenedorA = new ArrayList();
        DataTable ds = new DataTable();
        ContenedorBL oContenedorBL = new ContenedorBL();
        ContenedorEL oContenedorEL = new ContenedorEL();
        NaveBL oNaveBL = new NaveBL();
        NaveEL objNave = new NaveEL();
        objNave.id = Convert.ToInt32(txtCodNave.Text);
        List<NaveEL> lstNave = oNaveBL.ConsultarNave(objNave);
        objNave.anio_manifiesto = lstNave[0].anio_manifiesto;
        objNave.nro_manifiesto = lstNave[0].nro_manifiesto;
        List<ContenedorEL> lst = oContenedorBL.ContenedoresDescarga(objNave); //<----Nuevos Contenedores
        oContenedorEL.id = Convert.ToInt32(txtCodNave.Text);
        List<ContenedorEL> lstContenedor = oContenedorBL.ListarContenedor(oContenedorEL); //<------Contenedores ya registrados


        if (lstContenedor.Count>0)
        {
            for (int i = 0; i < lstContenedor.Count; i++)
            {
                ContenedorA.Add(lstContenedor[i].contenedor);
            }
        }
        
        for (int i = 0; i < lst.Count; i++)
        {
            ContenedorEL oContenedoEl = new ContenedorEL();
            oContenedoEl.id = id;
            oContenedoEl.contenedor = lst[i].CONTENEDOR;
            oContenedoEl.tipo = lst[i].TIPO_CTN;
            oContenedoEl.vacio = "";
            if (ContenedorA.Count > 0)
            {
                if (ContenedorA.Contains(oContenedoEl.contenedor))
                {
                    mensaje = "No se debe repetir";
                }
                else
                {
                    CantContenedores++;
                    List<TransaccionEL> lst2 = oContenedorBL.RegistarContenedor(oContenedoEl);
                    ContenedorA.Add(oContenedoEl.contenedor);
                    mensaje = "Se registro Correctamente la nave de embarque: " + txtNave.Text + " con " + CantContenedores + " Contenedores";
                }
            }
            else
            {
                CantContenedores++;
                List<TransaccionEL> lst2 = oContenedorBL.RegistarContenedor(oContenedoEl);
                ContenedorA.Add(oContenedoEl.contenedor);
            }

        }

    }

    protected void btnImportar_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlOperacion.SelectedItem.Text.Equals("Embarque"))
            {
                DateTime d;
                DateTime fecha;
                //ComprobarExcel();
                string extension = Path.GetExtension(fuImportar.PostedFile.FileName);
                if (txtNave.Text.Length > 1)
                {
                    if (fuImportar.HasFile == true)
                    {
                        if (extension == ".xls" || extension == ".xlsx")
                        {
                            if (txtFecha.Text.Length == 0)
                            {
                                fecha = System.DateTime.Now;

                                registrarNave(fecha);
                                ImportarContenedores();
                            }
                            else
                            {
                                if (txtHora.Text.Length == 0)
                                {
                                    fecha = Convert.ToDateTime(txtFecha.Text + ' ' + System.DateTime.Now.Hour + ':' + System.DateTime.Now.Minute);
                                    registrarNave(fecha);
                                    ImportarContenedores();


                                }
                                else
                                {

                                    fecha = Convert.ToDateTime(txtFecha.Text + ' ' + txtHora.Text);
                                    registrarNave(fecha);
                                    ImportarContenedores();
                                }
                            }
                        }
                        else
                        {
                            mensaje = "Debe Selecionar un archivo excel";
                            error = 1;
                        }
                    }
                    else
                    {
                        mensaje = "Debe seleccionar un archivo excel";
                        error = 1;
                    }
                }
                else
                {
                    mensaje = "Debe ingresar el nombre de la nave";
                    error = 1;
                }
            }
            else
            {

                if (registrarNaveDescarga() == 1)
                {
                    ContenedorDescarga();
                }
            }

    }
        catch (Exception ex)
        {
            mensaje = ex.Message.ToString();
            lblMensaje.Text = mensaje;
        }
        MostrarMensaje();
        ListarNaveContenedor();
        Limpiar();
    }

    public void MostrarMensaje()
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

    public void loadItems(DropDownList ddl, string id_catalogo)
    {
        ItemBL oItem = new ItemBL();
        ddl.DataSource = oItem.ListarItemOpe(id_catalogo);
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
    }
    public void CargarEstado()
    {
        ddlEstadoNave.Items.Clear();
        ddlEstadoNave.Items.Add("--TODOS--");
        ddlEstadoNave.Items[0].Value = "2";
        ddlEstadoNave.Items.Add("PENDIENTE");
        ddlEstadoNave.Items[1].Value = "0";
        ddlEstadoNave.Items.Add("FINALIZADO");
        ddlEstadoNave.Items[2].Value = "1";
        ddlEstadoNave.SelectedIndex = 1;
    }

    public void llenarPuerto()
    {
        ddlPuerto.Items.Clear();
        ddlPuerto.Items.Add("DPW");
        ddlPuerto.Items.Add("APM");
    }
    public void llenarOperacion()
    {
        ddlOperacion.Items.Clear();
        ddlOperacion.Items.Add("Embarque");
        ddlOperacion.Items.Add("Descarga");
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        txtNave.Text = "";
        txtFecha.Text = "";
        txtHora.Text = "";
        txtAmanifiesto.Text = "";
        txtNmanifiesto.Text = "";
        txtAmanifiesto.Text = System.DateTime.Now.Year.ToString();

        if (lblMensaje.Text.Equals("2"))
        {
            lblNave.Text = lblTitulo.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert3').modal('show');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
            Limpiarfecha();
        }


    }

    public void Limpiarfecha()
    {
        txtFecha.Text = "";
    }



    protected void grvNave_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Observar":
                string[] arg = new string[3];
                arg = e.CommandArgument.ToString().Split(';');
                ListarContenedor(Convert.ToInt32(arg[0]));
                txtCodNave.Text = arg[0];
                if (arg[2].Equals("D"))
                    lblTitulo.Text = arg[1] + "  (DESCARGA)";
                else
                    lblTitulo.Text = arg[1] + "  (EMBARQUE)";


                lblMensaje.Text = "2";

                if (grvContenedor.Rows.Count > 0)
                {
                    MultiView1.ActiveViewIndex = 1;
                    break;
                }
                error = 1;
                mensaje = "No se ha registrado contenedores para esta nave";
                MostrarMensaje();
                break;
            case "Modificar":
                string[] arg2 = new string[6];
                arg2 = e.CommandArgument.ToString().Split(';');
                txtID.Text = arg2[0];
                lblANave.Text = arg2[1];
                txtANave.Text = arg2[1];
                txtAFecha.Text = arg2[3];
                txtAFechaInicio.Text = arg2[4];
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert4').modal('show');", true);
                break;
            case "eliminar":
                if (ConsultarNaveSeguimiento(Convert.ToInt32(e.CommandArgument.ToString())) == 0)
                {
                    txtID.Text = e.CommandArgument.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert5').modal('show');", true);
                    break;
                }
                else
                {
                    error = 1;
                    mensaje = "La nave ya a comenzado el seguimiento";
                    MostrarMensaje();
                    break;
                }
        }
    }
    public void ListarContenedor(int id)
    {
        ContenedorBL oContenedorBL = new ContenedorBL();
        ContenedorEL oContenedorEL = new ContenedorEL();
        oContenedorEL.id = id;
        List<ContenedorEL> lst = oContenedorBL.ListarContenedor(oContenedorEL);
        grvContenedor.DataSource = lst;
        grvContenedor.DataBind();
    }

    protected void grvNave_PreRender(object sender, EventArgs e)
    {
        if (grvNave.Rows.Count > 0)
        {
            grvNave.UseAccessibleHeader = true;
            grvNave.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvNave.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void grvContenedor_PreRender(object sender, EventArgs e)
    {
        if (grvContenedor.Rows.Count > 0)
        {
            grvContenedor.UseAccessibleHeader = true;
            grvContenedor.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvContenedor.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }



    protected void grvNave_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblFinalizado = (Label)e.Row.FindControl("lblFinalizado");
            Label lbloperacion = (Label)e.Row.FindControl("lbloperacion");

            if (lblFinalizado.Text == "1")
            {
                lblFinalizado.Text = "FINALIZADO";
                lblFinalizado.CssClass = "label label-icon waves-effect waves-light btn-teal m-b-5";
            }
            else
            {
                lblFinalizado.Text = "PENDIENTE";
                lblFinalizado.CssClass = "label label-icon waves-effect waves-light btn-danger m-b-5";
            }

            if (lbloperacion.Text.Equals("D"))
            {
                lbloperacion.Text = "DESCARGA";
                lbloperacion.CssClass = "label label-icon waves-effect waves-light btn-brown m-b-5";
            }
            else
            {
                lbloperacion.Text = "EMBARQUE";
                lbloperacion.CssClass = "label label-icon waves-effect waves-light btn-primary m-b-5";
            }
        }
    }



    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        ListarNaveContenedor();
        MultiView1.ActiveViewIndex = 0;
        lblTitulo.Text = "";
        lblMensaje.Text = "";
    }

    protected void grvContenedor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblEstado = (Label)e.Row.FindControl("lblEstado");
            Label lblVacio = (Label)e.Row.FindControl("lblVacio");
            Label lblPLaca = (Label)e.Row.FindControl("lblPlaca");
            Label lblConductor = (Label)e.Row.FindControl("lblConductor");
            if (lblEstado.Text == "1")
            {
                lblEstado.Text = "FINALIZADO";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-teal m-b-5";
            }
            else
            {
                lblEstado.Text = "PENDIENTE";
                lblEstado.CssClass = "label label-icon waves-effect waves-light btn-danger m-b-5";
            }
            if (lblVacio.Text.Length == 0)
            {
                lblVacio.Text = "";
            }
            else
            {
                lblVacio.Text = "VACIO";
                lblVacio.CssClass = "label label-icon waves-effect waves-light btn-teal m-b-5";
            }
        }
    }

    protected void btnAgregarContenedor_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(txtCodNave.Text);

        if (ckhexcel.Checked)
        {
            ImportarContenedores2();
            ListarContenedor(id);
            MostrarMensaje();
            txtContenedor.Text = "";
            txtTipo.Text = "";
        }
        else
        {
            RegistrarContenedor();
            ListarContenedor(id);
            MostrarMensaje();
            txtContenedor.Text = "";
            txtTipo.Text = "";
        }
    }

    protected void grvContenedor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "eliminar":

                if (ConsultarSeguimiento(Convert.ToInt32(txtCodNave.Text), Convert.ToInt32(e.CommandArgument.ToString())) == 0)
                {
                    txtid_cnt.Text = e.CommandArgument.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert6').modal('show');", true);
                    break;
                }
                else
                {
                    error = 1;
                    mensaje = "El contenedor ya cuenta con seguimiento";
                    MostrarMensaje();
                    break;
                }
            case "asignar":
                LimpiarHoraSeguimiento();
                string[] arg = new string[6];
                arg = e.CommandArgument.ToString().Split(';');
                txtUnidad.Text = "";
                txtContenedor_id.Text = arg[0].ToString();
                hfidSeg.Value= arg[5].ToString(); 
                NombreContenedor.Text = "Registro de seguimiento (" + arg[1] + ")";
                if (arg[2].Length > 0)
                {
                    chkVacio.Checked = true;
                }
                else
                {

                    chkVacio.Checked = false;

                }

                if (arg[3].ToString().Equals("Sin asignar"))
                {
                    txtConductor.Text = "";
                }
                else
                {
                    txtConductor.Text = arg[3].ToString();
                }
                txtDia01.Text = System.DateTime.Now.ToShortDateString();
                txtDia02.Text = System.DateTime.Now.ToShortDateString();
                txtDia03.Text = System.DateTime.Now.ToShortDateString();
                txtDia04.Text = System.DateTime.Now.ToShortDateString();
                txtDia05.Text = System.DateTime.Now.ToShortDateString();
                txtDia06.Text = System.DateTime.Now.ToShortDateString();

                //txtPlaca.Text = arg[4].ToString();
                SeguimientoBL oSeguimientoBL = new SeguimientoBL();
                SeguimientoEL oSeguimientoEL = new SeguimientoEL();
                oSeguimientoEL.id_nave = Convert.ToInt32(txtCodNave.Text);
                oSeguimientoEL.id_cnt = Convert.ToInt32(txtContenedor_id.Text);
                List<SeguimientoEL> lst = oSeguimientoBL.ListarSeguimiento(oSeguimientoEL);
                lblContenedor.Text = "0";
                if (lst.Count > 0)
                {
                    txtUnidad_id.Text = lst[0].cod_unidad.ToString();
                    txtUnidad.Text = lst[0].cod_interno.ToString();
                    txtConductor_id.Text = lst[0].cod_conductor.ToString();
                    if (lst[0].fch_T1_llegada2.ToString().Equals(""))
                    {
                        
                        txtFch1.Text = "";
                    }
                    else
                    {
                        txtDia01.Text= lst[0].fch_T1_llegada2.ToString().Substring(0, 10);
                        txtFch1.Text = lst[0].fch_T1_llegada2.ToString().Substring(11, 5);
                    }
                    if (lst[0].fch_T2_ingreso2.ToString().Equals(""))
                    {
                        
                        txtFch2.Text = "";
                    }
                    else
                    {
                        txtDia02.Text= lst[0].fch_T2_ingreso2.ToString().Substring(0, 10);
                        txtFch2.Text = lst[0].fch_T2_ingreso2.ToString().Substring(11, 5);
                    }
                    if (lst[0].fch_T3_salida2.ToString().Equals(""))
                    {
                      
                        txtFch3.Text = "";

                    }
                    else
                    {
                        txtDia03.Text = lst[0].fch_T3_salida2.ToString().Substring(0, 10);
                        txtFch3.Text = lst[0].fch_T3_salida2.ToString().Substring(11, 5);
                    }
                    if (lst[0].fch_T4_llegada2.ToString().Equals(""))
                    {
                       
                        txtFch4.Text = "";
                    }
                    else
                    {
                        txtDia04.Text = lst[0].fch_T4_llegada2.ToString().Substring(0, 10);
                        txtFch4.Text = lst[0].fch_T4_llegada2.ToString().Substring(11, 5);
                    }
                    if (lst[0].fch_T5_ingreso2.ToString().Equals(""))
                    {
                       
                        txtFch5.Text = "";
                    }
                    else
                    {
                        txtDia05.Text= lst[0].fch_T5_ingreso2.ToString().Substring(0, 10);
                        txtFch5.Text = lst[0].fch_T5_ingreso2.ToString().Substring(11, 5);
                    }
                    if (lst[0].fch_T6_salida2.ToString().Equals(""))
                    {
                       
                        txtFch6.Text = "";
                    }
                    else
                    {
                        txtDia06.Text= lst[0].fch_T6_salida2.ToString().Substring(0, 10);
                        txtFch6.Text = lst[0].fch_T6_salida2.ToString().Substring(11, 5);
                    }
                    
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlertAdd').modal('show');", true);
                break;
        }
    }

    public void EliminarContenedor()
    {
        ContenedorBL oContenedorBL = new ContenedorBL();
        ContenedorEL objContenedor = new ContenedorEL();
        objContenedor.id_cnt = Convert.ToInt32(txtid_cnt.Text);
        List<ContenedorEL> lst2 = oContenedorBL.EliminarContenedor(objContenedor);
        ListarContenedor(Convert.ToInt32(txtCodNave.Text));
        error = 0;
        mensaje = "Se elimino el contenedor correctamente";
        MostrarMensaje();
    }

    public void EliminarContenedorSeleccionado(int id)
    {
        ContenedorBL oContenedorBL = new ContenedorBL();
        ContenedorEL objContenedor = new ContenedorEL();
        objContenedor.id_cnt = Convert.ToInt32(id);
        List<ContenedorEL> lst2 = oContenedorBL.EliminarContenedor(objContenedor);
        error = 0;
        mensaje = "Se elimino el contenedor correctamente";
        MostrarMensaje();
    }

    protected void btnActualizarNave_Click(object sender, EventArgs e)
    {
        ActualizarNave();
        ListarNaveContenedor();
    }

    public void ActualizarNave()
    {
        try
        {
            if (txtANave.Text.Length > 0)
            {
                NaveBL oNaveBL = new NaveBL();
                NaveEL objNave = new NaveEL();
                objNave.nave = txtANave.Text;
                objNave.fecha_termino = Convert.ToDateTime(txtAFecha.Text);
                objNave.fecha_registro = Convert.ToDateTime(txtAFechaInicio.Text);
                objNave.id = Convert.ToInt32(txtID.Text);
                List<NaveEL> lst2 = oNaveBL.ActualizarNave(objNave);
                error = 0;
                mensaje = "Se actualizo la nave correctamente";
                MostrarMensaje();
            }
            else
            {
                error = 1;
                mensaje = "Debe ingresar un nombre de nave";
                MostrarMensaje();
            }
        }
        catch
        {
            error = 1;
            mensaje = "Inserte los datos correctamente";
            MostrarMensaje();
        }
    }

    protected void ddlOperacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOperacion.SelectedIndex == 0)
        {
            PanelEmbarque.Visible = true;
            PanelDescarga.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
        }
        else
        {
            PanelEmbarque.Visible = false;
            PanelDescarga.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
        }


    }


    public void EliminarNave(int idNave)
    {
        NaveBL oNaverBL = new NaveBL();
        NaveEL objNave = new NaveEL();
        objNave.id = idNave;
        List<NaveEL> lst2 = oNaverBL.EliminarNave(objNave);
        error = 0;
        mensaje = "Se elimino la Nave correctamente";
        ListarNaveContenedor();
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        EliminarNave(Convert.ToInt32(txtID.Text));
        MostrarMensaje();
    }

    protected void btnEliminarCNT_Click(object sender, EventArgs e)
    {
        EliminarContenedor();
    }

    protected void ckhexcel_CheckedChanged(object sender, EventArgs e)
    {
        if (fuImportar2.Visible == true)
        {
            fuImportar2.Visible = false;
        }
        else if (fuImportar2.Visible == false)
        {
            fuImportar2.Visible = true;
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert3').modal('show');", true);
    }

    public void RegistrarSeguimiento()
    {
        if (txtUnidad_id.Text.Length == 0)
        {
            error = 1;
            mensaje = "Debe seleccionar una unidad";
            MostrarMensaje();
        }
        else
        {
            SeguimientoBL oSeguimientoBL = new SeguimientoBL();
            SeguimientoEL oSeguimientoEL = new SeguimientoEL();
            oSeguimientoEL.id_nave = Convert.ToInt32(txtCodNave.Text);
            oSeguimientoEL.id_cnt = Convert.ToInt32(txtContenedor_id.Text);
            oSeguimientoEL.cod_unidad = Convert.ToInt32(txtUnidad_id.Text);
            oSeguimientoEL.cod_interno = txtUnidad.Text;



            oSeguimientoEL.cod_conductor = Convert.ToInt32(txtConductor_id.Text);
            if (txtFch1.Text.Length != 0)
                oSeguimientoEL.fch_T1_llegada = Convert.ToDateTime(txtDia01.Text + " " + txtFch1.Text);
            else
                oSeguimientoEL.fch_T1_llegada = Convert.ToDateTime("1900-01-01 00:00:00.000");

            if (txtFch2.Text.Length != 0)
                oSeguimientoEL.fch_T2_ingreso = Convert.ToDateTime(txtDia02.Text + " " + txtFch2.Text);
            else
                oSeguimientoEL.fch_T2_ingreso = Convert.ToDateTime("1900-01-01 00:00:00.000");

            if (txtFch3.Text.Length != 0)
                oSeguimientoEL.fch_T3_salida = Convert.ToDateTime(txtDia03.Text + " " + txtFch3.Text);
            else
                oSeguimientoEL.fch_T3_salida = Convert.ToDateTime("1900-01-01 00:00:00.000");

            if (txtFch4.Text.Length != 0)
                oSeguimientoEL.fch_T4_llegada = Convert.ToDateTime(txtDia04.Text + " " + txtFch4.Text);
            else
                oSeguimientoEL.fch_T4_llegada = Convert.ToDateTime("1900-01-01 00:00:00.000");

            if (txtFch5.Text.Length != 0)
                oSeguimientoEL.fch_T5_ingreso = Convert.ToDateTime(txtDia05.Text + " " + txtFch5.Text);
            else
                oSeguimientoEL.fch_T5_ingreso = Convert.ToDateTime("1900-01-01 00:00:00.000");

            if (txtFch6.Text.Length != 0)
                oSeguimientoEL.fch_T6_salida = Convert.ToDateTime(txtDia06.Text + " " + txtFch6.Text);
            else
                oSeguimientoEL.fch_T6_salida = Convert.ToDateTime("1900-01-01 00:00:00.000");
            oSeguimientoBL.RegistrarSeguimiento(oSeguimientoEL,hfNomUser.Value);
        }
    }
    public void RegistrarSeguimiento2()
    {
        SeguimientoBL oSeguimientoBL = new SeguimientoBL();
        SeguimientoEL oSeguimientoEL = new SeguimientoEL();
        oSeguimientoEL.id_nave = Convert.ToInt32(txtCodNave.Text);
        oSeguimientoEL.id_cnt = Convert.ToInt32(txtContenedor_id.Text);
        oSeguimientoEL.cod_unidad = 0;
        oSeguimientoEL.cod_interno = "";
        oSeguimientoEL.cod_conductor = 0;
        if (txtFch1.Text.Length != 0)
            oSeguimientoEL.fch_T1_llegada = Convert.ToDateTime(txtDia01.Text + " " + txtFch1.Text);
        else
            oSeguimientoEL.fch_T1_llegada = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch2.Text.Length != 0)
            oSeguimientoEL.fch_T2_ingreso = Convert.ToDateTime(txtDia02.Text + " " + txtFch2.Text);
        else
            oSeguimientoEL.fch_T2_ingreso = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch3.Text.Length != 0)
            oSeguimientoEL.fch_T3_salida = Convert.ToDateTime(txtDia03.Text + " " + txtFch3.Text);
        else
            oSeguimientoEL.fch_T3_salida = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch4.Text.Length != 0)
            oSeguimientoEL.fch_T4_llegada = Convert.ToDateTime(txtDia04.Text + " " + txtFch4.Text);
        else
            oSeguimientoEL.fch_T4_llegada = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch5.Text.Length != 0)
            oSeguimientoEL.fch_T5_ingreso = Convert.ToDateTime(txtDia05.Text + " " + txtFch5.Text);
        else
            oSeguimientoEL.fch_T5_ingreso = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch6.Text.Length != 0)
            oSeguimientoEL.fch_T6_salida = Convert.ToDateTime(txtDia06.Text + " " + txtFch6.Text);
        else
            oSeguimientoEL.fch_T6_salida = Convert.ToDateTime("1900-01-01 00:00:00.000");
        oSeguimientoBL.RegistrarSeguimiento(oSeguimientoEL,hfNomUser.Value);

    }

    public string VerificarConductor()
    {
        string rspt = "";
        NombradaBL oNombradaBL = new NombradaBL();
        NombradaEL oNombradaEL = new NombradaEL();
        oNombradaEL.NombreCompleto = txtConductor.Text;
        List<NombradaEL> lst2 = oNombradaBL.VerificarConductor(oNombradaEL);
        rspt = lst2[0].tipo;
        return rspt;
    }

    public string VerificarUnidad()
    {
        string rspt = "";
        NombradaBL oNombradaBL = new NombradaBL();
        NombradaEL oNombradaEL = new NombradaEL();
        oNombradaEL.cod_interno = txtUnidad.Text;
        oNombradaEL.cod_id = Convert.ToInt32(txtUnidad_id.Text);
        List<NombradaEL> lst2 = oNombradaBL.VerificarUnidad(oNombradaEL);
        rspt = lst2[0].tipo;
        return rspt;
    }

    public string ComprobarAsignacion()
    {
        string resultado;

        if (VerificarConductor().Equals("P"))
        {
            if (VerificarUnidad().Equals("P"))
            {
                resultado = "V";
            }
            else
            {
                resultado = "F";
            }
        }
        else
        {
            if (VerificarUnidad().Equals("T"))
            {
                resultado = "V";
            }
            else
            {
                resultado = "F";
            }
        }


        return resultado;
    }





    public void ActualizarSeguimiento()
    {

        SeguimientoBL oSeguimientoBL = new SeguimientoBL();
        SeguimientoEL oSeguimientoEL = new SeguimientoEL();
        oSeguimientoEL.id_seg = Convert.ToInt32(hfidSeg.Value);
        oSeguimientoEL.cod_unidad = Convert.ToInt32(txtUnidad_id.Text);
        oSeguimientoEL.cod_interno = txtUnidad.Text;
        oSeguimientoEL.cod_conductor = Convert.ToInt32(txtConductor_id.Text);

        if (txtFch1.Text.Length != 0)
            oSeguimientoEL.fch_T1_llegada = Convert.ToDateTime(txtDia01.Text + " " + txtFch1.Text);
        else
            oSeguimientoEL.fch_T1_llegada = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch2.Text.Length != 0)
            oSeguimientoEL.fch_T2_ingreso = Convert.ToDateTime(txtDia02.Text + " " + txtFch2.Text);
        else
            oSeguimientoEL.fch_T2_ingreso = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch3.Text.Length != 0)
            oSeguimientoEL.fch_T3_salida = Convert.ToDateTime(txtDia03.Text + " " + txtFch3.Text);
        else
            oSeguimientoEL.fch_T3_salida = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch4.Text.Length != 0)
            oSeguimientoEL.fch_T4_llegada = Convert.ToDateTime(txtDia04.Text + " " + txtFch4.Text);
        else
            oSeguimientoEL.fch_T4_llegada = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch5.Text.Length != 0)
            oSeguimientoEL.fch_T5_ingreso = Convert.ToDateTime(txtDia05.Text + " " + txtFch5.Text);
        else
            oSeguimientoEL.fch_T5_ingreso = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch6.Text.Length != 0)
            oSeguimientoEL.fch_T6_salida = Convert.ToDateTime(txtDia06.Text + " " + txtFch6.Text);
        else
            oSeguimientoEL.fch_T6_salida = Convert.ToDateTime("1900-01-01 00:00:00.000");

        oSeguimientoBL.ActualizarSeguimiento(oSeguimientoEL, hfNomUser.Value);


    }

    public void ActualizarSeguimiento2()
    {

        SeguimientoBL oSeguimientoBL = new SeguimientoBL();
        SeguimientoEL oSeguimientoEL = new SeguimientoEL();
        oSeguimientoEL.id_seg = Convert.ToInt32(hfidSeg.Value);
        oSeguimientoEL.cod_unidad = 0;
        oSeguimientoEL.cod_interno = "";
        oSeguimientoEL.cod_conductor = 0;
        if (txtFch1.Text.Length != 0)
            oSeguimientoEL.fch_T1_llegada = Convert.ToDateTime(System.DateTime.Now.ToShortDateString() + " " + txtFch1.Text);
        else
            oSeguimientoEL.fch_T1_llegada = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch2.Text.Length != 0)
            oSeguimientoEL.fch_T2_ingreso = Convert.ToDateTime(System.DateTime.Now.ToShortDateString() + " " + txtFch2.Text);
        else
            oSeguimientoEL.fch_T2_ingreso = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch3.Text.Length != 0)
            oSeguimientoEL.fch_T3_salida = Convert.ToDateTime(System.DateTime.Now.ToShortDateString() + " " + txtFch3.Text);
        else
            oSeguimientoEL.fch_T3_salida = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch4.Text.Length != 0)
            oSeguimientoEL.fch_T4_llegada = Convert.ToDateTime(System.DateTime.Now.ToShortDateString() + " " + txtFch4.Text);
        else
            oSeguimientoEL.fch_T4_llegada = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch5.Text.Length != 0)
            oSeguimientoEL.fch_T5_ingreso = Convert.ToDateTime(System.DateTime.Now.ToShortDateString() + " " + txtFch5.Text);
        else
            oSeguimientoEL.fch_T5_ingreso = Convert.ToDateTime("1900-01-01 00:00:00.000");

        if (txtFch6.Text.Length != 0)
            oSeguimientoEL.fch_T6_salida = Convert.ToDateTime(System.DateTime.Now.ToShortDateString() + " " + txtFch6.Text);
        else
            oSeguimientoEL.fch_T6_salida = Convert.ToDateTime("1900-01-01 00:00:00.000");

        oSeguimientoBL.ActualizarSeguimiento(oSeguimientoEL, hfNomUser.Value);


    }

    public void HabilitarHoraSeguimiento()
    {
        txtFch1.Enabled = true;
        txtFch2.Enabled = true;
        txtFch3.Enabled = true;
        txtFch4.Enabled = true;
        txtFch5.Enabled = true;
        txtFch6.Enabled = true;
    }

    public void LimpiarHoraSeguimiento()
    {
        txtFch1.Text = "";
        txtFch2.Text = "";
        txtFch3.Text = "";
        txtFch4.Text = "";
        txtFch5.Text = "";
        txtFch6.Text = "";
    }

    public void DeshabilitarHoraSeguimiento()
    {
        txtFch1.Enabled = false;
        txtFch2.Enabled = false;
        txtFch3.Enabled = false;
        txtFch4.Enabled = false;
        txtFch5.Enabled = false;
        txtFch6.Enabled = false;
    }

    protected void btnAsignar_Click(object sender, EventArgs e)
    {

        try
        {
            if (hfidSeg.Value.Equals("0"))
            {

                if (txtUnidad.Text.Equals(""))
                {
                    if (txtConductor.Text.Equals(""))
                    {
                        RegistrarSeguimiento2();
                        error = 0;
                        mensaje = "Se ingreso seguimiento al contenedor sin Asignar Unidad";
                    }
                }

                if (ComprobarAsignacion().Equals("V"))
                {
                    RegistrarSeguimiento();
                    error = 0;
                    mensaje = "Se actualizo correctamente";
                }
                else
                {
                    error = 1;
                    mensaje = "Debe hacer una asignacion correcta";
                }
                lblContenedor.Text = "0";

            }
            else
            {
                if (txtUnidad.Text.Equals(""))
                {
                    if (txtConductor.Text.Equals(""))
                    {

                        SeguimientoBL oSeguimientoBL = new SeguimientoBL();
                        SeguimientoEL oSeguimientoEL = new SeguimientoEL();
                        oSeguimientoEL.id_nave = Convert.ToInt32(txtCodNave.Text);
                        oSeguimientoEL.id_cnt = Convert.ToInt32(txtContenedor_id.Text);
                        List<SeguimientoEL> lst = oSeguimientoBL.ListarSeguimiento(oSeguimientoEL);
                        ActualizarSeguimiento2();
                        lblContenedor.Text = "0";
                        error = 0;
                        mensaje = "Se actualizo correctamente";
                    }
                }
                else
                {

                    ActualizarSeguimiento();
                    lblContenedor.Text = "0";
                    error = 0;
                    mensaje = "Se actualizo correctamente";
                }
            }

            ContenedorBL oContenedorBL = new ContenedorBL();
            ContenedorEL oContenedorEL = new ContenedorEL();
            oContenedorEL.id_cnt = Convert.ToInt32(txtContenedor_id.Text);
            if (chkVacio.Checked)
            {
                oContenedorEL.vacio = "x";
            }
            else
            {
                oContenedorEL.vacio = "";
            }
            oContenedorBL.ActualizarContenedor(oContenedorEL);
            ListarContenedor(Convert.ToInt32(txtCodNave.Text));
            MostrarMensaje();
        }
        catch (Exception E)
        {
            error = 1;
            mensaje = E.Message;
            MostrarMensaje();
        }



    }

    public void SeleccionarUnidad()
    {
        NombradaBL oNombradaBL = new NombradaBL();
        NombradaEL oNombradaEL = new NombradaEL();
        oNombradaEL.id_unidad = Convert.ToInt32(txtUnidad_id.Text);
        List<NombradaEL> lst = oNombradaBL.SeleccionarUnidad(oNombradaEL);
        txtConductor.Text = lst[0].NombreCompleto;
        //txtPlaca.Text = lst[0].nro_placa;
    }



    protected void txtUnidad_id_TextChanged(object sender, EventArgs e)
    {
        if (txtUnidad_id.Text.Length == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlertAdd').modal('show');", true);
        }
        else
        {
            SeleccionarUnidad();
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlertAdd').modal('show');", true);
        }
    }


    protected void btnExportar_Click(object sender, EventArgs e)
    {
        if (lblMensaje.Text.Equals("2"))
        {
            ExportarContenedor(Convert.ToInt32(txtCodNave.Text));
        }
        else
        {
            txtfchBegin.Text = "";
            txtfchEnd.Text = "";
            pnl1.Visible = false;
            ddlExportar.SelectedIndex = 0;
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlertexpo').modal('show');", true);
        }

    }

    public void ExportarNave() {
        NaveBL naveBL = new NaveBL();

        var GridView1 = new GridView();

        GridView1.DataSource = naveBL.ListarContenedorNaveExportar();
        GridView1.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attacNhment;filename=ReporteNaves_" + DateTime.Now.ToString("ddMMyyyy") + ".xls");
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

    public void ExportarContenedor(int id)
    {
        ContenedorBL contenedorBL = new ContenedorBL();
        ContenedorEL contenedorEL = new ContenedorEL();
        contenedorEL.id = id;
        var GridView1 = new GridView();

        GridView1.DataSource = contenedorBL.ListarContenedorExportar(contenedorEL);
        GridView1.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attacNhment;filename=ReporteContenedor_" + lblTitulo.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".xls");
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


    public void ExportarContenedorxFecha(string fchBegin, string fchEnd)
    {
        ContenedorBL contenedorBL = new ContenedorBL();
        ContenedorExportaEL contenedorEL = new ContenedorExportaEL();
        contenedorEL.fch_T1_llegada = fchBegin;
        contenedorEL.fch_T2_ingreso = fchEnd;
        var GridView1 = new GridView();

        GridView1.DataSource = contenedorBL.ListarContenedorExportarxFecha(contenedorEL);
        GridView1.DataBind();
        if (GridView1.Rows.Count > 0)
        {
            Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attacNhment;filename=ReporteContenedorxFechas_" + fchBegin + "-" + fchEnd + "_" + DateTime.Now.ToString("ddMMyyyy") + ".xls");
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
            error = 1;
            mensaje = "No se encontro servicios en el rango de fecha seleccionado";
        }
    }

   

    protected void mostrarfechas(object sender, EventArgs e)
    {
        pnl1.Visible = false;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlertexpo').modal('show');", true);
    }

    protected void ddlExportar_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlExportar.SelectedItem.Text.Equals("NAVES"))
        {
            pnl1.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlertexpo').modal('show');", true);
        }
        else
        {
            pnl1.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlertexpo').modal('show');", true);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlExportar.SelectedItem.Text.Equals("NAVES"))
            {
                ExportarNave();
            }
            else
            {
                if (!txtfchBegin.Text.Equals("") && !txtfchEnd.Text.Equals(""))
                {
                        ExportarContenedorxFecha(txtfchBegin.Text, txtfchEnd.Text);
                }
                else
                {
                    mensaje = "Se deben llenar todos los campos";
                    error = 1;
                }
            }
        }
        catch (Exception ex)
        {
            error = 1;
            mensaje = "El rango de fechas seleccionado no contiene contenedores";
        }
        MostrarMensaje();
    }

    protected void btnLiberar_Click(object sender, EventArgs e)
    {

        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#EliminarSeguimiento').modal('show');", true);
        

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (hfidSeg.Value.Equals("0"))
            {
                mensaje = "El contenedor no cuenta con seguimiento";
                error = 1;
                MostrarMensaje();
            }
            else
            {

                SeguimientoBL oSeguimiento = new SeguimientoBL();
                SeguimientoEL objSeguimiento = new SeguimientoEL();
                objSeguimiento.id_seg = Convert.ToInt32(hfidSeg.Value);
                oSeguimiento.EliminarSeguimiento(objSeguimiento);
                ListarContenedor(Convert.ToInt32(txtCodNave.Text));
                mensaje = "Se libero el seguimiento";
                error = 0;
                MostrarMensaje();
            }
        }
        catch (Exception ex) { }
    }

    protected void btnRefrescar_Click(object sender, EventArgs e)
    {
        ContenedorDescargaRefrescar();
        ListarContenedor(Convert.ToInt32(txtCodNave.Text));
    }

    protected void chkContenedorALL_CheckedChanged(object sender, EventArgs e)
    {
        
          foreach (GridViewRow dtgItem in this.grvContenedor.Rows)
          {
                    CheckBox Sel = ((CheckBox)grvContenedor.Rows[dtgItem.RowIndex].FindControl("chkContenedor"));
                    Sel.Checked = true;

          }
            
        
    }

    protected void btnEliminarAll_Click(object sender, EventArgs e)
    {
        ArrayList ContenedorRegistro = new ArrayList();
        foreach (GridViewRow dtgItem in this.grvContenedor.Rows)
        {
            CheckBox Sel = ((CheckBox)grvContenedor.Rows[dtgItem.RowIndex].FindControl("chkContenedor"));
            string contenedor = grvContenedor.Rows[dtgItem.RowIndex].Cells[3].Text;

            bool valor = Sel.Checked;
            if (valor)
            {
                ContenedorRegistro.Add(contenedor);
            }
        }
        grvContenedor.Columns[2].Visible = true;
        ListarContenedor(Convert.ToInt32(txtCodNave.Text));

        foreach (GridViewRow dtgItem in this.grvContenedor.Rows)
        {
            int id = Convert.ToInt32(grvContenedor.Rows[dtgItem.RowIndex].Cells[2].Text);
            string contenedor = grvContenedor.Rows[dtgItem.RowIndex].Cells[3].Text;

            
           if (ContenedorRegistro.Contains(contenedor))
           {
                EliminarContenedorSeleccionado(id);
           }
                
        }
        grvContenedor.Columns[2].Visible = false;
        ListarContenedor(Convert.ToInt32(txtCodNave.Text));
    }




    protected void ddlEstadoNave_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarNaveContenedor();
    }
}