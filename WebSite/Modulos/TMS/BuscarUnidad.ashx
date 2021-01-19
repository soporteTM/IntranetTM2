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
        string term = HttpContext.Current.Request.QueryString["term"];
        TMS_SeguimientoBL oSeguimiento = new TMS_SeguimientoBL();
        TMS_SeguimientoEL SeguimientoEL = new TMS_SeguimientoEL();
        SeguimientoEL.UNIDAD_PLACA = term;
        List <TMS_SeguimientoEL> lst = oSeguimiento.UnidadxEmp(88,SeguimientoEL.UNIDAD_PLACA);
        if (lst.Count > 1)
        {
            lst.RemoveAt(0);
        }
        var data = from und in lst select new { id = und.UNIDAD_CODIGO, descripcion = und.UNIDAD_PLACA };
        var json = new JavaScriptSerializer().Serialize(data.ToList());
        context.Response.Write(json);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }
}