<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="DefaultMonitoreo.aspx.cs" Inherits="Modulos_TMS_DefaultMonitoreo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    
 
     <script type="text/javascript" src="../../App_Themes/zircos/default/assets/plugins/datatables/gridviewscroll.js"></script>
    <script type="text/javascript">
        var gridViewScroll = null;
        $(document).ready(function () {
            $('table.juanjo tr').addClass('GridViewScrollItem');
            $('table.juanjo tr').eq(0).addClass('GridViewScrollHeader');
            //var ancho = $('div.container').width();
            var ancho = $('body').width();
            var ancho_menu = $('div.side-menu').width();
            ancho = ancho - ancho_menu;
            var idgrid = $('table.juanjo').attr("id");
            gridViewScroll = new GridViewScroll({
                elementID: idgrid,
                width: ancho,
                height: 350,
                freezeColumn: true,
                freezeFooter: false,
                freezeColumnCssClass: "GridViewScrollItemFreeze",
                //reezeFooterCssClass: "GridViewScrollFooterFreeze",
                freezeHeaderRowCount: 1,
                freezeColumnCount: 4
                //onscroll: function (scrollTop, scrollLeft) {
                //    console.log(scrollTop + " - " + scrollLeft);
                //}
            });
            gridViewScroll.enhance();
        });
    </script>

    <style type="text/css"> 
    .dropdown-menu>li>a{
        padding-left:10px;
    }

        .GridViewScrollItemFreeze TD {
            padding: 8px;
            white-space: nowrap;
            border-right: 1px solid #e6e6e6;
            border-bottom: 1px solid #e6e6e6;
            background-color: #FAFAFA;
            color: #444444;
        }

        .GridViewScrollHeader TH, .GridViewScrollHeader TD {
            padding: 6px 2.2px;
            font-weight: normal;
            white-space: nowrap;
            border-right: 1px solid #e6e6e6;
            border-bottom: 1px solid #e6e6e6;
            background-color: #F4F4F4;
            color: #999999;
            text-align: left;
            vertical-align: bottom;
        }
    </style>

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
                            $("input[id*='txtPrefijo']").val(dato.substring(0,4));
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
             
            validarInputHoras();
            $('.panelHora input[type=text]').each(function (a, e) {
                $(this).change(function () {
                    //alert($(this).attr("id"));
                    validarInputHoras();
                });
            });
        });
        function validarInputHoras() {
            $(".panelHora input[type=text]").attr("disabled", "disabled");
            var tope = 0;
            $('.panelHora').each(function (a, e) {
                if ($('.panelHora').eq(a).find("input[type=text]").eq(0).val() != "" && $('.panelHora').eq(a).find("input[type=text]").eq(1).val() != "") {
                    $('.panelHora').eq(a).find("input[type=text]").removeAttr("disabled");
                    tope = a + 1;
                }
                else {
                    if (tope == a)
                        $('.panelHora').eq(a).find("input[type=text]").removeAttr("disabled");
                    else {

                    }
                }
                //alert($('.panelHora').eq(a).find("input[type=text]").eq(0).val());
                //alert($('.panelHora').eq(a).find("input[type=text]").eq(1).val());
                // ($('.panelHora').eq(a).find("input[type=text]").val() == "")
            });

            if (tope == 0)
                $('.panelHora').eq(0).find("input[type=text]").removeAttr("disabled");
        }
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

     $(function() {

         //===== Form validation engine =====//
         //$("form").validationEngine();
         //===== UI dialog =====//           

         $("input[id*='chkCargaSuelta']").click(function(event) {
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
    <style type="text/css">
       
        #ContentPlaceHolder1_GVDetalleSolicitud_filter,
        #ctl00_ContentPlaceHolder1_GVDetalleSolicitud_filter,
        #ctl00_ContentPlaceHolder1_gvContenedoresContrans_filter,
        #ContentPlaceHolder1_gvContenedoresContrans_filter
        {
          
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
        #ContentPlaceHolder1_GVDetalleSolicitud_wrapper .dataTables_paginate ,
        #ContentPlaceHolder1_gvContenedoresContrans_filter
        {
           display:none;
        }

        @media (min-width: 768px){
            .modal-sm{
                width:360px !important;
            }
        }
        .panel-default .panel-heading{
            padding:10px 20px !important;
        }
        .form-control{
            font-size:12px !important;
        }
          .tab-content > .tab-pane {
            display: block;
        }
        .table .checkbox label{            
            padding: 0px;
            width: 0px;
            color: transparent;
        }

        .table>tbody>tr>td, .table>tbody>tr>th, .table>tfoot>tr>td, .table>tfoot>tr>th, .table>thead>tr>td, .table>thead>tr>th{
            vertical-align:middle !important;
        }
        .dataTables_scrollFootInner table{
            margin-bottom:0px !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Monitoreo de Servicios
                </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Monitoreo</a>
                    </li>
                    <li class="active">Seguimiento
                    </li>
                </ol>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <div class="row">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <asp:HiddenField ID="lblMensaje" runat="server"/>
                                <div class="col-lg-2">
                                    <h4 class="header-title">Filtros de busqueda</h4>
                                </div>

                                <div class="col-lg-10 text-right">
                                    <asp:LinkButton ID="btnFiltrarSolicitudes" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnFiltrarSolicitudes_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-search"></i> Buscar
                                    </asp:LinkButton> 

                                     <%--<asp:LinkButton ID="btnAgregarSolicitud" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnAgregarSolicitud_Click">
                                        <i class="glyphicon glyphicon-plus"></i> Agregar Solicitud
                                    </asp:LinkButton> --%>
                                    <%--<asp:LinkButton ID="btnAnularSolicitud" runat="server" CssClass="btn btn-danger btn-sm" OnClientClick="JConfirm('¿Esta seguro de anular las solicitudes?','Confirmar Acción', this); return false;" OnClick="btnAnularSolicitud_Click">
                                        <i class="glyphicon glyphicon-trash"></i> Anular Solicitud
                                    </asp:LinkButton> --%>

                                    <%--<asp:LinkButton ID="btnProgramacion" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnProgramacion_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-road"></i> Programación
                                    </asp:LinkButton> --%>
                                    
                                    <asp:LinkButton ID="btnExportar" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnExportar_Click" >
                                        <i class="glyphicon glyphicon-save-file m-r-5"></i> Exportar
                                    </asp:LinkButton> 

                                    <asp:LinkButton ID="btnAgregarSeguimiento" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnAgregarSeguimiento_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-time"></i> Seguimiento
                                    </asp:LinkButton> 

                                    <%-- <asp:LinkButton ID="btnFacturacion" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnAgregarSeguimiento_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-check"></i> Facturación
                                    </asp:LinkButton> --%>
                                    
                                      
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
                                   <%-- Estado--%>
                                    Contenedor
                                </div>
                                <div class="col-md-2">
                                  <asp:DropDownList style="display:none;" CssClass="form-control" ID="ddlEstadoFiltro" runat="server">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtContenedorFiltro" CssClass="form-control" runat="server"></asp:TextBox>
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
                                    Choferes
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlChoferesWS" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="lblentidad0" runat="server"/>

            <div class="table-responsive1" style="margin-top: 10px;">
                <asp:GridView ID="GVPlaneamiento" runat="server" cssclass="table table-striped table-bordered juanjo" gridlines="None" AutoGenerateColumns="False" 
                    EmptyDataText="No se encontraron resultados" OnPreRender="GVPlaneamiento_PreRender" >
                        
                        <Columns>
                         
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="checkbox checkbox-primary">
                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="." />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TIPO/SOL">
                                <ItemTemplate>
                                    <asp:Label ID="lblTipoSol" runat="server" CssClass="text2" Text='<%# Eval("TS_Des") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RO/AL">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemROAL" runat="server" CssClass="text2" Text='<%# Eval("ROS_KRO") %>'></asp:Label>
                                    <asp:Label ID="lblKItem" runat="server" Text='<%# Eval("ROS_Kitem") %>'
                                                Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FECHA CITA">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaCita" runat="server" Text='<%# Eval("FechaCita") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="HoraCita" HeaderText="Hora Cita" />   
                            <asp:BoundField DataField="EMP_CREACION" HeaderText="CLIENTE" />
                            <asp:TemplateField HeaderText="Cod_Emp_Cre" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblcliencod" runat="server" Text='<%# Eval("Cod_Emp_Cre") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="Cod_Emp_Cre" HeaderText="Cod_Emp_Cre" Visible="false" />--%>
                             
                            <asp:TemplateField HeaderText="SUB CLIENTE">
                                <ItemTemplate>
                                    <asp:Label ID="lblcliente" runat="server" Text='<%# Eval("Ent_Rsoc") %>'></asp:Label>
                                    <asp:Label ID="lblsubcliencod" runat="server" Text='<%# Eval("Cod_Ent") %>' 
                                        Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MOVIMIENTO">
                                <ItemTemplate>
                                    <asp:Label ID="lblMovimiento" runat="server" Text='<%# Eval("Tgc_Desc") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="Tgc_Desc" HeaderText="MOVIMIENTO" />--%>
                            <asp:TemplateField HeaderText="CONTENEDOR">
                                <ItemTemplate>
                                    <asp:Label ID="lblContenedor" runat="server" Text='<%# Eval("ROS_Contenedor") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="Contenedor" HeaderText="Contenedor" />--%>
                            <asp:BoundField DataField="Conductor" HeaderText="CONDUCTOR" />
                            <asp:BoundField DataField="UNIDAD_PLACA" HeaderText="UNIDAD" />
                            <asp:TemplateField HeaderText="SOLICITUD" Visible="false">
                                <ItemTemplate>                                                
                                        <asp:LinkButton ID="hplSolicitud" CommandName="Editar" CommandArgument='<%# Convert.ToString(Eval("ROS_Kitem")) + "|" + Convert.ToString(Eval("ROS_KRO")) + "|" + Convert.ToString(Eval("TS_DES")) %>' Text='<%# Eval("ROS_Kitem") %>'  runat="server"></asp:LinkButton>
                                        <asp:LinkButton ID="lkSolDistrib" CommandName="select" Text='<%# Eval("ROS_Kitem") %>' Visible="false"  runat="server"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle CssClass="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ITEM" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblItem" runat="server" Text='<%# Eval("ROS_Item") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="ROS_Item" HeaderText="Item" ItemStyle-CssClass="center" Visible="false"/>    --%>
                            <%--<asp:BoundField DataField="ROS_KRO" HeaderText="RO/AL" ItemStyle-CssClass="center" />    --%>
                            <asp:BoundField DataField="EstadoSegui" HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderText="ESTADO" Visible="false" />
                            <asp:BoundField DataField="Tracking" HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderText="ESTADO" />
                            <asp:BoundField DataField="ROS_Ucre" HeaderText="USUARIO CREACION" />
                            <asp:BoundField DataField="ROS_Fcre" HeaderText="FECHA CREACION" DataFormatString="{0:d}" />
                            
                            <asp:TemplateField HeaderText="PIES" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemPies" runat="server" Text='<%# Eval("ROS_Tipo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>

                            <%--<asp:BoundField DataField="Cantidad" HeaderText="CANT. CONT." ItemStyle-CssClass="center" />--%>
              
                            
                         
                        </Columns>
                    </asp:GridView>
            </div>
        </asp:View>
    </asp:MultiView>


    <div id="modalAsignacion" class="modal fade" tabindex="-1" role="dialog" style="display: none;">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-lg-6">
                            Contenedor:
                                            <asp:Label ID="lblTittle" runat="server"></asp:Label>
                        </div>
                        <div class="col-lg-6 text-right">
                            <asp:LinkButton class="btn btn-primary btn-sm" ID="btnGuardarAsignacion" OnClick="btnGuardarAsignacion_Click" runat="server"><i class="glyphicon glyphicon-check"></i> Actualizar información</asp:LinkButton>
                            <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-close"></i>Cerrar</button>
                        </div>
                    </div>

                    <%-- <button type="button" class="close" data-dismiss="modal">
                                                <span aria-hidden="true">×</span>
                                                <span class="sr-only">Cerrar</span>
                                            </button>--%>
                </div>
                <div class="modal-body" style="padding-bottom: 0px;">
                    <div class="row">
                        <asp:HiddenField ID="hfTSol" runat="server" />
                        <asp:HiddenField ID="hfTipSol" runat="server" />
                        <asp:HiddenField ID="hfEnt1" runat="server" />
                        <asp:HiddenField ID="hfEnt2" runat="server" />
                        <asp:HiddenField ID="hfsol" runat="server" />
                        <asp:HiddenField ID="hfSoli" runat="server" />
                        <asp:HiddenField ID="hfFechaSoli" runat="server" />
                        <asp:HiddenField ID="hfHoraSoli" runat="server" />
                        <asp:HiddenField ID="hfEvento" runat="server" />
                        <asp:HiddenField ID="hfAL" runat="server" />
                        <asp:HiddenField ID="hfContenedor" runat="server" />
                        <asp:HiddenField ID="hfMovimiento" runat="server" />
                        <asp:HiddenField ID="hfAction" runat="server" />
                        <div class="col-md-4" style="padding-right: 20px;">
                            <div class="card-box" style="padding: 0px; border: none;">
                                <div class="card-header bg-light">
                                    <h4 class="card-title panel-title">Terminal de Retiro</h4>
                                </div>
                                <div class="card-body" style="padding-top: 15px;">

                                    <div class="form-group">
                                        <asp:Label runat="server">Terminal</asp:Label>
                                        <asp:DropDownList runat="server" ID="ddlTerminalRetiro" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">

                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:Label runat="server">Llegada</asp:Label>
                                            </div>
                                            <div class="col-md-5">
                                                <asp:TextBox runat="server" ID="dtpRetiroLlegadaFecha" CssClass="datepicker form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox AutoCompleteType="Disabled" placeholder="Hora" CssClass="form-control " ID="txtRetiroLlegadaHora" runat="server" data-toggle="input-mask" data-mask-format="00:00" MaxLength="5"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3">
                                                Ingreso
                                            </div>

                                            <div class="col-md-5">
                                                <asp:TextBox runat="server" ID="dtpRetiroIngresoFecha" CssClass="datepicker form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtRetiroIngresoHora" placeholder="Hora" CssClass="form-control" data-toggle="input-mask" data-mask-format="00:00" MaxLength="5"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3">
                                                Salida
                                            </div>

                                            <div class="col-md-5">
                                                <asp:TextBox runat="server" ID="dtpRetiroSalidaFecha" CssClass="datepicker form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtRetiroSalidaHora" placeholder="Hora" CssClass="form-control" data-toggle="input-mask" data-mask-format="00:00:00" MaxLength="8"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server">Observación</asp:Label>
                                        <asp:TextBox runat="server" ID="txtRetiroObservacion" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                            </div>


                        </div>

                        <div class="col-md-4" style="padding: 0px;">
                            <div class="card-box" style="padding: 0px 20px; border-top: none; border-bottom: none; border-radius: 0px; margin-bottom: 0px; padding-bottom: 10px;">
                                <div class="card-header bg-light">
                                    <h4 class="card-title panel-title">Cliente</h4>
                                </div>
                                <div class="card-body" style="padding-top: 15px;">

                                    <div class="form-group">
                                        <asp:Label runat="server">Local</asp:Label>
                                        <asp:DropDownList runat="server" ID="ddlClienteLocal" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3">
                                                Llegada
                                            </div>
                                            <div class="col-md-5">
                                                <asp:TextBox runat="server" ID="dtpClienteLlegadaFecha" CssClass="datepicker form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtClienteLlegadaHora" CssClass="form-control" placeholder="Hora" data-toggle="input-mask" data-mask-format="00:00" MaxLength="5"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3">
                                                Ingreso
                                            </div>
                                            <div class="col-md-5">
                                                <asp:TextBox runat="server" ID="dtpClienteIngresoFecha" CssClass="datepicker form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtClienteIngresoHora" CssClass="form-control" placeholder="Hora" data-toggle="input-mask" data-mask-format="00:00" MaxLength="5"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3">
                                                Inicio
                                            </div>
                                            <div class="col-md-5">
                                                <asp:TextBox runat="server" ID="dtpClienteInicioFecha" CssClass="datepicker form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtClienteInicioHora" placeholder="Hora" CssClass="form-control " data-toggle="input-mask" data-mask-format="00:00" MaxLength="5"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3">
                                                Termino
                                            </div>
                                            <div class="col-md-5">
                                                <asp:TextBox runat="server" ID="dtpClienteTerminoFecha" CssClass="datepicker form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtClienteTerminoHora" placeholder="Hora" CssClass="form-control " data-toggle="input-mask" data-mask-format="00:00" MaxLength="5"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3">
                                                Salida
                                            </div>
                                            <div class="col-md-5">
                                                <asp:TextBox runat="server" ID="dtpClienteSalidaFecha" CssClass="datepicker form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtClienteSalidaHora" placeholder="Hora" CssClass="form-control " data-toggle="input-mask" data-mask-format="00:00" MaxLength="5"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server">Observación</asp:Label>
                                        <asp:TextBox runat="server" ID="txtClienteObservacion" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding-left: 20px;">
                            <div class="card-box" style="padding: 0px; border: none;">
                                <div class="card-header bg-light">
                                    <h4 class="card-title panel-title">Terminal de Devolución</h4>
                                </div>
                                <div class="card-body" style="padding-top: 15px;">

                                    <div class="form-group">
                                        <asp:Label runat="server">Terminal</asp:Label>
                                        <asp:DropDownList runat="server" ID="ddlTerminalDevolucion" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3">
                                                Llegada
                                            </div>
                                            <div class="col-md-5">
                                                <asp:TextBox runat="server" ID="dtpDevolucionLlegadaFecha" CssClass="datepicker form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtDevolucionLlegadaHora" placeholder="Hora" CssClass="form-control " data-toggle="input-mask" data-mask-format="00:00" MaxLength="5"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3">
                                                Ingreso
                                            </div>
                                            <div class="col-md-5">
                                                <asp:TextBox runat="server" ID="dtpDevolucionIngresoFecha" CssClass="datepicker form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtDevolucionIngresoHora" placeholder="Hora" CssClass="form-control " data-toggle="input-mask" data-mask-format="00:00" MaxLength="5"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3">
                                                Salida
                                            </div>
                                            <div class="col-md-5">
                                                <asp:TextBox runat="server" ID="dtpDevolucionSalidaFecha" CssClass="datepicker form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtDevolucionSalidaHora" placeholder="Hora" CssClass="form-control " data-toggle="input-mask" data-mask-format="00:00" MaxLength="5"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="checkbox checkbox-primary">
                                            <asp:CheckBox runat="server" ID="chkNoDevolucion" Text="No hay devolución" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server">Observación</asp:Label>
                                        <asp:TextBox runat="server" ID="txtObservacionDevolucion" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="row" title="Más Información" style="padding-top: 20px; border-top: 2px solid #f3f3f3;">
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label runat="server">Empresa</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlEmpresaInfo" CssClass="form-control" OnSelectedIndexChanged="ddlEmpresaInfo_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server">Kilometraje</asp:Label>
                                <asp:TextBox runat="server" ID="txtKmInicialInfo" CssClass="form-control">Inicial</asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server">Precinto Linea</asp:Label>
                                <asp:TextBox runat="server" ID="txtPrecintoLineaInfo" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <div class="checkbox checkbox-primary">
                                    <asp:CheckBox runat="server" Checked="true" ID="chkEnviarCorreoInfo" Text="Enviar Correo" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label runat="server">Unidad</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlUnidadInfo" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server">Kilometraje</asp:Label>
                                <asp:TextBox runat="server" ID="txtKmFinalInfo" CssClass="form-control">Final</asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server">Precinto Aduana</asp:Label>
                                <asp:TextBox runat="server" ID="txtPrecintoAduanaInfo" CssClass="form-control"></asp:TextBox>
                            </div>
                            <%--<div class="form-group">
                                                        <asp:Label runat="server" >Doble Carga</asp:Label>
                                                        <asp:CheckBox runat="server" Checked="false" ID="chkDobleCargaInfo"/>
                                                    </div>--%>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label runat="server">Chofer</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlChoferInfo" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server">Precinto CTN Vacío</asp:Label>
                                <asp:TextBox runat="server" ID="txtPrecintoVacioInfo" CssClass="form-control">Inicial</asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server">Precinto Tránsito</asp:Label>
                                <asp:TextBox runat="server" ID="txtPrecintoTransitoInfo" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">

                                <div class="checkbox checkbox-primary">
                                    <asp:CheckBox runat="server" ID="chkPernocteInfo" Checked="false" Text="Pernocte" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>