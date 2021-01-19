<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Liquidacion.aspx.cs" Inherits="Modulos_Combustible_Liquidacion" %>

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
            font-size: 12px;
        }

        .table.table-bordered tbody th, table.table-bordered tbody td {
            border-left-width: 0;
            border-bottom-width: 0;
            font-size: 11px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Modulo de Liquidacion </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Inicio</a>
                    </li>
                    <li>
                        <a href="#">Combustible</a>
                    </li>
                    <li class="active">Liquidacion
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
                            <h4 class="m-t-0 header-title"><b>Liquidacion</b></h4>
                        </div>

                        <div class="panelOptions col-sm-6" style="text-align: right;">
                            <asp:LinkButton ID="lnkGenerar" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                runat="server" OnClick="lnkGenerar_Click" >
                   <i class="fa fa-plus m-r-5"></i> <span> Generar </span>  </asp:LinkButton>
                        </div>
                        <div class="clearfix"></div>
                        <asp:HiddenField ID="hdCisterna" runat="server" />
                        <asp:HiddenField ID="hfIdLiquidacion" runat="server" />
                        <asp:HiddenField ID="hfUsuario" runat="server" />
                        <asp:GridView ID="grvLiquidacion" runat="server" AutoGenerateColumns="False" OnPreRender="grvLiquidacion_PreRender"
                            CssClass="table table-striped table-bordered dataTable" GridLines="None" OnRowCommand="grvLiquidacion_RowCommand" >

                            <Columns>

                                <asp:BoundField DataField="id_liquidacion" HeaderText="Codigo"  Visible="false"/>
                                <asp:BoundField DataField="cod_empresa" HeaderText="Codigo empresa"  Visible="false"/>
                                <asp:BoundField DataField="nom_empresa" HeaderText="Razon social" />
                                <asp:BoundField DataField="cod_maquinaria" HeaderText="Codigo maquinaria" Visible="false"/>
                                <asp:BoundField DataField="maquinaria" HeaderText="Tipo Maquinaria" />
                                <asp:BoundField DataField="cant" HeaderText="Cantidad Abastecimiento" ItemStyle-Width="20px" />
                                <asp:BoundField DataField="consumo_gl" HeaderText="Consumo (Gl.)" />
                                <asp:BoundField DataField="consumo" HeaderText="Consumo S/." />
                                <asp:BoundField DataField="fch_liquidacion_inicio" HeaderText="Fecha Inicio" />
                                <asp:BoundField DataField="fch_liquidacion_fin" HeaderText="Fecha Fin" />
                                <asp:BoundField DataField="fch_registro" HeaderText="Fecha registro" />
                                <asp:BoundField DataField="usuario" HeaderText="Usuario" />


                                <asp:TemplateField ItemStyle-Width="20px">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnModificar" CommandArgument='<%#Eval("id_liquidacion")+";"+Eval("fch_liquidacion_inicio")+";"+Eval("fch_liquidacion_fin")+";"+Eval("cod_empresa")+";"+Eval("nom_empresa")+";"+Eval("cod_maquinaria")+";"+Eval("maquinaria")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5"   runat="server" CommandName="Modificar"><i class="fa fa-pencil-square-o" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval("id_liquidacion")%>' CssClass="btn btn-danger waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="eliminar"><i class="fa fa-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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

            <div class="card-box table-responsive">

            <div class="form-group col-lg-2">
                    <label for="userName">Cliente </label>
                    <asp:DropDownList required CssClass="form-control" ID="ddlCliente" runat="server" Enabled="false" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>

            <div class="form-group col-lg-2">
                    <label for="userName">Tipo Vehiculo </label>
                    <asp:DropDownList required CssClass="form-control" ID="ddlTipoVehiculo" runat="server" Enabled="false" OnSelectedIndexChanged="ddlTipoVehiculo_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>

                        <div class="col-sm-2 m-t-5">
                <asp:Label  ID="Label2" runat="server" CssClass="m-t-5" ForeColor="#000000" Visible="true">Fecha Inicio:</asp:Label>
                <div class="input-group">
                    <span class="input-group-addon">
                        <span class="fa fa-calendar-check-o"></span>
                    </span>
                    <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control" ID="txtfchInicio" runat="server" Enabled="false" OnTextChanged="txtfchInicio_TextChanged" AutoPostBack="true"></asp:TextBox>
                </div>
            </div>

            <div class="col-sm-2 m-t-5">
                <asp:Label  ID="Label1" runat="server" CssClass="m-t-5" ForeColor="#000000" Visible="true">Fecha Fin:</asp:Label>
                <div class="input-group">
                    <span class="input-group-addon">
                        <span class="fa fa-calendar-check-o"></span>
                    </span>
                    <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control" ID="txtfchFin" runat="server" Enabled="false" OnTextChanged="txtfchFin_TextChanged" AutoPostBack="true"></asp:TextBox>
                </div>
            </div>

            <div class="panelOptions col-sm-4" style="text-align: right;">

                <asp:LinkButton ID="btnRegresar" CssClass="btn btn-default waves-effect waves-light m-b-5 m-t-20" runat="server" OnClick="btnRegresar_Click" >
                        <span>Regresar</span>
                     </asp:LinkButton>

                   <asp:LinkButton ID="lnkBuscar" CssClass="btn btn-info waves-effect waves-light m-b-5 m-t-20"
                    runat="server" OnClick="lnkBuscar_Click">
                   <i class="fa fa-search m-r-5"></i> <span> Buscar </span>  </asp:LinkButton>

            <asp:LinkButton ID="lnkGuardar" CssClass="btn btn-info waves-effect waves-light m-b-5 m-t-20"
                    runat="server" OnClick="lnkGuardar_Click">
                   <i class="fa fa-save m-r-5"></i> <span> Guardar </span>  </asp:LinkButton>

                

                        </div>
                </div>
            
            <div class="card-box table-responsive">

            <asp:GridView ID="gvDetalleMod" runat="server" AutoGenerateColumns="False" OnPreRender="gvDetalleMod_PreRender" OnRowCommand="gvDetalleMod_RowCommand"
                    CssClass="table table-striped table-bordered dataTable" GridLines="None">

                    <Columns>
                        <asp:BoundField  DataField="id_abastecimiento" HeaderText="Codigo" Visible="false" />
                        <asp:BoundField DataField="nro_despacho" HeaderText="Nro.Despacho" />
                        <asp:BoundField DataField="nom_empresa" HeaderText="Cliente" />
                        <asp:BoundField DataField="fecha_registro" HeaderText="Fecha" />
                        <asp:BoundField DataField="cod_unidad" HeaderText="Tipo Vehículo" />
                        <asp:BoundField DataField="unidad" HeaderText="Unidad" />
                        <asp:BoundField DataField="nro_placa" HeaderText="Placa" />
                        <asp:BoundField DataField="cnt_inicial" HeaderText="Cnt. Inicial" />
                        <asp:BoundField DataField="cnt_final" HeaderText="Cnt. Final" />
                        <asp:BoundField DataField="km_unidad" HeaderText="KM." />
                        <asp:BoundField DataField="horometro" HeaderText="Horometro" />
                        <asp:BoundField DataField="cantidad_gl" HeaderText="Cantidad(Gl.)" />
                        <asp:BoundField DataField="nom_conductor" HeaderText="Conductor" />
                        <asp:BoundField DataField="precio_galon_igv" HeaderText="Precio"  DataFormatString="{0:c}" />
                        <asp:BoundField DataField="total_venta" HeaderText="Total(S/.)"  DataFormatString="{0:c}" />
                        <asp:TemplateField ItemStyle-Width="20px">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval("id_abastecimiento")%>' CssClass="btn btn-danger waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="eliminar"><i class="fa fa-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                    </Columns>

                </asp:GridView>

            <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" OnPreRender="gvDetalle_PreRender"
                    CssClass="table table-striped table-bordered dataTable" GridLines="None">

                    <Columns>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkLiquidacionALL" runat="server" EnableViewState="true" OnCheckedChanged="chkLiquidacionALL_CheckedChanged"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td style="padding: 0 2px;">
                                            <asp:CheckBox ID="chkLiquidacion" runat="server" EnableViewState="true"/>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField  DataField="id_abastecimiento" HeaderText="Codigo" Visible="true" />
                        <asp:BoundField DataField="nro_despacho" HeaderText="Nro.Despacho" />
                        <asp:BoundField DataField="nom_empresa" HeaderText="Cliente" />
                        <asp:BoundField DataField="fecha_registro" HeaderText="Fecha" />
                        <asp:BoundField DataField="cod_unidad" HeaderText="Tipo Vehículo" />
                        <asp:BoundField DataField="unidad" HeaderText="Unidad" />
                        <asp:BoundField DataField="nro_placa" HeaderText="Placa" />
                        <asp:BoundField DataField="cnt_inicial" HeaderText="Cnt. Inicial" />
                        <asp:BoundField DataField="cnt_final" HeaderText="Cnt. Final" />
                        <asp:BoundField DataField="km_unidad" HeaderText="KM." />
                        <asp:BoundField DataField="horometro" HeaderText="Horometro" />
                        <asp:BoundField DataField="cantidad_gl" HeaderText="Cantidad(Gl.)" />
                        <asp:BoundField DataField="nom_conductor" HeaderText="Conductor" />
                        <asp:BoundField DataField="precio_galon_igv" HeaderText="Precio"  DataFormatString="{0:c}" />
                        <asp:BoundField DataField="total_venta" HeaderText="Total(S/.)"  DataFormatString="{0:c}" />

                      <%--  <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:Label ID="lblFactura" runat="server" Text='<%# Eval("estado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="nro_factura" HeaderText="Nro. Factura" />--%>

                    </Columns>

                </asp:GridView>

                </div>



        </asp:View>

    </asp:MultiView>

    <div id="ModalDelete" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">×</span>
                            <span class="sr-only">Cerrar</span>
                            </button>
                        </div>
                        <asp:HiddenField runat="server" ID="hfEliminarLiqui" />
                        <asp:HiddenField runat="server" ID="hfEliminarDetalle" />
                        <div class="modal-body">
                            <div class="text-center">
                                <span class="text-danger icon icon-times-circle icon-5x"></span>
                                    <h3 class="text-danger">¿Desea eliminar la Liquidacion?</h3>
                                    <p>Debe estar seguro antes de eliminar información del sistema</p>
                                    <div class="m-t-lg">
                                        <asp:LinkButton ID="btnEliminar" CssClass="btn btn-danger" runat="server" OnClick="btnEliminar_Click" ><i class="fa m-r-5"></i> <span>   Eliminar</span>  </asp:LinkButton>
                                        <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                    </div>
                             </div>

                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script type="text/javascript">
        function round(value, exp) {
            if (typeof exp === 'undefined' || +exp === 0)
                return Math.round(value);

            value = +value;
            exp = +exp;

            if (isNaN(value) || !(typeof exp === 'number' && exp % 1 === 0))
                return NaN;

            // Shift
            value = value.toString().split('e');
            value = Math.round(+(value[0] + 'e' + (value[1] ? (+value[1] + exp) : exp)));

            // Shift back
            value = value.toString().split('e');
            return +(value[0] + 'e' + (value[1] ? (+value[1] - exp) : -exp));
        }

        $(document).ready(function () {

            $("input[id*='txtCapacidad'], input[id*='txtPrecioCompra']").change(function () {
                $("input[id*='txtTotalCarga']").val();
                $("input[id*='txtTotalCargaIGV']").val();
                var valor1 = $("input[id*='txtCapacidad']").val();
                var valor2 = $("input[id*='txtPrecioCompra']").val();
                var valor3 = parseFloat(valor1) * parseFloat(valor2);
                var valor4 = parseFloat(valor3) * 1.18;
                if (valor3 != null && !isNaN(valor3))
                    $("input[id*='txtTotalCarga']").val(round(valor3, 2));
                if (valor4 != null && !isNaN(valor4))
                    $("input[id*='txtTotalCargaIGV']").val(round(valor4,2));
            });


            $("input[id*='txtcntInicial'], input[id*='txtcntFinal']").change(function () {
                $("input[id*='txtcntInicial']").val();
                $("input[id*='txtcntFinal']").val();
                var valor1 = $("input[id*='txtcntInicial']").val();
                var valor2 = $("input[id*='txtcntFinal']").val();
                var valor3 = parseFloat(valor2) - parseFloat(valor1);                
                if (valor3 != null && !isNaN(valor3))
                    $("input[id*='txtGl']").val(round(valor3, 2));
                
            });


        });

    </script>

</asp:Content>

