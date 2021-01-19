using BL;
using CrystalDecisions.CrystalReports.Engine;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Modulos_OT_OrdenesTrabajo : System.Web.UI.Page
{

  

    apiRRHH.apiSoapClient api = new apiRRHH.apiSoapClient();

    List<OrdTrabajoDetEL> ListaGeneral = new List<OrdTrabajoDetEL>();

    int id, error = 0;
    string mensaje, extension;

    
   

    protected void Page_Load(object sender, EventArgs e)
    {

        lblProveedor.Visible = false;
        ddlProveedor.Visible = false;
        if (!IsPostBack)
        {
            ListarOrdenesTrabajo();
            loadItems(ddlTecnico, "30");
            ListarConductores();
            loadItems(ddlSede, "29");
            loadItems(ddlServicio, "27");
            loadItems(ddlTipoServicio, "26");
            loadItems(ddlServicioRealizado, "28");
            ListarProveedores();
            loadItemsSistema(lstSistema, "31");

         
            txtHoraSalida.Text = "00:00";

            txtHoraSalida.Enabled = false;
            txtDuracion.Enabled = false;

        }
    }

    public void ListarConductores()
    {

        string xmljson = api.TM_ListarConductores();
        string json = xmljson.Substring(xmljson.IndexOf('['), (xmljson.IndexOf(']') - xmljson.IndexOf('[') + 1));
        ListaGeneral = JsonConvert.DeserializeObject<List<OrdTrabajoDetEL>>(json);
        //ddlConductores.Items.Insert(0, new ListItem("-- TODOS --", ""));

        for (int i = 0; i < ListaGeneral.Count; i++)
        {
            ddlConductores.DataValueField = Convert.ToString(ListaGeneral[i].nro_documento);
            ddlConductores.DataTextField = ListaGeneral[i].nom_conductor;
            ddlConductores.DataSource = ListaGeneral;
            ddlConductores.Items.Add(new ListItem(ListaGeneral[i].nom_conductor, Convert.ToString(ListaGeneral[i].nro_documento)));
            ddlConductores.SelectedIndex = -1;
        }


        //OrdTrabajoDetBL otarBL = new OrdTrabajoDetBL();
        //List<OrdTrabajoDetEL> lst = otarBL.ListarConductores();
        //ddlConductores.Items.Insert(0, new ListItem("-- TODOS --", ""));
        //for (int i = 0; i < lst.Count; i++)
        //{
        //    ddlConductores.DataValueField = Convert.ToString(lst[i].id_conductor);
        //    ddlConductores.DataTextField = lst[i].nom_conductor;
        //    ddlConductores.DataSource = lst;
        //    ddlConductores.Items.Add(new ListItem(lst[i].nom_conductor, Convert.ToString(lst[i].id_conductor)));
        //    ddlConductores.SelectedIndex = -1;
        //}

    }



    public void ListarProveedores()
    {
        OrdTrabajoDetEL oTarEL = new OrdTrabajoDetEL();
        OrdTrabajoDetBL otarBL = new OrdTrabajoDetBL();
        List<OrdTrabajoDetEL> lst = otarBL.ListarProveedores();
        ddlProveedor.Items.Insert(0, new ListItem("-- TODOS --", ""));
        for (int i = 0; i < lst.Count; i++)
        {
            ddlProveedor.DataValueField = Convert.ToString(lst[i].IdProveedor);
            ddlProveedor.DataTextField = lst[i].nom_proveedor;
            ddlProveedor.DataSource = lst;
            ddlProveedor.Items.Add(new ListItem(lst[i].nom_proveedor, Convert.ToString(lst[i].IdProveedor)));
            ddlProveedor.SelectedIndex = -1;
        }

        for (int i = 0; i < lst.Count; i++)
        {
            ddlApeProveedor.DataValueField = Convert.ToString(lst[i].IdProveedor);
            ddlApeProveedor.DataTextField = lst[i].nom_proveedor;
            ddlApeProveedor.DataSource = lst;
            ddlApeProveedor.Items.Add(new ListItem(lst[i].nom_proveedor, Convert.ToString(lst[i].IdProveedor)));
            ddlApeProveedor.SelectedIndex = -1;
        }



    }

    public void ListarTareas(string id_codigo)
    {
        OrdTrabajoDetEL oTarEL = new OrdTrabajoDetEL();
        OrdTrabajoDetBL otarBL = new OrdTrabajoDetBL();
        List<OrdTrabajoDetEL> lst = otarBL.ListarTareas(id_codigo);
        lstTareas.Items.Clear();
        for (int i = 0; i < lst.Count; i++)
        {
            lstTareas.DataValueField = Convert.ToString(lst[i].IdTarea);
            lstTareas.DataTextField = lst[i].nom_tarea;
            lstTareas.DataSource = lst;
            lstTareas.Items.Add(new ListItem(lst[i].nom_tarea, Convert.ToString(lst[i].IdTarea)));
            lstTareas.SelectedIndex = -1;
        }

    }

    public void ListarMateriales(string id_codigo)
    {
        OrdTrabajoDetEL oTarEL = new OrdTrabajoDetEL();
        OrdTrabajoDetBL otarBL = new OrdTrabajoDetBL();
        List<OrdTrabajoDetEL> lst = otarBL.ListarMateriales(id_codigo);
        lstMaterialAgregar.Items.Clear();
        for (int i = 0; i < lst.Count; i++)
        {
            lstMaterialAgregar.DataValueField = Convert.ToString(lst[i].IdMaterial);
            lstMaterialAgregar.DataTextField = lst[i].nom_material;
            lstMaterialAgregar.DataSource = lst;
            lstMaterialAgregar.Items.Add(new ListItem(lst[i].nom_material, Convert.ToString(lst[i].IdMaterial)));
            lstMaterialAgregar.SelectedIndex = -1;
        }

    }

    public void ListarMaterialesTareas(string id_codigo)
    {
        OrdTrabajoDetEL oTarEL = new OrdTrabajoDetEL();
        OrdTrabajoDetBL otarBL = new OrdTrabajoDetBL();
        List<OrdTrabajoDetEL> lst = otarBL.ListarMaterialesTareas(id_codigo);
        grvDataMaterialSelect.DataSource = lst;
        grvDataMaterialSelect.DataBind();
    }

    public void ListarMaterialesTareas(string id_codigo, string id_tarea)
    {

        OrdTrabajoDetEL oTarEL = new OrdTrabajoDetEL();
        OrdTrabajoDetBL otarBL = new OrdTrabajoDetBL();
        List<OrdTrabajoDetEL> lst = otarBL.ListarMaterialesTareas(id_codigo, id_tarea);
        grvDataMaterialSelect.DataSource = lst;
        grvDataMaterialSelect.DataBind();
    }

    public void ListarMaterialesOrden(int id_Orden) 
    {
        OrdTrabajoDetEL oTarEL = new OrdTrabajoDetEL();
        OrdTrabajoDetBL otarBL = new OrdTrabajoDetBL();
        id_Orden = Convert.ToInt32(lblIdOrden.Text);
        List<OrdTrabajoDetEL> lst = otarBL.ListarMaterialesOrden(id_Orden);

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

    public void loadItemsSistema(ListBox ddl, string id_catalogo)
    {
        ItemBL oItem = new ItemBL();
        ddl.DataSource = oItem.ListarItemOpe(id_catalogo);
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
        ddl.SelectedIndex = 0;
    }

    protected void btnAgregar_Command(object sender, CommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Agregar":
                MultiView1.ActiveViewIndex = 2;
                btnRegresar.Visible = false;
                break;
        }
    }

    protected void ddlServicioRealizado_SelectedIndexChanged(object sender, EventArgs e)
    {
        MostrarProveedores();
    }
    public void MostrarProveedores()
    {
        lblProveedor.Visible = false;
        if (ddlServicioRealizado.SelectedValue == "280200")
        {
            ddlProveedor.Visible = true;
            lblProveedor.Visible = true;
            ddlProveedor.Attributes["visibility"] = "visible";
            ddlProveedor.SelectedIndex = 0;
        }
        else
        {
            ddlProveedor.Visible = false;
            lblProveedor.Visible = false;
        }
    }

    protected void btnTareaSelect_Click(object sender, EventArgs e)
    {

    }


    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPlacaTracto.Text != "" || txtPlacaSemiremolque.Text != "")
            {

                if (txtHoraIngreso.Text != "" && txtHoraSalida.Text != "")
                {
                    //int valor = Convert.ToInt32(txtHoraSalida.Text.Substring(0, 2)) - Convert.ToInt32(txtHoraIngreso.Text.Substring(0, 2));
                    //txtDuracion.Text = Convert.ToString(valor);
                    lblvalidaPlaca.Visible = false;
                    if (lblIdOrden.Text == "")
                    {
                        int valor1 = 0;
                        txtDuracion.Text = Convert.ToString(valor1);
                        RegistrarOrdenTrabajo();


                        error = 0;
                        mensaje = "Se registró correctamente";
                    }
                    else
                    {

                        //int horaentrada;
                        //int horasalida;




                        //if (txtHoraIngreso.Text.Length == 4)
                        //{
                        //     horaentrada = int.Parse(txtHoraIngreso.Text.Substring(0, 1));
                        //}
                        //else
                        //{
                        //    horaentrada = int.Parse(txtHoraIngreso.Text.Substring(0, 2));
                        //}

                        //if (txtHoraSalida.Text.Length == 4)
                        //{
                        //    horasalida= int.Parse(txtHoraSalida.Text.Substring(0, 1));
                        //}
                        //else
                        //{
                        //    horasalida = int.Parse(txtHoraSalida.Text.Substring(0, 2));
                        //}


                        //int valor = Convert.ToInt32(txtHoraSalida.Text.Substring(0, 2)) - Convert.ToInt32(txtHoraIngreso.Text.Substring(0, 1));
                        //int valor = horasalida - horaentrada;
                        //txtDuracion.Text = Convert.ToString(valor);
                        EditarOrdenTrabajo();
                        error = 0;
                        mensaje = "Se modificó correctamente";
                        txtHoraSalida.Enabled = false;
                    }
                }
                else
                {
                    lblvalidaPlaca.Visible = false;
                    
                    if (lblIdOrden.Text == "")
                    {
                        int valor1 = 0;
                        txtDuracion.Text = Convert.ToString(valor1);
                        RegistrarOrdenTrabajo();


                        error = 0;
                        mensaje = "Se registró correctamente";
                    }
                    else
                    {
                        
                        int valor = Convert.ToInt32(txtHoraSalida.Text.Substring(0, 2)) - Convert.ToInt32("0" + txtHoraIngreso.Text.Substring(0, 2));
                        txtDuracion.Text = Convert.ToString(valor);
                        EditarOrdenTrabajo();
                        error = 0;
                        mensaje = "Se modificó correctamente";
                        txtHoraSalida.Enabled = false;

                    }

                }
            }
            else
            {
                lblvalidaPlaca.Text = "*Debe llenar alguno de estos campos";
                lblvalidaPlaca.Visible = true;
            }

        }
        catch (Exception ex)
        {

            mensaje = "Ocurrio un error";
            error = 1;
        }
        MultiView1.ActiveViewIndex = 0;
        MostrarMensaje();
        ListarOrdenesTrabajo();
    }

    public void ListarOrdenesTrabajo()
    {
        OrdTrabajoBL oDet = new OrdTrabajoBL();
        OrdTrabajoEL oDetEL = new OrdTrabajoEL();
        List<OrdTrabajoEL> lst = oDet.Listar_OrdenesTrabajo();
        grvDataOrdenesTrabajo.DataSource = lst;
        grvDataOrdenesTrabajo.DataBind();
    }

    public void RegistrarOrdenTrabajo()
    {
        OrdTrabajoBL oTarBL = new OrdTrabajoBL();
        OrdTrabajoEL oTarEL = new OrdTrabajoEL();
        oTarEL.Fecha = txtFecha.Text;
        oTarEL.PlacaTracto = txtPlacaTracto.Text;
        oTarEL.PlacaSemirremolque = txtPlacaSemiremolque.Text;
        oTarEL.HoraIngreso =txtHoraIngreso2.Text+" "+txtHoraIngreso.Text+":00.000";
        oTarEL.HoraSalida =txtHoraSalida2.Text+" "+txtHoraSalida.Text+":00.000";
        oTarEL.DescKilometraje = txtKilometraje.Text;
        oTarEL.Duracion = Convert.ToDecimal(txtDuracion.Text);
        oTarEL.Horometro = txtHorometro.Text;
        oTarEL.Tecnico = ddlTecnico.SelectedValue;
        oTarEL.nro_documento =ddlConductores.SelectedValue;
        oTarEL.CodiSede = ddlSede.SelectedValue;
        oTarEL.CodiServicio = ddlServicio.SelectedValue;
        oTarEL.GrupoArticuloCodiMaterial = ddlTipoServicio.SelectedValue;
        oTarEL.ServRealizado = ddlServicioRealizado.SelectedValue;
        oTarEL.IdProveedor = (ddlProveedor.SelectedValue == "" ? 0 : Convert.ToInt32(ddlProveedor.SelectedValue));
        oTarEL.Descripcion = txtSolicitud.Text;
        string Usuario = ObtenerDatosSesion("codigo");
        List<TransaccionEL> lst = oTarBL.Registrar_OrdTrabajo(oTarEL, Usuario);
        int id_Orden = lst[0].id_mensaje;
        OrdTrabajoDetEL oTarDetEL = new OrdTrabajoDetEL();
        foreach (ListItem item in lstSistemaSelect.Items)
        {
            Usuario = ObtenerDatosSesion("codigo");
            oTarDetEL.IdOrden = id_Orden;
            oTarDetEL.IdTipo = 1;
            oTarDetEL.CodiSistema = item.Value;
            RegistrarDetalleOrdenTrabajo(oTarDetEL, Usuario);
        }
        foreach (ListItem item in lstTareasSelect.Items)
        {
            Usuario = ObtenerDatosSesion("codigo");
            oTarDetEL.IdOrden = id_Orden;
            oTarDetEL.IdTipo = 2;
            oTarDetEL.IdTarea = Convert.ToInt32(item.Value);
            RegistrarDetalleOrdenTrabajo(oTarDetEL, Usuario);
        }
    }

    public void RegistrarOrdenTrabajo2()
    {
        try
        {
            OrdTrabajoBL oTarBL = new OrdTrabajoBL();
            OrdTrabajoEL oTarEL = new OrdTrabajoEL();
            oTarEL.TipoApertura = int.Parse(ddlTipoApertura.SelectedValue);
            oTarEL.PlacaTracto = txtUnidad.Text;
            oTarEL.Descripcion = txtDescripcion.Text;
            oTarEL.Fecha = "";
            oTarEL.PlacaSemirremolque = "";
            oTarEL.HoraIngreso = DateTime.Now.ToString("dd/MM/yyyy") + " "+"00:00:00.000";
            oTarEL.HoraSalida = DateTime.Now.ToString("dd/MM/yyyy") + " " + "00:00:00.000";
            oTarEL.DescKilometraje = "";
            oTarEL.Duracion = Convert.ToDecimal(0.00);
            oTarEL.Horometro = "";
            oTarEL.Tecnico = "";
            oTarEL.nro_documento = "-1";
            oTarEL.CodiSede = "290300";
            oTarEL.CodiServicio = "270100";
            oTarEL.GrupoArticuloCodiMaterial = "260100";
            oTarEL.ServRealizado = "280100";
            oTarEL.IdProveedor = (ddlApeProveedor.SelectedValue == "" ? 0 : Convert.ToInt32(ddlApeProveedor.SelectedValue));
            string Usuario = ObtenerDatosSesion("codigo");
            List<TransaccionEL> lst = oTarBL.Registrar_OrdTrabajo(oTarEL, Usuario);
        }
        catch(Exception ex)
        {
            throw;
        }
        

    }







    public void RegistrarDetalleOrdenTrabajo(OrdTrabajoDetEL objDet, string Usuario)
    {
        OrdTrabajoDetBL oTarDetBL = new OrdTrabajoDetBL();
        List<TransaccionEL> lst2 = oTarDetBL.Registrar_DetalleOrdenTrabajo(objDet, Usuario);
        int id_detalle = lst2[0].id_mensaje;
        if (objDet.IdTipo == 2)
        {
            int i = 0;
            foreach (GridViewRow row in grvDataMaterialSelect.Rows)
            {
                objDet.IdDetalle = id_detalle;
                int id_tarea = objDet.IdTarea;
                if (id_tarea == Convert.ToInt32(grvDataMaterialSelect.DataKeys[i]["IdTarea"].ToString())) {
                    objDet.IdMaterial = Convert.ToInt32((string)grvDataMaterialSelect.DataKeys[i]["CodiMarca"]);
                    objDet.CantiMaterial = Convert.ToInt32((decimal)grvDataMaterialSelect.DataKeys[i]["cantidad"]);
                    RegistrarDetalleOrdenTrabajoTarea(objDet, Usuario);
                }
                i = i + 1;
            }

        }

    }

    public void RegistrarDetalleOrdenTrabajoTarea(OrdTrabajoDetEL objDet, string Usuario)
    {
        OrdTrabajoDetBL oTarDetBL = new OrdTrabajoDetBL();
        OrdTrabajoDetEL oTarDetEL = new OrdTrabajoDetEL();
        List<TransaccionEL> lst3 = oTarDetBL.Registrar_DetalleOrdenTrabajoTarea(objDet, Usuario);
    }

    public void EditarOrdenTrabajo() 
    {
        OrdTrabajoBL oTarBL = new OrdTrabajoBL();
        OrdTrabajoEL oTarEL = new OrdTrabajoEL();
        oTarEL.Fecha = txtFecha.Text;
        oTarEL.PlacaTracto = txtPlacaTracto.Text;
        oTarEL.PlacaSemirremolque = txtPlacaSemiremolque.Text;
        oTarEL.HoraIngreso = txtHoraIngreso2.Text + " " + txtHoraIngreso.Text + ":00.000";
        oTarEL.HoraSalida = txtHoraSalida2.Text + " " + txtHoraSalida.Text + ":00.000";
        oTarEL.DescKilometraje = txtKilometraje.Text;
        //oTarEL.Duracion = Convert.ToDecimal(txtDuracion.Text);
        oTarEL.Horometro = txtHorometro.Text;
        oTarEL.Tecnico = ddlTecnico.SelectedValue;
        oTarEL.nro_documento = ddlConductores.SelectedValue;
        oTarEL.CodiSede = ddlSede.SelectedValue;
        oTarEL.CodiServicio = ddlServicio.SelectedValue;
        oTarEL.GrupoArticuloCodiMaterial = ddlTipoServicio.SelectedValue;
        oTarEL.ServRealizado = ddlServicioRealizado.SelectedValue;
        oTarEL.IdProveedor = (ddlProveedor.SelectedValue == "" ? 0 : Convert.ToInt32(ddlProveedor.SelectedValue));
        oTarEL.Descripcion = txtSolicitud.Text;
        oTarEL.TipoApertura = int.Parse(ddlTipoApertura.SelectedValue);

        string Usuario = ObtenerDatosSesion("codigo");

        if (oTarEL.TipoApertura == 2)
        {
            List<TransaccionEL> lst = oTarBL.Editar_OrdenTrabajo(oTarEL, Convert.ToInt32(HFValor.Value), Usuario);

            OrdTrabajoDetEL oTarDetEL = new OrdTrabajoDetEL();
            foreach (ListItem item in lstSistemaSelect.Items)
            {
                Usuario = ObtenerDatosSesion("codigo");
                oTarDetEL.IdOrden = Convert.ToInt32(HFValor.Value);
                oTarDetEL.IdTipo = 1;
                oTarDetEL.CodiSistema = item.Value;
                if (lblIdOrden.Text != "")
                {
                    RegistrarDetalleOrdenTrabajo(oTarDetEL, Usuario);
                }

            }
            foreach (ListItem item in lstTareasSelect.Items)
            {
                Usuario = ObtenerDatosSesion("codigo");
                oTarDetEL.IdOrden = Convert.ToInt32(HFValor.Value);
                oTarDetEL.IdTipo = 2;
                oTarDetEL.IdTarea = Convert.ToInt32(item.Value);
                if (lblIdOrden.Text != "")
                {
                    RegistrarDetalleOrdenTrabajo(oTarDetEL, Usuario);
                }
            }
        }
        else
        {
                List<TransaccionEL> lst = oTarBL.Editar_OrdenTrabajo(oTarEL, Convert.ToInt32(lblIdOrden.Text), Usuario);
        }


        
    }

    //public void EditarOrdenTrabajo2()
    //{
    //    OrdTrabajoBL oTarBL = new OrdTrabajoBL();
    //    OrdTrabajoEL oTarEL = new OrdTrabajoEL();
    //    oTarEL.Fecha = txtFecha.Text;
    //    oTarEL.PlacaTracto = txtPlacaTracto.Text;
    //    oTarEL.PlacaSemirremolque = txtPlacaSemiremolque.Text;
    //    oTarEL.HoraIngreso = txtHoraIngreso.Text;
    //    oTarEL.HoraSalida = txtHoraSalida.Text;
    //    oTarEL.DescKilometraje = txtKilometraje.Text;
    //    oTarEL.Duracion = Convert.ToDecimal(txtDuracion.Text);
    //    oTarEL.Horometro = txtHorometro.Text;
    //    oTarEL.Tecnico = ddlTecnico.SelectedValue;
    //    oTarEL.nro_documento = ddlConductores.SelectedValue;
    //    oTarEL.CodiSede = ddlSede.SelectedValue;
    //    oTarEL.CodiServicio = ddlServicio.SelectedValue;
    //    oTarEL.GrupoArticuloCodiMaterial = ddlTipoServicio.SelectedValue;
    //    oTarEL.ServRealizado = ddlServicioRealizado.SelectedValue;
    //    oTarEL.IdProveedor = (ddlProveedor.SelectedValue == "" ? 0 : Convert.ToInt32(ddlProveedor.SelectedValue));
    //    oTarEL.Descripcion = txtSolicitud.Text;
    //    string Usuario = ObtenerDatosSesion("codigo");
    //    List<TransaccionEL> lst = oTarBL.Editar_OrdenTrabajo(oTarEL, Convert.ToInt32(lblIdOrden.Text), Usuario);
    //    OrdTrabajoDetEL oTarDetEL = new OrdTrabajoDetEL();
    //    foreach (ListItem item in lstSistemaSelect.Items)
    //    {
    //        Usuario = ObtenerDatosSesion("codigo");
    //        oTarDetEL.IdOrden = Convert.ToInt32(lblIdOrden.Text);
    //        oTarDetEL.IdTipo = 1;
    //        oTarDetEL.CodiSistema = item.Value;
    //        if (lblIdOrden.Text != "")
    //        {
    //            RegistrarDetalleOrdenTrabajo(oTarDetEL, Usuario);
    //        }

    //    }
    //    foreach (ListItem item in lstTareasSelect.Items)
    //    {
    //        Usuario = ObtenerDatosSesion("codigo");
    //        oTarDetEL.IdOrden = Convert.ToInt32(lblIdOrden.Text);
    //        oTarDetEL.IdTipo = 2;
    //        oTarDetEL.IdTarea = Convert.ToInt32(item.Value);
    //        if (lblIdOrden.Text != "")
    //        {
    //            RegistrarDetalleOrdenTrabajo(oTarDetEL, Usuario);
    //        }
    //    }
    //}




    string ObtenerDatosSesion(string tipo)
    {
        string dato = "";
        HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        if (authCookie != null)
        {
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            String dataUser = (authTicket.UserData != null && authTicket.UserData != "" ? authTicket.UserData : "");
            String[] data = dataUser.Split('|');
            if (tipo == "perfil")
            {
                dato = data[3];
            }
            if (tipo == "codigo")
            {
                dato = data[4];
            }
            if (tipo == "nombres")
            {
                dato = data[2];
            }
            if (tipo == "usuario")
            {
                dato = data[1];
            }
        }
        return dato;
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
   
protected void lstSistema_SelectedIndexChanged(object sender, EventArgs e)
    {
        MaintainScrollPositionOnPostBack = true;
        OrdTrabajoEL oTarEL = new OrdTrabajoEL();
        foreach (ListItem item in lstSistema.Items)
        {
            if (item.Selected)
            {
                if (lstSistemaSelect.Items.Contains(item))
                {
                    lblSistema.Visible = true;
                    lblSistema.Text = "Este sistema está seleccionado.";
                }
                else
                {
                    lstSistemaSelect.Items.Add(item);
                    lstSistema.ClearSelection();
                    lblSistema.Visible = false;
                }
            }
        }
    }

    protected void btnEliminarSist_Click(object sender, EventArgs e)
    {
        MaintainScrollPositionOnPostBack = true;
        while (lstSistemaSelect.GetSelectedIndices().Length > 0)
        {
            lstSistemaSelect.Items.Remove(lstSistemaSelect.SelectedItem);
        }

    }

    protected void btnTareaAgregar_Click(object sender, EventArgs e)
    {
        OrdTrabajoDetBL otarBL = new OrdTrabajoDetBL();
        string id_codigo = ddlTipoServicio.SelectedValue;
        string id_tarea = "";
        foreach (ListItem item in lstTareas.Items)
        {
            if (item.Selected)
            {
              
                if (lstTareasSelect.Items.Contains(item))
                {
                    lbltareaSelect.Visible = true;
                    lbltareaSelect.Text = "La tarea esta agregada.";
                }
                else
                {
                    lstTareasSelect.Items.Add(item);
                    lstTareas.ClearSelection();
                    lbltareaSelect.Visible = false;
                } 
            }
        }
        foreach(ListItem item in lstTareasSelect.Items) 
        {
            id_tarea += item.Value + ",";
        }

      

        if (lblIdOrden.Text != "U" && lblIdOrden.Text!="")
        {
            char delimitador = ',';
            string[] valores = id_tarea.Split(delimitador);
            string idTareaLista= valores[valores.Length-2];//hay que revisar si solo tiene una 

            List<OrdTrabajoDetEL> lst = otarBL.ListarMaterialesTareas(id_codigo, idTareaLista);

            OrdTrabajoDetBL oTarDetBL = new OrdTrabajoDetBL();
            List<OrdTrabajoDetEL> listaUno = new List<OrdTrabajoDetEL>();
            listaUno = oTarDetBL.ListarMaterialesOrden(Convert.ToInt32(lblIdOrden.Text));


            //bool Entre = false;
            //int y = 0;
            //for (int i = 0; i < listaUno.Count; i++)
            //{
            //    Entre = false;

            //    for (int x = 0; x < lst.Count; x++)
            //    {
            //        if (listaUno[i].CodiMarca == lst[x].CodiMarca && Entre==false) {
            //            listaUno[i].cantidad = listaUno[i].cantidad + lst[x].cantidad;
            //            Entre = true;
            //            y = x;
            //        }
            //    }
            //    if (Entre==false) {
            //        listaUno.Add(lst[y]);
            //    }
            //}
          
            bool Entre = false;
            //int y = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                Entre = false;

                for (int x = 0; x < listaUno.Count; x++)
                {
                    if (lst[i].CodiMarca == listaUno[x].CodiMarca && Entre == false)
                    {
                        listaUno[x].cantidad = listaUno[x].cantidad + lst[i].cantidad;
                        Entre = true;
                        //y = x;

                        //i = i + 1;
                    }
                    else {
                        //listaUno.Add(lst[i]);
                        //i = i + 1;
                        //i = i + 1;
                    }
                }
                if (Entre == false)
                {
                    listaUno.Add(lst[i]);
                }
            }
       

            //int i = 0;
            //foreach (GridViewRow row in grvDataMaterialSelect.Rows)
            //{
            //    OrdTrabajoDetEL objDet = new OrdTrabajoDetEL();
            //    objDet.IdDetalle = id_detalle;
            //    int id_tarea = objDet.IdTarea;
            //    if (id_tarea == Convert.ToInt32(grvDataMaterialSelect.DataKeys[i]["IdTarea"].ToString()))
            //    {
            //        objDet.IdMaterial = Convert.ToInt32((string)grvDataMaterialSelect.DataKeys[i]["CodiMarca"]);
            //        objDet.CantiMaterial = Convert.ToInt32((decimal)grvDataMaterialSelect.DataKeys[i]["cantidad"]);
            //        RegistrarDetalleOrdenTrabajoTarea(objDet, Usuario);
            //    }
            //    i = i + 1;
            //}



            ////string Usuario = ObtenerDatosSesion("codigo");
            ////OrdTrabajoDetEL objDet = new OrdTrabajoDetEL();
            ////objDet.IdMaterial = Convert.ToInt32(idTareaLista);
            ////objDet.CantiMaterial = Convert.ToInt32((decimal)grvDataMaterialSelect.DataKeys[i]["cantidad"]);
            ////RegistrarDetalleOrdenTrabajoTarea(objDet, Usuario);

            //for (int i = 0; i < lst.Count; i++)
            //{
            //    objDet = new OrdTrabajoDetEL();
            //    objDet.IdOrden = Convert.ToInt32(lblIdOrden.Text);
            //    objDet.IdDetalle = 0;
            //    objDet.IdTarea = Convert.ToInt32(idTareaLista);
            //    objDet.CantiMaterial = lst[i].cantidad;
               
            //    RegistrarDetalleOrdenTrabajoTarea(objDet, Usuario);
            //}

                //oTarDetBL.idor
                grvDataMaterialSelect.DataSource = listaUno;
            grvDataMaterialSelect.DataBind();

          
        }
        else
        {
            List<OrdTrabajoDetEL> lst = otarBL.ListarMaterialesTareas(id_codigo, id_tarea);
            //for (int i=0;i< lst.Count;i++) {
            //    for (int q = 0; q < lst.Count; q++)
            //    {
            //        if (lst[i].CodiMarca== lst[q].CodiMarca) {
            //            lst[i].cantidad = lst[i].cantidad + lst[q].cantidad;
            //        }
            //    }
            //}
            Global Global = new Global();
            Global.ListaGeneral = lst;
            grvDataMaterialSelect.DataSource = lst;
            grvDataMaterialSelect.DataBind();
        }



    }

    protected void btnMaterialesSelect_Click(object sender, EventArgs e)
    {
        try
        {
                foreach (ListItem item in lstMaterialAgregar.Items)
                {
                if (item.Selected)
                {
                    foreach (ListItem item2 in lstTareasSelect.Items)
                    {
                        if (item2.Selected)
                        {
                            lblMaterialAgregar.Visible = false;
                           
                                OrdTrabajoDetEL oTarDetEL = new OrdTrabajoDetEL();
                                int i = 0;
                                int id_Detalle = 0;
                            foreach (GridViewRow row in grvDataMaterialSelect.Rows)
                            {
                                id_Detalle = Convert.ToInt32(grvDataMaterialSelect.DataKeys[i]["IdDetalle"].ToString());
                                i = i + 1;
                            }
                            oTarDetEL.IdDetalle = id_Detalle;
                            if (lblIdOrden.Text == "")
                            {
                                oTarDetEL.IdOrden =0;
                            }
                            else {
                                oTarDetEL.IdOrden = Convert.ToInt32(lblIdOrden.Text);
                            }

                      
                            if (lblIdOrden.Text == "")
                            {
                                //oTarDetEL.IdOrden = 0;
                                //DataTable dt = (DataTable)grvDataMaterialSelect.DataSource;
                                //DataRow row = d t.NewRow();
                                ////foreach (var something in something)
                                ////{
                                ////    row["ColumnName"] = something;
                                ////}
                                //row["cEstado"] ="xd";
                                //dt.Rows.Add(row);
                                //grvDataMaterialSelect.DataSource = dt;

                                //ListaGeneral =(List< OrdTrabajoDetEL>) grvDataMaterialSelect.DataSource;


                                //grvDataMaterialSelect.DataSource = ListaGeneral;
                                //grvDataMaterialSelect.DataBind();
                                //Global Global = new Global();
                                //OrdTrabajoDetEL OrdTrabajoDetEL = new OrdTrabajoDetEL();

                             

                                //OrdTrabajoDetBL oTarDetBL = new OrdTrabajoDetBL();
                                //string Usuario = ObtenerDatosSesion("codigo");
                                bool bEntre=false;
                                for (int q=0;q < Global.ListaGeneral.Count;q++) {
                                    if (item.Value == Global.ListaGeneral[q].CodiMarca) {
                                        bEntre = true;
                                        Global.ListaGeneral[q].cantidad = Global.ListaGeneral[q].cantidad + Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else {
                                      
                                    }
                                }
                                if (bEntre==false) {
                                    oTarDetEL.IdTarea = 0;
                                    oTarDetEL.IdTarea = Convert.ToInt32(item2.Value);
                                    oTarDetEL.IdDetalle = id_Detalle;
                                    oTarDetEL.CodiMarca = item.Value;
                                    oTarDetEL.nom_material = item.Text;
                                    oTarDetEL.cantidad = Convert.ToDecimal(txtCantidad.Text);
                                    Global.ListaGeneral.Add(oTarDetEL);
                                   
                                }

                                grvDataMaterialSelect.DataSource = Global.ListaGeneral;
                                grvDataMaterialSelect.DataBind();
                            }
                            else
                            {
                                oTarDetEL.IdTarea = Convert.ToInt32(item2.Value);
                                oTarDetEL.IdMaterial = Convert.ToInt32(item.Value);
                             if (txtCantidad.Text != "")
                                {
                                    oTarDetEL.CantiMaterial = Convert.ToDecimal(txtCantidad.Text);
                                    OrdTrabajoDetBL oTarDetBL = new OrdTrabajoDetBL();
                                    string Usuario = ObtenerDatosSesion("codigo");
                                    List<TransaccionEL> lst3 = oTarDetBL.Registrar_DetalleOrdenTrabajoTarea(oTarDetEL, Usuario);

                                    grvDataMaterialSelect.DataSource = oTarDetBL.ListarMaterialesOrden(oTarDetEL.IdOrden);
                                    grvDataMaterialSelect.DataBind();
                                }
                                else
                                {
                                    lblCantidad.Text = "Ingrese cantidad";
                                    lblCantidad.Visible = true;
                                }

                                
                            }
                           
                            //listado de detalle Tareas
                            //lo igualo a la grilla
                            //y pongo databinding


                            //foreach (GridViewRow row in grvDataMaterialSelect.Rows)
                            //{
                            //    Label lblDescripcion = (Label)row.Cells[3].FindControl("lblNombreMaterial");
                            //    string valorcantidad = lblDescripcion.Text;
                            //    if (valorcantidad.Equals(item.Text))
                            //    {
                            //        lblMaterialSelect.Visible = true;
                            //        lblMaterialSelect.Text = "El material esta agregado.";
                            //    }
                            //    else
                            //    {
                            //        if (txtCantidad.Text != "")
                            //        {
                            //            OrdTrabajoDetBL oTarDetBL = new OrdTrabajoDetBL();
                            //            string Usuario = ObtenerDatosSesion("codigo");
                            //            List<TransaccionEL> lst3 = oTarDetBL.Registrar_DetalleOrdenTrabajoTarea(oTarDetEL, Usuario);

                            //        }
                            //        else
                            //        {
                            //            lblCantidad.Text = "Ingrese cantidad";
                            //            lblCantidad.Visible = true;
                            //        }
                            //    }
                            //}

                        }
                        else
                        {
                             lblMaterialAgregar.Visible = true;
                             lblMaterialAgregar.Text = "Debe seleccionar una Tarea";
                        }

                    }
   
                }


            }


        }
        catch (Exception ex)
        {

            throw;
        }
       
    }

    protected void btnTareaEliminar_Click(object sender, EventArgs e)
    {
        MaintainScrollPositionOnPostBack = true;
        int idTarea = 0;
        while (lstTareasSelect.GetSelectedIndices().Length > 0)
        {

            foreach (ListItem item in lstTareasSelect.Items)
            {
                //item.Value = "";
                if (item.Selected)
                {

                    //if (lstTareasSelect.Items.Contains(item))
                    //{
                    //    lbltareaSelect.Visible = true;
                    //    lbltareaSelect.Text = "La tarea esta agregada.";
                    //}
                    //else
                    //{
                    //    lstTareasSelect.Items.Add(item);
                    //    lstTareas.ClearSelection();
                    //    lbltareaSelect.Visible = false;

                    //}
                    idTarea=Convert.ToInt32(item.Value);
                }
            }


            
            ////idTarea = Convert.ToInt32(lstTareasSelect.Items.FindByValue(idTarea));
            //Global Global = new Global();
            ////Global.ListaGeneral =;
            ////List<OrdTrabajoDetEL> ListaGeneralNew = new List<OrdTrabajoDetEL>();
            ////List<OrdTrabajoDetEL> ListaGeneralNew =  Global.ListaGeneral;
            //for (int i=0; i< Global.ListaGeneral.Count;i++) {
            //    if (Global.ListaGeneral[i].IdTarea == Convert.ToInt32(lstTareasSelect.SelectedValue)) {
            //        Global.ListaGeneral.Remove(Global.ListaGeneral[i]);
            //        if (i >= 0)
            //        {
            //            i = i - 1;
            //        }
            //        //if (i== Global.ListaGeneral.Count) {
            //        //} 
            //    }
            //}
            ////Global.ListaGeneral = ListaGeneralNew;

            //grvDataMaterialSelect.DataSource = Global.ListaGeneral;
            //grvDataMaterialSelect.DataBind();
            lstTareasSelect.Items.Remove(lstTareasSelect.SelectedItem);
            //idTarea = 6;
        }
        //int i = 0;
        if (grvDataMaterialSelect.Rows.Count > 0)
        {
            //for (int i = 0; i > grvDataMaterialSelect.Rows.Count; i++)
            //{
            //    if (idTarea == Convert.ToInt32(grvDataMaterialSelect.DataKeys[i]["IdTarea"].ToString()))
            //    {
            //        grvDataMaterialSelect.Rows.Remove(DataGridView1.CurrentRow);
            //    }
              
            //}
            //foreach (GridViewRow item in this.grvDataMaterialSelect.SelectedRows)
            //{
            //    //item.RowIndex[0].
            //}
        }
        //foreach (GridViewRow row in grvDataMaterialSelect.Rows)
        //{
        //    //objDet.IdDetalle = id_detalle;
        //    //int id_tarea = objDet.IdTarea;
        //    if (idTarea == Convert.ToInt32(grvDataMaterialSelect.DataKeys[i]["IdTarea"].ToString()))
        //    {
        //        grvDataMaterialSelect.RemoveAt(item.Index);

        //        //    objDet.IdMaterial = Convert.ToInt32((string)grvDataMaterialSelect.DataKeys[i]["CodiMarca"]);
        //        //    objDet.CantiMaterial = Convert.ToInt32((decimal)grvDataMaterialSelect.DataKeys[i]["cantidad"]);
        //        //    RegistrarDetalleOrdenTrabajoTarea(objDet, Usuario);
        //    }
        //    i = i + 1;
        //    grvDataMaterialSelect.RowDeleted;
        //}
    }


    protected void ddlTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id_codigo = ddlTipoServicio.SelectedValue;
        
        //foreach (ListItem item in lstTareas.Items)
        //{
        //    if (item.Selected)
        //    {
        //        id_tarea = Convert.ToInt32(item.Value);
        //        ListarMaterialesTareas(id_codigo, id_tarea);
        //    }
        //}
        ListarTareas(id_codigo);
        ListarMateriales(id_codigo);
        //ListarMaterialesTareas(id_codigo);
        
    }

    protected void grvDataMaterialesSelect_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }

    protected void grvDataMaterialSelect_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string id_codigo = ddlTipoServicio.SelectedValue;
        string id_tarea = lstTareasSelect.SelectedValue;
        //
        //foreach (ListItem item in lstTareasSelect.Items)
        //{
        //    if (item.Selected)
        //    {
                foreach (ListItem item in lstTareasSelect.Items)
                {
                   
                    id_tarea += item.Value + ",";
                }
                grvDataMaterialSelect.EditIndex = e.NewEditIndex;


        if (lblIdOrden.Text != "U"&&lblIdOrden.Text!="")
        {
            OrdTrabajoDetBL oTarDetBL = new OrdTrabajoDetBL();
            //oTarDetBL.idor
            grvDataMaterialSelect.DataSource = oTarDetBL.ListarMaterialesOrden(Convert.ToInt32(HFValor.Value));
            grvDataMaterialSelect.DataBind();
        }
        else
        {
            //OrdTrabajoDetBL otarBL = new OrdTrabajoDetBL();
            //List<OrdTrabajoDetEL> lst = otarBL.ListarMaterialesTareas(id_codigo, id_tarea);
            //grvDataMaterialSelect.DataSource = lst;
            //grvDataMaterialSelect.DataBind();
            grvDataMaterialSelect.DataSource = Global.ListaGeneral;
            grvDataMaterialSelect.DataBind();
        }


        //foreach (GridViewRow row in grvDataMaterialSelect.Rows)
        //{

        //    grvDataMaterialSelect.EditIndex = e.NewEditIndex;
        //    grvDataMaterialSelect.DataBind();
        //    OrdTrabajoBL otarBL = new OrdTrabajoBL();
        //    List<OrdTrabajoEL> lst = otarBL.ListarMaterialesTareas(id_codigo, id_tarea);
        //    grvDataMaterialSelect.DataSource = lst;
        //    grvDataMaterialSelect.DataBind();
        //}

        //}


        //}

    }

    protected void lnkDetalle_Click(object sender, EventArgs e)
    {
        GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
        
        string cantidad = (row.Cells[2].Controls[0] as TextBox).Text;
       
        grvDataMaterialSelect.EditIndex = -1;
        this.DataBind();
        //GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
        //string name = (row.Cells[0].Controls[0] as TextBox).Text;
        //string country = (row.Cells[1].Controls[0] as TextBox).Text;
        //DataTable dt = ViewState["dt"] as DataTable;
        //dt.Rows[row.RowIndex]["Name"] = name;
        //dt.Rows[row.RowIndex]["Country"] = country;
        //ViewState["dt"] = dt;
        //GridView1.EditIndex = -1;
        //this.BindGrid();
    }


    protected void lnkEliminar_Click(object sender, EventArgs e)
{
    grvDataMaterialSelect.EditIndex = -1;
    this.DataBind();
}


    protected void grvDataMaterialSelect_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        string id_codigo = ddlTipoServicio.SelectedValue;
        string id_tarea = lstTareasSelect.SelectedValue;
        foreach (ListItem item in lstTareasSelect.Items)
        {

            id_tarea += item.Value + ",";
        }
        grvDataMaterialSelect.EditIndex = -1;

        if (lblIdOrden.Text != "U" && lblIdOrden.Text!="")
        {
            OrdTrabajoDetBL oTarDetBL = new OrdTrabajoDetBL();
            //oTarDetBL.idor
            grvDataMaterialSelect.DataSource = oTarDetBL.ListarMaterialesOrden(Convert.ToInt32(lblIdOrden.Text));
            grvDataMaterialSelect.DataBind();
        }
        else
        {
            OrdTrabajoDetBL otarBL = new OrdTrabajoDetBL();
            List<OrdTrabajoDetEL> lst = otarBL.ListarMaterialesTareas(ddlTipoServicio.SelectedValue, id_tarea);
            grvDataMaterialSelect.DataSource = lst;
            //ListarMaterialesTareas(id_codigo, id_tarea);
            grvDataMaterialSelect.DataBind();
        }

  
    }

    protected void grvDataMaterialSelect_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow grv = (GridViewRow)grvDataMaterialSelect.Rows[e.RowIndex];
        int id_Detalle = 0;
        id_Detalle = Convert.ToInt32(grvDataMaterialSelect.DataKeys[e.RowIndex]["IdDetalle"].ToString());
        TextBox txtCantidad = (TextBox)grvDataMaterialSelect.Rows[grv.DataItemIndex].Cells[3].FindControl("txtCantidadRow");
        Label lblCodiMarca = (Label)grvDataMaterialSelect.Rows[grv.DataItemIndex].Cells[3].FindControl("lblCodiMarca");
        OrdTrabajoDetBL otarBL = new OrdTrabajoDetBL();
        otarBL.ActualizarCantidadMateriales(Convert.ToDecimal(txtCantidad.Text),Convert.ToInt32(lblCodiMarca.Text), id_Detalle);
        
        string id_tarea = "";
        foreach (ListItem item in lstTareasSelect.Items)
        {

            id_tarea += item.Value + ",";
        }
        grvDataMaterialSelect.EditIndex = -1;

        if (lblIdOrden.Text != "U"&&lblIdOrden.Text!="")
        {
            OrdTrabajoDetBL oTarDetBL = new OrdTrabajoDetBL();
            //oTarDetBL.idor
            grvDataMaterialSelect.DataSource = oTarDetBL.ListarMaterialesOrden(Convert.ToInt32(lblIdOrden.Text));
            grvDataMaterialSelect.DataBind();
        }
        else
        {
            for (int q = 0; q < Global.ListaGeneral.Count; q++)
            {
                if (lblCodiMarca.Text == Global.ListaGeneral[q].CodiMarca)
                {
                    Global.ListaGeneral[q].cantidad = Convert.ToDecimal(txtCantidad.Text);
                }
               
            }

           
            grvDataMaterialSelect.DataSource = Global.ListaGeneral;
            grvDataMaterialSelect.DataBind();
        }


    }



    protected void grvDataOrdenesTrabajo_PreRender(object sender, EventArgs e)
    {
        if (grvDataOrdenesTrabajo.Rows.Count > 0)
        {
            grvDataOrdenesTrabajo.UseAccessibleHeader = true;
            grvDataOrdenesTrabajo.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvDataOrdenesTrabajo.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void grvDataOrdenesTrabajo_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int id_Orden = Convert.ToInt32(e.CommandArgument);
        OrdTrabajoBL oDet = new OrdTrabajoBL();
        OrdTrabajoEL oMat = new OrdTrabajoEL();
        switch (e.CommandName.ToString())
        {
            case "ver":
                SqlConnection scSqlConnection = new SqlConnection("Data Source=10.93.185.21\\SQLTMERIDIAN;Initial Catalog=TM_Flota_QA;User Id=Sa;Password=tm3r1d1@n20");
                SqlCommand scSqlCommand = new SqlCommand();
                scSqlCommand.CommandText = "OT_Listar_Reporte_Ordenes_Trabajo";
                scSqlCommand.Connection = scSqlConnection;
                scSqlCommand.CommandType = CommandType.StoredProcedure;


                //limpiarOrdenesTrabajo();
                List<OrdTrabajoEL> lst = oDet.Listar_DetalleOrdenesTrabajos(id_Orden);
                scSqlCommand.Parameters.AddWithValue("@IdOrden", id_Orden);



                string xmljson = api.TM_ListarConductores();
                string json = xmljson.Substring(xmljson.IndexOf('['), (xmljson.IndexOf(']') - xmljson.IndexOf('[') + 1));
                List<OrdTrabajoDetEL> Lista = JsonConvert.DeserializeObject<List<OrdTrabajoDetEL>>(json);

                var query = (from x in Lista
                             where x.nro_documento == lst[0].nro_documento
                             select x).First().nom_conductor;
                string name = query.ToString();




                scSqlCommand.Parameters.AddWithValue("@nom_conductor", name);
                SqlDataAdapter sdaSqlDataAdapter = new SqlDataAdapter(scSqlCommand);
                scSqlConnection.Open();
                DataTable Tabla = new DataTable();
                Tabla.Load(scSqlCommand.ExecuteReader());
                try
                {
                    ReportDocument myReportDocument = new ReportDocument();
                    myReportDocument.Load(Server.MapPath("ReporteOT.rpt"));
                    //myReportDocument.SetDataSource(Tabla);
                    myReportDocument.SetDatabaseLogon("sa", "tm3r1d1@n20", "10.93.185.21\\SQLTMERIDIAN", "TM_Flota_QA");
                    //myReportDocument.SetParameterValue("@IdOrden", id_Orden);
                    //myReportDocument.SetParameterValue("@nom_conductor", name);

                    myReportDocument.SetParameterValue("@IdOrden", id_Orden);
                    myReportDocument.SetParameterValue("@nom_conductor", name);

                    //myReportDocument.SetParameterValue("@IdOrden", id_Orden, myReportDocument.Subreports[0].Name.ToString());
                    //myReportDocument.SetParameterValue("@IdOrden", id_Orden, myReportDocument.Subreports[1].Name.ToString());
                    //myReportDocument.SetParameterValue("@IdOrden", id_Orden, myReportDocument.Subreports[2].Name.ToString());

                    myReportDocument.SetParameterValue("@IdOrden", id_Orden, myReportDocument.Subreports[0].Name.ToString());
                    myReportDocument.SetParameterValue("@IdOrden", id_Orden, myReportDocument.Subreports[1].Name.ToString());
                    myReportDocument.SetParameterValue("@IdOrden", id_Orden, myReportDocument.Subreports[2].Name.ToString());

                    BinaryReader stream = new BinaryReader(myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment; filename=" + "Orden de Trabajo N° " + id_Orden + ".pdf");
                    Response.AddHeader("content-length", stream.BaseStream.Length.ToString());
                    Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
                    Response.Flush();
                    Response.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                break;

            case "detalle":
                ListarDetalleOrdenesTrabajo(id_Orden);
                MultiView1.ActiveViewIndex = 1;
                btnRegresar.Visible = true;
                break;

            case "eliminar":
                try
                {
                    oDet = new OrdTrabajoBL();
                    oDet.Eliminar_OrdenTrabajo(id_Orden);
                    error = 0;
                    mensaje = "Se eliminó correctamente";
                    MultiView1.ActiveViewIndex = 0;
                }
                catch (Exception ex)
                {
                    mensaje = "Ocurrio un error";
                    error = 1;
                }
                MostrarMensaje();
                ListarOrdenesTrabajo();
                break;
        }
    }

    public void ListarDetalleOrdenesTrabajo(int id_Orden)
    {
        
        OrdTrabajoEL oMat = new OrdTrabajoEL();
        limpiarOrdenesTrabajo();
        OrdTrabajoBL oDet = new OrdTrabajoBL();
        List<OrdTrabajoEL> lst = oDet.Listar_DetalleOrdenesTrabajos(id_Orden);

        HFValor.Value = Convert.ToString(id_Orden);

        txtFecha.Text = lst[0].Fecha;
        txtPlacaTracto.Text = lst[0].PlacaTracto;
        txtPlacaSemiremolque.Text = lst[0].PlacaSemirremolque;
        txtHoraIngreso2.Text =  lst[0].HoraIngreso.Substring(0,10);
        txtHoraIngreso.Text = lst[0].HoraIngreso.Substring(11,5);
        txtHoraSalida2.Text = lst[0].HoraSalida.Substring(0, 10);
        txtHoraSalida.Text = lst[0].HoraSalida.Substring(11, 5);
        txtKilometraje.Text = lst[0].DescKilometraje;
        txtDuracion.Text = Convert.ToString(lst[0].Duracion);
        txtHorometro.Text = lst[0].Horometro;
        ddlTecnico.SelectedValue = lst[0].Tecnico;
        ddlTipoApertura.SelectedValue = lst[0].TipoApertura.ToString();

        if (lst[0].TipoApertura.ToString() =="2")
        {
            lblIdOrden.Text = "U";
        }
        else
        {
            lblIdOrden.Text = Convert.ToString(id_Orden);
        }
            
        
        //if (lst[0].id_conductor>0) {
        //    ddlConductores.SelectedValue = Convert.ToString(lst[0].id_conductor);
        //}

        ddlConductores.SelectedValue = lst[0].nro_documento;
      
        ddlSede.SelectedValue = lst[0].CodiSede;
        ddlServicio.SelectedValue = lst[0].CodiServicio;
        ddlTipoServicio.SelectedValue = lst[0].GrupoArticuloCodiMaterial;
        ddlServicioRealizado.SelectedValue = lst[0].ServRealizado;
        if (Convert.ToString(lst[0].IdProveedor)!="0") {
            ddlProveedor.SelectedValue = Convert.ToString(lst[0].IdProveedor);
        }
        txtSolicitud.Text = lst[0].Descripcion;

        Listar_DetalleOrdenesTrabajo_Sistemas_Tareas(id_Orden);

        if (lst[0].BEstado == 2)
        {
            txtHoraIngreso.Enabled = false;
            txtHoraSalida.Enabled = false;
            txtDuracion.Enabled=false;
        }
        else
        {
            txtHoraSalida.Enabled = true;
        }


    }

    public void Listar_DetalleOrdenesTrabajo_Sistemas_Tareas(int id_Orden)
    {
        OrdTrabajoBL oDet2 = new OrdTrabajoBL();
        OrdTrabajoDetBL oDet = new OrdTrabajoDetBL();
        List<OrdTrabajoDetEL> lst2 = oDet.Listar_DetalleOrdenesTrabajo_Sistemas_Tareas(id_Orden);
        List<OrdTrabajoEL> lstx = oDet2.Listar_DetalleOrdenesTrabajos(id_Orden);


        if (lstx[0].TipoApertura == 2)
        {
            lblIdOrden.Text = "U";
        }
        else
        {
            lblIdOrden.Text = Convert.ToString(id_Orden);
        }


        for (int i = 0; i < lst2.Count; i++)
        {
            if (lst2[i].IdTipo == 1)
            {
                lstSistemaSelect.DataValueField = Convert.ToString(lst2[i].CodiSistema);
                lstSistemaSelect.DataTextField = lst2[i].nom_sistema;
                lstSistemaSelect.DataSource = lst2;
                lstSistemaSelect.Items.Add(new ListItem(lst2[i].nom_sistema, Convert.ToString(lst2[i].CodiSistema)));
            }
            else
            {
                OrdTrabajoBL otarBL = new OrdTrabajoBL();

                string id_codigo = ddlTipoServicio.SelectedValue;
                string id_tarea = Convert.ToString(lst2[i].IdTarea);
                ListarTareas(id_codigo);
                lstTareasSelect.DataValueField = Convert.ToString(lst2[i].IdTarea);
                lstTareasSelect.DataTextField = lst2[i].nom_tarea;
                lstTareasSelect.DataSource = lst2;
                lstTareasSelect.Items.Add(new ListItem(lst2[i].nom_tarea, Convert.ToString(lst2[i].IdTarea)));
                ListarMateriales(id_codigo);
                foreach (ListItem item in lstTareasSelect.Items)
                {
                    id_tarea += item.Value + ",";
                }
                if (lblIdOrden.Text != "")
                {
                    OrdTrabajoDetBL oTarDetBL = new OrdTrabajoDetBL();
                    //oTarDetBL.idor
                    grvDataMaterialSelect.DataSource = oTarDetBL.ListarMaterialesOrden(Convert.ToInt32(HFValor.Value));
                    grvDataMaterialSelect.DataBind();
                }
                else { 
                List<OrdTrabajoDetEL> lst = oDet.ListarMaterialesTareas(id_codigo, id_tarea);
                grvDataMaterialSelect.DataSource = lst;
                grvDataMaterialSelect.DataBind();
                }
                

            }
        }

    }

    public void limpiarOrdenesTrabajo()
    {
        txtFecha.Text = "";
        txtPlacaTracto.Text = "";
        txtPlacaSemiremolque.Text = "";
        txtHoraIngreso.Text = "";
        txtHoraSalida.Text = "";
        txtKilometraje.Text = "";
        txtDuracion.Text = "";
        txtHorometro.Text = "";
        ddlTecnico.Text = "";
        ddlTecnico.SelectedIndex = 0;
        ddlConductores.SelectedIndex = 0;
        ddlConductores.SelectedIndex = 0;
        ddlSede.Text = "";
        ddlSede.SelectedIndex = 0;
        ddlServicio.Text = "";
        ddlServicio.SelectedIndex = 0;
        ddlTipoServicio.Text = "";
        ddlTipoServicio.SelectedIndex = 0;
        ddlServicioRealizado.Text = "";
        ddlServicioRealizado.SelectedIndex = 0;
        ddlProveedor.Text = "";
        ddlProveedor.SelectedIndex = 0;
        lstSistema.ClearSelection();
        lstSistema.SelectedIndex = -1;
        lstSistemaSelect.Items.Clear();
        txtSolicitud.Text = "";
        lstTareas.ClearSelection();
        lstTareas.SelectedIndex = -1;
        lstTareasSelect.Items.Clear();
        grvDataMaterialSelect.DataSource = null;
        grvDataMaterialSelect.DataBind();
    }


    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("OrdenesTrabajo.aspx");
        MultiView1.ActiveViewIndex = 0;
    }

    protected void btnAperturar_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void btnRegistrarApertura_Click(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void btnGuardarApertura_Click(object sender, EventArgs e)
    {

        RegistrarOrdenTrabajo2();
        ListarOrdenesTrabajo();
        MultiView1.ActiveViewIndex = 0;
        error = 0;
        mensaje = "Se registró correctamente";
        MostrarMensaje();


    }

    protected void ddlTipoApertura_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipoApertura.SelectedValue == Convert.ToString("1"))
        {
            MultiView1.ActiveViewIndex = 1;
        }
    }
}