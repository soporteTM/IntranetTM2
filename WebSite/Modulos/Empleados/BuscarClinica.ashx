﻿<%@ WebHandler Language="C#" Class="BuscarClinica" %>
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

public class BuscarClinica : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
        DescansoMedicoBL oDescanso = new DescansoMedicoBL();
        List<DescansoMedicoEL> lst = oDescanso.BuscarClinica();

        string term = HttpContext.Current.Request.QueryString["term"];

        var data = from cont in lst where cont.desc_clinica.Contains(term) select new { id = cont.cod_clinica, descripcion = cont.desc_clinica };

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