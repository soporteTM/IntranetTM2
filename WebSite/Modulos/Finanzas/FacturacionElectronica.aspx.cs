using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ionic.Zip;
using System.IO;
public partial class Modulos_Finanzas_FE : System.Web.UI.Page
{
    FactElectronicaBL oFacturacionElectronica = new FactElectronicaBL();
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
        List<UsuarioEL> lista = oUsuario.ActualizarJefatura(Convert.ToInt32(txtJefe_id.Text),Convert.ToInt32(hfIDEmpleado.Value));
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
    protected void ListarDocumetos()
    {
        DateTime fchInicio = Convert.ToDateTime("01/01/1900");
        DateTime fchFin = Convert.ToDateTime("31/12/3000");
        if (fchEmision_Desde.Text != "")
            fchInicio = Convert.ToDateTime(fchEmision_Desde.Text);
        if (fchEmision_Hasta.Text != "")
            fchFin = Convert.ToDateTime(fchEmision_Hasta.Text + " 23:59:59");

        List<FactElectronicaEL> lista = oFacturacionElectronica.Consultar(ddlTipoDocumento.SelectedValue, fchInicio, fchFin, "","",0,"","");
        gvUsuario.DataSource = lista;
        gvUsuario.DataBind();

        LinkButton2.Text = " <i class='fa fa-check m-r-5'></i> <span> Marcar Todos</span>";            
        HFMarcarFilas.Value = "1";

        LinkButton1.Visible = false;
        LinkButton2.Visible = false;
        if (lista.Count() > 0)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //fchEmision_Desde.Text = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            fchEmision_Desde.Text = DateTime.Today.AddDays(-7).ToString("dd/MM/yyyy");
            fchEmision_Hasta.Text = DateTime.Today.ToString("dd/MM/yyyy");
            ListarDocumetos();
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
            case "PDF":
                string[] arg = new string[3];
                arg = e.CommandArgument.ToString().Split(';');
                string strArchivo = ObtenerArchivo(arg[2], "PDF");
                if (strArchivo != "")
                {
                    string NombreFile = Path.GetFileName(strArchivo);
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", NombreFile));
                    Response.TransmitFile(strArchivo);
                    Response.End();
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('No se encontro archivo PDF','Error:','danger');", true);

                break;
            case "CDP":
                string[] arg1 = new string[3];
                arg1 = e.CommandArgument.ToString().Split(';');
                string strArchivo1 = ObtenerArchivo_v2(arg1[2], "XML","F");
                if (strArchivo1 != "")
                {
                    string NombreFile1 = Path.GetFileName(strArchivo1);
                    Response.ContentType = "application/xml";
                    Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", NombreFile1));
                    Response.TransmitFile(strArchivo1);
                    Response.End();
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('No se encontro archivo PDF','Error:','danger');", true);

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
        ListarDocumetos();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (hfAction.Value.Equals("r"))
        {
            TEST_Agregar();
        }
        ListarDocumetos();

    }

    

    protected void btnReestablecer_Click(object sender, EventArgs e)
    {
        try
        {
            TEST_Editar();
            ListarDocumetos();
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
            ListarDocumetos();
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

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        ListarDocumetos();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (gvUsuario.Rows.Count > 0)
        {
            int count = Convert.ToInt32(HFMarcarFilas.Value);
            count++;
            bool check_valor = (count % 2 == 0 ? true : false);
            foreach(GridViewRow row in gvUsuario.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("chkSeleccionar");
                check.Checked = check_valor;
            }

            if (!check_valor)
                LinkButton2.Text = " <i class='fa fa-check m-r-5'></i> <span> Marcar Todos</span>";
            else
                LinkButton2.Text = " <i class='fa fa-check m-r-5'></i> <span> Desmarcar Todos</span>";

            HFMarcarFilas.Value = count.ToString();
        }
        else
        {

        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (gvUsuario.Rows.Count > 0)
        {
            List<string> ListaFiles = new List<string>();
            List<string> ListaFW = new List<string>();
            //List<MemoryStream> ListaStream = new List<MemoryStream>();
            //List<Byte[]> ListaByte = new List<Byte[]>();          

            foreach (GridViewRow row in gvUsuario.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("chkSeleccionar");
                string RutaCarpeta = ((Label)row.FindControl("lblDirectory")).Text;
                if (RutaCarpeta != "" && check.Visible)
                {
                    string NombreFile = RutaCarpeta.Split('/')[2];
                    if (check.Checked)
                    {
                        ListaFiles.Add(ObtenerArchivo(RutaCarpeta,"PDF"));
                        ListaFW.Add(NombreFile);
                    }
                }           
            }

            if (ListaFiles.Count == 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('Debe marcar una o más filas','Alerta:','warning');", true);
            else
            {

                string rutaDirectorioTemp = Server.MapPath("~/temp/");
                string rutaNombre = "PDF_" + DateTime.Now.ToString("dMyyHms") + ".zip";
                List<string> strERROR = new List<string>();
                if (ListaFiles.Count > 0)
                {
                    ZipFile zip = new ZipFile(rutaDirectorioTemp + rutaNombre);
                    zip.TempFileFolder = rutaDirectorioTemp;
                    int j = 0;
                    foreach (string file in ListaFiles)
                    {
                        if (file != "")
                            zip.AddFile(file, ListaFW[j]);
                        else
                            strERROR.Add(ListaFW[j]);

                        j++;
                    }
                    zip.Save();
                    zip.Dispose();
                }

                if (strERROR.Count() > 0)
                {
                    string strMensaje = "No se encontrarón los sig. documentos: <br>" + string.Join("<br>", strERROR.ToArray()); 
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('" + strMensaje + "','Alerta:','warning');", true);
                }

                Response.ContentType = "application/zip";
                Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", rutaNombre));
                Response.TransmitFile(rutaDirectorioTemp + rutaNombre);
                Response.End();

            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('No se encontrarón filas','Alerta:','warning');", true);
        }
    }

    string ObtenerArchivo(string ruta, string tipo_archivo)
    {
        string strRuta = "";
        ruta = "D:/ServiciosWindows/FacturacacionElectronica/DocumentosOUT/" + ruta;
        //ruta = "C:/Log/TM/FE/" + ruta;
        if (Directory.Exists(ruta))
        {
            string[] txtFiles = Directory.GetFiles(ruta, "*." + tipo_archivo, SearchOption.TopDirectoryOnly);
            foreach (string filenm in txtFiles)
            {
                string NombreFile = Path.GetFileName(filenm);
                strRuta = ruta + "/" + NombreFile;
            }
            
        }
        return strRuta;
    }

    string ObtenerArchivo_v2(string ruta, string tipo_archivo, string valorIniciar)
    {
        string strRuta = "";
        ruta = "D:/ServiciosWindows/FacturacacionElectronica/DocumentosOUT/" + ruta;
        //ruta = "C:/Log/TM/FE/" + ruta;
        
        if (Directory.Exists(ruta))
        {
            string[] txtFiles = Directory.GetFiles(ruta, "*." + tipo_archivo, SearchOption.TopDirectoryOnly);
            foreach (string filenm in txtFiles)
            {
                string NombreFile = Path.GetFileName(filenm);
                if (valorIniciar == "")
                {
                    strRuta = ruta + "/" + NombreFile;
                    break;
                }
                else
                {
                    if (NombreFile.Substring(0,1) == valorIniciar)
                    {
                        strRuta = ruta + "/" + NombreFile;
                        break;
                    }
                    //else
                    //{
                    //    strRuta = ruta + "/" + NombreFile;
                    //    break;
                    //}
                }
            }

        }
        return strRuta;
    }
}