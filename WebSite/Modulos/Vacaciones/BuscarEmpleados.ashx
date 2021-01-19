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
        EmpleadoBL objEmpleadoBuscar = new EmpleadoBL();
        DataTable Data = objEmpleadoBuscar.Consultar(filtro);
        List<EmpleadoEL> DataEmpleado = Data.AsEnumerable().ToList().ConvertAll(x => new EmpleadoEL { id_key = (int)x.ItemArray[0], nombre_emp = (string)x.ItemArray[8] });//.Select(i => id = i.id_key, descripcion = i.descripcion);
        var jsonData = from cont in DataEmpleado.AsEnumerable() select new { id = cont.id_key, descripcion = cont.nombre_emp };
        var json = new JavaScriptSerializer().Serialize(jsonData);
        context.Response.Write(json);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}