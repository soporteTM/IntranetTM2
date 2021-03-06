﻿<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="cliente_default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="/App_Themes/Elephant/css/demo.min.css">

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
                <h4 class="page-title">Modulo de Gestion de Unidades </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Inicio</a>
                    </li>
                    <li>
                        <a href="#">Flota</a>
                    </li>
                    <li class="active"> Registro de Unidades
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
                            <h4 class="m-t-0 header-title"><b>Flota General</b></h4>
                            <p class="text-muted font-13 m-b-30">
                                Ingresar la informacion de las unidades  
                            </p>
                        </div>

                        <div class="panelOptions col-sm-6" style="text-align: right;">
                            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                runat="server" OnClick="btnNuevo_Click">
                                <i class="fa fa-plus m-r-5"></i> <span> Agregar </span>  
                            </asp:LinkButton>
                            <asp:LinkButton ID="LinkButton4" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                runat="server" OnClick="btnExportar_Click">
                                <i class="glyphicon glyphicon-save-file m-r-5"></i> <span> Exportar </span>  
                            </asp:LinkButton>



                            <!--
                            <asp:LinkButton ID="btnExportar" CssClass="btn btn-warning waves-effect waves-light m-b-5"
                                runat="server" OnClick="btnExportar_Click"> 
                            <i class="fa fa-file m-r-5"></i> <span>Exportar  </span> </asp:LinkButton>
                            -->

                        </div>
                        <div class="clearfix"></div>

                        <asp:GridView ID="gvMarcas" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-striped table-bordered dataTable" GridLines="None"
                            OnRowCommand="gvMarcas_RowCommand" OnPreRender="gvMarcas_PreRender">

                            <Columns>

                                <asp:BoundField Visible="false" DataField="cod_flota" HeaderText="Codigo" />
                                <asp:BoundField DataField="cod_interno" HeaderText="Cod. Interno" />
                                <asp:BoundField DataField="nro_placa" HeaderText="Nro. Placa" />
                                <asp:BoundField DataField="nom_tipo_vehiculo" HeaderText="Tipo" />
                                <asp:BoundField DataField="nom_marca" HeaderText="Marca" />
                                <asp:BoundField DataField="nom_modelo" HeaderText="Modelo" />
                                <asp:BoundField DataField="nom_configuracion" HeaderText="Configuracion" />
                                <asp:BoundField DataField="anio_unidad" HeaderText="Año" />
                                <asp:BoundField DataField="nro_motor" HeaderText="Motor" />
                                <asp:BoundField DataField="nom_operacion" HeaderText="Operacion" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="padding: 0 2px;">                                                    
                                                    <asp:LinkButton ID="LinkButton3" CommandArgument='<%# Eval("cod_flota") %>' CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="editar"><span class="fa fa-pencil-square-o"/></asp:LinkButton>
                                                </td>
                                                
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("cod_flota") %>' CssClass="btn btn-icon waves-effect waves-light btn-success m-b-5" runat="server" CommandName="ver"><span class="fa fa-wpforms"/></asp:LinkButton>
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


            <div id="infoModalAlert" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title" id="myModalLabel">Información de Cliente</h4>

                        </div>
                        <div class="modal-body">
                            <div class="text-center">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>





                                <div class="form-group">

                                    <label class="md-control-label">Nombres o razón social:</label>

                                    <asp:TextBox required CssClass="form-control text-center" ID="TextBox1" runat="server"></asp:TextBox>


                                </div>

                                <div class="form-group">

                                    <label class="md-control-label">Representante legal:</label>

                                    <asp:TextBox required CssClass="form-control text-center" ID="TextBox2" runat="server"></asp:TextBox>


                                </div>

                                <div class="form-group">

                                    <label class="md-control-label">Giro del negocio:</label>

                                    <asp:TextBox required CssClass="form-control text-center" ID="TextBox3" runat="server"></asp:TextBox>


                                </div>

                                <div class="form-group">

                                    <label class="md-control-label">Fecha Atención:</label>

                                    <asp:TextBox required data-provide="datepicker" data-date-format="dd/mm/yyyy" CssClass="form-control text-center datepickers" ID="TextBox4" runat="server"></asp:TextBox>


                                </div>

                                <div class="m-t-lg">
                                    <asp:LinkButton ID="lnkProcesar" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                runat="server">
                   <i class="fa fa-save m-r-5"></i> <span>Procesar</span>  </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer"></div>
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
                                        <h4 class="header-title m-t-0">Registrar/Actualizar</h4>
                                        <p class="text-muted font-13 m-b-10">
                                            Registra la informacion básica de la flota.
                                        </p>
                                    </div>

                                    <div class="col-lg-4">
                                        <asp:Button ID="btnGuardar" ValidationGroup="registrar"
                                            OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server"
                                            Text="Guardar" />
                                        <asp:Button ID="btnRegresar" OnClick="Button2_Click" CssClass="btn btn-default" runat="server" Text="Regresar" UseSubmitBehavior="False" />
                                        <asp:HiddenField ID="HFCodigo" runat="server" Value="0" />
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="form-group col-lg-6">
                                    <label for="userName">Cod. Interno </label>
                                    <asp:TextBox title="ingresar nombre" required parsley-trigger="change" CssClass="form-control" ID="txtCodInterno" runat="server"></asp:TextBox>

                                </div>


                                <div class="form-group col-lg-6">

                                    <label> Nro. Placa/Tracto</label>

                                    <asp:TextBox required CssClass="form-control" ID="txtNroPlaca" runat="server"></asp:TextBox>


                                </div>
                                <div class="form-group col-lg-12">

                                    <label> Tipo Vehiculo </label>
                                    <asp:DropDownList required CssClass="form-control" ID="ddlVehiculo" runat="server">
                                    </asp:DropDownList>

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
                               
                                <div class="form-group col-lg-6">
                                    <label for="userName"> Marca </label>
                                    <asp:DropDownList required CssClass="form-control" ID="ddlMarca" runat="server">
                                    </asp:DropDownList>
                                </div>


                                <div class="form-group col-lg-6">
                                    <label> Modelo </label>
                                    <asp:DropDownList required CssClass="form-control" ID="ddlModelo" runat="server">
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName"> Color </label>
                                    <asp:TextBox title="Ingrese color" required parsley-trigger="change" CssClass="form-control" ID="txtColor" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group col-lg-6">
                                    <label> Configuracion </label>
                                    <asp:DropDownList required CssClass="form-control" ID="ddlConfiguracion" runat="server">
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-lg-12  ">
                                    <label> Numero de Motor </label>
                                    <asp:TextBox title="Ingrese Nro. Motor" required parsley-trigger="change" CssClass="form-control" ID="txtNroMotor" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group col-lg-6">
                                    <label> Cilindrada(CC) </label>
                                    <asp:TextBox title="Ingrese CC" required parsley-trigger="change" CssClass="form-control" ID="txtCilindrada" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group col-lg-6">
                                    <label> Nro. Cilindros </label>
                                    <asp:TextBox title="Ingrese Nro. Cilindros" required parsley-trigger="change" CssClass="form-control" ID="txtNroCilindros" type="number" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group col-lg-12">
                                     <label for="name-1" class="control-label">Chasis</label>
                                    <div class="input-group">
                                                <span class="input-group-addon">
                                                    <span class="ti-menu"></span>
                                                </span>
                                                <asp:TextBox required spellcheck="false" placeholder="Ingresa nombre del cliente" CssClass="form-control" ID="txtNroChasis" runat="server"></asp:TextBox>

                                            </div>
                                </div>

                                <div class="form-group col-lg-6 ">
                                    <label> Nro. Ruedas </label>
                                    <asp:TextBox title="Ingrese Nro. Ruedas" required parsley-trigger="change" CssClass="form-control" ID="txtNroRueda"  type="number" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group col-lg-6 ">
                                    <label> Nro. Ejes </label>
                                    <asp:TextBox title="Ingrese Nro. Ejes" required parsley-trigger="change" CssClass="form-control" ID="txtNroEje"  type="number" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group col-lg-6 ">
                                    <label> Año/Modelo </label>
                                    <asp:TextBox title="Ingrese Año" required parsley-trigger="change" CssClass="form-control" ID="txtAño" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group col-lg-6 ">
                                    <label> Capacidad </label>
                                    <asp:TextBox title="Ingrese Capacidad" required parsley-trigger="change" CssClass="form-control" ID="txtCapacidad"  type="number" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group col-lg-12">
                                    <label> Operacion  </label>
                                    <asp:DropDownList required CssClass="form-control" ID="ddlOperacion" runat="server">
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
                                        <h4 class="header-title m-t-0"> Documentacion </h4>
                                        <p class="text-muted font-13 m-b-10">
                                            Registra la documentacion de las unidades(documentos adjuntos).
                                        </p>
                                    </div>

                                    <div class="col-lg-4">
                                        <asp:Button ID="btnDocumentacion" ValidationGroup="registrar"
                                            CssClass="btn btn-primary" runat="server"
                                            Text="Guardar" OnClick="btnDocumentacion_Click" />
                                        <asp:Button ID="Button2" OnClick="Button2_Click" CssClass="btn btn-default" runat="server" Text="Regresar" UseSubmitBehavior="False" />
                                        <asp:HiddenField ID="HFCodDoc" runat="server" Value="0" />
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="form-group col-lg-6">
                                    <label for="userName">Cod. Interno </label>
                                    <asp:TextBox title="ingresar nombre" required parsley-trigger="change" CssClass="form-control" ID="txtCodInternoDoc" runat="server" Enabled="False"></asp:TextBox>

                                </div>


                                <div class="form-group col-lg-6">

                                    <label> Nro. Placa/Tracto </label>

                                    <asp:TextBox required CssClass="form-control" ID="txtNroPlacaDoc" runat="server" Enabled="False"></asp:TextBox>


                                </div>
                                <div class="form-group col-lg-12">

                                    <label> Tipo de Documentación </label>
                                    <asp:DropDownList required CssClass="form-control" ID="ddlDocumentacion" runat="server">
                                    </asp:DropDownList>

                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName">Fecha Emision </label>
                                    <asp:TextBox title="Fecha Emision" data-provide="datepicker" data-date-format="dd/mm/yyyy"  required parsley-trigger="change" CssClass="form-control" ID="txtEmision" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName">Fecha Vencimiento </label>
                                    <asp:TextBox title="Fecha Vencimiento" data-provide="datepicker" data-date-format="dd/mm/yyyy"  required parsley-trigger="change" CssClass="form-control" ID="txtVencimiento" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group">
                                    <label for="userName"> Documento Adjunto </label>
                                    <asp:FileUpload ID="fuArchivo" CssClass="filestyle" data-buttonname="btn-default" runat="server" />
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
                                                <strong>Alerta!</strong> No existen registros para la unidad seleccionada.
                                            </div>

                                    <asp:GridView ID="gvDocumentacion" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvDocumentacion_PreRender" OnRowCommand="gvDocumentacion_RowCommand" OnRowCreated="gvDocumentacion_RowCreated" OnRowDataBound="gvDocumentacion_RowDataBound">

                            <Columns>

                                <asp:BoundField DataField="cod_doc" HeaderText="Codigo" />
                                <asp:BoundField Visible="false" DataField="cod_flota" HeaderText="Codigo" />
                                <asp:BoundField DataField="cod_documentacion" HeaderText="" />
                                <asp:BoundField DataField="nom_documentacion" HeaderText="Documento" />
                                <asp:BoundField DataField="fch_emision" HeaderText="Fch. Emision" />
                                <asp:BoundField DataField="fch_vencimiento" HeaderText="Fch. Vencimiento" />
                                

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="padding: 0 2px;">                                                    
                                                    <asp:LinkButton ID="lnkEdit" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="editar"><span class="fa fa-pencil-square-o"/></asp:LinkButton>
                                                </td>
                                                <td style="padding: 0 2px;">                                                    
                                                    <asp:LinkButton ID="lnkDownload" CommandArgument='<%# Eval("path_doc") %>' CssClass="btn btn-icon waves-effect waves-light btn-warning m-b-5" runat="server" CommandName="descargar"><span class="fa fa-file-pdf-o"/></asp:LinkButton>
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
