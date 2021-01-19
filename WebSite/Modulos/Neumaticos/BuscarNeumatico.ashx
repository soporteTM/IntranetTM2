<%@ WebHandler Language="C#" Class="Handler" %>
using System; 
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO; 
using System.Drawing;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using BL;
using EL;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        NeumaticoBL oNeumatico = new NeumaticoBL();
        List<NeumaticoEL> lst = oNeumatico.ListarNeumatico(0);

        string term = HttpContext.Current.Request.QueryString["term"];

        var data = from cont in lst where cont.nro_serie.Contains(term) select new { id = cont.id_nm , descripcion = cont.nro_serie };

        var json = new JavaScriptSerializer().Serialize(data.ToList());
        context.Response.Write(json);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}