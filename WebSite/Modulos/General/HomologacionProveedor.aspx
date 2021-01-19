<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="HomologacionProveedor.aspx.cs" Inherits="Modulos_General_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
.content
{
    background-image:url('Images/bgTM_operaciones.png');
    background-position:center center;
    background-size:cover; 
}
iframe{
    position:absolute;
    left:225px;
    bottom:0px;
    width:85%;
    /*right:50px;*/
    top:70px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<iframe width="100%" height="100%" frameborder="0" src="http://10.93.185.22/extranetproveedores/Modulos/Reporte/Analistas.aspx?iframe=1"></iframe>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

