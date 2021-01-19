<%@ WebHandler Language="C#" Class="Handler" %>
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using EL;
using System.Collections.Generic;

using System.Data;
using System.Text;
using System.IO;
using System.Drawing;
using System.Web.Script.Serialization;
public class Handler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string filtro = HttpContext.Current.Request.QueryString["term"];
        CatalogoBL objCatalogo = new CatalogoBL();
        DataTable Data = objCatalogo.Consultar(filtro);
        List<ItemEL> DataEmpleado = Data.AsEnumerable().ToList().ConvertAll(x => new ItemEL { id_descripcion = x.ItemArray[0].ToString(), descripcion = (string)x.ItemArray[1] });//.Select(i => id = i.id_key, descripcion = i.descripcion);
        var jsonData = from cont in DataEmpleado.AsEnumerable() select new { id = cont.id_descripcion, descripcion = cont.descripcion };
        var json = new JavaScriptSerializer().Serialize(jsonData);
        context.Response.Write(json);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}