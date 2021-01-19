<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="ReporteCombustible.aspx.cs" Inherits="Modulos_Reportes_ReporteCombustible" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!--Morris Chart CSS -->
    <link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Reportes de Combustible</h4>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    
    <!-- end row -->
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div class="panel m-b-lg" style="border-top:none;">
                        <ul id="tabsControl" class="nav nav-tabs nav-justified">
                        <li>
                            <asp:LinkButton ID="btnReporte1" runat="server" OnClick="btnReporte1_Click">Consumo de Flota</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="btnReporte2" runat="server" OnClick="btnReporte2_Click">Consumo por Area</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="btnReporte3" runat="server" OnClick="btnReporte3_Click">Resumen de Ventas</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="btnReporte4" runat="server" OnClick="btnReporte4_Click">Variacion de Diesel</asp:LinkButton>
                        </li>
                    </ul>
                        <div class="tab-content">
                            <div class="tab-pane fade active in" id="Reporte1" runat="server" style="padding:15px;">
                                <script>
                                    $(document).ready(function () {
                                        $("#tabsControl").find("li").eq(0).addClass("active");
                                    });
                                </script>
                                <div class="row">                              
                                    <div class="col-lg-12">
                                <div class="demo-box">
                                     
                                    <div class="form-group">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <asp:DropDownList CssClass="form-control" ID="ddlCliente" runat="server" >
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:DropDownList CssClass="form-control" ID="ddlMesP" runat="server" >
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:DropDownList CssClass="form-control" ID="ddlAñoP" runat="server" >
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:TextBox CssClass="form-control" ID="txtPlaca" runat="server" Placeholder="Nro° Placa"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="BUSCAR" />
                                        </div>
                                        <div class="clearfix"></div> 
                                    </div> 
                                    </div>
                                    <div class="table-responsive">
                                <asp:GridView ID="grvPlaca" runat="server" AutoGenerateColumns="False"
                                CssClass="table table-striped table-bordered dataTable " GridLines="None" OnPreRender="grvPlaca_PreRender">
                                    <Columns>
                                        <%--<asp:BoundField DataField="nom_empresa" HeaderText="nom_empresa"/>--%>
                                        <asp:BoundField DataField="unidad" HeaderText="Unidad" />
                                        <asp:BoundField DataField="nro_placa" HeaderText="N° de placa"/>
                                        <asp:BoundField DataField="cantidad_gl" HeaderText="Cantidad GL." DataFormatString="{0:n}"/>
                                        <asp:BoundField DataField="precio_galon_igv" HeaderText="Precio por galon(IGV)" DataFormatString="{0:n}"/>
                                        <asp:BoundField DataField="total_venta" HeaderText="Total de Venta(IGV)" DataFormatString="{0:n}"/>
                                        <asp:BoundField DataField="KmGalon" HeaderText="Km/Galon" DataFormatString="{0:n}"/>
                                        <asp:BoundField DataField="Km_Mayor" HeaderText="Km Mes Actual" DataFormatString="{0:n}"/>
                                        <asp:BoundField DataField="KM_Menor" HeaderText="Km Mes Anterior" DataFormatString="{0:n}"/>
                                        <asp:BoundField DataField="Km_recorrido" HeaderText="Km Recorrido" DataFormatString="{0:n}"/>
                                        <asp:BoundField DataField="Variacion" HeaderText="Variacion de rendimiento" DataFormatString="{0:n}"/>
                                        <asp:BoundField DataField="OPERACION" HeaderText="Area" DataFormatString="{0:n}"/>
                                        <%--<asp:BoundField DataField="CONSUMO" HeaderText="Consumo"/>--%>
                                    </Columns>
                                </asp:GridView>
                                </div>
                                </div>                                  
                            </div>                                                        
                                </div>
                            </div>
                            <div class="tab-pane fade active in" id="Reporte2" runat="server" visible="false" style="padding:15px;">
                                <script>
                                    $(document).ready(function () {
                                        $("#tabsControl").find("li").eq(1).addClass("active");
                                    });
                                </script>
                                <div class="row m-t-20">
                                           <%-- <h4 class="header-title">Consumo por Área Operativa</h4>--%>
                                            <div class="form-group">   
                                                <div class="col-lg-3"></div> 
                                                <div class="col-lg-3">
                                        <asp:DropDownList  CssClass="form-control" ID="ddlMesO" runat="server" OnSelectedIndexChanged="ddlMesO_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-3">
                                        <asp:DropDownList  CssClass="form-control" ID="ddlAñoO" runat="server" OnSelectedIndexChanged="ddlAñoO_SelectedIndexChanged" AutoPostBack="true" >
                                        </asp:DropDownList>
                                                    </div>
                                                <div class="clearfix"></div> 
                                            </div>
                                        </div>
                                <div class="row">                                        
                                    <div class="col-lg-12">                                           
                                        <h4 class="header-title text-center" style="display:block;">Variación Anual</h4>
                                        <div id="grafico-consumo-area-anual" style="width: 100%; height: 500px;"></div>    
                                        
                                    </div>  
                                     <div class="clearfix"></div>                         
                                </div>
                                <div class="row">                                        
                                    <div class="col-lg-12">                                           
                                        <h4 class="header-title text-center" style="display:block;">Variación Mensual</h4>
                                        <div id="grafico-consumo-area" style="width: 100%; height: 500px;"></div>        
                                    </div>  
                                     <div class="clearfix"></div>                         
                                </div>
                                <div class="row">       
                                     <div class="col-lg-2"></div> 
                                    <div class="col-lg-8">

                                        <div class="table-responsive">
                                            <asp:GridView ID="grvOperacion" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-striped table-bordered" GridLines="None">
                                                <Columns>
                                                    <asp:BoundField DataField="OPERACION" HeaderText="Área"/>
                                                    <asp:BoundField DataField="cantidad_gl" HeaderText="Cantidad Gl." DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField DataField="precio_galon_igv" HeaderText="Precio Gl." DataFormatString="S/ {0:n}" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="total_venta" HeaderText="Total Venta" DataFormatString="S/ {0:n}" ItemStyle-HorizontalAlign="Right"/>    
                                                    <asp:BoundField DataField="KmGalon" HeaderText="Km/Hr"/>    
                                        
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                          
                                    <div class="clearfix"></div>                         
                                </div>
                            
                            </div>
                            <div class="tab-pane fade active in" id="Reporte3" runat="server" visible="false" style="padding:15px;">
                                 <script>
                                    $(document).ready(function () {
                                        $("#tabsControl").find("li").eq(2).addClass("active");
                                    });
                                </script>     
                                <div class="row">    
                                                <div class="form-group">  
                                                    <div class="col-lg-3"></div>                                                  
                                                    <div class="col-lg-3">
                                            <asp:DropDownList  CssClass="form-control" ID="ddlMesV" runat="server" OnSelectedIndexChanged="ddlMesV_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                                    </div>
                                                    <div class="col-lg-3">
                                            <asp:DropDownList  CssClass="form-control" ID="ddlAñosV" runat="server" OnSelectedIndexChanged="ddlAñosV_SelectedIndexChanged" AutoPostBack="true" >
                                            </asp:DropDownList>
                                                        </div>
                                                    <div class="clearfix"></div>
                                                </div> 
                                            </div>   
                                <div class="table-responsive">
                                            <asp:GridView ID="gvrVentas" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-striped table-bordered" GridLines="None">
                                                <Columns>
                                                    <asp:BoundField DataField="nom_empresa" HeaderText="Empresa"/>
                                                    <asp:BoundField DataField="VentaDeGalones" HeaderText="Venta De Galones" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField DataField="TotalVenta" HeaderText="Total Venta" DataFormatString="S/ {0:n}" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Ganancia" HeaderText="Ganancia" DataFormatString="S/ {0:n}" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="Ahorro" HeaderText="Ahorro" DataFormatString="S/ {0:n}" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField DataField="PrecioCisterna" HeaderText="PrecioCisterna" Visible="false"/>
                                                    <asp:BoundField DataField="PrecioGrifo" HeaderText="PrecioGrifo" Visible="false"/>
                                                </Columns>
                                            </asp:GridView>
                                        </div>                   
                            </div>
                            <div class="tab-pane fade active in" id="Reporte4" runat="server" visible="false" style="padding:15px;">
                                 <script>
                                    $(document).ready(function () {
                                        $("#tabsControl").find("li").eq(3).addClass("active");
                                    });
                                </script>    
                                <div class="row">
                            <div class="col-lg-12">
                                <div class="demo-box">
                                    <div class="col-lg-3">
                                        
                                    </div>
                                    <div class="col-lg-6">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlDA" runat="server" OnSelectedIndexChanged="ddlDA_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlDM" runat="server" OnSelectedIndexChanged="ddlDM_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                        </DIV>
                                        </div>
                                     <div class="clearfix"></div>
                                    <br /><br />
                                    <h4 class="header-title text-center" style="display:block;">Variación Anual</h4>
                                    <br /><br /><br />

                                        <div class="row">
                                        <div class="chart" id="grafico-diesel-anual"></div>
                                            <br /><br /> 
                                            <h4 class="header-title text-center m-b-30" style="display:block;">Variación Mensual</h4>
                                        <br /> 
                                            <div class="chart" id="grafico-diesel-mensual"></div>
                                            
                                        <div class="clearfix"></div>

                                            
                                        </div>
                                    
                                </div>
                                <div class="table-responsive">
                                </div>
                        </div>

                        <div class="clearfix"></div> 
                        </div>                       
                            </div>
                        </div>
                    </div>

                     
            </asp:View>
           
           
          </asp:MultiView>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <!-- Google Charts js -->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <!-- Init -->
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/initReportes.js")%>'></script>


    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
   <%-- <script type="text/javascript">
      google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawVisualization);

      function drawVisualization() {
        // Some raw data (not necessarily accurate)
        var data = google.visualization.arrayToDataTable([
          ['Month', 'Bolivia', 'Ecuador', 'Madagascar', 'Papua New Guinea', 'Rwanda', 'Average'],
          ['2004/05',  165,      938,         522,             998,           450,      614.6],
          ['2005/06',  135,      1120,        599,             1268,          288,      682],
          ['2006/07',  157,      1167,        587,             807,           397,      623],
          ['2007/08',  139,      1110,        615,             968,           215,      609.4],
          ['2008/09',  136,      691,         629,             1026,          366,      569.6]
        ]);

        var options = { title : 'Monthly Coffee Production by Country', vAxis: {title: 'Cups'}, hAxis: {title: 'Month'}, seriesType: 'bars', series: {5: {type: 'line'}}        };

        var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));
        chart.draw(data, options);
      }
    </script>--%>
    
</asp:Content>

