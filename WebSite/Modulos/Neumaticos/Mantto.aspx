<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Mantto.aspx.cs" Inherits="Modulos_Neumaticos_Mantto" %>

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

        .label {
            font-size: 90%;
        }

        .S2_pos1 {
            position: absolute;
            top: 15px;
            left: 270px;
            width: 80px;
        }

        .S2_pos2 {
            position: absolute;
            top: 145px;
            left: 270px;
            width: 80px;
        }

        .S2_pos3 {
            position: absolute;
            top: 15px;
            left: 460px;
            width: 80px;
        }

        .S2_pos4 {
            position: absolute;
            top: 40px;
            left: 460px;
            width: 80px;
        }

        .S2_pos5 {
            position: absolute;
            top: 130px;
            left: 460px;
            width: 80px;
        }

        .S2_pos6 {
            position: absolute;
            top: 155px;
            left: 460px;
            width: 80px;
        }

        .S2_pos7 {
            position: absolute;
            top: 15px;
            left: 560px;
            width: 80px;
        }

        .S2_pos8 {
            position: absolute;
            top: 40px;
            left: 560px;
            width: 80px;
        }

        .S2_pos9 {
            position: absolute;
            top: 130px;
            left: 560px;
            width: 80px;
        }

        .S2_pos10 {
            position: absolute;
            top: 155px;
            left: 560px;
            width: 80px;
        }

        .S2_pos11 {
            position: absolute;
            top: 15px;
            left: 450px;
            width: 80px;
        }

        .S2_pos12 {
            position: absolute;
            top: 40px;
            left: 450px;
            width: 80px;
        }

        .S2_pos13 {
            position: absolute;
            top: 130px;
            left: 450px;
            width: 80px;
        }

        .S2_pos14 {
            position: absolute;
            top: 155px;
            left: 450px;
            width: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Modulo de Neumáticos </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Inicio</a>
                    </li>
                    <li>
                        <a href="#">Neumaticos</a>
                    </li>
                    <li class="active">Mantenimiento de Neumaticos
                    </li>
                </ol>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server"  ID="hfUsuario"/>
    <asp:HiddenField runat="server"  ID="hfAccion"/>
    <asp:HiddenField runat="server"  ID="hfCodNeumatico"/>

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        
        <asp:View ID="View1" runat="server">
            
            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">
                        <div class="col-sm-6">
                            <h4 class="m-t-0 header-title"><b>Neumaticos</b></h4>
                            <p class="text-muted font-13 m-b-30">
                                Ingresar la informacion correspondiente a los neumaticos.  
                            </p>
                        </div>

                        <div class="panelOptions col-sm-6" style="text-align: right;">
                            <asp:LinkButton ID="lnkAgregar" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                runat="server" OnClick="lnkAgregar_Click">
                            <i class="fa fa-plus m-r-5"></i> <span>Agregar</span>  </asp:LinkButton>

                            
                            <asp:LinkButton ID="btnReporte" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                runat="server" OnClick="btnReporte_Click"> 
                            <i class="fa fa-file m-r-5"></i> <span>Reporte  </span> </asp:LinkButton>
                            

                        </div>
                        <div class="clearfix"></div>

                        <asp:GridView ID="gvNeumatico" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvNeumatico_PreRender" OnRowDataBound="gvNeumatico_RowDataBound" OnRowCommand="gvNeumatico_RowCommand">

                            <Columns>

                                <%--<asp:BoundField DataField="id_nm" HeaderText="ID Neumatico" Visible="false" />--%>
                                <asp:TemplateField HeaderText="id_nm" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="id_nm" runat="server" Text='<%# Eval("id_nm") %>' Font-Size="10"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nro_serie" HeaderText="Numero de Serie" />
                                <asp:BoundField DataField="nom_marca" HeaderText="Marca" />
                                <asp:BoundField DataField="nom_modelo" HeaderText="Modelo" />
                                <asp:BoundField DataField="precio_costo" HeaderText="Precio" visible="false"/>
                                <asp:BoundField DataField="Fecha_Instalacion" HeaderText="Fec. Instalacion"/>
                                <asp:BoundField DataField="km_recorrido" HeaderText="Km Recorrido" />
                                
                                <%--<asp:BoundField DataField="estado_cd" HeaderText="estado_cd" />--%>
                                <asp:TemplateField HeaderText="Coondicion">
                                    <ItemTemplate>
                                        <asp:Label ID="lblreencauche" runat="server" Text='<%# Eval("reencauche") %>' Font-Size="10"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DOT" HeaderText="DOT" />
                                <asp:BoundField DataField="medida" HeaderText="medida" />
                                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" />
                                <asp:BoundField DataField="fecha_compra" HeaderText="Fecha Compra" />
                                <asp:BoundField DataField="cod_interno" HeaderText="Codigo Interno" />
                                <asp:TemplateField ItemStyle-Width="30px">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="btnReencauche" ToolTip="Reencauche" CommandArgument='<%#Eval("id_nm")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Reencauche"><i class="fa fa-undo" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="btnHistorico" ToolTip="Historico" CommandArgument='<%#Eval("nro_serie")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Historial"><i class="fa fa-search" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="btnEditar" ToolTip="Editar" CommandArgument='<%#Eval("id_nm")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Editar"><i class="fa fa-edit" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <td style="padding: 0 2px;">
                                                    <%--<asp:LinkButton ID="btnEliminar" ToolTip="Eliminar" CommandArgument='<%#Eval("id_nm")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Eliminar"><i class="fa fa-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>--%>
                                                    <asp:LinkButton ToolTip="Eliminar" CommandArgument='<%# Eval("id_nm") %>' CommandName="eliminar" CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5"    ID="LinkButton3" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>

                                                
                                                
                                                <%--<td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval("id_nm")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Eliminar"><i class="fa fa-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
            </div>

            <div id="infoModalRegistrar" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title">Registro de Neumatico</h4>

                        </div>
                        <div class="modal-body">
                            <div class="text">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                 <div class="form-group col-lg-12">
                                     <div class="col-lg-6">
                                        <asp:RadioButton  runat="server" ID="rbtNuevo" GroupName="G1" Text="Nuevo" Checked="true" AutoPostBack="true" OnCheckedChanged="rbtReencauche_CheckedChanged"/>
                                     </div>
                                     <div class="col-lg-6">
                                        <asp:RadioButton  runat="server" ID="rbtReencauche" GroupName="G1" Text="Reencauche" AutoPostBack="true" OnCheckedChanged="rbtReencauche_CheckedChanged"/>
                                     </div>
                                     <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtReencauche" runat="server" Visible="false" placeholder="Nro de Reencauche"></asp:TextBox>
                                     <label for="name-1" class="control-label">Código Interno:</label>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtNroSerie" runat="server"></asp:TextBox>
                                     <label for="name-1" class="control-label">DOT:</label>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtDOT" runat="server"></asp:TextBox>

                                     <label for="name-1" class="control-label">Marca:</label>
                                        <asp:TextBox required CssClass="form-control" ID="txtMarca" runat="server"></asp:TextBox>

                                     <label for="name-1" class="control-label">Modelo:</label>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtDiseño" runat="server"></asp:TextBox>

                                     <label for="name-1" class="control-label">Diseño:</label>
                                        <asp:DropDownList  CssClass="form-control" ID="ddlModelo" runat="server"></asp:DropDownList>   

                                     <label for="name-1" class="control-label">Medida:</label>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtMedida" runat="server"></asp:TextBox>

                                     <label for="name-1" class="control-label">Proveedor:</label>
                                        <asp:DropDownList  CssClass="form-control" ID="ddlProveedor" runat="server"></asp:DropDownList>

                                     <div class="col-lg-10">
                                         <label for="name-1" class="control-label">Precio:</label>

                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtPrecio" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-lg-2">
                                         <label for="name-1" class="control-label">Moneda:</label>
                                         <asp:DropDownList  CssClass="form-control" ID="ddlTipoMoneda" runat="server"></asp:DropDownList>
                                     </div>
                                     
                                     <label for="name-1" class="control-label">Remanente 1:</label>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtR1" runat="server"></asp:TextBox>
                                     <label for="name-1" class="control-label">Remanente 2:</label>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtR2" runat="server"></asp:TextBox>
                                     <label for="name-1" class="control-label">Remanente 3:</label>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtR3" runat="server"></asp:TextBox>
                                     <label for="name-1" class="control-label">Fecha de Compra:</label>
                                        <asp:TextBox required data-provide="datepicker" data-date-format="dd/mm/yyyy" CssClass="form-control text-center datepickers" ID="txtFCompra" runat="server"></asp:TextBox>
                                     <%--<label for="name-1" class="control-label">Estado:</label>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtEstado" runat="server"></asp:TextBox>--%>
                                </div>
                                
                                <div class="m-t-lg text-right">
                                    <asp:Button ID="lnkRegistrar" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                        runat="server" OnClick="lnkRegistrar_Click" Text="Registrar"/>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>

            <%-- MODAL DAR DE BAJA --%>
            <div id="infoModalBaja" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Cerrar</span>
                            </button>
                        </div>

                        <div class="modal-body">
                            <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional"><ContentTemplate>--%>
                            <div class="text-center">
                                <span class="text-danger icon icon-times-circle icon-5x"></span>
                                <h3 class="text-danger">¿Desea DAR DE BAJA este Neumático?</h3>
                                <%--<p>Debe estar seguro antes de ejecutar la siguiente accion.</p>--%>
                                <p>Indique un motivo por el cual se está DANDO DE BAJA.</p>
                                <div class="row">
                                    <asp:DropDownList CssClass="form-control" ID="ddlMotivo" OnSelectedIndexChanged="ddlMotivo_SelectedIndexChanged" AutoPostBack="true" runat="server" required data-msg-required="Completar campo.">
                                    </asp:DropDownList> 
                                </div>
                                <div class="form-group col-lg-12 m-t-5">
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtR1Baja" runat="server" CssClass="form-control" placeholder="R1"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtR2Baja" runat="server" CssClass="form-control" placeholder="R2"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtR3Baja" runat="server" CssClass="form-control" placeholder="R3"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="form-group col-lg-12 m-t-5">
                                    <asp:Label Text="Kilometraje:" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtKilometrajeBaja" CssClass="form-control"></asp:TextBox>
                                </div>
                                <br />
                                <asp:TextBox CssClass="form-control m-t" placeholder="¿Desea agregar alguna observacion?" TextMode="MultiLine" runat="server" ID="txtObservacion" Visible="false"></asp:TextBox>
                                <div class="m-t-lg">
                                    <asp:LinkButton ID="btnRechazar" CssClass="btn btn-danger" runat="server" OnClick="btnRechazar_Click"><i class="fa m-r-5"></i> <span>   Dar de Baja</span>  </asp:LinkButton>
                                    <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                </div>
                            </div>
                            <%-- </ContentTemplate></asp:UpdatePanel>--%>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>


            <div id="modalHistorico" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content p-0 b-0">
                        <div class="panel panel-color panel-primary">
                            <div class="panel-heading">
                                <button type="button" class="close" data-dismiss="modal">
                                    <span aria-hidden="true">×</span>
                                    <span class="sr-only">Close</span>
                                </button>

                                <h3 class="panel-title">Histórico de Reencauche</h3>

                            </div>
                            <div class="panel-body">
                                <h5 class="panel-info">Histórico Neumaticos</h5>
                                <asp:GridView ID="gvHistorico" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered dataTable" GridLines="None" OnRowDataBound="gvHistorico_RowDataBound" OnRowCommand="gvHistorico_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="id_nm" HeaderText="ID Neumatico" Visible="false"/>
                                        <asp:BoundField DataField="nro_serie" HeaderText="Numero de Serie" />
                                        <asp:BoundField DataField="nom_marca" HeaderText="Marca" />
                                        <asp:BoundField DataField="nom_modelo" HeaderText="Modelo" />
                                        <asp:BoundField DataField="precio_costo" HeaderText="Precio" />
                                        <asp:BoundField DataField="km_recorrido" HeaderText="Km Recorrido" />
                                        <asp:TemplateField HeaderText="Coondicion">
                                            <ItemTemplate>
                                                <asp:Label ID="lblreencauche" runat="server" Text='<%# Eval("reencauche") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="30px">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval("id_nm")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Eliminar"><i class="fa fa-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                            </div>
                            <div class="modal-footer"></div>


                        </div>
                    </div>
                </div>
            </div>

            <%-- MODAL REPORTE DE NEUMATICOS --%>
            <div id="modalReporte" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content p-0 b-0">
                        <div class="panel panel-color panel-primary">
                            <div class="panel-heading">
                                <button type="button" class="close" data-dismiss="modal">
                                    <span aria-hidden="true">×</span>
                                    <span class="sr-only">Close</span>
                                </button>

                                <h3 class="panel-title">Reporte de Neumáticos</h3>

                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3">
                                        <asp:Label runat="server" Text="Estado: "></asp:Label>
                                        <asp:DropDownList ID="ddlEstadoNeumaticoReporte" runat="server" CssClass="form-control dropdown"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label runat="server" Text="Fecha Inicio: "></asp:Label>
                                        <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy" CssClass="form-control text-center datepickers" 
                                            ID="dtpFechaInicioReporte" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label runat="server" Text="Fecha Fin: "></asp:Label>
                                        <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy" CssClass="form-control text-center datepickers" 
                                            ID="dtpFechaFinReporte" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:LinkButton ID="btnListarReporte" CssClass="btn btn-default form-control" runat="server" OnClick="btnListarReporte_Click"><i class="fa m-r-5"></i> <span>Listar Reporte</span>  </asp:LinkButton>
                                    </div>
                                </div>
                                <asp:GridView ID="grvReporteNeumaticos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered dataTable" 
                                    GridLines="None" OnRowDataBound="grvReporteNeumaticos_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="id_nm" HeaderText="ID Neumatico" Visible="false"/>
                                        <asp:BoundField DataField="nro_serie" HeaderText="Numero de Serie" />
                                        <asp:BoundField DataField="nom_marca" HeaderText="Marca" />
                                        <asp:BoundField DataField="km_recorrido" HeaderText="Km Recorrido" />
                                        <asp:BoundField DataField="aud_fecha_modificacion" HeaderText="Fecha de Baja" />
                                        <%--
                                        <asp:BoundField DataField="nom_modelo" HeaderText="Modelo" />
                                        <asp:BoundField DataField="precio_costo" HeaderText="Precio" />
                                        
                                        <asp:TemplateField HeaderText="Coondicion">
                                            <ItemTemplate>
                                                <asp:Label ID="lblreencauche" runat="server" Text='<%# Eval("reencauche") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="30px">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval("id_nm")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Eliminar"><i class="fa fa-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>

                            </div>
                            <div class="modal-footer"></div>


                        </div>
                    </div>
                </div>
            </div>
        </asp:View>

    </asp:MultiView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

