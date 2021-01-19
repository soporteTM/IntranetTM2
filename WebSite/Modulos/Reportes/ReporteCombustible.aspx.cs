using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Globalization;

public partial class Modulos_Reportes_ReporteCombustible : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarDDL();
            ListarPlaca();
            //cargarGraficos();
        }
    }

    public void cargarGraficos()
    {
        ListarPlaca();
        ListarOperacionAnual();
        ListarOperacion();
        ListarVentas();
        listarVariacionDieselAnual();
        listarVariacionDieselMensual();
    }

    public void CargarDDL()
    {
        CargarMeses(ddlMesO);
        CargarMeses(ddlMesP);
        CargarMeses(ddlMesV);
        CargarMeses(ddlDM);
        CargarAño(ddlAñoO);
        CargarAño(ddlAñoP);
        CargarAño(ddlAñosV);
        CargarAño(ddlDA);
        ListarCliente();

        ddlMesO.SelectedIndex = System.DateTime.Now.Month;
        ddlMesP.SelectedIndex = System.DateTime.Now.Month;
        ddlMesV.SelectedIndex = System.DateTime.Now.Month;
        ddlDM.SelectedIndex = System.DateTime.Now.Month;

        ddlAñoO.SelectedIndex = 3;
        ddlAñosV.SelectedIndex = 3;
        ddlAñoP.SelectedIndex = 3;
        ddlDA.SelectedIndex = 3;
        ddlCliente.SelectedIndex = 2;
    }

    public void ListarCliente()
    {
        ClienteBL oCliente = new ClienteBL();
        List<ClienteEL> lst = oCliente.ListarCliente();
        ddlCliente.DataSource = lst;
        ddlCliente.DataValueField = "id_empresa";
        ddlCliente.DataTextField = "nom_empresa";
        ddlCliente.DataBind();
        ddlCliente.Items.Insert(0, new ListItem("", ""));
        
        ddlCliente.SelectedIndex = 0;
    }

    public void CargarMeses(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add("--Seleccione Mes--");
        ddl.Items.Add("Enero");
        ddl.Items.Add("Febrero");
        ddl.Items.Add("Marzo");
        ddl.Items.Add("Abril");
        ddl.Items.Add("Mayo");
        ddl.Items.Add("Junio");
        ddl.Items.Add("Julio");
        ddl.Items.Add("Agosto");
        ddl.Items.Add("Setiembre");
        ddl.Items.Add("Octubre");
        ddl.Items.Add("Noviembre");
        ddl.Items.Add("Diciembre");
    }

    public void CargarAño(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add("--Seleccione Año--");
        ddl.Items.Add("2017");
        ddl.Items.Add("2018");
        ddl.Items.Add("2019");
        ddl.Items.Add("2020");
        ddl.Items.Add("2021");
    }

    public void ListarPlaca()
    {
        AbastecimientoBL oEmpresa = new AbastecimientoBL();
        List<AbastecimientoEL> lst = oEmpresa.ListarReportePlaca(Convert.ToInt32(ddlAñoP.SelectedItem.Text),Convert.ToInt32(ddlMesP.SelectedIndex),txtPlaca.Text,ddlCliente.SelectedItem.Text);
        grvPlaca.DataSource = lst;
        grvPlaca.DataBind();

        //StringBuilder codeChart = new StringBuilder();
        //codeChart.AppendLine("var common_data = [");
        //codeChart.AppendLine(" ['Placa','KM / GL'],");
        //foreach (var item in lst)
        //{
        //    codeChart.AppendLine("['" + item.nro_placa + "'," + item.KmGalon+"],");
        //}
        //for(int i = 0; i <= 10 ; i++)
        //{
        //    codeChart.AppendLine("['" + lst[i].nro_placa + "'," + lst[i].KmGalon+"],");
        //}
        //codeChart.AppendLine("];");

        //codeChart.AppendLine("$.GoogleChart.createColumnChart($('#grafico-consumo-placa')[0], common_data, 'Consumo por Placa', ['#4bd396', '#f5707a']);");
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "aler3", codeChart.ToString(), true);
    }

    public void ListarOperacion()
    {
        AbastecimientoBL oEmpresa = new AbastecimientoBL();
        List<AbastecimientoEL> lst = oEmpresa.ListarReporteOperacion(Convert.ToInt32(ddlAñoO.SelectedItem.Text), Convert.ToInt32(ddlMesO.SelectedIndex));
        grvOperacion.DataSource = lst;
        grvOperacion.DataBind();

        StringBuilder codeChart = new StringBuilder();

        codeChart.AppendLine("google.charts.load('current', {'packages':['corechart']});");
        codeChart.AppendLine("google.charts.setOnLoadCallback(drawVisualization);");
        codeChart.AppendLine("function drawVisualization() {");
        codeChart.AppendLine("var data = google.visualization.arrayToDataTable([");
        codeChart.AppendLine(" ['Área','Venta', 'Galones', 'Km/HR'],");
        foreach(var item in lst)
        {
            codeChart.AppendLine("['" + item.OPERACION + "'," + item.total_venta + "," + item.cantidad_gl + "," + item.KmGalon + "],");
        }
        codeChart.AppendLine("]);");

        //codeChart.AppendLine("$.GoogleChart.ComboChart($('#grafico-consumo-area')[0], common_data, 'Consumo por Área Operativa', ['#4bd396', '#f5707a' ,'#188ae2']);");
        codeChart.AppendLine("var options = {seriesType: 'bars', series: {2: {type: 'line'}}};");
        codeChart.AppendLine("var chart = new google.visualization.ComboChart(document.getElementById('grafico-consumo-area'));");
        codeChart.AppendLine("chart.draw(data, options);");
        codeChart.AppendLine("}");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler4", codeChart.ToString(), true);

    }

    public void ListarOperacionAnual()
    {
        AbastecimientoBL oEmpresa = new AbastecimientoBL();
        List<AbastecimientoEL> lst = oEmpresa.ListarReporteOperacionAnual(Convert.ToInt32(ddlAñoO.SelectedItem.Text));

        StringBuilder codeChart = new StringBuilder();

        codeChart.AppendLine("google.charts.load('current', {'packages':['corechart']});");
        codeChart.AppendLine("google.charts.setOnLoadCallback(drawVisualization2);");
        codeChart.AppendLine("function drawVisualization2() {");
        codeChart.AppendLine("var data = google.visualization.arrayToDataTable([");
        codeChart.AppendLine(" ['Mes','Venta', 'Galones', 'Km/HR'],");

        DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
        string fecha = "";
        string total = "0";
        string cantidadGL = "0";
        string KmGalon = "0";

        for (int i = 1; i <= 12; i++)
        {
            fecha = formatoFecha.GetMonthName(i);
            for (int x = 0; x <= lst.Count - 1; x++)
            {
                if (lst[x].fecha_registro.Equals(i.ToString()))
                {
                    total = Convert.ToString(lst[x].total_venta);
                    cantidadGL = Convert.ToString(lst[x].cantidad_gl);
                    KmGalon = Convert.ToString(lst[x].KmGalon);
                }
            }

            codeChart.AppendLine("['" + fecha + "'," + total + "," + cantidadGL + "," + KmGalon + "],");
            total = "0";
            cantidadGL = "0";
            KmGalon = "0";
        }
        codeChart.AppendLine("]);");

        //codeChart.AppendLine("$.GoogleChart.ComboChart($('#grafico-consumo-area')[0], common_data, 'Consumo por Área Operativa', ['#4bd396', '#f5707a' ,'#188ae2']);");
        codeChart.AppendLine("var options = {seriesType: 'bars', series: {2: {type: 'line'}}};");
        codeChart.AppendLine("var chart = new google.visualization.ComboChart(document.getElementById('grafico-consumo-area-anual'));");
        codeChart.AppendLine("chart.draw(data, options);");
        codeChart.AppendLine("}");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler7", codeChart.ToString(), true);

    }

    public void ListarVentas()
    {
        AbastecimientoBL oEmpresa = new AbastecimientoBL();
        List<AbastecimientoEL> lst = oEmpresa.ListarReporteVentas(Convert.ToInt32(ddlAñosV.SelectedItem.Text), Convert.ToInt32(ddlMesV.SelectedIndex));
        gvrVentas.DataSource = lst;
        gvrVentas.DataBind();
    }

    public void listarVariacionDieselAnual()
    {
        AbastecimientoBL oEmpresa = new AbastecimientoBL();
        List<CombustibleCompraEL> lst = oEmpresa.VariacionDieselAnual(Convert.ToInt32(ddlDA.SelectedItem.ToString()));

        string Grifo = "0";
        string refineria = "0";

        StringBuilder codeChart = new StringBuilder(); 
        codeChart.AppendLine("var common_data = [");
        codeChart.AppendLine(" ['Mes', 'Refineria', 'Grifo'],");

        DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
        string fecha = "";

        for (int i = 1; i <= 12; i++)
        {
            fecha = formatoFecha.GetMonthName(i);
            for (int x = 0; x<= lst.Count-1;x++)
            {
                if (lst[x].fecha_registro.Equals(i.ToString()))
                {
                    Grifo = Convert.ToString(lst[x].precio_compra_grifo);
                    refineria = Convert.ToString(lst[x].precio_compra_cisterna);
                }
            }

            if (i == 12)
            {
                codeChart.AppendLine("['" + fecha + "'," + Grifo + "," + refineria + "]");
                Grifo = "0";
                refineria = "0";
            }
            else
            {
                codeChart.AppendLine("['" + fecha + "'," + Grifo + "," + refineria + "],");
                Grifo = "0";
                refineria = "0";
            }
        }
        codeChart.AppendLine("];");
        codeChart.AppendLine("$.GoogleChart.createLineChart($('#grafico-diesel-anual')[0], common_data, 'VARIACION PRECIO DIESEL ANUAL', ['#188ae2', '#f5707a']);");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler5", codeChart.ToString(), true);
    }

    public void listarVariacionDieselMensual()
    {
        AbastecimientoBL oEmpresa = new AbastecimientoBL();
        List<CombustibleCompraEL> lst = oEmpresa.VariacionDieselMensual(Convert.ToInt32(ddlDA.SelectedItem.ToString()), ddlDM.SelectedIndex);

            StringBuilder codeChart = new StringBuilder(); 
            codeChart.AppendLine("var common_data = [");
            codeChart.AppendLine(" ['Fecha', 'Refineria', 'Grifo'],");

            for (int i = 0; i < lst.Count; i++)
            {
                if (i == lst.Count)
                {
                    codeChart.AppendLine("['" + lst[i].fecha_registro + "'," + lst[i].precio_compra_cisterna.ToString() + "," + lst[i].precio_compra_grifo.ToString() + "]");
                }
                else
                {
                    codeChart.AppendLine("['" + lst[i].fecha_registro + "'," + lst[i].precio_compra_cisterna.ToString() + "," + lst[i].precio_compra_grifo.ToString() + "],");
                }
            }
            codeChart.AppendLine("];");
            codeChart.AppendLine("$.GoogleChart.createLineChart($('#grafico-diesel-mensual')[0], common_data, 'VARIACION PRECIO DIESEL MES', ['#188ae2', '#f5707a']);");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "aler6", codeChart.ToString(), true);
        
    }


    protected void ddlMesO_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarOperacionAnual();
        ListarOperacion();
    }

    protected void ddlAñoO_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarOperacionAnual();
        ListarOperacion();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        ListarPlaca();
    }

    protected void grvPlaca_PreRender(object sender, EventArgs e)
    {
        if (grvPlaca.Rows.Count > 0)
        {
            grvPlaca.UseAccessibleHeader = true;
            grvPlaca.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvPlaca.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void ddlMesV_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarVentas();
    }

    protected void ddlAñosV_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarVentas();
    }

    protected void ddlDA_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarGraficos();
    }

    protected void ddlDM_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarGraficos();
    }

    protected void btnReporte1_Click(object sender, EventArgs e)
    {
        Reporte1.Visible = true;
        Reporte2.Visible = false;
        Reporte3.Visible = false;
        Reporte4.Visible = false;
        ListarPlaca();
    }

    protected void btnReporte2_Click(object sender, EventArgs e)
    {
        Reporte1.Visible = false;
        Reporte2.Visible = true;
        Reporte3.Visible = false;
        Reporte4.Visible = false;
        ListarOperacionAnual();
        ListarOperacion();
        
    }

    protected void btnReporte3_Click(object sender, EventArgs e)
    { 
        Reporte1.Visible = false;
        Reporte2.Visible = false;
        Reporte3.Visible = true;
        Reporte4.Visible = false;
        ListarVentas();
    }
    protected void btnReporte4_Click(object sender, EventArgs e)
    {
        Reporte1.Visible = false;
        Reporte2.Visible = false;
        Reporte3.Visible = false;
        Reporte4.Visible = true;
        listarVariacionDieselAnual();
        listarVariacionDieselMensual();
    }
}