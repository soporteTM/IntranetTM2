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
        
        FlotaBL oFlota = new FlotaBL();
        List<FlotaEL> lst = oFlota.ConsultarFlota(0,"");

        string term = HttpContext.Current.Request.QueryString["term"];

        var data = from cont in lst where cont.nro_placa.Contains(term) select new { id = cont.cod_flota, descripcion = cont.nro_placa };

        //System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
        //MemoryStream ms = new MemoryStream();
        //serializer.WriteObject(ms, data);
        //string json = Encoding.Default.GetString(ms.ToArray());
        //return json;

        var json = new JavaScriptSerializer().Serialize(data.ToList());
        context.Response.Write(json); 

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}