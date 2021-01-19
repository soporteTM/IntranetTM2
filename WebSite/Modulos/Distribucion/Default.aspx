<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modulos_Distribucion_Default" %>

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

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">

            <div class="page-title-box">
                <h4 class="page-title">Modulo de Registro de Solicitudes </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Inicio</a>
                    </li>
                    <li>
                        <a href="#">Distribución</a>
                    </li>
                    <li class="active">Registro de Solicitudes
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
                            <h4 class="m-t-0 header-title"><b>Distribución</b></h4>
                            <p class="text-muted font-13 m-b-30">
                               Registrar la solicitud de transporte
                            </p>
                        </div>
                    
                    <div class="panelOptions col-sm-6" style="text-align: right;">

                             <asp:LinkButton ID="LinkButton1" CssClass="btn btn-info waves-effect waves-light m-b-5" runat="server" OnClick="LinkButton1_Click">
                             <i class="fa fa-plus m-r-5"></i> <span> Agregar </span></asp:LinkButton>
                    </div>
                        <div class="clearfix"></div>
                       
                    </div>
                   
                </div>
            </div>
         
            <div id="infoModalAlert1" tabindex="-1" role="dialog" class="modal fade">
               <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                           <button type="button" class="close" data-dismiss="modal">
                              <span aria-hidden="true">×</span>
                              <span class="sr-only">Close</span>
                           </button>
                             <h4 class="modal-title m-t-0">Solicitud de Transporte</h4>

                        </div>
                        <div class="modal-body">
                           <span class="text-primary icon icon-info-circle icon-5x"></span>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-12">
                                         <label for="userName">Fecha Programada:</label>
                                        <div class="input-group">
                                        <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span></span>
                                        <asp:textbox required spellcheck="false" placeholder="Fecha Programada" data-provide="datepicker" cssclass="form-control datepickers" id="fch_inicio" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                </div>
                                <div class="form-group">
                                     <div class="row">
                                        <div class="col-lg-4">
                                           <label for="userName">Orden Viaje:</label>
                                            <asp:TextBox ID="txtorden" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-4">
                                            <label for="userName">Origen:</label>
                                              <asp:DropDownList ToolTip="Seleccionar Origen" required CssClass="form-control" ID="ddlOrigen" runat="server">
                                             </asp:DropDownList>
                                        </div>
                                         <div class="col-lg-4">
                                            <label for="userName">Destino:</label>
                                              <asp:DropDownList ToolTip="Seleccionar Destino" required CssClass="form-control" ID="ddlDestino" runat="server">
                                             </asp:DropDownList>
                                        </div>
                                    
                                </div>
                           </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-4">
                                           <label for="userName">Tipo Unidad:</label>
                                           <asp:DropDownList ToolTip="Seleccionar Unidad" required CssClass="form-control" ID="ddlUnidad" runat="server">
                                             </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-4">
                                            <label for="userName">Pick Ticket:</label>
                                            <asp:TextBox ID="txtticket" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                         <div class="col-lg-4">
                                            <label for="userName">Contenedor:</label>
                                              <asp:TextBox ID="txtcontenedor" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <label for="userName">GR Sodimac:</label>
                                            <asp:TextBox ID="txtsodimac" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6">
                                        <label for="userName">GR Transporte:</label>
                                            <asp:TextBox ID="txttransporte" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-12">
                                        <label for="userName">Observaciones </label>
                                        <asp:TextBox  spellcheck="false"  CssClass="form-control col-12" ID="txtObservaciones" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                    </div>
                                    <br />
                                    <div class="col-lg-12 text-right">
                                        <asp:LinkButton ID="btnAsignar" CssClass="btn btn-instagram m-t-5 "  runat="server" Text="Solicitar" ></asp:LinkButton>
                                    </div>
                                </div>
                            </div> 
                        </div>
                        <div class="modal-footer">

                        </div>
                    </div>
                </div>
            </div>

         </asp:View>

              
     </asp:MultiView>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

