<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Estadisticas.aspx.cs" Inherits="Modulos_Operativo_Estadisticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server" ID="smp"></asp:ScriptManager>
    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Estadisticas Operativo </h4>
                <ol class="breadcrumb p-0 m-0">                    
                    <li class="active">Estadisticas
                    </li>
                </ol>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="card-box">

                <div class="row">
                    
                    <div class="panelOptions col-sm-12" style="text-align: right;">
                        <%--<div class="col-lg-12">
                                <div class="col-lg-3">
                            <asp:DropDownList  CssClass="form-control" ID="ddlMes" runat="server" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-3">
                            <asp:DropDownList  CssClass="form-control" ID="ddlAño" runat="server" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" AutoPostBack="true" >
                            </asp:DropDownList>
                                        </div>
                            </div>--%>
                        </div>

                    <asp:Panel ID="pnlReporte" runat="server" Visible="false">
                        <%--<div id="columnchart_values" style="width: 900px; height: 300px;"></div>--%>
                    <div class="col-md-12">
                        <div class="demo-box m-t-30">
                            <h4 class="header-title m-t-0">Numero de Servicio</h4>
                            <p class="text-muted font-13 m-b-30">
                                Muestra comparativa entre el año actual y el anterior.                                               
                            </p>
                            <div class="col-lg-6 m-b-30 " style="text-align: center;">
                            <asp:Label runat="server" class="text-muted">Total de servicios del año anterior:</asp:Label>
                            <asp:label runat="server" ID="TotalServiciosAnual1" style="color:#f5707a;" ></asp:label>
                            </div>
                            <div class="col-lg-6 m-b-30" style="text-align: center;">
                            <asp:Label runat="server" class="text-muted">Total de servicios del año actual:</asp:Label>
                            <asp:label runat="server" ID="TotalServiciosAnual2" style="color:#3ac9d6;"></asp:label>
                            </div>
                            <div style="text-align: right;">
                            </div>
                            <div class="chart m-t-50" id="column-chart"></div>
                        </div>
                    </div>

                    <div class="col-md-5">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="demo-box">
                                    <h4 class="header-title">Servicios por Operacion</h4>
                                    <div class="col-lg-12">
                                        <div class="col-lg-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlMesSO" runat="server" OnSelectedIndexChanged="ddlMesSO_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:DropDownList CssClass="form-control" ID="ddlAñoSO" runat="server" OnSelectedIndexChanged="ddlMesSO_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="m-r-15" style="text-align: center;">
                                        <asp:Label runat="server" class="text-muted">Total de servicios:</asp:Label>
                                        <asp:Label runat="server" ID="lblSO" Style="color: #4bd396;"></asp:Label>
                                    </div>
                                    <div>
                                        <div class="chart" id="column-chart-3"></div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlMesSO" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlAñoSO" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>


                    <div class="col-md-7">                        
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="demo-box">
                            <h4 class="header-title">Detalle de Servicios</h4>
                            <div class="col-lg-12">
                                <div class="col-lg-6">
                            <asp:DropDownList  CssClass="form-control" ID="ddlMesDS" runat="server" OnSelectedIndexChanged="ddlMesDS_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-6">
                            <asp:DropDownList  CssClass="form-control" ID="ddlAñoDS" runat="server" OnSelectedIndexChanged="ddlMesDS_SelectedIndexChanged" AutoPostBack="true" >
                            </asp:DropDownList>
                                        </div>
                            </div>


                            <div class="m-r-15" style="text-align: center;">
                                <asp:Label runat="server" class="text-muted">Total de servicios:</asp:Label>
                                <asp:label runat="server" ID="lblDS" style="color:#188ae2;"></asp:label>
                            </div>
                            <div >
                            <div class="chart" id="column-chart-4"></div>
                            </div>
                        </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlMesDS" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlMesDS" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>



                    <div class="col-md-12  m-t-30">
                        <div class="demo-box">
                            <h4 class="header-title m-t-0">Servicios por Operacion</h4>
                            <div class="col-lg-3 m-b-30 " style="text-align: center;">
                                    <asp:Label runat="server" class="text-muted">Total de Descarga(DPW/APM):</asp:Label>
                                    <asp:label runat="server" ID="lblServicioOperacion1" style="color:#188ae2;"></asp:label>
                                </div>
                            <div class="col-lg-3 m-b-30 " style="text-align: center;">
                                    <asp:Label runat="server" class="text-muted">Total de Embarque (DPW/APM):</asp:Label>
                                    <asp:label runat="server" ID="lblServicioOperacion2" style="color:#f5707a;"></asp:label>
                                </div>
                            <div class="col-lg-3 m-b-30 " style="text-align: center;">
                                    <asp:Label runat="server" class="text-muted">Total de Embarque Vacios (DPW/APM):</asp:Label>
                                    <asp:label runat="server" ID="lblServicioOperacion3" style="color:#3ac9d6;"></asp:label>
                                </div>
                            <div class="col-lg-3 m-b-30 " style="text-align: center;">
                                    <asp:Label runat="server" class="text-muted">Total de Descarga Vacios(DPW/APM):</asp:Label>
                                    <asp:label runat="server" ID="lblServicioOperacion4" style="color:#4bd396;"></asp:label>
                                </div>
                            <%--<p class="text-muted font-13 m-b-30">
                                You can smooth the lines by setting the <code>curveType</code> option
                                                    to <code>function</code>:
                                               
                            </p>--%>
                            <div class="col-lg-12">
                            <div class="chart" id="line-chart"></div>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-12">
                        <div class="demo-box m-t-30">
                            <h4 class="header-title m-t-0">Servicios de Propios vs Terceros</h4>
                            <p class="text-muted font-13 m-b-30">
                                Muestra comparativa entre los servicios propios y terceros.                                               
                            </p>
                            
                                <div class="col-lg-6 m-b-30 " style="text-align: center;">
                                    <asp:Label runat="server" class="text-muted">Total de servicios propios:</asp:Label>
                                    <asp:label runat="server" ID="lblServiciosPropioTercero1" style="color:#f9c851;"></asp:label>
                                </div>
                                <div class="col-lg-6 m-b-30 " style="text-align: center;">
                                    <asp:Label runat="server" class="text-muted">Total de servicios terceros:</asp:Label>
                                    <asp:label runat="server" ID="lblServiciosPropioTercero2" style="color:#4bd396;"></asp:label>
                                </div>
                            <div class="col-lg-12">
                            <div class="chart" id="column-chart-2"></div>
                                </div>
                        </div>
                    </div>


                    <div class="col-md-6">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="demo-box m-t-30">
                            
                            <h4 class="header-title m-t-0"> Servicios Propios vs Terceros</h4>
                            <div class="col-lg-12">
                                <div class="col-lg-6">
                            <asp:DropDownList  CssClass="form-control" ID="ddlMesPT" runat="server" OnSelectedIndexChanged="ddlMesPT_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-6">
                            <asp:DropDownList  CssClass="form-control" ID="ddlAñoPT" runat="server" OnSelectedIndexChanged="ddlMesPT_SelectedIndexChanged" AutoPostBack="true" >
                            </asp:DropDownList>
                                        </div>
                            </div>
                                <div class="col-lg-6 m-b-30 " style="text-align: center;">
                                    <asp:Label runat="server" class="text-muted">Total de servicios propios:</asp:Label>
                                    <asp:label runat="server" ID="lblPT1" style="color:#6b5fb5;"></asp:label>
                                </div>
                                <div class="col-lg-6 m-b-30 " style="text-align: center;">
                                    <asp:Label runat="server" class="text-muted">Total de servicios terceros:</asp:Label>
                                    <asp:label runat="server" ID="lblPT2" style="color:#f5707a;"></asp:label>
                                </div>

                            
                            <%--<p class="text-muted font-13 m-b-30">
                                If you set the <code>is3D</code> option to <code>true</code>, your
pie chart will be drawn as though it has three dimensions:
                                               
                            </p>--%>

                            <div class="google-chart text-center">
                                <div class="chart" id="pie-3d-chart"></div>
                            </div>
                        </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlMesPT" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlAñoPT" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        
                    </div>

                    <div class="col-md-6">
                        
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="demo-box m-t-30">
                            <h4 class="header-title m-t-0">Total de Servicios</h4>
                            <div class="col-lg-12">
                                <div class="col-lg-6">
                            <asp:DropDownList  CssClass="form-control" ID="ddlMesTS" runat="server" OnSelectedIndexChanged="ddlMesTS_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-6">
                            <asp:DropDownList  CssClass="form-control" ID="ddlAñoTS" runat="server" OnSelectedIndexChanged="ddlMesTS_SelectedIndexChanged" AutoPostBack="true" >
                            </asp:DropDownList>
                                        </div>
                            </div>

                            <div class="col-lg-6 m-b-30 " style="text-align: center;">
                                    <asp:Label runat="server" class="text-muted">Total de servicios APM:</asp:Label>
                                    <asp:label runat="server" ID="lblTS1" style="color:#4bd396;"></asp:label>
                                </div>
                                <div class="col-lg-6 m-b-30 " style="text-align: center;">
                                    <asp:Label runat="server" class="text-muted">Total de servicios DPW:</asp:Label>
                                    <asp:label runat="server" ID="lblTS2" style="color:#188ae2;"></asp:label>
                                </div>
                            <%--<p class="text-muted font-13 m-b-30">
                                If you set the <code>is3D</code> option to <code>true</code>, your
pie chart will be drawn as though it has three dimensions:
                                               
                            </p>--%>

                            <div class="google-chart text-center">
                                <div class="chart" id="pie-3d-chart-2"></div>
                            </div>
                        </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlMesTS" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlAñoTS" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>

                        </asp:Panel>

                </div>

                 <div id="infoModalAlert" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title">Reportes y Estadisticas</h4>

                        </div>
                        <div class="modal-body">
                            <div class="text">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                <div class="form-group col-lg-6">

                                    <label for="name-1" class="control-label">Fecha Inicio</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="ion-calendar"></span>
                                        </span>
                                        <asp:TextBox data-provide="datepicker" placeholder="dd/mm/yyyy" data-date-format="dd/mm/yyyy" required parsley-trigger="change" CssClass="form-control datepicker" ID="txtInicio" runat="server"></asp:TextBox>

                                    </div>

                                </div>

                                <div class="form-group col-lg-6">

                                    <label for="name-1" class="control-label">Fecha Fin</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="ion-calendar"></span>
                                        </span>
                                        <asp:TextBox data-provide="datepicker" placeholder="dd/mm/yyyy" data-date-format="dd/mm/yyyy" required parsley-trigger="change" CssClass="form-control datepicker" ID="txtFin" runat="server"></asp:TextBox>
                                    </div>

                                </div>

                                <div class="m-t-lg text-right">
                                    <asp:Button ID="lnkGenerar" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                        runat="server" OnClick="lnkGenerar_Click" Text="Generar">
                                    </asp:Button>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>


            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <!-- Google Charts js -->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <!-- Init -->
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/initReportes.js")%>'></script>
</asp:Content>

