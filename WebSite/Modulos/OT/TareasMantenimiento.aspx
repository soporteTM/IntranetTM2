<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="TareasMantenimiento.aspx.cs" Inherits="Modulos_OT_TareasMantenimiento" %>

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
                                            <h4 class="m-t-0 header-title"><b>Consulta de Tareas de Mantenimiento</b></h4>
                                        </div>
                                        <div class="panelOptions col-sm-6" style="text-align: right;">
                                             <asp:LinkButton ID="btnAgregar" CssClass="btn btn-info waves-effect waves-light m-b-5"  runat="server" OnClick="btnAgregar_Click">
                                                 <i class="fa fa-plus m-r-5"></i> <span>Agregar</span> 
                                             </asp:LinkButton>
                                        </div>
                                        <div class="clearfix"></div>
                                        <asp:GridView ID="grvDataTareasMantenimientoDetalle" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="grvDataTareasMantenimientoDetalle_PreRender" OnRowCommand="grvDataTareasMantenimientoDetalle_RowCommand">
                                             <Columns>
                                                 <asp:BoundField DataField="IdTarea" HeaderText="Nro.">
                                                     <ItemStyle Width="150px"></ItemStyle>
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="nom_grupo" HeaderText="Tipo de Servicio">
                                                 </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <table>
                                                          <tr> 
                                                              <td style="padding: 0 2px;">
                                                                  <asp:LinkButton ToolTip="Ver" ID="lnkVer" CommandArgument='<%# Eval("IdTarea") %>'  CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="ver"><i class="fa fa-info-circle" aria-hidden="true"></i></asp:LinkButton>
                                                               </td>
                                                               <td style="padding: 0 2px;">
                                                                   <asp:LinkButton ToolTip="Detalle Tarea" ID="lnkDetalle" CommandArgument='<%# Eval("IdTarea") %>'  CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="detalle"><span class="fa fa-pencil-square-o"/></asp:LinkButton>
                                                               </td>
                                                               <td style="padding: 0 2px;">
                                                                   <asp:LinkButton  ToolTip="Eliminar Tarea" ID="lnkEliminar" CommandArgument='<%# Eval("IdTarea") %>' CommandName="eliminar" OnClientClick="JConfirm('Debe estar seguro antes de eliminar la tarea del sistema','¿Desea eliminar esta Tarea?',this); return false;"   CssClass="btn btn-icon waves-effect waves-light btn-danger m-b-5" runat="server"><span class="ti ti-trash"/></asp:LinkButton>
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
                                    <asp:Label ID="lblIdTarea" runat="server" Visible="false"></asp:Label>
                                    <div class="row">
                                        <span class="text-primary icon icon-info-circle icon-5x"></span>
                                        <div class="form-group col-md-12">
                                            <div class="form-group col-md-6">
                                                <label for="txtDescripcion">Descripción : </label>
                                                <div class="form-group">
                                                    <asp:TextBox required spellcheck="false" placeholder="Ingresa la descripción de la tarea"  CssClass="form-control" ID="txtDescripcion" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                              <div class="form-group col-md-6">
                                         <asp:ScriptManager ID="ScriptManager1" runat="server">
                                         </asp:ScriptManager> 
                                                  <asp:UpdatePanel ID="UpdatePanelTipoServicio" runat="server">
                                                    <ContentTemplate>
                                                     <label for="txtGrupo">Tipo de Servicio : </label>
                                                     <div class="form-group">
                                                        <asp:DropDownList required ID="ddlGrupo" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlGrupo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    </div>
                                                </ContentTemplate>
                                                       <Triggers>
                                                           <asp:AsyncPostBackTrigger ControlID="ddlGrupo" EventName="SelectedIndexChanged" />
                                                       </Triggers>
                                                 </asp:UpdatePanel>

                                              </div>
                                        </div>
                                        
                                        <div class="form-group col-md-12">
                                        <asp:UpdatePanel ID="updatepanelMarca" runat="server">
                                        <ContentTemplate>
                                             <div class="form-group col-md-6">
                                                      <label for="txtMarca">Marcas Disponibles : </label>       
                                                      <div class="form-group">
                                                        <asp:ListBox runat="server" SelectionMode="Multiple" ID="ddlMarca" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged"  CssClass="form-control" AutoPostBack="true" Rows="10">
                                                        </asp:ListBox>
                                                        <asp:Label id="Label1" Font-Names="Verdana" Font-Size="10pt" runat="server">    
                                                        </asp:Label>
                                                       </div>
                                                    </div>  
                                              <div class="form-group col-md-6">
                                                       <label for="txtMarca">Marcas Seleccionadas : </label>
                                                         <div class="form-group">
                                                            <asp:ListBox runat="server" SelectionMode="Multiple" ID="lstAgregar" AutoPostBack="false" CssClass="form-control" Rows="10">
                                                            </asp:ListBox>
                                                            <asp:Label id="Label2" Font-Names="Verdana" Font-Size="10pt" runat="server">
                                                             </asp:Label>
                                                             </br>
                                                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar seleccionado" CssClass="btn btn-instagram m-t-3 center-block" OnClick="btnEliminar_Click" />
                                                          </div>
                                            </div>
                                         </ContentTemplate> 
                                          <Triggers>
                                            <asp:AsyncPostBackTrigger  ControlID="ddlMarca" EventName="SelectedIndexChanged"/>
                                            <asp:AsyncPostBackTrigger  ControlID="btnEliminar" EventName="Click"/>                       
                                          </Triggers>
                                          </asp:UpdatePanel>
                                        </div>
                                        <div class="form-group col-md-12">
                                           <asp:UpdatePanel ID="updatepanelBuscar" runat="server">
                                            <ContentTemplate>
                                            <div class="form-group col-md-8">
                                               <asp:TextBox ID="txtMaterial" runat="server"  CssClass="form-control" placeholder="Ingresa el material a buscar"></asp:TextBox>
                                                <asp:Label ID="lblError" runat="server" Font-Names="Verdana" Font-Size="10pt"></asp:Label>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <asp:Button ID="btnBuscarMat" runat="server" Text="Buscar" CssClass="btn btn-instagram m-t-3 center-block" OnClick="btnBuscarMat_Click" />
                                            </div>
                                             </ContentTemplate> 
                                               <Triggers>
                                                   <asp:AsyncPostBackTrigger  ControlID="btnBuscarMat" EventName="Click"/> 
                                               </Triggers>
                                            </asp:UpdatePanel>

                                        </div>
                                      <div class="form-group col-md-12">
                                          <asp:UpdatePanel ID="updatepanelMaterial" runat="server">
                                            <ContentTemplate>
                                            <div class="form-group col-md-6">
                                             <label for="txtMaterial">Materiales Disponibles : </label>
                                              <div class="form-group">
                                                 <asp:ListBox ID="lstMaterial" runat="server" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="true" Rows="10"></asp:ListBox>
                                                  <%--<asp:Label ID="Label4"  Font-Names="Verdana" Font-Size="10pt" runat="server" Text=""></asp:Label>--%>
                                                  </br>
                                                  <asp:Button ID="btnAgregarMat" runat="server" Text="Agregar Seleccionado" CssClass="btn btn-instagram m-t-3 center-block" OnClick="btnAgregarMat_Click"/>
                                                  </div>
                                            </div>
                                            <div class="form-group col-md-6">
                                                  <label for="txtMaterial">Materiales Seleccionados : </label>
                                                  <asp:ListBox ID="lstMaterialSelect" runat="server" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="false" Rows="10"></asp:ListBox>
                                                  <asp:Label ID="Label3" Font-Names="Verdana" Font-Size="10pt" runat="server">
                                                  </asp:Label>
                                                </br>
                                                  <asp:Button ID="btnEliminarMat" runat="server" Text="Eliminar seleccionado"  CssClass="btn btn-instagram m-t-3 center-block" OnClick="btnEliminarMat_Click" />
                                            </div>
                                            </ContentTemplate>
                                               <Triggers>
                                                     <%--<asp:AsyncPostBackTrigger ControlID="ddlGrupo" EventName="SelectedIndexChanged"/>--%>
                                                     <asp:AsyncPostBackTrigger ControlID="lstMaterial" EventName="SelectedIndexChanged"/>
                                                     <asp:AsyncPostBackTrigger ControlID="btnAgregarMat" EventName="Click"/>
                                                     <asp:AsyncPostBackTrigger  ControlID="btnEliminarMat" EventName="Click" />
                                                     
                                               </Triggers>
                                           </asp:UpdatePanel>
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
                      
                    <div id="infoModalAlert3" tabindex="-1" role="dialog" class="modal fade">
                        <div class="modal-dialog">
                               <div class="modal-content">
                                   <div class="modal-header">
                                     <button type="button" class="close" data-dismiss="modal">
                                        <span aria-hidden="true">×</span>
                                        <span class="sr-only">Close</span>
                                    </button>
                                   </div>
                                   <h4 class="modal-title">Detalle de Marcas y Materiales</h4>
                                   <div class="modal-body">
                                       <asp:Label ID="lblIdtareaDetalle" runat="server" Visible="false"></asp:Label>
                                        <div class="row">
                                              <span class="text-primary icon icon-info-circle icon-5x"></span>
                                              <div class="form-group col-md-12">
                                                  <asp:GridView ID="grvDataDetMarca" runat="server" AutoGenerateColumns="False"
                                                    CssClass="table table-striped table-bordered dataTable" GridLines="None">
                                                      <Columns>
                                                           <asp:BoundField DataField="IdTarea" HeaderText="Nro.">
                                                            <ItemStyle Width="5px"></ItemStyle>
                                                            </asp:BoundField>

                                                           <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                                            <ItemStyle Width="90px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="nom_marca" HeaderText="Marcas">
                                                                <ItemStyle Width="20px"></ItemStyle>
                                                            </asp:BoundField>
                                                         </Columns>
                                                  </asp:GridView>
                                              </div>
                                        </div>
                                       <div class="row">
                                           <div class="form-group col-md-12">
                                               <asp:GridView ID="grvDataDetMaterial" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-striped table-bordered dataTable" GridLines="None">
                                                    <Columns>
                                                            <asp:BoundField DataField="IdTarea" HeaderText="Nro.">
                                                                <ItemStyle Width="5px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                                                <ItemStyle Width="80px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="nom_material" HeaderText="Materiales">
                                                                <ItemStyle Width="30px"></ItemStyle>
                                                            </asp:BoundField>
                                                    </Columns>
                                               </asp:GridView>
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
<script type="text/javascript" src="https://www.google.com/jsapi">
</script>
<script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/initReportes.js")%>'></script>
<script type="text/javascript">
    <%--function Eliminar() {
        debugger;
        var x = '<%= lstAgregar.SelectedValue %>';
        $("#lstAgregar option[value=" + x + "]").attr("selected", true);
        $('.lstAgregar option[value="' + x + '"]').remove();
    }--%>
</script>

</asp:Content>

