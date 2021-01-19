using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_OT_Proveedores : System.Web.UI.Page
{
    int error = 0;
    string mensaje;
    protected void Page_Load(object sender, EventArgs e)
    {
        ListarProveedores();

    }

    public void ListarProveedores()
    {
        ProveedorBL oDet = new ProveedorBL();
        List<ProveedorEL> lst = oDet.ListarProveedores();
        grvDataProveedores.DataSource = lst;
        grvDataProveedores.DataBind();
    }

    public void LimpiarProveedores()
    {
        txtCodigo.Text = "";
        txtDescripcion.Text = "";
    }

    public string RegistrarProveedor()
    {
        string cRespuesta = "";
        ProveedorBL oProBL = new ProveedorBL();
        ProveedorEL oProEL = new ProveedorEL();
        oProEL.Codigo = txtCodigo.Text;
        oProEL.Descripcion = txtDescripcion.Text;
        List<TransaccionEL> lst = null;
        lst  = oProBL.Registrar_Proveedor(oProEL);
        cRespuesta = lst[0].mensaje;
        return cRespuesta;
    }

    public void ListarDetalleProveedores(int id_proveedor)
    {
        ProveedorBL oDet = new ProveedorBL();
        ProveedorEL oMat = new ProveedorEL();
        LimpiarProveedores();
        List<ProveedorEL> lst = oDet.Listar_DetalleProveedores(id_proveedor);
        lblIdProveedor.Text = Convert.ToString(lst[0].IdProveedor);
        txtCodigo.Text = lst[0].Codigo;
        txtDescripcion.Text = lst[0].Descripcion;
    }

    public string EditarProveedores()
    {
        string cRespuesta = "";
        ProveedorBL oProBL = new ProveedorBL();
        ProveedorEL oProEL = new ProveedorEL();
        oProEL.Codigo = txtCodigo.Text;
        oProEL.Descripcion = txtDescripcion.Text;
        List<TransaccionEL> lst = null;
        lst = oProBL.Editar_Proveedor(oProEL, Convert.ToInt32(lblIdProveedor.Text));
        cRespuesta = lst[0].mensaje;
        return cRespuesta;
    }

        protected void btnAgregar_Click(object sender, EventArgs e)
    {
        LimpiarProveedores();
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
    }

    protected void grvDataProveedores_PreRender(object sender, EventArgs e)
    {
        if (grvDataProveedores.Rows.Count > 0)
        {
            grvDataProveedores.UseAccessibleHeader = true;
            grvDataProveedores.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvDataProveedores.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void grvDataProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id_proveedor = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName.ToString())
        {
            case "detalle":
                ListarDetalleProveedores(id_proveedor);
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
                //MultiView1.ActiveViewIndex = 1;
                break;
            case "eliminar":
                try
                {
                    ProveedorBL oPro = new ProveedorBL();
                    oPro.Eliminar_Proveedor(id_proveedor);
                    error = 0;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se eliminó correctamente','Alerta:','success');", true);
                }
                catch (Exception ex)
                {
                    error = 1;
                    mensaje = "No se pudo eliminar";
                }

                break;
                //MultiView1.ActiveViewIndex = 0;
                //EliminarCabeceraDetalle(id);
                //ListarCabecera();
                //MultiView1.ActiveViewIndex = 0;
        }
        ListarProveedores();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {

        try
        {
            if (lblIdProveedor.Text == "")
            {
                string cRespuesta = RegistrarProveedor();
                error = 0;
                // mensaje = "Se registró correctamente";
                mensaje = cRespuesta;
            }
            else
            {
                string cRespuesta = EditarProveedores();
                error = 0;
                //mensaje = "Se modifico correctamente";
                mensaje = cRespuesta;
            }

        }
        catch (Exception ex)
        {
            mensaje = "Ocurrio un error";
            error = 1;
        }
        MostrarMensaje();
        ListarProveedores();
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