<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Ticket.aspx.cs" Inherits="Modulos_Combustible_Ticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
            function imprimirDocumento(numeroDeCopias) {
                var count = 0;
                while (count < numeroDeCopias) {
                    window.print(0);
                    count++;
                }
            }
        </script>

        <style type="text/css">
            body{
                font-family: 'Cairo', sans-serif;
                font-size: 13px;
                font-style: normal;
                font-weight: 400;
                line-height: 1.5;
            }

            .m-t-30 {
                margin-top: 0px!important;
            }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
                            <div class="col-md-12">
                                <div class="panel panel-default">
                                    <!-- <div class="panel-heading">
                                        <h4>Invoice</h4>
                                    </div> -->
                                    <div class="panel-body">
                                        <div class="clearfix">
                                            <div class="text-center">
                                                <h3><img src="../../App_Themes/zircos/default/assets/images/logo_tm_v2.png" alt="" height="80"></h3>
                                            </div>
                                            <div class="text-center">
                                                <p class="text-center">TRANSPORTES MERIDIAN S.A.C<br>
                                                <p class="text-center">Av. Oquendo Mza H-L. Ex Fundo Oquendo – Callao (alt. Km 8.5 Nestor Gambetta)<br>
                                                <p class="text-center">CALLAO-CALLAO.<br>
                                                <p class="text-left">--------------------------------------------<br>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">

                                                <div class="pull-left m-t-30">
                                                    <address>
                                                      <b>Ticket </b><br>
                                                      <b>Fecha Emision : </b><br>
                                                      <b>RUC :</b><br>
                                                      <b>Razon Social :</b><br>
                                                      <b>Unidad : </b><br>
                                                      <b>Placa : </b><br>
                                                      <b>Conductor : </b><br>
                                                      <b>Km : </b><br>
                                                      <b>Horometro : </b><br>
                                                      <b>Cantidad Gl. </b><br>
                                                      <b>Precio Gl.</b><br> 
                                                      <b>Importe Total:</b><br>                                                                                                             
                                                      </address>
                                                </div>
                                                <div class="pull-right m-t-30">
                                                    <asp:Label ID="lblNroTicket" runat="server" Text="[Nro Ticket]"></asp:Label><br>
                                                    <asp:Label ID="lblFechaEmision" runat="server" Text="[Fecha Emision]"></asp:Label><br>
                                                    <asp:Label ID="lblRUC" runat="server" Text="[RUC]"></asp:Label><br>
                                                    <asp:Label ID="lblEmpresa" runat="server" Text="[Razon Social]"></asp:Label><br>
                                                    <asp:Label ID="lblUnidad" runat="server" Text="[Unidad]"></asp:Label><br>
                                                    <asp:Label ID="lblPlaca" runat="server" Text="[Placa]"></asp:Label><br>
                                                    <asp:Label ID="lblConductor" runat="server" Text="[Conductor]"></asp:Label><br>
                                                    <asp:Label ID="lblkm" runat="server" Text="[km]"></asp:Label><br>
                                                    <asp:Label ID="lblHorometro" runat="server" Text="[Horometro]"></asp:Label><br>
                                                    <asp:Label ID="lblCantidad" runat="server" Text="[Cantidad]"></asp:Label><br>
                                                    S/.<asp:Label ID="lblPrecio" runat="server" Text="[Precio]"></asp:Label><br>
                                                    S/.<asp:Label ID="lblImporte" runat="server" Text="[Importe]"></asp:Label><br>                                                    
                                                </div>
                                                
                                            </div><!-- end col -->
                                            
                                        </div>

                                        <div class="clearfix">
                                            <div class="text-center">
                                                <p class="text-left">--------------------------------------------<br>
                                                <p class="text-center">***Gracias por su compra***<br>
                                                <p class="text-left">Sus comprobantes podras ser consultados en nuestra web : www.tmeridian.com.pe en la seccion de Consulta tu Facturacion.<br>
                                                    </div>
                                            </div>
                                        <!-- end row -->

                                        <div class="m-h-50"></div>
                                        
                                        
                                        <hr>
                                        <div class="hidden-print">
                                            <div class="pull-right">
                                                <a href="javascript:imprimirDocumento(2)" class="btn btn-inverse waves-effect waves-light"><i class="fa fa-print"></i></a>
                                                
                                                <asp:Button ID="btnRegresar" CssClass="btn btn-primary" runat="server" Text="Cancelar" OnClick="btnRegresar_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

