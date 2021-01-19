<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="aprobacion.aspx.cs" Inherits="Modulos_Vacaciones_aprobacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!--Morris Chart CSS -->
    <link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <div class="row">
    <div class="col-xs-12">
        <div class="page-title-box">
            <h4 class="page-title">Módulo Vacaciones </h4>
            <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Inicio</a>
                    </li>
                    <li>
                        <a href="#">Vacaciones</a>
                    </li>
                    <li class="active">Consulta Aprobaciones
                    </li>
                </ol>
            <div class="clearfix"></div>
        </div>
    </div>
 </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box table-responsive">
                <asp:HiddenField ID="hfSolicitante" runat="server" />
                <asp:HiddenField id="hfRespuesta" runat="server"/>
                <asp:Panel runat="server" ID="pnl1" Visible="false">
                    <div class="col-sm-12 m-b-20">
                        <h3 class="header-title">Informe de aprobacion de Vacaciones </h3>
                    </div>
                
                    <asp:gridview id="grvPendientes" runat="server" autogeneratecolumns="False"  OnRowCommand="grvPendientes_RowCommand" OnRowDataBound="grvPendientes_RowDataBound" OnPreRender="grvPendientes_PreRender"
                        cssclass="table table-striped table-bordered dataTable" gridlines="None">
                            <Columns>
                                <asp:BoundField DataField="fila" HeaderText="N°" Visible="false" />
                                <asp:BoundField DataField="id_aprobacion" HeaderText="idAprobacion" Visible="false" />
                                <asp:BoundField DataField="id_solicitud" HeaderText="Codigo de solicitud" Visible="false"  />
                                <asp:BoundField DataField="id_evaluador" HeaderText="idEvaluador" Visible="false" />
                                <asp:BoundField DataField="id_solicitante" HeaderText="id_solicitante" visible="false"/>
                                <asp:BoundField DataField="nom_solicitante" HeaderText="Nombre Solicitante" visible="true"/>
                                <asp:BoundField DataField="id_empleado" HeaderText="id_emp" visible="false"/>
                                <asp:BoundField DataField="nom_empleado" HeaderText="Nombre Empleado" visible="true"/>
                                <asp:BoundField DataField="fch_inicio" HeaderText="Fecha Inicio" />
                                <asp:BoundField DataField="fch_fin" HeaderText="Fecha Termino" />
                                <asp:BoundField DataField="total_dias" HeaderText="#Días" />
                                <asp:BoundField DataField="fch_ingreso" HeaderText="Fecha Ingreso" />
                                <asp:BoundField DataField="dpto_laboral" HeaderText="Dpto Laboral" />
                                <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("estado") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="30px">
                                            <itemtemplate>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 0 2px;">
                                                            <asp:linkbutton id="btnaprobar" commandargument='<%#Eval("id_aprobacion")+";"+Eval("nom_solicitante")+";"+Eval("fch_inicio")+";"+Eval("fch_fin")+";"+Eval("total_dias")%>' cssclass="btn btn-primary waves-effect waves-light btn-teal m-b-5"   Visible="false" runat="server" commandname="Aprobar"><i class="glyphicon glyphicon-ok" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:linkbutton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:linkbutton id="btnrechazar" commandargument='<%#Eval("id_aprobacion")+";"+Eval("nom_solicitante")+";"+Eval("fch_inicio")+";"+Eval("fch_fin")+";"+Eval("total_dias")%>' cssclass="btn btn-primary waves-effect waves-light btn-danger m-b-5" Visible="false" runat="server" commandname="Rechazar"><i class="glyphicon glyphicon-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:linkbutton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </itemtemplate>
                                        </asp:TemplateField>
                            </Columns>
                        </asp:gridview>


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
                                    <p>Debe estar seguro antes de eliminar información del sistema</p>
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
                                    <p>Debe estar seguro antes de eliminar información del sistema</p>
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




            </asp:Panel>                
            </div>
    </div>
   </div>
        
    
    <%-- CONDUCTOR --%>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <!-- Google Charts js -->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
     <script type="text/javascript">
         

                                                    $(document).ready(function () {

                                                        $("input[id*='fch_fin']").change(function () {
                                                            $("input[id*='txtDias']").val();
                                                            var valor1 = $("input[id*='fch_inicio']").val();
                                                            var valor2 = $("input[id*='fch_fin']").val();

                                                            var parts = valor1.split('/');
                                                            var parts2 = valor2.split('/');

                                                            var valor3 = new Date(parts[2], parts[1] - 1, parts[0]);
                                                            var valor4 = new Date(parts2[2], parts2[1] - 1, parts2[0]);
                                                            var newdate = new Date(valor3);
                                                            var newdate2 = new Date(valor4);

                                                            var diasdif= newdate2.getTime()-newdate.getTime();
	                                                        var contdias = Math.round(diasdif/(1000*60*60*24));

                                                            $("input[id*='txtDias']").val(contdias+1);
                                                        });

                                                        $(".tooltip_html").each(function (index) {
                                                            var html = $(this).parent().find(".infoHTML").html();
                                                            $(this).tooltipster({
                                                                content: $(html),
                                                                minWidth: 200,
                                                                maxWidth: 300,
                                                                position: 'top',
                                                                contentAsHTML: true,
                                                                interactive: true
                                                            });
                                                        });
                                                    });


    </script>
</asp:Content>
