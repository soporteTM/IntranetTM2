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
    public class EmpleadoBL
    {
        EmpleadoDAL oItem = new EmpleadoDAL();
        public List<ItemEL> Listar(string cod_departamento)
        {
            return oItem.ListarItem(cod_departamento);
        }

        public List<NombradaEL> ListarAdministrativo()
        {
            EmpleadoDAL oNombrada = new EmpleadoDAL();
            return oNombrada.ListarAdministrativo();
        }
        

        public DataTable Consultar_PorCodigo(int id_key)
        {
            return oItem.Consultar_PorCodigo(id_key);
        }

        public List<EmpleadoEL> Consultar_PorCodigo2(int id_key)
        {
            return oItem.Consultar_PorCodigoV2(id_key);
        }

        public DataTable Consultar(string filtro,string estado)
        {
            return oItem.Consultar(filtro, estado);
        }

        public DataTable Consultar(string filtro)
        {
            return oItem.Consultar(filtro);
        }

        public DataTable Exportar()
        {
            return oItem.Exportar();
        }

        public List<EmpleadoDocumentoEL> Consultar_EmpleadoDocumento(int id_empleado, string carpeta, string ficha)
        {
            return oItem.Consultar_EmpleadoDocumento(id_empleado, carpeta, ficha);
        }

        public List<EmpleadoDocumentoEL> Consultar_EmpleadoDocumento_PorCodigo(int id_documento)
        {
            return oItem.Consultar_EmpleadoDocumento_PorCodigo(id_documento);
        }

        public List<EmpleadoFormacionEL> Consultar_EmpleadoFormacion_PorCodigo(int cod_id)
        {
            return oItem.Consultar_EmpleadoFormacion_PorCodigo(cod_id);
        }

        public List<EmpleadoIdiomaEL> Consultar_EmpleadoIdioma_PorCodigo(int cod_id)
        {
            return oItem.Consultar_EmpleadoIdioma_PorCodigo(cod_id);
        }

        public List<EmpleadoInteresEL> Consultar_EmpleadoInteres_PorCodigo(int cod_id)
        {
            return oItem.Consultar_EmpleadoInteres_PorCodigo(cod_id);
        }

        public List<EmpleadoExperienciaEL> Consultar_ExperienciaInteres_PorCodigo(int cod_id)
        {
            return oItem.Consultar_ExperienciaInteres_PorCodigo(cod_id);
        }

        public List<TransaccionEL> Registrar(EmpleadoEL Entidad)
        {
            return oItem.Registrar(Entidad);
        }

        public List<TransaccionEL> Actualizar(EmpleadoEL Entidad)
        {
            return oItem.Actualizar(Entidad);
        }

        public List<TransaccionEL> ActualizarDocumento(EmpleadoDocumentoEL Entidad)
        {
            return oItem.ActualizarDocumento(Entidad);
        }
        public List<TransaccionEL> Actualizar_CarpetaCompartida(int id_empleado, string carpeta)
        {
            return oItem.Actualizar_CarpetaCompartida(id_empleado, carpeta);
        }

        public List<TransaccionEL> RegistrarDocumento(EmpleadoDocumentoEL Entidad)
        {
            return oItem.RegistrarDocumento(Entidad);
        }

        //Inicio Familiares
        public List<TransaccionEL> RegistrarFamiliar(EmpleadoFamiliaEL Entidad)
        {
            return oItem.RegistrarFamiliar(Entidad);
        }

        

        public List<TransaccionEL> ActualizarFamiliar(EmpleadoFamiliaEL Entidad)
        {
            return oItem.ActualizarFamiliar(Entidad);
        }
        
        
        public List<EmpleadoFamiliaEL> Consultar_EmpleadoFamiliar_PorCodigo(int cod_id)
        {
            return oItem.Consultar_EmpleadoFamiliar_PorCodigo(cod_id);
        }
        //Fin Familiares
        public List<TransaccionEL> RegistrarFormacion(EmpleadoFormacionEL Entidad)
        {
            return oItem.RegistrarFormacion(Entidad);
        }

        public List<TransaccionEL> RegistrarIdioma(EmpleadoIdiomaEL Entidad)
        {
            return oItem.RegistrarIdioma(Entidad);
        }

        public List<TransaccionEL> RegistrarInteres(EmpleadoInteresEL Entidad)
        {
            return oItem.RegistrarInteres(Entidad);
        }

        public List<TransaccionEL> RegistrarExperiencia(EmpleadoExperienciaEL Entidad)
        {
            return oItem.RegistrarExperiencia(Entidad);
        }

        public List<TransaccionEL> Eliminar(int id_key)
        {
            return oItem.Eliminar(id_key);
        }

        public List<TransaccionEL> EliminarArchivo(int id_key)
        {
            return oItem.EliminarArchivo(id_key);
        }

        public List<TransaccionEL> EliminarDetalle(int id_key)
        {
            return oItem.EliminarDetalle(id_key);
        }
        
        public List<EmpleadoDocumento2EL> ListarDocumentos(string id_subCatalogo, int idPersonal)
        {
            return oItem.ListarDocumentos(id_subCatalogo,idPersonal);
        }

        public List<EmpleadoDocumento2EL> ListarDocumentoHistorico(string id_subCatalogo, int idPersonal)
        {
            return oItem.ListarDocumentoHistorico(id_subCatalogo, idPersonal);
        }

        public DataTable DocumentacionReporte(DateTime fchInicio,DateTime fchFin)
        {
            return oItem.DocumentacionReporte(fchInicio,fchFin);
        }

        public DataTable ExportarLicencias()
        {
            return oItem.ExportarLicencias();
        }

        public List<EmpleadoDocumentoRegistrar> InsertarDocumentos(EmpleadoDocumentoRegistrar oDocumento)
        {
            return oItem.InsertarDocumentos(oDocumento);
        }

        public List<EmpleadoDocumentoRegistrar> ActualizarDocumento(EmpleadoDocumentoRegistrar oDocumento)
        {
            return oItem.ActualizarDocumento(oDocumento);
        }

        public List<EmpleadoDocumento2EL> EliminarDocumento(int id)
        {
            return oItem.EliminarDocumento(id);
        }

        


        /*****************************************/
        public List<VacacionesSolicitudEL> ListarVacacionesRRHH(int id)
        {
            EmpleadoDAL oVacaciones = new EmpleadoDAL();
            return oVacaciones.ListarVacacionesRRHH(id);
        }
        public List<VacacionesReporteEL> ListarReporte(int id)
        {
            EmpleadoDAL oVacaciones = new EmpleadoDAL();
            return oVacaciones.ListarReporte(id); 
        }
    }
}
