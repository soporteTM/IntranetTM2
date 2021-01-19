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
        TMS_EmpresaBL oEmpresa = new TMS_EmpresaBL(); 
        TMS_EmpresaEL LocalesEL = new TMS_EmpresaEL();
        LocalesEL.ENT_CODI = "*";
        LocalesEL.ENT_DIRE = "*";
        LocalesEL.ENT_Empresa = "*";
        LocalesEL.ENT_NOMC = "*";
        LocalesEL.ENT_RSOC = term;
        LocalesEL.ENT_RUC = "*";
        List <TMS_EmpresaEL> lst = oEmpresa.ListarEmpresas(LocalesEL);
        if (lst.Count > 1)
        {
            if (lst[0].ENT_RSOC.Trim() == "SELECIONE CLIENTE")
                lst.RemoveAt(0);
        }
        var data = from emp in lst select new { id = emp.ENT_CODI, descripcion = emp.ENT_RSOC + " (" +  emp.ENT_RUC + ")", ruc = emp.ENT_RUC  };        
        var json = new JavaScriptSerializer().Serialize(data.ToList());
        context.Response.Write(json);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }
}