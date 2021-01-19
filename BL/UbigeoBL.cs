using DAL;
using EL;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class UbigeoBL
    {
        UbigeoDAL oItem = new UbigeoDAL();
        public List<UbigeoEL> ListarUbigeo(string cod_departamento, string cod_provincia, string cod_distrito)
        {            
            return oItem.ListarUbigeo(cod_departamento, cod_provincia, cod_distrito);
        }

       
    }
}
