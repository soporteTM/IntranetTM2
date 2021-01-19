<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Proveedores.aspx.cs" Inherits="Modulos_OT_Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Módulo de Mantenimiento</h4>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                        <div class="row">
                             <div class="col-sm-12">
                                    <div class="card-box table-responsive">
                                        <div class="col-sm-6">
                                            <h4 class="m-t-0 header-title"><b>Consulta de Proveedores</b></h4>
                                        </div>
                                         <div class="panelOptions col-sm-6" style="text-align: right;">
                                             <asp:LinkButton ID="btnAgregar" CssClass="btn btn-info waves-effect waves-light m-b-5"  runat="server" OnClick="btnAgregar_Click">
                                                 <i class="fa fa-plus m-r-5"></i> <span>Agregar</span> 
                                             </asp:LinkButton>
                                        </div>
                                         <div class="clearfix"></div>
                                        <asp:GridView ID="grvDataProveedores" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="grvDataProveedores_PreRender" OnRowCommand="grvDataProveedores_RowCommand">
                                            <Columns>
                                                <asp:BoundField DataField="IdProveedor" HeaderText="Nro.">
                                                     <ItemStyle Width="150px"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Codigo" HeaderText="Código">
                                                    <ItemStyle Width="250px"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                                     <ItemStyle Width="350px"></ItemStyle>
                                                </asp:BoundField>
                                            <asp:TemplateField>
                                                 <ItemTemplate>
                                                    <table>
                                                        <tr>                                               
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ToolTip="Detalle Proveedor" ID="lnkDetalle" CommandArgument='<%# Eval("IdProveedor") %>' CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="detalle"><span class="fa fa-pencil-square-o"/></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ToolTip="Eliminar Proveedor" ID="lnkEliminar" CommandArgument='<%# Eval("IdProveedor") %>' CommandName="eliminar" OnClientClick="JConfirm('Debe estar seguro antes de eliminar al proveedor del sistema','¿Desea eliminar este Proveedor?',this); return false;"   CssClass="btn btn-icon waves-effect waves-light btn-danger m-b-5" runat="server" ><span class="ti ti-trash"/></asp:LinkButton>
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

                     <div id="infoModalAlert2" tabindex="-1" role="dialog" class="modal fade">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">
                                        <span aria-hidden="true">×</span>
                                        <span class="sr-only">Close</span>
                                    </button>
                                    <h4 class="modal-title"></h4>
                                </div>
                                <div class="modal-body">
                                    <asp:Label ID="lblIdProveedor" runat="server" Visible="false"></asp:Label>
                                    <div class="row">
                                        <span class="text-primary icon icon-info-circle icon-5x"></span>
                                        <div class="form-group col-md-12">
                                              
                                            <div class="form-group col-md-6">
                                                <label for="txtCodigo">Código : </label>
                                                <div class="form-group">
                                                    <asp:TextBox required spellcheck="false" placeholder="Ingrese un código para el proveedor"  CssClass="form-control " ID="txtCodigo" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group col-md-6">
                                                <label for="txtDescripcion">Descripción : </label>
                                                <div class="form-group">
                                                    <asp:TextBox required spellcheck="false" placeholder="Ingresa la descripción del proveedor"  CssClass="form-control" ID="txtDescripcion" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group col-lg-12">
                                            <div class="col-lg-12 text-center">
                                                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-instagram m-t-5" Text="Guardar" OnClick="btnGuardar_Click"></asp:Button>
                                            </div>
                                        </div>
                                   </div>
                              </div>
                            <div class="modal-footer"></div>
                          </div>
                       </div>
                    </div>
                </asp:View>

            </asp:MultiView>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
         <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <!-- Init -->
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/initReportes.js")%>'></script>
</asp:Content>

