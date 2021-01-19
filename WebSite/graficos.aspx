<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="graficos.aspx.cs" Inherits="_graficos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <!--Morris Chart CSS -->
		<link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



                        <div class="row">
							<div class="col-xs-12">
								<div class="page-title-box">
                                    <h4 class="page-title">Google Charts </h4>
                                    <ol class="breadcrumb p-0 m-0">
                                        <li>
                                            <a href="#">Zircos</a>
                                        </li>
                                        <li>
                                            <a href="#">Charts </a>
                                        </li>
                                        <li class="active">
                                            Google Charts
                                        </li>
                                    </ol>
                                    <div class="clearfix"></div>
                                </div>
							</div>
						</div>
                        <!-- end row -->


                        <div class="row">
                            <div class="col-md-12">
                                <div class="card-box">


                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="demo-box">
                                                <h4 class="header-title m-t-0">Line chart</h4>
                                                <p class="text-muted font-13 m-b-30">
                                                    You can smooth the lines by setting the <code>curveType</code> option
                                                    to <code>function</code>:
                                                </p>

                                                <div class="chart" id="line-chart"></div>
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="demo-box">
                                                <h4 class="header-title">Area Chart</h4>
                                                <p class="text-muted font-13 m-b-30">
                                                    An area chart that is rendered within the browser using
                                                    <code>SVG</code> or
                                                    <code>VML</code>.
                                                    Displays tips when hovering over points.
                                                </p>

                                                <div class="chart" id="area-chart"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end row -->


                                    <div class="row m-t-30">
                                        <div class="col-md-6">
                                            <div class="demo-box m-t-30">
                                                <h4 class="header-title m-t-0">Column Chart</h4>
                                                <p class="text-muted font-13 m-b-30">
                                                    A column chart is a vertical bar chart rendered in the browser using SVG or VML, whichever is appropriate for the user's browser.
                                                </p>

                                                <div class="chart" id="column-chart"></div>
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="demo-box m-t-30">
                                                <h4 class="header-title">Bar Charts</h4>
                                                <p class="text-muted font-13 m-b-30">
                                                    Google bar charts are rendered in the browser using SVG or VML, whichever is appropriate for the user's browser.
                                                </p>

                                                <div class="chart" id="bar-chart"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end row -->


                                    <div class="row m-t-30">
                                        <div class="col-md-6">
                                            <div class="demo-box m-t-30">
                                                <h4 class="header-title m-t-0">Stacked column charts</h4>
                                                <p class="text-muted font-13 m-b-30">
                                                    A stacked column chart is a column chart that places related values atop one another. If there are any negative values, they are stacked in reverse order below the chart's baseline.
                                                </p>

                                                <div class="chart" id="column-stacked-chart"></div>
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="demo-box m-t-30">
                                                <h4 class="header-title">Stacked bar charts</h4>
                                                <p class="text-muted font-13 m-b-30">
                                                    A stacked bar chart is a bar chart that places related values atop one another. If there are any negative values, they are stacked in reverse order below the chart's axis baseline.
                                                </p>

                                                <div class="chart" id="bar-stacked-chart"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end row -->



                                    <div class="row m-t-30">
                                        <div class="col-md-6">
                                            <div class="demo-box m-t-30">
                                                <h4 class="header-title m-t-0">Pie Chart</h4>
                                                <p class="text-muted font-13 m-b-30">
                                                    A pie chart that is rendered within the browser using SVG or VML. Displays tooltips when hovering over slices.
                                                </p>

                                                <div class="google-chart text-center">
                                                    <div class="chart" id="pie-chart"></div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="demo-box m-t-30">
                                                <h4 class="header-title m-t-0">Donut Chart</h4>
                                                <p class="text-muted font-13 m-b-30">
                                                    A <i>donut</i> chart is a pie chart with a hole in the center.  You
can create donut charts with the <code>pieHole</code> option:
                                                </p>

                                                <div class="google-chart text-center">
                                                    <div class="chart" id="donut-chart"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end row -->



                                    <div class="row m-t-30">
                                        <div class="col-md-6">
                                            <div class="demo-box m-t-30">
                                                <h4 class="header-title m-t-0">3D Pie Chart</h4>
                                                <p class="text-muted font-13 m-b-30">
                                                    If you set the <code>is3D</code> option to <code>true</code>, your
pie chart will be drawn as though it has three dimensions:
                                                </p>

                                                <div class="google-chart text-center">
                                                    <div class="chart" id="pie-3d-chart"></div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="demo-box m-t-30">
                                                <h4 class="header-title m-t-0">Exploding a Slice</h4>
                                                <p class="text-muted font-13 m-b-30">
                                                    You can separate pie slices from the rest of the chart with the <code>offset</code> property of
  the <code>slices</code> option:
                                                </p>

                                                <div class="google-chart text-center">
                                                    <div class="chart" id="3d-exploded-chart"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end row -->




                                </div> <!-- end card-box -->
                            </div> <!-- End col -->
                        </div>
                        <!-- end row -->

     
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">

 

        <!-- Google Charts js -->
	    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
        <!-- Init -->
        <script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/initReportes.js")%>'></script>

        
</asp:Content>

