<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="indumentaria.aspx.cs" Inherits="Modulos_Empleados_indumentaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Módulo Empleados</h4>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
  
    <div class="row"> 
        <div class="col-xs-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-lg-8">
                            <div class="header-title">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style="width: 10px;">EPP</td>
                                        <td style="width: 15px; text-align: center;">/</td>
                                        <td style="width: 90px;">Empleado</td>
                                        <td>
                                            <asp:TextBox placeholder="Ingresar nombre del personal" CssClass="form-control autocomplete" data-url="BuscarEmpleados.ashx" ID="txtEmpleado" runat="server"></asp:TextBox>
                                            <asp:TextBox  runat="server" ID="txtEmpleado_id" class="form-control" Style="color: #CCC; background: transparent; z-index: 1; display: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        
                        <div class="col-lg-4" style="text-align: right;">
                            <asp:Button ID="btnBuscarEmpleado" CssClass="btn btn-primary " runat="server" Text="Buscar" UseSubmitBehavior="False" OnClick="btnBuscarEmpleado_Click"/>
                            <asp:Button ID="btnExportarEPP" CssClass="btn btn-primary " runat="server" Text="Exportar" UseSubmitBehavior="False" OnClick="btnExportarEPP_Click"/>
                            <asp:HiddenField ID="hfCodId" runat="server" Value="0" />
                            <asp:HiddenField ID="hfCodigoDoc" runat="server" Value="0" />
                        </div>    
            </div>
        </div>
    </div>
            <div class="clearfix"></div>
        </div>
    </div>
    <asp:Panel runat="server" ID="PanelEPP" Visible="false">
     <div class="col-md-12">
                                <ul class="nav nav-tabs">
                                    <li id="li1" runat="server" class="">
                                        <asp:LinkButton ID="lnkEPP" runat="server" OnClick="lnkEPP_Click"><span class="visible-xs"><i class="fa fa-user"></i></span><span class="hidden-xs">1. Equipo de Proteccion Personal</span></asp:LinkButton></li>
                                    <li id="li2" runat="server" class="">
                                        <asp:LinkButton ID="lnkIndumentaria" runat="server" OnClick="lnkIndumentaria_Click"><span class="visible-xs"><i class="fa fa-users"></i></span><span class="hidden-xs">2. Indumentaria</span></asp:LinkButton></li>
                                </ul>

                         <div class="tab-content">
                              <div class="tab-pane">
                                   
                                               
                                   
                                    </div>
                                </div>

                            </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box table-responsive">
                <div class="col-sm-12">
                      <div class="col-sm-8 m-b-20">
                      </div>
                      <div class="clearfix"></div>
                    <asp:HiddenField ID="hfIDEquipo" runat="server" />
                    <asp:HiddenField ID="hfUsuario" runat="server" />
                    <asp:HiddenField ID="hfEquipo" runat="server" />
                    <asp:HiddenField ID="hfAccionEntrega" runat="server"/>
                    <asp:HiddenField ID="hfAccionDevolucion" runat="server"/>
                        <asp:gridview id="grvEPP" runat="server" autogeneratecolumns="False" cssclass="table table-striped table-bordered dataTable"  gridlines="None" OnPreRender="grvEntrega_PreRender" OnRowCommand="grvEntrega_RowCommand" OnRowDataBound="gvHistorico_RowDataBound" >
                            <Columns>
                                <asp:BoundField DataField="cod_equipo" HeaderText="CodigoTipo" Visible="false" />
                                <asp:BoundField DataField="tipoEPPS" HeaderText="Implemento" Visible="true" />
                                <asp:BoundField DataField="cantidad" HeaderText="En posesión" visible="true" ItemStyle-HorizontalAlign="Center"/>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha Operacion" visible="true" ItemStyle-HorizontalAlign="Center"/>
                                <asp:TemplateField HeaderText="Tipo Operacion">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltipo" runat="server" Text='<%# Eval("Tipo") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("estado") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="30px">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="btnRegistrar" ToolTip="Registrar EPP" CommandArgument='<%#Eval("cod_equipo")+";"+Eval("tipoEPPS")%>' CommandName="registrar" CssClass="icon-list-primary m-r-5" runat="server"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>

                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="btnHistorial" ToolTip="Ver Historial" CommandArgument='<%#Eval("cod_equipo")%>' CommandName="historial" CssClass="icon-list-primary m-r-5" runat="server"><i class="glyphicon glyphicon-list-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>


                                                <%--<td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="btnEliminar" ToolTip="Eliminar EPP" CommandArgument='<%#Eval("id_entre_epp")+";"+Eval("id_debo_epp")%>' CommandName="eliminar" CssClass="icon-list-primary m-r-5" runat="server" ><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                       </asp:gridview>
                </div>
            </div>
        </div>
    </div>


             <%--Inicio de Registro y Devolución de EPP--%>
            <div id="modalRegistroEPP" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title">Registro Indumentaria</h4>

                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                <div class="form-group col-lg-12">
                                    <div class="form-group col-lg-6">
                                    <label for="userName">Equipo :</label>
                                       <asp:Label CssClass="form-control" ID="lblEquipo" runat="server"></asp:Label>
                                    </div>
                                    <div class="form-group col-lg-3">
                                       <label for="userName">Fecha :</label>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                            <asp:TextBox required data-provide="datepicker" CssClass="form-control datepickers" ID="txtFchEntrega" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group col-lg-3">
                                        <label for="userName">Cantidad :</label>
                                        <asp:TextBox required type="number" spellcheck="false" CssClass="form-control" ID="txtCanEntrega" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                
                                <div class="form-group col-lg-12">

                                    <div class="form-group col-lg-4">
                                        <label for="userName">Talla:</label>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtTalla" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-lg-4 m-t-30">
                                        <div class="radio radio-custom radio-inline">
                                            <asp:RadioButton ID="rbEntrega" runat="server" GroupName="Equipo" checked/>
                                            <label for="chkActivo">Entrega</label>
                                        </div>
                                    </div>
                                    <div class="form-group col-lg-4 m-t-30">
                                        <div class="radio radio-custom radio-inline">
                                            <asp:RadioButton ID="rbDevolucion" runat="server" GroupName="Equipo" />
                                            <label for="chkActivo">Devolución</label>
                                        </div>
                                    </div>
                                </div>
                                 <div class="form-group col-lg-12">
                                    <div class="form-group col-lg-12">
                                        <label for="userName" class="control-label">Observación :</label>
                                            <asp:TextBox CssClass="form-control" ID="txtObsEntrega" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                        </div>
                                </div>
                                <div class="form-group col-lg-12">
                                     <div class="form-group col-lg-12">
                                         <div class="m-t-lg text-right">
                                             <asp:LinkButton ID="lnkRegistrarEPP" OnClick="lnkRegistrarEPP_Click" runat="server" CssClass="btn btn-info m-t-5" Text="Procesar"> </asp:LinkButton>
                                         </div>
                                     </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%--Fin de Registro de Local--%>

            <%-- INICIO DE HISTORICO --%>

            <div id="modalHistorico" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog modal-lg">
            <div class="modal-content p-0 b-0">
                <div class="panel panel-color panel-primary">
                    <div class="panel-heading">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                        <span class="sr-only">Close</span>
                    </button>

                    <h3 class="panel-title">Histórico de EPP e Indumentaria</h3>
                    
                </div>
                    <div class="panel-body">

                         <h5 class="panel-info">Histórico Entrega</h5>

                         <asp:HiddenField ID="hfEntrega" runat="server"/>
                        <asp:HiddenField ID="hfEquiEntrega" runat="server"/>
                     <asp:GridView ID="gvHistorico" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered dataTable" GridLines="None" OnRowCommand="gvHistorico_RowCommand" OnRowDataBound="gvHistorico_RowDataBound">

                                    <Columns>
                                        <asp:BoundField DataField="id_epp" HeaderText="Código de EPP" Visible="false" />
                                        <asp:BoundField DataField="nombre_completo" HeaderText="Nombre de Empleado" Visible="true" />
                                        <asp:BoundField DataField="cod_equipo" HeaderText="Implemento" Visible="true" />
                                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" Visible="true" />
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha de entrega"/>
                                        <asp:BoundField DataField="observacion" HeaderText="Observacion"/>
                                        <asp:BoundField DataField="talla" HeaderText="Talla"/>
                                        <asp:TemplateField HeaderText="Tipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltipo" runat="server" Text='<%# Eval("Tipo") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Estado" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("estado") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                         </Columns>

                      </asp:GridView>

                        <asp:HiddenField ID="hfDevolucion" runat="server"/>
                        <asp:HiddenField ID="hfEquiDevolucion" runat="server"/>
                        <asp:GridView ID="gvHistoricoDevolucion" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered dataTable" GridLines="None" OnRowCommand="gvHistoricoDevolucion_RowCommand">

                                    <Columns>
                                        <asp:BoundField DataField="id_debo_epp" HeaderText="Código de EPP" Visible="false" />
                                        <asp:BoundField DataField="id_emp" HeaderText="Código de Empleado" Visible="false" />
                                        <asp:BoundField DataField="codTipo" HeaderText="Código de Equipo" Visible="false" />
                                        <asp:BoundField DataField="cod_equipo" HeaderText="Nombre de Equipo" Visible="true" />
                                        <asp:BoundField DataField="can_devolucion" HeaderText="Cantidad"/>
                                        <asp:BoundField DataField="fecha_devolucion" HeaderText="Fecha Devolución"/>
                                        <asp:BoundField DataField="observa_devolucion" HeaderText="Observaciones"/>
                                        


                                        <asp:TemplateField HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                        <table>
                                            <tr>
                                               <%-- <td>
                                                    <a class="fancybox"  href='<%# Page.ResolveUrl(Eval("documentacion").ToString())%>' title='<%# Eval("tipodocumento")%>'><i class="fa fa-search" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></a>
                                                    <script type="text/javascript">
                                                    $(document).ready(function() {
	                                                $(".fancybox").fancybox({
		                                            width: 800,
                                                    height: 800,
                                                    type: 'iframe'
	                                                });
                                                    });
                                            </script>
                                                </td>--%>
                                                <%--<td>
                                                    <asp:LinkButton ToolTip="Descargar" CommandName="Descargar" CssClass="icon-list-primary m-l-5" ID="LinkButton9" runat="server"><i class="fa fa-file-pdf-o" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>--%>
                                                <td>
                                                    <asp:LinkButton  ID="btnEliminarDevolucion" ToolTip="Eliminar" CommandArgument='<%#Eval("codTipo")+";"+Eval("id_debo_epp")%>' CommandName="eliminar" CssClass="icon-list-primary m-l-5" runat="server"><i class="ti ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px" />
                                </asp:TemplateField>
                         </Columns>

                      </asp:GridView>


                </div>
                    <div class="modal-footer"></div>


                </div>
            </div>
        </div>
            </div>
    
            

            <%-- INICIO DE HISTORICO --%>


 <%-- CONFIRMAR ELIMINADO DE FILA --%>
            <div id="infoModalAlert3" tabindex="-1" role="dialog" class="modal fade">
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
                                    <h3 class="text-danger">¿Desea eliminar este registro?</h3>
                                    <p>Debe estar seguro antes de eliminar información del sistema</p>
                                    <div class="m-t-lg">
                                        <asp:LinkButton ID="btnEliminar" CssClass="btn btn-danger" runat="server" OnClick="btnEliminar_Click" ><i class="fa m-r-5"></i> <span>Eliminar</span>  </asp:LinkButton>
                                        <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                    </div>
                             </div>

                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%-- FIN DE ELIMINADO DE FILA --%>


    
 <%-- CONFIRMAR ELIMINADO DE FILA --%>
            <div id="infoModalAlert4" tabindex="-1" role="dialog" class="modal fade">
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
                                    <h3 class="text-danger">¿Desea eliminar este registro?</h3>
                                    <p>Debe estar seguro antes de eliminar información del sistema</p>
                                    <div class="m-t-lg">
                                        <asp:LinkButton ID="btnEliminarDevolucion" CssClass="btn btn-danger" runat="server" OnClick="btnEliminarDevolucion_Click" ><i class="fa m-r-5"></i> <span>Eliminar</span>  </asp:LinkButton>
                                        <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                    </div>
                             </div>

                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%-- FIN DE ELIMINADO DE FILA --%>



        </asp:Panel>





 </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">

</asp:Content>
