using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Nombrada_Nombrada : System.Web.UI.Page
{
    public int error = 0;
    public DateTime fecha= System.DateTime.Today;
    public string mensaje;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFecha.Text =  System.DateTime.Today.ToShortDateString();
            llenarOperaciones();
            loadItems(ddlObservaciones,"19");            
            ListarNombrada();
        }   
    }

    public void BuscarNombrada()
    {
        OcultarColumnasNombrada();
        try
        {
            if (txtFecha.Text.Length>0)
            { 
                NombradaBL oNombrada = new NombradaBL();
                NombradaEL objNombrada = new NombradaEL();
                fecha = Convert.ToDateTime(txtFecha.Text);
                objNombrada.fecha = fecha;
                List<NombradaEL> lst = oNombrada.ListarNombrada(objNombrada);
                grvNombrada.DataSource = lst;
                grvNombrada.DataBind();

                if (grvNombrada.Rows.Count == 0)
                {
                    error = 1;
                    mensaje = "No se ha podido encontrar una nombrada de referencia";
                }
            }
            else
            {
                error = 1;
                mensaje = "Debe seleccionar una fecha";
                MostrarMensaje();
            }
        }
        catch(Exception ex)
        {
            error = 1;
            mensaje = "Algo sucedio!";
            MostrarMensaje();
        }
        for (int i = 0; i < grvNombrada.Rows.Count; i++)
        {
            if (grvNombrada.Rows[i].Cells[8].Text.Equals("DESCANSO MEDICO"))
            {
                grvNombrada.Rows[i].ForeColor = System.Drawing.Color.Red;
            }
        }
        OcultarColumnasNombrada();
    }   

    public void ListarNombrada()
    {
        OcultarColumnasNombrada();
        NombradaBL oNombrada = new NombradaBL();
        NombradaEL objNombrada = new NombradaEL();
        objNombrada.fecha = fecha;
        List<NombradaEL> lst = oNombrada.ListarNombrada(objNombrada);
        grvNombrada.DataSource = lst;
        grvNombrada.DataBind();
        OcultarColumnasNombrada();

        for (int i=0;i<grvNombrada.Rows.Count;i++)
        {
            if (grvNombrada.Rows[i].Cells[8].Text.Equals("DESCANSO MEDICO"))
            {
                grvNombrada.Rows[i].ForeColor = System.Drawing.Color.Red;
            }
        }


    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        BuscarNombrada();
        MostrarMensaje();
    }

    public void llenarOperaciones()
    {        
        ddlOperacion.Items.Clear();
        ddlOperacion.Items.Add("--Seleccione Operacion--");
        ddlOperacion.Items.Add("Operativo");
        ddlOperacion.Items[1].Value = "040100";
        ddlOperacion.Items.Add("Integral");
        ddlOperacion.Items[2].Value = "040200";
    }

    public void RegistrarNombrada()
    {
        NombradaBL oNombrada = new NombradaBL();
        NombradaEL objNombrada = new NombradaEL();
        objNombrada.fecha= Convert.ToDateTime(txtFecha.Text);
        oNombrada.RegistrarNombrada(objNombrada);
        error = 0;
        mensaje = "Creado correctamente";
    }
    
    protected void grvNombrada_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToString())
        {            
            case "Modificar":
                if (Convert.ToDateTime(txtFecha.Text + " " + "7:00") < System.DateTime.Today)
                {
                    error = 1;
                    mensaje = "No se puede modificar una nombrada pasada";
                    MostrarMensaje();
                    break;
                }
                else
                {
                    string[] arg = new string[8];
                    arg = e.CommandArgument.ToString().Split(';');
                    txtCod.Text = arg[0];
                    txtCodUnidad.Text = arg[1];
                    txtUnidad_id.Text = arg[7];
                    txtUnidad.Text = arg[3];
                    txtCodUnidad_id.Text = arg[5];

                    if (arg[4].ToString().Equals("OPERATIVO"))
                    {
                        ddlOperacion.SelectedIndex = 1;
                        ddlOperacion.SelectedValue = "040100";
                    }
                    else if (arg[4].ToString().Equals("INTEGRAL"))
                    {
                        ddlOperacion.SelectedIndex = 2;
                        ddlOperacion.SelectedValue = "040200";
                    }
                    if (arg[6].ToString().Equals("DESCANSO MEDICO"))
                    {
                        ddlObservaciones.SelectedIndex = 1;
                        ddlObservaciones.SelectedValue = "190100";

                    }
                    else if (arg[6].ToString().Equals("PERMISO"))
                    {
                        ddlObservaciones.SelectedIndex = 2;
                        ddlObservaciones.SelectedValue = "190200";

                    }

                    lblMensaje.Text = "2";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
                    break;
                }
            case "eliminar":
                if (Convert.ToDateTime(txtFecha.Text+" "+"7:00") < System.DateTime.Today)
                {
                    error = 1;
                    mensaje = "No se puede modificar una nombrada pasada";
                    MostrarMensaje();
                    break;
                }
                else
                {
                    EliminarConductor(Convert.ToInt32(e.CommandArgument.ToString()));
                    error = 0;
                    mensaje = "Se elimino correctamente";
                    MostrarMensaje();
                    break;
                }
        }
    }

    protected void SendMail(string CodInterno,string NumeroPLaca,string NombreCompleto,string Brevete,string Operacion,string  Observacion,string Fecha)
    {
        StringBuilder emailHtml = new StringBuilder(File.ReadAllText(Server.MapPath("mails/nombrada.html")));

        emailHtml.Replace("[%var_CodInterno%]", CodInterno);
        emailHtml.Replace("[%var_NumeroPlaca%]", NumeroPLaca);
        emailHtml.Replace("[%var_NombreCompleto%]", NombreCompleto);
        emailHtml.Replace("[%var_Brevete%]", Brevete);
        emailHtml.Replace("[%var_Operacion%]", Operacion);
        emailHtml.Replace("[%var_Observaciones%]",Observacion);
        emailHtml.Replace("[%var_Fecha%]", Fecha);

        MailMessage message = new MailMessage();
        message.From = new MailAddress("rodrigo.rojas@tmeridian.com.pe");
        message.To.Add("rodrigo.rojas@tmeridian.com.pe");
        message.Subject = "Nombrada";
        message.IsBodyHtml = true;
        message.Body = emailHtml.ToString();

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.UseDefaultCredentials = true;

        smtpClient.Host = "smtp.office365.com";
        smtpClient.Port = 25;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new System.Net.NetworkCredential("rodrigo.rojas@tmeridian.com.pe", "abcd.1234");
        smtpClient.Send(message);
    }
    
    public void EliminarConductor(int id)
    {
        NombradaBL oNombrada = new NombradaBL();
        NombradaEL objNombrada = new NombradaEL();
        objNombrada.id = id;
        List<TransaccionEL> lst = oNombrada.EliminarConductor(objNombrada);
        BuscarNombrada();
    }

    public void OcultarColumnasNombrada()
    {
        if (grvNombrada.Columns[0].Visible == true)
        {
            grvNombrada.Columns[0].Visible = false;

        }

        else if (grvNombrada.Columns[0].Visible == false)
        {
            grvNombrada.Columns[0].Visible = true;
        }

        if (grvNombrada.Columns[1].Visible == true)
        {
            grvNombrada.Columns[1].Visible = false;

        }
        else if (grvNombrada.Columns[1].Visible == false)
        {
            grvNombrada.Columns[1].Visible = true;
        }

        if (grvNombrada.Columns[4].Visible == true)
        {
            grvNombrada.Columns[4].Visible = false;

        }
        else if (grvNombrada.Columns[4].Visible == false)
        {
            grvNombrada.Columns[4].Visible = true;
        }
    }
    
    public void MostrarMensaje()
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

    public void loadItems(DropDownList ddl, string id_catalogo)
    {
        ItemBL oItem = new ItemBL();
        ddl.DataSource = oItem.ListarItemOpe(id_catalogo);
        ddl.DataTextField = "descripcion";
        ddl.DataValueField = "id_descripcion";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Observaciones --", ""));
        ddl.SelectedIndex = 0;
    }

    public void ActualizarConductor()
    {
        int x = 0;
        string valor;
        for (int i = 0; i < grvNombrada.Rows.Count; i++)
        {
            valor = grvNombrada.Rows[i].Cells[1].Text;
            if (txtCodUnidad_id.Text == valor)
            {
                if(txtCod.Text == grvNombrada.Rows[i].Cells[0].Text)
                {
                    NombradaBL oNombrada = new NombradaBL();
                    NombradaEL objNombrada = new NombradaEL();
                    if (txtCodUnidad.Text.Length == 0)
                    {
                        objNombrada.id_unidad = 0;
                    }
                    else
                    {
                        objNombrada.id_unidad = Convert.ToInt32(txtCodUnidad_id.Text);
                    }
                    if (ddlObservaciones.SelectedIndex == 0)
                    {
                        objNombrada.observacion = "";
                    }
                    else
                    {
                        objNombrada.observacion = ddlObservaciones.SelectedValue.ToString();
                    }
                    objNombrada.tipo = ddlOperacion.SelectedValue.ToString();
                    objNombrada.id = Convert.ToInt32(txtCod.Text);
                    objNombrada.id_conductor = Convert.ToInt32(txtUnidad_id.Text);
                    List<TransaccionEL> lst = oNombrada.ActualizarNombrada(objNombrada);
                    mensaje = "Se actualizo correctamente";
                    break;
                }
                error = 1;
                x = 1;
                mensaje = "La unidad ya se encuentra asignada";
                break;
            }
            else
            {
                x = 0;
            }
        }
        if (x == 0)
        {
            NombradaBL oNombrada = new NombradaBL();
            NombradaEL objNombrada = new NombradaEL();
            if (txtCodUnidad.Text.Length == 0)
            {
                objNombrada.id_unidad = 0;
            }
            else
            {
                objNombrada.id_unidad = Convert.ToInt32(txtCodUnidad_id.Text);
            }
            if (ddlObservaciones.SelectedIndex == 0)
            {
                objNombrada.observacion = "";
            }
            else
            {
                objNombrada.observacion = ddlObservaciones.SelectedValue.ToString();
            }
            objNombrada.tipo = ddlOperacion.SelectedValue.ToString();
            objNombrada.id = Convert.ToInt32(txtCod.Text);
            objNombrada.id_conductor = Convert.ToInt32(txtUnidad_id.Text);
            List<TransaccionEL> lst = oNombrada.ActualizarNombrada(objNombrada);
            mensaje = "Se actualizo correctamente";
        }   
    }

    public void AgregarConductor()
    {
        int x = 0;
        string valor,valor2;
        for (int i = 0; i < grvNombrada.Rows.Count; i++)
        {
            valor = grvNombrada.Rows[i].Cells[4].Text;
            valor2 = grvNombrada.Rows[i].Cells[1].Text;
            if(txtCodUnidad_id.Text==valor2){
                error = 1;
                x = 1;
                mensaje = "La unidad ya se encuentra asignada";
                break;
            }
            if (txtUnidad_id.Text == valor)
            {
                error = 1;
                x = 1;
                mensaje = "El conductor no se puede repetir";
                break;
            }
            else
            {
                x = 0;
            }
        }
        if (x == 0)
        {
            NombradaBL oNombrada = new NombradaBL();
            NombradaEL objNombrada = new NombradaEL();
            objNombrada.fecha = Convert.ToDateTime(txtFecha.Text);   
            if (txtUnidad.Text.Length == 0)
            {
                objNombrada.id_conductor = 0;
            }
            else
            {
                objNombrada.id_conductor = Convert.ToInt32(txtUnidad_id.Text);
            }
            if (txtCodUnidad.Text.Length==0)
            {
                objNombrada.id_unidad = 0;
            }
            else
            {
                objNombrada.id_unidad = Convert.ToInt32(txtCodUnidad_id.Text);
            }
            if (ddlOperacion.SelectedIndex==0)
            {
                objNombrada.tipo = "";
            }
            else
            {
                objNombrada.tipo = ddlOperacion.SelectedValue.ToString();
            }
            if (ddlObservaciones.SelectedIndex == 0)
            {
                objNombrada.observacion = "";
            }
            else
            {
                objNombrada.observacion = ddlObservaciones.SelectedValue.ToString();
            }
            objNombrada.status_unidad = false;
            List<TransaccionEL> lst = oNombrada.AgregarConductor(objNombrada);
            mensaje = "Registrado correctamente";
        }
        txtCodUnidad.Text = "";
        txtCodUnidad_id.Text = "";
        txtUnidad.Text = "";
        txtUnidad_id.Text = "";
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        txtUnidad.Text = "";
        txtUnidad_id.Text = "";
        txtCodUnidad.Text = "";
        txtCodUnidad_id.Text = "";
        ddlOperacion.SelectedIndex = 0;
        ddlObservaciones.SelectedIndex = 0;
        txtUnidad.Enabled = true;
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#infoModalAlert2').modal('show');", true);
        lblMensaje.Text = "1";
    }
    
    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        BuscarNombrada();
        if (grvNombrada.Rows.Count == 0)
        {
            RegistrarNombrada();
            BuscarNombrada();
            MostrarMensaje();
        }
    }

    protected void grvNombrada_PreRender(object sender, EventArgs e)
    {
        if (grvNombrada.Rows.Count > 0)
        {
            grvNombrada.UseAccessibleHeader = true;
            grvNombrada.HeaderRow.TableSection = TableRowSection.TableHeader;
            grvNombrada.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        if (lblMensaje.Text.Equals("1"))
        {
            if (txtCodUnidad.Text.Length == 0)
            {
                if (txtUnidad.Text.Length == 0)
                {

                    error = 1;
                    mensaje = "Debe ingresar un conductor y/o unidad ";
                }
                else
                {
                    if (ConsultarDescanso() == "")
                    {
                        AgregarConductor();
                    }
                    else
                    {
                        error = 1;
                        mensaje = "El conductor seleccionado se encuentra con descanso medico";
                    }
                }
            }
            else
            {
                if (ConsultarDescanso() == "")
                {
                    AgregarConductor();
                }
                else
                {
                    error = 1;
                    mensaje = "El conductor seleccionado se encuentra con descanso medico hasta el "+ConsultarDescanso();
                }
            }
        }
        else if (lblMensaje.Text.Equals("2"))
        {
            ActualizarConductor();
        }
        BuscarNombrada();

        MostrarMensaje();

    }

    

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        //SendMail();
    }

    public string ConsultarDescanso()
    {
        string x;
                DescansoMedicoBL oDescansoBL = new DescansoMedicoBL();
                DescansoMedicoEL oDescansoEL = new DescansoMedicoEL();
                oDescansoEL.fecha = Convert.ToDateTime(txtFecha.Text);
                oDescansoEL.id_emp = Convert.ToInt32(txtUnidad_id.Text);
                
                List<TransaccionEL> lst = oDescansoBL.ConsultarDescanso(oDescansoEL);
                if (lst[0].id_mensaje == 1)
                {
            
                    x = lst[0].mensaje;
                }
                else
                {
                    x = lst[0].mensaje;
                }


        return x;
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        NombradaBL nombradaBL = new NombradaBL();
        NombradaEL nombradaEL = new NombradaEL();
        nombradaEL.fecha = Convert.ToDateTime(txtFecha.Text);

        var GridView1 = new GridView();
        GridView1.DataSource = nombradaBL.ListarNombradaExportar(nombradaEL);
        GridView1.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attacNhment;filename=Nombrada_" + txtFecha.Text + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            GridView1.AllowPaging = false;
            GridView1.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                cell.BackColor = GridView1.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GridView1.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            GridView1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}