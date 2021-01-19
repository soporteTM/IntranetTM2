using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Usuarios_Default : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TEST_istar();

            loadItems();
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        hfAction.Value = "r";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
    }

    public void loadItems()
    {
        EcoPerfilBL oPerfil = new EcoPerfilBL();
        ddlPerfil.DataSource = oPerfil.ListarPefil();
        ddlPerfil.DataTextField = "per_descripcion"; 
        ddlPerfil.DataValueField = "per_codigo";
        ddlPerfil.DataBind();
        ddlPerfil.Items.Insert(0, new ListItem("-- Perfiles --", ""));
        ddlPerfil.SelectedIndex = 0;
    }


    protected void gvUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Modificar":
                hfAction.Value = "a";
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                hfID.Value = arg[0];
                hfIDEmpleado.Value = arg[1];
                txtJefe.Text = "";
                txtJefe_id.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert4').modal('show');", true);
                break;

            case "eliminar":
                string[] arg2 = new string[1];
                arg2 = e.CommandArgument.ToString().Split(';');
                hfID.Value = arg2[0];
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert3').modal('show');", true);
                break;
        }
    }

    protected void gvUsuario_PreRender(object sender, EventArgs e)
    {
        if (gvUsuario.Rows.Count > 0)
        {
            gvUsuario.UseAccessibleHeader = true;
            gvUsuario.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvUsuario.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        TEST_Eliminar();
        TEST_istar();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (hfAction.Value.Equals("r"))
        {
            TEST_Agregar();
        }
        TEST_istar();

    }

    

    protected void btnReestablecer_Click(object sender, EventArgs e)
    {
        try
        {
            TEST_Editar();
            TEST_istar();
            MostrarMensaje(0,"Se edito el usuario correctamente");
        }
        catch(Exception ex)
        {
            MostrarMensaje(1, "No se pudo realizar la actualizacion");
        }
    }

    protected void lnkModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Actualizacion_Jefatura();
            TEST_istar();
            MostrarMensaje(0,"Se actualizo la jefatura correctamente");
        }
        catch(Exception ex)
        {
            MostrarMensaje(1, "No se pudo actualizar la jefatura");
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

    protected void TEST_Editar()
    {
        UsuarioBL oUsuario = new UsuarioBL();
        int id_usuario = Convert.ToInt32(hfID.Value);
        List<UsuarioEL> lista = oUsuario.TEST_Editar(id_usuario);
    }

    protected void TEST_Eliminar()
    {
        int id_usuario;
        UsuarioBL oUsuario = new UsuarioBL();
        id_usuario = Convert.ToInt32(hfID.Value);
        List<UsuarioEL> lista = oUsuario.TEST_Eliminar(id_usuario);
    }

    public void Actualizacion_Jefatura()
    {
        UsuarioBL oUsuario = new UsuarioBL();
        List<UsuarioEL> lista = oUsuario.ActualizarJefatura(Convert.ToInt32(txtJefe_id.Text), Convert.ToInt32(hfIDEmpleado.Value));
    }




    protected void TEST_Agregar()
    {
        UsuarioBL oUsuario = new UsuarioBL();
        string nom_usuario = txtNomUsuario.Text;
        string nom_user = txtNomUser.Text;
        string perfil = ddlPerfil.SelectedValue.ToString();
        int id_empleado = 0;
        if (!txtEmpleado.Text.Equals(""))
        {
            id_empleado = Convert.ToInt32(txtEmpleado_id.Text);
        }


        List<UsuarioEL> lista = oUsuario.TEST_Listar_Filtro(nom_usuario, nom_user, perfil, id_empleado);

    }
    protected void TEST_istar()
    {
        UsuarioBL oUsuario = new UsuarioBL();
        List<UsuarioEL> lista = oUsuario.TEST_Listar_Todo_Usuarios();
        gvUsuario.DataSource = lista;
        gvUsuario.DataBind();

    }
}