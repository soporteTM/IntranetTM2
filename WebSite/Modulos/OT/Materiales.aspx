<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true"  CodeFile="Materiales.aspx.cs" Inherits="Modulos_OT_Materiales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

        <!--Morris Chart CSS -->
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
                                    <h4 class="m-t-0 header-title"><b>Consulta de Materiales</b></h4>
                                </div>


                                <%-- Boton Agregar Material --%>
                                <div class="panelOptions col-sm-6" style="text-align: right;">
                                        <asp:LinkButton ID="btnAgregar" CssClass="btn btn-info waves-effect waves-light m-b-5"  runat="server" OnClick="btnAgregar_Click">
                                          <i class="fa fa-plus m-r-5"></i> <span>Agregar</span> 
                                        </asp:LinkButton>
                                </div>
                                <%-- Fin de Boton Seleccionar Archivo--%>

                                <div class="clearfix"></div>
                                <asp:HiddenField ID="hfUsuario" runat="server" />

                                <%-- Grid View m --%>

                                   <asp:GridView ID="grvDataMateriales" runat="server" AutoGenerateColumns="False"
                                   CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="grvDataMateriales_PreRender" OnRowCommand="grvDataMateriales_RowCommand">
                                    <Columns>

                                        <asp:BoundField DataField="IdMaterial" HeaderText="Nro." />
                                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                        <asp:BoundField DataField="nom_grupo" HeaderText="Grupo de Artículos" />
                                        <asp:BoundField DataField="ArticuloNumero" HeaderText="Núm. de Grupo" />
                                        <%--<asp:BoundField DataField="" HeaderText="Fecha de Registro" />
                                        <asp:BoundField DataField="" HeaderText="Usuario de Registro" />--%>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table>
                                            <tr>                                               
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ToolTip="Detalle Material" ID="LinkButton3" CommandArgument='<%# Eval("IdMaterial") %>' CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="detalle"><span class="fa fa-pencil-square-o"/></asp:LinkButton>
                                                </td>
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ToolTip="Eliminar Material" ID="lnkEliminar" CommandArgument='<%# Eval("IdMaterial") %>' CommandName="eliminar" OnClientClick="JConfirm('Debe estar seguro antes de eliminar el material del sistema','¿Desea eliminar este Material?',this); return false;"   CssClass="btn btn-icon waves-effect waves-light btn-danger m-b-5" runat="server" ><span class="ti ti-trash"/></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>



                                    </Columns>
                                   
                                   </asp:GridView>

                             <%--   <asp:GridView ID="grvCombustibleCabecera" runat="server" AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="grvCombustibleCabecera_PreRender" OnRowCommand="grvCombustibleCabecera_RowCommand">

                                    <Columns>

                                        <asp:BoundField DataField="id" HeaderText="Nro." />
                                        <asp:BoundField DataField="nom_estacion" HeaderText="Estación" />
                                        <asp:BoundField DataField="fecha_inicio" HeaderText="Fecha Inicio" />
                                        <asp:BoundField DataField="fecha_corte" HeaderText="Fecha de Fin" />
                                        <asp:BoundField DataField="fecha_registro" HeaderText="Fecha de Registro" />
                                        <asp:BoundField DataField="usuario_registro" HeaderText="Usuario de Registro" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table>
                                            <tr>                                               
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ToolTip="Detalle Consumo" ID="LinkButton3" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="detalle"><span class="fa fa-pencil-square-o"/></asp:LinkButton>
                                                </td>
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ToolTip="Eliminar Consumo" ID="lnkEliminar" OnClientClick="JConfirm('Debe estar seguro antes de eliminar el consumo del sistema','¿Desea eliminar este Consumo?',this); return false;"  CommandArgument='<%# Eval("id") %>' CssClass="btn btn-icon waves-effect waves-light btn-danger m-b-5" runat="server" CommandName="eliminar"><span class="ti ti-trash"/></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>



                                    </Columns>

                                </asp:GridView>--%>
                                <%-- Fin Grid View Cabecera Combustible --%>
                            </div>
                        </div>
                    </div>                    

                    <%-- INICIO DE REGISTRAR MATERIALES --%>
                    <%-----------------------------%>

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
                                    <asp:Label ID="lblIdMaterial" runat="server" Visible="false"></asp:Label>
                                    <div class="row">
                                        <span class="text-primary icon icon-info-circle icon-5x"></span>
                                        <div class="form-group col-md-12">
                                              
                                            <div class="form-group col-md-6">
                                                <label for="txtCodigo">Código : </label>
                                                <div class="form-group">
                                                    <asp:TextBox required spellcheck="false" placeholder="Ingrese un código para el material"  CssClass="form-control " ID="txtCodigo" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group col-md-6">
                                                <label for="txtDescripcion">Descripción : </label>
                                                <div class="form-group">
                                                    <asp:TextBox required spellcheck="false" placeholder="Ingresa una descripción para el material"  CssClass="form-control" ID="txtDescripcion" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <!--PONER STYLE ROSA 20-11-2020-->
                                        <div class="form-group col-md-12">

                                             <div class="form-group col-md-6">
                                                  <label for="txtGrupo">Grupo de Artículos : </label>
                                                 <div class="form-group">
                                                    <asp:DropDownList ID="ddlGrupo" CssClass="form-control" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="form-group col-md-6" style="visibility:hidden" >
                                                  <label for="txtGrupo">Número de Grupo: </label>
                                                 <div class="form-group">
                                                   <label for="txtGrupo" ID="lblGrupoNumero" runat="server"></label>
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

             
                    <%-----------------------------%>
                </asp:View>


                <asp:View ID="View2" runat="server">

                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card-box table-responsive">
                                <div class="col-sm-6">
                                    <h4 class="m-t-0 header-title"><b>Detalle Consumo en Estación</b></h4>
                                </div>

                                
                                <%-- Boton Seleccionar Archivo --%>
                                <div class="panelOptions col-sm-6" style="text-align: right;">
                                    <%--<asp:LinkButton ID="lnkRegresar" CssClass="btn btn-default waves-effect waves-light m-b-5" runat="server" OnClick="lnkRegresar_Click"> <span> Regresar </span>  </asp:LinkButton>
                                    <asp:LinkButton ID="btnExportar" CssClass="btn btn-default waves-effect waves-light m-b-5" runat="server" Text="Exportar a Excel" OnClick="btnExportar_Click" ><span>Exportar</span></asp:LinkButton>--%>
                                </div>
                                <%-- Fin de Boton Seleccionar Archivo--%>
                               
                          
                                <div class="clearfix"></div>

                                <%-- Grid View Cabecera Combustible --%>
                                <%--<asp:GridView ID="grvCombustibleDetalle" runat="server" AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="grvCombustibleDetalle_PreRender" OnRowCreated="grvCombustibleDetalle_RowCreated">

                                    <Columns>
                                        <asp:BoundField DataField="id_detalle" HeaderText="ID" Visible="false"/>
                                        <asp:BoundField DataField="id_cabecera" HeaderText="ID"/>
                                        <asp:BoundField DataField="nro_placa" HeaderText="Nro. Placa" />
                                        <asp:BoundField DataField="nom_cliente" HeaderText="Usuario" />
                                        <asp:BoundField DataField="c_costo" HeaderText="Centro de Costo" />
                                        <asp:BoundField DataField="cod_eess" HeaderText="EESS" Visible="False" />
                                        <asp:BoundField DataField="nom_eess" HeaderText="EESS Nombre" Visible="False"/>
                                        <asp:BoundField DataField="fch_documento" HeaderText="Fecha Documento" />
                                        <asp:BoundField DataField="num_documento" HeaderText="Nro. Documento" />
                                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                        <%--<asp:BoundField DataField="precio_sin_igv" HeaderText="P.S/IGV" />--%>
                                        <asp:BoundField DataField="precio_con_igv" HeaderText="P.C/IGV" />
                                        <%--<asp:BoundField DataField="monto_sin_igv" HeaderText="M.S/IGV" />--%>
                                        <asp:BoundField DataField="monto_con_igv" HeaderText="Monto" />                              
                                        <asp:BoundField DataField="Kilometraje" HeaderText="Kilometraje" />                              
                                    </Columns>
                                </asp:GridView>--%>


                                <%-- Fin Grid View Cabecera Combustible --%>
                            </div>
                        </div>
                    </div>

                </asp:View>

            </asp:MultiView>

            <!-- end card-box -->
        </div>
        <!-- End col -->
    </div>
    <!-- end row -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">

      <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <!-- Init -->
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/initReportes.js")%>'></script>
      <!-- Google Charts js -->
     <script type="text/javascript">

     
    
      </script>
   


</asp:Content>

