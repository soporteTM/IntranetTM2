using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLHelper;


namespace DAL
{
    public class EmpleadoDAL
    {
        public List<ItemEL> ListarItem(string id_catalogo)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_catalogo", SqlDbType.VarChar, 2);
            arParams[0].Value = id_catalogo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "HR_Catalogo_Consultar", arParams);

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }

        public DataTable Consultar(string nombre,string estado)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@nombre", SqlDbType.VarChar, 100);
            arParams[0].Value = nombre;

            arParams[1] = new SqlParameter("@estado", SqlDbType.VarChar, 1);
            arParams[1].Value = estado;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Consultar", arParams);

            //List<ItemEL> lstItem = new List<ItemEL>();
            //lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return dt;
        }

        public DataTable Consultar(string nombre)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@nombre", SqlDbType.VarChar, 100);
            arParams[0].Value = nombre;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Consultar", arParams);

            //List<ItemEL> lstItem = new List<ItemEL>();
            //lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return dt;
        }

        public DataTable Exportar()
        {
            DataTable dt;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Exportar");

            List<EmpleadoEL> lstItem = new List<EmpleadoEL>();
            lstItem = Util.ConvertDataTable<EmpleadoEL>(dt);

            return dt;
        }

        public DataTable Consultar_PorCodigo(int id_key)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_key", SqlDbType.Int);
            arParams[0].Value = id_key;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Consultar_PorCodigo", arParams);

            //List<ItemEL> lstItem = new List<ItemEL>();
            //lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return dt;
        }

        public List<EmpleadoEL> Consultar_PorCodigoV2(int id_key)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@idPersonal", SqlDbType.Int);
            arParams[0].Value = id_key;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Consultar_PorCodigoV2", arParams);

            //List<ItemEL> lstItem = new List<ItemEL>();
            //lstItem = Util.ConvertDataTable<ItemEL>(dt);

            List<EmpleadoEL> lstItem = new List<EmpleadoEL>();
            lstItem = Util.ConvertDataTable<EmpleadoEL>(dt);

            return lstItem;
        }

        public List<NombradaEL> ListarAdministrativo()
        {
            DataTable dt;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "RRHH_Listado_administrativo");
            List<NombradaEL> lstItem = new List<NombradaEL>();
            lstItem = Util.ConvertDataTable<NombradaEL>(dt);
            return lstItem;
        }

        public List<EmpleadoDocumentoEL> Consultar_EmpleadoDocumento(int id_empleado, string carpeta, string ficha)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@IDPersonal", SqlDbType.Int);
            arParams[0].Value = id_empleado;

            arParams[1] = new SqlParameter("@TipoCarpeta", SqlDbType.VarChar);
            arParams[1].Value = carpeta;

            arParams[2] = new SqlParameter("@TipoDocumento", SqlDbType.VarChar);
            arParams[2].Value = ficha;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Documento_Consultar", arParams);

            List<EmpleadoDocumentoEL> lstItem = new List<EmpleadoDocumentoEL>();
            lstItem = Util.ConvertDataTable<EmpleadoDocumentoEL>(dt);

            return lstItem;
        }

        public List<EmpleadoDocumentoEL> Consultar_EmpleadoDocumento_PorCodigo(int id_documento)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@IDDocumento ", SqlDbType.Int);
            arParams[0].Value = id_documento; 

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Documento_Consultar_PorCodigo", arParams);

            List<EmpleadoDocumentoEL> lstItem = new List<EmpleadoDocumentoEL>();
            lstItem = Util.ConvertDataTable<EmpleadoDocumentoEL>(dt);

            return lstItem;
        }

        public List<EmpleadoFormacionEL> Consultar_EmpleadoFormacion_PorCodigo(int cod_id)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@cod_id", SqlDbType.Int);
            arParams[0].Value = cod_id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Formacion_ConsultarPorEmpleado", arParams);

            List<EmpleadoFormacionEL> lstItem = new List<EmpleadoFormacionEL>();
            lstItem = Util.ConvertDataTable<EmpleadoFormacionEL>(dt);

            return lstItem;
        }


        public List<EmpleadoIdiomaEL> Consultar_EmpleadoIdioma_PorCodigo(int cod_id)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@cod_id", SqlDbType.Int);
            arParams[0].Value = cod_id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Idioma_ConsultarPorEmpleado", arParams);

            List<EmpleadoIdiomaEL> lstItem = new List<EmpleadoIdiomaEL>();
            lstItem = Util.ConvertDataTable<EmpleadoIdiomaEL>(dt);

            return lstItem;
        }

        public List<EmpleadoInteresEL> Consultar_EmpleadoInteres_PorCodigo(int cod_id)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@cod_id", SqlDbType.Int);
            arParams[0].Value = cod_id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Intereses_ConsultarPorEmpleado", arParams);

            List<EmpleadoInteresEL> lstItem = new List<EmpleadoInteresEL>();
            lstItem = Util.ConvertDataTable<EmpleadoInteresEL>(dt);

            return lstItem;
        }

        public List<EmpleadoExperienciaEL> Consultar_ExperienciaInteres_PorCodigo(int cod_id)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@cod_id", SqlDbType.Int);
            arParams[0].Value = cod_id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Experiencia_ConsultarPorEmpleado", arParams);

            List<EmpleadoExperienciaEL> lstItem = new List<EmpleadoExperienciaEL>();
            lstItem = Util.ConvertDataTable<EmpleadoExperienciaEL>(dt);

            return lstItem;
        }



        public List<TransaccionEL> ObtenerID()
        {
            DataTable dt;
           
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "TM_Generar_OT");

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> Registrar(EmpleadoEL Entidad)
        {
           
            Type t = Entidad.GetType();
            System.Reflection.PropertyInfo[] properties = t.GetProperties();
            int total_propiedades = properties.Count();

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[total_propiedades - 1];

            int pos = 0;
            foreach (System.Reflection.PropertyInfo p in properties)
            {

                if (p.Name.ToLower().Length > 9)
                    if (p.Name.ToLower().Substring(0, 9) == "opcional_")
                        continue;

                if (p.Name.ToLower() == "id_key")
                    continue;

                object PropertyValue = p.GetValue(Entidad, null);
                SqlDbType TypeSql = SqlDbType.VarChar;

                if (p.PropertyType.Name.ToLower() == "int" || p.PropertyType.Name.ToLower() == "int32")
                    TypeSql = SqlDbType.Int;
                if (p.PropertyType.Name.ToLower() == "datetime")
                    TypeSql = SqlDbType.DateTime;
                if (p.PropertyType.Name.ToLower() == "decimal")
                    TypeSql = SqlDbType.Decimal;

                arParams[pos] = new SqlParameter("@" + p.Name, TypeSql);
                arParams[pos].Value = PropertyValue;
                pos++;
            }

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Registrar_v2", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> Actualizar(EmpleadoEL Entidad)
        {

            Type t = Entidad.GetType();
            System.Reflection.PropertyInfo[] properties = t.GetProperties();
            int total_propiedades = properties.Count();

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[0];

            int pos = 0;
            foreach (System.Reflection.PropertyInfo p in properties)
            {

                if (p.Name.ToLower().Length > 9)
                    if (p.Name.ToLower().Substring(0, 9) == "opcional_")
                        continue;

                //if (p.Name.ToLower() == "id_key")
                //    continue;
                Array.Resize(ref arParams, arParams.Length + 1);
                object PropertyValue = p.GetValue(Entidad, null);
                SqlDbType TypeSql = SqlDbType.VarChar;

                if (p.PropertyType.Name.ToLower() == "int" || p.PropertyType.Name.ToLower() == "int32")
                    TypeSql = SqlDbType.Int;
                if (p.PropertyType.Name.ToLower() == "datetime")
                    TypeSql = SqlDbType.DateTime;
                if (p.PropertyType.Name.ToLower() == "decimal")
                    TypeSql = SqlDbType.Decimal;

                arParams[pos] = new SqlParameter("@" + p.Name, TypeSql);
                arParams[pos].Value = PropertyValue;
                pos++;
            }

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Actualizar", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> ActualizarDocumento(EmpleadoDocumentoEL Entidad)
        {
            Type t = Entidad.GetType();
            System.Reflection.PropertyInfo[] properties = t.GetProperties();
            int total_propiedades = properties.Count();

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[0];

            int pos = 0;
            foreach (System.Reflection.PropertyInfo p in properties)
            {
                if (p.Name.ToLower().Length > 9)
                    if (p.Name.ToLower().Substring(0, 9) == "opcional_")
                        continue;
 
                Array.Resize(ref arParams, arParams.Length + 1);
                object PropertyValue = p.GetValue(Entidad, null);
                SqlDbType TypeSql = SqlDbType.VarChar;

                if (p.PropertyType.Name.ToLower() == "int" || p.PropertyType.Name.ToLower() == "int32")
                    TypeSql = SqlDbType.Int;
                if (p.PropertyType.Name.ToLower() == "datetime")
                    TypeSql = SqlDbType.DateTime;
                if (p.PropertyType.Name.ToLower() == "boolean")
                    TypeSql = SqlDbType.Bit;
                if (p.PropertyType.Name.ToLower() == "decimal")
                    TypeSql = SqlDbType.Decimal;

                arParams[pos] = new SqlParameter("@" + p.Name, TypeSql);
                arParams[pos].Value = PropertyValue;
                pos++;
            }

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Documento_Actualizar", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> Actualizar_CarpetaCompartida(int id_empleado, string carpeta)
        {
            
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@id_key", SqlDbType.Int);
            arParams[0].Value = id_empleado;
            arParams[1] = new SqlParameter("@carpeta_compartida", SqlDbType.VarChar,250);
            arParams[1].Value = carpeta;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Actualizar_CarpetaCompartida", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> RegistrarDocumento(EmpleadoDocumentoEL Entidad)
        {
            Type t = Entidad.GetType();
            System.Reflection.PropertyInfo[] properties = t.GetProperties();
            int total_propiedades = properties.Count();

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[0];

            int pos = 0;
            foreach (System.Reflection.PropertyInfo p in properties)
            {
                if (p.Name.ToLower().Length > 9)
                    if (p.Name.ToLower().Substring(0, 9) == "opcional_")
                        continue;

                if (p.Name.ToLower() == "id_key")
                    continue;

                Array.Resize(ref arParams, arParams.Length + 1);
                object PropertyValue = p.GetValue(Entidad, null);
                SqlDbType TypeSql = SqlDbType.VarChar;

                if (p.PropertyType.Name.ToLower() == "int" || p.PropertyType.Name.ToLower() == "int32")
                    TypeSql = SqlDbType.Int;
                if (p.PropertyType.Name.ToLower() == "datetime")
                    TypeSql = SqlDbType.DateTime;
                if (p.PropertyType.Name.ToLower() == "boolean")
                    TypeSql = SqlDbType.Bit;
                if (p.PropertyType.Name.ToLower() == "decimal")
                    TypeSql = SqlDbType.Decimal;

                arParams[pos] = new SqlParameter("@" + p.Name, TypeSql);
                arParams[pos].Value = PropertyValue;
                pos++;
            }

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Documento_Registrar", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        //Inicio Familiares 
        public List<TransaccionEL> RegistrarFamiliar(EmpleadoFamiliaEL Entidad)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[12];

            arParams[0] = new SqlParameter("@cod_id", SqlDbType.Int);
            arParams[0].Value = Entidad.cod_id;

            arParams[1] = new SqlParameter("@cod_parentesco", SqlDbType.VarChar, 6);
            arParams[1].Value = Entidad.cod_parentesco;

            arParams[2] = new SqlParameter("@fam_nombre", SqlDbType.VarChar, 50);
            arParams[2].Value = Entidad.fam_nombre;

            arParams[3] = new SqlParameter("@fam_apellido_pat", SqlDbType.VarChar, 50);
            arParams[3].Value = Entidad.fam_apellido_pat;

            arParams[4] = new SqlParameter("@fam_apellido_mat", SqlDbType.VarChar, 50);
            arParams[4].Value = Entidad.fam_apellido_mat;

            arParams[5] = new SqlParameter("@fch_nacimiento", SqlDbType.DateTime);
            arParams[5].Value = Entidad.fch_nacimiento;

            arParams[6] = new SqlParameter("@lugar_nacimiento", SqlDbType.VarChar, 50);
            arParams[6].Value = Entidad.lugar_nacimiento;

            arParams[7] = new SqlParameter("@cod_ocupacion", SqlDbType.VarChar, 6);
            arParams[7].Value = Entidad.cod_ocupacion;

            arParams[8] = new SqlParameter("@lugar_trabajo", SqlDbType.VarChar, 50);
            arParams[8].Value = Entidad.lugar_trabajo;

            arParams[9] = new SqlParameter("@telf_of", SqlDbType.VarChar, 10);
            arParams[9].Value = Entidad.telf_of;

            arParams[10] = new SqlParameter("@telf_casa", SqlDbType.VarChar, 10);
            arParams[10].Value = Entidad.telf_casa;

            arParams[11] = new SqlParameter("@llamar_emergencia", SqlDbType.VarChar, 6);
            arParams[11].Value = Entidad.llamar_emergencia;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Familia_Registrar", arParams);
            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }



        public List<TransaccionEL> ActualizarFamiliar(EmpleadoFamiliaEL Entidad)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[12];

            arParams[0] = new SqlParameter("@cod_id", SqlDbType.Int);
            arParams[0].Value = Entidad.cod_id;

            arParams[1] = new SqlParameter("@cod_parentesco", SqlDbType.VarChar, 6);
            arParams[1].Value = Entidad.cod_parentesco;

            arParams[2] = new SqlParameter("@fam_nombre", SqlDbType.VarChar, 50);
            arParams[2].Value = Entidad.fam_nombre;

            arParams[3] = new SqlParameter("@fam_apellido_pat", SqlDbType.VarChar, 50);
            arParams[3].Value = Entidad.fam_apellido_pat;

            arParams[4] = new SqlParameter("@fam_apellido_mat", SqlDbType.VarChar, 50);
            arParams[4].Value = Entidad.fam_apellido_mat;

            arParams[5] = new SqlParameter("@fch_nacimiento", SqlDbType.DateTime);
            arParams[5].Value = Entidad.fch_nacimiento;

            arParams[6] = new SqlParameter("@lugar_nacimiento", SqlDbType.VarChar, 50);
            arParams[6].Value = Entidad.lugar_nacimiento;

            arParams[7] = new SqlParameter("@cod_ocupacion", SqlDbType.VarChar, 6);
            arParams[7].Value = Entidad.cod_ocupacion;

            arParams[8] = new SqlParameter("@lugar_trabajo", SqlDbType.VarChar, 50);
            arParams[8].Value = Entidad.lugar_trabajo;

            arParams[9] = new SqlParameter("@telf_of", SqlDbType.VarChar, 10);
            arParams[9].Value = Entidad.telf_of;

            arParams[10] = new SqlParameter("@telf_casa", SqlDbType.VarChar, 10);
            arParams[10].Value = Entidad.telf_casa;

            arParams[11] = new SqlParameter("@llamar_emergencia", SqlDbType.VarChar, 6);
            arParams[11].Value = Entidad.llamar_emergencia;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Familia_Actualizar", arParams);
            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);
            return lstData;

        }



       
        public List<EmpleadoFamiliaEL> Consultar_EmpleadoFamiliar_PorCodigo(int cod_id)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@cod_id", SqlDbType.Int);
            arParams[0].Value = cod_id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Familia_ConsultarPorEmpleado", arParams);

            List<EmpleadoFamiliaEL> lstItem = new List<EmpleadoFamiliaEL>();
            lstItem = Util.ConvertDataTable<EmpleadoFamiliaEL>(dt);

            return lstItem;
        }

        //Fin Familiares


        public List<TransaccionEL> RegistrarFormacion( EmpleadoFormacionEL Entidad)
        {
            Type t = Entidad.GetType();
            System.Reflection.PropertyInfo[] properties = t.GetProperties();
            int total_propiedades = properties.Count();

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[0];

            int pos = 0;
            foreach (System.Reflection.PropertyInfo p in properties)
            {
                if (p.Name.ToLower().Length > 9)
                    if (p.Name.ToLower().Substring(0, 9) == "opcional_")
                        continue;

                if (p.Name.ToLower() == "id_key")
                    continue;

                Array.Resize(ref arParams, arParams.Length + 1);
                object PropertyValue = p.GetValue(Entidad, null);
                SqlDbType TypeSql = SqlDbType.VarChar;

                if (p.PropertyType.Name.ToLower() == "int" || p.PropertyType.Name.ToLower() == "int32")
                    TypeSql = SqlDbType.Int;
                if (p.PropertyType.Name.ToLower() == "datetime")
                    TypeSql = SqlDbType.DateTime;
                if (p.PropertyType.Name.ToLower() == "decimal")
                    TypeSql = SqlDbType.Decimal;

                arParams[pos] = new SqlParameter("@" + p.Name, TypeSql);
                arParams[pos].Value = PropertyValue;
                pos++;
            }

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Formacion_Registrar", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> RegistrarIdioma(EmpleadoIdiomaEL Entidad)
        {
            Type t = Entidad.GetType();
            System.Reflection.PropertyInfo[] properties = t.GetProperties();
            int total_propiedades = properties.Count();

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[0];

            int pos = 0;
            foreach (System.Reflection.PropertyInfo p in properties)
            {
                if (p.Name.ToLower().Length > 9)
                    if (p.Name.ToLower().Substring(0, 9) == "opcional_")
                        continue;

                if (p.Name.ToLower() == "id_key")
                    continue;

                Array.Resize(ref arParams, arParams.Length + 1);
                object PropertyValue = p.GetValue(Entidad, null);
                SqlDbType TypeSql = SqlDbType.VarChar;

                if (p.PropertyType.Name.ToLower() == "int" || p.PropertyType.Name.ToLower() == "int32")
                    TypeSql = SqlDbType.Int;
                if (p.PropertyType.Name.ToLower() == "datetime")
                    TypeSql = SqlDbType.DateTime;
                if (p.PropertyType.Name.ToLower() == "decimal")
                    TypeSql = SqlDbType.Decimal;

                arParams[pos] = new SqlParameter("@" + p.Name, TypeSql);
                arParams[pos].Value = PropertyValue;
                pos++;
            }

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Idioma_Registrar", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> RegistrarInteres(EmpleadoInteresEL Entidad)
        {
            Type t = Entidad.GetType();
            System.Reflection.PropertyInfo[] properties = t.GetProperties();
            int total_propiedades = properties.Count();

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[0];

            int pos = 0;
            foreach (System.Reflection.PropertyInfo p in properties)
            {
                if (p.Name.ToLower().Length > 9)
                    if (p.Name.ToLower().Substring(0, 9) == "opcional_")
                        continue;

                if (p.Name.ToLower() == "id_key")
                    continue;

                Array.Resize(ref arParams, arParams.Length + 1);
                object PropertyValue = p.GetValue(Entidad, null);
                SqlDbType TypeSql = SqlDbType.VarChar;

                if (p.PropertyType.Name.ToLower() == "int" || p.PropertyType.Name.ToLower() == "int32")
                    TypeSql = SqlDbType.Int;
                if (p.PropertyType.Name.ToLower() == "datetime")
                    TypeSql = SqlDbType.DateTime;
                if (p.PropertyType.Name.ToLower() == "decimal")
                    TypeSql = SqlDbType.Decimal;

                arParams[pos] = new SqlParameter("@" + p.Name, TypeSql);
                arParams[pos].Value = PropertyValue;
                pos++;
            }

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Interes_Registrar", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> RegistrarExperiencia(EmpleadoExperienciaEL Entidad)
        {
            Type t = Entidad.GetType();
            System.Reflection.PropertyInfo[] properties = t.GetProperties();
            int total_propiedades = properties.Count();

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[0];

            int pos = 0;
            foreach (System.Reflection.PropertyInfo p in properties)
            {
                if (p.Name.ToLower().Length > 9)
                    if (p.Name.ToLower().Substring(0, 9) == "opcional_")
                        continue;

                if (p.Name.ToLower() == "id_key")
                    continue;

                Array.Resize(ref arParams, arParams.Length + 1);
                object PropertyValue = p.GetValue(Entidad, null);
                SqlDbType TypeSql = SqlDbType.VarChar;

                if (p.PropertyType.Name.ToLower() == "int" || p.PropertyType.Name.ToLower() == "int32")
                    TypeSql = SqlDbType.Int;
                if (p.PropertyType.Name.ToLower() == "datetime")
                    TypeSql = SqlDbType.DateTime;
                if (p.PropertyType.Name.ToLower() == "decimal")
                    TypeSql = SqlDbType.Decimal;

                arParams[pos] = new SqlParameter("@" + p.Name, TypeSql);
                arParams[pos].Value = PropertyValue;
                pos++;
            }

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Experiencia_Registrar", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> Eliminar(int id_key)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_key", SqlDbType.Int);
            arParams[0].Value = id_key;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Eliminar", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> EliminarDetalle(int cod_id)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@cod_id", SqlDbType.Int);
            arParams[0].Value = cod_id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_EliminarDetalle", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> EliminarArchivo(int id_key)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_key", SqlDbType.Int);
            arParams[0].Value = id_key;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Documento_Eliminar", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        /*****************************************/

        public List<VacacionesSolicitudEL> ListarVacacionesRRHH(int id)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_ListarSolicitud_v2", arParams);

            List<VacacionesSolicitudEL> lstItem = new List<VacacionesSolicitudEL>();
            lstItem = Util.ConvertDataTable<VacacionesSolicitudEL>(dt);

            return lstItem;
        }

        public List<VacacionesReporteEL> ListarReporte(int id)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@cod_id", SqlDbType.Int);
            arParams[0].Value = id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_ListarReporte", arParams);

            List<VacacionesReporteEL> lstItem = new List<VacacionesReporteEL>();
            lstItem = Util.ConvertDataTable<VacacionesReporteEL>(dt);

            return lstItem;
        }

        /*****************************************/

        public List<EmpleadoDocumento2EL> ListarDocumentos(string id_subCatalogo,int idPersonal )
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@id_subCatalogo", SqlDbType.VarChar,2);
            arParams[0].Value = id_subCatalogo;

            arParams[1] = new SqlParameter("@idPersonal", SqlDbType.Int);
            arParams[1].Value = idPersonal;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Documentacion_Listar", arParams);

            List<EmpleadoDocumento2EL> lstData = new List<EmpleadoDocumento2EL>();
            lstData = Util.ConvertDataTable<EmpleadoDocumento2EL>(dt);

            return lstData;
        }
        public List<EmpleadoDocumento2EL> ListarDocumentoHistorico(string coddoc, int idPersonal)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@coddoc", SqlDbType.VarChar, 10);
            arParams[0].Value = coddoc;

            arParams[1] = new SqlParameter("@idPersonal", SqlDbType.Int);
            arParams[1].Value = idPersonal;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Documento_Listar_Historico", arParams);

            List<EmpleadoDocumento2EL> lstData = new List<EmpleadoDocumento2EL>();
            lstData = Util.ConvertDataTable<EmpleadoDocumento2EL>(dt);

            return lstData;
        }

        public List<EmpleadoDocumentoRegistrar> InsertarDocumentos(EmpleadoDocumentoRegistrar oDocumento)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@IDPersonal", SqlDbType.Int);
            arParams[0].Value = oDocumento.IDPersonal;

            arParams[1] = new SqlParameter("@tipodocumento", SqlDbType.VarChar,10);
            arParams[1].Value = oDocumento.tipodocumento;

            arParams[2] = new SqlParameter("@documentacion", SqlDbType.VarChar,400);
            arParams[2].Value = oDocumento.documentacion;

            arParams[3] = new SqlParameter("@tienevigencia", SqlDbType.Bit);
            arParams[3].Value = oDocumento.TieneVigencia;

            arParams[4] = new SqlParameter("@fchInicioVigencia", SqlDbType.Date);
            arParams[4].Value = oDocumento.FchInicioVigencia;
        
            arParams[5] = new SqlParameter("@fchFinVigencia", SqlDbType.Date);
            arParams[5].Value = oDocumento.FchFinVigencia;

            arParams[6] = new SqlParameter("@observacion", SqlDbType.VarChar,100);
            arParams[6].Value = oDocumento.Observacion;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Documentacion_Insertar", arParams);

            List<EmpleadoDocumentoRegistrar> lstData = new List<EmpleadoDocumentoRegistrar>();
            lstData = Util.ConvertDataTable<EmpleadoDocumentoRegistrar>(dt);

            return lstData;
        }


        public List<EmpleadoDocumentoRegistrar> ActualizarDocumento(EmpleadoDocumentoRegistrar oDocumento)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@IDPersonal", SqlDbType.Int);
            arParams[0].Value = oDocumento.IDPersonal;

            arParams[1] = new SqlParameter("@tipodocumento", SqlDbType.VarChar, 10);
            arParams[1].Value = oDocumento.tipodocumento;

            arParams[2] = new SqlParameter("@documentacion", SqlDbType.VarChar, 400);
            arParams[2].Value = oDocumento.documentacion;

            arParams[3] = new SqlParameter("@tienevigencia", SqlDbType.Bit);
            arParams[3].Value = oDocumento.TieneVigencia;

            arParams[4] = new SqlParameter("@fchInicioVigencia", SqlDbType.Date);
            arParams[4].Value = oDocumento.FchInicioVigencia;

            arParams[5] = new SqlParameter("@fchFinVigencia", SqlDbType.Date);
            arParams[5].Value = oDocumento.FchFinVigencia;

            arParams[6] = new SqlParameter("@observacion", SqlDbType.VarChar, 100);
            arParams[6].Value = oDocumento.Observacion;

            arParams[7] = new SqlParameter("@IDDocumento", SqlDbType.Int);
            arParams[7].Value = oDocumento.IDDocumento;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Documentacion_Actualizar", arParams);

            List<EmpleadoDocumentoRegistrar> lstData = new List<EmpleadoDocumentoRegistrar>();
            lstData = Util.ConvertDataTable<EmpleadoDocumentoRegistrar>(dt);

            return lstData;
        }

        public List<EmpleadoDocumento2EL> EliminarDocumento(int id)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.VarChar, 10);
            arParams[0].Value = id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Documentacion_Eliminar", arParams);

            List<EmpleadoDocumento2EL> lstData = new List<EmpleadoDocumento2EL>();
            lstData = Util.ConvertDataTable<EmpleadoDocumento2EL>(dt);

            return lstData;
        }

        public DataTable DocumentacionReporte(DateTime fchInicio,DateTime fchFin)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@FechaInicio", SqlDbType.Date);
            arParams[0].Value = fchInicio;

            arParams[1] = new SqlParameter("@FechaFin", SqlDbType.Date);
            arParams[1].Value = fchFin;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Documentacion_Reporte", arParams);

            //List<ItemEL> lstItem = new List<ItemEL>();
            //lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return dt;
        }

        public DataTable ExportarLicencias()
        {
            DataTable dt;
            
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Exportar_Licencias");

            //List<ItemEL> lstItem = new List<ItemEL>();
            //lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return dt;
        }

    }
}
