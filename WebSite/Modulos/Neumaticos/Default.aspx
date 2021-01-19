<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modulos_Neumaticos_Default" %>

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
            left: 650px;
            width: 80px;
        }

        .S2_pos12 {
            position: absolute;
            top: 40px;
            left: 650px;
            width: 80px;
        }

        .S2_pos13 {
            position: absolute;
            top: 130px;
            left: 650px;
            width: 80px;
        }

        .S2_pos14 {
            position: absolute;
            top: 155px;
            left: 650px;
            width: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField runat="server" ID="hfPos" />
    <asp:HiddenField runat="server" ID="hfAccion" />
    <asp:HiddenField runat="server" ID="hfUsuario" />
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
                    <li class="active">Registro de Neumaticos
                    </li>
                </ol>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
        <div class="row">
            <div class="col-lg-8">
                <div class="header-title">

                    <table width="100%" border="0">
                        <tr>
                            <td style="width: 100px;">Nro Placa</td>
                            <td>
                                <asp:TextBox placeholder="Ingresar la placa" CssClass="form-control autocomplete" data-url="BuscarUnidad.ashx" ID="txtUnidad" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtUnidad_id" runat="server" class="form-control" Style="color: #CCC; background: transparent; z-index: 1; display: none;"></asp:TextBox>
                            </td>
                        </tr>
                    </table>


                </div>
            </div>

            <div class="col-lg-4" style="text-align: right;">

                <asp:Button ID="btnBuscarPlaca" CssClass="btn btn-primary " runat="server" Text="Buscar" UseSubmitBehavior="False" OnClick="btnBuscarPlaca_Click" />

                <asp:HiddenField ID="HFEmpleadoDocumento" runat="server" Value="0" />
            </div>
            <div class="clearfix"></div>
        </div>

    </div>
    </div>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

        <asp:View ID="View1" runat="server">
            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">

                        <div class="panelOptions col-sm-6" style="text-align: right;">
                        </div>
                        <div class="clearfix"></div>
                        <br />
                        <br />
                        <div class="row">
                            <div class="col-lg-8">
                                <h4 class="header-title m-t-0">Asignación de Neumaticos</h4>
                                <p class="text-muted font-13 m-b-10">
                                    Asigna los neumaticos a la unidad segun la posicion.
                                </p>
                            </div>

                            <div class="form-group col-lg-12">
                                <div class="property-card">
                                    <div id="div_image" runat="server" class="property-image" style="height: 200px; margin: auto; background: url('../../App_Themes/zircos/default/assets/images/unit/S0.png') center center no-repeat; width:1050px;">
                                                                                
                                        <asp:LinkButton Visible="false" runat="server" ID="lbl0" Text="Pos 1" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos2" OnClick="lbl0_Click"></asp:LinkButton>
                                        <asp:LinkButton Visible="false" runat="server" ID="lbl1" Text="Pos 2" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos1" OnClick="lbl1_Click"></asp:LinkButton>
                                        <asp:LinkButton Visible="false" runat="server" ID="lbl2" Text="Pos 3" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos6" OnClick="lbl2_Click"></asp:LinkButton>
                                        <asp:LinkButton Visible="false" runat="server" ID="lbl3" Text="Pos 4" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos5" OnClick="lbl3_Click"></asp:LinkButton>
                                        <asp:LinkButton Visible="false" runat="server" ID="lbl4" Text="Pos 5" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos4" OnClick="lbl4_Click"></asp:LinkButton>
                                        <asp:LinkButton Visible="false" runat="server" ID="lbl5" Text="Pos 6" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos3" OnClick="lbl5_Click"></asp:LinkButton>
                                        <asp:LinkButton Visible="false" runat="server" ID="lbl6" Text="Pos 7" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos10" OnClick="lbl6_Click"></asp:LinkButton>
                                        <asp:LinkButton Visible="false" runat="server" ID="lbl7" Text="Pos 8" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos9" OnClick="lbl7_Click"></asp:LinkButton>
                                        <asp:LinkButton Visible="false" runat="server" ID="lbl8" Text="Pos 9" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos8" OnClick="lbl8_Click"></asp:LinkButton>
                                        <asp:LinkButton Visible="false" runat="server" ID="lbl9" Text="Pos 10" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos7" OnClick="lbl9_Click"></asp:LinkButton>

                                        <asp:LinkButton Visible="false" runat="server" ID="lbl10" Text="Pos 11" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos14" OnClick="lbl10_Click"></asp:LinkButton>
                                        <asp:LinkButton Visible="false" runat="server" ID="lbl11" Text="Pos 12" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos13" OnClick="lbl11_Click"></asp:LinkButton>
                                        <asp:LinkButton Visible="false" runat="server" ID="lbl12" Text="Pos 13" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos12" OnClick="lbl12_Click"></asp:LinkButton>
                                        <asp:LinkButton Visible="false" runat="server" ID="lbl13" Text="Pos 14" CssClass="irs-grid-text js-grid-text-0 label label-success waves-effect waves-light btn-teal m-b-5 S2_pos11" OnClick="lbl13_Click"></asp:LinkButton>

                                    </div>
                                </div>
                            </div>
                        </div>

                        
                        <br />
                        <br />
                        <div class="col-sm-6">
                            <h4 class="m-t-0 header-title"><b>Neumaticos</b></h4>
                            <p class="text-muted font-13 m-b-30">
                                Ingresar la informacion correspondiente a los neumaticos.  
                            </p>
                        </div>
                        <asp:GridView ID="gvNeumatico" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvNeumatico_PreRender" OnRowDataBound="gvNeumatico_RowDataBound" OnRowCommand="gvNeumatico_RowCommand">

                            <Columns>

                                <asp:BoundField Visible="false" DataField="id_nm" HeaderText="ID" />
                                <asp:BoundField DataField="nro_serie" HeaderText="Nro.Serie" />
                                <asp:BoundField DataField="nom_configuracion" HeaderText="Cnf." />
                                <asp:BoundField DataField="nom_marca" HeaderText="Marca" />
                                <asp:BoundField DataField="nom_modelo" HeaderText="Modelo" />
                                <asp:BoundField DataField="pos" HeaderText="Pos." />
                                <asp:BoundField DataField="km_actual" HeaderText="KM. Recorrido" />
                                <asp:BoundField DataField="R1" HeaderText="Remanente 1" />
                                <asp:BoundField DataField="R2" HeaderText="Remanente 2" />
                                <asp:BoundField DataField="R3" HeaderText="Remanente 3" />
                                <asp:TemplateField ItemStyle-Width="30px">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="btnLiberar" CommandArgument='<%#Eval("id_nm")+";"+Eval("nro_serie")+";"+Eval("pos")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Liberar"><i class="fa fa-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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

            <div id="infoModalRegistrar" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title">Registro de Mantenimiento</h4>

                        </div>
                        <div class="modal-body">
                            <div class="text">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                 <div class="form-group col-lg-12">
                                     <label for="name-1" class="control-label">Codigo Interno del Neumatico:</label>
                                        <asp:TextBox CssClass="form-control autocomplete" data-url="BuscarNeumatico.ashx" ID="txtNSerie" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtNSerie_id" runat="server" class="form-control" Style="color: #CCC; background: transparent; z-index: 1; display: none;"></asp:TextBox>
                                     <label for="name-1" class="control-label">Km:</label>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtKm" runat="server"></asp:TextBox>
                                     <label for="name-1" class="control-label">Remanente 1:</label>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtR1" runat="server"></asp:TextBox>
                                     <label for="name-1" class="control-label">Remanente 2:</label>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtR2" runat="server"></asp:TextBox>
                                     <label for="name-1" class="control-label">Remanente 3:</label>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtR3" runat="server"></asp:TextBox>
                                     <label for="name-1" class="control-label">Fecha:</label>
                                     <asp:TextBox required data-provide="datepicker" data-date-format="dd/mm/yyyy" CssClass="form-control text-center datepickers" ID="txtFecha" runat="server"></asp:TextBox>
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
        </asp:View>

    </asp:MultiView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

