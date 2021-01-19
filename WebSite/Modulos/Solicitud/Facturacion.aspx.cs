using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Solicitud_Facturacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string CrearXml(string archivo)
    {
        string carpetaUsuario="";
        string archivoXml = "";
        Stream strStreamW = null;
        string mensaje="";
        string pUsuario = "";

        StreamWriter strStreamWriter= null;

        carpetaUsuario = "d:\"Documentos XML\" & pUsuario & \"";

        try
        {
            if (Directory.Exists(carpetaUsuario) == false)
            {
                Directory.CreateDirectory(carpetaUsuario);
            }
            archivoXml = carpetaUsuario + archivo +System.DateTime.Today + ".xml";

            if (File.Exists(archivoXml))
            {
                strStreamW = File.Open(archivoXml, FileMode.Open);
            }
            else
            {
                strStreamW = File.Create(archivoXml);
            }

        }
        catch(Exception ex)
        {

        }



        return archivoXml;
    }
    //        If Directory.Exists(carpetaUsuario) = False Then ' si no existe la carpeta se crea
    //            Directory.CreateDirectory(carpetaUsuario)
    //        End If

    //        archivoXml = carpetaUsuario & archivo & Format(Today.Date, "ddMMyyyy") & ".xml"

    //        'verificamos si existe el archivo

    //        If File.Exists(archivoXml) Then
    //            strStreamW = File.Open(archivoXml, FileMode.Open) 'Abrimos el archivo
    //        Else
    //            strStreamW = File.Create(archivoXml) ' lo creamos
    //        End If

    //        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura


    //        'escribimos en el archivo

    //        strStreamWriter.WriteLine("")


    //        strStreamWriter.Close() ' cerramos

            

    //    Catch ex As Exception
    //        lblMensaje.Text = "No se pudo crear el archivo xml"
    //    End Try

    //End Function

}