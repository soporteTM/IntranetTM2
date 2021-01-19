using EL;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MantenimientoDAL
    {
        public List<ItemEL> ListarDepartamento()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "TM_ubigeo_departamento");

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }

        public List<ItemEL> ListarProvincia(string cod_dep)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@cod_dep", SqlDbType.VarChar, 2);
            arParams[0].Value = cod_dep;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "TM_ubigeo_provincia", arParams);

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }

        public List<ItemEL> ListarDistrito(string cod_dep, string cod_pro)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@cod_dep", SqlDbType.VarChar, 2);
            arParams[0].Value = cod_dep;

            arParams[1] = new SqlParameter("@cod_pro", SqlDbType.VarChar, 2);
            arParams[1].Value = cod_pro;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "TM_ubigeo_distrito", arParams);

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }
    }

    public class MantenimientoClienteDAL
    {
        public List<MantenimientoClienteEL> ListarCliente()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "CLI_Cliente_Listar");

            List<MantenimientoClienteEL> lstItem = new List<MantenimientoClienteEL>();
            lstItem = Util.ConvertDataTable<MantenimientoClienteEL>(dt);

            return lstItem;
        }

        public List<MantenimientoClienteEL> InsertarCliente(MantenimientoClienteEL oCliente)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[6];

            arParams[0] = new SqlParameter("@tipo_documento", SqlDbType.VarChar, 6);
            arParams[0].Value = oCliente.tipo_documento;

            arParams[1] = new SqlParameter("@nro_documento", SqlDbType.VarChar, 200);
            arParams[1].Value = oCliente.nro_documento;

            arParams[2] = new SqlParameter("@razon_social", SqlDbType.VarChar, 200);
            arParams[2].Value = oCliente.razon_social;

            arParams[3] = new SqlParameter("@nombre_comercial", SqlDbType.VarChar, 200);
            arParams[3].Value = oCliente.nombre_comercial;

            arParams[4] = new SqlParameter("@direccion", SqlDbType.VarChar, 200);
            arParams[4].Value = oCliente.direccion;

            arParams[5] = new SqlParameter("@usuario_creacion", SqlDbType.VarChar, 200);
            arParams[5].Value = oCliente.usuario_creacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "CLI_Cliente_Insertar", arParams);

            List<MantenimientoClienteEL> lstItem = new List<MantenimientoClienteEL>();
            lstItem = Util.ConvertDataTable<MantenimientoClienteEL>(dt);

            return lstItem;
        }

        public List<MantenimientoClienteEL> ModificarCliente(MantenimientoClienteEL oCliente)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@cod_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = oCliente.codigo_cliente;

            arParams[1] = new SqlParameter("@tipo_documento", SqlDbType.VarChar, 6);
            arParams[1].Value = oCliente.tipo_documento;

            arParams[2] = new SqlParameter("@nro_documento", SqlDbType.VarChar, 200);
            arParams[2].Value = oCliente.nro_documento;

            arParams[3] = new SqlParameter("@razon_social", SqlDbType.VarChar, 200);
            arParams[3].Value = oCliente.razon_social;

            arParams[4] = new SqlParameter("@nombre_comercial", SqlDbType.VarChar, 200);
            arParams[4].Value = oCliente.nombre_comercial;

            arParams[5] = new SqlParameter("@direccion", SqlDbType.VarChar, 200);
            arParams[5].Value = oCliente.direccion;

            arParams[6] = new SqlParameter("@usuario", SqlDbType.VarChar, 200);
            arParams[6].Value = oCliente.usuario_modificacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "CLI_Cliente_Actualizar", arParams);

            List<MantenimientoClienteEL> lstItem = new List<MantenimientoClienteEL>();
            lstItem = Util.ConvertDataTable<MantenimientoClienteEL>(dt);

            return lstItem;
        }

        public List<MantenimientoClienteEL> EliminarCliente(MantenimientoClienteEL oCliente)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@cod_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = oCliente.codigo_cliente;

            arParams[1] = new SqlParameter("@usuario", SqlDbType.VarChar, 200);
            arParams[1].Value = oCliente.usuario_modificacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "CLI_Cliente_Eliminar", arParams);

            List<MantenimientoClienteEL> lstItem = new List<MantenimientoClienteEL>();
            lstItem = Util.ConvertDataTable<MantenimientoClienteEL>(dt);

            return lstItem;
        }


    }

    public class MantenimientoLocalDAL
    {
        public List<MantenimientoLocalEL> ListarLocal(int oLocal)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@cod_cliente", SqlDbType.Int);
            arParams[0].Value = oLocal;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "CLI_Local_Listar", arParams);

            List<MantenimientoLocalEL> lstItem = new List<MantenimientoLocalEL>();
            lstItem = Util.ConvertDataTable<MantenimientoLocalEL>(dt);

            return lstItem;
        }
   
        public List<MantenimientoLocalEL> InsertarLocal(MantenimientoLocalEL oLocal)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@codigo_cliente", SqlDbType.Int);
            arParams[0].Value = oLocal.codigo_cliente;

            arParams[1] = new SqlParameter("@direccion", SqlDbType.VarChar, 300);
            arParams[1].Value = oLocal.direccion;

            arParams[2] = new SqlParameter("@codigo_ubigeo", SqlDbType.VarChar, 6);
            arParams[2].Value = oLocal.codigo_ubigeo;

            arParams[3] = new SqlParameter("@usuario_creacion", SqlDbType.VarChar, 50);
            arParams[3].Value = oLocal.usuario_creacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "CLI_Local_Insertar", arParams);

            List<MantenimientoLocalEL> lstItem = new List<MantenimientoLocalEL>();
            lstItem = Util.ConvertDataTable<MantenimientoLocalEL>(dt);

            return lstItem;
        }

        public List<MantenimientoLocalEL> ModificarLocal(MantenimientoLocalEL oLocal)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@cod_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = oLocal.codigo_cliente;

            arParams[1] = new SqlParameter("@cod_local", SqlDbType.Int);
            arParams[1].Value = oLocal.codigo_local;

            arParams[2] = new SqlParameter("@direccion", SqlDbType.VarChar, 400);
            arParams[2].Value = oLocal.direccion;

            arParams[3] = new SqlParameter("@codigo_ubigeo", SqlDbType.VarChar, 6);
            arParams[3].Value = oLocal.codigo_ubigeo;

            arParams[4] = new SqlParameter("@usuario", SqlDbType.VarChar, 100);
            arParams[4].Value = oLocal.usuario_modificacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "CLI_Local_Actualizar", arParams);

            List<MantenimientoLocalEL> lstItem = new List<MantenimientoLocalEL>();
            lstItem = Util.ConvertDataTable<MantenimientoLocalEL>(dt);

            return lstItem;
        }

        public List<MantenimientoLocalEL> EliminarLocal(MantenimientoLocalEL oLocal)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@cod_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = oLocal.codigo_cliente;

            arParams[1] = new SqlParameter("@cod_local", SqlDbType.Int);
            arParams[1].Value = oLocal.codigo_local;

            arParams[2] = new SqlParameter("@usuario", SqlDbType.VarChar, 200);
            arParams[2].Value = oLocal.usuario_modificacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "CLI_Local_Eliminar", arParams);

            List<MantenimientoLocalEL> lstItem = new List<MantenimientoLocalEL>();
            lstItem = Util.ConvertDataTable<MantenimientoLocalEL>(dt);

            return lstItem;
        }
    }
    public class MantenimientoContactoDAL
    {
        public List<MantenimientoContactoEL> ListarContacto(MantenimientoContactoEL oContacto)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@codigo_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = oContacto.codigo_cliente;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "CLI_Contacto_Listar", arParams);

            List<MantenimientoContactoEL> lstItem = new List<MantenimientoContactoEL>();
            lstItem = Util.ConvertDataTable<MantenimientoContactoEL>(dt);

            return lstItem;
        }
   
        public List<TransaccionEL> InsertarContacto(MantenimientoContactoEL oContacto)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[11];
            arParams[0] = new SqlParameter("@codigo_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = oContacto.codigo_cliente;

            arParams[1] = new SqlParameter("@nombre", SqlDbType.VarChar, 200);
            arParams[1].Value = oContacto.nombre;

            arParams[2] = new SqlParameter("@apellido_pat", SqlDbType.VarChar, 200);
            arParams[2].Value = oContacto.apellido_pat;

            arParams[3] = new SqlParameter("@apellido_mat", SqlDbType.VarChar, 200);
            arParams[3].Value = oContacto.apellido_mat;

            arParams[4] = new SqlParameter("@cargo", SqlDbType.VarChar, 200);
            arParams[4].Value = oContacto.cargo;

            arParams[5] = new SqlParameter("@correo", SqlDbType.VarChar, 200);
            arParams[5].Value = oContacto.correo;

            arParams[6] = new SqlParameter("@telefono", SqlDbType.VarChar, 20);
            arParams[6].Value = oContacto.telefono;

            arParams[7] = new SqlParameter("@anexo", SqlDbType.VarChar, 30);
            arParams[7].Value = oContacto.anexo;

            arParams[8] = new SqlParameter("@fecha_nacimiento", SqlDbType.VarChar, 10);
            arParams[8].Value = oContacto.fecha_nacimiento;
      
            arParams[9] = new SqlParameter("@observacion", SqlDbType.VarChar, 300);
            arParams[9].Value = oContacto.observacion;

            arParams[10] = new SqlParameter("@usuario_creacion", SqlDbType.VarChar, 200);
            arParams[10].Value = oContacto.usuario_creacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "CLI_Contacto_Insertar", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> ModificarContacto(MantenimientoContactoEL oContacto)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[12];
            arParams[0] = new SqlParameter("@contacto_id", SqlDbType.Int);
            arParams[0].Value = oContacto.contacto_id;

            arParams[1] = new SqlParameter("@codigo_cliente", SqlDbType.VarChar, 6);
            arParams[1].Value = oContacto.codigo_cliente;

            arParams[2] = new SqlParameter("@nombre", SqlDbType.VarChar, 200);
            arParams[2].Value = oContacto.nombre;

            arParams[3] = new SqlParameter("@apellido_pat", SqlDbType.VarChar, 200);
            arParams[3].Value = oContacto.apellido_pat;

            arParams[4] = new SqlParameter("@apellido_mat", SqlDbType.VarChar, 200);
            arParams[4].Value = oContacto.apellido_mat;

            arParams[5] = new SqlParameter("@cargo", SqlDbType.VarChar, 200);
            arParams[5].Value = oContacto.cargo;

            arParams[6] = new SqlParameter("@correo", SqlDbType.VarChar, 200);
            arParams[6].Value = oContacto.correo;
        
            arParams[7] = new SqlParameter("@telefono", SqlDbType.VarChar, 20);
            arParams[7].Value = oContacto.telefono;

            arParams[8] = new SqlParameter("@anexo", SqlDbType.VarChar, 30);
            arParams[8].Value = oContacto.anexo;

            arParams[9] = new SqlParameter("@fecha_nacimiento", SqlDbType.VarChar, 10);
            arParams[9].Value = oContacto.fecha_nacimiento;

            arParams[10] = new SqlParameter("@observacion", SqlDbType.VarChar, 300);
            arParams[10].Value = oContacto.observacion;

            arParams[11] = new SqlParameter("@usuario", SqlDbType.VarChar, 200);
            arParams[11].Value = oContacto.usuario_modificacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "CLI_Contacto_Actualizar", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> EliminarContacto(MantenimientoContactoEL oContacto)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@codigo_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = oContacto.codigo_cliente;

            arParams[1] = new SqlParameter("@contacto_id", SqlDbType.VarChar, 6);
            arParams[1].Value = oContacto.contacto_id;

            arParams[2] = new SqlParameter("@usuario_modificacion", SqlDbType.VarChar, 200);
            arParams[2].Value = oContacto.usuario_modificacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "CLI_Contacto_Eliminar", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }



    }
}
