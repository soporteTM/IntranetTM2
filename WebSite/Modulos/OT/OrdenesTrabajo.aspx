<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="OrdenesTrabajo.aspx.cs" Inherits="Modulos_OT_OrdenesTrabajo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                    <h4 class="m-t-0 header-title"><b>Consulta de Ordenes de Trabajo</b></h4>
                                </div>
                                <div class="panelOptions col-sm-6" style="text-align: right;">
                                    <asp:LinkButton ID="btnAgregar" runat="server" CssClass="btn btn-info waves-effect waves-light m-b-5" CommandName="Agregar" OnCommand="btnAgregar_Command">
                                                <i class="fa fa-plus m-r-5"></i> <span>Agregar</span> 
                                    </asp:LinkButton>
                                </div>
                                <div class="clearfix"></div>
                                <asp:HiddenField ID="HFNombreConductor" runat="server" />

                                <asp:HiddenField ID="HFValor" runat="server" />

                                <asp:GridView ID="grvDataOrdenesTrabajo" runat="server" AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="grvDataOrdenesTrabajo_PreRender" OnRowCommand="grvDataOrdenesTrabajo_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="IdOrden" HeaderText="Nro.">
                                            <ItemStyle Width="150px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                            <ItemStyle Width="400px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cEstado" HeaderText="Estado">
                                            <ItemStyle Width="100px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ToolTip="Ver" ID="lnkVer" CommandArgument='<%# Eval("IdOrden") %>' CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="ver"><i class="fa fa-info-circle" aria-hidden="true"></i></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ToolTip="Detalle Material" ID="lnkDetalle" CommandArgument='<%# Eval("IdOrden") %>' CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="detalle"><span class="fa fa-pencil-square-o"/></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ToolTip="Eliminar Orden" ID="lnkEliminar" CommandArgument='<%# Eval("IdOrden") %>' CommandName="eliminar" OnClientClick="JConfirm('Debe estar seguro antes de eliminar la orden del sistema','¿Desea eliminar esta Orden?',this); return false;" CssClass="btn btn-icon waves-effect waves-light btn-danger m-b-5" runat="server"><span class="ti ti-trash"/></asp:LinkButton>
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
                    <div class="row">
                        <div class="form-group col-sm-12">
                            <div class="card-box table-responsive">
                                <asp:Label ID="lblIdOrden" runat="server" Visible="false"></asp:Label>
                                <div class="col-lg-12 text-right">
                                    <asp:Button ID="btnRegresar" runat="server" CssClass="btn btn-instagram m-t-5" Text="Regresar" OnClick="btnRegresar_Click"></asp:Button>
                                </div>
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                <div class="form-group col-md-12">
                                    <div class="form-group col-md-4">
                                        <label for="txtFecha">Fecha : </label>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                            <asp:TextBox required ID="txtFecha" runat="server" placeholder="Seleccione fecha" CssClass="form-control datepicker" spellcheck="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="txtPlacaTracto">Placa Tracto : </label>
                                        <asp:TextBox ID="txtPlacaTracto" runat="server" CssClass="form-control" placeholder="Placa Tracto"></asp:TextBox>
                                        <asp:Label ID="lblvalidaPlaca" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="txtPlacaSemiremolque">Placa Semiremolque : </label>
                                        <asp:TextBox ID="txtPlacaSemiremolque" runat="server" CssClass="form-control" placeholder="Placa Semiremolque"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-md-12">
                                    <div class="form-group col-md-4">
                                        <label for="txtHoraIngreso">Fecha Hora Ingreso : </label>
                                        <div class="input-group date" data-target-input="nearest">

                                            <asp:TextBox runat="server" ID="txtHoraIngreso2" CssClass="datepicker form-control"></asp:TextBox>
                                            <%-- <asp:TextBox data-provide="timepicker" required parsley-trigger="change" CssClass="form-control timepicker" ID="txtHoraIngreso" runat="server"></asp:TextBox>--%>
                                            <span class="input-group-addon"><i class="mdi mdi-clock"></i></span>
                                            

                                            <asp:TextBox AutoCompleteType="Disabled" placeholder="Hora" CssClass="form-control " ID="txtHoraIngreso" runat="server"></asp:TextBox>
                                           
                                        </div>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="txtHoraIngreso">Fecha Hora Salida : </label>
                                        <div class="input-group date" data-target-input="nearest">
                                         

                                            <asp:TextBox runat="server" ID="txtHoraSalida2" CssClass="datepicker form-control"></asp:TextBox>
                                            <span class="input-group-addon"><i class="mdi mdi-clock"></i></span>                                   
                                            <asp:TextBox AutoCompleteType="Disabled" placeholder="Hora" CssClass="form-control " ID="txtHoraSalida" runat="server"></asp:TextBox>

                                           <%-- <asp:TextBox data-provide="timepicker" parsley-trigger="change" CssClass="form-control timepicker" ID="txtHoraSalida" runat="server"></asp:TextBox>
                                            <span class="input-group-addon"><i class="mdi mdi-clock"></i></span>--%>


                                        </div>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="txtKilometraje">Kilometraje : </label>
                                        <asp:TextBox ID="txtKilometraje" runat="server" CssClass="form-control" placeholder="Kilometraje"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-md-12">
                                    <div class="form-group col-md-4">
                                        <label for="txtDuracion">Duración : </label>
                                        <asp:TextBox ID="txtDuracion" runat="server" CssClass="form-control" placeholder="Duración"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="txtHorometro">Horómetro : </label>
                                        <asp:TextBox ID="txtHorometro" runat="server" CssClass="form-control" placeholder="Horómetro"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="txtTecnico">Técnico : </label>
                                        <asp:DropDownList required ID="ddlTecnico" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-md-12">
                                    <div class="form-group col-md-4">
                                        <label for="txtConductor">Conductor : </label>
                                        <asp:DropDownList required ID="ddlConductores" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="txtSede">Sede : </label>
                                        <asp:DropDownList required ID="ddlSede" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="txtServicio">Servicio : </label>
                                        <asp:DropDownList required ID="ddlServicio" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-md-12">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanelProveedor" runat="server">
                                        <ContentTemplate>
                                            <div class="form-group col-md-4">
                                                <label for="txtServicio">Tipo de Servicio : </label>
                                                <asp:DropDownList required ID="ddlTipoServicio" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipoServicio_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label for="txtServicioRealizado">Servicio Realizado : </label>
                                                <asp:DropDownList required ID="ddlServicioRealizado" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlServicioRealizado_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label for="txtProveedor" id="lblProveedor" runat="server">Proveedor : </label>
                                                <asp:DropDownList required ID="ddlProveedor" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlTipoServicio" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlServicioRealizado" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                </div>

                                <div class="form-group col-md-12">
                                    <asp:UpdatePanel ID="updatePanelSistema" runat="server">
                                        <ContentTemplate>
                                            <div class="form-group col-md-6">
                                                <label for="txtSistema">Sistema : </label>
                                                <asp:ListBox ID="lstSistema" runat="server" CssClass="form-control" SelectionMode="Multiple" Rows="8" AutoPostBack="True" OnSelectedIndexChanged="lstSistema_SelectedIndexChanged"></asp:ListBox>
                                            </div>
                                            <div class="form-group col-md-6">
                                                <label for="txtSistemaSelect">Seleccionados : </label>
                                                <div class="form-group">
                                                    <asp:ListBox ID="lstSistemaSelect" runat="server" CssClass="form-control" SelectionMode="Multiple" Rows="8" AutoPostBack="false"></asp:ListBox>
                                                    <asp:Label ID="lblSistema" runat="server"></asp:Label>
                                                    <br>
                                                    <asp:Button ID="btnEliminarSist" runat="server" Text="Eliminar Seleccionado" CssClass="btn btn-instagram m-t-3 center-block" OnClick="btnEliminarSist_Click" />
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="lstSistema" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="btnEliminarSist" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>

                                <div class="form-group col-md-12">
                                    <label for="txtSolicitud">Solicitud/Inconveniente encontrado : </label>
                                    <br />
                                    <asp:TextBox ID="txtSolicitud" TextMode="MultiLine" runat="server" Columns="10" Rows="2" CssClass="form-control"></asp:TextBox>
                                </div>
                                <h5 class="modal-title">Tareas Efectuadas: </h5>
                                <div class="form-group col-md-12">
                                    <asp:UpdatePanel ID="UpdatePanelTareas" runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-6">
                                                <label for="txtTareas">Tareas: </label>
                                                <asp:ListBox ID="lstTareas" runat="server" CssClass="form-control" SelectionMode="Multiple" Rows="10" AutoPostBack="True"></asp:ListBox>
                                                <br />
                                                <asp:Button ID="btnTareaAgregar" runat="server" Text="Agregar Seleccionado" CssClass="btn btn-instagram m-t-3 center-block" OnClick="btnTareaAgregar_Click" />
                                            </div>
                                            <div class="col-md-6">
                                                <label for="txtTareas">Seleccionadas : </label>
                                                <asp:ListBox ID="lstTareasSelect" runat="server" CssClass="form-control" SelectionMode="Multiple" Rows="10" AutoPostBack="false"></asp:ListBox>
                                                <asp:Label ID="lbltareaSelect" runat="server"></asp:Label>
                                                <br />
                                                <asp:Button ID="btnTareaEliminar" runat="server" Text="Eliminar Seleccionado" CssClass="btn btn-instagram m-t-3 center-block" OnClick="btnTareaEliminar_Click" />
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnTareaAgregar" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnTareaEliminar" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <h5 class="modal-title">Materiales Utilizados: </h5>
                                <div class="form-group col-md-12">
                                    <asp:UpdatePanel ID="UpdatePanelMateriales" runat="server">
                                        <ContentTemplate>
                                            <div class="form-group col-md-6">
                                                <label for="txtMaterialesSelect">Materiales : </label>
                                                <asp:ListBox ID="lstMaterialAgregar" runat="server" CssClass="form-control" SelectionMode="Multiple" Rows="10"></asp:ListBox>
                                                <asp:Label ID="lblMaterialAgregar" runat="server"></asp:Label>
                                                <br />
                                                <asp:Button ID="btnMaterialesSelect" runat="server" Text="Agregar Seleccionado" CssClass="btn btn-instagram m-t-3 center-block" OnClick="btnMaterialesSelect_Click" />
                                            </div>
                                            <div class="form-group col-md-2">
                                                <br />
                                                <label for="txtCantidad">Cant:</label>
                                                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" PlaceHolder="Ingrese Cantidad"></asp:TextBox>
                                                <asp:Label ID="lblCantidad" runat="server"></asp:Label>
                                            </div>
                                            <div class="row">
                                                <div class="form-control col-md-12">
                                                    <label for="txtMateriales">Materiales Seleccionados : </label>
                                                    <h4>
                                                        <asp:Label ID="lblMaterialSelect" runat="server" CssClass="font-normal"></asp:Label></h4>
                                                    <asp:GridView ID="grvDataMaterialSelect" runat="server" DataKeyNames="IdDetalle,IdTarea,CodiMarca,nom_material,cantidad" AutoGenerateColumns="False" OnRowEditing="grvDataMaterialSelect_RowEditing"
                                                        OnRowCancelingEdit="grvDataMaterialSelect_RowCancelingEdit" OnRowUpdating="grvDataMaterialSelect_RowUpdating" CssClass="table table-striped table-bordered dataTable">
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIdTarea" runat="server" Text='<%# Eval("IdTarea") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nro.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCodiMarca" runat="server" Text='<%# Eval("CodiMarca") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="150px"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Descripción">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNombreMaterial" runat="server" Text='<%#Eval("nom_material") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:BoundField DataField="cantidad" HeaderText="Cantidad">
                                                                    <ItemStyle Width="150px"></ItemStyle>
                                                                </asp:BoundField>--%>
                                                            <asp:CommandField ShowEditButton="true" UpdateText="Actualizar" CancelText="cancelar" EditText="Editar" />
                                                            <asp:TemplateField HeaderText="Cantidad">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCantidad" runat="server" Text='<%#Eval("cantidad") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtCantidadRow" runat="server" Text='<%#Eval("cantidad") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemStyle Width="150px"></ItemStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                            <%--<div class="form-group col-md-2">
                                                          <label for="txtCantidad">Cant. x Material: </label>
                                                           <asp:ListBox ID="lstCantidad" runat="server" CssClass="form-control" Rows="10" AutoPostBack="true"></asp:ListBox>
                                                          </div>--%>
                                        </ContentTemplate>
                                        <Triggers>
                                            <%--<asp:AsyncPostBackTrigger  ControlID="lstMaterialSelect" EventName="SelectedIndexChanged" />--%>
                                            <asp:AsyncPostBackTrigger ControlID="btnMaterialesSelect" EventName="Click" />
                                            <%-- <asp:AsyncPostBackTrigger   ControlID="btnMaterialEliminar" EventName="Click"/>--%>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>

                            </div>
                        </div>
                        <div class="form-group col-lg-12">
                            <div class="col-lg-12 text-center">
                                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-instagram m-t-5" Text="Guardar" OnClick="btnGuardar_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </asp:View>



                <asp:View ID="View3" runat="server">
                    <div class="col-md-8 col-md-offset-2">
                        <div class="card-box">

                            <div class="row">

                                <div class="col-md-12">
                                    <div class="col-lg-12">

                                        <div class="row">
                                            <div class="col-lg-8">
                                                <h4 class="header-title m-t-0">Apertura Orden de Trabajo</h4>
                                                <p class="text-muted font-13 m-b-10">
                                                    Registra la informacion que corresponde al mantenimiento de unidades
                                       
                                                </p>
                                            </div>

                                            <div class="col-lg-4">
                                                <asp:Button ID="btnGuardarApertura" ValidationGroup="registrar"
                                                    CssClass="btn btn-primary" runat="server"
                                                    Text="Registrar" OnClick="btnGuardarApertura_Click" />
                                                <asp:Button ID="Button2" CssClass="btn btn-default" runat="server" Text="Regresar" UseSubmitBehavior="False" OnClick="Button2_Click" />
                                                <asp:HiddenField ID="HFCodigo" runat="server" Value="0" />
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="form-group col-lg-6">
                                            <label for="userName">Tipo Apertura </label>

                                            <asp:DropDownList ID="ddlTipoApertura" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoApertura_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Text="--SELECCIONE TIPO APERTURA ---"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="REGISTRO PROPIO"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="DERIVAR"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>




                                        <div class="form-group col-lg-6">
                                            <label>Proveedor</label>
                                            <asp:DropDownList required CssClass="form-control" ID="ddlApeProveedor" runat="server">
                                            </asp:DropDownList>
                                        </div>

                                        <div class="form-group col-lg-6">
                                            <label>Placa</label>
                                            <%--<asp:TextBox required CssClass="form-control autocomplete" data-url="BuscarUnidad.ashx" ID="txtUnidad" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtUnidad_id" runat="server" class="form-control" Style="color: #CCC; position: absolute; background: transparent; z-index: 1; display: none;"></asp:TextBox>--%>
                                            <asp:TextBox ID="txtUnidad" runat="server" CssClass="form-control" placeholder="Ingresa Placa"></asp:TextBox>

                                        </div>

                                        <div class="form-group col-lg-12">
                                            <label>Descripcion previa de la falla</label>
                                            <asp:TextBox required CssClass="form-control" ID="txtDescripcion" runat="server" TextMode="MultiLine"></asp:TextBox>
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
    <style type="text/css">
        #ui-datepicker-div {
            z-index: 9999;
            clip: auto;
        }
    </style>
    <script type="text/javascript">
        //$(function () {
        //    $("#datetimepicker3").datetimepicker({
        //        format: 'LT'

        //    });
        //});

    </script>

</asp:Content>


