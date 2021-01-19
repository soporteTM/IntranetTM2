<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <!--Morris Chart CSS -->
		<link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        !function ($) {
            "use strict";

            var Dashboard1 = function () {
                this.$realData = []
            };

            //creates Bar chart
            Dashboard1.prototype.createBarChart = function (element, data, xkey, ykeys, labels, lineColors) {
                Morris.Bar({
                    element: element,
                    data: data,
                    xkey: xkey,
                    ykeys: ykeys,
                    labels: labels,
                    hideHover: 'auto',
                    resize: true, //defaulted to true
                    gridLineColor: '#eeeeee',
                    barSizeRatio: 0.2,
                    barColors: lineColors,
                    postUnits: 'k'
                });
            },

            //creates line chart
            Dashboard1.prototype.createLineChart = function (element, data, xkey, ykeys, labels, opacity, Pfillcolor, Pstockcolor, lineColors) {
                Morris.Line({
                    element: element,
                    data: data,
                    xkey: xkey,
                    ykeys: ykeys,
                    labels: labels,
                    fillOpacity: opacity,
                    pointFillColors: Pfillcolor,
                    pointStrokeColors: Pstockcolor,
                    behaveLikeLine: true,
                    gridLineColor: '#eef0f2',
                    hideHover: 'auto',
                    resize: true, //defaulted to true
                    pointSize: 0,
                    lineColors: lineColors,
                    postUnits: 'k'
                });
            },

            //creates Donut chart
            Dashboard1.prototype.createDonutChart = function (element, data, colors) {
                Morris.Donut({
                    element: element,
                    data: data,
                    resize: true, //defaulted to true
                    colors: colors
                });
            },


            Dashboard1.prototype.init = function () {

                //creating bar chart
                var $barData = [
                    { y: '01/16', a: 42 },
                    { y: '02/16', a: 75 },
                    { y: '03/16', a: 38 },
                    { y: '04/16', a: 19 },
                    { y: '05/16', a: 93 }
                ];
                this.createBarChart('morris-bar-example', $barData, 'y', ['a'], ['Statistics'], ['#3bafda']);

                //create line chart
                var $data = [
                    { y: '2008', a: 50, b: 0 },
                    { y: '2009', a: 75, b: 50 },
                    { y: '2010', a: 30, b: 80 },
                    { y: '2011', a: 50, b: 50 },
                    { y: '2012', a: 75, b: 10 },
                    { y: '2013', a: 50, b: 40 },
                    { y: '2014', a: 75, b: 50 },
                    { y: '2015', a: 100, b: 70 }
                ];
                this.createLineChart('morris-line-example', $data, 'y', ['a', 'b'], ['Series A', 'Series B'], ['0.9'], ['#ffffff'], ['#999999'], ['#10c469', '#188ae2']);

                //creating donut chart
                var $donutData = [
                        { label: "Unidades", value: 183 },
                        { label: "Maquinarias", value: 30 }
                ];
                this.createDonutChart('morris-donut-example', $donutData, ['#3ac9d6', '#f5707a']);
            },
            //init
            $.Dashboard1 = new Dashboard1, $.Dashboard1.Constructor = Dashboard1
        }(window.jQuery),

//initializing 
function ($) {
    "use strict";
    $.Dashboard1.init();
}(window.jQuery);
    </script>


      <div class="row">
							<div class="col-xs-12">
								<div class="page-title-box">
                                    <h4 class="page-title">Dashboard</h4>
                                    <ol class="breadcrumb p-0 m-0">
                                        <li>
                                            <a href="#">Flota</a>
                                        </li>
                                        <li>
                                            <a href="#">Dashboard</a>
                                        </li>
                                        <li class="active">
                                            Dashboard
                                        </li>
                                    </ol>
                                    <div class="clearfix"></div>
                                </div>
							</div>
						</div>
                        <!-- end row -->

                        <div class="row">

                            <div class="col-xl-2 col-md-2">
                                <div class="card-box widget-box-two widget-two-primary">
                                    <i class="mdi mdi-account-multiple widget-two-icon"></i>
                                    <div class="wigdet-two-content">
                                        <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="Statistics">PERSONAL ACTIVO</p>
                                        <h2><span data-plugin="counterup">0</span> <small><i class="mdi mdi-arrow-up text-success"></i></small></h2>
                                        <p class="text-muted m-0"><b>OPERACIONES</b></p>
                                    </div>
                                </div>
                            </div>

                            <div class="col-xl-3 col-md-2">
                                <div class="card-box widget-box-two widget-two-success">
                                    <i class="mdi mdi-account-multiple widget-two-icon"></i>
                                    <div class="wigdet-two-content">
                                        <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="User Today">PERSONAL ACTIVO</p>
                                        <h2><span data-plugin="counterup">95</span> <small><i class="mdi mdi-arrow-down text-danger"></i></small></h2>
                                        <p class="text-muted m-0"><b>ADMINISTRATIVOS</b></p>
                                    </div>
                                </div>
                            </div>

                            <div class="col-xl-3 col-md-2">
                                <div class="card-box widget-box-two widget-two-warning">
                                    <i class="mdi mdi-account-multiple widget-two-icon"></i>
                                    <div class="wigdet-two-content">
                                        <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="User Today">PERSONAL ACTIVO</p>
                                        <h2><span data-plugin="counterup">210</span> <small><i class="mdi mdi-arrow-down text-danger"></i></small></h2>
                                        <p class="text-muted m-0"><b>CONDUCTORES</b></p>
                                    </div>
                                </div>
                            </div>

                            <div class="col-xl-3 col-md-2">
                                <div class="card-box widget-box-two widget-two-warning">
                                    <i class="mdi mdi-account-multiple widget-two-icon"></i>
                                    <div class="wigdet-two-content">
                                        <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="User Today">PERSONAL ACTIVO</p>
                                        <h2><span data-plugin="counterup">305</span> <small><i class="mdi mdi-arrow-down text-danger"></i></small></h2>
                                        <p class="text-muted m-0"><b>TOTAL</b></p>
                                    </div>
                                </div>
                            </div>


                            <div class="col-lg-2 col-md-4 col-sm-6">
                                <div class="card-box widget-box-one">
                                    <i class="fa fa-truck widget-one-icon"></i>
                                    <div class="wigdet-one-content">
                                        <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="Statistics">Unidades</p>
                                        <h2>183 <small><i class="mdi mdi-arrow-up text-success"></i></small></h2>
                                        <p class="text-muted m-0"><b>Unidades </b> Registradas </p>
                                    </div>
                                </div>
                            </div><!-- end col -->

                            <div class="col-lg-2 col-md-4 col-sm-6">
                                <div class="card-box widget-box-one">
                                    <i class="mdi mdi-car widget-one-icon"></i>
                                    <div class="wigdet-one-content">
                                        <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="User Today">Maquinaria</p>
                                        <h2>30 <small><i class="mdi mdi-arrow-up text-success"></i></small></h2>
                                        <p class="text-muted m-0"><b>Equipos </b> Registrados </p>
                                    </div>
                                </div>
                            </div><!-- end col -->

                            <%--<div class="col-lg-2 col-md-4 col-sm-6">
                                <div class="card-box widget-box-one">
                                    <i class="mdi mdi-layers widget-one-icon"></i>
                                    <div class="wigdet-one-content">
                                        <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="User This Month">User This Month</p>
                                        <h2>52410 <small><i class="mdi mdi-arrow-up text-success"></i></small></h2>
                                        <p class="text-muted m-0"><b>Last:</b> 40.33k</p>
                                    </div>
                                </div>
                            </div><!-- end col -->

                            <div class="col-lg-2 col-md-4 col-sm-6">
                                <div class="card-box widget-box-one">
                                    <i class="mdi mdi-av-timer widget-one-icon"></i>
                                    <div class="wigdet-one-content">
                                        <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="Request Per Minute">Request Per Minute</p>
                                        <h2>652 <small><i class="mdi mdi-arrow-down text-danger"></i></small></h2>
                                        <p class="text-muted m-0"><b>Last:</b> 956</p>
                                    </div>
                                </div>
                            </div><!-- end col -->

                            <div class="col-lg-2 col-md-4 col-sm-6">
                                <div class="card-box widget-box-one">
                                    <i class="mdi mdi-account-multiple widget-one-icon"></i>
                                    <div class="wigdet-one-content">
                                        <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="Total Users">Total Users</p>
                                        <h2>3245 <small><i class="mdi mdi-arrow-down text-danger"></i></small></h2>
                                        <p class="text-muted m-0"><b>Last:</b> 20k</p>
                                    </div>
                                </div>
                            </div><!-- end col -->

                            <div class="col-lg-2 col-md-4 col-sm-6">
                                <div class="card-box widget-box-one">
                                    <i class="mdi mdi-download widget-one-icon"></i>
                                    <div class="wigdet-one-content">
                                        <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="New Downloads">New Downloads</p>
                                        <h2>78541 <small><i class="mdi mdi-arrow-up text-success"></i></small></h2>
                                        <p class="text-muted m-0"><b>Last:</b> 50k</p>
                                    </div>
                                </div>
                            </div><!-- end col -->--%>

                        </div>
                        <!-- end row -->


                        <div class="row">
                            <div class="col-lg-4">
                        		<div class="card-box">

                        			<h4 class="header-title m-t-0">Estadisticas de Transportes</h4>

                                    <div class="widget-chart text-center">
                                        <div id="morris-donut-example"style="height: 245px;"></div>
                                        <ul class="list-inline chart-detail-list m-b-0">
                                            <li>
                                                <h5 class="text-danger"><i class="fa fa-circle m-r-5"></i>T. Meridian</h5>
                                            </li>
                                            <li>
                                                <h5 class="text-success"><i class="fa fa-circle m-r-5"></i>Contrans</h5>
                                            </li>
                                        </ul>
                                	</div>
                        		</div>
                            </div><!-- end col -->

                            <div class="col-lg-4">
                                <div class="card-box">

                                    <h4 class="header-title m-t-0">Statistics</h4>
                                    <div id="morris-bar-example" style="height: 280px;"></div>
                                </div>
                            </div><!-- end col -->

                            <div class="col-lg-4">
                                <div class="card-box">

                                    <h4 class="header-title m-t-0">Total Revenue</h4>
                                    <div id="morris-line-example" style="height: 280px;"></div>
                                </div>
                            </div><!-- end col -->

                        </div>
                        <!-- end row -->


                        <div class="row">
                            <div class="col-lg-6">
                                <div class="card-box">
                                    <h4 class="header-title m-t-0 m-b-30">Recent Users</h4>

                                    <div class="table-responsive">
                                        <table class="table table table-hover m-0">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>User Name</th>
                                                    <th>Phone</th>
                                                    <th>Location</th>
                                                    <th>Date</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <th>
                                                        <img src="assets/images/users/avatar-1.jpg" alt="user" class="thumb-sm img-circle" />
                                                    </th>
                                                    <td>
                                                        <h5 class="m-0">Louis Hansen</h5>
                                                        <p class="m-0 text-muted font-13"><small>Web designer</small></p>
                                                    </td>
                                                    <td>+12 3456 789</td>
                                                    <td>USA</td>
                                                    <td>07/08/2016</td>
                                                </tr>

                                                <tr>
                                                    <th>
                                                        <img src="assets/images/users/avatar-2.jpg" alt="user" class="thumb-sm img-circle" />
                                                    </th>
                                                    <td>
                                                        <h5 class="m-0">Craig Hause</h5>
                                                        <p class="m-0 text-muted font-13"><small>Programmer</small></p>
                                                    </td>
                                                    <td>+89 345 6789</td>
                                                    <td>Canada</td>
                                                    <td>29/07/2016</td>
                                                </tr>

                                                <tr>
                                                    <th>
                                                        <img src="assets/images/users/avatar-3.jpg" alt="user" class="thumb-sm img-circle" />
                                                    </th>
                                                    <td>
                                                        <h5 class="m-0">Edward Grimes</h5>
                                                        <p class="m-0 text-muted font-13"><small>Founder</small></p>
                                                    </td>
                                                    <td>+12 29856 256</td>
                                                    <td>Brazil</td>
                                                    <td>22/07/2016</td>
                                                </tr>

                                                <tr>
                                                    <th>
                                                        <img src="assets/images/users/avatar-4.jpg" alt="user" class="thumb-sm img-circle" />
                                                    </th>
                                                    <td>
                                                        <h5 class="m-0">Bret Weaver</h5>
                                                        <p class="m-0 text-muted font-13"><small>Web designer</small></p>
                                                    </td>
                                                    <td>+00 567 890</td>
                                                    <td>USA</td>
                                                    <td>20/07/2016</td>
                                                </tr>

                                                <tr>
                                                    <th>
                                                        <img src="assets/images/users/avatar-5.jpg" alt="user" class="thumb-sm img-circle" />
                                                    </th>
                                                    <td>
                                                        <h5 class="m-0">Mark</h5>
                                                        <p class="m-0 text-muted font-13"><small>Web design</small></p>
                                                    </td>
                                                    <td>+91 123 456</td>
                                                    <td>India</td>
                                                    <td>07/07/2016</td>
                                                </tr>

                                            </tbody>
                                        </table>

                                    </div> <!-- table-responsive -->
                                </div> <!-- end card -->
                            </div>
                            <!-- end col -->

                            <div class="col-lg-6">
                                <div class="card-box">
                                    <h4 class="header-title m-t-0 m-b-30">Recent Users</h4>

                                    <div class="table-responsive">
                                        <table class="table table table-hover m-0">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>User Name</th>
                                                    <th>Phone</th>
                                                    <th>Location</th>
                                                    <th>Date</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <th>
                                                        <span class="avatar-sm-box bg-success">L</span>
                                                    </th>
                                                    <td>
                                                        <h5 class="m-0">Louis Hansen</h5>
                                                        <p class="m-0 text-muted font-13"><small>Web designer</small></p>
                                                    </td>
                                                    <td>+12 3456 789</td>
                                                    <td>USA</td>
                                                    <td>07/08/2016</td>
                                                </tr>

                                                <tr>
                                                    <th>
                                                        <span class="avatar-sm-box bg-primary">C</span>
                                                    </th>
                                                    <td>
                                                        <h5 class="m-0">Craig Hause</h5>
                                                        <p class="m-0 text-muted font-13"><small>Programmer</small></p>
                                                    </td>
                                                    <td>+89 345 6789</td>
                                                    <td>Canada</td>
                                                    <td>29/07/2016</td>
                                                </tr>

                                                <tr>
                                                    <th>
                                                        <span class="avatar-sm-box bg-brown">E</span>
                                                    </th>
                                                    <td>
                                                        <h5 class="m-0">Edward Grimes</h5>
                                                        <p class="m-0 text-muted font-13"><small>Founder</small></p>
                                                    </td>
                                                    <td>+12 29856 256</td>
                                                    <td>Brazil</td>
                                                    <td>22/07/2016</td>
                                                </tr>

                                                <tr>
                                                    <th>
                                                        <span class="avatar-sm-box bg-pink">B</span>
                                                    </th>
                                                    <td>
                                                        <h5 class="m-0">Bret Weaver</h5>
                                                        <p class="m-0 text-muted font-13"><small>Web designer</small></p>
                                                    </td>
                                                    <td>+00 567 890</td>
                                                    <td>USA</td>
                                                    <td>20/07/2016</td>
                                                </tr>

                                                <tr>
                                                    <th>
                                                        <span class="avatar-sm-box bg-orange">M</span>
                                                    </th>
                                                    <td>
                                                        <h5 class="m-0">Mark</h5>
                                                        <p class="m-0 text-muted font-13"><small>Web design</small></p>
                                                    </td>
                                                    <td>+91 123 456</td>
                                                    <td>India</td>
                                                    <td>07/07/2016</td>
                                                </tr>

                                            </tbody>
                                        </table>

                                    </div> <!-- table-responsive -->
                                </div> <!-- end card -->
                            </div>
                            <!-- end col -->

                        </div>
                        <!-- end row -->



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">

     
        <!-- Counter js  -->
        <script src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/plugins/waypoints/jquery.waypoints.min.js")%>' type="text/javascript"></script>
        <script src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/plugins/counterup/jquery.counterup.min.js")%>' type="text/javascript"></script>

        <!--Morris Chart-->
		<script src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/plugins/morris/morris.min.js")%>' type="text/javascript"></script>
		<script src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/plugins/raphael/raphael-min.js")%>' type="text/javascript"></script>

        
        <!-- Dashboard init -->
        <script src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/pages/jquery.dashboard.js")%>' type="text/javascript"></script>


</asp:Content>

