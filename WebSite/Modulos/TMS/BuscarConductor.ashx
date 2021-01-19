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
        TMS_ChoferEL ChoferEL = new TMS_ChoferEL();
        ChoferEL.CHOFER = term;
        List <TMS_ChoferEL> lst = oSeguimiento.GetChoferxEmp(88,ChoferEL.CHOFER);
        if (lst.Count > 1)
        {
                lst.RemoveAt(0);
        }
        var data = from cond in lst select new { id = cond.CHOFER_CODIGO, descripcion = cond.CHOFER };
        var json = new JavaScriptSerializer().Serialize(data.ToList());
        context.Response.Write(json);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }
}