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
    public class ItemBL
    {
        public List<ItemEL> ListarItem(string id_catalogo)
        {
            ItemDAL oItem = new ItemDAL();
            return oItem.ListarItem(id_catalogo);
        }

        public List<ItemEL> ListarItemOpe(string id_catalogo)
        {
            ItemDAL oItem = new ItemDAL();
            return oItem.ListarItemOpe(id_catalogo);
        }

        public List<ItemEL> ListarItemOperaciones(string id_catalogo)
        {
            ItemDAL oItem = new ItemDAL();
            return oItem.ListarItemOperaciones(id_catalogo);
        }

        public List<ItemEL> ListarItemFlota(string id_catalogo)
        {
            ItemDAL oItem = new ItemDAL();
            return oItem.ListarItemCatalogoFlota(id_catalogo);
        }

        public List<ItemEL> ListarItemDocu(string id_catalogo)
        {
            ItemDAL oItem = new ItemDAL();
            return oItem.ListarItemDocu(id_catalogo);
        }
        public List<ItemEL> ConsultarCatalogo(string id_catalogo)
        {
            ItemDAL oItem = new ItemDAL();
            return oItem.ConsultarCatalogo(id_catalogo);
        }

        public List<ItemEL> ConsultarCatalogoOperaciones(string id_catalogo)
        {
            ItemDAL oItem = new ItemDAL();
            return oItem.ConsultarCatalogoOperaciones(id_catalogo);
        }

        public List<TransaccionEL> ObtenerID()
        {
            ItemDAL oItem = new ItemDAL();
            return oItem.ObtenerID();
        }
    }
}
