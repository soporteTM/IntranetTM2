using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Distribucion_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public void AbrirPopUp(string PopUp)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyy"), "$('#" + PopUp + "').modal('show');", true);
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        AbrirPopUp("infoModalAlert1");
    }
}