using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
public partial class _graficos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StringBuilder codeChart = new StringBuilder();

            //Creado Line Chart  
            codeChart.AppendLine("$(document).ready(function(){ ");
            codeChart.AppendLine("var common_data = [");
            codeChart.AppendLine(" ['Year', 'Angelo', 'Francisco'],");
            codeChart.AppendLine(" ['2010',  850,      120],");
            codeChart.AppendLine("['2011',  745,      200],");
            codeChart.AppendLine("['2012',  852,      180],");
            codeChart.AppendLine("['2013',  1000,      400],");
            codeChart.AppendLine("['2014',  1170,      460],");
            codeChart.AppendLine("['2015',  660,       1120],");
            codeChart.AppendLine("['2016',  1030,      540]");
            codeChart.AppendLine("];");
            codeChart.AppendLine("$.GoogleChart.createLineChart($('#line-chart')[0], common_data, 'Sales and Expenses', ['#4bd396', '#f5707a', '#3ac9d6']);");

            //creating area chart using same data
            codeChart.AppendLine("$.GoogleChart.createAreaChart($('#area-chart')[0], common_data, 'Sales and Expenses', ['#4bd396', '#f5707a']);");

            ////creating column chart
            codeChart.AppendLine("var column_data = [");
           codeChart.AppendLine("    ['Year', 'Desktop', 'Tablets', 'Mobiles'],");
            codeChart.AppendLine("    ['2010',  850,      120, 200],");
            codeChart.AppendLine("    ['2011',  745,      200, 562],");
            codeChart.AppendLine("    ['2012',  852,      180, 521],");
            codeChart.AppendLine("    ['2013',  1000,      400, 652],");
            codeChart.AppendLine("    ['2014',  1170,      460, 200],");
            codeChart.AppendLine("    ['2015',  660,       1120, 562],");
            codeChart.AppendLine("    ['2016',  1030,      540, 852]");
            codeChart.AppendLine("];");
            codeChart.AppendLine("$.GoogleChart.createColumnChart($('#column-chart')[0], column_data, 'Sales and Expenses', ['#4bd396', '#f5707a', '#3ac9d6']);");


            ////creating bar chart
            codeChart.AppendLine("var bar_data = [");
            codeChart.AppendLine("    ['Year', 'Sales', 'Expenses'],");
            codeChart.AppendLine("    ['2004',  1000,      400],");
            codeChart.AppendLine("    ['2005',  1170,      460],");
            codeChart.AppendLine("    ['2006',  660,       1120],");
            codeChart.AppendLine("    ['2007',  1030,      540]");
            codeChart.AppendLine("];");
            codeChart.AppendLine("$.GoogleChart.createBarChart($('#bar-chart')[0], bar_data, ['#4bd396', '#f5707a']);");


            ////creating columns tacked chart
            codeChart.AppendLine("var column_stacked_data = [");
            codeChart.AppendLine("    ['Genre', 'Fantasy & Sci Fi', 'Romance', 'Mystery/Crime', 'General', 'Western', 'Literature', { role: 'annotation' } ],");
            codeChart.AppendLine("    ['2000', 20, 30, 35, 40, 45, 30, ''],");
            codeChart.AppendLine("    ['2005', 14, 20, 25, 30, 48, 30, ''],");
            codeChart.AppendLine("    ['2010', 10, 24, 20, 32, 18, 5, ''],");
            codeChart.AppendLine("    ['2015', 15, 25, 30, 35, 20, 15, ''],");
            codeChart.AppendLine("    ['2020', 16, 22, 23, 30, 16, 9, ''],");
            codeChart.AppendLine("    ['2025', 12, 26, 20, 40, 20, 30, ''],");
            codeChart.AppendLine("    ['2030', 28, 19, 29, 30, 12, 13, '']");
            codeChart.AppendLine("];");
            codeChart.AppendLine("$.GoogleChart.createColumnStackChart($('#column-stacked-chart')[0], column_stacked_data, 'Sales and Expenses', ['#188ae2', '#4bd396', '#f9c851', '#f5707a', '#6b5fb5', '#3ac9d6']);");


            ////creating bar tacked chart
            codeChart.AppendLine("var bar_stacked_data = [");
            codeChart.AppendLine("    ['Genre', 'Fantasy & Sci Fi', 'Romance', 'Mystery/Crime', 'General', 'Western', 'Literature', { role: 'annotation' } ],");
            codeChart.AppendLine("    ['2000', 20, 30, 35, 40, 45, 30, ''],");
            codeChart.AppendLine("    ['2005', 14, 20, 25, 30, 48, 30, ''],");
            codeChart.AppendLine("    ['2010', 10, 24, 20, 32, 18, 5, ''],");
            codeChart.AppendLine("    ['2015', 15, 25, 30, 35, 20, 15, ''],");
            codeChart.AppendLine("    ['2020', 16, 22, 23, 30, 16, 9, ''],");
            codeChart.AppendLine("    ['2025', 12, 26, 20, 40, 20, 30, ''],");
            codeChart.AppendLine("    ['2030', 28, 19, 29, 30, 12, 13, '']");
            codeChart.AppendLine("];");
            codeChart.AppendLine("$.GoogleChart.createBarStackChart($('#bar-stacked-chart')[0], bar_stacked_data, ['#188ae2', '#4bd396', '#f9c851', '#f5707a', '#6b5fb5', '#3ac9d6']);");


            ////creating pie chart
            codeChart.AppendLine("var pie_data = [");
            codeChart.AppendLine("    ['Task', 'Hours per Day'],");
            codeChart.AppendLine("    ['Work',     11],");
            codeChart.AppendLine("    ['Eat',      2],");
            codeChart.AppendLine("    ['Commute',  2],");
            codeChart.AppendLine("    ['Watch TV', 2],");
            codeChart.AppendLine("    ['Sleep',    7]");
            codeChart.AppendLine("];");
            codeChart.AppendLine("$.GoogleChart.createPieChart($('#pie-chart')[0], pie_data, ['#188ae2', '#4bd396', '#f9c851', '#f5707a', '#6b5fb5'], false, false);");


            ////creating donut chart
            codeChart.AppendLine("$.GoogleChart.createDonutChart($('#donut-chart')[0], pie_data, ['#188ae2', '#4bd396', '#f9c851', '#f5707a', '#6b5fb5']);");

            ////creating 3d pie chart
            codeChart.AppendLine("$.GoogleChart.createPieChart($('#pie-3d-chart')[0], pie_data, ['#188ae2', '#4bd396', '#f9c851', '#f5707a', '#6b5fb5'], true, false);");

            ////creating Sliced pie chart
            codeChart.AppendLine("var sliced_Data = [");
            codeChart.AppendLine("    ['Language', 'Speakers (in millions)'],");
            codeChart.AppendLine("    ['Assamese', 13],");
            codeChart.AppendLine("    ['Bengali', 83],");
            codeChart.AppendLine("    ['Gujarati', 46],");
            codeChart.AppendLine("    ['Hindi', 90],");
            codeChart.AppendLine("    ['Kannada', 38],");
            codeChart.AppendLine("    ['Malayalam', 33]");
            codeChart.AppendLine("];");
            codeChart.AppendLine("$.GoogleChart.createPieChart($('#3d-exploded-chart')[0], sliced_Data, ['#188ae2', '#4bd396', '#f9c851', '#f5707a', '#6b5fb5'], true, true);");



            codeChart.AppendLine("});"); 
           ScriptManager.RegisterStartupScript(this, this.GetType(), "aler4", codeChart.ToString(), true);
        }
    }
}