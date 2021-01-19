<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="cliente_default2" EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .card-actions {
            margin-top: -15px;
        }

        .md-form-group {
            margin-bottom: 0px !important;
        }

        .parsley-errors-list {
            display: none !important;
        }

        .wizard.vertical > .steps {
            width: 100%;
        }

        .wizard > .steps .current a {
            background: #2184be;
        }

        .wizard > .steps a {
            text-align: left;
            padding-left: 60px;
        }

            .wizard > .steps a:hover {
                text-align: left;
                padding-left: 60px;
            }

        .wizard > .steps .number {
            left: 3px;
        }

        .form-control {
            border: 1px solid #e3e3e3;
            border-radius: 4px;
            padding: 6px 6px;
            height: auto !important;
            max-width: 100%;
            font-size: 12px;
            -webkit-box-shadow: none;
            box-shadow: none;
            -webkit-transition: all 300ms linear;
            -moz-transition: all 300ms linear;
            -o-transition: all 300ms linear;
            -ms-transition: all 300ms linear;
            transition: all 300ms linear;
            background-color: #fbfbfb;
        }

        select.form-control {
            padding: 6px 1px;
        }

        #mapa {
            max-width: 1200px;
            height: 350px;
        }

        tr.selected {
            background-color: #337ab7 !important;
            color: white;
        }

            tr.selected a {
                color: white;
            }

        .modalArchivo .modal-dialog {
            max-width: 420px !important;
        }

        textarea.form-control {
            min-height: 40px;
            resize: none;
        }

        .tooltipster-content {
            color: #797979 !important;
        }

        .tooltipster-sidetip .tooltipster-box {
            border: 1px solid #ccc !important;
            background-color: #f3f3f3 !important;
        }

        .tooltipster-sidetip.tooltipster-top .tooltipster-arrow-border, .tooltipster-sidetip.tooltipster-top .tooltipster-arrow-background {
            border-top-color: #ccc !important;
        }

        .infoHTML table td {
            padding: 3px !important;
        }

        .noBorder {
            padding: 0px !important;
            border: none !important;
        }

            .noBorder table {
                margin: 0px !important;
                border: none;
            }

        .nav-tabs > li.active > a, .nav-tabs > li.active > a:focus, .nav-tabs > li.active > a:hover {
            background-color: #2184be !important;
            border: 1px solid #188ae2 !important;
        }

            .nav-tabs > li.active > a, .nav-tabs > li.active > a:focus, .nav-tabs > li.active > a:hover {
                color: #ffffff !important;
            }

        .nav-tabs {
            border-bottom: 2px solid #2184be;
        }

        .tab-content > .tab-pane {
            display: block;
        }

        .nav > li > a {
            padding: 10px 13px;
        }
        /* .nav-tabs>li{
            margin-bottom:-2px;
        }*/
    </style>
    <!--Form Wizard-->
    <script src="https://maps.google.com/maps/api/js?key=AIzaSyBnmF4GN6B8ks5fmASxUBpbL1bioRCdeHA&libraries=places&region=pe&language=es"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Modulo de Empleados </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Empleados</a>
                    </li>
                    <li class="active">Busqueda
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
                        <div class="form-group col-lg-6">
                            <label for="userName">Estado </label>
                            <asp:DropDownList CssClass="form-control" ID="ddlEstadoPersonal" runat="server" OnSelectedIndexChanged="ddlEstadoPersonal_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="panelOptions col-sm-6" style="text-align: right;">
                            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default waves-effect waves-light m-b-5" runat="server" OnClick="btnNuevo_Click">
                                <i class="fa fa-plus m-r-5"></i> <span> Agregar empleado</span> </asp:LinkButton>

                            <asp:LinkButton ID="btnExportar" CssClass="btn btn-success waves-effect waves-light m-b-5" runat="server" OnClick="btnExportar_Click"> 
                                <i class="fa fa-file m-r-5"></i> <span>Exportar  </span> </asp:LinkButton>
                        </div>

                        <div class="clearfix"></div>

                        <asp:GridView ID="gvMarcas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered example" GridLines="None"
                            OnRowCommand="gvMarcas_RowCommand" OnPreRender="gvMarcas_PreRender" OnRowDataBound="gvMarcas_RowDataBound">

                            <Columns>
                                <asp:BoundField Visible="false" DataField="cod_id" HeaderText="Codigo" />
                                <asp:TemplateField HeaderText="Foto" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" CssClass="img-responsive img-thumbnail img-circle" alt="image" Width="30px" Style="padding: 0px;" ImageUrl='<%# Eval("img_personal") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="apellido_pat" HeaderText="Ap. Paterno" />
                                <asp:BoundField DataField="apellido_mat" HeaderText="Ap. Materno" />
                                <asp:BoundField DataField="nombre_emp" HeaderText="Nombres" />
                                <asp:BoundField DataField="nro_documento" HeaderText="Documento Identidad" />
                                <asp:BoundField DataField="Tipo_Persona" HeaderText="Tip. Persona" />
                                <asp:BoundField DataField="nacionalidad" HeaderText="Nacionalidad" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstadoEmp" runat="server" Text='<%# Eval("estado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="20px">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ToolTip="Editar Empleado" CommandArgument='<%# Eval("cod_id") %>' CommandName="editar" CssClass="icon-list-primary" ID="LinkButton2" runat="server"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <%--<td>
                                                    <asp:LinkButton ToolTip="Eliminar Empleado" OnClientClick="JConfirm('Debe estar seguro antes de eliminar información del sistema','¿Desea eliminar este empleado?',this); return false;" CommandArgument='<%# Eval("cod_id") %>' CommandName="eliminar" CssClass="icon-list-demo" ID="LinkButton3" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>--%>
                                                <td>
                                                    <asp:LinkButton ToolTip="Ver Documentación" CommandArgument='<%# Eval("cod_id") %>' CommandName="documento" CssClass="icon-list-primary m-l-10" ID="LinkButton2Ver" runat="server"><i class="ti-folder" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ToolTip="Ver EPPS" CommandArgument='<%# Eval("cod_id") %>' CommandName="EPPS" CssClass="icon-list-primary m-l-10" ID="LinkButton16" runat="server"><i class="mdi mdi-worker" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ToolTip="Descanso Médico" CommandArgument='<%# Eval("cod_id") %>' CommandName="descanso" CssClass="icon-list-primary m-l-10" ID="LinkButtonDes" runat="server"><i class="fa fa-plus-square" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                  <%--<td>
                                                    <asp:LinkButton ToolTip="EPP" CommandArgument='<%# Eval("cod_id") %>' CommandName="epp" CssClass="icon-list-primary m-l-10" ID="lnkIndumentaria" runat="server"><i class="fa fa-black-tie" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </asp:View>



        <asp:View ID="View2" runat="server">

            <div class="row">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">

                                <div class="col-lg-9">
                                    <h4 class="header-title">Registrar/Actualizar</h4>
                                </div>

                                <div class="col-lg-3" style="text-align: right;">
                                    <asp:Button ID="btnRegresar" OnClick="Button2_Click" CssClass="btn btn-warning" runat="server" Text="Regresar" UseSubmitBehavior="False" />
                                    <asp:LinkButton ID="btnGuardar" ValidationGroup="registrar" OnClick="Button1_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                                    <asp:HiddenField ID="HFCodigo" runat="server" Value="0" />
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>

                        <div class="panel-body">
                            <div class="col-md-12">
                                <ul class="nav nav-tabs">
                                    <li id="li1" runat="server" class="">
                                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click"><span class="visible-xs"><i class="fa fa-user"></i></span><span class="hidden-xs">1. Datos Personales</span></asp:LinkButton></li>
                                    <li id="li2" runat="server" class="">
                                        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click"><span class="visible-xs"><i class="fa fa-users"></i></span><span class="hidden-xs">2. Familiares y Dep.</span></asp:LinkButton></li>
                                    <li id="li3" runat="server" class="">
                                        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click"><span class="visible-xs"><i class="fa fa-graduation-cap"></i></span><span class="hidden-xs">3. Formación y Estudios</span></asp:LinkButton></li>
                                    <li id="li4" runat="server" class="">
                                        <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click"><span class="visible-xs"><i class="fa fa-suitcase"></i></span><span class="hidden-xs">4. Exp. Profesional</span></asp:LinkButton></li>
                                    <li id="li5" runat="server" class="">
                                        <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click"><span class="visible-xs"><i class="fa fa-credit-card-alt"></i></span><span class="hidden-xs">5. Info. Economica</span></asp:LinkButton></li>
                                    <li id="li7" runat="server" class="">
                                        <asp:LinkButton ID="LinkButton11" runat="server" OnClick="LinkButton11_Click"><span class="visible-xs"><i class="fa fa-building"></i></span><span class="hidden-xs">6. Datos Empresa</span></asp:LinkButton></li>
                                    <li id="li8" runat="server" class="">
                                        <asp:LinkButton ID="LinkButton14" runat="server" OnClick="LinkButton14_Click"><span class="visible-xs"><i class="fa fa-calendar-check-o"></i></span><span class="hidden-xs">7. Vacaciones </span></asp:LinkButton></li>
                                </ul>

                         <div class="tab-content">
                              <div class="tab-pane">
                                   <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">

                                         <asp:View ID="View1a" runat="server">
                                                <div class="col-md-9">

                                                    <div class="form-group">
                                                        <div class="row">
                                                            <div class="col-lg-4">
                                                                <label for="userName">Apellido Paterno:</label>
                                                                <label for="userName">Apellido Paterno:</label>
                                                                <asp:TextBox required CssClass="form-control" ID="txtApellidoPaterno" runat="server"></asp:TextBox>
                                                               
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <label>Apellido Materno:</label>
                                                                <asp:TextBox required CssClass="form-control" ID="txtApellidoMaterno" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <label>Nombres:</label>
                                                                <asp:TextBox  title="ingresar nombre" required CssClass="form-control" ID="txtNombres" runat="server"></asp:TextBox>
                                                            </div>

                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <div class="row">
                                                            <div class="col-lg-4">
                                                                <label class="md-control-label">Tipo Documento:</label>
                                                                <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlTipoDocumento" runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <label for="userName">Nro. Documento :</label>
                                                                <asp:TextBox title="ingresar nombre" required CssClass="form-control" ID="txtNumeroDocumento" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <label class="md-control-label">Fch. Nacimiento:</label>
                                                                <asp:TextBox required data-provide="datepicker" CssClass="form-control datepickers" ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                                                            </div>

                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <div class="row">
                                                            <div class="col-lg-2">
                                                                <label class="md-control-label">Sexo:</label>
                                                                <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlSexo" runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <label class="md-control-label">Estado Civil:</label>
                                                                <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlEstadoCivil" runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <label for="userName">Correo Personal:</label>
                                                                <asp:TextBox title="ingresar nombre" required CssClass="form-control" ID="txtCorreo" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <label for="userName">Teléfono Personal:</label>
                                                                <asp:TextBox title="ingresar nombre" required CssClass="form-control" ID="txtTelefonoPersonal" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <div class="row">
                                                            <div class="col-lg-4">
                                                                <label class="md-control-label">Pais:</label>
                                                                <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlPais" runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <label class="md-control-label">Departamento:</label>
                                                                <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlDepartamento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <label class="md-control-label">Provincia:</label>
                                                                <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>

                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <div class="row">
                                                            <div class="col-lg-4">
                                                                <label class="md-control-label">Distrito:</label>
                                                                <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlDistrito" runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-lg-8">
                                                                <label class="md-control-label">Dirección:</label>
                                                                <asp:TextBox required CssClass="form-control" ID="txtDireccion" runat="server"></asp:TextBox>
                                                            </div>

                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <div class="row">
                                                            <div class="col-lg-4">
                                                                <label for="userName">Urbanización :</label>
                                                                <asp:TextBox title="ingresar nombre" CssClass="form-control" ID="txtUrbanizacion" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <label>Nro.:</label>
                                                                <asp:TextBox CssClass="form-control" ID="txtNumero" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <label>Interior:</label>
                                                                <asp:TextBox CssClass="form-control" ID="txtInterior" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <label>Teléfono Domicilio:</label>
                                                                <asp:TextBox CssClass="form-control" ID="txtTelefono" runat="server"></asp:TextBox>
                                                            </div>

                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-3">

                                                    <div class="col-md-12">
                                                        <asp:Image ID="img" runat="server" Width="220" Height="200" ImageUrl="~/imagenes/no-user.png" />
                                                    </div>

                                                    <div class="col-md-12">
                                                        <div class="col-lg-12">
                                                            <label class="md-control-label">Foto:</label>
                                                            <asp:FileUpload ID="FUFotoPersonal" accept=".png, .jpg, .jpeg" CssClass="form-control" onchange="showimagepreview(this)" runat="server" />
                                                            <asp:HiddenField ID="HFFotoPersonal" runat="server" />
                                                        </div>
                                                    </div>

                                                </div>

                                             
                                                <div class="form-group" id="panelMapa">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="panel panel-default">
                                                                <div class="panel-heading">
                                                                    <h3 class="panel-title">Google Maps</h3>
                                                                    <p class="panel-sub-title font-13 text-muted">Ubica tu dirección en el mapa</p>
                                                                </div>
                                                                <div class="panel-body" style="position: relative; padding: 0px;">
                                                                    <asp:TextBox Style="position: absolute; left: 10px; top: 10px; z-index: 1; right: 10px; width: 98%;" CssClass="form-control" ID="buscar_mapa" runat="server"></asp:TextBox>
                                                                    <div style="display: none;">
                                                                        <asp:TextBox CssClass="form-control" ID="lat" runat="server"></asp:TextBox>
                                                                        <asp:TextBox CssClass="form-control" ID="lon" runat="server"></asp:TextBox>
                                                                    </div>
                                                                    <div id="mapa"></div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <script type="text/javascript"> 
                                                    function openMapa(distrito) {
                                                        $("#panelMapa").slideToggle("slow");
                                                    }


                                                    $(document).ready(function () {

                                                    var input_buscar_mapa = $("input[id*='buscar_mapa']").attr("id");
                                                    var geocoder = new google.maps.Geocoder();
                                                        var lat = ($("input[id*='lat']").val() == "" ? -12.0431800 : $("input[id*='lat']").val()),
                                                        lng = ($("input[id*='lon']").val() == "" ? -77.0282400 : $("input[id*='lon']").val()),
                                                        zoom = ($("input[id*='lon']").val() == "" ? 11 : 17),
                                                        latlng = new google.maps.LatLng(lat, lng),
                                                        image = '../../imagenes/Maps/map-marker.png';
         
                                                    var mapOptions = {           
                                                            center: new google.maps.LatLng(lat, lng),           
                                                            zoom: zoom,
                                                            mapTypeId: google.maps.MapTypeId.ROADMAP         
                                                        },
                                                        map = new google.maps.Map(document.getElementById('mapa'), mapOptions),
                                                        marker = new google.maps.Marker({
			                                                draggable: true,
			                                                animation: google.maps.Animation.DROP,
                                                            position: latlng,
                                                            map: map,
                                                            icon: image
                                                            });
		 
		                                                    marker.addListener('click', toggleBounce);
		 
		                                                    function toggleBounce() {
		                                                    if (marker.getAnimation() !== null) {
			                                                marker.setAnimation(null);
		                                                    } else {
			                                                marker.setAnimation(google.maps.Animation.BOUNCE);
		                                                    }
		                                                }
                                                        
		                                                 
                                                    var input = document.getElementById(input_buscar_mapa);
                                                    var autocomplete = new google.maps.places.Autocomplete(input, {
                                                        types: ["geocode"],
		                                                componentRestrictions: {country: "pe"}
                                                    });          
    
                                                    autocomplete.bindTo('bounds', map); 
                                                    var infowindow = new google.maps.InfoWindow(); 
 
                                                    google.maps.event.addListener(autocomplete, 'place_changed', function() {
                                                        infowindow.close(); 
                                                        var place = autocomplete.getPlace();
                                                        if (place.geometry.viewport) {
                                                            map.fitBounds(place.geometry.viewport);
			                                                //console.log(place.geometry);
                                                        } else {
                                                            map.setCenter(place.geometry.location);
			                                                //console.log(place.geometry);
                                                            map.setZoom(17);  
                                                        }
                                                        console.log(place.geometry.location);
                                                        moveMarker(place.name, place.geometry.location);
                                                        $("input[id*='lat']").val(place.geometry.location.lat());
                                                        $("input[id*='lon']").val(place.geometry.location.lng());
                                                    });  
	
	                                                google.maps.event.addListener(marker, 'dragend', function (event) {
	                                                    $("input[id*='lat']").val(this.getPosition().lat());
	                                                    $("input[id*='lon']").val(this.getPosition().lng()); 
		                                                var latlng_dir = new google.maps.LatLng(this.getPosition().lat(),this.getPosition().lng());
		                                                geocoder.geocode({latLng:latlng_dir},function(results,status){
			                                                if(status==google.maps.GeocoderStatus.OK){
				                                                if(results[0]){
				                                                    $("input[id*='buscar_mapa']").val(results[0].formatted_address);
				                                                }
			                                                }
		                                                });		
	                                                });
    
	                                                $("input[id*='buscar_mapa']").focusin(function () {
                                                        $(document).keypress(function (e) {
                                                            if (e.which == 13) {
                                                                infowindow.close();
                                                                var firstResult = $(".pac-container .pac-item:first").text();
                
                                                                var geocoder = new google.maps.Geocoder();
                                                                geocoder.geocode({"address":firstResult }, function(results, status) {
                                                                    if (status == google.maps.GeocoderStatus.OK) {
                                                                        var lat = results[0].geometry.location.lat(),
                                                                            lng = results[0].geometry.location.lng(),
                                                                            placeName = results[0].address_components[0].long_name,
                                                                            latlng = new google.maps.LatLng(lat, lng);
                        
                                                                        moveMarker(placeName, latlng); 
                                                                        $("input[id*='buscar_mapa']").val(firstResult);
                                                                        $("input[id*='lat']").val(lat);
                                                                        $("input[id*='lon']").val(lng);
                                                                    }
                                                                });
                                                            }
                                                        });
                                                    });
     
                                                    function moveMarker(placeName, latlng){
                                                        marker.setIcon(image);
                                                        marker.setPosition(latlng);
                                                        infowindow.setContent(placeName);
                                                        infowindow.open(map, marker);
                                                    }

                                                    //$("#panelMapa").hide();
                                                }); 
                                                </script>
                                            </asp:View>
                                            <asp:View ID="View2a" runat="server">

                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <div class="card-box table-responsive">
                                                            <div class="col-sm-8">
                                                                <h4 class="header-title"><b>Información de Familiares y Dependientes</b></h4>
                                                            </div>

                                                            <div class="panelOptions col-sm-4" style="text-align: right;">
                                                                <asp:LinkButton ID="LinkButton10" CssClass="btn btn-default waves-effect waves-light m-b-5"
                                                                    runat="server" OnClick="LinkButton10_Click">
                                                                   <i class="fa fa-plus m-r-5"></i> <span> Agregar familiar</span>  </asp:LinkButton>
                                                            </div>
                                                            <div class="clearfix"></div>

                                                            <asp:GridView ID="gvFamiliares" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvFamiliares_PreRender" OnRowDeleting="gvFamiliares_RowDeleting" OnRowCommand="gvFamiliares_RowCommand">

                                                                <Columns>
                                                                    <asp:BoundField  DataField="id_key" HeaderText="Key" Visible="false" />
                                                                    <asp:BoundField Visible="false" DataField="cod_id" HeaderText="cod_id" />
                                                                    <asp:BoundField Visible="false" DataField="cod_parentesco" HeaderText="IDParentesco" />
                                                                    <asp:BoundField DataField="opcional_parentesco" HeaderText="Parentesco" />
                                                                    <asp:BoundField DataField="fam_apellido_pat" HeaderText="Ap. Paterno" />
                                                                    <asp:BoundField DataField="fam_apellido_mat" HeaderText="Ap. Materno" />
                                                                    <asp:BoundField DataField="fam_nombre" HeaderText="Nombres" />

                                                                    <asp:BoundField DataField="edad" HeaderText="Edad" />

                                                                    <asp:BoundField Visible="false" DataField="fch_nacimiento" HeaderText="fch_nacimiento" />
                                                                    <asp:BoundField Visible="false" DataField="lugar_nacimiento" HeaderText="lugar_nacimiento" />
                                                                    <asp:BoundField Visible="false" DataField="cod_ocupacion" HeaderText="cod_ocupacion" />
                                                                    <asp:BoundField Visible="false" DataField="opcional_ocupacion" HeaderText="ocupacion" />
                                                                    <asp:BoundField Visible="false" DataField="lugar_trabajo" HeaderText="lugar_trabajo" />
                                                                    <asp:BoundField Visible="false" DataField="telf_of" HeaderText="telf_of" />
                                                                    <asp:BoundField Visible="false" DataField="telf_casa" HeaderText="telf_casa" />
                                                                    <asp:BoundField Visible="false" DataField="llamar_emergencia" HeaderText="llamar_emergencia" />
                                                                    <asp:BoundField DataField="opcional_llamar_emergencia" HeaderText="¿Llamar en emergencia?" />
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:LinkButton CommandArgument='<%# Eval("id_key")+";"+Eval("fam_apellido_pat")+";"+Eval("fam_apellido_mat")+";"+Eval("fam_nombre")+";"+Eval("cod_parentesco")+";"+Eval("fch_nacimiento")+";"+Eval("lugar_nacimiento")+";"+Eval("lugar_trabajo")+";"+Eval("telf_of")+";"+Eval("telf_casa")+";"+Eval("llamar_emergencia")%>' CommandName="editar" CssClass="icon-list-demo" ID="Edit" runat="server" OnClick="Edit_Click"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:LinkButton OnClientClick="JConfirm('','¿Desea eliminar este familiar?',this); return false;" CommandArgument='<%# Eval("id_key") %>' CommandName="Delete" CssClass="icon-list-demo" ID="LinkButton3" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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

                                                <div id="modalFamiliar" runat="server" tabindex="-1" role="dialog" class="modal fade modalFamiliar">
                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal">
                                                                    <span aria-hidden="true">×</span>
                                                                    <span class="sr-only">Close</span>
                                                                </button>

                                                                <h4 class="modal-title">Información de Familiar</h4>

                                                            </div>
                                                            <div class="modal-body">
                                                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            <label for="userName">Apellido Paterno:</label>
                                                                            <asp:TextBox required CssClass="form-control" ID="txtApellidoPaternoFamiliar" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-lg-6">
                                                                            <label>Apellido Materno:</label>
                                                                            <asp:TextBox required CssClass="form-control" ID="txtApellidoMaternoFamiliar" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            <label>Nombres:</label>
                                                                            <asp:TextBox required CssClass="form-control" ID="txtNombresFamiliar" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-lg-6">
                                                                            <label for="userName">Parentesco:</label>
                                                                            <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlParentesco" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            <label for="userName">Fch. Nacimiento:</label>
                                                                            <asp:TextBox required data-provide="datepicker" CssClass="form-control datepickers" ID="txtFechaNacimientoFamiliar" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-lg-6">
                                                                            <label>Lugar de Nacimiento:</label>
                                                                            <asp:TextBox required CssClass="form-control" ID="txtLugarNacimientoFamiliar" runat="server"></asp:TextBox>
                                                                        </div>

                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            <label>Lugar de Trabajo:</label>
                                                                            <asp:TextBox CssClass="form-control" ID="txtLugarTrabajoFamiliar" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-lg-3">
                                                                            <label for="userName">Tel. Oficina:</label>
                                                                            <asp:TextBox CssClass="form-control" ID="txtTelefonoOficinaFamiliar" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-lg-3">
                                                                            <label>Tel. Casa:</label>
                                                                            <asp:TextBox CssClass="form-control" ID="txtTelefonoCasaFamiliar" runat="server"></asp:TextBox>
                                                                        </div>

                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            <label>¿Llamar en caso de emergencia?</label>
                                                                            <asp:DropDownList required ToolTip="Seleccionar tipo" CssClass="form-control" ID="ddlLlamarEmergenciaFamiliar" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>


                                                            </div>
                                                            <div class="modal-footer">

                                                                <div class="m-t-lg">
                                                                    <asp:HiddenField ID="HFIDFamiliar" Value="0" runat="server" />
                                                                    <asp:HiddenField ID="txtAccionFamiliar"  runat="server" />
                                                                    <asp:Button ID="btnGuardarFamiliar" OnClick="btnGuardarFamiliar_Click" runat="server" Text="Continuar" CssClass="btn btn-primary" />
                                                                    <button class="btn btn-default" data-dismiss="modal" type="button">Cerrar</button>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </asp:View>
                                            <asp:View ID="View3a" runat="server">

                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <div class="card-box table-responsive">
                                                            <div class="col-sm-8">
                                                                <h4 class="header-title"><b>Información de Formación Academica y Educación</b></h4>
                                                            </div>

                                                            <div class="panelOptions col-sm-4" style="text-align: right;">
                                                                <asp:LinkButton ID="btnAgregarFormacion" CssClass="btn btn-default waves-effect waves-light m-b-5"
                                                                    runat="server" OnClick="btnAgregarFormacion_Click">
                                                                   <i class="fa fa-plus m-r-5"></i> <span> Agregar formación</span>  </asp:LinkButton>
                                                            </div>
                                                            <div class="clearfix"></div>

                                                            <asp:GridView ID="gvFormacion" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvFormacion_PreRender" OnRowDeleting="gvFormacion_RowDeleting" OnRowCommand="gvFormacion_RowCommand1">

                                                                <Columns>
                                                                    <asp:BoundField  DataField="id_key" HeaderText="Key" Visible="false" />
                                                                    <asp:BoundField  DataField="cod_id" HeaderText="cod_id" Visible="false" />
                                                                    <asp:BoundField  DataField="cod_grado_instruccion" HeaderText="cod_grado_instruccion" Visible="false" />
                                                                    <asp:BoundField DataField="opcional_instruccion" HeaderText="Grado de Instrucción" />
                                                                    <asp:BoundField DataField="cod_institucion" HeaderText="cod_institucion" Visible="false"  />
                                                                    <asp:BoundField DataField="opcional_institucion" HeaderText="Centro de Instrucción" />
                                                                    <asp:BoundField DataField="titulo" HeaderText="Título" />
                                                                    <asp:BoundField DataField="anio_inicio" HeaderText="Inicio" />
                                                                    <asp:BoundField DataField="anio_fin" HeaderText="Termino" />
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:LinkButton CommandArgument='<%# Eval("id_key") + ";"+Eval("cod_grado_instruccion")+";"+Eval("opcional_institucion")+";"+Eval("titulo")+";"+Eval("anio_inicio")+";"+Eval("anio_fin")%>' CommandName="editar" CssClass="icon-list-demo" ID="LinkButton2" OnClick="LinkButton2_Click1" runat="server"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:LinkButton OnClientClick="JConfirm('','¿Desea eliminar esta formación?',this); return false;" CommandArgument='<%# Eval("id_key") %>' CommandName="Delete" CssClass="icon-list-demo" ID="LinkButton3" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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

                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <div class="card-box table-responsive">
                                                            <div class="col-sm-8">
                                                                <h4 class="header-title"><b>Información de Idiomas</b></h4>
                                                            </div>

                                                            <div class="panelOptions col-sm-4" style="text-align: right;">
                                                                <asp:LinkButton ID="btnAgregarIdioma" CssClass="btn btn-default waves-effect waves-light m-b-5"
                                                                    runat="server" OnClick="btnAgregarIdioma_Click">
                                                                   <i class="fa fa-plus m-r-5"></i> <span> Agregar idioma</span>  </asp:LinkButton>
                                                            </div>
                                                            <div class="clearfix"></div>

                                                            <asp:GridView ID="gvIdioma" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvIdioma_PreRender" OnRowDeleting="gvIdioma_RowDeleting" OnRowCommand="gvIdioma_RowCommand">

                                                                <Columns>
                                                                    <asp:BoundField Visible="false" DataField="id_key" HeaderText="Key" />
                                                                    <asp:BoundField Visible="false" DataField="cod_id" HeaderText="cod_id" />
                                                                    <asp:BoundField Visible="false" DataField="cod_idioma" HeaderText="IDIdioma" />
                                                                    <asp:BoundField Visible="false" DataField="cod_nivel" HeaderText="IDNivel" />
                                                                    <asp:BoundField DataField="opcional_idioma" HeaderText="Idioma" />
                                                                    <asp:BoundField DataField="opcional_nivel" HeaderText="Nivel" />
                                                                    <asp:BoundField DataField="institucion" HeaderText="Institucion" />
                                                                    <asp:BoundField DataField="opcional_habla" HeaderText="Habla" />
                                                                    <asp:BoundField DataField="opcional_lee" HeaderText="Lee" />
                                                                    <asp:BoundField DataField="opcional_escritura" HeaderText="Escritura" />
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:LinkButton CommandArgument='<%#Eval("id_key")+";"+Eval("cod_idioma")+";"+Eval("cod_nivel")+";"+Eval("institucion")+";"+Eval("opcional_habla")+";"+Eval("opcional_lee")+";"+Eval("opcional_escritura")%>' CommandName="editar" CssClass="icon-list-demo" ID="LinkButton2" OnClick="LinkButton2_Click" runat="server"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:LinkButton OnClientClick="JConfirm('','¿Desea eliminar este idioma?',this); return false;" CommandArgument='<%# Eval("id_key") %>' CommandName="Delete" CssClass="icon-list-demo" ID="LinkButton3"  runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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

                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <div class="card-box table-responsive">
                                                            <div class="col-sm-8">
                                                                <h4 class="header-title"><b>Información de Cursos/Programas</b></h4>
                                                            </div>

                                                            <div class="panelOptions col-sm-4" style="text-align: right;">
                                                                <asp:LinkButton ID="btnAgregarCurso" CssClass="btn btn-default waves-effect waves-light m-b-5"
                                                                    OnClick="btnAgregarCurso_Click" runat="server">
                                                                   <i class="fa fa-plus m-r-5"></i> <span> Agregar curso/programa</span>  </asp:LinkButton>
                                                            </div>
                                                            <div class="clearfix"></div>

                                                            <asp:GridView ID="gvProgramas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvProgramas_PreRender" OnRowDeleting="gvProgramas_RowDeleting" OnRowCommand="gvProgramas_RowCommand">

                                                                <Columns>
                                                                    <asp:BoundField  DataField="id_key" HeaderText="Key" Visible="false"/>
                                                                    <asp:BoundField  DataField="cod_id" HeaderText="cod_id"  Visible="false"/>
                                                                    <asp:BoundField  DataField="cod_nivel" HeaderText="cod_nivel"  Visible="false" />
                                                                    <asp:BoundField  DataField="cod_interes" HeaderText="cod_interes" Visible="false" />
                                                                    <asp:BoundField DataField="opcional_interes" HeaderText="Curso/Programa" />
                                                                    <asp:BoundField DataField="opcional_nivel" HeaderText="Nivel" />

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:LinkButton OnClick="LinkButton2_Click3" CommandArgument='<%# Eval("id_key")+";"+Eval("cod_interes")+";"+Eval("cod_nivel")+";"+Eval("desc_interes") %>' CommandName="editar" CssClass="icon-list-demo" ID="LinkButton2" runat="server"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:LinkButton OnClientClick="JConfirm('','¿Desea eliminar este curso/programa?',this); return false;" CommandArgument='<%# Eval("id_key") %>' CommandName="Delete" CssClass="icon-list-demo" ID="LinkButton3" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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

                                                <div id="modalFormacion" runat="server" tabindex="-1" role="dialog" class="modal fade modalFormacion">
                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal">
                                                                    <span aria-hidden="true">×</span>
                                                                    <span class="sr-only">Close</span>
                                                                </button>

                                                                <h4 class="modal-title">Información de Formación Academica y Educación</h4>

                                                            </div>
                                                            <div class="modal-body">
                                                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            <label for="userName">Grado de Instrucción:</label>
                                                                            <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlGradoFormacion" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>

                                                                        <div class="col-lg-6">
                                                                            <label>Tipo de Institucion</label>
                                                                            <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlTipoInstitucion" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <div class="row">

                                                                        <div class="col-lg-12">
                                                                            <label>Nombre de la institucion educativa</label>
                                                                            <asp:TextBox placeholder="Ingresar nombre de la institucion" CssClass="form-control autocomplete" data-url="BuscarInstitucion.ashx" ID="txtCentroInstruccion" runat="server"></asp:TextBox>
                                                                            <asp:TextBox ID="txtCentroInstruccion_id" runat="server" class="form-control" Style="color: #CCC; background: transparent; z-index: 1; display: none;"></asp:TextBox>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>


                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-12">
                                                                            <label>Título:</label>
                                                                            <asp:TextBox CssClass="form-control" ID="txtTitulo" runat="server"></asp:TextBox>
                                                                        </div>

                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            <label>Año de Inicio:</label>
                                                                            <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlAnnoIntruccionInicio" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="col-lg-6">
                                                                            <label>Año de Termino:</label>
                                                                            <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlAnnoIntruccionFin" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>

                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="modal-footer">

                                                                <div class="m-t-lg">
                                                                    <asp:HiddenField ID="HFIDFormacion" Value="0" runat="server" />
                                                                    <asp:HiddenField ID="txtAccionFormacion"  runat="server" />
                                                                    <asp:Button ID="btnGuardarFormacion" OnClick="btnGuardarFormacion_Click" runat="server" Text="Continuar" CssClass="btn btn-primary" />
                                                                    <button class="btn btn-default" data-dismiss="modal" type="button">Cerrar</button>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div id="modalIdioma" runat="server" tabindex="-1" role="dialog" class="modal fade modalIdioma">
                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal">
                                                                    <span aria-hidden="true">×</span>
                                                                    <span class="sr-only">Close</span>
                                                                </button>

                                                                <h4 class="modal-title">Información de Idioma</h4>

                                                            </div>
                                                            <div class="modal-body">
                                                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            <label for="userName">Idioma:</label>
                                                                            <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlIdioma" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>

                                                                        <div class="col-lg-6">
                                                                            <label>Nivel:</label>
                                                                            <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlIdiomaNivel" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            <label>Centro de Instrucción:</label>
                                                                            <asp:TextBox required CssClass="form-control" ID="txtIdiomaInstruccion" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-lg-2">
                                                                            <label>Habla:</label>
                                                                            <asp:DropDownList required CssClass="form-control" ID="ddlHabla" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="col-lg-2">
                                                                            <label>Lee:</label>
                                                                            <asp:DropDownList required CssClass="form-control" ID="ddlLee" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="col-lg-2">
                                                                            <label>Escribe:</label>
                                                                            <asp:DropDownList required CssClass="form-control" ID="ddlEscribe" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="modal-footer">

                                                                <div class="m-t-lg">
                                                                    <asp:HiddenField ID="HFIDIdioma" Value="0" runat="server" />
                                                                    <asp:HiddenField ID="txtAccionIdioma" runat="server" />
                                                                    <asp:Button ID="btnGuardarIdioma" OnClick="btnGuardarIdioma_Click" runat="server" Text="Continuar" CssClass="btn btn-primary" />
                                                                    <button class="btn btn-default" data-dismiss="modal" type="button">Cerrar</button>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div id="modalInteres" runat="server" tabindex="-1" role="dialog" class="modal fade modalInteres">
                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal">
                                                                    <span aria-hidden="true">×</span>
                                                                    <span class="sr-only">Close</span>
                                                                </button>

                                                                <h4 class="modal-title">Información de Interes</h4>

                                                            </div>
                                                            <div class="modal-body">
                                                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            <label for="userName">Curso/Programa:</label>
                                                                            <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlInteres" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>

                                                                        <div class="col-lg-6">
                                                                            <label>Nivel:</label>
                                                                            <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlNivelInteres" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-12">
                                                                            <label>Especificar curso/programa en caso otros:</label>
                                                                            <asp:TextBox CssClass="form-control" ID="txtOtrosCurso" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="modal-footer">

                                                                <div class="m-t-lg">
                                                                    <asp:HiddenField ID="HFIDInteres" Value="0" runat="server" />
                                                                    <asp:HiddenField ID="txtAccionInteres" runat="server" />
                                                                    <asp:Button ID="btnGuardarInteres" OnClick="btnGuardarInteres_Click" runat="server" Text="Continuar" CssClass="btn btn-primary" />
                                                                    <button class="btn btn-default" data-dismiss="modal" type="button">Cerrar</button>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </asp:View>
                                            <asp:View ID="View4a" runat="server">

                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <div class="card-box table-responsive">
                                                            <div class="col-sm-8">
                                                                <h4 class="header-title"><b>Información de Experiencia Profesional</b></h4>
                                                            </div>

                                                            <div class="panelOptions col-sm-4" style="text-align: right;">
                                                                <asp:LinkButton ID="btnAgregarExperiencia" CssClass="btn btn-default waves-effect waves-light m-b-5"
                                                                    runat="server" OnClick="btnAgregarExperiencia_Click">
                                                                   <i class="fa fa-plus m-r-5"></i> <span> Agregar experiencia</span>  </asp:LinkButton>
                                                            </div>
                                                            <div class="clearfix"></div>

                                                            <asp:GridView ID="gvExperiencia" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvExperiencia_PreRender" OnRowDeleting="gvExperiencia_RowDeleting" OnRowCommand="gvExperiencia_RowCommand">

                                                                <Columns>
                                                                    <asp:BoundField Visible="false" DataField="id_key" HeaderText="Key" />
                                                                    <asp:BoundField Visible="false" DataField="cod_id" HeaderText="cod_id" />
                                                                    <asp:BoundField Visible="false" DataField="cod_cargo_laboral" HeaderText="cod_cargo_laboral" />
                                                                    <asp:BoundField DataField="nom_empresa" HeaderText="Empresa" />
                                                                    <asp:BoundField DataField="des_cargo_laboral" HeaderText="Cargo" />
                                                                    <asp:BoundField DataField="mes_inicio" HeaderText="Desde" />
                                                                    <asp:BoundField DataField="anio_inicio" HeaderText="" />

                                                                    <asp:BoundField DataField="mes_fin" HeaderText="Hasta" />
                                                                    <asp:BoundField DataField="anio_fin" HeaderText="" />

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:LinkButton OnClick="LinkButton2_Click2" CommandArgument='<%# Eval("id_key") +";"+Eval("nom_empresa")+";"+Eval("des_cargo_laboral")+";"+Eval("mes_inicio")+";"+Eval("anio_inicio")+";"+Eval("mes_fin")+";"+Eval("anio_fin")+";"+Eval("observaciones")%>' CommandName="editar" CssClass="icon-list-demo" ID="LinkButton2" runat="server"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:LinkButton OnClientClick="JConfirm('','¿Desea eliminar esta experiencia?',this); return false;" CommandArgument='<%# Eval("id_key") %>' CommandName="Delete" CssClass="icon-list-demo" ID="LinkButton3" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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

                                                <div id="modalExperiencia" runat="server" tabindex="-1" role="dialog" class="modal fade modalExperiencia">
                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal">
                                                                    <span aria-hidden="true">×</span>
                                                                    <span class="sr-only">Close</span>
                                                                </button>

                                                                <h4 class="modal-title">Información de Experiencia</h4>

                                                            </div>
                                                            <div class="modal-body">
                                                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            <label for="userName">Empresa:</label>
                                                                            <asp:TextBox required CssClass="form-control" ID="txtExperienciaEmpresa" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-lg-6">
                                                                            <label>Cargo:</label>
                                                                            <asp:TextBox required CssClass="form-control" ID="txtExperienciaCargo" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <div class="row">

                                                                        <div class="col-lg-3">
                                                                            <label for="userName">Desde (Mes):</label>
                                                                            <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlExperienciaMesInicio" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="col-lg-3">
                                                                            <label for="userName">Desde (Año):</label>
                                                                            <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlExperienciaAnnoInicio" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>

                                                                        <div class="col-lg-3">
                                                                            <label for="userName">Hasta (Mes):</label>
                                                                            <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlExperienciaMesFin" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>

                                                                        <div class="col-lg-3">
                                                                            <label for="userName">Hasta (Año):</label>
                                                                            <asp:DropDownList ToolTip="Seleccionar tipo" required CssClass="form-control" ID="ddlExperienciaAnnoFin" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-lg-12">
                                                                            <label>Observación:</label>
                                                                            <asp:TextBox CssClass="form-control" ID="txtExperienciaObservacion" runat="server" Rows="2" TextMode="MultiLine"></asp:TextBox>
                                                                        </div>


                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="modal-footer">

                                                                <div class="m-t-lg">
                                                                    <asp:HiddenField ID="HFIDExperiencia" Value="0" runat="server" />
                                                                    <asp:HiddenField ID="txtAccionExperiencia" runat="server" />
                                                                    <asp:Button ID="btnGuardarExperiencia" OnClick="btnGuardarExperiencia_Click" runat="server" Text="Continuar" CssClass="btn btn-primary" />
                                                                    <button class="btn btn-default" data-dismiss="modal" type="button">Cerrar</button>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </asp:View>
                                            <asp:View ID="View5a" runat="server">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <label>Tipo Vivienda:</label>
                                                            <asp:DropDownList ToolTip="Seleccionar tipo" CssClass="form-control" ID="ddlTipoVivienda" runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                         <div class="col-lg-4">
                                                            <label>Tipo de Licencia:</label>
                                                            <asp:DropDownList ToolTip="Seleccionar tipo" CssClass="form-control" ID="ddlTipoLicencia" runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <label>Num. Licencia:</label>
                                                            <asp:TextBox CssClass="form-control" ID="txtNumLicencia" runat="server"></asp:TextBox>
                                                        </div>

                                                        <div class="clearfix"></div>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <label>Vehículo Marca:</label>
                                                            <asp:TextBox CssClass="form-control" ID="txtVehiculoMarca" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <label>Vehículo Modelo:</label>
                                                            <asp:TextBox CssClass="form-control" ID="txtVehiculoModelo" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <label>Vehículo Placa:</label>
                                                            <asp:TextBox CssClass="form-control" ID="txtVehiculoPlaca" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <label>Posee Cta. Bancaria:</label>
                                                            <asp:DropDownList ToolTip="Seleccionar tipo" CssClass="form-control" ID="ddlPoseeCtaBanco" runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <label>Banco Emisor:</label>
                                                            <asp:DropDownList ToolTip="Seleccionar tipo" CssClass="form-control" ID="ddlBancoCta" runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <label>Posee Tarjeta Crédito:</label>
                                                            <asp:DropDownList ToolTip="Seleccionar tipo" CssClass="form-control" ID="ddlPoseTarjBanco" runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <label>Banco Emisor:</label>
                                                            <asp:DropDownList ToolTip="Seleccionar tipo" CssClass="form-control" ID="ddlBancoTarj" runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <label>Otros bienes muebles e inmuebles, decriba:</label>
                                                            <asp:TextBox CssClass="form-control" ID="txtOtrosMueblesInmuebles" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                    </div>
                                                </div>


                                            </asp:View>
                                            <asp:View ID="View6a" runat="server">
                                            </asp:View>
                                            <asp:View ID="View7a" runat="server">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <label>Tipo Personal:</label>
                                                            <asp:DropDownList required ToolTip="Seleccionar tipo" CssClass="form-control" ID="ddlTipoPersonal" runat="server">
                                                            </asp:DropDownList>
                                                        </div>

                                                        <div class="col-lg-4">
                                                            <label>Tipo Contrato:</label>
                                                            <asp:DropDownList required ToolTip="Seleccionar tipo" CssClass="form-control" ID="ddlTipoContrato" runat="server">
                                                            </asp:DropDownList>
                                                        </div>

                                                        <div class="col-lg-4">
                                                            <label>Proceso:</label>
                                                            <asp:DropDownList required ToolTip="Seleccionar proceso" CssClass="form-control" ID="ddlProceso" runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <label>Puesto Laboral:</label>
                                                            <asp:DropDownList required ToolTip="Seleccionar puesto" CssClass="form-control" ID="ddlCargo" runat="server">
                                                            </asp:DropDownList>
                                                        </div>

                                                        <div class="form-group col-lg-4">
                                                            <label for="name-1" class="control-label">Fecha Ingreso</label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon">
                                                                    <span class="fa fa-calendar"></span>
                                                                </span>
                                                                <asp:TextBox required spellcheck="false" placeholder="Ingresa fecha de ingreso" data-provide="datepicker" CssClass="form-control datepickers" ID="txt_fecha_ingreso" runat="server"></asp:TextBox>

                                                            </div>
                                                        </div>

                                                        <div class="col-lg-4">
                                                            <label>Jefatura:</label>
                                                            <asp:DropDownList ToolTip="Seleccionar jefatura" CssClass="form-control" ID="ddlJefatura" runat="server">
                                                            </asp:DropDownList>
                                                        </div>

                                                    </div>

                                                    <hr style="color: #0056b2;" />

                                                    <div class="panel panel-border panel-info">
                                                        <div class="panel-heading">
                                                            <h3 class="panel-title">CESE DE PERSONAL</h3>
                                                        </div>
                                                        <div class="panel-body">
                                                            <div class="row">

                                                                <div class="form-group col-lg-4">
                                                                    <label for="name-1" class="control-label">Fecha Cese</label>
                                                                    <div class="input-group">
                                                                        <span class="input-group-addon">
                                                                            <span class="fa fa-calendar"></span>
                                                                        </span>
                                                                        <asp:TextBox spellcheck="false" placeholder="Ingresa fecha cese" data-provide="datepicker" CssClass="form-control datepickers" ID="txt_fch_cese" runat="server"></asp:TextBox>

                                                                    </div>
                                                                </div>

                                                                <div class="col-lg-4">
                                                                    <label>Motivo Cese:</label>
                                                                    <asp:DropDownList ToolTip="Seleccionar motivo" CssClass="form-control" ID="ddlMotivoCese" runat="server">
                                                                    </asp:DropDownList>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="panel panel-border panel-purple">
                                                        <div class="panel-heading">
                                                            <h3 class="panel-title">BENEFICIOS LABORALES</h3>
                                                        </div>
                                                        <div class="panel-body">
                                                            <div class="row">

                                                                <div class="col-lg-4">
                                                                    <label>Nro. Cuenta Sueldo</label>
                                                                    <asp:TextBox placeholder="Ingrese Cuenta Sueldo"  CssClass="form-control" ID="txtNroCtaSueldo" runat="server"></asp:TextBox>
                                                                </div>
                                                                        
                                                                <div class="col-lg-4">
                                                                    <label>CCI</label>
                                                                    <asp:TextBox placeholder="Ingrese CCI"  CssClass="form-control" ID="txtCCISueldo" runat="server"></asp:TextBox>
                                                                </div>

                                                                <div class="col-lg-4">
                                                                    <label>Banco Cta. Sueldo:</label>
                                                                    <asp:DropDownList ToolTip="Seleccionar banco" CssClass="form-control" ID="ddlCtaSueldo" runat="server">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="row">

                                                                <div class="col-lg-4">
                                                                    <label>Nro. Cuenta CTS</label>
                                                                    <asp:TextBox placeholder="Ingrese Cuenta CTS" CssClass="form-control" ID="txtNroCtaCTS" runat="server"></asp:TextBox>
                                                                </div>

                                                                <div class="col-lg-4">
                                                                    <label>CCI</label>
                                                                    <asp:TextBox placeholder="Ingrese CCI" CssClass="form-control" ID="txtCCICTS" runat="server"></asp:TextBox>
                                                                </div>

                                                                <div class="col-lg-4">
                                                                    <label>Banco Cta. CTS:</label>
                                                                    <asp:DropDownList ToolTip="Seleccionar banco" CssClass="form-control" ID="ddlCtaCTS" runat="server">
                                                                    </asp:DropDownList>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="panel panel-border panel-brown">
                                                        <div class="panel-heading">
                                                            <h3 class="panel-title">DATOS DE AFILIACION</h3>
                                                        </div>
                                                        <div class="panel-body">
                                                            <div class="form-group">
                                                                <div class="row">

                                                                    <div class="col-lg-4">
                                                                        <label>Seguro </label>
                                                                        <asp:DropDownList ToolTip="Seleccionar Seguro" CssClass="form-control" ID="ddlSeguro" runat="server">
                                                                        </asp:DropDownList>
                                                                    </div>

                                                                    <div class="col-lg-4">
                                                                        <label for="userName">Código Seguro</label>
                                                                        <div class="input-group">
                                                                            <span class="input-group-addon">
                                                                                <span class="fa fa-file-text"></span>
                                                                            </span>
                                                                            <asp:TextBox spellcheck="false" placeholder="Codigo de seguro" CssClass="form-control" ID="txtCodigoIPSS" runat="server"></asp:TextBox>
                                                                        </div>

                                                                    </div>

                                                                    <div class="form-group col-lg-4">
                                                                        <label for="name-1" class="control-label">Fecha Inscripcion</label>
                                                                        <div class="input-group">
                                                                            <span class="input-group-addon">
                                                                                <span class="fa fa-calendar"></span>
                                                                            </span>
                                                                            <asp:TextBox spellcheck="false" placeholder="Fecha Seguro" data-provide="datepicker" CssClass="form-control datepickers" ID="txtfchAfiliacionSeguro" runat="server"></asp:TextBox>

                                                                        </div>
                                                                    </div>

                                                                    <div class="col-lg-4">
                                                                        <label>AFP:</label>
                                                                        <asp:DropDownList ToolTip="Seleccionar AFP" CssClass="form-control" ID="ddlAFP" runat="server">
                                                                        </asp:DropDownList>
                                                                        
                                                                    </div>

                                                                    <div class="col-lg-4">

                                                                        <label for="userName">Código AFP</label>
                                                                        <div class="input-group">
                                                                            <span class="input-group-addon">
                                                                                <span class="fa fa-file-text"></span>
                                                                            </span>
                                                                            <asp:TextBox spellcheck="false" placeholder="Ingresa codigo AFP" CssClass="form-control" ID="txtNombreAFP" runat="server"></asp:TextBox>
                                                                        </div>

                                                                    </div>

                                                                    <div class="form-group col-lg-4">
                                                                        <label for="name-1" class="control-label">Fecha Inscripcion</label>
                                                                        <div class="input-group">
                                                                            <span class="input-group-addon">
                                                                                <span class="fa fa-calendar"></span>
                                                                            </span>
                                                                            <asp:TextBox spellcheck="false" placeholder="Fecha Inscripcion AFP" data-provide="datepicker" CssClass="form-control datepickers" ID="txtFechaInscripcionAFP" runat="server"></asp:TextBox>

                                                                        </div>
                                                                    </div>

                                                                    <div class="clearfix"></div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-4">
                                                                        <label>Discapacitado:</label>
                                                                        <asp:DropDownList ToolTip="Seleccionar tipo" CssClass="form-control" ID="ddlDiscapacitado" runat="server">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="clearfix"></div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-12">
                                                                        <label>Salud e Indicaciones Médicas:</label>
                                                                        <asp:TextBox CssClass="form-control" ID="txtIndicacionesMedicas" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                                                        <p style="font-size: 11px;">Indicar condiciones médicas de riesgo y por favor dar todas las indicaciones a tomar en cuenta para cualquier situación de emergencia:</p>
                                                                    </div>
                                                                    <div class="clearfix"></div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>



                                                </div>
                                            </asp:View>


                                       <asp:View ID="View8a" runat="server">                                               

                                               <div class="row">
                                                    <div class="col-sm-12">
                                                        <div class="card-box table-responsive">
                                                            <div class="col-sm-8">
                                                                <h4 class="header-title"><b>Información de Vacaciones</b></h4>
                                                            </div>

                                                            <div class="panelOptions col-sm-4" style="text-align: right;">
                                                              <asp:LinkButton ID="btnResumen" CssClass="btn btn-instagram m-b-5" runat="server" OnClick="btnResumen_Click" > <i class="glyphicon glyphicon-list"></i> <span> Resumen</span>  </asp:LinkButton>
                                                            </div>
                                                            <div class="clearfix"></div>

                                                           <asp:gridview id="grvVacaciones" runat="server" autogeneratecolumns="False" OnPreRender="grvVacaciones_PreRender" cssclass="table table-striped table-bordered dataTable" gridlines="None">
                                                               <Columns>
                                                                   <asp:BoundField DataField="id_solicitud" HeaderText="Codigo de solicitud" visible="false"/>
                                                                   <asp:BoundField DataField="id_solicitante" HeaderText="id_solicitante" visible="false"/>
                                                                   <asp:BoundField DataField="nom_solicitante" HeaderText="Nombre Solicitante" visible="false"/>
                                                                   <asp:BoundField DataField="id_empleado" HeaderText="id_emp" visible="false"/>
                                                                   <asp:BoundField DataField="nom_empleado" HeaderText="Nombre Empleado" visible="true"/>
                                                                   <asp:BoundField DataField="fch_inicio" HeaderText="Fecha Inicio" />
                                                                   <asp:BoundField DataField="fch_fin" HeaderText="Fecha Termino" />
                                                                   <asp:BoundField DataField="total_dias" HeaderText="#Días" />
                                                                   <asp:BoundField DataField="observaciones" HeaderText="observaciones" visible="false" />
                                                                   <asp:BoundField DataField="fch_registro" HeaderText="Fecha Registro" />
                                                                   <asp:TemplateField HeaderText="Estado" Visible="false">
                                                                       <ItemTemplate>
                                                                           <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("estado") %>' Font-Size="10"></asp:Label>
                                                                       </ItemTemplate>
                                                                   </asp:TemplateField>                               
                                                               </Columns>
                                                           </asp:gridview>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:View>
                                        </asp:MultiView>
                                    </div>
                                </div>
                            </div>
                            <!-- end col -->

                            <div class="col-lg-3" style="padding: 0px;">
                                <div class="wizard clearfix vertical">
                                    <div class="steps clearfix">
                                        <ul role="tablist">
                                        </ul>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-9">
                            </div>







                        </div>
                    </div>


                </div>

            </div>

            <%----------------------------------------------------------------%>

                                       <div id="modalResumen" tabindex="-1" role="dialog" class="modal fade">
                                           <div class="modal-dialog modal-sm">
                                               <div class="modal-content">
                                                   <div class="modal-header">
                                                       <button type="button" class="close" data-dismiss="modal">
                                                           <span aria-hidden="true">×</span>
                                                           <span class="sr-only">Close</span>
                                                       </button>

                                                       <h3 class="header-title">Informe de Vacaciones </h3>

                                                   </div>
                                                   <div class="modal-body">
                                                       <div class="form-group col-lg-6">
                                                           <label for="userName">Dias Tomados:</label>
                                                       </div>
                                                       <div class="form-group col-lg-6">
                                                           <asp:TextBox spellcheck="false" CssClass="form-control col-12" ID="txtTomados" Enabled="false" runat="server"></asp:TextBox>
                                                       </div>
                                                       <div class="form-group col-lg-6">
                                                           <label for="userName">Dias Pendientes:</label>
                                                       </div>
                                                       <div class="form-group col-lg-6">
                                                           <asp:TextBox spellcheck="false" CssClass="form-control col-6" ID="txtPendientes" Enabled="false" runat="server"></asp:TextBox>
                                                       </div>
                                                       <div class="form-group col-lg-6">
                                                           <label for="userName">Dias Truncos:</label>
                                                       </div>
                                                       <div class="form-group col-lg-6">
                                                           <asp:TextBox spellcheck="false" CssClass="form-control col-12" ID="txtTruncos" Enabled="false" runat="server"></asp:TextBox>
                                                       </div>
                                                       <div class="form-group col-lg-6">
                                                           <label for="userName">Dias Vencidos: </label>
                                                       </div>
                                                       <div class="form-group col-lg-6">
                                                           <asp:TextBox spellcheck="false" CssClass="form-control col-6" ID="txtVencidos" Enabled="false" runat="server"></asp:TextBox>
                                                       </div>
                                                       <div class="form-group col-lg-6">
                                                           <label for="userName">Dias Disponibles:</label>
                                                       </div>
                                                       <div class="form-group col-lg-6">
                                                           <asp:TextBox spellcheck="false" CssClass="form-control col-12" ID="txtDisponibles" Enabled="false" runat="server"></asp:TextBox>
                                                       </div>
                                                   </div>
                                                   <div class="modal-header"></div>
                                               </div>
                                           </div>
                                       </div>                                      

<%----------------------------------------------------------------%>

        </asp:View>

        <asp:View ID="View3" runat="server">

            <div class="row">
                <div class="col-xs-12">

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-lg-8">
                                    <div class="header-title">

                                        <table width="100%" border="0">
                                            <tr>
                                                <td style="width: 100px;">Documentación</td>
                                                <td style="width: 15px; text-align: center;">/</td>
                                                <td style="width: 80px;">Empleado</td>
                                                <td>
                                                    <asp:TextBox placeholder="Ingresar nombre del personal" CssClass="form-control autocomplete" data-url="BuscarEmpleados.ashx" ID="txtEmpleado" runat="server"></asp:TextBox>
                                                    <asp:TextBox ID="txtEmpleado_id" runat="server" class="form-control" Style="color: #CCC; background: transparent; z-index: 1; display: none;"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>


                                    </div>
                                </div>

                                <div class="col-lg-4" style="text-align: right;">
                                    <asp:Button ID="btnBuscarEmpleadoDocumento" CssClass="btn btn-primary " runat="server" Text="Buscar" UseSubmitBehavior="False" OnClick="btnBuscarEmpleadoDocumento_Click" />
                                    <asp:Button ID="btnRegresarDocumento" OnClick="btnRegresarDocumento_Click" CssClass="btn btn-default " runat="server" Text="Regresar" UseSubmitBehavior="False" />
                                    <asp:HiddenField ID="HFEmpleadoDocumento" runat="server" Value="0" />
                                </div>
                                <div class="clearfix"></div>
                            </div>

                        </div>
                        <div class="panel-body">

                            <div class="col-lg-6">
                                <div class="table-responsive">

                                    <asp:GridView ID="gvCarpetaN1" runat="server" AutoGenerateColumns="False"
                                        CssClass="table table-striped table-bordered" GridLines="None" DataKeyNames="valor1"
                                        OnRowCommand="gvCarpetaN1_RowCommand" OnPreRender="gvCarpetaN1_PreRender" OnRowDataBound="gvCarpetaN1_RowDataBound">

                                        <Columns>


                                            <asp:TemplateField HeaderText="Carpetas" ItemStyle-CssClass="noBorder">
                                                <ItemTemplate>

                                                    <table class="table table-striped table-bordered">
                                                        <thead>
                                                            <td><%# Eval("valor2") %> <%# Eval("descripcion") %></td>
                                                            <td style="width: 31px;">
                                                                <asp:LinkButton CommandArgument='<%# Eval("id_sub_catalogo") %>' CommandName="carpeta" ToolTip="Ver fichas" ID="LinkButton12a" runat="server"><i class="ti-folder" style="width:16px; height:16px; line-height:16px; font-size:16px;"></i></asp:LinkButton></td>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td colspan="2" style="padding: 0px;">
                                                                    <asp:Label ID="lblIDCarpeta" Style="display: none;" runat="server" Text='<%# Eval("id_sub_catalogo") %>'></asp:Label>
                                                                    <asp:GridView Style="margin: 0px !important;" ID="gvCarpetaN1_detalle" runat="server" AutoGenerateColumns="False"
                                                                        CssClass="table table-striped table-bordered" GridLines="None"
                                                                        OnRowCommand="gvCarpetaN2_RowCommand">

                                                                        <Columns>



                                                                            <asp:BoundField Visible="false" DataField="id_descripcion" HeaderText="Codigo" />

                                                                            <asp:BoundField DataField="valor2" HeaderText="N°" HeaderStyle-Width="20px" />
                                                                            <asp:BoundField DataField="descripcion" HeaderText="Fichas" />
                                                                            <asp:BoundField DataField="valor1" HeaderText="Fichas" Visible="false" />
                                                                            <asp:TemplateField HeaderStyle-Width="10px">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton CommandArgument='<%# Eval("id_tabla") %>' CommandName="documento" ToolTip="Ver documentos" ID="LinkButton12" runat="server"><i class="ti-files" style="width:16px; height:16px; line-height:16px; font-size:16px;"></i></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>

                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>


                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>

                                    </asp:GridView>

                                </div>
                            </div>

                            <div class="col-lg-6" id="panelDocumentos" runat="server">
                                <div class="table-responsive">

                                    <asp:GridView ID="gvDocumentos" runat="server" AutoGenerateColumns="False"
                                        CssClass="table table-striped table-bordered" GridLines="None" EmptyDataText="No se encontraron archivos"
                                        OnRowCommand="gvDocumentos_RowCommand" OnPreRender="gvDocumentos_PreRender">

                                        <Columns>



                                            <asp:BoundField Visible="false" DataField="IDDocumento" HeaderText="Codigo" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Documento" />
                                            <asp:BoundField DataField="opcional_TieneVigencia" Visible="false" HeaderText="¿Tiene Vigencia?" HeaderStyle-Width="50px" />




                                            <asp:TemplateField HeaderStyle-Width="10px">
                                                <ItemTemplate>


                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ToolTip="Editar Documento" CommandArgument='<%# Eval("id_key") %>' CommandName="editar" CssClass="icon-list-demo" ID="LinkButton2" runat="server"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px; margin-right:8px;"></i></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ToolTip="Eliminar Documento" OnClientClick="JConfirm('Debe estar seguro antes de eliminar información del sistema','¿Desea eliminar este documento?',this); return false;" CommandArgument='<%# Eval("id_key") %>' CommandName="eliminar" CssClass="icon-list-demo" ID="LinkButton3" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px; margin-right:8px;"></i></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <a title="Ver Documento" style="cursor: pointer;" class="icon-list-demo tooltip_html"><i class="ti-info" style="width: 18px; height: 18px; line-height: 18px; font-size: 18px; margin-right: 8px;"></i></a>
                                                                <div class="infoHTML" style="display: none;">
                                                                    <table border="0" width="100%">
                                                                        <tr>
                                                                            <td>Nombre:</td>
                                                                            <td><%# Eval("Nombre") %></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding-right: 10px;">¿Tiene Vigencia?</td>
                                                                            <td><%# Eval("opcional_TieneVigencia") %></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Desde:</td>
                                                                            <td><%# Eval("opcional_FchInicioVigencia") %></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Hasta:</td>
                                                                            <td><%# Eval("opcional_FchFinVigencia") %></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Archivo:</td>
                                                                            <td><a target="_blank" href='<%# Eval("Archivo") %>'>Descargar</a></td>
                                                                        </tr>
                                                                    </table>

                                                                </div>

                                                            </td>
                                                        </tr>
                                                    </table>


                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>

                                    </asp:GridView>
                                    <asp:LinkButton ID="btnAgregarArchivo" CssClass="btn btn-default waves-effect waves-light btn-sm" runat="server" OnClick="btnAgregarArchivo_Click"><i class="fa fa-plus m-r-5"></i> <span> Agregar archivo</span>  </asp:LinkButton>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
            </div>

            <asp:HiddenField ID="HFCarpetaActiva" runat="server" />
            <asp:HiddenField ID="HFFichaActiva" runat="server" />
            <asp:HiddenField ID="HFCarpetaFicha" runat="server" />
            <asp:HiddenField ID="HFCarpetaCompartida" runat="server" />

            <div id="modalArchivo" runat="server" tabindex="-1" role="dialog" class="modal fade modalArchivo">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title">Información de Documento</h4>

                        </div>
                        <div class="modal-body">
                            <span class="text-primary icon icon-info-circle icon-5x"></span>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <label for="userName">Nombre:</label>
                                        <asp:TextBox required CssClass="form-control" ID="txtNombreDocumento" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <label>Archivo:</label>
                                        <asp:FileUpload CssClass="form-control" ID="FUArchivoDocumento" runat="server" accept=".pdf, .doc, .docx" />
                                        <asp:HiddenField ID="HFArchivoDocumento" runat="server" />
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <label>¿Tiene Vigencia?:</label>
                                        <asp:DropDownList required ToolTip="Seleccionar tipo" CssClass="form-control" ID="ddlVigenciaDocumento" runat="server">
                                        </asp:DropDownList>

                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <label for="userName">Desde:</label>
                                        <asp:TextBox data-provide="datepicker" CssClass="form-control datepickers" ID="txtFechaDesdeDocumento" runat="server"></asp:TextBox>

                                    </div>
                                    <div class="col-lg-6">
                                        <label>Hasta:</label>
                                        <asp:TextBox data-provide="datepicker" CssClass="form-control datepickers" ID="txtFechaHastaDocumento" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="clearfix"></div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <label>Comentario/Observación</label>
                                        <asp:TextBox CssClass="form-control" ID="txtObservacionDocumento" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">

                            <div class="m-t-lg">
                                <asp:HiddenField ID="HFIDArchivo" Value="0" runat="server" />
                                <asp:Button ID="btnGuardarArchivo" OnClick="btnGuardarArchivo_Click" runat="server" Text="Continuar" CssClass="btn btn-primary" />
                                <button class="btn btn-default" data-dismiss="modal" type="button">Cerrar</button>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </asp:View>



        <asp:View ID="View4" runat="server">

            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">
                        <div class="col-sm-8">
                            <h4 class="header-title"><b>Informe de Descansos Médicos / </b>
                                
                                    <asp:Label ID="lblEmp" runat="server" Text="" Font-Size="15" ForeColor="DarkBlue"></asp:Label></h4>
                        </div>

                        <div class="panelOptions col-sm-4" style="text-align: right;">
                            <asp:Button ID="Button2" OnClick="Button2_Click" CssClass="btn btn-warning m-b-5" runat="server" Text="Regresar" UseSubmitBehavior="False" />
                            <asp:LinkButton ID="LBAgregar" CssClass="btn btn-info m-b-5" runat="server" OnClick="LBAgregar_Click">
                                <i class="fa fa-plus m-r-5"></i> <span> Agregar</span>  </asp:LinkButton>
                        </div>

                        <div class="clearfix"></div>
                        

                        <asp:GridView ID="gvDescansos" runat="server" AutoGenerateColumns="False" OnRowCommand="gvDescansos_RowCommand"
                            CssClass="table table-striped table-bordered-custom dataTable" GridLines="None" OnPreRender="gvDescansos_PreRender" OnRowDeleting="gvDescansos_RowDeleting">

                            <Columns>
                                <%--AGREGADO--%>
                                <asp:BoundField DataField="fila" HeaderText="N°" Visible="true" />
                                <%--AGREGADO--%>
                                <asp:BoundField DataField="desc_motivo" HeaderText="Motivo" />
                                <asp:BoundField DataField="desc_clinica" HeaderText="Clínica" />
                                <asp:BoundField DataField="diasInicio_des" HeaderText="Inicio" />
                                <asp:BoundField DataField="diasFin_des" HeaderText="Fin" />
                                <asp:BoundField DataField="diasTotal_des" HeaderText="#Días" />
                                <asp:BoundField DataField="estadoDM" HeaderText="Estado" Visible="false" />

                                

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ToolTip="Visualizar/Consultar" CommandArgument='<%# Eval("id")+";"+Eval("estadoDM")%>' CommandName="Visualizar" CssClass="icon-list-demo" ID="LinkButton3" runat="server"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ToolTip="Descargar" CommandArgument='<%# Eval("documentacion_des") %>' CommandName="Descargar" CssClass="icon-list-demo" ID="LinkButton9" runat="server"><i class="fa fa-file-pdf-o" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ToolTip="Eliminar" OnClientClick="JConfirm('','¿Desea eliminar descanso médico?',this); return false;" CommandArgument='<%# Eval("id") %>' CommandName="Delete" CssClass="icon-list-demo" ID="LinkButton13" runat="server"><i class="ti ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>

                        </asp:GridView>


                        
                        <div class="col-lg-12">
                            <div class="alert alert-icon alert-info alert-dismissible fade in" role="alert">
                                                <i class="mdi mdi-information"></i>
                                                <strong>Obs! El empleado tiene acumulado</strong> <asp:Label ID="lblmsg" runat="server" Text="" Font-Bold="true" Font-Size="15" ></asp:Label><strong>días de descanso</strong>
                                            </div>
                        </div>

                        <asp:GridView ID="gvSubsidio" runat="server" AutoGenerateColumns="False" OnRowCommand="gvDescansos_RowCommand"
                            CssClass="table table-striped table-bordered-custom dataTable" GridLines="None" OnPreRender="gvSubsidio_PreRender" OnRowDeleting="gvSubsidio_RowDeleting">

                            <Columns>
                                <%--AGREGADO--%>
                                <asp:BoundField DataField="fila" HeaderText="N°" Visible="true" />
                                <%--AGREGADO--%>
                                <asp:BoundField DataField="desc_motivo" HeaderText="Motivo" />
                                <asp:BoundField DataField="desc_clinica" HeaderText="Clínica" />
                                <asp:BoundField DataField="diasInicio_des" HeaderText="Inicio" />
                                <asp:BoundField DataField="diasFin_des" HeaderText="Fin" />
                                <asp:BoundField DataField="diasTotal_des" HeaderText="#Días" />
                                <asp:BoundField DataField="estadoDM" HeaderText="Estado" Visible="false" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ToolTip="Visualizar/Consultar" CommandArgument='<%# Eval("id")+";"+Eval("estadoDM") %>' CommandName="Visualizar" CssClass="icon-list-demo" ID="LinkButton3" runat="server"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ToolTip="Descargar" CommandArgument='<%# Eval("documentacion_des") %>' CommandName="Descargar" CssClass="icon-list-demo" ID="LinkButton9" runat="server"><i class="fa fa-file-pdf-o" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ToolTip="Eliminar" OnClientClick="JConfirm('','¿Desea eliminar descanso médico?',this); return false;" CommandArgument='<%# Eval("id") %>' CommandName="Delete" CssClass="icon-list-demo" ID="LinkButton13" runat="server"><i class="ti ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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


            <%-- ACTUALIZAR CONDUCTOR --%>
            <div id="DM1" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title">Descanso Médico</h4>

                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>



                                <asp:TextBox  spellcheck="false" CssClass="form-control col-" ID="txtCod" runat="server" Visible="false"></asp:TextBox>
                                <%-- AUTO COMPLETADO CONDUCTOR --%>
                                 <div class="form-group col-lg-12">
                                    <label for="userName">Empleado </label>
                                    <asp:TextBox required CssClass="form-control autocomplete" ID="txtConductor" runat="server" Enabled="false" Font-Size="11" BorderStyle="Double"></asp:TextBox>
                                    </div>
                                <%-- FIN AUTOCOMPLETADO CONDUCTOR --%>

                                <div class="form-group col-lg-12">
                                    <%-- AUTO COMPLETADO UNIDAD --%>
                                    <div class="form-group col-lg-4">
                                        <label for="userName">Fecha Inicio </label>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                            <asp:TextBox required spellcheck="false" placeholder="Ingresa fecha inicio" data-provide="datepicker" CssClass="form-control datepickers" ID="fchInicio" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <%-- FIN DE AUTOCOMPLETADO UNIDAD --%>

                                    <div class="form-group col-lg-4">
                                        <label for="userName">Total Días </label>
                                        <asp:TextBox required CssClass="form-control" placeholder="Ingrese días" ID="txtDias" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-lg-4">
                                        <label for="userName">Fecha Fin </label>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                            <asp:TextBox required spellcheck="false" CssClass="form-control" ID="fchFin" runat="server" disabled></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName">Motivo </label>
                                    <asp:DropDownList required CssClass="form-control" ID="ddlMotivo" runat="server">
                                    </asp:DropDownList>
                                </div>
                                
                                <div class="form-group col-lg-6">
                                    <label for="userName">Descanso/Subsidio </label>
                                    <asp:DropDownList required CssClass="form-control au" ID="ddlMotivoEstado" runat="server">
                                    </asp:DropDownList>
                                </div>
                                
                                <div class="form-group col-lg-12">
                                        <label for="userName">Clínica </label>
                                    <asp:TextBox required CssClass="form-control autocomplete" data-url="BuscarClinica.ashx" ID="txtClinica" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txtClinica_id" runat="server" class="form-control" style="color: #CCC; position: absolute; background: transparent; z-index: 1;display: none;"></asp:TextBox>
                                </div>

                                <%--<div class="form-group col-lg-6">
                                    <label for="userName">Clínica </label>
                                    <asp:DropDownList required CssClass="form-control au" ID="ddlClinica" runat="server">
                                    </asp:DropDownList>
                                </div>--%>

                                <div class="form-group col-lg-12">
                                    <label>Observaciones:</label>
                                    <asp:TextBox CssClass="form-control" ID="txtObserva" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group col-lg-12">  
                                    <label for="userName">Archivo:</label>
                                    <asp:FileUpload CssClass="form-control" ID="fuArchivo" runat="server" accept=".pdf"  />
                                    <asp:HiddenField ID="HiddenField3" runat="server" />

                                </div>
                                <div class="form-group col-lg-12">
                                    <div class="col-lg-12 text-right">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-instagram m-t-5" Text="Guardar" OnClick="btnGuardarDM_Click"></asp:Button>

                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%-- FIN ACTUALIZAR CONDUCTOR --%>
        </asp:View>



        <asp:View ID="View5" runat="server">

            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">
                        <div class="col-sm-6">
                            <h4 class="header-title"><b> Reporte de DM </b></h4>
                        </div>

                        <div class="panelOptions col-sm-6" style="text-align: right;">
                            <asp:Button ID="Regresar" OnClick="Button2_Click" CssClass="btn btn-warning m-b-5" runat="server" Text="Regresar" UseSubmitBehavior="False" />
                            <asp:LinkButton ID="btnConsultarDM" CssClass="btn btn-info m-b-5" runat="server" OnClick="btnConsultarDM_Click">
                                <i class="fa fa-plus m-r-5"></i> <span> Consultar</span>  </asp:LinkButton>
                            <asp:LinkButton ID="btnExportarDM1" CssClass="btn btn-success waves-effect waves-light m-b-5"
                                runat="server" OnClick="btnExportarDM_Click"> 
                            <i class="fa fa-file m-r-5"></i> <span>Exportar DM </span> </asp:LinkButton>
                        </div>

                        <div class="clearfix"></div>
                        

                        <asp:GridView ID="gvFiltroDM" runat="server" AutoGenerateColumns="False" OnRowCommand="gvFiltroDM_RowCommand"
                            CssClass="table table-striped table-bordered-custom dataTable" GridLines="None" OnPreRender="gvFiltroDM_PreRender" OnRowDeleting="gvFiltroDM_RowDeleting">

                            <Columns>
                                <asp:BoundField DataField="nombre_emp" HeaderText="Empleado" />
                                <asp:BoundField DataField="desc_motivo" HeaderText="Motivo" />
                                <asp:BoundField DataField="desc_clinica" HeaderText="Clínica" />
                                <asp:BoundField DataField="diasInicio_des" HeaderText="Inicio" />
                                <asp:BoundField DataField="diasTotal_des" HeaderText="#Días" />
                                <asp:BoundField DataField="diasFin_des" HeaderText="Fin" />
                                <asp:BoundField DataField="estadoDM" HeaderText="Estado" />
                            </Columns>

                        </asp:GridView>
                            
                    </div>
                </div>
            </div>


            <%-- ACTUALIZAR CONDUCTOR --%>
            <div id="DMFiltro" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title">Filtrar Fechas</h4>

                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                <div class="form-group col-lg-12">
                                  
                                    <div class="form-group col-lg-6">
                                        <label for="userName">Fecha Inicio </label>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                            <asp:TextBox required spellcheck="false" placeholder="Ingresa fecha inicio" data-provide="datepicker" CssClass="form-control datepickers" ID="fchInicioFiltro" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                  
                                    <div class="form-group col-lg-6">
                                        <label for="userName">Fecha Fin </label>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                            <asp:TextBox required spellcheck="false" placeholder="Ingresa fecha fin" data-provide="datepicker" CssClass="form-control datepickers" ID="fchFinFiltro" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group col-lg-12">
                                    <label for="userName">Tipo de Reporte </label>
                                    <asp:DropDownList required CssClass="form-control" ID="ddlTipoR" runat="server" >
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-lg-12">
                                    <div class="col-lg-12 text-center">
                                        <asp:Button ID="BuscarDM" runat="server" CssClass="btn btn-instagram m-t-5" Text="Buscar" OnClick="BuscarDM_Click"></asp:Button>

                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%-- FIN ACTUALIZAR CONDUCTOR --%>
        </asp:View>
        
        <%-- INICIO --%>
        <asp:View ID="View6" runat="server">

            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">
                        <div class="col-sm-6">
                            <h4 class="header-title"><b> Reporte de Indumentaria </b></h4>
                        </div>

                        <div class="panelOptions col-sm-6" style="text-align: right;">
                            <asp:Button ID="btnRegresarInd" CssClass="btn btn-warning m-b-5" runat="server" Text="Regresar" UseSubmitBehavior="False" OnClick="Button2_Click"/>
                            <asp:LinkButton ID="LinkButton15" CssClass="btn btn-info m-b-5" runat="server"> <i class="fa fa-wpforms m-r-5"></i> <span> Formato </span>  </asp:LinkButton>
                            <%--<asp:LinkButton ID="LinkButton16" CssClass="btn btn-success waves-effect waves-light m-b-5" runat="server"> <i class="fa fa-file m-r-5"></i> <span>Exportar DM </span> </asp:LinkButton>--%>
                        </div>







                        </div>
                        </div>
                        </div>
                        </asp:View>



    </asp:MultiView>




</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
        
    <script type="text/javascript">


                                                    function showimagepreview(input) {

                                                        if (input.files && input.files[0]) {
                                                            var reader = new FileReader();
                                                            reader.onload = function (e) {

                                                                document.getElementById("ContentPlaceHolder1_img").setAttribute("src", e.target.result);
                                                            }
                                                            reader.readAsDataURL(input.files[0]);
                                                        }
                                                    }

                                                    $(document).ready(function () {

                                                        $("input[id*='txtDias']").change(function () {
                                                            $("input[id*='fchFin']").val();
                                                            var valor1 = $("input[id*='fchInicio']").val();
                                                            var valor2 = $("input[id*='txtDias']").val();

                                                            var parts = valor1.split('/');

                                                            var valor3 = new Date(parts[2], parts[1] - 1, parts[0]);
                                                            var newdate = new Date(valor3);

                                                            newdate.setDate(newdate.getDate() + parseFloat(valor2) - 1);

                                                            var dd = newdate.getDate();
                                                            var dd = ((dd < 10) ? '0' + dd : dd);
                                                            var mm = newdate.getMonth() + 1;
                                                            var mm = ((mm < 10) ? '0' + mm : mm);
                                                            var y = newdate.getFullYear();

                                                            var someFormattedDate = dd + '/' + mm + '/' + y;

                                                            $("input[id*='fchFin']").val(someFormattedDate);
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

    <script type="text/javascript">
        $(document).ready(function () {
            /*$(".fancybox").fancybox({
                width: 800,
                height: 800,
                type: 'iframe'
            });*/
            $('.example').DataTable({
                "order": [[1, "asc"]]
            });
        });
    </script>
</asp:Content>
