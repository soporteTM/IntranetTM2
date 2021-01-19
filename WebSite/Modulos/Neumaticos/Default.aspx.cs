using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Modulos_Neumaticos_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Perfil();
            //txtUnidad.Text = "APY717";
            //loadNeumatico();
            //RendimientoNeumatico(); 
        }
    }

    public void Perfil()
    {
        HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        if (authCookie != null)
        {
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            String dataUser = (authTicket.UserData != null && authTicket.UserData != "" ? authTicket.UserData : "");
            String[] data = dataUser.Split('|');
            hfUsuario.Value = data[0];
        }
    }

    public void AsignarLabel(int pos, string text)
    {
        switch (pos - 1)
        {

            case 0:
                lbl0.Text = text;
                break;
            case 1:
                lbl1.Text = text;
                break;
            case 2:
                lbl2.Text = text;
                break;
            case 3:
                lbl3.Text = text;
                break;
            case 4:
                lbl4.Text = text;
                break;
            case 5:
                lbl5.Text = text;
                break;
            case 6:
                lbl6.Text = text;
                break;
            case 7:
                lbl7.Text = text;
                break;
            case 8:
                lbl8.Text = text;
                break;
            case 9:
                lbl9.Text = text;
                break;
            case 10:
                lbl10.Text = text;
                break;
            case 11:
                lbl11.Text = text;
                break;
            case 12:
                lbl12.Text = text;
                break;
            case 13:
                lbl13.Text = text;
                break;
        }
    }

    public void limpiarBotones()
    {
        lbl0.Visible = false;
        lbl1.Visible = false;
        lbl2.Visible = false;
        lbl3.Visible = false;
        lbl4.Visible = false;
        lbl5.Visible = false;
        lbl6.Visible = false;
        lbl7.Visible = false;
        lbl8.Visible = false;
        lbl9.Visible = false;
        lbl10.Visible = false;
        lbl11.Visible = false;
        lbl12.Visible = false;
        lbl13.Visible = false;
    }

    public void configuracionS1()
    {
        lbl0.Text = "Pos 1";
        lbl0.Visible = true;
        lbl1.Text = "Pos 2";
        lbl1.Visible = true;
        lbl2.Text = "Pos 3";
        lbl2.Visible = true;
        lbl3.Text = "Pos 4";
        lbl3.Visible = true;
        lbl4.Text = "Pos 5";
        lbl4.Visible = true;
        lbl5.Text = "Pos 6";
        lbl5.Visible = true;
        lbl6.Text = "Pos 7";
        lbl6.Visible = true;
        lbl7.Text = "Pos 8";
        lbl7.Visible = true;
        lbl8.Text = "Pos 9";
        lbl8.Visible = true;
        lbl9.Text = "Pos 10";
        lbl9.Visible = true;
        lbl10.Text = "Pos 11";
        lbl10.Visible = true;
        lbl11.Text = "Pos 12";
        lbl11.Visible = true;
        lbl12.Text = "Pos 13";
        lbl12.Visible = true;
        lbl13.Text = "Pos 14";
        lbl13.Visible = true;
    }

    public void configuracionS2()
    {
        lbl2.Text = "Pos 1";
        lbl2.Visible = true;
        lbl3.Text = "Pos 2";
        lbl3.Visible = true;
        lbl4.Text = "Pos 3";
        lbl4.Visible = true;
        lbl5.Text = "Pos 4";
        lbl5.Visible = true;
        lbl6.Text = "Pos 5";
        lbl6.Visible = true;
        lbl7.Text = "Pos 6";
        lbl7.Visible = true;
        lbl8.Text = "Pos 7";
        lbl8.Visible = true;
        lbl9.Text = "Pos 8";
        lbl9.Visible = true;
    }

    public void configuracionS3()
    {
        lbl2.Text = "Pos 1";
        lbl2.Visible = true;
        lbl3.Text = "Pos 2";
        lbl3.Visible = true;
        lbl4.Text = "Pos 3";
        lbl4.Visible = true;
        lbl5.Text = "Pos 4";
        lbl5.Visible = true;
        lbl6.Text = "Pos 5";
        lbl6.Visible = true;
        lbl7.Text = "Pos 6";
        lbl7.Visible = true;
        lbl8.Text = "Pos 7";
        lbl8.Visible = true;
        lbl9.Text = "Pos 8";
        lbl9.Visible = true;
        lbl10.Text = "Pos 9";
        lbl10.Visible = true;
        lbl11.Text = "Pos 10";
        lbl11.Visible = true;
        lbl12.Text = "Pos 11";
        lbl12.Visible = true;
        lbl13.Text = "Pos 12";
        lbl13.Visible = true;
    }

    public void configuracionT2()
    {
        lbl0.Text = "Pos 1";
        lbl0.Visible = true;
        lbl1.Text = "Pos 2";
        lbl1.Visible = true;
        
        lbl2.Text = "Pos 3";
        lbl2.Visible = true;
        lbl3.Text = "Pos 4";
        lbl3.Visible = true;
        lbl4.Text = "Pos 5";
        lbl4.Visible = true;
        lbl5.Text = "Pos 6";
        lbl5.Visible = true;
        
    }

    public void configuracionT3()
    {
        lbl0.Text = "Pos 1";
        lbl0.Visible = true;
        lbl1.Text = "Pos 2";
        lbl1.Visible = true;

        lbl2.Text = "Pos 3";
        lbl2.Visible = true;
        lbl3.Text = "Pos 4";
        lbl3.Visible = true;
        lbl4.Text = "Pos 5";
        lbl4.Visible = true;
        lbl5.Text = "Pos 6";
        lbl5.Visible = true;

        lbl6.Text = "Pos 7";
        lbl6.Visible = true;
        lbl7.Text = "Pos 8";
        lbl7.Visible = true;
        lbl8.Text = "Pos 9";
        lbl8.Visible = true;
        lbl9.Text = "Pos 10";
        lbl9.Visible = true;
    }

    public void configuracionN1()
    {
        lbl0.Text = "Pos 1";
        lbl0.Visible = true;
        lbl1.Text = "Pos 2";
        lbl1.Visible = true;

        lbl2.Text = "Pos 3";
        lbl2.Visible = true;
        lbl5.Text = "Pos 6";
        lbl5.Visible = true;
        
    }

    public void VisibleLabel(string nrLlantas, string configuracion)
    {

        limpiarBotones();

        switch (configuracion)
        {
            case "T2":
                configuracionT2();
                break;
            case "T3":
                configuracionT3();
                break;
            case "C2":
                //MostrarMensaje(1,"No hay configuracion C2.");
                configuracionT2(); //Según SRamos llevan la misma configuración
                break;
            case "S3":
                configuracionS3();
                break;
            case "S2":
                configuracionS2();
                break;
            case "S1":
                configuracionS1();
                break;
            case "N1":
                //configuracionT2(); //Según SRamos llevan la misma configuración
                configuracionN1();
                //MostrarMensaje(1, "En proceso de creación de config.");
                break;
            default:
                limpiarBotones();
                break;
        }
        
    }
    public void loadNeumatico()
    {
        NeumaticoBL oNeumatico = new NeumaticoBL();
        List<NeumaticoEL> lst = oNeumatico.ConsultarNeumatico(txtUnidad.Text);

        FlotaBL oFlota = new FlotaBL();
        List<NeumaticoEL> lst2 = oFlota.ConsultarFlotaNeumatico(Convert.ToInt32(txtUnidad_id.Text));

        gvNeumatico.DataSource = lst;
        gvNeumatico.DataBind();

        ////Image
        //if(lst.Count>0)
        //{
        div_image.Attributes["style"] = "height: 200px; margin: auto; background: url('" + lst2[0].URL + "') center center no-repeat; width:975px;";
        VisibleLabel(lst2[0].NrLlantas,lst2[0].nom_configuracion);
        //}
        //else
        //{
        //    VisibleLabel("14");
        //}



        //Populate TextBox
        for (int i = 0; i <= lst.Count - 1; i++)
        {
            AsignarLabel(lst[i].pos, lst[i].nro_serie);
        }


    }

    protected void gvNeumatico_PreRender(object sender, EventArgs e)
    {
        if (gvNeumatico.Rows.Count > 0)
        {
            gvNeumatico.UseAccessibleHeader = true;
            gvNeumatico.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvNeumatico.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void gvNeumatico_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void gvNeumatico_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {
            case "Liberar":
                hfAccion.Value = "Liberar";
                string[] arg = new string[3];
                arg = e.CommandArgument.ToString().Split(';');
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
                hfPos.Value = arg[2];
                txtNSerie.Text = arg[1];
                txtNSerie.Enabled = false;
                txtNSerie_id.Text = arg[0];
                txtNSerie_id.Enabled = false;

                txtKm.Text = "";
                txtR1.Text = "";
                txtR2.Text = "";
                txtR3.Text = "";
                break;
        }
    }

    protected void btnBuscarPlaca_Click(object sender, EventArgs e)
    {
        loadNeumatico();
    }

    
    protected void lbl0_Click(object sender, EventArgs e)
    {
        hfPos.Value = "1";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }
    protected void lbl1_Click(object sender, EventArgs e)
    {
        hfPos.Value = "2";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }
    protected void lbl2_Click(object sender, EventArgs e)
    {
        hfPos.Value = "3";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }
    protected void lbl3_Click(object sender, EventArgs e)
    {
        hfPos.Value = "4";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }
    protected void lbl4_Click(object sender, EventArgs e)
    {
        hfPos.Value = "5";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }
    protected void lbl5_Click(object sender, EventArgs e)
    {
        hfPos.Value = "6";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }
    protected void lbl6_Click(object sender, EventArgs e)
    {
        hfPos.Value = "7";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }
    protected void lbl7_Click(object sender, EventArgs e)
    {
        hfPos.Value = "8";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }
    protected void lbl8_Click(object sender, EventArgs e)
    {
        hfPos.Value = "9";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }
    protected void lbl9_Click(object sender, EventArgs e)
    {
        hfPos.Value = "10";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }
    protected void lbl10_Click(object sender, EventArgs e)
    {
        hfPos.Value = "11";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }
    protected void lbl11_Click(object sender, EventArgs e)
    {
        hfPos.Value = "12";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }
    protected void lbl12_Click(object sender, EventArgs e)
    {
        hfPos.Value = "13";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }
    protected void lbl13_Click(object sender, EventArgs e)
    {
        hfPos.Value = "14";
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "$('#infoModalRegistrar').modal('show');", true);
        txtNSerie.Text = "";
        txtNSerie_id.Text = "";
        txtKm.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        txtNSerie.Enabled = true;
    }

    protected void lnkRegistrar_Click(object sender, EventArgs e)
    {
        RegistrarNeumaticoFlota();
        loadNeumatico();
    }

    public void RegistrarNeumaticoFlota()
    {
        int estado;
        if (hfAccion.Value.Equals("Liberar"))
        {
            estado = 0;
            hfAccion.Value = "";
        }
        else
        {
            estado = 1;
        }

       
            try
            {
                NeumaticoBL oNeumaticos = new NeumaticoBL();
                NeumaticoEL objNeumaticos = new NeumaticoEL();
                objNeumaticos.id_nm = Convert.ToInt32(txtNSerie_id.Text);
                objNeumaticos.cod_flota = Convert.ToInt32(txtUnidad_id.Text);
                objNeumaticos.pos = Convert.ToInt32(hfPos.Value);
                objNeumaticos.km_actual = Convert.ToDecimal(txtKm.Text);
                objNeumaticos.R1 = Convert.ToInt32(txtR1.Text);
                objNeumaticos.R2 = Convert.ToInt32(txtR2.Text);
                objNeumaticos.R3 = Convert.ToInt32(txtR3.Text);
                objNeumaticos.aud_usuario_creacion = hfUsuario.Value;
                objNeumaticos.fecha = Convert.ToDateTime(txtFecha.Text);
                List<TransaccionEL> lst = oNeumaticos.RegistrarNeumaticoFlota(objNeumaticos, estado);
                MostrarMensaje(lst[0].id_mensaje, lst[0].mensaje);
            }
            catch (Exception ex)
            {
                MostrarMensaje(1, "No se pudo realizar el registro");
            }
            
        
        
    }

    public void MostrarMensaje(int error, string mensaje)
    {
        if (error == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('" + mensaje + "','Alerta:','success');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "JToastr('" + mensaje + "','Alerta:','error');", true);
        }
    }
}