<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Solicitud.aspx.cs" Inherits="Modulos_SIG_Solicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!--Morris Chart CSS -->
    <link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Modulo de solicitudes de creacion</h4>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    
    
    
    <div class="row">
        
        <div class="col-md-12">
          
            
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div class="col-lg-8">
                    </div>
                    <div class="panelOptions col-sm-4 m-t-15" style="text-align: right;">
                    <asp:HiddenField runat="server" ID="hfNomUser"/>
                    <asp:HiddenField runat="server" ID="hfCodEmpresa"/>
                    </div>


                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card-box table-responsive">
                                <div class="panelOptions col-sm-6" style="text-align: right;"></div>
                                <div class="clearfix"></div>

                                
                                <asp:GridView ID="grvEmpresa" runat="server" AutoGenerateColumns="False" 
                                CssClass="table table-striped table-bordered dataTable" GridLines="None" OnRowCommand="grvEmpresa_RowCommand" >
                                   
                                    <Columns>
                                        <asp:BoundField DataField="Cod_Empresa" HeaderText="ID" Visible="false" />
                                        <asp:BoundField DataField="Razon_Social" HeaderText="Razon Social"/>
                                        <asp:BoundField DataField="RUC" HeaderText="RUC"/>
                                        <asp:BoundField DataField="Contacto" HeaderText="Contacto"/>
                                        <asp:BoundField DataField="Cargo_Contacto" HeaderText="Cargo"/>
                                        <asp:BoundField DataField="Email_Contacto" HeaderText="Email"/>
                                        <asp:BoundField DataField="Fecha_Solicitud" HeaderText="Fch. Solicitud"/>
                                        <asp:TemplateField ItemStyle-Width="20px" HeaderText="Opciones">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnAprobar" CommandArgument='<%#Eval("Cod_Empresa")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Aceptar"><i class="mdi mdi-check" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnRechazar" CommandArgument='<%#Eval("Cod_Empresa")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5"   runat="server" CommandName="Rechazar"><i class="fa fa-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>

                                <%-- MODAL CONFIRMAR --%>
                                    <div id="infoModaAprobar" tabindex="-1" role="dialog" class="modal fade">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">
                                            <span aria-hidden="true">×</span>
                                            <span class="sr-only">Cerrar</span>
                                            </button>
                                        </div>

                                        <div class="modal-body">
                                            <div class="text-center">
                                                <span class="text-danger icon icon-times-circle icon-5x"></span>
                                                    <h3 class="text-success">¿Desea APROBAR esta Solicitud?</h3>
                                                    <p>Debe estar seguro antes de ejecutar la siguiente accion</p>
                                                    <div class="m-t-lg">
                                                        <asp:LinkButton ID="btnAprobar" CssClass="btn btn-success" runat="server" OnClick="btnAprobar_Click" ><i class="fa m-r-5"></i> <span>   Aprobar</span>  </asp:LinkButton>
                                                        <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                                    </div>
                                             </div>

                                        </div>
                                        <div class="modal-footer"></div>
                                    </div>
                                </div>
                            </div>
                                <%-- MODAL RECHAZAR --%>
                                <div id="infoModaRechazar" tabindex="-1" role="dialog" class="modal fade">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal">
                                                <span aria-hidden="true">×</span>
                                                <span class="sr-only">Cerrar</span>
                                                </button>
                                            </div>

                                            <div class="modal-body">
                                                <div class="text-center">
                                                    <span class="text-danger icon icon-times-circle icon-5x"></span>
                                                        <h3 class="text-danger">¿Desea RECHAZAR esta Solicitud?</h3>
                                                        <p>Debe estar seguro antes de ejecutar la siguiente accion</p>
                                                    <asp:TextBox placeholder="¿Desea agregar alguna observacion?" TextMode="MultiLine" runat="server" ID="txtObservacion"></asp:TextBox>
                                                        <div class="m-t-lg">
                                                            <asp:LinkButton ID="btnRechazar" CssClass="btn btn-danger" runat="server" OnClick="btnRechazar_Click" ><i class="fa m-r-5"></i> <span>   Rechazar</span>  </asp:LinkButton>
                                                            <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                                        </div>
                                                 </div>

                                            </div>
                                            <div class="modal-footer"></div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

            </asp:View>
        
           
           
          </asp:MultiView>
        </div>
    </div>
        
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <!-- Google Charts js -->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <!-- Init -->
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/initReportes.js")%>'></script>

    
</asp:Content>