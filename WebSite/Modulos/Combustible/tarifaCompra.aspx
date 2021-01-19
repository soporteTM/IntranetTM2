<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="tarifaCompra.aspx.cs" Inherits="Modulos_Combustible_tarifaCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Modulo de Gestion Compra de Combustible </h4>
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
    <asp:HiddenField runat="server" ID="hfUsuario" />
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">

            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">
                        <div class="col-sm-6">
                            <h4 class="m-t-0 header-title"><b>Tarifas de compra</b></h4>
                            <p class="text-muted font-13 m-b-30">
                                Registro y consulta de tarifas de compra de combustible. 
                            </p>
                        </div>

                        <div class="panelOptions col-sm-6" style="text-align: right;">
                            <asp:LinkButton ID="lnkTarifa" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                runat="server" OnClick="lnkTarifa_Click">
                   <i class="fa fa-plus m-r-5"></i> <span> Agregar </span>  </asp:LinkButton>
                        </div>
                        <div class="clearfix"></div>
                        <asp:GridView ID="gvTarifas" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-striped table-bordered dataTable" GridLines="None" OnRowCommand="gvTarifas_RowCommand">

                            <Columns>

                                <asp:BoundField Visible="false" DataField="id_PC" HeaderText="Codigo" />
                                <asp:BoundField DataField="precio_compra_cisterna" HeaderText="Precio Compra Cisterna" DataFormatString="{0:c}" />
                                <asp:BoundField DataField="precio_compra_grifo" HeaderText="Precio Compra Grifo" DataFormatString="{0:c}" />
                                <asp:BoundField DataField="fecha_registro" HeaderText="Fecha"  />
                                <asp:TemplateField ItemStyle-Width="30px">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 0 2px;">
                                                            <%--<asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval("id_PC")%>' CssClass="btn btn-primary waves-effect waves-light btn-danger m-b-5" runat="server" CommandName="eliminar"><i class="fa fa-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>--%>
                                                            <asp:LinkButton ToolTip="Eliminar Tarifa" OnClientClick="JConfirm('Debe estar seguro antes de eliminar información del sistema','¿Desea eliminar esta tarifa?',this); return false;" CommandArgument='<%# Eval("id_PC") %>' CommandName="eliminar" CssClass="btn btn-primary waves-effect waves-light btn-danger m-b-5" ID="LinkButton3" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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

                            <h4 class="modal-title">Registro de Tarifa</h4>

                        </div>
                        <div class="modal-body">
                            <div class="text">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                 <div class="form-group col-lg-12">
                                     <label for="name-1" class="control-label">Precio Compra Cisterna:</label>
                                        <asp:TextBox required spellcheck="false" placeholder="Ingrese Compra Cisterna" CssClass="form-control" ID="txtCisterna" runat="server"></asp:TextBox>
                                     <label for="name-1" class="control-label">Precio Compra Grifo:</label>
                                        <asp:TextBox required spellcheck="false" placeholder="Ingrese Compra Grifo" CssClass="form-control" ID="txtGrifo" runat="server"></asp:TextBox>
                                     <label for="name-1" class="control-label">Fecha de registro:</label>
                                        <asp:TextBox required placeholder="dd/MM/yyyy" data-provide="datepicker" CssClass="form-control datepicker" ID="txtFecha" runat="server"></asp:TextBox>
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

   
</asp:Content>

