using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using BL;
using EL;
using DAL;
using System.Web.Security;
using System.Text.RegularExpressions;

public partial class Modulos_Otros_Default : System.Web.UI.Page
{
    int state;
    public int error = 0;
    public CatalogoBL objCatalogo = new CatalogoBL();
    public UbigeoBL objUbigeo = new UbigeoBL();
    public ReposicionBL objReposicion = new ReposicionBL();
    public string mensaje;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Perfil();
            ListarReposicion();
            cargarArea();
            cargarMotivo();
            cargarNombreUsuario();
            cargarPlanEquipo();
            cargarmensaje();

        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        AbrirPopUp("infoModalAlert4");
    }

    protected void gvOtros_PreRender(object sender, EventArgs e)
    {
        if (gvOtros.Rows.Count > 0)
        {
            gvOtros.UseAccessibleHeader = true;
            gvOtros.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvOtros.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void gvOtros_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblEstado1 = (Label)e.Row.FindControl("lblEstado");
            if (Convert.ToInt32(lblEstado1.Text) == 1)
            {
                lblEstado1.Text = "PENDIENTE";
                lblEstado1.CssClass = "btn btn-icon waves-effect waves-light btn-danger w-md m-b-5";
            }
            else if (Convert.ToInt32(lblEstado1.Text) == 2)
            {
                lblEstado1.Text = "ENVIADO";
                lblEstado1.CssClass = "btn btn-icon waves-effect waves-light btn-primary w-md m-b-5";
            }
            else
            {
                lblEstado1.Text = "RECHAZADO";
                lblEstado1.CssClass = "btn btn-icon waves-effect waves-light btn-success w-md m-b-5";
            }

        }

    }

    public void AbrirPopUp(string PopUp)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#" + PopUp + "').modal('show');", true);
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        RegistrarReposicion();
        MostrarMensaje(0, "Registrado Correctamente");
        ListarReposicion();
        Limpiar();
        cargarNombreUsuario();

    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {


    }

    protected void RBadministrativo_CheckedChanged(object sender, EventArgs e)
    {
       
    }

    public void EnviarMail(int c, string a, string b,string d,string mensaje)
    {
        string[] arg = new string[c];
        string[] arg1 = new string[c];
        string[] arg2 = new string[c];

        mensaje = "Estimado Equipo Entel:" +"</br>"+
            "Se solicita la reposición de los siguientes telefonos :";

        arg = a.Split(';');
        arg1 = b.Split(';');
        arg2 = d.Split(';');
        string numeros = "";
        string plan = "";
        string nombre = "";

        for (int i = 0; i <= arg.Length - 1; i++)
        {
            numeros += "<p>" + arg[i] + "</p>";

        }
        for (int x = 0; x <= arg1.Length - 1; x++)
        {
            plan += "<p>" + arg1[x] + "</p>";
        }
        for (int x = 0; x <= arg2.Length - 1; x++)
        {
            nombre += "<p>" + arg2[x] + "</p>";
        }

        VacacionesEmailBL oEmail = new VacacionesEmailBL();
        string from, body, sub, BC;
        from = "angelo.bendezu@tmeridian.com.pe";
        BC = "";
        body = mensaje+"</br>"+"<table border='2'>"+ "<tr style='background-color: #36404e'>" + "<th style='color:#FAF6F6'>" + "Numero Celular"+"</th>"+
                          "<th style='color:#FAF6F6'>" + "Nombre Equipo" +"</th>"+ "<th style='color:#FAF6F6'>" + "Plan Asignado"+"</th>"+"</tr>"
                         +"<tr>"+"<td>"+numeros+"</td>"+"<td>"+nombre+"</td>" + "<td>" + plan + "</td>" + "</tr>"+"</table>"       ;
        sub = "Reposición de Equipo";

            List <VacacionesEmailEL> lst2 = oEmail.EnviarEMail(from, body, sub, BC);
    }

    public void ListarReposicion()
    {

        if (hfusuario.Value.Equals("angelo.bendezu"))
        {
            ReposicionBL oReposicion1 = new ReposicionBL();
            ReposicionEL oReposicionEL = new ReposicionEL();
            //oReposicionEL.cod_reposicion = Convert.ToInt32(hfcod_reposicion.Value);
            List<ReposicionEL> lst1 = oReposicion1.ListarReposicion_ADM();
            GvOtros1.DataSource = lst1;
            GvOtros1.DataBind();
            GvOtros1.Visible = true;
            gvOtros.Visible = false;
        }
        else {

            ReposicionBL oReposicion = new ReposicionBL();
            ReposicionEL oReposicionEL = new ReposicionEL();
            // oReposicionEL.cod_reposicion = int.Parse(hfcod_reposicion.Value);
            oReposicionEL.usuario_registro = hfusuario.Value;
            List<ReposicionEL> lst = oReposicion.ListarReposicion(oReposicionEL);
            gvOtros.DataSource = lst;
            gvOtros.DataBind();
            gvOtros.Visible = true;
            GvOtros1.Visible = false;
            LinkEnviar.Visible = false;
        }

    }

    public void cargarArea()
    {
        this.ddlArea.DataSource = objCatalogo.ListarItem("26");
        ddlArea.DataTextField = "descripcion";
        ddlArea.DataValueField = "id_descripcion";
        ddlArea.DataBind();
        ddlArea.Items.Insert(0, new ListItem("--SELECCIONE TIPO ÁREA--", ""));
    }

    public void cargarAreaOperativa()
    {
        this.ddlArea.DataSource = objCatalogo.ListarItem("36");
        ddlArea.DataTextField = "descripcion";
        ddlArea.DataValueField = "id_descripcion";
        ddlArea.DataBind();
        ddlArea.Items.Insert(0, new ListItem("--SELECCIONE TIPO ÁREA--", ""));
    }




    public void cargarMotivo()
    {
        this.ddlMotivo.DataSource = objCatalogo.ListarItem("34");
        ddlMotivo.DataTextField = "descripcion";
        ddlMotivo.DataValueField = "id_descripcion";
        ddlMotivo.DataBind();
        ddlMotivo.Items.Insert(0, new ListItem("--SELECCIONE MOTIVO--", ""));
    }

    public void RegistrarReposicion()
    {
        ReposicionBL oReposicionBL = new ReposicionBL();
        ReposicionEL oReposicionEL = new ReposicionEL();

        oReposicionEL.n_celular = txtTelefono.Text;
        oReposicionEL.empleado = txtEmpleado.Text;

        if (chkConductor.Checked)
        {
            oReposicionEL.tipo_emp = "CONDUCTOR";
            
        }
        else
        {
            oReposicionEL.tipo_emp = "ADMINISTRATIVO";
        }

        oReposicionEL.motivo = ddlMotivo.SelectedValue.ToString();
        oReposicionEL.unidad = txtUnidad.Text;
        oReposicionEL.placa = txtUnidad_id.Text;
        oReposicionEL.area = ddlArea.SelectedValue.ToString();
        oReposicionEL.plan_equipo = "";
        oReposicionEL.nom_equipo = "";
        oReposicionEL.usuario_registro = hfusuario.Value;
        oReposicionEL.usuario_modificacion = "";
        oReposicionEL.estado = 1;
        oReposicionEL.obs = txtobs.Text;

        List<ReposicionEL> lst = oReposicionBL.RegistrarReposicion(oReposicionEL);

    }

    public void ActualizarReposicion(int id)
    {
        ReposicionBL oReposicionBL = new ReposicionBL();
        ReposicionEL oReposicionEL = new ReposicionEL();
        oReposicionEL.cod_reposicion = id;
        oReposicionEL.usuario_modificacion = hfusuario.Value;
        List<ReposicionEL> lst = oReposicionBL.ActualizarReposicion(oReposicionEL);
    }

    public void EliminarReposicion(int id)
    {
        ReposicionBL reposicionBL = new ReposicionBL();
        ReposicionEL reposicionEL = new ReposicionEL();
        reposicionEL.cod_reposicion = id;
        List<TransaccionEL> lst = reposicionBL.Eliminar_Reposicion(reposicionEL);
    }

    public void Asignar_Reposicion(int id)
    {
            ReposicionBL reposicionBL = new ReposicionBL();
            ReposicionEL reposicionEL = new ReposicionEL();
            reposicionEL.cod_reposicion = id;
            reposicionEL.plan_equipo = ddlPlanEquipo.SelectedValue.ToString();
            reposicionEL.nom_equipo = txtNombreEquipo.Text;
            List<ReposicionEL> lst = reposicionBL.Asignar_Equipo(reposicionEL);
    }
    public void Limpiar()
    {
        txtTelefono.Text = "";
        RBadministrativo.Checked = false;
        RBConductor.Checked = false;
        ddlMotivo.SelectedIndex = 0;
        txtUnidad.Text = "";
        txtUnidad_id.Text = "";
        ddlArea.SelectedIndex = 0;
        ddlPlanEquipo.SelectedIndex = 0;
        txtNombreEquipo.Text = "";
        if (chkConductor.Checked)
        {
            txtEmpleado.Text = Hfnomusuario.Value;
            chkConductor.Checked = false;
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
            hfusuario.Value = data[0];
            Hfnomusuario.Value = data[2];

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

    public void actualizarEstado()
    {

        int cantidad = 0;
        
        string acumulador = "";

        string acumulador2 = "";

        string acumulador3 = "";
        
        foreach (GridViewRow dtgItem in this.GvOtros1.Rows)
        {
           
            CheckBox chkReposicion = (CheckBox)GvOtros1.Rows[dtgItem.RowIndex].FindControl("chkReposicion");
            int id = Convert.ToInt32(GvOtros1.Rows[dtgItem.RowIndex].Cells[1].Text);
            String numero = Convert.ToString(GvOtros1.Rows[dtgItem.RowIndex].Cells[2].Text);
            String plan = Convert.ToString(GvOtros1.Rows[dtgItem.RowIndex].Cells[13].Text);
            String nombre= Convert.ToString(GvOtros1.Rows[dtgItem.RowIndex].Cells[14].Text); ;
            bool valor = chkReposicion.Checked;
            if (valor)
            {
                ActualizarReposicion(id);
                cantidad++;
                acumulador += numero + ";";
                acumulador2 +=plan+";";
                acumulador3 += nombre + ";";  
            }
        }
        EnviarMail(cantidad, acumulador,acumulador2,acumulador3,txtObservaciones.Text);
        MostrarMensaje(0, "Correo Enviado Correctamente");
    }

    protected void GvOtros1_PreRender(object sender, EventArgs e)
    {
        if (GvOtros1.Rows.Count > 0)
        {
            GvOtros1.UseAccessibleHeader = true;
            GvOtros1.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvOtros1.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void GvOtros1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {

            case "Editar":
                hfcod_reposicion.Value = e.CommandArgument.ToString();
                
                AbrirPopUp("infoModalAlert5");
                break;

            case "Eliminar":
                hfcod_reposicion.Value = e.CommandArgument.ToString();
                AbrirPopUp("infoModalAlert3");
                break;
        }
    }

    protected void GvOtros1_DataBound(object sender, EventArgs e)
    {

    }

    protected void GvOtros1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        CheckBox chkReposicion = (CheckBox)e.Row.FindControl("chkReposicion");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblEstado1 = (Label)e.Row.FindControl("lblEstado1");
            if (Convert.ToInt32(lblEstado1.Text) == 1)
            {
                lblEstado1.Text = "PENDIENTE";
                lblEstado1.CssClass = "btn btn-icon waves-effect waves-light btn-danger w-md m-b-5";
            }
            else if (Convert.ToInt32(lblEstado1.Text) == 2)
            {
                lblEstado1.Text = "ENVIADO";
                lblEstado1.CssClass = "btn btn-icon waves-effect waves-light btn-primary w-md m-b-5";
            }
            else
            {
                lblEstado1.Text = "RECHAZADO";
                lblEstado1.CssClass = "btn btn-icon waves-effect waves-light btn-success w-md m-b-5";
            }

        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {

        AbrirPopUp("infoModalAlert5");

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

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            EliminarReposicion(Convert.ToInt32(hfcod_reposicion.Value));
            ListarReposicion();
            MostrarMensaje(0, "Eliminado Correctamente");
        }
        catch
        {
            MostrarMensaje(1, "Algo sucedio, llame al administrador del sistema");
        }

    }

    protected void gvOtros_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Eliminar1":
                hfcod_reposicion.Value = e.CommandArgument.ToString();
                AbrirPopUp("infoModalAlert3");
                break;
        }
    }

    protected void chkConductor_CheckedChanged(object sender, EventArgs e)
    {
        if (chkConductor.Checked)
        {
            txtUnidad.Enabled = true;
            txtUnidad_id.Enabled = false;
            txtUnidad_id.Enabled = true;
            txtEmpleado.Text = "";
            txtEmpleado.Enabled = true;
            cargarAreaOperativa();
        }
        else
        {
            Limpiar();
            cargarNombreUsuario();
            cargarArea();
        }
        AbrirPopUp("infoModalAlert4");
    }

    public void cargarNombreUsuario()
    {
        txtEmpleado.Text = Hfnomusuario.Value;
        txtEmpleado.Enabled = false;
        txtTelefono.MaxLength = 9;
        txtUnidad.Enabled = false;
        txtUnidad_id.Enabled = false;
    }

    public void cargarPlanEquipo()
    {
        this.ddlPlanEquipo.DataSource = objCatalogo.ListarItem("35");
        ddlPlanEquipo.DataTextField = "descripcion";
        ddlPlanEquipo.DataValueField = "id_descripcion";
        ddlPlanEquipo.DataBind();
        ddlPlanEquipo.Items.Insert(0, new ListItem("--SELECCIONE PLAN EQUIPO--", ""));

    }
    protected void LinkAsignar_Click(object sender, EventArgs e)
    {
       
    }
    protected void LinkEnviar_Click(object sender, EventArgs e)
    {
        AbrirPopUp("infoModalAlert15");

        //try
        //{
        //    actualizarEstado();
        //    ListarReposicion();
        //}
        //catch
        //{
        //    MostrarMensaje(1, "Algo sucedio, llame al administrador del sistema");
        //}
      
    }
    protected void lnkAsignar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNombreEquipo.Text=="")
            {
                MostrarMensaje(1, "Asigne un nombre por favor");
            }
            else if (ddlPlanEquipo.SelectedIndex==0)
            {
                MostrarMensaje(1, "Seleccione el plan por favor");
            }
            else
            {
                Asignar_Reposicion(Convert.ToInt32(hfcod_reposicion.Value));
                ListarReposicion();
                Limpiar();
                MostrarMensaje(0, "Asignado Correctamente");
            }
        }
        catch
        {
            MostrarMensaje(1, "Algo sucedio, llame al administrador del sistema");
        }
    }

    protected void btnGuardar1_Click(object sender, EventArgs e)
    {
        try
        {
            string formato = "^[0-9]*";
            Regex reg = new Regex(formato);

            if (txtTelefono.Text== ""||txtTelefono.Text.Length!=9)
            {
                MostrarMensaje(1, "Completar el campo telefono");
            }
            else if (!reg.IsMatch(txtTelefono.Text))
            {
                MostrarMensaje(1, "Ingresar solo numeros al campo telefono ");
            }
            else if (ddlArea.SelectedIndex==0)
            {
                MostrarMensaje(1, "Seleccionar el area por favor");
            }
            else if (ddlMotivo.SelectedIndex == 0)
            {
                MostrarMensaje(1, "Seleccionar el motivo por favor");
            }
           
            else
            {

                RegistrarReposicion();
                MostrarMensaje(0, "Registrado Correctamente");
                ListarReposicion();
                Limpiar();
                cargarNombreUsuario();
            }


        }


        catch
        {
            MostrarMensaje(1, "Algo sucedio, llame al administrador del sistema");
        }
           
        

    }

    public void cargarmensaje()
    {
       
        txtObservaciones.Text = "Estimado Equipo Entel: \n"+
            "Se solicita la reposición de los siguientes telefonos :";
    }


    protected void btnAsignar_Click(object sender, EventArgs e)
    {
        //AbrirPopUp("infoModalAlert15");
        try
        {
            actualizarEstado();
            txtObservaciones.Text = "";
            ListarReposicion();
        }
        catch
        {
            MostrarMensaje(1, "Algo sucedio, llame al administrador del sistema");
        }
    }
}
