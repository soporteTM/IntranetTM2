<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modulos_TMS_Default" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <%--<script type="text/javascript" src="../../App_Themes/zircos/default/assets/js/gridviewscroll.js"></script>--%>
    <script type="text/javascript" src="../../App_Themes/zircos/default/assets/plugins/datatables/gridviewscroll.js"></script>
    <script type="text/javascript">
        var gridViewScroll = null;
        function arregloGrilla() {
                gridViewScroll = new GridViewScroll({
                elementID: "GVPlaneamiento",
                width: 850,
                height: 350,
                freezeColumn: true,
                freezeFooter: false,
                freezeColumnCssClass: "GridViewScrollItemFreeze",
                //reezeFooterCssClass: "GridViewScrollFooterFreeze",
                freezeHeaderRowCount : 1,
                freezeColumnCount: 3
                //onscroll: function (scrollTop, scrollLeft) {
                //    console.log(scrollTop + " - " + scrollLeft);
                //}
            });
            gridViewScroll.enhance();
        }
    </script>
    <%--<script type="text/javascript">
        function mostrar() {
            alert('Hola mundo')
        }
    </script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".eventCopy").on('paste', function () {
                var $self = $(this);
                setTimeout(function () {
                    var dato = $self.val();
                    if (dato != "") {
                        dato = dato.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '-');
                        //alert(dato);
                        if (dato.length > 4) {
                            //alert(dato);
                            $("input[id*='txtPrefijo']").val(dato.substring(0, 4));
                            $("input[id*='txtNumero']").val(dato.substring(4));
                        }
                    }
                }, 100);

            });

            $("input[id*='chkMarcarTodos']").change(function (r) {
                $("input[id*='chkSeleccionar']").button('reset');
                var check = ($("input[id*='chkMarcarTodos']").is(":checked") ? 1 : 0)
                $("input[id*='chkSeleccionar']").attr("checked", check);
            });


        });

    </script>
    <script type="text/javascript">
        var ctrlRow = null;
        var ctrlRowTer = null;
        function LimpiarFormDetalle() {
            $("select[id*='dllTipoCTN']").val(0);
            $("input[id*='txtTotalCTN']").val("");
            $("input[id*='HFIndexServicio']").val("-1");
        }
        function LimpiarFormContenedor() {
            $("select[id*='ddlTipo2CTN']").val(0);
            $("input[id*='txtPrefijo']").val("");
            $("input[id*='txtNumero']").val("");
            $("input[id*='ddlLocal1']").val("0");
            $("input[id*='ddlLocal2']").val("0");
            $("input[id*='ddlTransporte']").val("88");
            $("input[id*='txtFechaCita']").val("");
            $("input[id*='txtHoraCita']").val("");
            $("input[id*='HFKItem']").val("0");
        }

        function validarCliente() {
            var cliente = $("select[id*='ddlCliente']").val();
            //alert(cliente);
            if (cliente == "[Seleccionar]" || cliente == "" || cliente == "0") {
                JAlert('Dede seleccionar un cliente', 'Información', 'danger');

                return false;
            }

            return true;
        }

        $(function () {

            //===== Form validation engine =====//
            //$("form").validationEngine();
            //===== UI dialog =====//           

            $("input[id*='chkCargaSuelta']").click(function (event) {
                var check = ($("input[id*='chkCargaSuelta']").is(':checked') ? 1 : 0);
                if (check == 1) {
                    $("input[id*='txtPrefijo']").val("CARG");
                    $("input[id*='txtNumero']").val("SUELTA");
                    $("input[id*='txtNumero']").attr("disabled", "disabled");
                    $("input[id*='txtPrefijo']").attr("disabled", "disabled");
                }
                else {
                    $("input[id*='txtPrefijo']").val("");
                    $("input[id*='txtNumero']").val("");
                    $("input[id*='txtNumero']").removeAttr("disabled");
                    $("input[id*='txtPrefijo']").removeAttr("disabled");
                }
            });
        });

        function strPad(input, length, string) {
            string = string || '0'; input = input + '';
            return input.length >= length ? input : new Array(length - input.length + 1).join(string) + input;
        }

        function findContenedores(row) {
            var tipo = $(row).parent().parent().find(".tipo").text();
            var pies = $(row).parent().parent().find(".pies").text();
            //alert(tipo + " - " + pies);
            $(row).parent().parent().parent().find("tr").removeClass("row_selected");
            $(row).parent().parent().addClass("row_selected");
            $("table[id*='GVDetalleSolicitud']").dataTable().fnFilter(tipo.toString().trim(), 2);
            $("table[id*='GVDetalleSolicitud']").dataTable().fnFilter(pies.toString().trim(), 1);
            return false;
        }

        function allContenedores() {
            $("table[id*='GVDetalleSolicitud']").dataTable().fnFilter("", 2);
            $("table[id*='GVDetalleSolicitud']").dataTable().fnFilter("", 1);
            $("table[id*='GVDetalleSolicitud'] tr").removeClass("row_selected");
            return false;
        }

    </script>
    
    <%--<script type="text/javascript">
        Console.log("Holaaaa");
        var gridViewScroll = new GridViewScroll({
            elementID: "GVPlaneamiento", // String

            width: 700, // Integer or String(Percentage)
            height: 350, // Integer or String(Percentage)
            freezeColumn: true, // Boolean
            
            //freezeColumnCssClass: "", // String
            //freezeFooterCssClass: "", // String
            freezeColumnCount: 3 // Integer
        });


    </script>--%>

    <style type="text/css">
        #ContentPlaceHolder1_GVDetalleSolicitud_filter,
        #ctl00_ContentPlaceHolder1_GVDetalleSolicitud_filter,
        #ctl00_ContentPlaceHolder1_gvContenedoresContrans_filter,
        #ContentPlaceHolder1_gvContenedoresContrans_filter {
            position: absolute;
            right: 0px;
            top: -35px;
            z-index: 1000;
        }

        #ContentPlaceHolder1_gvDetalleServicios_wrapper .dataTables_filter,
        #ContentPlaceHolder1_gvDetalleServicios_wrapper .dataTables_length,
        #ContentPlaceHolder1_gvDetalleServicios_wrapper .dataTables_info,
        #ContentPlaceHolder1_gvDetalleServicios_wrapper .dataTables_paginate,
        #ContentPlaceHolder1_GVDetalleSolicitud_wrapper .dataTables_filter,
        #ContentPlaceHolder1_GVDetalleSolicitud_wrapper .dataTables_length,
        #ContentPlaceHolder1_GVDetalleSolicitud_wrapper .dataTables_info,
        #ContentPlaceHolder1_GVDetalleSolicitud_wrapper .dataTables_paginate,
        #ContentPlaceHolder1_gvContenedoresContrans_filter {
            display: none;
        }

        @media (min-width: 768px) {
            .modal-sm {
                width: 360px !important;
            }
        }

        .panel-default .panel-heading {
            padding: 10px 20px !important;
        }

        .form-control {
            font-size: 12px !important;
        }

        .tab-content > .tab-pane {
            display: block;
        }

        .table .checkbox label {
            padding: 0px;
            width: 0px;
            color: transparent;
        }

        /*.table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
            vertical-align: middle !important;
        }*/

        /*.dataTables_scrollFootInner table {
            margin-bottom: 0px !important;
        }*/

        .select2-container .select2-selection--single .select2-selection__rendered {
            font-size: 10px;
            text-transform: uppercase;
        }

        .select2-results__option {
            padding: 6px 12px;
            font-size: 11px;
            text-transform: uppercase;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Solicitud de Transporte
                </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Operaciones</a>
                    </li>
                    <li class="active">Solicitud de Transporte
                    </li>
                </ol>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <%--Vista de búsqueda de AL--%>
        <asp:View ID="View1" runat="server">
            <div class="row">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <asp:HiddenField ID="lblMensaje" runat="server"/>
                                <div class="col-lg-2">
                                    <h4 class="header-title">Busqueda de Solictud</h4>
                                </div>

                                <div class="col-lg-10 text-right">
                                    <asp:LinkButton ID="btnFiltrarSolicitudes" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnFiltrarSolicitudes_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-search"></i> Buscar
                                    </asp:LinkButton> 

                                     <asp:LinkButton ID="btnAgregarSolicitud" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnAgregarSolicitud_Click">
                                        <i class="glyphicon glyphicon-file"></i> Nuevo
                                    </asp:LinkButton> 
                                      <asp:LinkButton ID="btnAnularSolicitud" runat="server" CssClass="btn btn-danger btn-sm" OnClientClick="JConfirm('¿Esta seguro de anular las solicitudes?','Confirmar Acción', this); return false;" OnClick="btnAnularSolicitud_Click">
                                        <i class="glyphicon glyphicon-trash"></i> Anular
                                    </asp:LinkButton> 

                                     <asp:LinkButton ID="btnProgramacion" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnProgramacion_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-road"></i> Programación
                                    </asp:LinkButton> 
                                    <asp:LinkButton ID="btnAgregarSeguimiento" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnAgregarSeguimiento_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-time"></i> Seguimiento
                                    </asp:LinkButton> 
                                     <asp:LinkButton ID="btnFacturacion" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnFacturacion_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-check"></i> Facturación
                                    </asp:LinkButton> 
                                    
                                     <asp:LinkButton ID="btnExportar" runat="server" CssClass="btn btn-success btn-sm" OnClick="btnExportar_Click">
                                        <i class="glyphicon glyphicon-file"></i> Exportar
                                    </asp:LinkButton> 
                                      
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>

                        <div class="panel-body" style="padding-bottom:10px;"> 
                             <div class="row form-group">
                                <div class="col-md-2">
                                    Movimiento
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList CssClass="form-control" ID="ddlMovimientoFiltro" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    Estado
                                </div>
                                <div class="col-md-2">
                                  <asp:DropDownList CssClass="form-control" ID="ddlEstadoFiltro" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    Cliente:</div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlEmpresaFiltro" runat="server" CssClass="form-control" >
                                    </asp:DropDownList>
                                </div>

                            </div>
                             <div class="row form-group">

                                <div class="col-md-2">
                                    RO / AL
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox CssClass="form-control" ID="txtALFiltro" runat="server"  ></asp:TextBox>
                                </div>

                                <div class="col-md-2">
                                    Nro Solicitud
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox CssClass="form-control" ID="txtNroSolicitudFiltro" runat="server"></asp:TextBox>
                                </div>

                                <div class="col-md-2">
                                    Tipo Solicitud
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlTipoSolicitudFiltro" runat="server" 
                                        AppendDataBoundItems="true" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>

                            </div>                             
                             <div class="row form-group">
                                <div class="col-md-2">
                                    Fecha Inicio
                                </div>
                                <div class="col-md-2">                                       
                                        <div class="input-group">
                                        <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span></span>
                                        <asp:TextBox  AutoCompleteType="None" placeholder="dd/mm/yyyy" data-provide="datepicker" cssclass="form-control datepickers" id="txtFechaDesdeFiltro" runat="server"></asp:TextBox>
                                        </div>                                
                                </div>
                                <div class="col-md-2">
                                   Fecha Termino
                                </div>
                                <div class="col-md-2">
                                                                       
                                        <div class="input-group">
                                        <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span></span>
                                        <asp:TextBox  AutoCompleteType="None" placeholder="dd/mm/yyyy" data-provide="datepicker" cssclass="form-control datepickers" id="txtFechaHastaFiltro" runat="server"></asp:TextBox>
                                        </div>    

                                </div>
                                <div class="col-md-2" >
                                  
                                    Seguimiento
                                  
                                </div>
                                <div class="col-md-2">
                                
                                    <asp:DropDownList ID="ddlSeguimientoFiltro" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="A">Ambos</asp:ListItem>
                                        <asp:ListItem Value="S">Si</asp:ListItem>
                                        <asp:ListItem Value="N">No</asp:ListItem>
                                    </asp:DropDownList>
                                
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-sm-2">
                                    Contenedor
                                </div>
                                <div class="col-sm-2">
                                    <asp:TextBox ID="txtContenedorFiltro" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="lblentidad0" runat="server"/>

            <div >
                <asp:GridView ID="GVPlaneamiento" runat="server" GridLines="None" AutoGenerateColumns="False" EmptyDataText="No se encontraron resultados"
                 OnRowCommand="GVPlaneamiento_RowCommand" CssClass="table table-striped table-bordered"
                > 
                    <%--CssClass="table table-striped table-bordered" scrollable-table dataTables_scroll OnPreRender="GVPlaneamiento_PreRender"--%>
                    <%--style="overflow-x:scroll;overflow:scroll;max-height:150px;width:500px;" --%>
                <Columns>

                    <asp:TemplateField ItemStyle-CssClass="FrozenCell" HeaderStyle-CssClass="FrozenCell">
                        <ItemTemplate>
                            <div class="checkbox checkbox-primary">
                                <asp:CheckBox ID="CheckBox1" runat="server" Enabled='<%# ( Convert.ToString(Eval("EstadoSegui")) == "Anulado" ? false : true)   %>' Text="." />
                            </div>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TIPO/SOL" ItemStyle-CssClass="FrozenCell" HeaderStyle-CssClass="FrozenCell">
                        <ItemTemplate>
                            <asp:Label ID="lblTipoSol" runat="server" CssClass="text2" Text='<%# Eval("TS_Des") %>'></asp:Label>
                        </ItemTemplate>
                        
                    </asp:TemplateField>

                   <%-- <asp:BoundField DataField="Sol_DiaD" HeaderText="DIAS DIFERIDOS" ItemStyle-CssClass="center" >
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="Ent_Ruc" HeaderText="RUC2" ItemStyle-CssClass="center" />
                    <asp:BoundField DataField="RucCliente" HeaderText="RUC3" ItemStyle-CssClass="center" />

                    <asp:BoundField DataField="Agente" HeaderText="AGENTE" />
                    <asp:BoundField DataField="UsuarioAsignado" HeaderText="USUARIO MODIF" >
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="Sol_Fmod" HeaderText="FECHA MODIF" />
                    <asp:BoundField DataField="TOTA" HeaderText="FACT." ItemStyle-CssClass="center" >
                        
                    </asp:BoundField>--%>

                    <asp:TemplateField HeaderText="SOLICITUD">
                        <ItemTemplate>
                            <asp:LinkButton ID="hplSolicitud" CommandName="Editar" CommandArgument='<%# Convert.ToString(Eval("ROS_Kitem")) + "|" + Convert.ToString(Eval("ROS_KRO")) + "|" + Convert.ToString(Eval("TS_DES")) %>' Text='<%# Eval("ROS_Kitem") %>' runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="lkSolDistrib" CommandName="select" Text='<%# Eval("ROS_Kitem") %>' Visible="false" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:BoundField DataField="ROS_KRO" HeaderText="RO/AL" ItemStyle-CssClass="center" >
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="EMP_CREACION" HeaderText="EMP.CREACION" >
                        
                    </asp:BoundField>
                    <%--     <asp:BoundField DataField="Sol_EstR" HeaderText="EST.ROUTING" />--%>
                    <asp:BoundField DataField="Tgc_Desc" HeaderText="MOVIMIENTO" >
                        
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="CLIENTE">
                        <ItemTemplate>
                            <asp:Label ID="lblcliente" runat="server" Text='<%# Eval("Ent_Rsoc") %>'></asp:Label>
                            <asp:Label ID="lblcliencod" runat="server" Text='<%# Eval("Ent_Rsoc") %>'
                                Visible="False"></asp:Label>
                        </ItemTemplate>
                        
                    </asp:TemplateField>

                    <asp:BoundField DataField="EstadoSegui" HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderText="ESTADO" >
                        
                    </asp:BoundField>

                    <asp:BoundField DataField="ROS_Observacion" HeaderText="OBSERVACION" >
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="Cantidad" HeaderText="CANT. CONT." ItemStyle-CssClass="center" >
                        
                    </asp:BoundField>
                    <%-- INICIO DE COLUMNAS AGREGADAS PARA FACTURACION --%>
                    <asp:TemplateField HeaderText="Ruc Cli." Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblRucCliente" runat="server" Text='<%# Eval("RucCliente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ruc Cli. del Cli." Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblRuc" runat="server" Text='<%# Eval("Ent_Ruc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DetFac_Solicitud" HeaderText="Facturacion" visible="true"/>
                    <%-- FIN DE COLUMNAS AGREGADAS PARA FACTURACION --%>
                    <asp:BoundField DataField="ROS_Ucre" HeaderText="USUARIO CREACION" >
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="ROS_Fcre" HeaderText="FECHA CREACION" DataFormatString="{0:d}" >
                        
                    </asp:BoundField>

                </Columns>

                <RowStyle CssClass="tabledit-view-mode" />
            </asp:GridView>
            </div>
             
        </asp:View>

        <%--Vista de registro de solicitud--%>
        <asp:View ID="View2" runat="server">

            <div class="row">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">

                                <div class="col-lg-7">
                                    <h4 class="header-title">Registrar solictud</h4>
                                </div>

                                <div class="col-lg-5" style="text-align: right;">

                                   <asp:HiddenField ID="HFCodigo" runat="server" Value="0" />

                                    <asp:LinkButton ID="btnGuardarSolicitud" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnGuardarSolicitud_Click">
                                        <i class="glyphicon glyphicon-floppy-saved"></i> Guardar
                                    </asp:LinkButton> 
                                     <asp:LinkButton ID="btnCancelarSolicitud" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnCancelarSolicitud_Click" >
                                        <i class="glyphicon  glyphicon-repeat"></i> Cancelar
                                    </asp:LinkButton> 
                                      <asp:LinkButton ID="btnImportarCTN" runat="server" CssClass="btn btn-inverse btn-sm" OnClientClick="return validarCliente();" OnClick="btnImportarCTN_Click">
                                        <i class="glyphicon glyphicon-import"></i> Importar datos contenedor(es)                     </asp:LinkButton> 
                                      
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>

                        <div class="panel-body" style="padding-bottom:10px;"> 
                             <div class="row">
                                 <div class="col-lg-4">
                                     <div class="row form-group">
                                        <div class="col-md-5">
                                            Tipo Solicitud:
                                        </div>
                                        <div class="col-md-7">                                                
                                                <asp:DropDownList ID="ddlTipoSolicitud" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                        </div>
                                    </div>
                                     <div class="row form-group">
                                        <div class="col-md-5">
                                            Nro. Solicitud:
                                        </div>
                                        <div class="col-md-7"> 
                                              <asp:TextBox ID="txtNroSolicitud" runat="server" ReadOnly="true"  CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-5">
                                             RO / AL:
                                        </div>
                                        <div class="col-md-7">
                                           <asp:TextBox ID="txtAL" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-5">
                                            Cliente:</div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlEmpresa" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEmpresa_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-5">
                                            Sub-Cliente:</div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-5">
                                            Fecha Solicitud:</div>
                                        <div class="col-md-7"> 
                                             <div class="input-group">
                                                <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                                <asp:TextBox  AutoCompleteType="None" placeholder="dd/mm/yyyy" data-provide="datepicker" cssclass="form-control datepickers" id="txtFechaSolicitud" runat="server"></asp:TextBox>
                                            </div>      
                                        </div>
                                    </div>
                                 </div>
                                 <div class="col-lg-4">
                                    <div class="row form-group">
                                        <div class="col-md-5">
                                             Movimiento:
                                        </div>
                                        <div class="col-md-7">
                                          <asp:DropDownList ID="ddlMovimiento" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                        </div>
                                    </div>

                                     <div class="row form-group">
                                        <div class="col-md-5">
                                           Incoterm:
                                        </div>
                                        <div class="col-md-7"> 
                                              <asp:DropDownList ID="ddlIncoterm" runat="server" CssClass="form-control" >
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-5">
                                             C. Embarque:
                                        </div>
                                        <div class="col-md-7">
                                           <asp:DropDownList ID="ddlCEmbarque" runat="server" CssClass="form-control" >
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-5">
                                            Booking:</div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtBKG" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-5">
                                            BL:</div>
                                        <div class="col-md-7">
                                             <asp:TextBox ID="txtBL" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div> 
                                     <div class="row form-group">
                                        <div class="col-md-5">
                                            Aduana:</div>
                                        <div class="col-md-7">
                                             <asp:DropDownList ID="ddlAduana" runat="server" CssClass="form-control" >
                                            </asp:DropDownList>
                                        </div>
                                    </div> 
                                 </div>

                                 <div class="col-lg-4">
                                    

                                     <div class="row form-group">
                                        <div class="col-md-5">
                                           Terminal (Recojo):
                                        </div>
                                        <div class="col-md-7"> 
                                              <asp:DropDownList ID="ddlTerminal" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-5">
                                             Terminal (vacio):
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlPuerto" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                        </div>
                                    </div>
                                     <div class="row form-group">
                                        <div class="col-md-5">
                                             Estado:
                                        </div>
                                        <div class="col-md-7">
                                          <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                        </div>
                                    </div>
                                     <div class="row form-group">
                                        <div class="col-md-5">
                                            Referencia:</div>
                                        <div class="col-md-7">
                                             <asp:TextBox ID="txtRef" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-5">
                                            Observación:</div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtObservacion" CssClass="form-control" runat="server" style="min-height:initial !important;" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                        </div>
                                    </div>
                                    <%--                                  <div class="row form-group">
                                        <div class="col-md-6">
                                            BL:</div>
                                        <div class="col-md-6">
                                             <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div> <div class="row form-group">
                                        <div class="col-md-6">
                                            Referencia:</div>
                                        <div class="col-md-6">
                                             <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div> --%>
                                 </div>
                            </div>                     

                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">

                                <div class="col-lg-7">
                                    <h4 class="header-title">Detalle de Carga</h4>
                                </div>

                                <div class="col-lg-5" style="text-align: right;">
 
                                    <asp:LinkButton ID="btnAgregarDetalle" runat="server" CssClass="btn btn-primary btn-sm" OnClientClick="$('#modalDetalleCarga').modal('show'); LimpiarFormDetalle(); return false;">
                                        <i class="glyphicon glyphicon-plus"></i> Agregar
                                    </asp:LinkButton> 
                                   <%-- <asp:Button ID="btnAgregarDetalle" runat="server" Text="Agregar" CssClass="basicBtn" 
                        style="float:right; margin-top:6px; margin-right:6px;" 
                        onclientclick="LimpiarFormDetalle(); AbrirModalAdjunto(this); return false;" />--%>                                      
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>

                        <div class="panel-body" style="padding-bottom:10px;"> 
                                     
                            <div class="table"> 
                                <asp:GridView cssclass="table table-striped table-bordered grillascrollYa" gridlines="None" ID="gvDetalleServicios" runat="server"
                                    AutoGenerateColumns="False" EmptyDataText="No hay información" OnPreRender="gvDetalleServicios_PreRender" OnRowCommand="gvDetalleServicios_RowCommand" >
                                    <Columns>
                                    <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate>
                                            <%# Convert.ToInt32(Container.DataItemIndex) + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="center" />
                                         <HeaderStyle Width="20px" />
                                    </asp:TemplateField>

                                        <asp:TemplateField  HeaderText="Tipo / Pies">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTipoPies" runat="server" Text='<%# Eval("TipoPies") %>'></asp:Label>
                                                 - 
                                               <asp:Label ID="lblTIPOCTN" runat="server" Text='<%# Bind("TIPOCTN") %>'></asp:Label>
                                                
                                            </ItemTemplate> 
                                            <ItemStyle CssClass="center tipo" />
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label>
                                            </ItemTemplate>
                                                            
                                             <ItemStyle CssClass="center" />
                                        </asp:TemplateField>
                         
                 <%--                        
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:ImageButton CommandName="Delete" CausesValidation="False" ID="ImageButton1a"
                                                    runat="server" CssClass="bt1n14 " ImageUrl="~/App_Themes/Templete/images/icons/dark/close.png"
                                                    ToolTip="Quitar servicio" OnClientClick="return confirm('¿Desea quitar este detalle?');" /></ItemTemplate>
                                            <HeaderStyle Width="30px" />
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>--%>
                <%--                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:ImageButton CommandName="Edit" CausesValidation="False" ID="ImageButton1aas"
                                                    runat="server" CssClass="bt1n14 " ImageUrl="~/App_Themes/Templete/images/icons/dark/pencil.png"
                                                    ToolTip="Editar detalle"  /> 
                                            </ItemTemplate>
                                            <HeaderStyle Width="30px" />
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>--%>
                <%--                        <asp:CommandField ButtonType="Image" CancelImageUrl="~/Images/canceled.png" EditImageUrl="~/Images/icono_editar.gif"
                                                ShowEditButton="True" UpdateImageUrl="~/Images/ico_actualizar.gif">
                                            <ItemStyle Wrap="False" />
                                        </asp:CommandField>--%>

                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                             <asp:ImageButton CommandName="Select" CausesValidation="False" ID="btnVerContenedores" OnClientClick="return findContenedores(this);"
                                                    runat="server" CssClass="bt1n14 " ImageUrl="~/App_Themes/Templete/images/icons/dark/list.png"
                                                    ToolTip="Ver contenedores"  /> </ItemTemplate>
                                     
                             
                                            <HeaderStyle Width="30px" />
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
 
                                     
                                            <asp:LinkButton CommandName="eliminar" CommandArgument='<%# Convert.ToInt32(Container.DataItemIndex) %>' ID="LinkButton1" runat="server" CssClass="btn btn-danger btn-xs">
                                        <i class="glyphicon glyphicon-plus1"></i> Eliminar
                                    </asp:LinkButton> 
                             </ItemTemplate>
                                            <HeaderStyle Width="30px" />
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>              

                        </div>
                    </div>
                </div>
                <div class="col-lg-8">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">

                                <div class="col-lg-7">
                                    <h4 class="header-title">Detalle de Contenedores</h4>
                                </div>

                                <div class="col-lg-5" style="text-align: right;">

                                  

                                    <asp:LinkButton ID="btnAgregarContenedor" runat="server" CssClass="btn btn-primary btn-sm"  OnClientClick="$('#modalDetalleContenedor').modal('show');  LimpiarFormContenedor();  return false;">
                                        <i class="glyphicon glyphicon-plus"></i> Agregar
                                    </asp:LinkButton> 
                                     <asp:LinkButton ID="btnAllCTN" Visible="false" runat="server" CssClass="btn btn-default btn-sm"  >
                                        <i class="glyphicon  glyphicon-repeat"></i> Motrar Todos
                                    </asp:LinkButton> 
                     
                             <%--        <asp:Button ID="btnAgregarContenedor" runat="server" Text="Agregar" CssClass="basicBtn" 
                        style="float:left; margin-top:6px; margin-right:6px;" 
                       />

                       <asp:Button ID="btnAllCTN" runat="server" Text="Ver todos CTN" CssClass="basicBtn" OnClientClick="return allContenedores();" 
                        style="float:left; margin-top:6px; margin-right:6px;" 
                       />--%>
                                      
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>

                        <div class="panel-body" style="padding-bottom:10px;">                                                    
                            <div class="table" >
                                <asp:GridView cssclass="table table-striped table-bordered grillascrollYa" gridlines="None" ID="GVDetalleSolicitud" runat="server"
                                    AutoGenerateColumns="False" EmptyDataText="No hay información" OnPreRender="GVDetalleSolicitud_PreRender" OnRowCommand="GVDetalleSolicitud_RowCommand">
                                    <Columns>
                             
                                          <%--<asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkheadAll" runat="server" />
                                            </ItemTemplate>
                                             <HeaderTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                             </HeaderTemplate>
                                           <ItemStyle CssClass="center" />
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="RO/AL" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemROAL" runat="server" Text='<%# Eval("ROAL") %>'></asp:Label>
                                            </ItemTemplate>
                                 
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>

                            

                                        <asp:TemplateField HeaderText="Contenedor">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContenedor" runat="server" Text='<%# Eval("Contenedor") %>'></asp:Label>
                                                <asp:Label ID="lblNumero" runat="server" Text='<%# Eval("Numero") %>' Visible="False"></asp:Label>
                                                <asp:Label ID="lblPrefijo" runat="server" Text='<%# Eval("Prefijo") %>' Visible="False"></asp:Label>
                                                 <asp:Label ID="lblTransporte" runat="server" Text='<%# Eval("Transportista") %>' Visible="False"></asp:Label>
                                                 <asp:Label ID="lblIDTransporte" runat="server" Text='<%# Eval("Transportista_ruc") %>' Visible="False"></asp:Label>
                                                <asp:Label ID="lblItem" runat="server" Text='<%# Eval("Item") %>' Visible="False"></asp:Label>
                                            </ItemTemplate>
                                 
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pies">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemPies" runat="server" Text='<%# Eval("Pies") %>'></asp:Label>
                                            </ItemTemplate>
                                 
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemTipo" runat="server" Text='<%# Eval("Tipo") %>'></asp:Label>
                                            </ItemTemplate>
                                 
                                           <ItemStyle CssClass="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tara" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTara" runat="server" Text='<%# Eval("Tara") %>'></asp:Label>
                                            </ItemTemplate>
                                 
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Peso" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPeso" runat="server" Text='<%# Eval("Peso") %>'></asp:Label>
                                            </ItemTemplate>
                                             <ItemStyle CssClass="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Precinto" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPyld" runat="server" BorderStyle="None" 
                                                    Text='<%# Eval("Precinto") %>'></asp:Label>
                                            </ItemTemplate>
                                 
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>
                            
                                        <asp:TemplateField HeaderText="Fecha Cita">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaCita" runat="server" BorderStyle="None" 
                                                    Text='<%# Eval("FechaCita") %>'></asp:Label> <%# Eval("HoraCita") %>
                                            </ItemTemplate>
                                 
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Hora Cita" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHoraCita" runat="server" BorderStyle="None" 
                                                    Text='<%# Eval("HoraCita") %>'></asp:Label>
                                            </ItemTemplate>
                                 
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Local">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocal" runat="server" BorderStyle="None" 
                                                    Text='<%# Eval("Local1") %>'></asp:Label>
                                                <asp:Label ID="lblIDLocal" runat="server" BorderStyle="None" Visible="false"
                                                    Text='<%# Eval("IDLocal1") %>'></asp:Label>
                                            </ItemTemplate>
                                 
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Local 2" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocal2" runat="server" BorderStyle="None" 
                                                    Text='<%# Eval("Local2") %>'></asp:Label>
                                                <asp:Label ID="lblIDLocal2" runat="server" BorderStyle="None" Visible="false"
                                                    Text='<%# Eval("IDLocal2") %>'></asp:Label>
                                            </ItemTemplate>
                                 
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>
                             
                             
                                   <%--     <asp:TemplateField HeaderText="Placa">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPlaca" runat="server" Text='<%# Eval("Placa") %>'></asp:Label>
                                            </ItemTemplate>
                                 
                                           <ItemStyle CssClass="center" />
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField ShowHeader="False" Visible="false">
                                        <ItemTemplate>
                                            <asp:ImageButton CommandName="Select" CausesValidation="False" ID="ImageButton1eeea"
                                                runat="server" CssClass="bt1n14 " ImageUrl="~/App_Themes/Templete/images/icons/dark/close.png"
                                                ToolTip="Quitar servicio" OnClientClick="return confirm('¿Desea quitar este contenedor?');" /></ItemTemplate>
                                        <HeaderStyle Width="30px" />
                                        <ItemStyle CssClass="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField ShowHeader="False" Visible="false">
                                 
                                            <ItemTemplate>
                                                   <asp:ImageButton CommandName="Delete" CausesValidation="False" ID="btnVerContenedoresSeguimiento" Visible='<%# Eval("EsNuevo") %>'
                                                runat="server" CssClass="bt1n14 " ImageUrl="~/App_Themes/Templete/images/icons/dark/list.png"
                                                ToolTip="Ver seguimiento"  />  
                                 
                                            </ItemTemplate>
                                           <ItemStyle CssClass="center" />
                                        </asp:TemplateField>

                                         <asp:TemplateField>
                                            <ItemTemplate>
 
                                     
                                            <asp:LinkButton CommandName="eliminar" CommandArgument='<%# Convert.ToInt32(Container.DataItemIndex) %>' ID="LinkButton1" runat="server" CssClass="btn btn-danger btn-xs">
                                        <i class="glyphicon glyphicon-plus1"></i> Eliminar
                                    </asp:LinkButton> 
                             </ItemTemplate>
                                            <HeaderStyle Width="30px" />
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>
                             
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
             
            
            <div id="modalDetalleCarga" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Cerrar</span>
                            </button>
                            <h4 class="modal-title">Registro de Carga</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                <div class="form-group col-lg-6">
                                    <label for="userName">Tipo </label> 
                                     <asp:DropDownList ID="dllTipoCTN" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="dllTipoCTN" ValidationGroup="carga" Display="Dynamic" InitialValue="0" CssClass="text-danger" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Completar dato"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-lg-6">
                                    <label for="userName"> Cantidad </label>
                                    <asp:TextBox ID="txtTotalCTN" runat="server" CssClass="form-control number"
                                         AutoCompleteType="Disabled"></asp:TextBox>
                                    <asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="txtTotalCTN" ValidationGroup="carga" Display="Dynamic" CssClass="text-danger" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Completar dato"></asp:RequiredFieldValidator>
                                </div>                                
                                
                                </div>
                        </div>
                        <div class="modal-footer">

                            <asp:HiddenField ID="HFIndexServicio" Value="-1" runat="server" />
                            <asp:Button ID="btnAgregarPopup_CTN" CssClass="btn btn-primary" ValidationGroup="carga" runat="server" Text="Agregar" OnClick="btnAgregarPopup_CTN_Click" UseSubmitBehavior="False" />

                            <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Cerrar</button>

                        </div>
                    </div>
                </div>
            </div>

            <div id="modalDetalleContenedor" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Cerrar</span>
                            </button>
                            <h4 class="modal-title">Registro de Contenedor</h4>
                        </div>
                        <div class="modal-body">
                             

                                <div class="row">                                    
                                    <div class="form-group col-lg-6">
                                    <label for="userName">Tipo/Pies </label> 
                                     <asp:DropDownList ID="ddlTipo2CTN" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                        <asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="ddlTipo2CTN" ValidationGroup="detalle" Display="Dynamic" InitialValue="0" CssClass="text-danger" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Completar dato"></asp:RequiredFieldValidator>
                                        </div>

                                      <div class="form-group col-lg-6">
                                    <label for="userName">¿Carga Suelta? </label>
                                          <div>
<asp:CheckBox ID="chkCargaSuelta" runat="server" />
                                          </div> 
                                    
                                        </div>

                                     </div>
                                <div class="row">
                               
                                    <div class="form-group col-lg-6">
                                    <label for="userName"> Prefijo </label>
                                    <asp:TextBox ID="txtPrefijo" runat="server" CssClass="form-control eventCopy" 
                                        AutoCompleteType="Disabled"></asp:TextBox>
                                        <asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="txtPrefijo" ValidationGroup="detalle" Display="Dynamic" CssClass="text-danger" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Completar dato"></asp:RequiredFieldValidator>
                                </div>   
                                    <div class="form-group col-lg-6">
                                    <label for="userName"> Número </label>
                                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"
                                        AutoCompleteType="Disabled"></asp:TextBox>
                                        <asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="txtNumero" ValidationGroup="detalle" Display="Dynamic" CssClass="text-danger" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Copmpletar dato"></asp:RequiredFieldValidator>
                                </div>    
                                </div> 
                                <div class="row">                                    
                                    <div class="form-group col-lg-12">
                                    <label for="userName">1° Lugar Descarga </label> 
                                     <asp:DropDownList ID="ddlLocal1" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="ddlLocal1" ValidationGroup="detalle" Display="Dynamic" InitialValue="0" CssClass="text-danger" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Completar dato"></asp:RequiredFieldValidator>--%>
                                </div>
                                     </div>     
                                <div class="row">                                    
                                    <div class="form-group col-lg-12">
                                    <label for="userName">2° Lugar Descarga </label> 
                                     <asp:DropDownList ID="ddlLocal2" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                     </div>     
                                <div class="row">                                    
                                    <div class="form-group col-lg-6">
                                    <label for="userName">Fecha Cita </label> 
                                   
                                         <div class="input-group">
                                                <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                                <asp:TextBox  AutoCompleteType="Disabled" placeholder="dd/mm/yyyy" data-provide="datepicker" cssclass="form-control datepickers" id="txtFechaCita" runat="server"></asp:TextBox>
                                            </div>  
                                        <asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="txtFechaCita" ValidationGroup="detalle" Display="Dynamic" CssClass="text-danger" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Completar dato"></asp:RequiredFieldValidator>
                                    </div>
                                        <div class="form-group col-lg-6">
                                        <label for="userName"> Hora Cita </label>
                                                 <div class="input-group">
                                                <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                                <asp:TextBox  AutoCompleteType="Disabled" placeholder="hh:mm" data-provide="timepicker" cssclass="form-control datepickers" id="txtHoraCita" runat="server"></asp:TextBox>
                                            </div>  
                                            <asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="txtHoraCita" ValidationGroup="detalle" Display="Dynamic" CssClass="text-danger" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Completar dato"></asp:RequiredFieldValidator>
                                    </div>      
                                </div>       
                                <div class="row">                                    
                                    <div class="form-group col-lg-12">
                                    <label for="userName">Transporte </label> 
                                     <asp:DropDownList ID="ddlTransporte" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                     </div>
                                                     
                                
                               
                        </div>
                        <div class="modal-footer">
                              <asp:HiddenField ID="HFKItem" runat="server" Value="0" />
                        <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" ValidationGroup="detalle" Text="Agregar" UseSubmitBehavior="False" OnClick="btnAgregar_Click" 
                            />
                             
                            <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Cerrar</button>

                        </div>
                    </div>
                </div>
            </div> 


            <div id="modalImportarContenedor" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Cerrar</span>
                            </button>
                            <h4 class="modal-title">Importar Contenedor</h4>
                        </div>
                        <div class="modal-body">

                              
                                <ul class="nav nav-tabs">
                                    <li id="li1" runat="server" class="">
                                        <asp:LinkButton ID="btnTab1" runat="server" OnClick="btnTab1_Click"><span class="visible-xs"><i class="fa fa-user"></i></span><span class="hidden-xs">1. Integral</span></asp:LinkButton></li>
                                    <li id="li2" runat="server" class="">
                                        <asp:LinkButton ID="btnTab2" runat="server" OnClick="btnTab2_Click"><span class="visible-xs"><i class="fa fa-users"></i></span><span class="hidden-xs">2. Operativo</span></asp:LinkButton></li>
                                    <li id="li3" runat="server" class="">
                                        <asp:LinkButton ID="btnTab3" runat="server" OnClick="btnTab3_Click"><span class="visible-xs"><i class="fa fa-graduation-cap"></i></span><span class="hidden-xs">3. Excel</span></asp:LinkButton></li>
                                    
                                    
                                    
                                    
                                </ul>

                         <div class="tab-content">
                                <div class="tab-pane">
                                    <div class="col-lg-12">
                                        <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">

                                        <asp:View ID="View1a" runat="server">
                                            <div class="row form-group">
                                        <div class="col-md-2">
                                                Nro. Volante:
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtNroVolante" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="txtNroVolante" ValidationGroup="ctn" Display="Dynamic" CssClass="text-danger" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Completar dato"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:LinkButton ID="btnBuscarContenedor" runat="server" CssClass="btn btn-primary btn-sm" ValidationGroup="ctn" OnClick="btnBuscarContenedor_Click">
                                        <i class="glyphicon glyphicon-search"></i> Buscar
                                    </asp:LinkButton> 

                                            </div>
                                    </div>
                                            </asp:View>
                                        <asp:View ID="View2a" runat="server">

                                            <div class="row form-group">
                                        <div class="col-md-2 text-right">
                                                Movimiento:
                                        </div>
                                        <div class="col-md-2">
                                            <asp:DropDownList CssClass="form-control" ID="ddlMovimientoIntegracion" runat="server">
                                                                    <asp:ListItem Value="I">Importacion</asp:ListItem>
                                                                    <asp:ListItem Value="E">Exportacion</asp:ListItem>
                                                                    </asp:DropDownList>
                                            
                                        </div>
                                        <div class="col-md-2 text-right">
                                                Año: 
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtAnno" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="txtAnno" ValidationGroup="ctn2" Display="Dynamic" CssClass="text-danger" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Completar dato"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2 text-right">
                                                Manifiesto:
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtNunManifiesto" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="txtNunManifiesto" ValidationGroup="ctn2" Display="Dynamic" CssClass="text-danger" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Completar dato"></asp:RequiredFieldValidator>
                                        </div>
                                            </div>
                                         <div class="row form-group">
                                        <div class="col-md-2 text-right">
                                                Viaje:
                                        </div>
                                        <div class="col-md-2" >
                                            <asp:TextBox ID="txtViaje" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="txtViaje" ValidationGroup="ctn2" Display="Dynamic" CssClass="text-danger" ID="RequiredFieldValidator12" runat="server" ErrorMessage="Completar dato"></asp:RequiredFieldValidator>
                                        </div>

                                                <div class="col-md-2 text-right">
                                                Rumbo:
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtRumbo" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="txtRumbo" ValidationGroup="ctn2" Display="Dynamic" CssClass="text-danger" ID="RequiredFieldValidator13" runat="server" ErrorMessage="Completar dato"></asp:RequiredFieldValidator>
                                        </div>
                                             <div class="col-md-2">
                                           </div>
                                        <div class="col-md-2">
                                            <asp:LinkButton ID="btnBuscarContenedor_Operativo" runat="server" CssClass="btn btn-primary btn-sm" ValidationGroup="ctn2" OnClick="btnBuscarContenedor_Operativo_Click">
                                        <i class="glyphicon glyphicon-search"></i> Buscar
                                    </asp:LinkButton> 

                                            </div>
                                    </div>

                                             
                                        </asp:View>
                                        <asp:View ID="View3a" runat="server">
                                            <div class="row form-group">
                                        <div class="col-md-2">
                                               Plantilla excel:
                                        </div>
                                        <div class="col-md-5">
                                            <asp:FileUpload ID="FU_ExcelContenedores" runat="server" CssClass="form-control" />
                                            <asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="FU_ExcelContenedores" ValidationGroup="ctn3" Display="Dynamic" CssClass="text-danger" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Completar dato"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:LinkButton ID="btnImportarExcel" runat="server" CssClass="btn btn-primary btn-sm" ValidationGroup="ctn3" OnClick="btnImportarExcel_Click">
                                        <i class="glyphicon glyphicon-plus"></i> Importar datos
                                    </asp:LinkButton> 
                                           </div>  <div class="col-md-2 text-right">
                                             <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-default btn-sm" OnClientClick="location.href = '../../Formatos/xls/Plantilla_CargaContenedores.xlsx'; return false;">
                                        <i class="glyphicon glyphicon-download"></i> Descargar plantilla
                                    </asp:LinkButton> 

                                            </div>
                                    </div>
                                        </asp:View>
                                       
                                        </asp:MultiView>
                                        
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                           
                            <!-- end col -->  
                                
                            
                                <asp:GridView CssClass="table table-striped table-bordered grillascrollY" ID="gvContenedoresContrans" runat="server" OnPreRender="gvContenedoresContrans_PreRender" gridlines="None" 
                        AutoGenerateColumns="False" EmptyDataText="No hay información" >
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <HeaderTemplate>
                                    <div class="checkbox checkbox-primary">
                               <asp:CheckBox ID="chkMarcarTodos" runat="server" Text="." />
                                        </div>
                               </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="checkbox checkbox-primary">
                                        <asp:CheckBox ID="chkSeleccionar" runat="server" Text="." />
                                         <asp:Label Visible="false" ID="lblContenedor" runat="server" Text='<%# Eval("CONTENEDOR") %>'></asp:Label>
                                         <asp:Label Visible="false" ID="lblTipo" runat="server" Text='<%# Bind("TIPO_CTN") %>'></asp:Label>
                                         <asp:Label Visible="false" ID="lblPies" runat="server" Text='<%# Bind("SIZE_CTN") %>'></asp:Label>
                                                

                                    </div>
                                    
                                </ItemTemplate>
                                <HeaderStyle Width="1px" CssClass="text-center" />
                                <ItemStyle CssClass="text-center" />
                            </asp:TemplateField>  
                            <asp:BoundField DataField="CONTENEDOR" HeaderText="Contenedor" />
                            <asp:BoundField DataField="PRECINTO" HeaderText="Precinto" Visible="false" />
                            <asp:BoundField DataField="TARA" HeaderText="Tara" Visible="false" />
                            <asp:BoundField DataField="SIZE_CTN" HeaderText="Size" />
                            <asp:BoundField DataField="TIPO_CTN" HeaderText="Tipo" />
                            <asp:BoundField DataField="BULTOS" HeaderText="Bultos" Visible="false" />
                            <asp:BoundField DataField="PESO_NETO" HeaderText="Peso neto" Visible="false" />
                            <asp:BoundField DataField="PESO_BRUTO" HeaderText="Peso bruto" Visible="false" />        
                            
                            <asp:BoundField DataField="PROV_TRANSPORTE" HeaderText="Transporte" Visible="false"/>  
                            <asp:BoundField DataField="RUC_TRANSPORTE" HeaderText="Ruc" Visible="false" />  
                            <asp:BoundField DataField="PLACA_VEHICULO" HeaderText="Placa" Visible="false"/>  
                            <asp:BoundField DataField="CHOFER" HeaderText="Chofer" Visible="false"/>  
                            <asp:BoundField DataField="BREVETE" HeaderText="Brevete" Visible="false"/>
                            <asp:BoundField DataField="FECHA" HeaderText="Fecha Cita" Visible="false" />
                            
  
                            <asp:TemplateField  HeaderText="Local">
                                <ItemTemplate>
                                     <asp:DropDownList ID="ddlLocal1" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                                <ItemStyle CssClass="center" />
                            </asp:TemplateField>  
                            <asp:TemplateField  HeaderText="Local (2)">
                                <ItemTemplate>
                                     <asp:DropDownList ID="ddlLocal2" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </ItemTemplate>
                               <HeaderStyle Width="100px" />
                                <ItemStyle CssClass="center" />
                            </asp:TemplateField>  
                            <asp:TemplateField  HeaderText="Fecha Cita">
                                <ItemTemplate>
                                    <asp:Label ID="lblFecha" runat="server" Text='<%# Eval("FECHA") %>' Visible="false"></asp:Label>
                                    <div class="input-group">
                                                <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                                <asp:TextBox  AutoCompleteType="Disabled" placeholder="dd/mm/yyyy" data-provide="datepicker" cssclass="form-control datepickers" id="txtFechaCita" runat="server"></asp:TextBox>
                                            </div>  
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                                <ItemStyle CssClass="center" />
                            </asp:TemplateField>  
                            <asp:TemplateField  HeaderText="Hora Cita">
                                <ItemTemplate>
                                     <div class="input-group">
                                                <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                                <asp:TextBox  AutoCompleteType="Disabled" placeholder="hh:mm" data-provide="timepicker" cssclass="form-control datepickers" id="txtHoraCita" runat="server"></asp:TextBox>
                                            </div>  
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                                <ItemStyle CssClass="center" />
                            </asp:TemplateField>                    
                        </Columns>
                    </asp:GridView>
                            <div class="row" >
                                
                                <div class="col-md-4">
                                <div class="checkbox checkbox-primary">
                                        <asp:CheckBox ID="chkAsignacionMasiva" runat="server" OnCheckedChanged="chkAsignacionMasiva_CheckedChanged" AutoPostBack="true" Text="Asignar a todos" Checked="false" Enabled="false"/>
                                </div>
                                    </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlLocal1Masivo" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlLocal2Masivo" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                            
                            
                        </div>
                        <div class="modal-footer">
                             
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Continuar" UseSubmitBehavior="False" OnClick="Button1_Click" />
                             
                            <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Cerrar</button>

                        </div>
                    </div>
                </div>
            </div> 

            <div id="PanelSeguimiento" class="popupAdjunto segui ui-dialog ui-widget ui-widget-content" style="z-index: 1005; height: 470px; width: 900px; display:none;">
                <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix">
                    <span class="ui-dialog-title">Seguimiento</span>
                </div>
                <div style="height: 409px;" class="ui-dialog-content ui-widget-content">
                    <fieldset>
                        <div class="widget" style="margin-top: 10px; text-align: left; border: none;">
                            <div class="validationGroup" style="padding: 0px;">
                            
                    <table class="mainForm" border="0" style="border:1px solid #A6C9E2; border-top:none;">
                        <tr>
                            <td class="head" colspan="2"  >
                                Información del <asp:Label ID="lblTerminal1_t" runat="server" Text="Puerto"></asp:Label></td>
                            <td  class="head"  colspan="2"  >
                                Información del <asp:Label ID="lblTerminal2_t" runat="server" Text="Terminal"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="padding-top:7px;">                                  
                                <asp:Label ID="lblTerminal1" runat="server" Text="Terminal"></asp:Label>
                            </td>
                            <td style="padding-top:7px; width:298px;">
                                <asp:DropDownList ID="ddlTerminalRetiro" Enabled="False" runat="server" CssClass="select combo">
                                </asp:DropDownList>
                            </td>
                            <td  style="padding-top:7px;">
                                 
                                <asp:Label ID="lblTerminal2" runat="server" Text="Terminal"></asp:Label>
                            </td>
                            <td style="padding-top:7px;" >
                                <asp:DropDownList ID="ddlTerminalDevolucion" Enabled="False" runat="server" CssClass="select combo" >
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                 Llegada 
                            </td>
                            <td class="style18">
                                <asp:TextBox ID="txtFecLleTerRV" CssClass="datetimepickerSinMask" runat="server" ></asp:TextBox>
                             
                               
                            </td>
                            <td  >
                                Llegada 
                            </td>
                            <td class="style22" >
                                <asp:TextBox ID="txtFecLlegTerDI" CssClass="datetimepickerSinMask" runat="server"></asp:TextBox>
                               
                            </td>
                        </tr>
                        <tr>
                            <td  >
                                 Ingreso 
                            </td>
                            <td  >
                                <asp:TextBox ID="txtFecIngTerRV" CssClass="datetimepickerSinMask" runat="server" ></asp:TextBox>
                             
                            </td>
                            <td  >
                                 Ingreso 
                            </td>
                            <td  >
                                <asp:TextBox ID="txtFecIngTerDI" CssClass="datetimepickerSinMask" runat="server"  ></asp:TextBox>
                               
                            </td>
                        </tr>
                        <tr>
                            <td >
                               Salida 
                            </td>
                            <td  >
                                <asp:TextBox ID="txtFecSalTerRV" CssClass="datetimepickerSinMask" runat="server"  ></asp:TextBox>
                               
                            </td>
                            <td >
                                Salida 
                            </td>
                            <td >
                                <asp:TextBox ID="txtFecSalTerDI" runat="server" CssClass="datetimepickerSinMask"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td >
                                Observación 
                            </td>
                            <td >
                                <asp:TextBox ID="txtObsTerRV" runat="server" CssClass="textobox" Height="58px"   Rows="2" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td  >
                                Observación 
                            </td>
                            <td >
                                <asp:TextBox ID="txtObsTerDI" runat="server"  Height="58px"  Rows="2" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                        <td colspan="4" style="height:2px;"></td>
                        </tr>
                        <tr>
                            <td class="head" colspan="4">Transporte</td>
                        </tr>

                          <tr>
                        <td colspan="4" style="height:2px;"></td>
                        </tr>

                         <tr>
                    <td >
                        Transportista </td>
                    <td  >
                    
                       
                        <asp:DropDownList ID="ddlTransportista" CssClass="chzn-select combo"  
                            runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </td><td>&nbsp; </td><td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="titulotd">
                        Unidad 
                    </td>
                    <td >
                     
                        <asp:DropDownList ID="ddlUnidadTransporte" CssClass="select combo"  runat="server">
                        </asp:DropDownList>
                    </td><td>&nbsp;</td><td>&nbsp;</td>
              </tr>
              <tr>    
                    <td class="titulotd">
                        Chofer </td>
                    <td  >
                        <asp:DropDownList ID="ddlChofer" CssClass="select combo"  runat="server">
                        </asp:DropDownList>
                    </td>
                 
                            <td colspan="2"  style=" padding-right:5px;" >
                                   <asp:HiddenField ID="HFContenedor" Value="0" runat="server" />
                                    <asp:HiddenField ID="HFPies" Value="0" runat="server" />
                                    <asp:HiddenField ID="HFTipo" Value="0" runat="server" />
                                     <asp:HiddenField ID="HFItem" Value="0" runat="server" />
                                   

                                            <asp:Button ID="btnGuardarSeguimiento" CssClass="blueBtn causesValidation" runat="server"
                                                Text="Guardar" />
                                                 <asp:Button ID="Button2" CssClass="basicBtn" runat="server"
                                                Text="Canclar" onclientclick="clearPopup(); return false" /></td>
                            
                        </tr>
                          <tr>
                        <td colspan="4" style="height:2px;"></td>
                        </tr>
                    </table>
              
                   </div>
                        </div>
                    </fieldset>
                </div>
                 
            </div>

 


             
           
        </asp:View>

        <%--Vista de programación--%>
        <asp:View ID="View3" runat="server">

            <div class="row">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">

                                <div class="col-lg-7">
                                    <h4 class="header-title">Programación de Conductor/Unidades</h4>
                                </div>

                                <div class="col-lg-5" style="text-align: right;">

                                   <asp:HiddenField ID="HFNroSolicitud" runat="server" Value="0" />

                                    <asp:LinkButton ID="btnGuardarProgramacion" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnGuardarProgramacion_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-floppy-saved"></i> Guardar
                                    </asp:LinkButton> 
                                     <asp:LinkButton ID="btnCancelarProgramacion" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnCancelarSolicitud_Click" >
                                        <i class="glyphicon  glyphicon-repeat"></i> Cancelar
                                    </asp:LinkButton> 
 
                                      
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>

                        <div class="panel-body" style="padding-bottom:10px;"> 
                             <div class="table"> 
                                <asp:GridView cssclass="table table-striped table-bordered grillascrollYa" gridlines="None" ID="gvProgramacion" runat="server"
                                    AutoGenerateColumns="False" EmptyDataText="No hay información" OnPreRender="gvProgramacion_PreRender">
                                    <Columns>
                                  <%--  <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate>
                                            <%# Convert.ToInt32(Container.DataItemIndex) + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="center" />
                                         <HeaderStyle Width="20px" />
                                    </asp:TemplateField>--%>

                                        <asp:BoundField DataField="Solicitud" HeaderText="Sol" ItemStyle-CssClass="center" />
                                        <asp:BoundField DataField="RO/AL" HeaderText="RO/AL" ItemStyle-CssClass="center" />
                                       <%-- <asp:BoundField DataField="ROS_KRO" HeaderText="EMPRESA" ItemStyle-CssClass="center" />
                                        <asp:BoundField DataField="ROS_KRO" HeaderText="CLIENTE" ItemStyle-CssClass="center" />--%>
                                        <asp:BoundField DataField="Contenedor" HeaderText="Contenedor" ItemStyle-CssClass="center" />
                                       <%--<asp:BoundField DataField="Pies" HeaderText="CONTENEDOR" ItemStyle-CssClass="center" />
                                       <asp:BoundField DataField="Tipo" HeaderText="CONTENEDOR" ItemStyle-CssClass="center" />
                                       <asp:BoundField DataField="Fecha Cita" HeaderText="CONTENEDOR" ItemStyle-CssClass="center" />
                                        <asp:BoundField DataField="Hora Cita" HeaderText="CONTENEDOR" ItemStyle-CssClass="center" />--%>
          
                                        <asp:TemplateField HeaderText="Pies/Tipo">
                                        <ItemTemplate>
                                            <asp:Label Visible="false" ID="IDPlaca" runat="server" Text='<%# Eval("IDPlaca") %>'></asp:Label>
                                            <asp:Label Visible="false" ID="Placa" runat="server" Text='<%# Eval("Placa") %>'></asp:Label>
                                            <asp:Label Visible="false" ID="Conductor" runat="server" Text='<%# Eval("IDConductor") %>'></asp:Label>
                                            <asp:Label Visible="false" ID="DNI_Conductor" runat="server" Text='<%# Eval("DNIConductor") %>'></asp:Label>
                                            <asp:Label Visible="false" ID="Transporte" runat="server" Text='<%# Eval("IDTransporte") %>'></asp:Label>
                                            <asp:Label Visible="false" ID="Item" runat="server" Text='<%# Eval("Item") %>'></asp:Label>
                                            <asp:Label Visible="false" ID="Al" runat="server" Text='<%# Eval("RO/AL") %>'></asp:Label>
                                            <asp:Label Visible="false" ID="Sol" runat="server" Text='<%# Eval("Solicitud") %>'></asp:Label>
                                            <%# Eval("Pies") %> <%# Eval("Tipo") %>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="center" />
                                         <HeaderStyle Width="80px" />
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha/Hora Cita">
                                        <ItemTemplate>
                                            <%# Eval("Fecha Cita") %> <%# Eval("Hora Cita") %>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="center" />
                                         <HeaderStyle Width="110px" />
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Empresa Transporte">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlEmpresaTransporte" onchange="cargarCombo(this);"  Width="150px" CssClass="form-control select2" runat="server" style="font-size: 11px !important; text-transform:uppercase;"></asp:DropDownList> 
                                            </ItemTemplate>                             
                                            <HeaderStyle Width="200px" />
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Conductor">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlConductor"  onchange="setValor(this);" Width="150px" runat="server" CssClass="form-control select2" style="font-size: 11px !important; text-transform:uppercase;"></asp:DropDownList> 
                                                <div style="display:none;">
                                                    <asp:TextBox ID="txtConductor" runat="server" Text='<%# Eval("IDConductor") %>'></asp:TextBox>
                                                </div>
                                               
                                            </ItemTemplate>                             
                                            <HeaderStyle Width="200px" />
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Unidad">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlUnidad" onchange="setValor(this);" Width="100px" runat="server" CssClass="form-control select2" Style="font-size: 11px !important; text-transform: uppercase;"></asp:DropDownList>
                                                <div style="display: none;">
                                                    <asp:TextBox ID="txtUnidad" runat="server" Text='<%# Eval("IDPlaca") %>'></asp:TextBox>
                                                </div>
                                               
                                            </ItemTemplate>                             
                                            <HeaderStyle Width="80px" />
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>                     

                        </div>
                    </div>
                </div>
            </div>
  


             
           
        </asp:View>

        <%--Vista de seguimiento transportes--%>
        <%--        <asp:View ID="View3" runat="server">
            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">
                        
                        <asp:GridView CssClass="table table-striped table-bordered grillascrollY" ID="GridView1" runat="server" OnPreRender="gvContenedoresContrans_PreRender" GridLines="None"
                            AutoGenerateColumns="False" EmptyDataText="No hay información">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <div class="checkbox checkbox-primary">
                                            <asp:CheckBox ID="chkSeleccionar" runat="server" Text="." />
                                            <asp:Label Visible="false" ID="lblContenedor" runat="server" Text='<%# Eval("CONTENEDOR") %>'></asp:Label>
                                            <asp:Label Visible="false" ID="lblTipo" runat="server" Text='<%# Bind("TIPO_CTN") %>'></asp:Label>
                                            <asp:Label Visible="false" ID="lblPies" runat="server" Text='<%# Bind("SIZE_CTN") %>'></asp:Label>


                                        </div>

                                    </ItemTemplate>
                                    <HeaderStyle Width="1px" CssClass="text-center" />
                                    <ItemStyle CssClass="text-center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="CONTENEDOR" HeaderText="Contenedor" />
                                <asp:BoundField DataField="SIZE_CTN" HeaderText="Size" />
                                <asp:BoundField DataField="TIPO_CTN" HeaderText="Tipo" />
                                
                                <asp:TemplateField HeaderText="Local">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle CssClass="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Local (2)">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle CssClass="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fch. Cita">
                                    <ItemTemplate>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                            <asp:TextBox AutoCompleteType="Disabled" placeholder="dd/mm/yyyy" data-provide="datepicker" CssClass="form-control datepickers" ID="TextBox1" runat="server"></asp:TextBox>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle CssClass="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hora Cita">
                                    <ItemTemplate>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                            <asp:TextBox AutoCompleteType="Disabled" placeholder="hh:mm" data-provide="timepicker" CssClass="form-control datepickers" ID="TextBox2" runat="server"></asp:TextBox>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle CssClass="center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </asp:View>--%>
        

    </asp:MultiView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[id*='chkMarcarTodos']").change(function (r) {
                //alert();
            });
            $(".select2").select2();
            // Initialize ajax autocomplete:
            if ($('input.autocomplete2').length > 0) {
                $("input.autocomplete2").each(function (key, input) {
                    var url = $(this).data("url");

                    $(input).autocomplete({
                        serviceUrl: url,
                        paramName: 'term',
                        dataType: 'json',
                        //type: 'POST',
                        minChars: 2,
                        lookupLimit: 20,
                        transformResult: function (response) {
                            return {
                                suggestions: $.map(response, function (dataItem) {
                                    return { value: dataItem.descripcion, data: dataItem.id };
                                })
                            };
                        },

                        lookupFilter: function (suggestion, originalQuery, queryLowerCase) {
                            var re = new RegExp('\\b' + $.Autocomplete.utils.escapeRegExChars(queryLowerCase), 'gi');
                            return re.test(suggestion.value);
                        },
                        onSelect: function (suggestion) {
                            $(input).parent().find("input[id*='_id_']").val(suggestion.data);
                            //alert($(input).parent().find("input[id*='_id_']").length);
                            //$("input[id*='" + $(input).attr("id") + "_id']").val(suggestion.data);
                        }
                    });

                });
            }
        });
         
        function cargarCombo(cboEmpresa) {
            var IDEmpresa = cboEmpresa.value;
            $(cboEmpresa).parent().parent().find("select[id*='ddlConductor']").html("<option selected value='0'>Cargando...</option>");
            $(cboEmpresa).parent().parent().find("select[id*='ddlUnidad']").html("<option selected value='0'>Cargando...</option>");
            $.ajax({
                url: 'Default.aspx/CargarChofer',
                type: "POST",
                data: "{'IDEmpresa' : " + IDEmpresa + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () {
                    //alert("Start!!! ");
                },
                success: function (response) {
                    //console.log(data.d); ddlUnidad
                    var choferList = $.parseJSON(response.d);
                    if (choferList != null) {
                        $(cboEmpresa).parent().parent().find("select[id*='ddlConductor']").html("");
                        for (var i = 0; i < choferList.length; i++) {
                            var chofer = choferList[i]; 
                            $(cboEmpresa).parent().parent().find("select[id*='ddlConductor']").append("<option value='" + chofer.id + "'>" + chofer.descripcion + "</option>");
                        }
                    }
                },
                failure: function (msg) { alert("Sorry!!! "); }
            });
            $.ajax({
                url: 'Default.aspx/CargarUnidad',
                type: "POST",
                data: "{'IDEmpresa' : " + IDEmpresa + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () {
                    //alert("Start!!! ");
                },
                success: function (response) {
                    //console.log(data.d); ddlUnidad
                    var choferList = $.parseJSON(response.d);
                    if (choferList != null) {
                        $(cboEmpresa).parent().parent().find("select[id*='ddlUnidad']").html("");
                        for (var i = 0; i < choferList.length; i++) {
                            var chofer = choferList[i];
                            $(cboEmpresa).parent().parent().find("select[id*='ddlUnidad']").append("<option value='" + chofer.id + "'>" + chofer.descripcion + "</option>");
                        }
                    }
                },
                failure: function (msg) { alert("Sorry!!! "); }
            });

        }

        function setValor(cboControl) {
            var valor = cboControl.value;
            $(cboControl).parent().find("input").val(valor);
        }
    </script>
    <%--<script type=”text/javascript”>
        $(document).ready(function() {
        $(‘#GVPlaneamiento′).stacktable();
        });
    </script>--%>

</asp:Content>

