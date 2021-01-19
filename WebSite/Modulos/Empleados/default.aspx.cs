using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using EL;
using DAL;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class cliente_default2 : System.Web.UI.Page
{
    public CatalogoBL objCatalogo = new CatalogoBL();
    public UbigeoBL objUbigeo = new UbigeoBL();
    public EmpleadoBL objEmpleado = new EmpleadoBL();
    public DescansoMedicoBL objDescanso = new DescansoMedicoBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            

            Session["EmpleadoFamilia"] = new List<EmpleadoFamiliaEL>();
            Session["EmpleadoFormacion"] = new List<EmpleadoFormacionEL>();
            Session["EmpleadoIdioma"] = new List<EmpleadoIdiomaEL>();
            Session["EmpleadoInteres"] = new List<EmpleadoInteresEL>();
            Session["EmpleadoExperiencia"] = new List<EmpleadoExperienciaEL>();
            Session["EmpleadoEconomica"] = null;
            Session["EmpleadoVacaciones"] = new List<VacacionesSolicitudEL>();

            if (Request.QueryString["opcion"] == "registro")
            {
                MultiView1.ActiveViewIndex = 1;
            }

            if (Request.QueryString["opcion"] == "documentacion")
            {
                MultiView1.ActiveViewIndex = 2;
            }
            if (Request.QueryString["opcion"] == "ReporteDM")
            {
                MultiView1.ActiveViewIndex = 4;
            }
            if (Request.QueryString["opcion"] == "epp")
            {
                MultiView1.ActiveViewIndex = 5;
            }
            cargarDatos();
            cargarEmpleados();
            
            //setear fecha de inicio
            fchInicio.Text = DateTime.Now.ToString("dd/MM/yyyy");
            // llenarIdioma();

        }
    }

    #region CARGA DE DATOS 
    public void cargarDatos()
    {
        cargarTipoDocumento();
        cargarSexo();
        cargarEstadoCivil();
        cargarDiscapacitado();
        cargarPais();
        cargarDepartamento();
        cargarParentesco();
        cargarGradoInstruccion();
        cargarAnnos();
        cargarIdioma();
        cargarIdiomaNivel();
        cargarInteres();
        cargarBancoEmisor();
        cargarTipoVivienda();
        cargarTipoLicencia();
        cargarMeses();
        cargarTipoPersonal();
        cargarTipoContrato();
        cargarTipoInstitucion();
        cargarMotivoCese();
        cargarProceso();
        cargarPuesto();
        //cargarClinica();
        cargarMotivoEstado();
        cargarMotivo();
        cargarAFP();
        cargarSeguro();
        cargarTipoReporte();

        CargarJefatura();
        CargarEstado();
    }

    public void CargarEstado()
    {
        ddlEstadoPersonal.Items.Clear();
        ddlEstadoPersonal.Items.Add("--TODOS--");
        ddlEstadoPersonal.Items[0].Value = "";
        ddlEstadoPersonal.Items.Add("Activo");
        ddlEstadoPersonal.Items[1].Value = "R";
        ddlEstadoPersonal.Items.Add("Cesado");
        ddlEstadoPersonal.Items[2].Value = "A";
        ddlEstadoPersonal.SelectedIndex = 1;

        CargarJefatura();

    }

    public void cargarTipoDocumento()
    {

        this.ddlTipoDocumento.DataSource = objCatalogo.ListarItem("00");
        ddlTipoDocumento.DataTextField = "descripcion";
        ddlTipoDocumento.DataValueField = "id_descripcion";
        ddlTipoDocumento.DataBind();
        ddlTipoDocumento.Items.Insert(0, new ListItem("--SELECCIONE TIPO DOCUMENTO--", ""));
        ddlTipoDocumento.SelectedIndex = 0;
    }
    public void cargarEstadoCivil()
    {
        this.ddlEstadoCivil.DataSource = objCatalogo.ListarItem("01");
        ddlEstadoCivil.DataTextField = "descripcion";
        ddlEstadoCivil.DataValueField = "id_descripcion";
        ddlEstadoCivil.DataBind();
        ddlEstadoCivil.Items.Insert(0, new ListItem("", ""));
    }
    private void cargarAFP()
    {
        this.ddlAFP.DataSource = objCatalogo.ListarItem("02");
        ddlAFP.DataTextField = "descripcion";
        ddlAFP.DataValueField = "id_descripcion";
        ddlAFP.DataBind();
        ddlAFP.Items.Insert(0, new ListItem("--SELECCIONE AFP--", ""));
        ddlAFP.SelectedIndex = 0;
    }
    private void cargarSeguro()
    {
        this.ddlSeguro.DataSource = objCatalogo.ListarItem("28");
        ddlSeguro.DataTextField = "descripcion";
        ddlSeguro.DataValueField = "id_descripcion";
        ddlSeguro.DataBind();
        ddlSeguro.Items.Insert(0, new ListItem("--SELECCIONE SEGURO--", ""));
        ddlSeguro.SelectedIndex = 0;
    }
    public void cargarSexo()
    {
        this.ddlSexo.DataSource = objCatalogo.ListarItem("04");
        ddlSexo.DataTextField = "descripcion";
        ddlSexo.DataValueField = "id_descripcion";
        ddlSexo.DataBind();
        ddlSexo.Items.Insert(0, new ListItem("", ""));
    }
    public void cargarDiscapacitado()
    {
        this.ddlDiscapacitado.DataSource = objCatalogo.ListarItem("14");
        ddlDiscapacitado.DataTextField = "descripcion";
        ddlDiscapacitado.DataValueField = "id_descripcion";
        ddlDiscapacitado.DataBind();
        ddlDiscapacitado.Items.Insert(0, new ListItem("--SELECCIONE--", ""));
        ddlDiscapacitado.SelectedIndex = 2;

        this.ddlLlamarEmergenciaFamiliar.DataSource = ddlDiscapacitado.DataSource;
        ddlLlamarEmergenciaFamiliar.DataTextField = "descripcion";
        ddlLlamarEmergenciaFamiliar.DataValueField = "id_descripcion";
        ddlLlamarEmergenciaFamiliar.DataBind();
        ddlLlamarEmergenciaFamiliar.Items.Insert(0, new ListItem("", ""));

        this.ddlLee.DataSource = ddlDiscapacitado.DataSource;
        ddlLee.DataTextField = "descripcion";
        ddlLee.DataValueField = "id_descripcion";
        ddlLee.DataBind();
        ddlLee.Items.Insert(0, new ListItem("", ""));

        this.ddlEscribe.DataSource = ddlDiscapacitado.DataSource;
        ddlEscribe.DataTextField = "descripcion";
        ddlEscribe.DataValueField = "id_descripcion";
        ddlEscribe.DataBind();
        ddlEscribe.Items.Insert(0, new ListItem("", ""));

        this.ddlHabla.DataSource = ddlDiscapacitado.DataSource;
        ddlHabla.DataTextField = "descripcion";
        ddlHabla.DataValueField = "id_descripcion";
        ddlHabla.DataBind();
        ddlHabla.Items.Insert(0, new ListItem("", ""));

        //------------
        this.ddlPoseeCtaBanco.DataSource = objCatalogo.ListarItem("14");
        ddlPoseeCtaBanco.DataTextField = "descripcion";
        ddlPoseeCtaBanco.DataValueField = "id_descripcion";
        ddlPoseeCtaBanco.DataBind();
        ddlPoseeCtaBanco.Items.Insert(0, new ListItem("", ""));

        this.ddlPoseTarjBanco.DataSource = objCatalogo.ListarItem("14");
        ddlPoseTarjBanco.DataTextField = "descripcion";
        ddlPoseTarjBanco.DataValueField = "id_descripcion";
        ddlPoseTarjBanco.DataBind();
        ddlPoseTarjBanco.Items.Insert(0, new ListItem("", ""));
        //---------

        this.ddlVigenciaDocumento.DataSource = ddlDiscapacitado.DataSource;
        ddlVigenciaDocumento.DataTextField = "descripcion";
        ddlVigenciaDocumento.DataValueField = "id_descripcion";
        ddlVigenciaDocumento.DataBind();
        //ddlPoseTarjBanco.Items.Insert(0, new ListItem("", ""));

    }

    public void cargarPais()
    {
        this.ddlPais.DataSource = objCatalogo.ListarItem("15");
        ddlPais.DataTextField = "descripcion";
        ddlPais.DataValueField = "id_descripcion";
        ddlPais.DataBind();
        ddlPais.Items.Insert(0, new ListItem("", ""));

        ddlPais.SelectedIndex = 1;

    }
    public void cargarDepartamento()
    {
        this.ddlDepartamento.DataSource = objUbigeo.ListarUbigeo("", "00", "00");
        ddlDepartamento.DataTextField = "descripcion";
        ddlDepartamento.DataValueField = "cod_departamento";
        ddlDepartamento.DataBind();
        ddlDepartamento.Items.Insert(0, new ListItem("", ""));

        ddlDistrito.Items.Clear();
        ddlProvincia.Items.Clear();
        ddlProvincia.Items.Insert(0, new ListItem("", ""));
        ddlDistrito.Items.Insert(0, new ListItem("", ""));
    }
    public void cargarProvincia()
    {
        ddlProvincia.Items.Clear();
        List<UbigeoEL> data = objUbigeo.ListarUbigeo(ddlDepartamento.SelectedValue, "", "00");
        if (data.Count > 0 && ddlDepartamento.SelectedValue != "")
        {
            var query = data.Where(person => person.cod_provincia != "00");
            ddlProvincia.DataSource = query.ToList();
            ddlProvincia.DataTextField = "descripcion";
            ddlProvincia.DataValueField = "cod_provincia";
            ddlProvincia.DataBind();
        }

        ddlProvincia.Items.Insert(0, new ListItem("", ""));
        ddlDistrito.Items.Clear();
        ddlDistrito.Items.Insert(0, new ListItem("", ""));
    }
    public void cargarDistrito()
    {
        ddlDistrito.Items.Clear();
        List<UbigeoEL> data = objUbigeo.ListarUbigeo(ddlDepartamento.SelectedValue, ddlProvincia.SelectedValue, "");
        if (data.Count > 0 && ddlProvincia.SelectedValue != "")
        {
            var query = data.Where(person => person.cod_provincia != "00" && person.cod_distrito != "00");
            ddlDistrito.DataSource = query.ToList();
            ddlDistrito.DataTextField = "descripcion";
            ddlDistrito.DataValueField = "cod_distrito";
            ddlDistrito.DataBind();
        }
        ddlDistrito.Items.Insert(0, new ListItem("", ""));
    }
    public void cargarParentesco()
    {
        this.ddlParentesco.DataSource = objCatalogo.ListarItem("06");
        ddlParentesco.DataTextField = "descripcion";
        ddlParentesco.DataValueField = "id_descripcion";
        ddlParentesco.DataBind();
        ddlParentesco.Items.Insert(0, new ListItem("", ""));
    }
    public void cargarGradoInstruccion()
    {
        this.ddlGradoFormacion.DataSource = objCatalogo.ListarItem("16");
        ddlGradoFormacion.DataTextField = "descripcion";
        ddlGradoFormacion.DataValueField = "id_descripcion";
        ddlGradoFormacion.DataBind();
        ddlGradoFormacion.Items.Insert(0, new ListItem("", ""));
    }
    public void cargarIdioma()
    {
        this.ddlIdioma.DataSource = objCatalogo.ListarItem("07");
        ddlIdioma.DataTextField = "descripcion";
        ddlIdioma.DataValueField = "id_descripcion";
        ddlIdioma.DataBind();
        ddlIdioma.Items.Insert(0, new ListItem("", ""));
    }
    public void cargarIdiomaNivel()
    {
        this.ddlIdiomaNivel.DataSource = objCatalogo.ListarItem("17");
        ddlIdiomaNivel.DataTextField = "descripcion";
        ddlIdiomaNivel.DataValueField = "id_descripcion";
        ddlIdiomaNivel.DataBind();
        ddlIdiomaNivel.Items.Insert(0, new ListItem("", ""));


        this.ddlNivelInteres.DataSource = objCatalogo.ListarItem("17");
        ddlNivelInteres.DataTextField = "descripcion";
        ddlNivelInteres.DataValueField = "id_descripcion";
        ddlNivelInteres.DataBind();
        ddlNivelInteres.Items.Insert(0, new ListItem("", ""));
    }



    public void cargarAnnos()
    {
        int AnnoActual = DateTime.Now.Year;
        int AnnoInicio = AnnoActual - 80;

        for (int i = AnnoInicio; i <= AnnoActual; i++)
        {
            ddlAnnoIntruccionInicio.Items.Insert(0, i.ToString());
            ddlAnnoIntruccionFin.Items.Insert(0, i.ToString());

            ddlExperienciaAnnoFin.Items.Insert(0, i.ToString());
            ddlExperienciaAnnoInicio.Items.Insert(0, i.ToString());
        }
        ddlAnnoIntruccionInicio.Items.Insert(0, new ListItem("", ""));
        ddlAnnoIntruccionFin.Items.Insert(0, new ListItem("", ""));

        ddlExperienciaAnnoFin.Items.Insert(0, new ListItem("", ""));
        ddlExperienciaAnnoInicio.Items.Insert(0, new ListItem("", ""));

    }

    public void cargarMotivoEstado()
    {
        this.ddlMotivoEstado.DataSource = objCatalogo.ListarItem("31");
        ddlMotivoEstado.DataTextField = "descripcion";
        ddlMotivoEstado.DataValueField = "descripcion";
        ddlMotivoEstado.DataBind();
        ddlMotivoEstado.Items.Insert(0, new ListItem("--SELECCIONE MOTIVO--", ""));
    }
    public void cargarInteres()
    {
        this.ddlInteres.DataSource = objCatalogo.ListarItem("09");
        ddlInteres.DataTextField = "descripcion";
        ddlInteres.DataValueField = "id_descripcion";
        ddlInteres.DataBind();
        ddlInteres.Items.Insert(0, new ListItem("", ""));
        ddlInteres.Items.Add(new ListItem("OTROS", "00"));
    }
    public void cargarBancoEmisor()
    {
        this.ddlBancoCta.DataSource = objCatalogo.ListarItem("08");
        ddlBancoCta.DataTextField = "descripcion";
        ddlBancoCta.DataValueField = "id_descripcion";
        ddlBancoCta.DataBind();
        ddlBancoCta.Items.Insert(0, new ListItem("", ""));

        this.ddlBancoTarj.DataSource = ddlBancoCta.DataSource;
        ddlBancoTarj.DataTextField = "descripcion";
        ddlBancoTarj.DataValueField = "id_descripcion";
        ddlBancoTarj.DataBind();
        ddlBancoTarj.Items.Insert(0, new ListItem("", ""));

        this.ddlCtaSueldo.DataSource = ddlBancoCta.DataSource;
        ddlCtaSueldo.DataTextField = "descripcion";
        ddlCtaSueldo.DataValueField = "id_descripcion";
        ddlCtaSueldo.DataBind();
        ddlCtaSueldo.Items.Insert(0, new ListItem("-- SELECCIONA BANCO --", ""));

        this.ddlCtaCTS.DataSource = ddlBancoCta.DataSource;
        ddlCtaCTS.DataTextField = "descripcion";
        ddlCtaCTS.DataValueField = "id_descripcion";
        ddlCtaCTS.DataBind();
        ddlCtaCTS.Items.Insert(0, new ListItem("-- SELECCIONA BANCO --", ""));

    }
    public void cargarTipoVivienda()
    {
        this.ddlTipoVivienda.DataSource = objCatalogo.ListarItem("21");
        ddlTipoVivienda.DataTextField = "descripcion";
        ddlTipoVivienda.DataValueField = "id_descripcion";
        ddlTipoVivienda.DataBind();
        ddlTipoVivienda.Items.Insert(0, new ListItem("", ""));
    }
    public void cargarTipoLicencia()
    {
        this.ddlTipoLicencia.DataSource = objCatalogo.ListarItem("20");
        ddlTipoLicencia.DataTextField = "descripcion";
        ddlTipoLicencia.DataValueField = "id_descripcion";
        ddlTipoLicencia.DataBind();
        ddlTipoLicencia.Items.Insert(0, new ListItem("", ""));
    }
    public void cargarMeses()
    {
        ddlExperienciaMesFin.Items.Add(new ListItem("ENERO", "ENERO"));
        ddlExperienciaMesFin.Items.Add(new ListItem("FEBRERO", "FEBRERO"));
        ddlExperienciaMesFin.Items.Add(new ListItem("MARZO", "MARZO"));
        ddlExperienciaMesFin.Items.Add(new ListItem("ABRIL", "ABRIL"));
        ddlExperienciaMesFin.Items.Add(new ListItem("MAYO", "MAYO"));
        ddlExperienciaMesFin.Items.Add(new ListItem("JUNIO", "JUNIO"));
        ddlExperienciaMesFin.Items.Add(new ListItem("JULIO", "JULIO"));
        ddlExperienciaMesFin.Items.Add(new ListItem("AGOSTO", "AGOSTO"));
        ddlExperienciaMesFin.Items.Add(new ListItem("SEPTIEMBRE", "SEPTIEMBRE"));
        ddlExperienciaMesFin.Items.Add(new ListItem("OCTUBRE", "OCTUBRE"));
        ddlExperienciaMesFin.Items.Add(new ListItem("NOVIEMBRE", "NOVIEMBRE"));
        ddlExperienciaMesFin.Items.Add(new ListItem("DICIEMBRE", "DICIEMBRE"));

        ddlExperienciaMesInicio.Items.Add(new ListItem("ENERO", "ENERO"));
        ddlExperienciaMesInicio.Items.Add(new ListItem("FEBRERO", "FEBRERO"));
        ddlExperienciaMesInicio.Items.Add(new ListItem("MARZO", "MARZO"));
        ddlExperienciaMesInicio.Items.Add(new ListItem("ABRIL", "ABRIL"));
        ddlExperienciaMesInicio.Items.Add(new ListItem("MAYO", "MAYO"));
        ddlExperienciaMesInicio.Items.Add(new ListItem("JUNIO", "JUNIO"));
        ddlExperienciaMesInicio.Items.Add(new ListItem("JULIO", "JULIO"));
        ddlExperienciaMesInicio.Items.Add(new ListItem("AGOSTO", "AGOSTO"));
        ddlExperienciaMesInicio.Items.Add(new ListItem("SEPTIEMBRE", "SEPTIEMBRE"));
        ddlExperienciaMesInicio.Items.Add(new ListItem("OCTUBRE", "OCTUBRE"));
        ddlExperienciaMesInicio.Items.Add(new ListItem("NOVIEMBRE", "NOVIEMBRE"));
        ddlExperienciaMesInicio.Items.Add(new ListItem("DICIEMBRE", "DICIEMBRE"));

    }
    public void cargarTipoPersonal()
    {
        this.ddlTipoPersonal.DataSource = objCatalogo.ListarItem("22");
        ddlTipoPersonal.DataTextField = "descripcion";
        ddlTipoPersonal.DataValueField = "id_descripcion";
        ddlTipoPersonal.DataBind();
        ddlTipoPersonal.Items.Insert(0, new ListItem("--SELECCIONE TIPO PERSONAL--", ""));
    }
    public void cargarTipoContrato()
    {
        this.ddlTipoContrato.DataSource = objCatalogo.ListarItem("23");
        ddlTipoContrato.DataTextField = "descripcion";
        ddlTipoContrato.DataValueField = "id_descripcion";
        ddlTipoContrato.DataBind();
        ddlTipoContrato.Items.Insert(0, new ListItem("-- SELECCIONE TIPO CONTRATO", ""));
    }
    public void cargarMotivoCese()
    {
        this.ddlMotivoCese.DataSource = objCatalogo.ListarItem("05");
        ddlMotivoCese.DataTextField = "descripcion";
        ddlMotivoCese.DataValueField = "id_descripcion";
        ddlMotivoCese.DataBind();
        ddlMotivoCese.Items.Insert(0, new ListItem("--SELECCIONE MOTIVO CESE--", ""));
    }
    public void cargarProceso()
    {
        this.ddlProceso.DataSource = objCatalogo.ListarItem("26");
        ddlProceso.DataTextField = "descripcion";
        ddlProceso.DataValueField = "id_descripcion";
        ddlProceso.DataBind();
        ddlProceso.Items.Insert(0, new ListItem("--SELECCIONE PROCESO--", ""));
    }
    public void cargarPuesto()
    {
        this.ddlCargo.DataSource = objCatalogo.ListarItem("27");
        ddlCargo.DataTextField = "descripcion";
        ddlCargo.DataValueField = "id_descripcion";
        ddlCargo.DataBind();
        ddlCargo.Items.Insert(0, new ListItem("--SELECCIONE PUESTO--", ""));
    }
    public void cargarTipoInstitucion()
    {
        this.ddlTipoInstitucion.DataSource = objCatalogo.ListarItem("24");
        ddlTipoInstitucion.DataTextField = "descripcion";
        ddlTipoInstitucion.DataValueField = "id_descripcion";
        ddlTipoInstitucion.DataBind();
        ddlTipoInstitucion.Items.Insert(0, new ListItem("", ""));
    }
    public void cargarMotivo()
    {
        this.ddlMotivo.DataSource = objCatalogo.ListarItem("29");
        ddlMotivo.DataTextField = "descripcion";
        ddlMotivo.DataValueField = "id_descripcion";
        ddlMotivo.DataBind();
        ddlMotivo.Items.Insert(0, new ListItem("--SELECCIONE MOTIVO--", ""));
    }


    public void CargarJefatura()
    {
        this.ddlJefatura.DataSource = objCatalogo.ListarJefatura();
        ddlJefatura.DataTextField = "descripcion";
        ddlJefatura.DataValueField = "id_descripcion";
        ddlJefatura.DataBind();
        ddlJefatura.Items.Insert(0, new ListItem("--SELECCIONE Jefatura--", ""));
    }
    //public void cargarClinica()
    //{
    //    this.ddlClinica.DataSource = objCatalogo.ListarItem("30");
    //    ddlClinica.DataTextField = "descripcion";
    //    ddlClinica.DataValueField = "id_descripcion";
    //    ddlClinica.DataBind();
    //    ddlClinica.Items.Insert(0, new ListItem("--SELECCIONE CLINICA--", ""));
    //}



    public void cargarTipoReporte()
    {
        ddlTipoR.Items.Clear();
        ddlTipoR.Items.Add("--SELECCIONE TIPO REPORTE--");
        ddlTipoR.Items.Add("DESCANSO");
        ddlTipoR.Items[1].Value = "D";
        ddlTipoR.Items.Add("SUBSIDIO");
        ddlTipoR.Items[2].Value = "S";
    }

    #endregion

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        OcultarModals();
        setTabs();
        li1.Attributes.Add("class", "active");
        MultiView2.ActiveViewIndex = 0;

        Session["EmpleadoFamilia"] = new List<EmpleadoFamiliaEL>();
        Session["EmpleadoFormacion"] = new List<EmpleadoFormacionEL>();
        Session["EmpleadoIdioma"] = new List<EmpleadoIdiomaEL>();
        Session["EmpleadoInteres"] = new List<EmpleadoInteresEL>();
        Session["EmpleadoExperiencia"] = new List<EmpleadoExperienciaEL>();

        gvIdioma.DataSource = null;
        gvIdioma.DataBind();

        gvFamiliares.DataSource = null;
        gvFamiliares.DataBind();

        gvFormacion.DataSource = null;
        gvFormacion.DataBind();

        gvProgramas.DataSource = null;
        gvProgramas.DataBind();

        gvExperiencia.DataSource = null;
        gvExperiencia.DataBind();

        LimpiarFormEmpleado();
    }

    public void LimpiarFormEmpleado()
    {
        HFCodigo.Value = "0";
        HFFotoPersonal.Value = "";
        ddlTipoDocumento.SelectedIndex = 0;
        txtNumeroDocumento.Text = "";
        img.ImageUrl = "~/imagenes/no-user.png";
        txtNombres.Text = "";
        txtApellidoPaterno.Text = "";
        txtApellidoMaterno.Text = "";
        ddlSexo.SelectedIndex = 0;
        ddlEstadoCivil.SelectedIndex = 0;
        txtFechaNacimiento.Text = "";
        ddlPais.SelectedIndex = 0;
        ddlDepartamento.SelectedIndex = 0;
        ddlProvincia.SelectedIndex = 0;
        ddlDistrito.SelectedIndex = 0;
        txtDireccion.Text = "";
        txtNumero.Text = "";
        txtInterior.Text = "";
        txtUrbanizacion.Text = "";
        txtCorreo.Text = "";
        txtTelefono.Text = "";
        txtTelefonoPersonal.Text = "";
        ddlProceso.SelectedIndex = 0;
        ddlCargo.SelectedIndex = 0;
        ddlJefatura.SelectedIndex = 0;
        ddlTipoVivienda.SelectedIndex = 0;
        ddlTipoLicencia.SelectedIndex = 0;
        txtNumLicencia.Text = "";
        ddlDiscapacitado.SelectedIndex = 0;
        txtIndicacionesMedicas.Text = "";
        ddlMotivoCese.SelectedIndex = 0;
        txt_fch_cese.Text = "";
        ddlTipoContrato.SelectedIndex = 0;
        ddlTipoPersonal.SelectedIndex = 0;
        txt_fecha_ingreso.Text = "";

        //Empezando a grabar
        txtVehiculoMarca.Text = "";
        txtVehiculoModelo.Text = "";
        txtVehiculoPlaca.Text = "";
        ddlPoseeCtaBanco.SelectedIndex = 0;
        ddlBancoCta.SelectedIndex = 0;
        ddlBancoTarj.SelectedIndex = 0;
        ddlPoseTarjBanco.SelectedIndex = 0;
        txtOtrosMueblesInmuebles.Text = "";
        //Empezando a grabar

        txtNroCtaSueldo.Text = "";
        txtCCISueldo.Text = "";
        ddlCtaSueldo.SelectedIndex = 0;
        txtNroCtaCTS.Text = "";
        txtCCICTS.Text = "";
        ddlCtaCTS.SelectedIndex = 0;
        ddlSeguro.SelectedIndex = 0;
        txtCodigoIPSS.Text = "";
        txtfchAfiliacionSeguro.Text = "";
        ddlAFP.SelectedIndex = 0;
        txtNombreAFP.Text = "";
        txtFechaInscripcionAFP.Text = "";
        //txtValorActivos.Text = "";
        //txtIngresoEconomicoAdicional.Text = "";
        lon.Text = "";
        lat.Text = "";
        buscar_mapa.Text = "";
        HFCarpetaCompartida.Value = "";

        //---------------------------------
        txtVencidos.Text = "";
        txtPendientes.Text = "";
        txtDisponibles.Text = "";
        txtTruncos.Text = "";
        txtTomados.Text = "";
        //---------------------------------

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void btnRegresarDocumento_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    public void cargarEmpleados()
    {
        gvMarcas.DataSource = objEmpleado.Consultar("",ddlEstadoPersonal.SelectedValue);
        gvMarcas.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            if (string.IsNullOrEmpty(txtApellidoPaterno.Text) || string.IsNullOrEmpty(txtApellidoMaterno.Text))
            {
                //Response.Write("<script>window.alert('Completa todos los campos por favor');</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Los campos apellidos son requeridos.','error');", true);
            }
            else if (string.IsNullOrEmpty(txtNombres.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','El campo nombre  es requerido.','error');", true);
            }
            else if (ddlTipoDocumento.SelectedIndex < 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Seleccione un documento .','error');", true);
            }
            else if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','El campo nro.documento es requerido.','error');", true);
            }
            else if (string.IsNullOrEmpty(txtFechaNacimiento.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Completa tu fecha nacimiento por favor.','error');", true);
            }
            else if (ddlTipoDocumento.SelectedIndex < 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Seleccione un documento .','error');", true);
            }
            else if (ddlSexo.SelectedIndex == 0 || ddlEstadoCivil.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Selecciona el campo sexo o estado civil .','error');", true);
            }
            else if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Completa el campo correo .','error');", true);
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Completa el campo direccion .','error');", true);

            }




            EmpleadoEL empleado = new EmpleadoEL();
            empleado.id_key = Convert.ToInt32(HFCodigo.Value);
            empleado.cod_emp = "";
            empleado.cod_tipo = ddlTipoDocumento.SelectedValue;
            empleado.nro_documento = txtNumeroDocumento.Text;
            empleado.nombre_emp = txtNombres.Text;
            empleado.apellido_pat = txtApellidoPaterno.Text;
            empleado.apellido_mat = txtApellidoMaterno.Text;
            empleado.cod_genero = ddlSexo.SelectedValue;
            empleado.cod_civil = ddlEstadoCivil.SelectedValue;
            empleado.fch_nacimiento = Convert.ToDateTime("01/01/1900");
            DateTime fecha_nacimiendo;
            if (DateTime.TryParse(txtFechaNacimiento.Text, out fecha_nacimiendo))
                empleado.fch_nacimiento = fecha_nacimiendo;

            empleado.nacionalidad = ddlPais.SelectedValue;
            empleado.ubigeo = ddlDepartamento.SelectedValue + ddlProvincia.SelectedValue + ddlDistrito.SelectedValue;
            empleado.domicilio = txtDireccion.Text;
            empleado.nro_domicilio = txtNumero.Text;
            empleado.nro_int = txtInterior.Text;
            empleado.urbanizacion = txtUrbanizacion.Text;

            empleado.email = txtCorreo.Text;
            empleado.telf_trabajo = txtTelefono.Text;
            empleado.telf_personal = txtTelefonoPersonal.Text;
            empleado.cod_dpto_laboral = ddlProceso.SelectedValue;
            empleado.cod_puesto_laboral = ddlCargo.SelectedValue;
            empleado.cod_jefatura = ddlJefatura.SelectedValue;
            empleado.ingreso_mensual_extra = 0;
            //if (txtIngresoEconomicoAdicional.Text.Length > 0)
            //    empleado.ingreso_mensual_extra = Convert.ToDecimal(txtIngresoEconomicoAdicional.Text);
            empleado.tipo_viviendo = ddlTipoVivienda.SelectedValue;
            empleado.tipo_licencia = ddlTipoLicencia.SelectedValue;
            empleado.nro_licencia = txtNumLicencia.Text;
            empleado.observaciones_medicas = txtIndicacionesMedicas.Text;
            //
            empleado.tipo_discapa = ddlDiscapacitado.Text;
            //
            empleado.estado = "R";

            empleado.cod_cese = ddlMotivoCese.SelectedValue;

            empleado.fecha_cese = Convert.ToDateTime("01/01/1900");
            DateTime fecha_cese;
            if (DateTime.TryParse(txt_fch_cese.Text, out fecha_cese))
                empleado.fecha_cese = fecha_cese;

            empleado.tipo_contrato = ddlTipoContrato.SelectedValue;
            empleado.tipo_personal = ddlTipoPersonal.SelectedValue;
            empleado.fch_ingreso = Convert.ToDateTime("01/01/1900");
            DateTime fecha_ingreso;
            if (DateTime.TryParse(txt_fecha_ingreso.Text, out fecha_ingreso))
                empleado.fch_ingreso = fecha_ingreso;
            empleado.nro_cta_sueldo = txtNroCtaSueldo.Text;
            empleado.cci_cta_sueldo = txtCCISueldo.Text;
            empleado.bco_cta_sueldo = ddlCtaSueldo.SelectedValue;
            empleado.nro_cta_cts = txtNroCtaCTS.Text;
            empleado.cci_cta_cts = txtCCICTS.Text;
            empleado.bco_cta_cts = ddlCtaCTS.SelectedValue;
            empleado.cod_seguro = ddlSeguro.SelectedValue;
            empleado.num_afiliacionSeguro = txtCodigoIPSS.Text;
            empleado.fch_afiliacionSeguro = Convert.ToDateTime("01/01/1900");
            DateTime fecha_afiliacionSeguro;
            if (DateTime.TryParse(txtfchAfiliacionSeguro.Text, out fecha_afiliacionSeguro))
                empleado.fch_afiliacionSeguro = fecha_afiliacionSeguro;
            empleado.cod_afiliacionAFP = ddlAFP.SelectedValue;
            empleado.num_afiliacionAFP = txtNombreAFP.Text;
            empleado.fch_afiliacionAFP = Convert.ToDateTime("01/01/1900");
            DateTime fecha_afiliacionAFP;
            if (DateTime.TryParse(txtFechaInscripcionAFP.Text, out fecha_afiliacionAFP))
                empleado.fch_afiliacionAFP = fecha_afiliacionAFP;

            // AGREGADO
            empleado.marca_vehiculo = txtVehiculoMarca.Text;
            empleado.placa_vehiculo = txtVehiculoPlaca.Text;
            empleado.modelo_vehiculo = txtVehiculoModelo.Text;
            empleado.posee_cta_bancaria = ddlPoseeCtaBanco.SelectedValue;
            empleado.banco_cta_bancaria = ddlBancoCta.SelectedValue;
            empleado.banco_tarj_credito = ddlBancoTarj.SelectedValue;
            empleado.posee_tarj_credito = ddlPoseTarjBanco.SelectedValue;
            empleado.otros_muebles = txtOtrosMueblesInmuebles.Text;

            // AGREGADO
            int rptImagen = 0;
            string NomArchivo = HFFotoPersonal.Value;

            if (FUFotoPersonal.HasFile)
            {
                string Extension = Path.GetExtension(FUFotoPersonal.PostedFile.FileName);
                if (Extension == ".jpg" || Extension == ".png" || Extension == ".jpeg" || Extension == ".JPG" || Extension == ".PNG" || Extension == ".JPEG")
                {
                    string Ruta = Server.MapPath("~/Fotos");
                    NomArchivo = txtNumeroDocumento.Text + Extension;
                    FUFotoPersonal.SaveAs(Ruta + "/" + NomArchivo);
                }
                else
                {
                    rptImagen = 1;
                }
            }

            empleado.img_personal = NomArchivo;

            empleado.latitud = lat.Text;
            empleado.longitud = lon.Text;
            empleado.referencia_google_maps = buscar_mapa.Text;
            empleado.carpeta_compartida = "";

            List<TransaccionEL> tnx = new List<TransaccionEL>();
            bool continuar = true;

            if (txtNumLicencia.Text.Equals("") && ddlTipoPersonal.SelectedValue == "220200")
            {

                setTabs();
                li5.Attributes.Add("class", "current");
                li5.Attributes.Add("class", "active");
                MultiView2.ActiveViewIndex = 4;
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Número de brevete es un campo obligatorio. Por favor proceda a registrarlo.','error');", true);


            }
            else
            {
                if (empleado.id_key == 0)
                {
                    if (validar().Equals("OK"))
                    {
                        if (rptImagen == 0)
                        {
                            tnx = objEmpleado.Registrar(empleado);
                            if (tnx[0].id_mensaje != 1)
                            {
                                continuar = false;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('" + tnx[0].mensaje + "','Ocurrio un error','error');", true);
                            }
                        }
                        else
                        {
                            continuar = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Debe ingresar la imagen en el formato correcto','Alerta:','error');", true);
                        }
                    }
                    else
                    {
                        continuar = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('" + validar() + "','Ocurrio un error','error');", true);
                    }
                }
                else
                {
                    string estado = "";
                    if (empleado.cod_cese.Equals(""))
                    {
                        if (empleado.fecha_cese.Equals(""))
                        {
                            empleado.estado = "R";
                        }
                    }
                    else
                    {
                        empleado.estado = "A";
                    }
                    estado = empleado.estado;

                    if (validarDatos(estado).Equals("OK"))
                    {
                        if (validar().Equals("OK"))
                        {
                            if (rptImagen == 0)
                            {
                                tnx = objEmpleado.Actualizar(empleado);
                                if (tnx[0].id_mensaje != 1)
                                {
                                    continuar = false;
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('" + tnx[0].mensaje + "','Ocurrio un error','error');", true);
                                }
                            }
                            else
                            {
                                continuar = false;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Debe ingresar la imagen en el formato correcto','Alerta:','error');", true);
                            }
                        }
                        else
                        {
                            continuar = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('" + validar() + "','Ocurrio un error','error');", true);
                        }

                        //Borrar Detalles
                        tnx = objEmpleado.EliminarDetalle(empleado.id_key);
                        if (tnx[0].id_mensaje != 1)
                        {
                            continuar = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('" + tnx[0].mensaje + "','Ocurrio un error','error');", true);
                        }
                    }
                    else
                    {
                        continuar = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('" + validarDatos(estado) + "','Ocurrio un error','error');", true);
                    }


                }

            }
            if (continuar)
            {

                IList<EmpleadoFamiliaEL> DataFamiliar = (List<EmpleadoFamiliaEL>)Session["EmpleadoFamilia"];
                foreach (EmpleadoFamiliaEL Familiar in DataFamiliar)
                {
                    Familiar.cod_id = Convert.ToInt32(tnx[0].mensaje);
                    objEmpleado.RegistrarFamiliar(Familiar);
                }

                IList<EmpleadoFormacionEL> DataFormacion = (List<EmpleadoFormacionEL>)Session["EmpleadoFormacion"];
                foreach (EmpleadoFormacionEL Formacion in DataFormacion)
                {
                    Formacion.cod_id = Convert.ToInt32(tnx[0].mensaje);
                    objEmpleado.RegistrarFormacion(Formacion);
                }

                IList<EmpleadoIdiomaEL> DataIdioma = (List<EmpleadoIdiomaEL>)Session["EmpleadoIdioma"];
                foreach (EmpleadoIdiomaEL Idioma in DataIdioma)
                {
                    Idioma.cod_id = Convert.ToInt32(tnx[0].mensaje);
                    objEmpleado.RegistrarIdioma(Idioma);
                }

                IList<EmpleadoInteresEL> DataInteres = (List<EmpleadoInteresEL>)Session["EmpleadoInteres"];
                foreach (EmpleadoInteresEL Interes in DataInteres)
                {
                    Interes.cod_id = Convert.ToInt32(tnx[0].mensaje);
                    objEmpleado.RegistrarInteres(Interes);
                }

                IList<EmpleadoExperienciaEL> DataExperiencia = (List<EmpleadoExperienciaEL>)Session["EmpleadoExperiencia"];
                foreach (EmpleadoExperienciaEL Experiencia in DataExperiencia)
                {
                    Experiencia.cod_id = Convert.ToInt32(tnx[0].mensaje);
                    objEmpleado.RegistrarExperiencia(Experiencia);
                }


                if (HFCodigo.Value == "0")
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se registro con éxito.','success');", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se actualizo con éxito','success');", true);
                //    // success / info / warning / error
                if (txtNumLicencia.Text.Equals("") && ddlTipoPersonal.SelectedValue == "220200")
                {

                    setTabs();
                    li5.Attributes.Add("class", "current");
                    li5.Attributes.Add("class", "active");
                    MultiView2.ActiveViewIndex = 4;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Número de brevete es un campo obligatorio. Por favor proceda a registrarlo.','error');", true);


                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                    cargarEmpleados();
                }

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('Ocurrio un error','Error','error');", true);
        }
    }


    protected void gvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id_key = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName.ToString())
        {

            case "editar":
                EditarEmpleado(Convert.ToInt32(e.CommandArgument));
                break;
            case "eliminar":

                List<TransaccionEL> tnx = objEmpleado.Eliminar(id_key);
                if (tnx[0].id_mensaje == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se elimino con éxito.','success');", true);
                    cargarEmpleados();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('" + tnx[0].mensaje + "','Ocurrio un error','error');", true);
                }

                break;
            case "documento":
                String Valor = e.CommandArgument.ToString();
                Response.Redirect("documentacion.aspx?cod=" + Valor);
                break;
            case "EPPS":
                String Valor2 = e.CommandArgument.ToString();
                Response.Redirect("indumentaria.aspx?cod=" + Valor2);
                break;
            case "descanso":
                MultiView1.ActiveViewIndex = 3;
                HFCodigo.Value = e.CommandArgument.ToString();
                ListarConsulta(int.Parse(HFCodigo.Value));
                obtenerNombre();
                totalizar();
                break;
            case "epp":
                MultiView1.ActiveViewIndex = 5;
                HFCodigo.Value = e.CommandArgument.ToString();
                //ListarEPP
                obtenerNombre();
                break;
        }
    }

    public void obtenerNombre()
    {
        DataTable dataEmpleado = objEmpleado.Consultar_PorCodigo(int.Parse(HFCodigo.Value));

        if (dataEmpleado.Rows.Count > 0)
        {
            lblEmp.Text = dataEmpleado.Rows[0]["apellido_pat"].ToString().Trim() + " " + dataEmpleado.Rows[0]["apellido_mat"].ToString().Trim() + " " + dataEmpleado.Rows[0]["nombre_emp"].ToString().Trim();
        }
        if (dataEmpleado.Rows.Count > 0)
        {
            txtConductor.Text = dataEmpleado.Rows[0]["apellido_pat"].ToString().Trim() + " " + dataEmpleado.Rows[0]["apellido_mat"].ToString().Trim() + " " + dataEmpleado.Rows[0]["nombre_emp"].ToString().Trim();
        }

    }
    public int totalizar()
    {
        int dias;
        int total = 0;
        for (int i = 0; i < gvDescansos.Rows.Count; i++)
        {
            dias = Convert.ToInt32(gvDescansos.Rows[i].Cells[5].Text.ToString());
            total += dias;
        }

        lblmsg.Text = " " + total + " ";

        return total;
    }

    public void DocumentoEmpleado(int id_key)
    {

        List<ItemEL> DataCarpetas = objCatalogo.ListarItem("19");
        List<ItemEL> ConfigFileServer = objCatalogo.ListarItem("18");

        if (DataCarpetas.Count > 0 && ConfigFileServer.Count > 0)
        {
            //string carpetaCompartida = ConfigFileServer[0].valor1;
            string carpetaCompartida = ConfigurationManager.AppSettings["PathFiles"];
            if (carpetaCompartida.IndexOf("~") > -1)
            {
                carpetaCompartida = Server.MapPath(carpetaCompartida);
            }

            if (System.IO.Directory.Exists(carpetaCompartida))
            {
                DataTable dataEmpleado = objEmpleado.Consultar_PorCodigo(id_key);
                string CarpetaEmpleado = "";
                string CarpetaEmpleado2 = "";
                if (dataEmpleado.Rows.Count > 0)
                {
                    txtEmpleado_id.Text = id_key.ToString();
                    txtEmpleado.Text = dataEmpleado.Rows[0]["apellido_pat"].ToString().Trim() + " " + dataEmpleado.Rows[0]["apellido_mat"].ToString().Trim() + " " + dataEmpleado.Rows[0]["nombre_emp"].ToString().Trim();
                    CarpetaEmpleado = dataEmpleado.Rows[0]["nro_documento"].ToString() + " - " + txtEmpleado.Text.ToUpper();
                    CarpetaEmpleado2 = dataEmpleado.Rows[0]["nro_documento"].ToString() + " - " + txtEmpleado.Text.ToUpper();
                    CarpetaEmpleado = carpetaCompartida + CarpetaEmpleado;

                    if (dataEmpleado.Rows[0]["carpeta_compartida"].ToString() == "")
                        System.IO.Directory.CreateDirectory(CarpetaEmpleado);
                    else
                    {
                        if (System.IO.Directory.Exists(dataEmpleado.Rows[0]["carpeta_compartida"].ToString()))
                        {
                            if (dataEmpleado.Rows[0]["carpeta_compartida"].ToString() != CarpetaEmpleado && dataEmpleado.Rows[0]["carpeta_compartida"].ToString() != "")
                                System.IO.Directory.Move(dataEmpleado.Rows[0]["carpeta_compartida"].ToString(), CarpetaEmpleado);
                        }
                        else
                            System.IO.Directory.CreateDirectory(CarpetaEmpleado);

                    }
                    //ActualizarRutaCompartida
                    objEmpleado.Actualizar_CarpetaCompartida(id_key, CarpetaEmpleado2);

                    if (DataCarpetas.Count() > 0)
                    {
                        HFCarpetaCompartida.Value = CarpetaEmpleado;
                        foreach (ItemEL documento in DataCarpetas)
                        {
                            if (documento.id_tabla == "00")
                                documento.valor2 = documento.valor1.Substring(0, 3).Trim();
                            else
                                documento.valor2 = documento.valor1.Substring(0, 4).Trim();
                            //documento.valor1 = documento.valor1.Substring(4).Trim();
                            //documento.valor3 = ConfigFileServer[0].valor1 + documento.valor1;
                        }

                        List<ItemEL> CarpetasN1 = DataCarpetas.Where(f => f.id_tabla == "00").ToList();
                        gvCarpetaN1.DataSource = CarpetasN1;
                        gvCarpetaN1.DataBind();

                        //gvCarpetaN1.Rows[0].CssClass = "selected";
                        HFCarpetaFicha.Value = gvCarpetaN1.DataKeys[0].Value.ToString();

                        foreach (GridViewRow row in gvCarpetaN1.Rows)
                        {
                            GridView gvCarpetaN1_detalle = (GridView)row.FindControl("gvCarpetaN1_detalle");
                            gvCarpetaN1_detalle.Visible = false;
                        }
                    }
                    btnAgregarArchivo.Visible = false;
                    MultiView1.ActiveViewIndex = 2;
                }
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('No existe la carpeta compartida: " + carpetaCompartida + "'','Ocurrio un error','error');", true);

        }
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('No se encontro la direcicón de la carpeta compartida','Ocurrio un error','error');", true);

    }
    public void EditarEmpleado(int id_key)
    {
        DataTable dataEmpleado = objEmpleado.Consultar_PorCodigo(id_key);

        if (dataEmpleado.Rows.Count > 0)

        {
            OcultarModals();
            setTabs();
            li1.Attributes.Add("class", "active");
            MultiView2.ActiveViewIndex = 0;
            LimpiarFormEmpleado();

            this.HFCodigo.Value = id_key.ToString();

            ddlTipoDocumento.SelectedValue = dataEmpleado.Rows[0]["cod_tipo"].ToString().Trim();
            txtNumeroDocumento.Text = dataEmpleado.Rows[0]["nro_documento"].ToString().Trim();

            txtNombres.Text = dataEmpleado.Rows[0]["nombre_emp"].ToString().Trim();
            txtApellidoPaterno.Text = dataEmpleado.Rows[0]["apellido_pat"].ToString().Trim();
            txtApellidoMaterno.Text = dataEmpleado.Rows[0]["apellido_mat"].ToString().Trim();

            ddlSexo.SelectedValue = dataEmpleado.Rows[0]["cod_genero"].ToString().Trim();
            ddlEstadoCivil.SelectedValue = dataEmpleado.Rows[0]["cod_civil"].ToString().Trim();
            txtFechaNacimiento.Text = dataEmpleado.Rows[0]["fch_nacimiento"].ToString().Trim();
            ddlPais.SelectedValue = dataEmpleado.Rows[0]["nacionalidad"].ToString().Trim();

            if (dataEmpleado.Rows[0]["ubigeo"].ToString().Length == 6)
            {
                ddlDepartamento.SelectedValue = dataEmpleado.Rows[0]["ubigeo"].ToString().Substring(0, 2);
                cargarProvincia();
                ddlProvincia.SelectedValue = dataEmpleado.Rows[0]["ubigeo"].ToString().Substring(2, 2);
                cargarDistrito();
                ddlDistrito.SelectedValue = dataEmpleado.Rows[0]["ubigeo"].ToString().Substring(4, 2);
            }

            txtDireccion.Text = dataEmpleado.Rows[0]["domicilio"].ToString().Trim();
            txtNumero.Text = dataEmpleado.Rows[0]["nro_domicilio"].ToString().Trim();
            txtInterior.Text = dataEmpleado.Rows[0]["nro_int"].ToString().Trim();
            txtUrbanizacion.Text = dataEmpleado.Rows[0]["urbanizacion"].ToString().Trim();
            ddlAFP.SelectedValue = dataEmpleado.Rows[0]["cod_afiliacionAFP"].ToString().Trim();

            txtNombreAFP.Text = dataEmpleado.Rows[0]["num_afiliacionAFP"].ToString().Trim();

            //txtFechaInscripcionAFP.Text = dataEmpleado.Rows[0]["fch_afiliacionAFP"].ToString().Trim();

            if (dataEmpleado.Rows[0]["fch_afiliacionAFP"].ToString().Trim().Equals("01/01/1900"))
            {
                txtFechaInscripcionAFP.Text = "";
            }
            else
            {
                txtFechaInscripcionAFP.Text = dataEmpleado.Rows[0]["fch_afiliacionAFP"].ToString().Trim();
            }

            txtCorreo.Text = dataEmpleado.Rows[0]["email"].ToString().Trim();
            txtTelefono.Text = dataEmpleado.Rows[0]["telf_trabajo"].ToString().Trim();
            txtTelefonoPersonal.Text = dataEmpleado.Rows[0]["telf_personal"].ToString().Trim();
            ddlProceso.SelectedValue = dataEmpleado.Rows[0]["cod_dpto_laboral"].ToString().Trim();
            ddlCargo.SelectedValue = dataEmpleado.Rows[0]["cod_puesto_laboral"].ToString().Trim();
            ddlJefatura.SelectedValue = dataEmpleado.Rows[0]["cod_jefatura"].ToString().Trim();
            //txtIngresoEconomicoAdicional.Text = dataEmpleado.Rows[0]["ingreso_mensual_extra"].ToString().Trim();
            //***************************//
            ddlTipoVivienda.SelectedValue = dataEmpleado.Rows[0]["tipo_viviendo"].ToString().Trim();
            ddlTipoLicencia.SelectedValue = dataEmpleado.Rows[0]["tipo_licencia"].ToString().Trim();
            txtNumLicencia.Text = dataEmpleado.Rows[0]["nro_licencia"].ToString().Trim();
            txtIndicacionesMedicas.Text = dataEmpleado.Rows[0]["observaciones_medicas"].ToString().Trim();

            ddlDiscapacitado.SelectedValue = dataEmpleado.Rows[0]["tipo_discapa"].ToString().Trim();

            if (dataEmpleado.Rows[0]["fecha_cese"].ToString().Trim().Equals("01/01/1900"))
            {
                txt_fch_cese.Text = "";
            }
            else
            {
                txt_fch_cese.Text = dataEmpleado.Rows[0]["fecha_cese"].ToString().Trim();
            }

            //if (dataEmpleado.Rows[0]["fecha_cese"].ToString().Trim() != null)
            //    txt_fch_cese.Text = dataEmpleado.Rows[0]["fecha_cese"].ToString();

            ddlMotivoCese.SelectedValue = dataEmpleado.Rows[0]["cod_cese"].ToString().Trim();
            lat.Text = dataEmpleado.Rows[0]["latitud"].ToString().Trim();
            lon.Text = dataEmpleado.Rows[0]["longitud"].ToString().Trim();
            buscar_mapa.Text = dataEmpleado.Rows[0]["referencia_google_maps"].ToString().Trim();
            ddlTipoContrato.SelectedValue = dataEmpleado.Rows[0]["tipo_contrato"].ToString().Trim();
            ddlTipoPersonal.SelectedValue = dataEmpleado.Rows[0]["tipo_personal"].ToString().Trim();

            txt_fecha_ingreso.Text = dataEmpleado.Rows[0]["fch_ingreso"].ToString().Trim();

            if (dataEmpleado.Rows[0]["fch_ingreso"].ToString().Trim() != "01/01/1900")
                txt_fecha_ingreso.Text = dataEmpleado.Rows[0]["fch_ingreso"].ToString().Trim();

            ddlSeguro.SelectedValue = dataEmpleado.Rows[0]["cod_seguro"].ToString().Trim();
            txtCodigoIPSS.Text = dataEmpleado.Rows[0]["num_afiliacionSeguro"].ToString().Trim();

            //txtfchAfiliacionSeguro.Text = dataEmpleado.Rows[0]["fch_afiliciacionSeguro"].ToString().Trim();

            if (dataEmpleado.Rows[0]["fch_afiliciacionSeguro"].ToString().Trim().Equals("01/01/1900"))
            {
                txtfchAfiliacionSeguro.Text = "";
            }
            else
            {
                txtfchAfiliacionSeguro.Text = dataEmpleado.Rows[0]["fch_afiliciacionSeguro"].ToString().Trim();
            }

            txtNroCtaSueldo.Text = dataEmpleado.Rows[0]["nro_cta_sueldo"].ToString().Trim();
            txtCCISueldo.Text = dataEmpleado.Rows[0]["cci_cta_sueldo"].ToString().Trim();
            ddlCtaSueldo.SelectedValue = dataEmpleado.Rows[0]["bco_cta_sueldo"].ToString().Trim();
            txtNroCtaCTS.Text = dataEmpleado.Rows[0]["nro_cta_cts"].ToString().Trim();
            txtCCICTS.Text = dataEmpleado.Rows[0]["cci_cta_cts"].ToString().Trim();
            ddlCtaCTS.SelectedValue = dataEmpleado.Rows[0]["bco_cta_cts"].ToString().Trim();

            // AGREGADOOOOO
            txtVehiculoMarca.Text = dataEmpleado.Rows[0]["marca_vehiculo"].ToString().Trim();
            txtVehiculoPlaca.Text = dataEmpleado.Rows[0]["placa_vehiculo"].ToString().Trim();
            txtVehiculoModelo.Text = dataEmpleado.Rows[0]["modelo_vehiculo"].ToString().Trim();
            ddlPoseeCtaBanco.SelectedValue = dataEmpleado.Rows[0]["posee_cta_bancaria"].ToString().Trim();
            ddlBancoCta.SelectedValue = dataEmpleado.Rows[0]["banco_cta_bancaria"].ToString().Trim();
            ddlBancoTarj.SelectedValue = dataEmpleado.Rows[0]["banco_tarj_credito"].ToString().Trim();
            ddlPoseTarjBanco.SelectedValue = dataEmpleado.Rows[0]["posee_tarj_credito"].ToString().Trim();
            txtOtrosMueblesInmuebles.Text = dataEmpleado.Rows[0]["otros_muebles"].ToString().Trim();
            // AGREGADOOOOO


            HFFotoPersonal.Value = dataEmpleado.Rows[0]["img_personal"].ToString().Trim();

            //Evaluando si tiene foto
            if (dataEmpleado.Rows[0]["img_personal"].ToString().Trim() != "")
            {
                img.ImageUrl = "http://10.93.185.22/intranet/Fotos/" + dataEmpleado.Rows[0]["img_personal"].ToString().Trim();
            }
            else
            {
                img.ImageUrl = "http://10.93.185.22/intranet/imagenes/no-user.png";
            }

            //Cargando Detalle
            IList<EmpleadoFamiliaEL> DataFamiliar = objEmpleado.Consultar_EmpleadoFamiliar_PorCodigo(id_key);
            Session["EmpleadoFamilia"] = DataFamiliar;
            gvFamiliares.DataSource = DataFamiliar;
            gvFamiliares.DataBind();


            IList<EmpleadoIdiomaEL> DataIdioma = objEmpleado.Consultar_EmpleadoIdioma_PorCodigo(id_key);
            Session["EmpleadoIdioma"] = DataIdioma;
            gvIdioma.DataSource = DataIdioma;
            gvIdioma.DataBind();

            IList<EmpleadoInteresEL> DataPrograma = objEmpleado.Consultar_EmpleadoInteres_PorCodigo(id_key);
            Session["EmpleadoInteres"] = DataPrograma;
            gvProgramas.DataSource = DataPrograma;
            gvProgramas.DataBind();

            IList<EmpleadoFormacionEL> DataFormacion = objEmpleado.Consultar_EmpleadoFormacion_PorCodigo(id_key);
            Session["EmpleadoFormacion"] = DataFormacion;
            gvFormacion.DataSource = DataFormacion;
            gvFormacion.DataBind();


            IList<EmpleadoExperienciaEL> DataExperiencia = objEmpleado.Consultar_ExperienciaInteres_PorCodigo(id_key);
            Session["EmpleadoExperiencia"] = DataExperiencia;
            gvExperiencia.DataSource = DataExperiencia;
            gvExperiencia.DataBind();

            IList<VacacionesSolicitudEL> DataVacaciones = objEmpleado.ListarVacacionesRRHH(id_key);
            Session["EmpleadoVacaciones"] = DataVacaciones;
            grvVacaciones.DataSource = DataVacaciones;
            grvVacaciones.DataBind();
            ListarVacaciones(int.Parse(HFCodigo.Value));


            // = new List<EmpleadoFamiliaEL>();
            //Session["EmpleadoFormacion"] = new List<EmpleadoFormacionEL>();
            //Session["EmpleadoIdioma"] = new List<EmpleadoIdiomaEL>();
            //Session["EmpleadoInteres"] = new List<EmpleadoInteresEL>();
            //Session["EmpleadoExperiencia"] = new List<EmpleadoExperienciaEL>();

            MultiView1.ActiveViewIndex = 1;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('No se encontro información del empleado','Error:','error');", true);
            // success / info / warning / error
        }
    }

    public void ActualizarEmpleado1(int id)
    {
        IList<EmpleadoFamiliaEL> DataFamiliar;

        DataFamiliar = (IList<EmpleadoFamiliaEL>)Session["EmpleadoFamilia"];
        for (int i = 0; i < DataFamiliar.Count; i++)
        {
            if (DataFamiliar[i].id_key == id)
            {
                DataFamiliar[i].fam_apellido_pat = txtApellidoPaternoFamiliar.Text;
                DataFamiliar[i].fam_apellido_mat = txtApellidoMaternoFamiliar.Text;
                DataFamiliar[i].fam_nombre = txtNombresFamiliar.Text;
                DataFamiliar[i].cod_parentesco = ddlParentesco.SelectedValue;
                DataFamiliar[i].opcional_parentesco = ddlParentesco.SelectedItem.Text;
                DataFamiliar[i].fch_nacimiento = Convert.ToDateTime(txtFechaNacimientoFamiliar.Text);
                DataFamiliar[i].lugar_nacimiento = txtLugarNacimientoFamiliar.Text;
                DataFamiliar[i].edad = (DateTime.Today.AddTicks(-Convert.ToDateTime(txtFechaNacimientoFamiliar.Text).Ticks).Year) - 1;
                DataFamiliar[i].lugar_trabajo = txtLugarTrabajoFamiliar.Text;
                DataFamiliar[i].telf_of = txtTelefonoOficinaFamiliar.Text;
                DataFamiliar[i].telf_casa = txtTelefonoCasaFamiliar.Text;
                DataFamiliar[i].llamar_emergencia = ddlLlamarEmergenciaFamiliar.SelectedValue;
                DataFamiliar[i].opcional_llamar_emergencia = ddlLlamarEmergenciaFamiliar.SelectedItem.Text;
            }

        }
        Session["EmpleadoFamilia"] = DataFamiliar;
        gvFamiliares.DataSource = DataFamiliar;
        gvFamiliares.DataBind();

    }

    public void ActualizarFormacion(int id)
    {
        IList<EmpleadoFormacionEL> DataFormacion;
        DataFormacion = (IList<EmpleadoFormacionEL>)Session["EmpleadoFormacion"];
        for (int i = 0; i < DataFormacion.Count; i++)
        {
            if (DataFormacion[i].id_key == id)
            {
                DataFormacion[i].cod_grado_instruccion = ddlGradoFormacion.SelectedValue;
                DataFormacion[i].opcional_instruccion = ddlGradoFormacion.SelectedItem.Text;
                DataFormacion[i].cod_institucion = txtCentroInstruccion.Text;
                DataFormacion[i].opcional_institucion = txtCentroInstruccion.Text;
                DataFormacion[i].observaciones = "";
                DataFormacion[i].titulo = txtTitulo.Text;
                DataFormacion[i].anio_inicio = ddlAnnoIntruccionInicio.SelectedValue;
                DataFormacion[i].anio_fin = ddlAnnoIntruccionFin.SelectedValue;

            }
        }
        Session["EmpleadoFormacion"] = DataFormacion;
        gvFormacion.DataSource = DataFormacion;
        gvFormacion.DataBind();
    }
    public void ActualizarIdioma(int id)
    {

        IList<EmpleadoIdiomaEL> DataIdioma;
        DataIdioma = (IList<EmpleadoIdiomaEL>)Session["EmpleadoIdioma"];
        for (int i = 0; i < DataIdioma.Count; i++)
        {
            if (DataIdioma[i].id_key == id)
            {

                DataIdioma[i].cod_idioma = ddlIdioma.SelectedValue;
                DataIdioma[i].opcional_idioma = ddlIdioma.SelectedItem.Text;
                DataIdioma[i].cod_nivel = ddlIdiomaNivel.SelectedValue;
                DataIdioma[i].opcional_nivel = ddlIdiomaNivel.SelectedItem.Text;
                DataIdioma[i].institucion = txtIdiomaInstruccion.Text;
                DataIdioma[i].n_habla = ddlHabla.SelectedValue;
                DataIdioma[i].opcional_habla = ddlHabla.SelectedItem.Text;
                DataIdioma[i].n_lee = ddlLee.SelectedValue;
                DataIdioma[i].opcional_lee = ddlLee.SelectedItem.Text;
                DataIdioma[i].n_escritura = ddlEscribe.SelectedValue;
                DataIdioma[i].opcional_escritura = ddlEscribe.SelectedItem.Text;
            }
        }

        Session["EmpleadoIdioma"] = DataIdioma;
        gvIdioma.DataSource = DataIdioma;
        gvIdioma.DataBind();

    }

    public void ActualizarInteres(int id)
    {
        IList<EmpleadoInteresEL> DataPrograma;
        DataPrograma = (IList<EmpleadoInteresEL>)Session["EmpleadoInteres"];

        //recorrer la sesion
        for (int i = 0; i < DataPrograma.Count; i++)
        {
            if (DataPrograma[i].id_key == id)
            {
                DataPrograma[i].cod_interes = ddlInteres.SelectedValue;
                DataPrograma[i].opcional_interes = ddlInteres.SelectedItem.Text;
                DataPrograma[i].cod_nivel = ddlNivelInteres.SelectedValue;
                DataPrograma[i].opcional_nivel = ddlNivelInteres.SelectedItem.Text;
                DataPrograma[i].observacion = txtIdiomaInstruccion.Text;
                DataPrograma[i].desc_interes = txtOtrosCurso.Text;

            }
        }

        Session["EmpleadoInteres"] = DataPrograma;
        gvProgramas.DataSource = DataPrograma;
        gvProgramas.DataBind();
    }

    public void ActualizarExperienciaP(int id)
    {
        IList<EmpleadoExperienciaEL> DataExperiencia;
        DataExperiencia = (IList<EmpleadoExperienciaEL>)Session["EmpleadoExperiencia"];

        for (int i = 0; i < DataExperiencia.Count; i++)
        {
            if (DataExperiencia[i].id_key == id)
            {

                DataExperiencia[i].cod_cargo_laboral = "00";
                DataExperiencia[i].des_cargo_laboral = txtExperienciaCargo.Text;
                DataExperiencia[i].nom_empresa = txtExperienciaEmpresa.Text;
                DataExperiencia[i].ubicacion = "";
                DataExperiencia[i].anio_fin = ddlExperienciaAnnoFin.SelectedValue;
                DataExperiencia[i].mes_fin = ddlExperienciaMesFin.SelectedValue;
                DataExperiencia[i].mes_inicio = ddlExperienciaMesInicio.SelectedValue;
                DataExperiencia[i].anio_inicio = ddlExperienciaAnnoInicio.SelectedValue;
                DataExperiencia[i].observaciones = txtExperienciaObservacion.Text;

            }
        }

        Session["EmpleadoExperiencia"] = DataExperiencia;
        gvExperiencia.DataSource = DataExperiencia;
        gvExperiencia.DataBind();
    }




    /**********************************************************************/
    public void ListarVacaciones(int id)
    {
        EmpleadoBL oReporte = new EmpleadoBL();
        VacacionesSolicitudEL objReporte = new VacacionesSolicitudEL();
        objReporte.id_empleado = id;
        List<VacacionesReporteEL> lst4 = oReporte.ListarReporte(id);

        if (lst4.Count > 0)
        {
            txtVencidos.Text = Convert.ToString(lst4[0].diasVencidos);
            txtPendientes.Text = Convert.ToString(lst4[0].diasPendientes);
            txtDisponibles.Text = Convert.ToString(lst4[0].total);
            txtTruncos.Text = Convert.ToString(lst4[0].diasTruncos);
            txtTomados.Text = Convert.ToString(lst4[0].diasTomados);
        }
    }
    /**********************************************************************/

    protected void gvMarcas_PreRender(object sender, EventArgs e)
    {
        if (gvMarcas.Rows.Count > 0)
        {
            gvMarcas.UseAccessibleHeader = true;
            gvMarcas.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvMarcas.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void gvFormacion_PreRender(object sender, EventArgs e)
    {
        if (gvFormacion.Rows.Count > 0)
        {
            gvFormacion.UseAccessibleHeader = true;
            gvFormacion.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvFormacion.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void gvFamiliares_PreRender(object sender, EventArgs e)
    {
        if (gvFamiliares.Rows.Count > 0)
        {
            gvFamiliares.UseAccessibleHeader = true;
            gvFamiliares.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvFamiliares.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void gvIdioma_PreRender(object sender, EventArgs e)
    {
        if (gvIdioma.Rows.Count > 0)
        {
            gvIdioma.UseAccessibleHeader = true;
            gvIdioma.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvIdioma.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void gvProgramas_PreRender(object sender, EventArgs e)
    {
        if (gvProgramas.Rows.Count > 0)
        {
            gvProgramas.UseAccessibleHeader = true;
            gvProgramas.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvProgramas.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void gvExperiencia_PreRender(object sender, EventArgs e)
    {
        if (gvExperiencia.Rows.Count > 0)
        {
            gvExperiencia.UseAccessibleHeader = true;
            gvExperiencia.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvExperiencia.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void gvDocumentos_PreRender(object sender, EventArgs e)
    {
        if (gvDocumentos.Rows.Count > 0)
        {
            gvDocumentos.UseAccessibleHeader = true;
            gvDocumentos.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvDocumentos.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void gvCarpetaN1_PreRender(object sender, EventArgs e)
    {
        if (gvCarpetaN1.Rows.Count > 0)
        {
            gvCarpetaN1.UseAccessibleHeader = true;
            gvCarpetaN1.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvCarpetaN1.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void btnExportar_Click(object sender, EventArgs e)
    {

        var GridView1 = new GridView();
        GridView1.DataSource = objEmpleado.Exportar();
        GridView1.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attacNhment;filename=ReporteEmpleados_" + DateTime.Now.ToString("ddMMyyyy") + ".xls");
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
                cell.BackColor = System.Drawing.Color.FromArgb(15, 36, 62);
                cell.ForeColor = System.Drawing.Color.White;
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
                    if (cell.Text.Equals("01/01/1900"))
                    {
                        cell.Text = "N/A";
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
    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarProvincia();
    }
    protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarDistrito();
    }
    public void setTabs()
    {
        li1.Attributes.Add("class", "");
        li2.Attributes.Add("class", "");
        li3.Attributes.Add("class", "");
        li4.Attributes.Add("class", "");
        li5.Attributes.Add("class", "");
        //li6.Attributes.Add("class", "");
        li7.Attributes.Add("class", "");
        li8.Attributes.Add("class", "");

        //li1.Attributes.Add("class", "first disabled");
        //li2.Attributes.Add("class", "disabled");
        //li3.Attributes.Add("class", "disabled");
        //li4.Attributes.Add("class", "disabled");
        //li5.Attributes.Add("class", "disabled");
        //li6.Attributes.Add("class", "last disabled");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        setTabs();
        li1.Attributes.Add("class", "first current");
        li1.Attributes.Add("class", "active");
        MultiView2.ActiveViewIndex = 0;
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        setTabs();
        li2.Attributes.Add("class", "current");
        li2.Attributes.Add("class", "active");
        MultiView2.ActiveViewIndex = 1;
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        setTabs();
        li3.Attributes.Add("class", "current");
        li3.Attributes.Add("class", "active");
        MultiView2.ActiveViewIndex = 2;
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        setTabs();
        li4.Attributes.Add("class", "current");
        li4.Attributes.Add("class", "active");
        MultiView2.ActiveViewIndex = 3;
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        setTabs();
        li5.Attributes.Add("class", "current");
        li5.Attributes.Add("class", "active");
        MultiView2.ActiveViewIndex = 4;
    }

    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        setTabs();
        //li6.Attributes.Add("class", "last current");
        //li6.Attributes.Add("class", "active");
        MultiView2.ActiveViewIndex = 5;
    }


    protected void LinkButton14_Click(object sender, EventArgs e)
    {
        setTabs();
        li8.Attributes.Add("class", "current");
        li8.Attributes.Add("class", "active");
        MultiView2.ActiveViewIndex = 7;
    }

    public void OcultarModals()
    {
        modalFamiliar.Visible = false;
        modalFormacion.Visible = false;
        modalIdioma.Visible = false;
        modalInteres.Visible = false;
        modalExperiencia.Visible = false;
    }


    #region "Familiar"

    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        LimpiarFormFamiliar();
        OcultarModals();
        txtAccionFamiliar.Value = "Registrar";
        modalFamiliar.Visible = true;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalFamiliar').modal('show');", true);
    }

    public void LimpiarFormFamiliar()
    {
        txtApellidoMaternoFamiliar.Text = "";
        txtApellidoPaternoFamiliar.Text = "";
        txtNombresFamiliar.Text = "";
        txtFechaNacimientoFamiliar.Text = "";
        txtLugarNacimientoFamiliar.Text = "";
        txtTelefonoCasaFamiliar.Text = "";
        txtTelefonoOficinaFamiliar.Text = "";
        txtLugarTrabajoFamiliar.Text = "";
        HFIDFamiliar.Value = "0";
        ddlLlamarEmergenciaFamiliar.SelectedIndex = 2;
        ddlParentesco.SelectedIndex = 0;
    }

    protected void btnGuardarFamiliar_Click(object sender, EventArgs e)
    {


        if (txtAccionFamiliar.Value.Equals("Registrar"))
        {
            EmpleadoFamiliaEL Familiar = new EmpleadoFamiliaEL();
            Familiar.id_key = gvFamiliares.Rows.Count;
            Familiar.cod_id = 0;
            Familiar.cod_ocupacion = "";
            Familiar.opcional_ocupacion = "";
            Familiar.cod_parentesco = ddlParentesco.SelectedValue;
            Familiar.opcional_parentesco = ddlParentesco.SelectedItem.Text;
            Familiar.telf_casa = txtTelefonoCasaFamiliar.Text;
            Familiar.telf_of = txtTelefonoOficinaFamiliar.Text;
            Familiar.fam_apellido_mat = txtApellidoMaternoFamiliar.Text;
            Familiar.edad = (DateTime.Today.AddTicks(-Convert.ToDateTime(txtFechaNacimientoFamiliar.Text).Ticks).Year) - 1;
            Familiar.fam_apellido_pat = txtApellidoPaternoFamiliar.Text;
            Familiar.fam_nombre = txtNombresFamiliar.Text;
            Familiar.fch_nacimiento = Convert.ToDateTime(txtFechaNacimientoFamiliar.Text);
            Familiar.lugar_nacimiento = txtLugarNacimientoFamiliar.Text;
            Familiar.lugar_trabajo = txtLugarTrabajoFamiliar.Text;
            Familiar.llamar_emergencia = ddlLlamarEmergenciaFamiliar.SelectedValue;
            Familiar.opcional_llamar_emergencia = ddlLlamarEmergenciaFamiliar.SelectedItem.Text;

            IList<EmpleadoFamiliaEL> DataFamiliar = (List<EmpleadoFamiliaEL>)Session["EmpleadoFamilia"];
            DataFamiliar.Add(Familiar);

            //lstF.Add(Familiar);
            //Session["EmpleadoFamilia2"] = lstF;

            gvFamiliares.DataSource = DataFamiliar;

            gvFamiliares.DataBind();

            Session["EmpleadoFamilia"] = DataFamiliar;

            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se agrego con éxito.','success');", true);
        }
        else
        {
            ActualizarEmpleado1(Convert.ToInt32(HFIDFamiliar.Value));
        }







    }

    public IList<EmpleadoFamiliaEL> getDataFamilia()
    {
        IList<EmpleadoFamiliaEL> DataFamiliar = new List<EmpleadoFamiliaEL>();
        int index = 0;
        foreach (GridViewRow row in gvFamiliares.Rows)
        {
            EmpleadoFamiliaEL Familiar = new EmpleadoFamiliaEL();
            Familiar.id_key = index;
            Familiar.cod_id = Convert.ToInt32(row.Cells[1].Text.ToString().Trim());
            Familiar.cod_parentesco = row.Cells[2].Text.ToString().Trim();
            Familiar.opcional_parentesco = row.Cells[3].Text.ToString().Trim();
            Familiar.fam_apellido_mat = row.Cells[4].Text.ToString().Trim();
            Familiar.fam_apellido_pat = row.Cells[5].Text.ToString().Trim();
            Familiar.fam_nombre = row.Cells[6].Text.ToString().Trim();
            Familiar.fch_nacimiento = Convert.ToDateTime(row.Cells[7].Text.ToString().Trim());
            Familiar.lugar_nacimiento = row.Cells[8].Text.ToString().Trim();
            Familiar.cod_ocupacion = row.Cells[9].Text.ToString().Trim();
            Familiar.opcional_ocupacion = row.Cells[10].Text.ToString().Trim();
            Familiar.lugar_trabajo = row.Cells[11].Text.ToString().Trim();
            Familiar.telf_of = row.Cells[12].Text.ToString().Trim();
            Familiar.telf_casa = row.Cells[13].Text.ToString().Trim();
            Familiar.llamar_emergencia = row.Cells[14].Text.ToString().Trim();
            Familiar.opcional_llamar_emergencia = row.Cells[15].Text.ToString().Trim();
            DataFamiliar.Add(Familiar);
            index++;
        }
        return DataFamiliar;
    }

    protected void gvFamiliares_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        IList<EmpleadoFamiliaEL> DataFamiliar = (List<EmpleadoFamiliaEL>)Session["EmpleadoFamilia"];
        DataFamiliar.RemoveAt(e.RowIndex);

        gvFamiliares.DataSource = DataFamiliar;
        gvFamiliares.DataBind();

        Session["EmpleadoFamilia"] = DataFamiliar;
    }






    protected void gvFamiliares_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "editar":

                string[] arg = new string[10];
                string fecha = txtFechaNacimientoFamiliar.Text;
                arg = e.CommandArgument.ToString().Split(';');
                HFIDFamiliar.Value = arg[0].ToString();
                txtApellidoPaternoFamiliar.Text = arg[1].ToString();
                txtApellidoMaternoFamiliar.Text = arg[2].ToString();
                txtNombresFamiliar.Text = arg[3].ToString();
                ddlParentesco.SelectedValue = arg[4].ToString();
                txtFechaNacimientoFamiliar.Text = DateTime.Parse(arg[5].ToString()).ToString("dd/ MM/yyyy");
                txtLugarNacimientoFamiliar.Text = arg[6].ToString();
                txtLugarTrabajoFamiliar.Text = arg[7].ToString();
                txtTelefonoOficinaFamiliar.Text = arg[8].ToString();
                txtTelefonoCasaFamiliar.Text = arg[9].ToString();
                ddlLlamarEmergenciaFamiliar.SelectedValue = arg[10].ToString();

                modalFamiliar.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalFamiliar').modal('show');", true);
                txtAccionFamiliar.Value = "Actualizar";
                break;

            case "eliminar":
                int id_key = Convert.ToInt32(e.CommandArgument);


                List<TransaccionEL> tnx = objEmpleado.Eliminar(id_key);
                if (tnx[0].id_mensaje == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se elimino con éxito.','success');", true);
                    cargarEmpleados();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('" + tnx[0].mensaje + "','Ocurrio un error','error');", true);
                }

                break;
        }

    }

    //public void EditarFamiliar(int id_key)
    //{
    //    DataTable dataEmpleadoFamiliar = objEmpleado.ActualizarFamiliar(id_key);

    //    this.HFCodigo.Value = id_key.ToString();

    //}





    #endregion


    #region "Formacion"

    protected void btnAgregarFormacion_Click(object sender, EventArgs e)
    {
        LimpiarFormFormacion();
        OcultarModals();
        txtAccionFormacion.Value = "registrar";
        modalFormacion.Visible = true;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('div.modalFormacion').modal('show');", true);
    }
    public void LimpiarFormFormacion()
    {
        txtTitulo.Text = "";
        txtCentroInstruccion.Text = "";
        txtCentroInstruccion_id.Text = "";
        ddlTipoInstitucion.SelectedIndex = 0;
        ddlAnnoIntruccionInicio.SelectedIndex = 0;
        ddlAnnoIntruccionFin.SelectedIndex = 0;
        HFIDFormacion.Value = "0";
        ddlGradoFormacion.SelectedIndex = 0;
    }
    protected void btnGuardarFormacion_Click(object sender, EventArgs e)
    {

        if (txtAccionFormacion.Value.Equals("registrar"))
        {

            EmpleadoFormacionEL Familiar = new EmpleadoFormacionEL();
            Familiar.id_key = gvFormacion.Rows.Count;
            Familiar.cod_id = 0;
            Familiar.anio_inicio = ddlAnnoIntruccionInicio.SelectedValue;
            Familiar.anio_fin = ddlAnnoIntruccionFin.SelectedValue;
            Familiar.cod_grado_instruccion = ddlGradoFormacion.SelectedValue;
            Familiar.cod_institucion = txtCentroInstruccion_id.Text;
            Familiar.observaciones = "";
            Familiar.opcional_instruccion = ddlGradoFormacion.SelectedItem.Text;
            Familiar.opcional_institucion = txtCentroInstruccion.Text;
            Familiar.titulo = txtTitulo.Text;

            IList<EmpleadoFormacionEL> DataFormacion = (List<EmpleadoFormacionEL>)Session["EmpleadoFormacion"];
            DataFormacion.Add(Familiar);

            gvFormacion.DataSource = DataFormacion;
            gvFormacion.DataBind();

            Session["EmpleadoFormacion"] = DataFormacion;

            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se agrego con éxito.','success');", true);


        }
        else
        {
            ActualizarFormacion(Convert.ToInt32(HFIDFormacion.Value));
        }

        LimpiarFormFormacion();


    }
    protected void gvFormacion_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        IList<EmpleadoFormacionEL> DataFamiliar = (List<EmpleadoFormacionEL>)Session["EmpleadoFormacion"];
        DataFamiliar.RemoveAt(e.RowIndex);

        gvFormacion.DataSource = DataFamiliar;
        gvFormacion.DataBind();

        Session["EmpleadoFormacion"] = DataFamiliar;
    }

    #endregion


    #region "Idioma"

    protected void btnAgregarIdioma_Click(object sender, EventArgs e)
    {
        LimpiarFormIdioma();
        OcultarModals();
        txtAccionIdioma.Value = "registrar";
        modalIdioma.Visible = true;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalIdioma').modal('show');", true);
    }
    public void LimpiarFormIdioma()
    {

        ddlIdioma.SelectedIndex = 0;
        ddlIdiomaNivel.SelectedIndex = 0;
        ddlHabla.SelectedIndex = 0;
        ddlLee.SelectedIndex = 0;
        ddlEscribe.SelectedIndex = 0;
        HFIDIdioma.Value = "0";
        txtIdiomaInstruccion.Text = "";
    }
    protected void btnGuardarIdioma_Click(object sender, EventArgs e)
    {
        if (txtAccionIdioma.Value.Equals("registrar"))
        {

            EmpleadoIdiomaEL Familiar = new EmpleadoIdiomaEL();
            Familiar.id_key = gvFormacion.Rows.Count;
            Familiar.cod_id = 0;
            Familiar.cod_idioma = ddlIdioma.SelectedValue;
            Familiar.opcional_idioma = ddlIdioma.SelectedItem.Text;
            Familiar.cod_nivel = ddlIdiomaNivel.SelectedValue;
            Familiar.opcional_nivel = ddlIdiomaNivel.SelectedItem.Text;
            Familiar.institucion = txtIdiomaInstruccion.Text;
            Familiar.n_habla = ddlHabla.SelectedValue;
            Familiar.n_lee = ddlLee.SelectedValue;
            Familiar.n_escritura = ddlEscribe.SelectedValue;

            Familiar.opcional_habla = ddlHabla.SelectedItem.Text;
            Familiar.opcional_lee = ddlLee.SelectedItem.Text;
            Familiar.opcional_escritura = ddlEscribe.SelectedItem.Text;

            IList<EmpleadoIdiomaEL> DataFormacion = (List<EmpleadoIdiomaEL>)Session["EmpleadoIdioma"];
            DataFormacion.Add(Familiar);

            gvIdioma.DataSource = DataFormacion;
            gvIdioma.DataBind();

            Session["EmpleadoIdioma"] = DataFormacion;

            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se agrego con éxito.','success');", true);



        }
        else
        {
            ActualizarIdioma(Convert.ToInt32(HFIDIdioma.Value));
        }


        LimpiarFormIdioma();




    }
    protected void gvIdioma_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        IList<EmpleadoIdiomaEL> DataFamiliar = (List<EmpleadoIdiomaEL>)Session["EmpleadoIdioma"];
        DataFamiliar.RemoveAt(e.RowIndex);

        gvIdioma.DataSource = DataFamiliar;
        gvIdioma.DataBind();

        Session["EmpleadoIdioma"] = DataFamiliar;
    }

    #endregion


    #region "Interes"

    protected void btnAgregarCurso_Click(object sender, EventArgs e)
    {
        LimpiarFormInteres();
        OcultarModals();
        txtAccionInteres.Value = "registrar";
        modalInteres.Visible = true;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalInteres').modal('show');", true);
    }
    public void LimpiarFormInteres()
    {
        ddlInteres.SelectedIndex = 0;
        ddlNivelInteres.SelectedIndex = 0;
        txtOtrosCurso.Text = "";
        HFIDInteres.Value = "0";
    }
    protected void btnGuardarInteres_Click(object sender, EventArgs e)
    {
        if (txtAccionInteres.Value.Equals("registrar"))
        {
            EmpleadoInteresEL Familiar = new EmpleadoInteresEL();
            Familiar.id_key = gvFormacion.Rows.Count;
            Familiar.cod_id = 0;
            Familiar.cod_interes = ddlInteres.SelectedValue;
            Familiar.opcional_interes = ddlInteres.SelectedItem.Text;
            Familiar.cod_nivel = ddlNivelInteres.SelectedValue;
            Familiar.opcional_nivel = ddlNivelInteres.SelectedItem.Text;
            Familiar.observacion = txtIdiomaInstruccion.Text;
            Familiar.desc_interes = txtOtrosCurso.Text;

            IList<EmpleadoInteresEL> DataFormacion = (List<EmpleadoInteresEL>)Session["EmpleadoInteres"];
            DataFormacion.Add(Familiar);

            gvProgramas.DataSource = DataFormacion;
            gvProgramas.DataBind();

            Session["EmpleadoInteres"] = DataFormacion;

            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se agrego con éxito.','success');", true);
        }
        else
        {
            ActualizarInteres(Convert.ToInt32(HFIDInteres.Value));
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se actualizo con éxito.','success');", true);
        }

    }

    /*
    public void llenarIdioma()
    {

        ddlNivelInteres.Items.Clear();
        ddlNivelInteres.Items.Add("--Seleccione Idioma--");
        ddlNivelInteres.Items.Add("AVANZADO");
        ddlNivelInteres.Items[1].Value = "170300";
        ddlNivelInteres.Items.Add("BASICO");
        ddlNivelInteres.Items[2].Value = "170100";
        ddlNivelInteres.Items.Add("INTERMEDIO");
        ddlNivelInteres.Items[2].Value = "170200";

    }
    */

    protected void gvProgramas_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        IList<EmpleadoInteresEL> DataFamiliar = (List<EmpleadoInteresEL>)Session["EmpleadoInteres"];
        DataFamiliar.RemoveAt(e.RowIndex);

        gvProgramas.DataSource = DataFamiliar;
        gvProgramas.DataBind();

        Session["EmpleadoInteres"] = DataFamiliar;
    }

    #endregion


    #region "Experiencia"

    protected void btnAgregarExperiencia_Click(object sender, EventArgs e)
    {
        LimpiarFormExperiencia();
        OcultarModals();
        txtAccionExperiencia.Value = "registrar";
        modalExperiencia.Visible = true;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalExperiencia').modal('show');", true);
    }
    public void LimpiarFormExperiencia()
    {
        ddlExperienciaAnnoFin.SelectedIndex = 0;
        ddlExperienciaAnnoInicio.SelectedIndex = 0;
        ddlExperienciaMesFin.SelectedIndex = 0;
        ddlExperienciaMesInicio.SelectedIndex = 0;
        txtExperienciaEmpresa.Text = "";
        txtExperienciaObservacion.Text = "";
        txtExperienciaCargo.Text = "";
        HFIDExperiencia.Value = "0";
    }
    protected void btnGuardarExperiencia_Click(object sender, EventArgs e)
    {
        if (txtAccionExperiencia.Value.Equals("registrar"))
        {
            EmpleadoExperienciaEL Familiar = new EmpleadoExperienciaEL();
            Familiar.id_key = gvFormacion.Rows.Count;
            Familiar.cod_id = 0;
            Familiar.cod_cargo_laboral = "00";
            Familiar.des_cargo_laboral = txtExperienciaCargo.Text;
            Familiar.nom_empresa = txtExperienciaEmpresa.Text;
            Familiar.ubicacion = "";
            Familiar.anio_fin = ddlExperienciaAnnoFin.SelectedValue;
            Familiar.mes_fin = ddlExperienciaMesFin.SelectedValue;

            Familiar.mes_inicio = ddlExperienciaMesInicio.SelectedValue;
            Familiar.anio_inicio = ddlExperienciaAnnoInicio.SelectedValue;


            Familiar.observaciones = txtExperienciaObservacion.Text;

            //Session["EmpleadoExperiencia"] = new List<EmpleadoExperienciaEL>();

            IList<EmpleadoExperienciaEL> DataFormacion = (List<EmpleadoExperienciaEL>)Session["EmpleadoExperiencia"];
            DataFormacion.Add(Familiar);

            gvExperiencia.DataSource = DataFormacion;
            gvExperiencia.DataBind();

            Session["EmpleadoExperiencia"] = DataFormacion;

            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se agrego con éxito.','success');", true);
        }
        else
        {
            ActualizarExperienciaP(Convert.ToInt32(HFIDExperiencia.Value));
        }



    }
    protected void gvExperiencia_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        IList<EmpleadoExperienciaEL> DataFamiliar = (List<EmpleadoExperienciaEL>)Session["EmpleadoExperiencia"];
        DataFamiliar.RemoveAt(e.RowIndex);

        gvExperiencia.DataSource = DataFamiliar;
        gvExperiencia.DataBind();

        Session["EmpleadoExperiencia"] = DataFamiliar;
    }

    #endregion


    #region "Documento"

    public void LimpiarFormArchivo()
    {
        txtNombreDocumento.Text = "";
        ddlVigenciaDocumento.SelectedIndex = 1;
        txtObservacionDocumento.Text = "";
        txtFechaDesdeDocumento.Text = "";
        txtFechaHastaDocumento.Text = "";
        HFIDArchivo.Value = "0";
        HFArchivoDocumento.Value = "";
    }

    protected void gvDocumentos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id_key = Convert.ToInt32(e.CommandArgument.ToString());
        switch (e.CommandName.ToString())
        {

            case "editar":

                //GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                //int RowIndex = gvr.RowIndex;
                //int i = 0;
                //foreach (GridViewRow row in gvCarpetaN1.Rows)
                //{
                //    row.CssClass = "";
                //    if (i == RowIndex)
                //    {
                //        row.CssClass = "selected";
                //        HFCarpetaFicha.Value = gvCarpetaN1.DataKeys[i].Value.ToString();
                //    }
                //    i++;
                //}

                List<EmpleadoDocumentoEL> DataFile = objEmpleado.Consultar_EmpleadoDocumento_PorCodigo(id_key);
                if (DataFile.Count() > 0)
                {

                    LimpiarFormArchivo();
                    txtNombreDocumento.Text = DataFile[0].Nombre;
                    ddlVigenciaDocumento.SelectedIndex = (DataFile[0].TieneVigencia ? 0 : 1);
                    txtObservacionDocumento.Text = DataFile[0].Observacion;
                    txtFechaDesdeDocumento.Text = (DataFile[0].opcional_FchInicioVigencia == "01/01/1900" ? "" : DataFile[0].opcional_FchInicioVigencia);
                    txtFechaHastaDocumento.Text = (DataFile[0].opcional_FchFinVigencia == "01/01/1900" ? "" : DataFile[0].opcional_FchFinVigencia);
                    HFIDArchivo.Value = DataFile[0].id_key.ToString();
                    HFArchivoDocumento.Value = DataFile[0].Archivo;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalArchivo').modal('show');", true);

                }


                break;
            case "eliminar":

                List<TransaccionEL> tnx = objEmpleado.EliminarArchivo(id_key);
                if (tnx[0].id_mensaje == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se elimino con éxito.','success');", true);
                    cargarEmpleados();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('" + tnx[0].mensaje + "','Ocurrio un error','error');", true);
                }
                cargarDocumentos();
                break;
            case "documento":
                break;
        }
    }

    protected void gvCarpetaN1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id_key = Convert.ToString(e.CommandArgument);
        switch (e.CommandName.ToString())
        {

            case "carpeta":

                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);


                int RowIndex = gvr.RowIndex;
                int i = 0;
                foreach (GridViewRow row in gvCarpetaN1.Rows)
                {
                    GridView gvCarpetaN1_detalle = (GridView)row.FindControl("gvCarpetaN1_detalle");
                    row.CssClass = "";
                    if (i == RowIndex)
                    {
                        //row.CssClass = "selected";
                        HFCarpetaFicha.Value = gvCarpetaN1.DataKeys[i].Value.ToString();
                        gvCarpetaN1_detalle.Visible = true;

                        foreach (GridViewRow row1 in gvCarpetaN1_detalle.Rows)
                        {
                            row1.CssClass = "";
                        }
                    }
                    else
                        gvCarpetaN1_detalle.Visible = false;
                    i++;
                }


                HFCarpetaActiva.Value = id_key;
                HFFichaActiva.Value = "01";
                btnAgregarArchivo.Visible = false;
                gvDocumentos.Visible = false;
                break;
            case "eliminar":
                break;
            case "documento":
                break;
        }
    }

    protected void gvCarpetaN2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id_key = Convert.ToString(e.CommandArgument);
        switch (e.CommandName.ToString())
        {

            case "documento":

                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int posCarpeta = Convert.ToInt32(HFCarpetaActiva.Value);
                GridView gv = (GridView)gvCarpetaN1.Rows[posCarpeta - 1].FindControl("gvCarpetaN1_detalle");

                int RowIndex = gvr.RowIndex;

                int i = 0;
                foreach (GridViewRow row in gv.Rows)
                {
                    row.CssClass = "";
                    if (i == RowIndex)
                        row.CssClass = "selected";
                    i++;
                }
                HFFichaActiva.Value = id_key;
                cargarDocumentos();
                btnAgregarArchivo.Visible = true;
                break;
            case "eliminar":
                break;

        }
    }

    protected void btnAgregarArchivo_Click(object sender, EventArgs e)
    {
        LimpiarFormArchivo();
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalArchivo').modal('show');", true);
    }


    protected void btnBuscarEmpleadoDocumento_Click(object sender, EventArgs e)
    {
        DocumentoEmpleado(Convert.ToInt32(txtEmpleado_id.Text));
    }

    protected void btnGuardarArchivo_Click(object sender, EventArgs e)
    {

        EmpleadoDocumentoEL Documento = new EmpleadoDocumentoEL();
        Documento.id_key = Convert.ToInt32(HFIDArchivo.Value);
        Documento.IDPersonal = Convert.ToInt32(txtEmpleado_id.Text);
        Documento.Estado = true;
        Documento.Observacion = ddlAnnoIntruccionFin.SelectedValue;

        Documento.TieneVigencia = (ddlVigenciaDocumento.SelectedIndex == 0 ? true : false);
        Documento.FchActualizo = DateTime.Now;
        Documento.FchRegistro = DateTime.Now;
        Documento.FchInicioVigencia = Convert.ToDateTime("01/01/1900");
        Documento.FchFinVigencia = Convert.ToDateTime("01/01/1900");
        if (Documento.TieneVigencia)
        {
            Documento.FchInicioVigencia = Convert.ToDateTime(txtFechaDesdeDocumento.Text);
            Documento.FchFinVigencia = Convert.ToDateTime(txtFechaHastaDocumento.Text);
        }
        Documento.TipoCarpeta = HFCarpetaActiva.Value;
        Documento.TipoDocumento = HFFichaActiva.Value;
        Documento.Archivo = HFArchivoDocumento.Value;
        Documento.Observacion = txtObservacionDocumento.Text;
        Documento.Nombre = txtNombreDocumento.Text;
        Documento.UserActualizo = User.Identity.Name;
        Documento.UserRegistro = User.Identity.Name;
        //IList<EmpleadoFormacionEL> DataFormacion = (List<EmpleadoFormacionEL>)Session["EmpleadoFormacion"];
        //DataFormacion.Add(Familiar);
        //gvFormacion.DataSource = DataFormacion;
        //gvFormacion.DataBind();
        //Session["EmpleadoFormacion"] = DataFormacion;
        //ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se agrego con éxito.','success');", true);

        string NomArchivo = "";
        if (FUArchivoDocumento.HasFile)
        {
            string tempArchivo = Documento.TipoCarpeta + "_" + Documento.TipoDocumento + "_" + FUArchivoDocumento.PostedFile.FileName;
            NomArchivo = tempArchivo;
            FUArchivoDocumento.SaveAs(HFCarpetaCompartida.Value + "/" + HFCarpetaFicha.Value + "/" + tempArchivo);
            Documento.Archivo = "/" + HFCarpetaFicha.Value + "/" + NomArchivo;
        }


        if (HFIDArchivo.Value == "0")
        {
            objEmpleado.RegistrarDocumento(Documento);
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se agrego con éxito.','success');", true);
        }
        else
        {
            objEmpleado.ActualizarDocumento(Documento);
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se actualizo con éxito.','success');", true);
        }

        cargarDocumentos();
    }


    public void cargarDocumentos()
    {

        int IDEmpleado = Convert.ToInt32(txtEmpleado_id.Text);
        string Carpeta = HFCarpetaActiva.Value;
        string Ficha = HFFichaActiva.Value;
        string CarpetaEmpleado = "";
        List<ItemEL> ConfigFileServer = objCatalogo.ListarItem("18");

        if (ConfigFileServer.Count > 0)
            CarpetaEmpleado = ConfigFileServer[0].valor1.Replace("~", "../..");

        DataTable dataEmpleado = objEmpleado.Consultar_PorCodigo(IDEmpleado);


        List<EmpleadoDocumentoEL> DataDocumentos = objEmpleado.Consultar_EmpleadoDocumento(IDEmpleado, Carpeta, Ficha);
        foreach (EmpleadoDocumentoEL file in DataDocumentos)
        {
            file.Archivo = CarpetaEmpleado + dataEmpleado.Rows[0]["carpeta_compartida"].ToString() + file.Archivo;
        }

        gvDocumentos.DataSource = DataDocumentos;
        gvDocumentos.DataBind();
        gvDocumentos.Visible = true;
    }

    protected void gvCarpetaN1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string idCarpeta = ((Label)e.Row.FindControl("lblIDCarpeta")).Text;
            GridView gvCarpetaN1_detalle = (GridView)e.Row.FindControl("gvCarpetaN1_detalle");
            List<ItemEL> DataCarpetas = objCatalogo.ListarItem("19");
            List<ItemEL> CarpetasN2 = DataCarpetas.Where(f => f.id_sub_catalogo == idCarpeta && f.id_tabla != "00").ToList();
            foreach (ItemEL documento in CarpetasN2)
            {
                documento.valor2 = documento.valor1.Substring(0, 4).Trim();
            }

            gvCarpetaN1_detalle.DataSource = CarpetasN2;
            gvCarpetaN1_detalle.DataBind();
        }
    }


    #endregion


    #region "Cesados"
    protected void gvMarcas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lblEstadoEmp");
            string estado = lbl.Text.ToString();
            switch (estado)
            {
                case "R":
                    lbl.Text = "ACTIVO";
                    lbl.CssClass = "label label-success";
                    break;

                case "A":
                    lbl.Text = "CESADO";
                    lbl.CssClass = "label label-danger";
                    break;
            }
        }
    }
    #endregion

    #region "Datos Empresa"
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        setTabs();
        li7.Attributes.Add("class", "current");
        li7.Attributes.Add("class", "active");
        MultiView2.ActiveViewIndex = 6;
    }



    #endregion


    #region "Descanso Médico"

    protected void LBAgregar_Click(object sender, EventArgs e)
    {
        limpiarDM();
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#DM1').modal('show');", true);
    }

    protected void gvDescansos_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        switch (e.CommandName.ToString())
        {


            case "Visualizar":

                string[] Arg = new string[2];
                Arg = e.CommandArgument.ToString().Split(';');

                int id = Convert.ToInt32(Arg[0]);
                string es = Arg[1];

                if (es.Equals("D"))
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#DM1').modal('show');", true);
                    List<DescansoMedicoEL> lst = objDescanso.ListarDescanso(id, 0, "D");
                    fchInicio.Text = lst[0].diasInicio_des.ToString();
                    txtDias.Text = lst[0].diasTotal_des.ToString();
                    fchFin.Text = lst[0].diasFin_des.ToString();
                    ddlMotivo.SelectedValue = lst[0].cod_motivo.ToString();
                    txtClinica_id.Text = lst[0].cod_clinica.ToString();
                    txtClinica.Text = lst[0].desc_clinica.ToString();
                    txtObserva.Text = lst[0].observacion_des.ToString();
                    HiddenField3.Value = lst[0].documentacion_des.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#DM1').modal('show');", true);
                    List<DescansoMedicoEL> lstS = objDescanso.ListarDescanso(id, 0, "S");
                    fchInicio.Text = lstS[0].diasInicio_des.ToString();
                    txtDias.Text = lstS[0].diasTotal_des.ToString();
                    fchFin.Text = lstS[0].diasFin_des.ToString();
                    ddlMotivo.SelectedValue = lstS[0].cod_motivo.ToString();
                    txtClinica_id.Text = lstS[0].cod_clinica.ToString();
                    txtClinica.Text = lstS[0].desc_clinica.ToString();
                    txtObserva.Text = lstS[0].observacion_des.ToString();
                    HiddenField3.Value = lstS[0].documentacion_des.ToString();
                }

                break;
            case "Delete":

                int id_desc = Convert.ToInt32(e.CommandArgument.ToString());
                List<TransaccionEL> tnx = objDescanso.EliminarDescanso(id_desc);
                if (tnx[0].id_mensaje == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('','Se elimino con éxito.','success');", true);
                    ListarConsulta(int.Parse(HFCodigo.Value));
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('" + tnx[0].mensaje + "','Ocurrio un error','error');", true);
                }

                break;
            case "Descargar":
                string filename = e.CommandArgument.ToString();
                if (!filename.Equals(""))
                {
                    Response.Clear();
                    //Response.AddHeader("content-disposition", string.Format("attachment;filename{0}", filename));
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + filename.Substring(12, filename.Length - 12));
                    Response.ContentType = "Application/pdf";
                    Response.WriteFile(Server.MapPath(filename));
                    Response.Flush();
                    Response.End();
                }
                break;
        }
    }

    protected void btnGuardarDM_Click(object sender, EventArgs e)
    {
        RegistrarDM();
        ListarConsulta(int.Parse(HFCodigo.Value));
        MultiView1.ActiveViewIndex = 3;
    }

    public void RegistrarDM()
    {
        DescansoMedicoEL objDMEL = new DescansoMedicoEL();
        DescansoMedicoBL objDMBL = new DescansoMedicoBL();
        DataTable dataEmpleado = objEmpleado.Consultar_PorCodigo(int.Parse(HFCodigo.Value));

        objDMEL.id_emp = int.Parse(HFCodigo.Value);
        objDMEL.diasInicio_des = fchInicio.Text;

        DateTime dt = DateTime.Parse(fchInicio.Text);
        objDMEL.diasFin_des = dt.AddDays(double.Parse(txtDias.Text) - 1).ToString("dd/MM/yyyy");
        objDMEL.diasTotal_des = Convert.ToInt32(txtDias.Text);
        objDMEL.cod_motivo = ddlMotivo.SelectedValue;
        objDMEL.estadoDM = ddlMotivoEstado.SelectedValue.ToString().Substring(0, 1);
        objDMEL.cod_clinica = txtClinica_id.Text;
        objDMEL.observacion_des = txtObserva.Text;
        objDMEL.documentacion_des = ArchivoDescansoMedico(dataEmpleado.Rows[0]["nro_documento"].ToString().Trim());


        if (ConsultarFecha(objDMEL.id_emp, objDMEL.diasInicio_des, objDMEL.diasFin_des) == 0)
        {
            List<TransaccionEL> lst = objDMBL.RegistrarDescanso(objDMEL);
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Se registro el descanso medico de forma correcta','Alerta:','success');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Ya cuenta con descanso médico','Alerta:','error');", true);
        }
    }

    public void ListarConsulta(int id_emp)
    {

        DescansoMedicoBL oDescanso = new DescansoMedicoBL();
        List<DescansoMedicoEL> lst = oDescanso.ListarDescanso(0, id_emp, "D");
        gvDescansos.DataSource = lst;
        gvDescansos.DataBind();
        totalizar();

        List<DescansoMedicoEL> lstS = oDescanso.ListarDescanso(0, id_emp, "S");
        gvSubsidio.DataSource = lstS;
        gvSubsidio.DataBind();

    }

    protected void gvDescansos_PreRender(object sender, EventArgs e)
    {

        if (gvDescansos.Rows.Count > 0)
        {
            gvDescansos.UseAccessibleHeader = true;
            gvDescansos.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvDescansos.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    public void limpiarDM()
    {
        txtDias.Text = "";
        txtClinica.Text = "";
        txtClinica_id.Text = "";
        ddlMotivo.SelectedIndex = 0;
        txtObserva.Text = "";
    }


    protected void gvDescansos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }


    public string ArchivoDescansoMedico(string dni)
    {
        //DataTable ds = new DataTable();

        //string FileName = Path.GetFileName(fuArchivo.PostedFile.FileName);
        string Extension = Path.GetExtension(fuArchivo.PostedFile.FileName);
        string FolderPath = ConfigurationManager.AppSettings["folderDescansos"];
        string nombre = "DM_" + DateTime.Now.ToString("ddMMyyyy") + "_" + dni + ".pdf";
        if (fuArchivo.HasFile)
        {
            if (Extension == ".pdf" || Extension == ".PDF")
            {
                var pathDestino = Server.MapPath(FolderPath);
                //var carpetaDestino = new DirectoryInfo(pathDestino);
                //nombreArchivo = Path.GetFileName(fuArchivo.FileName);
                var PathFinal = Path.Combine(pathDestino, nombre);
                fuArchivo.SaveAs(PathFinal);
            }
        }
        return FolderPath + "/" + nombre;
    }


    protected void gvSubsidio_PreRender(object sender, EventArgs e)
    {
        if (gvSubsidio.Rows.Count > 0)
        {
            gvSubsidio.UseAccessibleHeader = true;
            gvSubsidio.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvSubsidio.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void gvSubsidio_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    public int ConsultarFecha(int id_emp, string fecha_inicio, string fecha_fin)
    {
        DescansoMedicoBL oDescanso = new DescansoMedicoBL();
        List<DescansoMedicoEL> lst = oDescanso.ConsultarFecha(id_emp, fecha_inicio, fecha_fin);
        return lst.Count;

    }

    protected void btnExportarDM_Click(object sender, EventArgs e)
    {
        if (gvFiltroDM.Rows.Count > 0)
        {
            DescansoMedicoEL DM = new DescansoMedicoEL();
            DM.diasInicio_des = fchInicioFiltro.Text;
            DM.diasFin_des = fchFinFiltro.Text;
            DM.estadoDM = ddlTipoR.SelectedValue;
            var GridView1 = new GridView();
            GridView1.DataSource = objDescanso.ExportarDM(DM);
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attacNhment;filename=ReporteDescansosMédicos_" + DateTime.Now.ToString("ddMMyyyy") + ".xls");
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('Seleccione rango de fecha','Alerta:','error');", true);
        }
    }

    protected void btnConsultarDM_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#DMFiltro').modal('show');", true);
    }

    protected void gvFiltroDM_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void BuscarDM_Click(object sender, EventArgs e)
    {
        DescansoMedicoEL DM = new DescansoMedicoEL();
        DM.diasInicio_des = fchInicioFiltro.Text;
        DM.diasFin_des = fchFinFiltro.Text;

        DM.estadoDM = ddlTipoR.SelectedValue;

        gvFiltroDM.DataSource = objDescanso.ExportarDM(DM);
        gvFiltroDM.DataBind();
    }

    protected void gvFiltroDM_PreRender(object sender, EventArgs e)
    {

    }

    protected void gvFiltroDM_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    #endregion





    #region Validación y Ediciones
    public string validarDatos(string estado)
    {
        string mensaje = "";
        DateTime fechaHoy = DateTime.Now;
        string fecha = fechaHoy.ToString("d");

        if (estado.Equals("A"))
        {
            if ((Convert.ToDateTime(txt_fch_cese.Text) <= Convert.ToDateTime(txt_fecha_ingreso.Text)) || (Convert.ToDateTime(txt_fch_cese.Text) > fechaHoy))
            {
                mensaje = "Debe validar la fecha de cese.";
            }
            else
            {
                if (!txt_fch_cese.Text.Equals(""))
                {
                    if (ddlMotivoCese.SelectedIndex == 0)
                    {
                        mensaje = "Debe seleccionar el motivo de cese";
                    }
                    else
                    {
                        mensaje = "OK";
                    }

                }
                else
                {
                    mensaje = "OK";
                }
            }
        }
        else
        {
            mensaje = "OK";

        }
        return mensaje;
    }

    public string validar()
    {
        string mensaje = "OK";


        if (ddlTipoPersonal.SelectedIndex == 0)
        {
            mensaje = "Seleccione Tipo Personal";
            setTabs();
            li7.Attributes.Add("class", "current");
            li7.Attributes.Add("class", "active");
            MultiView2.ActiveViewIndex = 6;
        }

        if (ddlTipoContrato.SelectedIndex == 0)
        {
            mensaje = "Seleccione Tipo Contrato";
            setTabs();
            li7.Attributes.Add("class", "current");
            li7.Attributes.Add("class", "active");
            MultiView2.ActiveViewIndex = 6;
        }

        if (ddlProceso.SelectedIndex == 0)
        {
            mensaje = "Seleccione Proceso";
            setTabs();
            li7.Attributes.Add("class", "current");
            li7.Attributes.Add("class", "active");
            MultiView2.ActiveViewIndex = 6;
        }

        if (ddlCargo.SelectedIndex == 0)
        {
            mensaje = "Seleccione Puesto Laboral";
            setTabs();
            li7.Attributes.Add("class", "current");
            li7.Attributes.Add("class", "active");
            MultiView2.ActiveViewIndex = 6;
        }

        if (txt_fecha_ingreso.Text == "")
        {
            mensaje = "Ingrese Fecha Ingreso";
            MultiView2.ActiveViewIndex = 6;
            setTabs();
            li7.Attributes.Add("class", "current");
            li7.Attributes.Add("class", "active");
        }

        if (txtApellidoPaterno.Text == "" || txtApellidoMaterno.Text == "" ||
            txtNombres.Text == "" || txtNumeroDocumento.Text == "" || txtFechaNacimiento.Text == ""
            || txtCorreo.Text == "" || txtTelefonoPersonal.Text == "" || txtDireccion.Text == "")
        {
            mensaje = "Ingrese Datos completos del Empleado";
            setTabs();
            li1.Attributes.Add("class", "first current");
            li1.Attributes.Add("class", "active");
            MultiView2.ActiveViewIndex = 0;
        }

        if (ddlTipoDocumento.SelectedIndex == 0 || ddlSexo.SelectedIndex == 0 || ddlEstadoCivil.SelectedIndex == 0 ||
            ddlDepartamento.SelectedIndex == 0 || ddlProvincia.SelectedIndex == 0 || ddlDistrito.SelectedIndex == 0)
        {
            mensaje = "Ingrese Datos completos del Empleado";
            setTabs();
            li1.Attributes.Add("class", "first current");
            li1.Attributes.Add("class", "active");
            MultiView2.ActiveViewIndex = 0;
        }

        return mensaje;
    }


    protected void grvVacaciones_PreRender(object sender, EventArgs e)
    {
        if (grvVacaciones.Rows.Count > 0)
        {
            grvVacaciones.UseAccessibleHeader = true;
            grvVacaciones.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvVacaciones.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void btnResumen_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#modalResumen').modal('show');", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JAlert('No se encontro información de vacaciones del empleado','Error:','error');", true);
        }

    }




    protected void Edit_Click(object sender, EventArgs e)
    {

        modalFamiliar.Visible = true;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalFamiliar').modal('show');", true);

    }


    protected void gvFormacion_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "editar":
                string[] arg = new string[5];
                arg = e.CommandArgument.ToString().Split(';');
                HFIDFormacion.Value = arg[0].ToString();
                ddlGradoFormacion.SelectedValue = arg[1].ToString();
                txtCentroInstruccion.Text = arg[2].ToString();
                txtTitulo.Text = arg[3].ToString();
                ddlAnnoIntruccionInicio.SelectedValue = arg[4].ToString();
                ddlAnnoIntruccionFin.SelectedValue = arg[5].ToString();
                cargarTipoInstitucion();
                txtAccionFormacion.Value = "Actualizar";
                break;
        }
    }

    protected void LinkButton2_Click1(object sender, EventArgs e)
    {
        modalFormacion.Visible = true;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('div.modalFormacion').modal('show');", true);
    }

    public void CargarCombo(DropDownList ddl, string cod)
    {
        ItemBL oItem = new ItemBL();
        List<ItemEL> oItemEL = oItem.ConsultarCatalogo(cod);
        ddl.SelectedItem.Text = oItemEL[0].descripcion;
        ddl.SelectedValue = oItemEL[0].id_tabla;

        ddl.DataSource = objCatalogo.ListarItem(cod.Substring(0, 2));
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("", ""));
    }

    protected void gvIdioma_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ItemBL oItem = new ItemBL();
        switch (e.CommandName.ToString())
        {
            case "editar":

                string[] arg = new string[6];
                arg = e.CommandArgument.ToString().Split(';');
                HFIDIdioma.Value = arg[0].ToString();
                CargarCombo(ddlIdioma, arg[1].ToString());
                CargarCombo(ddlIdiomaNivel, arg[2].ToString());
                txtIdiomaInstruccion.Text = arg[3].ToString();
                ddlHabla.SelectedItem.Text = arg[4].ToString();
                ddlLee.SelectedItem.Text = arg[5].ToString();
                ddlEscribe.SelectedItem.Text = arg[6].ToString();

                if (arg[4].ToString().Equals("SI") || arg[5].ToString().Equals("SI") || arg[6].ToString().Equals("SI"))
                {
                    ddlHabla.SelectedIndex = 0;
                    ddlLee.SelectedIndex = 0;
                    ddlEscribe.SelectedIndex = 0;
                    cargarDiscapacitado();
                }
                else
                {
                    ddlHabla.SelectedIndex = 1;
                    ddlLee.SelectedIndex = 1;
                    ddlEscribe.SelectedIndex = 1;
                    cargarDiscapacitado();
                }


                txtAccionIdioma.Value = "actualizar";
                break;
        }




    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {


        modalIdioma.Visible = true;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalIdioma').modal('show');", true);
    }

    protected void gvProgramas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ItemBL oItem = new ItemBL();
        switch (e.CommandName.ToString())
        {
            case "editar":
                string[] arg = new string[3];
                arg = e.CommandArgument.ToString().Split(';');
                HFIDInteres.Value = arg[0].ToString();
                CargarCombo(ddlInteres, arg[1].ToString());
                CargarCombo(ddlNivelInteres, arg[2].ToString());
                txtOtrosCurso.Text = arg[3].ToString();
                txtAccionInteres.Value = "actualizar";

                break;
        }
    }


    protected void LinkButton2_Click3(object sender, EventArgs e)
    {
        modalInteres.Visible = true;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalInteres').modal('show');", true);
    }

    protected void gvExperiencia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "editar":
                string[] arg = new string[6];
                arg = e.CommandArgument.ToString().Split(';');
                HFIDExperiencia.Value = arg[0].ToString();
                txtExperienciaEmpresa.Text = arg[1].ToString();
                txtExperienciaCargo.Text = arg[2].ToString();
                ddlExperienciaMesInicio.SelectedValue = arg[3].ToString();
                ddlExperienciaAnnoInicio.SelectedValue = arg[4].ToString();
                ddlExperienciaMesFin.SelectedValue = arg[5].ToString();
                ddlExperienciaAnnoFin.SelectedValue = arg[6].ToString();
                txtAccionExperiencia.Value = "actualizar";

                break;
        }

    }

    protected void LinkButton2_Click2(object sender, EventArgs e)
    {
        modalExperiencia.Visible = true;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('.modalExperiencia').modal('show');", true);
    }
    #endregion

    protected void ddlEstadoPersonal_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarEmpleados();
    }
}