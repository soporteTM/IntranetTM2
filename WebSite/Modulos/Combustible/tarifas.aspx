<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="tarifas.aspx.cs" Inherits="Modulos_Combustible_tarifas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Modulo de Gestion de Unidades </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Inicio</a>
                    </li>
                    <li>
                        <a href="#">Combustible</a>
                    </li>
                    <li class="active">Tarifas
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
                            <h4 class="m-t-0 header-title"><b>Tarifas</b></h4>
                            <p class="text-muted font-13 m-b-30">
                                Registro y consulta de tarifas de combustible. 
                            </p>
                        </div>

                        <div class="panelOptions col-sm-6" style="text-align: right;">
                            <asp:LinkButton ID="lnkTarifa" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                runat="server" OnClick="lnkTarifa_Click">
                   <i class="fa fa-plus m-r-5"></i> <span> Agregar </span>  </asp:LinkButton>
                        </div>
                        <div class="clearfix"></div>
                        <asp:HiddenField ID="hdCisterna" runat="server" />
                        <asp:GridView ID="gvTarifas" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvTarifas_PreRender" >

                            <Columns>

                                <asp:BoundField Visible="false" DataField="id_cliente" HeaderText="Codigo" />
                                <asp:BoundField DataField="nom_empresa" HeaderText="Cliente" />
                                <asp:BoundField DataField="precio_tarifa_no_igv" HeaderText="Precio" DataFormatString="{0:c}" />
                                <asp:BoundField DataField="precio_tarifa_igv" HeaderText="Precio(IGV)." DataFormatString="{0:c}" />
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

                            <h4 class="modal-title">Registro de Tarifa</h4>

                        </div>
                        <div class="modal-body">
                            <div class="text">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                 <div class="form-group col-lg-12">

                                    <label for="name-1" class="control-label"> Cliente </label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-file-excel-o"></span>
                                        </span>
                                        <asp:DropDownList required CssClass="form-control" ID="ddlCliente" runat="server">
                                    </asp:DropDownList>
                                    </div>

                                </div>
                                

                                <div class="form-group col-lg-6">

                                    <label for="name-1" class="control-label">Precio Venta</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="mdi mdi-battery"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" placeholder="Ingrese Precio Venta" CssClass="form-control" ID="txtVenta" runat="server"></asp:TextBox>

                                    </div>

                                </div>

                                <div class="form-group col-lg-6">

                                    <label for="name-1" class="control-label">Precio Venta(IGV.)</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="mdi mdi-battery-20"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" placeholder="Ingrese Precio Venta + IGV" CssClass="form-control" ID="txtVentaIGV" runat="server"></asp:TextBox>

                                    </div>

                                </div>

                                <div class="m-t-lg text-right">
                                    <asp:LinkButton ID="lnkRegistrar" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                        runat="server" OnClick="lnkRegistrar_Click">
                   <i class="fa fa-save m-r-5"></i> <span>Procesar</span>  </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>

        </asp:View>
        </asp:MultiView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">

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

            $("input[id*='txtVenta']").change(function () {
                $("input[id*='txtVentaIGV']").val();
                var valor1 = $("input[id*='txtVenta']").val();
                var valor2 = parseFloat(valor1) * 1.18;
                if (valor2 != null && !isNaN(valor2))
                    $("input[id*='txtVentaIGV']").val(round(valor2, 2));
               
            });

        });
        </script>
</asp:Content>

