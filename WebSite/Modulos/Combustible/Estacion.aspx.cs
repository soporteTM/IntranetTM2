using BL;
using DAL;
using EL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Combustible_Repsol : System.Web.UI.Page
{
    int id, error=0;
    string mensaje,extension;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarCabecera();
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
            hfUsuario.Value = data[0];
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        limpiarCabecera();
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
    }

    public void RegistrarCabecera()
    {
        CombustibleBL oCabBL = new CombustibleBL();
        CombustibleEL oCabEL = new CombustibleEL();
        oCabEL.fecha_inicio = txtFechaInicio.Text;
        oCabEL.fecha_corte = txtFechaCorte.Text;
        oCabEL.usuario_registro = hfUsuario.Value;

        if (ConsultarFecha(oCabEL.fecha_inicio, oCabEL.fecha_corte) == 0)
        {
            List<TransaccionEL> lst = oCabBL.Registrar_Combustible(oCabEL);

            if (lst[0].id_mensaje == 1)
            {
                id = Convert.ToInt32(lst[0].mensaje);
            }
            RegistrarDetalle();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Ya cuenta con registro','Alerta:','error');", true);
        }

    }

    public int ConsultarFecha(string fecha_inicio, string fecha_corte)
    {
        CombustibleBL oCombustible = new CombustibleBL();
        List<CombustibleEL> lst = oCombustible.ConsultarFecha(fecha_inicio, fecha_corte);
        return lst.Count;

    }

    protected void btnImportar_Click(object sender, EventArgs e)
    {
        try
        {
            ComprobarExcel();
            if (extension == ".xls" || extension == ".xlsx")
            {
                RegistrarCabecera();                
            }
            else
            {
                mensaje = "Seleccionar archivo Excel";
                error = 1;
            }
        }
        catch(Exception ex)
        {
            mensaje = "Ocurrio un error";
            error = 1;
        }
        MostrarMensaje();
        ListarCabecera();

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

    public void RegistrarDetalle()
    {
        DataTable ds = new DataTable();
        CombustibleDetBL oDetBL = new CombustibleDetBL();

        string FileName = Path.GetFileName(fuImportar.PostedFile.FileName);
        string Extension = Path.GetExtension(fuImportar.PostedFile.FileName);
        string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

        string FilePath = Server.MapPath(FolderPath + FileName);
        fuImportar.SaveAs(FilePath);
        ds = Util.Import_To_Grid(FilePath, Extension, "Yes");

        for (int i = 3; i <= ds.Rows.Count - 1; i++)
        {
            if (!String.IsNullOrEmpty(ds.Rows[i][2].ToString()))
            {
                CombustibleDetEL objDet = new CombustibleDetEL();
                objDet.id_cabecera = id;
                objDet.nro_placa =  ds.Rows[i][7].ToString().Replace("-","");
                objDet.nom_cliente = ds.Rows[i][15].ToString();
                objDet.c_costo = ds.Rows[i][17].ToString();
                objDet.cod_eess = ds.Rows[i][7].ToString();
                objDet.nom_eess = ds.Rows[i][4].ToString();
                objDet.fch_documento = ds.Rows[i][0].ToString().Substring(0,10)+" "+ ds.Rows[i][1].ToString();
                objDet.num_documento = ds.Rows[i][13].ToString();
                objDet.cantidad = Convert.ToDecimal(ds.Rows[i][10].ToString());
                objDet.precio_sin_igv= Convert.ToDecimal(ds.Rows[i][11].ToString());
                objDet.precio_con_igv = Convert.ToDecimal(ds.Rows[i][11].ToString());
                objDet.monto_sin_igv = Convert.ToDecimal(ds.Rows[i][12].ToString());
                objDet.monto_con_igv = Convert.ToDecimal(ds.Rows[i][12].ToString());
                objDet.Kilometraje = ds.Rows[i][18].ToString();

                List<TransaccionEL> lst2 = oDetBL.Registrar_Detalle(objDet);

                mensaje = "Se registro correctamente";  

            }
        }
    }

    public void ListarDetalle(int id_cabecera)
    {
        CombustibleDetBL oDet = new CombustibleDetBL();
        List<CombustibleDetEL> lst = oDet.Listar_Detalle(id_cabecera);
        grvCombustibleDetalle.DataSource = lst;
        grvCombustibleDetalle.DataBind();
    }

    public void ListarCabecera()
    {
        CombustibleBL oDet = new CombustibleBL();
        List<CombustibleEL> lst = oDet.Listar_Cabecera();
        grvCombustibleCabecera.DataSource = lst;
        grvCombustibleCabecera.DataBind();
    }        

    public void ComprobarExcel()
    {
        string Extension = Path.GetExtension(fuImportar.PostedFile.FileName);
        extension = Extension;
    }

    protected void grvCombustibleCabecera_PreRender(object sender, EventArgs e)
    {
        if (grvCombustibleCabecera.Rows.Count > 0)
        {
            grvCombustibleCabecera.UseAccessibleHeader = true;
            grvCombustibleCabecera.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvCombustibleCabecera.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void grvCombustibleCabecera_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);

        switch (e.CommandName.ToString())
        {
            case "detalle":
                ListarDetalle(id);
                MultiView1.ActiveViewIndex = 1;
                break;
            case "eliminar":
                EliminarCabeceraDetalle(id);
                ListarCabecera();
                MultiView1.ActiveViewIndex = 0;
                break;
        }

    }

    public void EliminarCabeceraDetalle(int id)
    {
        CombustibleBL oCombustible = new CombustibleBL();
        CombustibleEL objCombustible = new CombustibleEL();
        objCombustible.id = id;
        List<TransaccionEL> tnx = oCombustible.EliminarCabeceraDetalle(objCombustible);
        if (tnx[0].id_mensaje == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se eliminó con éxito.','Alerta:','success');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('" + mensaje + "','Alerta:','error');", true);
        }

    }

    protected void grvCombustibleDetalle_PreRender(object sender, EventArgs e)
    {
        if (grvCombustibleDetalle.Rows.Count > 0)
        {
            grvCombustibleDetalle.UseAccessibleHeader = true;
            grvCombustibleDetalle.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvCombustibleDetalle.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void lnkRegresar_Click(object sender, EventArgs e)
    {
        ListarCabecera();
        MultiView1.ActiveViewIndex = 0;
    }

    public void limpiarCabecera()
    {
        txtFechaInicio.Text = "";
        txtFechaCorte.Text = "";
    }

    //protected void grvCombustibleDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    e.Row.Cells[0].Visible = false;
    //}

    protected void grvCombustibleDetalle_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[0].Visible = false;
    }
}