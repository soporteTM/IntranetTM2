<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>


<!DOCTYPE html>
<html>

<head id="Head1" runat="server">

    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
 
    <!-- App favicon -->
    <link rel="shortcut icon" href="App_Themes/zircos/default/assets/images/RosaNautica.ico">
    <!-- App title -->
    <title>Intranet :: Transportes Meridian</title>

    <!-- App css -->
    <link href="~/App_Themes/zircos/default/assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/zircos/default/assets/css/core.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/zircos/default/assets/css/components.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/zircos/default/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/zircos/default/assets/css/pages.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/zircos/default/assets/css/menu.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/zircos/default/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/zircos/default/assets/plugins/switchery/switchery.min.css" rel="stylesheet" type="text/css" >
 
    <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->

    <script src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/js/modernizr.min.js")%>' type="text/javascript"></script>
 
    
</head>
<body style="height:100%; background:url(http://www.tmeridian.com.pe/img/principales/nosotros-fondo.jpg) no-repeat 0 0; background-size:cover;">

    <style type="text/css">
        .form-control {
            display: block;
            width: 100%;
            height: 34px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            background-color: transparent;
            /* background-image: none; */
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }

        .account-pages {
            box-shadow: 0 0 24px 0 rgba(0, 0, 0, 0.7), 0 1px 0 0 rgba(0,0,0,.02);
            border-radius: 5px;
        }

       .account-logo-box {
        background-color : transparent;
        padding: 10px;
        border-radius: 5px 5px 0 0;
    }
    </style>

    <form id="form1" runat="server" data-toggle="md-validator">

           <!-- HOME -->
        <section>
            <div class="container-alt">
                <div class="row">
                    <div class="col-sm-12">

                        <div class="wrapper-page">

                            <div class="m-t-40 account-pages" style="background-color:rgba(255, 255, 255, 0.8);">
                                <div class="text-center account-logo-box">
                                    <h2 class="text-uppercase">
                                        <a href="index-2.html" class="text-success">
                                            <span><img src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/images/meridian3.png")%>' style="height: 90px;" alt="" ></span>
                                        </a>
                                    </h2>
                                    <!--<h4 class="text-uppercase font-bold m-b-0">Sign In</h4>-->
                                </div>
                                  <div class="account-content">
                                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

        <asp:View ID="View1" runat="server">

            <div class="form-horizontal">

                                        <div class="form-group ">
                                            <div class="col-xs-12">
 
                                                <asp:TextBox placeholder="Usuario" required CssClass="form-control" ID="txtUsuario" spellcheck="false" autocomplete="off" data-msg-required="Ingresar email."   title="Ingrese su nombre de usuario" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="col-xs-12">
                                                
                                                <asp:TextBox placeholder="Contraseña" required minlength="4" data-msg-minlength="Password must be 6 characters or more." data-msg-required="Please enter your password." CssClass="form-control" ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="form-group ">
                                            <div class="col-xs-5">
                                                <div class="checkbox checkbox-success">
                                                    <input runat="server" id="remember" type="checkbox" checked>
                                                    <label for="remember">
                                                       Recordarme
                                                    </label>
                                                </div>

                                            </div>

                                            <div class="col-sm-7" style="padding-top:5px;">
                                                
                                                <asp:LinkButton ID="LinkButton1" CssClass="text-muted" style="float:right;" runat="server" OnClick="LinkButton1_Click"><i class="fa fa-lock m-r-5"></i>¿Olvidaste tu contraseña?</asp:LinkButton>
                                                 </div>
                                        </div>

                                      

                                        <div class="form-group">
                                            <div class="col-xs-12" style="text-align:center;">
                                             
                                                  <asp:Button ID="Button4" CssClass="btn w-md btn-bordered btn-primary waves-effect waves-light" style=" position:relative;"
                                runat="server" Text="Ingresar" onclick="btnIngresar_Click" />
                                            </div>
                                        </div>

                                    </div>

              
            


 

        </asp:View>


        <asp:View ID="View2" runat="server">

            <h3 class="login-heading">RECUPERAR CONTRASEÑA</h3>
        <div class="login-form">
          
            <div class="form-group"> 
               <label>Email address</label>
                <asp:TextBox spellcheck="false" autocomplete="off" data-msg-required="Please enter your email address." required CssClass="form-control" ID="txtRecuperarUsuario" runat="server"></asp:TextBox>
                
              <span class="md-help-block">We'll send you an email to reset your password.</span>
            </div>

             <asp:Button ID="Button1" CssClass="btn btn-primary btn-block" runat="server" Text="Enviar contraseña" />
                            <asp:Button CssClass="btn btn-default btn-block" ID="Button2" runat="server" Text="Regresar al login" CausesValidation="False" UseSubmitBehavior="False" OnClick="Button2_Click" />

 
           
        </div>


         

        </asp:View>

        <asp:View ID="View3" runat="server">
            <div class="form-horizontal">
                <div class="form-group ">
                    <div class="col-xs-12">
                        <asp:TextBox placeholder="Usuario" required CssClass="form-control" ID="txtActUsuario" spellcheck="false" autocomplete="off" data-msg-required="Ingresar email."   title="Ingrese su nombre de usuario" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-xs-12">                        
                        <asp:TextBox placeholder="Contraseña" required minlength="4" data-msg-minlength="Password must be 6 characters or more." data-msg-required="Please enter your password." CssClass="form-control" ID="txtActContraseña" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-xs-12">                        
                        <asp:TextBox placeholder="Nueva Contraseña" required minlength="4" data-msg-minlength="Password must be 6 characters or more." data-msg-required="Please enter your password." CssClass="form-control" ID="txtActNuevaContraseña" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-xs-12">                        
                        <asp:TextBox placeholder="Repetir Nueva Contraseña" required minlength="4" data-msg-minlength="Password must be 6 characters or more." data-msg-required="Please enter your password." CssClass="form-control" ID="txtActRepetir" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>


                <div class="form-group">
                    <div class="col-xs-12" style="text-align:center;">                         
                        <asp:Button ID="Button3" CssClass="btn w-md btn-bordered btn-primary waves-effect waves-light" style=" position:relative;" runat="server" Text="Procesar" onclick="Button3_Click" />
                    </div>
                </div>
                </div>
        </asp:View>

        


    </asp:MultiView>
                              
                                    

                                    <div class="clearfix"></div>

                                </div>
                            </div>
                            <!-- end card-box-->


                            <div class="row m-t-50">
                                <div class="col-sm-12 text-center">
                                    <p class="text-muted"> &copy; Todos los derechos son reservados</p>
                                </div>
                            </div>

                        </div>
                        <!-- end wrapper -->

                    </div>
                </div>
            </div>
          </section>
          <!-- END HOME -->

 
 

          <script>
            var resizefunc = [];
        </script>

        <!-- jQuery  -->
        <script type="text/javascript" src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/js/jquery.min.js")%>'></script>
        <script type="text/javascript" src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/js/bootstrap.min.js")%>'></script>
        <script type="text/javascript" src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/js/detect.js")%>'></script>
        <script type="text/javascript" src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/js/fastclick.js")%>'></script>
        <script type="text/javascript" src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/js/jquery.blockUI.js")%>'></script>
        <script type="text/javascript" src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/js/waves.js")%>'></script>
        <script type="text/javascript" src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/js/jquery.slimscroll.js")%>'></script>
        <script type="text/javascript" src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/js/jquery.scrollTo.min.js")%>'></script>

        <!-- App js -->
        <script type="text/javascript" src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/js/jquery.core.js")%>'></script>
        <script type="text/javascript" src='<%=ResolveClientUrl("~/App_Themes/zircos/default/assets/js/jquery.app.js")%>'></script>
          
 
    </form>
</body>
</html>
