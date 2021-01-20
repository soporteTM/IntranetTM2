using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_OT_TareasMantenimiento : System.Web.UI.Page
{
    int id, error = 0;
    string mensaje, extension;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarTareasMantenimiento();
            loadItems(ddlGrupo, "26");
            loadItemsMarca(ddlMarca, "01");
            //ListarMateriales();
        }

    }

    public void loadItemsMarca(ListBox ddl, string id_catalogo)
    {
        ItemBL oItem = new ItemBL();
        ddl.DataSource = oItem.ListarItemOpe(id_catalogo);
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
        //ddl.Items.Insert(0, new ListItem("-- TODOS --", ""));
        ddl.SelectedIndex = 0;
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


    public void ListarMateriales(string id_codigo)
    {
        TareaMantenimientoBL oTarBL = new TareaMantenimientoBL();
        TareaMantenimientoEL oTarEL = new TareaMantenimientoEL();
        List<TareaMantenimientoEL> lst = oTarBL.ListarMateriales(id_codigo);
        lstMaterial.Items.Clear();
        for (int i = 0; i < lst.Count; i++)
        {
            lstMaterial.DataValueField = Convert.ToString(lst[i].IdMaterial);
            lstMaterial.DataTextField = lst[i].nom_material;
            lstMaterial.DataSource = lst;
            lstMaterial.Items.Add(new ListItem(lst[i].nom_material, Convert.ToString(lst[i].IdMaterial)));
            //lstMaterial.Items.Insert(i, new ListItem(lst[i].nom_material, Convert.ToString(lst[i].IdMaterial)));
        }
    }

    public void ListarTareasMantenimiento()
    {
        TareaMantenimientoBL oTar = new TareaMantenimientoBL();
        List<TareaMantenimientoEL> lst = oTar.ListarTareasMantenimiento();
        grvDataTareasMantenimientoDetalle.DataSource = lst;
        grvDataTareasMantenimientoDetalle.DataBind();
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        limpiarTareasMantenimiento();
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
    }

    public void limpiarTareasMantenimiento()
    {
        txtDescripcion.Text = "";
        ddlGrupo.Text = "";
        ddlMarca.ClearSelection();
        ddlMarca.SelectedIndex = -1;
        lstAgregar.Items.Clear();
        txtMaterial.Text = "";
        lstMaterial.ClearSelection();
        lstMaterial.SelectedIndex = -1;
        lstMaterialSelect.Items.Clear();
    }

    protected void grvDataTareasMantenimientoDetalle_PreRender(object sender, EventArgs e)
    {
        if (grvDataTareasMantenimientoDetalle.Rows.Count > 0)
        {
            grvDataTareasMantenimientoDetalle.UseAccessibleHeader = true;
            grvDataTareasMantenimientoDetalle.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvDataTareasMantenimientoDetalle.FooterRow.TableSection = TableRowSection.TableFooter;
        }

    }

    protected void grvDataTareasMantenimientoDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id_tarea = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName.ToString())
        {
            case "ver":
                ListarDetalleTareaMarca(id_tarea);
                ListarDetalleTareaMaterial(id_tarea);
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert3').modal('show');", true);
                break;
            case "detalle":
                ListarDetalleTarea(id_tarea);
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
                break;
            case "eliminar":
                try
                {
                 TareaMantenimientoBL oTarBL = new TareaMantenimientoBL();
                 oTarBL.Eliminar_TareaMantenimiento(id_tarea);
                 error = 0;
                 ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se eliminó correctamente','Alerta:','success');", true);
                }
                catch (Exception ex)
                {
                }
                break;
        }
        ListarTareasMantenimiento();
    }


    public void ListarDetalleTareaMarca(int id_tarea)
    {
        TareaMantenimientoDetBL oTarDetBL = new TareaMantenimientoDetBL();
        TareaMantenimientoDetEL oTarDetEL = new TareaMantenimientoDetEL();
        List<TareaMantenimientoDetEL> lst = oTarDetBL.Listar_Detalle_TareasMarca(id_tarea);
        grvDataDetMarca.DataSource = lst;
        grvDataDetMarca.DataBind();

    }

    public void ListarDetalleTareaMaterial(int id_tarea)
    {
        TareaMantenimientoDetBL oTarDetBL = new TareaMantenimientoDetBL();
        TareaMantenimientoDetEL oTarDetEL = new TareaMantenimientoDetEL();
        List<TareaMantenimientoDetEL> lst = oTarDetBL.Listar_Detalle_TareasMaterial(id_tarea);
        grvDataDetMaterial.DataSource = lst;
        grvDataDetMaterial.DataBind();
    }



    public void ListarDetalleTarea(int id_tarea)
    {
        TareaMantenimientoBL oTarBL = new TareaMantenimientoBL();
        TareaMantenimientoEL oTarEL = new TareaMantenimientoEL();
        TareaMantenimientoDetBL oTarDetBL = new TareaMantenimientoDetBL();
        TareaMantenimientoDetEL oTarDetEL = new TareaMantenimientoDetEL();
        limpiarTareasMantenimiento();
        List<TareaMantenimientoEL> lst = oTarBL.Listar_DetalleTarea(id_tarea);
        lblIdTarea.Text = Convert.ToString(id_tarea);
        txtDescripcion.Text = lst[0].Descripcion;
        ddlGrupo.SelectedValue = lst[0].GrupoArticuloCodiMaterial;
        ListarDetalleTarea_Marca_Material(id_tarea);
    }

    public void ListarDetalleTarea_Marca_Material(int id_tarea)
    {

        TareaMantenimientoDetBL oTarDetBL = new TareaMantenimientoDetBL();
        List<TareaMantenimientoDetEL> lst2 = oTarDetBL.Listar_DetalleTarea_Marca_Material(id_tarea);
        for (int i = 0; i < lst2.Count; i++)
        {
            if (lst2[i].IdTipo == 1)
            {
                lstAgregar.DataValueField = Convert.ToString(lst2[i].CodiMarca);
                lstAgregar.DataTextField = lst2[i].nom_marca;
                lstAgregar.DataSource = lst2;
                lstAgregar.Items.Add(new ListItem(lst2[i].nom_marca, Convert.ToString(lst2[i].CodiMarca)));
            }
            else
            {
                lstMaterialSelect.DataValueField = Convert.ToString(lst2[i].CodiMarca);
                lstMaterialSelect.DataTextField = lst2[i].nom_material;
                lstMaterialSelect.DataSource = lst2;
                lstMaterialSelect.Items.Add(new ListItem(lst2[i].nom_material, Convert.ToString(lst2[i].CodiMarca)));
            }
        }

    }


    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        TareaMantenimientoBL oTarBL = new TareaMantenimientoBL();
        TareaMantenimientoEL oTarEL = new TareaMantenimientoEL();
        try
        {
            if (lblIdTarea.Text == "")
            {

                RegistrarTareaMantenimiento();
                error = 0;
                mensaje = "Se registró correctamente";
            }
            else
            {
                EditarTareaMantenimiento();
                error = 0;
                mensaje = "Se modificó correctamente";
            }
        }
        catch (Exception ex)
        {
            mensaje = "Ocurrio un error";
            error = 1;

        }
        MostrarMensaje();
        ListarTareasMantenimiento();
    }

    public void EditarTareaMantenimiento() 
    {
        try
        {
            TareaMantenimientoBL oTarBL = new TareaMantenimientoBL();
            TareaMantenimientoEL oTarEL = new TareaMantenimientoEL();
            oTarEL.Descripcion = txtDescripcion.Text;
            oTarEL.GrupoArticuloCodiMaterial = ddlGrupo.SelectedValue;
            TareaMantenimientoDetEL oTarDetEL = new TareaMantenimientoDetEL();
            List<TransaccionEL> lst = oTarBL.Editar_TareaMantenimiento(oTarEL, Convert.ToInt32(lblIdTarea.Text));
            foreach (ListItem item in lstAgregar.Items)
            {
                oTarDetEL.IdTarea = Convert.ToInt32(lblIdTarea.Text);
                oTarDetEL.IdTipo = 1;
                oTarDetEL.CodiMarca = item.Value;
                RegistrarDetalleTareaMantenimiento(oTarDetEL);
            }
            foreach (ListItem item in lstMaterialSelect.Items)
            {
                oTarDetEL.IdTarea = Convert.ToInt32(lblIdTarea.Text);
                oTarDetEL.IdTipo = 2;
                oTarDetEL.CodiMarca = item.Value;
                RegistrarDetalleTareaMantenimiento(oTarDetEL);
            }
            
        }
        catch (Exception)
        {

            throw;
        }

    }

    public void EditarDetalleTareaMantenimiento(TareaMantenimientoDetEL oTarDetEL)
    {
        TareaMantenimientoDetBL oTarDetBL = new TareaMantenimientoDetBL();
        List<TransaccionEL> lst2 = oTarDetBL.Editar_DetalleTareaMantenimiento(oTarDetEL);
    }

    public void RegistrarTareaMantenimiento()
    {
        TareaMantenimientoBL oTarBL = new TareaMantenimientoBL();
        TareaMantenimientoEL oTarEL = new TareaMantenimientoEL();
        oTarEL.Descripcion = txtDescripcion.Text;
        oTarEL.GrupoArticuloCodiMaterial = ddlGrupo.SelectedValue;
        string id_codigo = oTarEL.GrupoArticuloCodiMaterial;
        // List<TareaMantenimientoDetEL> lstMarca = new List<TareaMantenimientoDetEL>();
        TareaMantenimientoDetEL oTarDetEL = new TareaMantenimientoDetEL();
        List<TransaccionEL> lst = oTarBL.Registrar_TareaMantenimiento(oTarEL);
        //List<TareaMantenimientoDetEL> lista = new List<TareaMantenimientoDetEL>();
        int id_Tarea = lst[0].id_mensaje;
        //int id_Tarea = ;
        foreach (ListItem item in lstAgregar.Items)
        {
            oTarDetEL.IdTarea = id_Tarea;
            oTarDetEL.IdTipo = 1;
            oTarDetEL.CodiMarca = item.Value;
            RegistrarDetalleTareaMantenimiento(oTarDetEL);
            //RegistraDetalle();
            //lstAgregar.Items.Add(oTarDetEL.CodiMarca);
        }
        foreach (ListItem item in lstMaterialSelect.Items)
        {
            oTarDetEL.IdTarea = id_Tarea;
            oTarDetEL.IdTipo = 2;
            oTarDetEL.CodiMarca = item.Value;
            RegistrarDetalleTareaMantenimiento(oTarDetEL);
        }
            //oTarDetEL.CodiMarca = lstMaterial.SelectedItem.Value;
            //oMatEL.nom_grupo = ddlGrupo.SelectedItem.Text;
    }

    public void RegistrarDetalleTareaMantenimiento(TareaMantenimientoDetEL objDet)
    {

        TareaMantenimientoDetBL oTarDetBL = new TareaMantenimientoDetBL();
        List<TransaccionEL> lst2 = oTarDetBL.Registrar_DetalleTareaMantenimiento(objDet);

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

    protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
    {
        MaintainScrollPositionOnPostBack = true;
        TareaMantenimientoEL oTarEL = new TareaMantenimientoEL();
            foreach (ListItem item in ddlMarca.Items)
            {
                if (item.Selected)
                {
                    if (lstAgregar.Items.Contains(item))
                    {
                        Label2.Visible = true;
                        Label2.Text = "La marca esta agregada.";
                    }
                    else
                    {
                        lstAgregar.Items.Add(item);
                        ddlMarca.ClearSelection();
                        Label2.Visible = false;
                    }
                }
            }
       
    }


    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        MaintainScrollPositionOnPostBack = true;
            while (lstAgregar.GetSelectedIndices().Length > 0)
            {
                lstAgregar.Items.Remove(lstAgregar.SelectedItem);
            }
        
    }

    protected void btnAgregarMat_Click(object sender, EventArgs e)
    {
        
        foreach (ListItem item in lstMaterial.Items)
        {
            if (item.Selected)
            {
                if (lstMaterialSelect.Items.Contains(item))
                {
                    Label3.Visible = true;
                    Label3.Text = "El material esta agregado.";
                }
                else
                {
                    lstMaterialSelect.Items.Add(item);
                    lstMaterial.ClearSelection();
                    Label3.Visible = false;
                }
            }
        }
    }
    protected void btnEliminarMat_Click(object sender, EventArgs e)
    {
        MaintainScrollPositionOnPostBack = true;
        while (lstMaterialSelect.GetSelectedIndices().Length > 0)
        {
            lstMaterialSelect.Items.Remove(lstMaterialSelect.SelectedItem);
        }
    }


    protected void btnBuscarMat_Click(object sender, EventArgs e)
    {
        lblError.Visible = false;
        if (txtMaterial.Text != null) 
        {
            if (lstMaterial.Items.FindByText(txtMaterial.Text) != null)
            {
                TareaMantenimientoEL oTarEL = new TareaMantenimientoEL();
                TareaMantenimientoBL otarBL = new TareaMantenimientoBL();
                string id_codigo = ddlGrupo.SelectedValue;
                List<TareaMantenimientoEL> lst = otarBL.ListarMateriales(id_codigo);
                for (int i = 0; i < lst.Count; i++)
                {
                    lstMaterial.Items.FindByValue(Convert.ToString(lst[i].IdMaterial)).Selected = false;

                    lstMaterial.Items.FindByText(lst[i].nom_material).Selected = false;
                }
                lstMaterial.Items.FindByText(txtMaterial.Text).Selected = true;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "No se encontró el material";
            }
        }
      
    }


    protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id_codigo = ddlGrupo.SelectedValue;
        ListarMateriales(id_codigo);
    }
}