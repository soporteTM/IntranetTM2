<%@ Page Language="C#"  MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Alertas.aspx.cs" Inherits="Modulos_Alertas_Alertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!--Morris Chart CSS -->
    <link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title"> Alertas </h4>              
                <div class="clearfix"></div>
                
            </div>
        </div>
    </div>
    <!-- end row -->


    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-sm-12">
                    <div class="clearfix"></div>

                    <%-- Grid View Alerta --%>
                    <asp:GridView ID="grvAlertas" runat="server" AutoGenerateColumns="False"
                        CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="grvAlertas_PreRender">

                        <Columns>
                            <asp:BoundField DataField="id_alerta" HeaderText="ID" Visible="false" />
                            <asp:BoundField DataField="id_codigo" HeaderText="Código" Visible="false" />
                            <asp:BoundField DataField="ale_encabezado" HeaderText="Tipo Alerta" />
                            <asp:BoundField DataField="ale_mensaje" HeaderText="Mensaje" />

                        </Columns>

                    </asp:GridView>
                    <%-- Fin Grid View Alerta --%>

                    <div class="clearfix"></div>

                    <div class="col-lg-12">
                        <div class="alert alert-icon alert-info alert-dismissible fade in" role="alert">
                            <i class="mdi mdi-information"></i>
                            <strong>Usted tiene</strong>
                            <asp:Label ID="lblmsg" runat="server" Text="" Font-Bold="true" Font-Size="15"></asp:Label><strong>notificacione(s)</strong>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <!-- Google Charts js -->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <!-- Init -->
  <%--  <script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/initReportes.js")%>'></script>--%>
</asp:Content>