<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modulos_OT_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .card-actions {
            margin-top: -15px;
        }

        .md-form-group {
            margin-bottom: 0px !important;
        }

        .btn {
            border-radius: 2px;
            padding: 4px 8px;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Ordenes de Trabajo </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Inicio</a>
                    </li>
                    <li>
                        <a href="#">Flota </a>
                    </li>
                    <li class="active">Ordenes de Trabajo
                    </li>
                </ol>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">
                        <div class="col-sm-6">
                            <h4 class="m-t-0 header-title"><b>Ordenes de Trabajo/Servicio</b></h4>
                            <p class="text-muted font-13 m-b-30">
                                Ingresar la informacion de las unidades  
                            </p>
                        </div>

                        <div class="panelOptions col-sm-6" style="text-align: right;">
                            <asp:LinkButton ID="lnkNuevo" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                runat="server" OnClick="lnkNuevo_Click">
                   <i class="fa fa-plus m-r-5"></i> <span> Nuevo </span>  </asp:LinkButton>

                        </div>
                        <div class="clearfix"></div>

                        <asp:GridView ID="gvOT" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvOT_PreRender" OnRowCommand="gvOT_RowCommand" OnRowDataBound="gvOT_RowDataBound">

                            <Columns>

                                <asp:BoundField DataField="nro_orden" HeaderText="# Orden" />
                                <asp:BoundField DataField="nom_proveedor" HeaderText="Proveedor" />
                                <asp:BoundField DataField="fch_emision" dataformatstring="{0:dd/MM/yyyy}" HeaderText="Emision" />
                                <asp:BoundField DataField="hora_inicio" DataFormatString="{0:HH:mm}" HeaderText="Hora" />
                                <asp:TemplateField HeaderText="Fin">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFechaFin" runat="server" Text='<%# Eval("hora_fin") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hora">
                                    <ItemTemplate>
                                        <span id="spanlbl" runat="server" class="btn btn-icon waves-effect waves-light btn-teal m-b-5" >
                                            <i class="fa fa-clock-o m-r-5"></i>                                            
                                                <asp:Label ID="lblHoraFin" runat="server" Text='<%# Eval("hora_fin") %>'></asp:Label>                                            
                                        </span>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nro_placa" HeaderText="Unidad" />
                                <asp:BoundField DataField="nom_mantenimiento" HeaderText="Tipo" />
                                <asp:BoundField DataField="nom_taller" HeaderText="Taller" />
                                <asp:BoundField DataField="total_servicio" HeaderText="Total" >

                                <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("estado_cd") %>' CssClass="btn btn-xs btn-teal"></asp:Label>                                        
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="padding: 0 2px;">                                                                                     
                                                    <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("id_orden") %>' CssClass="btn btn-icon waves-effect waves-light btn-default m-b-5 " title="Editar" runat="server" CommandName="editar"><span class="fa fa-edit" /></asp:LinkButton>
                                                </td>

                                                <td style="padding: 0 2px;">                                                                                     
                                                    <asp:LinkButton ID="LinkButton3" CommandArgument='<%# Eval("id_orden") %>' CssClass="btn btn-icon waves-effect waves-light btn-default m-b-5 " title="Ver Servicios" runat="server" CommandName="servicios"><span class="fa fa-bars" /></asp:LinkButton>
                                                </td>
                                                
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("id_orden") %>' CssClass="btn btn-icon waves-effect waves-light btn-default m-b-5" runat="server" CommandName="ver"><span class="fa fa-cubes" title="Ver Articulos"/></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </asp:View>

        <asp:View ID="View2" runat="server">
            <div class="col-md-8 col-md-offset-2">
                <div class="card-box">

                    <div class="row">

                        <div class="col-md-12">
                            <div class="col-lg-12">

                                <div class="row">
                                    <div class="col-lg-8">
                                        <h4 class="header-title m-t-0">Orden de Trabajo</h4>
                                        <p class="text-muted font-13 m-b-10">
                                            Registra la informacion que corresponde al mantenimiento de unidades
                                        </p>
                                    </div>

                                    <div class="col-lg-4">
                                        <asp:Button ID="btnGuardar" ValidationGroup="registrar"
                                            CssClass="btn btn-primary" runat="server"
                                            Text="Guardar" OnClick="btnGuardar_Click" />
                                        <asp:Button ID="btnRegresar" CssClass="btn btn-default" runat="server" Text="Regresar" UseSubmitBehavior="False" OnClick="btnRegresar_Click" />
                                        <asp:HiddenField ID="HFCodigo" runat="server" Value="0" />
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="form-group col-lg-6">
                                    <label for="userName">Nro. Orden </label>
                                    <asp:TextBox title="ingresar nombre" required parsley-trigger="change" CssClass="form-control" ID="txtNroOrden" runat="server" Enabled="False"></asp:TextBox>

                                </div>


                                <div class="form-group col-lg-6">
                                    <label>Unidad</label>
                                    <asp:TextBox required CssClass="form-control autocomplete" data-url="BuscarUnidad.ashx" ID="txtUnidad" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txtUnidad_id" runat="server" class="form-control" style="color: #CCC; position: absolute; background: transparent; z-index: 1;display: none;"></asp:TextBox>
           
                                </div>

                                <div class="form-group col-lg-6">
                                    <label>Taller</label>
                                    <asp:DropDownList required CssClass="form-control" ID="ddlTaller" runat="server">
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label>Conductor</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlConductor" runat="server">
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-lg-3">
                                    <label for="userName">Fecha Emision</label>
                                    <div class="input-group">
                                        <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy" required parsley-trigger="change" CssClass="form-control datepicker" ID="txtfchEmision" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><i class="mdi mdi-calendar"></i></span>
                                    </div>
                                    </div>

                                <div class="form-group col-lg-3">
                                    <label for="userName">Hora</label>
                                    <div class="input-group">
                                        <asp:TextBox data-provide="timepicker" required parsley-trigger="change" CssClass="form-control timepicker" ID="txtHoraEmision" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><i class="mdi mdi-clock"></i></span>
                                    </div>
                                </div>

                                <div class="form-group col-lg-3">
                                    <label for="userName">Fecha Termino</label>
                                    <div class="input-group">
                                        <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy" parsley-trigger="change" CssClass="form-control datepicker" ID="txtfchFin" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><i class="mdi mdi-clock"></i></span>
                                    </div>
                                </div>

                                <div class="form-group col-lg-3">
                                    <label for="userName">Hora</label>
                                    <div class="input-group">
                                        <asp:TextBox data-provide="timepicker" parsley-trigger="change" CssClass="form-control timepicker" ID="txtHoraFin" runat="server"></asp:TextBox>
                                         <span class="input-group-addon"><i class="mdi mdi-clock"></i></span>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="col-md-8 col-md-offset-2">
                <div class="card-box">

                    <div class="row">

                        <div class="col-md-12">
                            <div class="col-lg-12">

                                <div class="form-group col-lg-12">
                                    <label for="userName">Proveedor</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlProveedor" runat="server">
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName">Kilometraje(km)</label>
                                    <asp:TextBox title="km" required parsley-trigger="change" CssClass="form-control" ID="txtKm" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName">Horometro</label>
                                    <asp:TextBox title="Hora Inicio" required parsley-trigger="change" CssClass="form-control" ID="txtHorometro" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName">Tipo Servicio</label>
                                    <asp:DropDownList required CssClass="form-control" ID="ddlTipoServicio" runat="server">
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label>Mantenimiento</label>
                                    <asp:DropDownList required CssClass="form-control" ID="ddlMantenimiento" runat="server">
                                    </asp:DropDownList>
                                </div>

                            </div>


                        </div>
                    </div>

                </div>
            </div>
        </asp:View>

        <asp:View ID="View3" runat="server">
            <div class="col-md-8 col-md-offset-2">
                <div class="card-box">

                    <div class="row">

                        <div class="col-md-12">
                            <div class="col-lg-12">

                                <div class="row">
                                    <div class="col-lg-8">
                                        <h4 class="header-title m-t-0"> Detalle del Servicio</h4>
                                        <p class="text-muted font-13 m-b-10">
                                            Registra la informacion que corresponde a los servicios realizados en el taller de mantenimiento
                                        </p>
                                    </div>

                                    <div class="col-lg-4">
                                        <asp:Button ID="btnServicio" ValidationGroup="registrar"
                                            CssClass="btn btn-primary" runat="server"
                                            Text="Guardar" OnClick="btnServicio_Click" />
                                        <asp:Button ID="btnServicioRegresar" CssClass="btn btn-default" runat="server" Text="Regresar" UseSubmitBehavior="False" OnClick="btnServicioRegresar_Click" />
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="form-group col-lg-9">
                                    <label for="userName">Servicio</label>
                                    <asp:DropDownList required CssClass="form-control" ID="ddlMotivoServicio" runat="server">
                                    </asp:DropDownList>
                                </div>
                                
                                <div class="form-group col-lg-3">
                                    <label>Costo</label>
                                    <asp:TextBox required CssClass="form-control" ID="txtCosto" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group col-lg-12">
                                    <label>Observaciones</label>
                                   <asp:TextBox required CssClass="form-control" ID="txtObs" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="col-md-8 col-md-offset-2">
                <div class="card-box">

                    <div class="row">

                        <div class="col-md-12">
                            <div class="col-lg-12">

                                <div class="row">
                                    
                                    <div id="alerta" class="alert alert-icon alert-danger alert-dismissible fade in" role="alert" runat="server">
                                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                    <span aria-hidden="true">×</span>
                                                </button>
                                                <i class="mdi mdi-block-helper"></i>
                                                <strong>Alerta!</strong> No existen servicios asociados a la Orden de Tabajo.
                                            </div>

                                    <asp:GridView ID="gvServicio" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-striped table-bordered dataTable" GridLines="None">

                            <Columns>

                                
                                <asp:BoundField Visible="false" DataField="id_orden" HeaderText="Codigo" />
                                <asp:BoundField DataField="cod_servicio" HeaderText="" />
                                <asp:BoundField DataField="nom_servicio" HeaderText="Servicio" />
                                <asp:BoundField DataField="costo" HeaderText="Monto(S/.)" />                                

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="padding: 0 2px;">                                                    
                                                    <asp:LinkButton ID="lnkEdit" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="editar"><span class="fa fa-pencil-square-o"/></asp:LinkButton>
                                                </td>
                                                <td style="padding: 0 2px;">                                                    
                                                    <asp:LinkButton ID="lnkDownload" CommandArgument='<%# Eval("id_orden") %>' CssClass="btn btn-icon waves-effect waves-light btn-warning m-b-5" runat="server" CommandName="descargar"><span class="fa fa-file-pdf-o"/></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

          
        </asp:View>
    </asp:MultiView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

