using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Operativo_Estadisticas : System.Web.UI.Page
{
    StringBuilder codeChart = new StringBuilder();
    List<EstadisticasServiciosOP> lst;
    List<EstadisticasTercerosOP> lista_transporte;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarDDL();
            GraphicsService();
            GraphicsTransporte();
            pnlReporte.Visible = true;
        }
    }

    public void CargarDDL()
    {
        //CargarMeses(ddlMes);
        CargarMeses(ddlMesDS);
        CargarMeses(ddlMesPT);
        CargarMeses(ddlMesSO);
        CargarMeses(ddlMesTS);
        //CargarAño(ddlAño);
        CargarAño(ddlAñoDS);
        CargarAño(ddlAñoPT);
        CargarAño(ddlAñoSO);
        CargarAño(ddlAñoTS);
        //ddlMes.SelectedIndex = System.DateTime.Now.Month;
        ddlMesDS.SelectedIndex = System.DateTime.Now.Month;
        ddlMesPT.SelectedIndex = System.DateTime.Now.Month;
        ddlMesSO.SelectedIndex = System.DateTime.Now.Month;
        ddlMesTS.SelectedIndex = System.DateTime.Now.Month;
        //ddlAño.SelectedIndex = 2;
        ddlAñoDS.SelectedIndex = 3;
        ddlAñoPT.SelectedIndex = 3;
        ddlAñoSO.SelectedIndex = 3;
        ddlAñoTS.SelectedIndex = 3;
    }


    public void Grafico1()
    {
        int total = 0;
        EstadisticaOPBL oEstadistica = new EstadisticaOPBL();
        EstadisticaOPEL entidad = new EstadisticaOPEL();

        //entidad2.fchIni = DateTime.Parse("01/07/2018");
        //entidad2.fchFin = DateTime.Parse("31/07/2018");
        //entidad2.fchIni = DateTime.Parse(txtInicio.Text);
        entidad.fchIni = DateTime.Parse("01/" + ddlMesSO.SelectedIndex.ToString() + "/" + ddlAñoSO.SelectedItem.Text.ToString());
        entidad.fchFin = DateTime.Parse(DateTime.DaysInMonth(Convert.ToInt32(ddlAñoSO.SelectedItem.Text.ToString()), Convert.ToInt32(ddlMesSO.SelectedIndex.ToString())).ToString() + "/" + ddlMesSO.SelectedIndex.ToString() + "/" + ddlAñoSO.SelectedItem.Text.ToString());

        List<EstadisticasServiciosOP> lista = oEstadistica.ReporteServicios(entidad);

        codeChart.AppendLine("var common_data = [");
        codeChart.AppendLine(" ['Year', 'Total'],");

        codeChart.AppendLine("['" + "Descarga" + "'," + lista[0].descarga.ToString() + "],");
        codeChart.AppendLine("['" + "Embarque" + "'," + lista[0].embarque.ToString() + "],");
        codeChart.AppendLine("['" + "D/Vacios   " + "'," + lista[0].descarga_vacio.ToString() + "],");
        codeChart.AppendLine("['" + "E/Vacio" + "'," + lista[0].embarque_vacio.ToString() + "]");

        lblSO.Text = "" + (total = lista[0].descarga + lista[0].embarque + lista[0].descarga_vacio + lista[0].embarque_vacio);
        codeChart.AppendLine("];");

        codeChart.AppendLine("$.GoogleChart.createColumnChart($('#column-chart-3')[0], common_data, 'Servicio por Operacion', ['#4bd396', '#f5707a']);");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler4", codeChart.ToString(), true);

    }

    public void Grafico2()
    {
        EstadisticaOPEL entidad2 = new EstadisticaOPEL();
        EstadisticaOPBL oEstadistica = new EstadisticaOPBL();

        entidad2.fchIni = DateTime.Parse("01/" + ddlMesDS.SelectedIndex.ToString() + "/" + ddlAñoDS.SelectedItem.Text.ToString());
        entidad2.fchFin = DateTime.Parse(DateTime.DaysInMonth(Convert.ToInt32(ddlAñoDS.SelectedItem.Text.ToString()), Convert.ToInt32(ddlMesDS.SelectedIndex.ToString())) + "/" + ddlMesDS.SelectedIndex.ToString() + "/" + ddlAñoDS.SelectedItem.Text.ToString());

        List<EstadisticasServiciosOP> lista2 = oEstadistica.ReporteServicios(entidad2);

        codeChart.AppendLine("var common_data = [");
        codeChart.AppendLine(" ['Year', 'Total'],");
        codeChart.AppendLine("['" + "D/AP" + "'," + lista2[0].descarga_APM.ToString() + "],");
        codeChart.AppendLine("['" + "D/DP" + "'," + lista2[0].descarga_DPW.ToString() + "],");
        codeChart.AppendLine("['" + "E/DP" + "'," + lista2[0].embarque_DPW.ToString() + "],");
        codeChart.AppendLine("['" + "E/AP" + "'," + lista2[0].embarque_APM.ToString() + "],");
        codeChart.AppendLine("['" + "D/V AP" + "'," + lista2[0].descarga_vacio_APM.ToString() + "],");
        codeChart.AppendLine("['" + "D/V DP" + "'," + lista2[0].descarga_vacio_DPW.ToString() + "],");
        codeChart.AppendLine("['" + "E/V AP" + "'," + lista2[0].embarque_vacio_APM.ToString() + "],");
        codeChart.AppendLine("['" + "E/V DP" + "'," + lista2[0].embarque_vacio_DPW.ToString() + "],");
        codeChart.AppendLine("];");
        lblDS.Text = "" + (lista2[0].descarga_APM + lista2[0].descarga_DPW + lista2[0].embarque_DPW + lista2[0].embarque_APM + lista2[0].descarga_vacio_APM + lista2[0].descarga_vacio_DPW + lista2[0].embarque_vacio_APM + lista2[0].embarque_vacio_DPW);

        codeChart.AppendLine("$.GoogleChart.createColumnChart($('#column-chart-4')[0], common_data, 'Detalle por Operacion', ['#188ae2']);");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler4", codeChart.ToString(), true);
    }

    public void Grafico3()
    {
        EstadisticaOPBL oEstadistica = new EstadisticaOPBL();
        EstadisticaOPEL entidad3 = new EstadisticaOPEL();
        //entidad3.fchIni = DateTime.Parse("01/07/2018");
        //entidad3.fchFin = DateTime.Parse("31/07/2018");
        entidad3.fchIni = DateTime.Parse("01/" + ddlMesPT.SelectedIndex.ToString() + "/" + ddlAñoPT.SelectedItem.Text.ToString());
        entidad3.fchFin = DateTime.Parse(DateTime.DaysInMonth(Convert.ToInt32(ddlAñoPT.SelectedItem.Text.ToString()), Convert.ToInt32(ddlMesPT.SelectedIndex.ToString())) + "/" + ddlMesPT.SelectedIndex.ToString() + "/" + ddlAñoPT.SelectedItem.Text.ToString());

        lista_transporte = oEstadistica.ReporteTercero(entidad3);
        ////creating pie chart
        codeChart.AppendLine("var pie_data = [");
        codeChart.AppendLine("    ['Propio', 'Tercero'],");
        codeChart.AppendLine("['" + "Tercero" + "'," + lista_transporte[0].servicios_terceros.ToString() + "],");
        codeChart.AppendLine("['" + "Propio" + "'," + lista_transporte[0].servicios_propios.ToString() + "],");
        codeChart.AppendLine("];");
        codeChart.AppendLine("$.GoogleChart.createPieChart($('#pie-3d-chart')[0], pie_data, ['#f5707a', '#6b5fb5', '#f9c851', '#f5707a', '#6b5fb5'], true, false);");
        lblPT1.Text = "" + lista_transporte[0].servicios_propios;
        lblPT2.Text = "" + lista_transporte[0].servicios_terceros;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler4", codeChart.ToString(), true);
    }

    public void Grafico4()
    {
        EstadisticaOPBL oEstadistica = new EstadisticaOPBL();
        EstadisticaOPEL entidad2 = new EstadisticaOPEL();
        entidad2.fchIni = DateTime.Parse("01/" + ddlMesTS.SelectedIndex.ToString() + "/" + ddlAñoTS.SelectedItem.Text.ToString());
        entidad2.fchFin = DateTime.Parse(DateTime.DaysInMonth(Convert.ToInt32(ddlAñoTS.SelectedItem.Text.ToString()), Convert.ToInt32(ddlMesTS.SelectedIndex.ToString())) + "/" + ddlMesTS.SelectedIndex.ToString() + "/" + ddlAñoTS.SelectedItem.Text.ToString());

        List<EstadisticasServiciosOP> lista3 = oEstadistica.ReporteServicios(entidad2);

        ////creating pie chart
        codeChart.AppendLine("var pie_data = [");
        codeChart.AppendLine("    ['DPW', 'APM'],");
        codeChart.AppendLine("['" + "DPW" + "'," + lista3[0].servicios_DPW.ToString() + "],");
        codeChart.AppendLine("['" + "APM" + "'," + lista3[0].servicios_APM.ToString() + "],");
        codeChart.AppendLine("];");
        codeChart.AppendLine("$.GoogleChart.createPieChart($('#pie-3d-chart-2')[0], pie_data, ['#188ae2', '#4bd396', '#f9c851', '#f5707a', '#6b5fb5'], true, false);");
        lblTS1.Text = "" + lista3[0].servicios_APM;
        lblTS2.Text = "" + lista3[0].servicios_DPW;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler4", codeChart.ToString(), true);
    }

    public void GraphicsService()
    {

        EstadisticaOPEL entidad = new EstadisticaOPEL();
        EstadisticaOPBL oEstadistica = new EstadisticaOPBL();

        entidad.fchIni = DateTime.Parse("01/01/2018");
        entidad.fchFin = DateTime.Parse("31/12/2019");
        int total = 0;
        int totalpasado = 0;
        lst = oEstadistica.ReporteServicios(entidad);


        //codeChart.AppendLine("$(document).ready(function(){ ");
        codeChart.AppendLine("var column_data = [");
        codeChart.AppendLine("    ['Mes', '"+ (System.DateTime.Now.Year-1) + "' , '"+ System.DateTime.Now.Year+ "'],");

        for (int i = 0; i <= lst.Count - 1; i++)
        {
            if (i >= 12)
            {
                if (i == lst.Count - 1)
                {
                    //codeChart.AppendLine("['" + lst[i].fecha.Replace(" 2018", "") + "'," + lst[i - 12].total.ToString() + "," + lst[i].total.ToString() + "]");
                    codeChart.AppendLine("['" + lst[i].fecha.Substring(0,3) + "'," + lst[i - 12].total.ToString() + "," + lst[i].total.ToString() + "]");
                    TotalServiciosAnual1.Text = (totalpasado += lst[i - 12].total)+"" ;
                    TotalServiciosAnual2.Text = "" + (total += lst[i].total);
                }
                else
                {
                    codeChart.AppendLine("['" + lst[i].fecha.Substring(0, 3) + "'," + lst[i - 12].total.ToString() + "," + lst[i].total.ToString() + "],");
                    TotalServiciosAnual1.Text = (totalpasado += lst[i - 12].total) + "";
                    TotalServiciosAnual2.Text = "" + (total += lst[i].total);
                }
            }


        }

        codeChart.AppendLine("];");
        codeChart.AppendLine("$.GoogleChart.createColumnChart($('#column-chart')[0], column_data, 'Número de Servicios', ['#f5707a','#3ac9d6']);");
        //codeChart.AppendLine("});");



        //** Scond Graphics**//
        EstadisticaOPEL entidad2 = new EstadisticaOPEL();
        EstadisticaOPBL oEstadistica2 = new EstadisticaOPBL();

        //entidad2.fchIni = DateTime.Parse("01/07/2018");
        //entidad2.fchFin = DateTime.Parse("31/07/2018");
        //entidad2.fchIni = DateTime.Parse(txtInicio.Text);
        entidad2.fchIni = DateTime.Parse("01/" + ddlMesSO.SelectedIndex.ToString() + "/" + ddlAñoSO.SelectedItem.Text.ToString());
        entidad2.fchFin = DateTime.Parse(DateTime.DaysInMonth(Convert.ToInt32(ddlAñoSO.SelectedItem.Text.ToString()), Convert.ToInt32(ddlMesSO.SelectedIndex.ToString())).ToString()+"/" + ddlMesSO.SelectedIndex.ToString() + "/" + ddlAñoSO.SelectedItem.Text.ToString());

        List<EstadisticasServiciosOP> lista = oEstadistica.ReporteServicios(entidad2);

        entidad2.fchIni = DateTime.Parse("01/" + ddlMesDS.SelectedIndex.ToString() + "/" + ddlAñoDS.SelectedItem.Text.ToString());
        entidad2.fchFin = DateTime.Parse(DateTime.DaysInMonth(Convert.ToInt32(ddlAñoDS.SelectedItem.Text.ToString()), Convert.ToInt32(ddlMesDS.SelectedIndex.ToString())) + "/" + ddlMesDS.SelectedIndex.ToString() + "/" + ddlAñoDS.SelectedItem.Text.ToString());

        List<EstadisticasServiciosOP> lista2 = oEstadistica.ReporteServicios(entidad2);



        codeChart.AppendLine("var common_data = [");
        codeChart.AppendLine(" ['Year', 'Total'],");

        codeChart.AppendLine("['" + "Descarga" + "'," + lista[0].descarga.ToString() + "],");
        codeChart.AppendLine("['" + "Embarque" + "'," + lista[0].embarque.ToString() + "],");
        codeChart.AppendLine("['" + "D/Vacios   " + "'," + lista[0].descarga_vacio.ToString() + "],");
        codeChart.AppendLine("['" + "E/Vacio" + "'," + lista[0].embarque_vacio.ToString() + "]");

        lblSO.Text = "" + (total = lista[0].descarga + lista[0].embarque + lista[0].descarga_vacio + lista[0].embarque_vacio);
        codeChart.AppendLine("];");

        codeChart.AppendLine("$.GoogleChart.createColumnChart($('#column-chart-3')[0], common_data, 'Servicio por Operacion', ['#4bd396', '#f5707a']);");

        //GOOGLE CHATRT//

        codeChart.AppendLine("var common_data = [");
        codeChart.AppendLine(" ['Year', 'Total'],");
        codeChart.AppendLine("['" + "D/AP" + "'," + lista2[0].descarga_APM.ToString() + "],");
        codeChart.AppendLine("['" + "D/DP" + "'," + lista2[0].descarga_DPW.ToString() + "],");
        codeChart.AppendLine("['" + "E/DP" + "'," + lista2[0].embarque_DPW.ToString() + "],");
        codeChart.AppendLine("['" + "E/AP" + "'," + lista2[0].embarque_APM.ToString() + "],");
        codeChart.AppendLine("['" + "D/V AP" + "'," + lista2[0].descarga_vacio_APM.ToString() + "],");
        codeChart.AppendLine("['" + "D/V DP" + "'," + lista2[0].descarga_vacio_DPW.ToString() + "],");
        codeChart.AppendLine("['" + "E/V AP" + "'," + lista2[0].embarque_vacio_APM.ToString() + "],");
        codeChart.AppendLine("['" + "E/V DP" + "'," + lista2[0].embarque_vacio_DPW.ToString() + "],");
        codeChart.AppendLine("];");
        lblDS.Text = "" + (lista2[0].descarga_APM + lista2[0].descarga_DPW + lista2[0].embarque_DPW + lista2[0].embarque_APM + lista2[0].descarga_vacio_APM + lista2[0].descarga_vacio_DPW + lista2[0].embarque_vacio_APM + lista2[0].embarque_vacio_DPW);
        codeChart.AppendLine("$.GoogleChart.createColumnChart($('#column-chart-4')[0], common_data, 'Detalle por Operacion', ['#188ae2']);");


        codeChart.AppendLine("var common_data = [");
        codeChart.AppendLine(" ['Mes', 'Descarga DPW/APM', 'Embarque DPW/APM','Embarque Vacios DPW/APM','Descarga Vacios DPW/APM'],");

        entidad.fchIni = DateTime.Parse("01/01/2019");
        entidad.fchFin = DateTime.Parse(System.DateTime.Now.ToShortDateString());
        total = 0;
        int descarga = 0;
        int embarque = 0;
        int descargaV = 0;
        int embarqueV = 0;
        lst = oEstadistica.ReporteServicios(entidad);
        for (int i = 0; i <= lst.Count - 1; i++)
        {
            if (i == lst.Count - 1)
            {
                //codeChart.AppendLine("['" + lst[i].fecha.Replace(" 2018", "") + "'," + lst[i].descarga.ToString() + "," + lst[i].embarque.ToString() + "," + lst[i].embarque_vacio.ToString() + "," + lst[i].descarga_vacio.ToString() + "]");
                codeChart.AppendLine("['" + lst[i].fecha.Replace(" 2019", "") + "'," + lst[i].descarga.ToString() + "," + lst[i].embarque.ToString() + "," + lst[i].embarque_vacio.ToString() + "," + lst[i].descarga_vacio.ToString() + "]");
                lblServicioOperacion1.Text = "" + (descarga += lst[i].descarga );
                lblServicioOperacion2.Text = "" + (embarque += lst[i].embarque );
                lblServicioOperacion3.Text = "" + (descargaV +=lst[i].descarga_vacio);
                lblServicioOperacion4.Text = "" + (embarqueV += lst[i].embarque_vacio);
            }
            else
            {
                codeChart.AppendLine("['" + lst[i].fecha.Replace(" 2019", "") + "'," + lst[i].descarga.ToString() + "," + lst[i].embarque.ToString() + "," + lst[i].embarque_vacio.ToString() + "," + lst[i].descarga_vacio.ToString() + "],");
                lblServicioOperacion1.Text = "" + (descarga += lst[i].descarga);
                lblServicioOperacion2.Text = "" + (embarque += lst[i].embarque);
                lblServicioOperacion3.Text = "" + (embarqueV += lst[i].embarque_vacio);
                lblServicioOperacion4.Text = "" + (descargaV += lst[i].descarga_vacio);
                
            }
        }
        codeChart.AppendLine("];");
        codeChart.AppendLine("$.GoogleChart.createLineChart($('#line-chart')[0], common_data, 'Sales and Expenses', ['#188ae2', '#f5707a', '#3ac9d6','#4bd396']);");

        entidad2.fchIni = DateTime.Parse("01/" + ddlMesTS.SelectedIndex.ToString() + "/" + ddlAñoTS.SelectedItem.Text.ToString());
        entidad2.fchFin = DateTime.Parse(DateTime.DaysInMonth(Convert.ToInt32(ddlAñoTS.SelectedItem.Text.ToString()), Convert.ToInt32(ddlMesTS.SelectedIndex.ToString())) + "/" + ddlMesTS.SelectedIndex.ToString() + "/" + ddlAñoTS.SelectedItem.Text.ToString());

        List<EstadisticasServiciosOP> lista3 = oEstadistica.ReporteServicios(entidad2);

        ////creating pie chart
        codeChart.AppendLine("var pie_data = [");
        codeChart.AppendLine("    ['DPW', 'APM'],");
        codeChart.AppendLine("['" + "DPW" + "'," + lista3[0].servicios_DPW.ToString() + "],");
        codeChart.AppendLine("['" + "APM" + "'," + lista3[0].servicios_APM.ToString() + "],");
        codeChart.AppendLine("];");
        codeChart.AppendLine("$.GoogleChart.createPieChart($('#pie-3d-chart-2')[0], pie_data, ['#188ae2', '#4bd396', '#f9c851', '#f5707a', '#6b5fb5'], true, false);");
        total = 0;
        lblTS1.Text = "" + lista3[0].servicios_APM;
        lblTS2.Text = "" + lista3[0].servicios_DPW;


        //ScriptManager.RegisterStartupScript(this, this.GetType(), "aler4", codeChart.ToString(), true);

    }

    public void GraphicsTransporte()
    {
        EstadisticaOPEL entidad = new EstadisticaOPEL();
        EstadisticaOPBL oEstadistica = new EstadisticaOPBL();
        //int total = 0;
        //entidad.fchIni = DateTime.Parse("01/" + System.DateTime.Now.Month + "/" + (Convert.ToInt32(System.DateTime.Now.Year) - 1));
        //entidad.fchFin = DateTime.Parse("01/" + System.DateTime.Now.Month + "/" + Convert.ToInt32(System.DateTime.Now.Year));
        entidad.fchIni = DateTime.Parse("01/01/" + Convert.ToInt32(System.DateTime.Now.Year));
        entidad.fchFin = DateTime.Parse("01/12/" + Convert.ToInt32(System.DateTime.Now.Year));

        lista_transporte = oEstadistica.ReporteTercero(entidad);

        int propios = 0;
        int terceros = 0;

        //codeChart.AppendLine("$(document).ready(function(){ ");
        codeChart.AppendLine("var column_data = [");
        codeChart.AppendLine("    ['Mes', 'Propio' , 'Terceros'],");

        for (int i = 0; i <= lista_transporte.Count - 1; i++)
        {
            //if (i >= 12)
            //{
            if (i == lista_transporte.Count - 1)
            {
                codeChart.AppendLine("['" + lista_transporte[i].fecha.Substring(0, 3) + "'," + lista_transporte[i].servicios_propios.ToString() + "," + lista_transporte[i].servicios_terceros.ToString() + "]");
                lblServiciosPropioTercero1.Text = "" + (propios += lista_transporte[i].servicios_propios);
                lblServiciosPropioTercero2.Text = "" + (terceros +=   lista_transporte[i].servicios_terceros);
            }
            else
            {
                codeChart.AppendLine("['" + lista_transporte[i].fecha.Substring(0, 3) + "'," + lista_transporte[i].servicios_propios.ToString() + "," + lista_transporte[i].servicios_terceros.ToString() + "],");
                lblServiciosPropioTercero1.Text = "" + (propios += lista_transporte[i].servicios_propios);
                lblServiciosPropioTercero2.Text = "" + (terceros += lista_transporte[i].servicios_terceros);
            }
            //}
        }

        codeChart.AppendLine("];");
        codeChart.AppendLine("$.GoogleChart.createColumnChart($('#column-chart-2')[0], column_data, 'Número de Servicios', ['#f9c851','#4bd396']);");


        EstadisticaOPEL entidad3 = new EstadisticaOPEL();
        //entidad3.fchIni = DateTime.Parse("01/07/2018");
        //entidad3.fchFin = DateTime.Parse("31/07/2018");
        entidad3.fchIni = DateTime.Parse("01/" + ddlMesPT.SelectedIndex.ToString() + "/" + ddlAñoPT.SelectedItem.Text.ToString());
        entidad3.fchFin = DateTime.Parse(DateTime.DaysInMonth(Convert.ToInt32(ddlAñoPT.SelectedItem.Text.ToString()), Convert.ToInt32(ddlMesPT.SelectedIndex.ToString())) + "/" + ddlMesPT.SelectedIndex.ToString() + "/" + ddlAñoPT.SelectedItem.Text.ToString());

        lista_transporte = oEstadistica.ReporteTercero(entidad3);
        //total = 0;
        ////creating pie chart
        codeChart.AppendLine("var pie_data = [");
        codeChart.AppendLine("    ['Propio', 'Tercero'],");
        codeChart.AppendLine("['" + "Tercero" + "'," + lista_transporte[0].servicios_terceros.ToString() + "],");
        codeChart.AppendLine("['" + "Propio" + "'," + lista_transporte[0].servicios_propios.ToString() + "],");
        codeChart.AppendLine("];");
        codeChart.AppendLine("$.GoogleChart.createPieChart($('#pie-3d-chart')[0], pie_data, ['#f5707a', '#6b5fb5', '#f9c851', '#f5707a', '#6b5fb5'], true, false);");
        lblPT1.Text = "" + lista_transporte[0].servicios_propios;
        lblPT2.Text = "" + lista_transporte[0].servicios_terceros;

        ScriptManager.RegisterStartupScript(this, this.GetType(), "aler4", codeChart.ToString(), true);

    }





    protected void lnkReporte_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalAlert').modal('show');", true);
    }

    protected void lnkGenerar_Click(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(txtInicio.Text) < Convert.ToDateTime(txtFin.Text))
        {
            pnlReporte.Visible = true;
            GraphicsService();
            GraphicsTransporte();
        }
        else
        {
            MostrarMensaje(1, "La fecha de inicio debe ser menor a la fecha fin");
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
    }




    protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GraphicsService();
            GraphicsTransporte();
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "La fecha seleccionada no contiene registros");
        }
    }

    protected void ddlMesDS_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Grafico2();
            UpdatePanel2.Update();
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "La fecha seleccionada no contiene registros");
        }
    }

    protected void ddlMesSO_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Grafico1();
            UpdatePanel1.Update();
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "La fecha seleccionada no contiene registros");
        }
    }



    protected void ddlMesPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Grafico3();
            UpdatePanel3.Update();
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "La fecha seleccionada no contiene registros");
        }
    }

    protected void ddlMesTS_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Grafico4();
            UpdatePanel4.Update();
        }
        catch (Exception ex)
        {
            MostrarMensaje(1, "La fecha seleccionada no contiene registros");
        }
    }
}