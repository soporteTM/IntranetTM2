using BL;
using DAL;
using EL;
using System;
using System.Activities.Statements;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Modulos_OT_Materiales : System.Web.UI.Page
{
    int id, error = 0;
    string mensaje, extension;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarMateriales();
            loadItems(ddlGrupo, "26");
        }
       
    }

    protected void grvDataMateriales_PreRender(object sender, EventArgs e)
    {
        if (grvDataMateriales.Rows.Count > 0)
        {
            grvDataMateriales.UseAccessibleHeader = true;
            grvDataMateriales.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvDataMateriales.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void grvDataMateriales_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id_material = Convert.ToInt32(e.CommandArgument);
          switch (e.CommandName.ToString())
        {
            case "detalle":
                ListarDetalleMateriales(id_material);

                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
                //MultiView1.ActiveViewIndex = 1;
                break;
            case "eliminar":
                try
                {
                    MaterialBL oMat = new MaterialBL();
                    oMat.Eliminar_Material(id_material);
                    error = 0;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se eliminó correctamente','Alerta:','success');", true);
                    // MostrarMensaje(0, "Se eliminó correctamente");
                }
                catch (Exception ex)
                {
                    error = 1;
                    mensaje = "No se pudo eliminar";
                    //MostrarMensaje(1, "No se pudo eliminar");
                }

                break;
                //MultiView1.ActiveViewIndex = 0;
                //EliminarCabeceraDetalle(id);
                //ListarCabecera();
                //MultiView1.ActiveViewIndex = 0;
        }
        ListarMateriales();
    }

    public void ListarDetalleMateriales(int id_material)
    {
        MaterialBL oDet = new MaterialBL();
        MaterialEL oMat = new MaterialEL();
        limpiarMateriales();
        List<MaterialEL> lst = oDet.Listar_DetalleMateriales(id_material);
        lblIdMaterial.Text = Convert.ToString(lst[0].IdMaterial);
        txtCodigo.Text = lst[0].Codigo;
        txtDescripcion.Text = lst[0].Descripcion;
        ddlGrupo.SelectedValue = lst[0].GrupoArticuloCodigo;
        //ddlGrupo.DataTextField = ;
        //grvDataMateriales.DataBind();
    }

    public string EditarMateriales()
    {
            List<TransaccionEL> lst = null;
            string cRespuesta = "";
            MaterialBL oMatBL = new MaterialBL();
            MaterialEL objMat= new MaterialEL();
            objMat.Codigo = txtCodigo.Text;
            objMat.Descripcion = txtDescripcion.Text;
            objMat.GrupoArticuloCodigo = ddlGrupo.SelectedValue;
            if (ddlGrupo.SelectedValue == "260000")
            {

                lblGrupoNumero.InnerHtml = "122";
                objMat.ArticuloNumero = Convert.ToInt32(lblGrupoNumero.InnerHtml);
                lst = oMatBL.Editar_Material(objMat, Convert.ToInt32(lblIdMaterial.Text));
            }
            else
            {
                if (ddlGrupo.SelectedValue == "260100")
                {

                    lblGrupoNumero.InnerHtml = "127";
                    objMat.ArticuloNumero = Convert.ToInt32(lblGrupoNumero.InnerHtml);
                    lst = oMatBL.Editar_Material(objMat, Convert.ToInt32(lblIdMaterial.Text));

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Debe seleccionar un Grupo.','Alerta:','error');", true);
                }
            }
          cRespuesta = lst[0].mensaje;
          return cRespuesta;
    }

    public void ListarMateriales()
    
    {
        MaterialBL oDet = new MaterialBL();
        List<MaterialEL> lst = oDet.ListarMateriales();
        grvDataMateriales.DataSource = lst;
        grvDataMateriales.DataBind();
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        limpiarMateriales();
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
        
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

    public void limpiarMateriales()
    {
        txtCodigo.Text = "";
        txtDescripcion.Text = "";
        ddlGrupo.Text = "";
        ddlGrupo.SelectedIndex = 0;
    }


    protected void btnGuardar_Click(object sender, EventArgs e)
    {

        MaterialBL oDet = new MaterialBL();
        MaterialEL oMatEL = new MaterialEL();
        //  int id_material = Convert.ToInt32(grvDataMateriales.Rows[0].Cells[0].Text); 
        try
        {
            if (lblIdMaterial.Text == "")
            {
               
                string cRespuesta=RegistrarMaterial();
                error = 0;
                //mensaje = "Se registró correctamente";
                mensaje = cRespuesta;
            }
            else
            {
                string cRespuesta=EditarMateriales();
                error = 0;
                //mensaje = "Se modifico correctamente";
                mensaje = cRespuesta;
            }
           // MostrarMensaje(0, "Se modifico correctamente");
        }
        catch (Exception ex)
        {
            mensaje = "Ocurrio un error";
            error = 1;
            // MostrarMensaje(1, "No se pudo realizar la modificacion");

        }
        MostrarMensaje();
        ListarMateriales();
    }

    public string RegistrarMaterial()
    {
        string cRespuesta = "";
        List<TransaccionEL> lst = null;
        MaterialBL oMatBL = new MaterialBL();
        MaterialEL oMatEL = new MaterialEL();
        oMatEL.Codigo = txtCodigo.Text;
        oMatEL.Descripcion = txtDescripcion.Text;
        oMatEL.GrupoArticuloCodigo = ddlGrupo.SelectedValue;
        //oMatEL.nom_grupo = ddlGrupo.SelectedItem.Text;
        if (ddlGrupo.SelectedValue == "260000")
        {
           
            lblGrupoNumero.InnerHtml = "122";
            oMatEL.ArticuloNumero = Convert.ToInt32(lblGrupoNumero.InnerHtml);
            //List<TransaccionEL> lst = oMatBL.Registrar_Material(oMatEL);
            lst = oMatBL.Registrar_Material(oMatEL);
        }
        else
        {
            if (ddlGrupo.SelectedValue == "260100")
            {
               
                lblGrupoNumero.InnerHtml = "127";
                oMatEL.ArticuloNumero = Convert.ToInt32(lblGrupoNumero.InnerHtml);
                //List<TransaccionEL> lst = oMatBL.Registrar_Material(oMatEL);
                lst = oMatBL.Registrar_Material(oMatEL);
                //
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Debe seleccionar un Grupo.','Alerta:','error');", true);
            }

        }
        cRespuesta = lst[0].mensaje;
        return cRespuesta;
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

}