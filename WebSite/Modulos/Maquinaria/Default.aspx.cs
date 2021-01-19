using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Maquinaria_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            listarMaquinaria();
        }
    }

    public void listarMaquinaria()
    {
        MaquinariaBL oMaq = new MaquinariaBL();
        List<MaquinariaEL> lst = oMaq.ConsultarMaquinaria();
        gvMaquinaria.DataSource = lst;
        gvMaquinaria.DataBind();
    }

    protected void gvMaquinaria_PreRender(object sender, EventArgs e)
    {
        if (gvMaquinaria.Rows.Count > 0)
        {
            gvMaquinaria.UseAccessibleHeader = true;
            gvMaquinaria.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvMaquinaria.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
}