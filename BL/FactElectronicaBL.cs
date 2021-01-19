using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactElectronicaBL
    {

        public List<FactElectronicaEL> Consultar(string Tipo, DateTime FchInicio, DateTime FchFin, string Pref, string Num, int DocEntry, string Estado, string EstadoLegal)
        {
            FactElectronicaDAL oUsuario = new FactElectronicaDAL();
            return oUsuario.Consultar(Tipo, FchInicio, FchFin, Pref, Num, DocEntry, Estado, EstadoLegal);
        }

        public List<UsuarioEL> TEST_Editar(int id_usuario)
        {
            UsuarioDAL oUsuario = new UsuarioDAL();
            return oUsuario.TEST_Editar(id_usuario);
        }

        public List<UsuarioEL> TEST_Eliminar(int id_usuario)
        {
            UsuarioDAL oUsuario = new UsuarioDAL();
            return oUsuario.TEST_Eliminar(id_usuario);
        }
        public List<UsuarioEL> TEST_Listar_Filtro(string nom_usuario, string nom_user, string perfil, int id_empleado)
        {
            UsuarioDAL oUsuario = new UsuarioDAL();
            return oUsuario.TEST_Listar_Filtro(nom_usuario, nom_user, perfil, id_empleado);
        }

        public List<UsuarioEL> TEST_Filtrar_Usuario(string nom_user)
        {
            UsuarioDAL oUsuario = new UsuarioDAL();
            return oUsuario.TEST_Filtrar_Usuario(nom_user);
        }

        public List<UsuarioEL> TEST_Listar_Todo_Usuarios()
        {
            UsuarioDAL oUsuario = new UsuarioDAL();
            return oUsuario.TEST_Listar_Todo_Usuarios();
        }

        public List<UsuarioEL> ValidarUsuario(string user, string pass)
        {
            UsuarioDAL oUsuario = new UsuarioDAL();
            return oUsuario.ValidarUsuario(user, pass);
        }


        public List<UsuarioEL> ActualizarContraseña(string user, string pass,string newpass)
        {
            UsuarioDAL oUsuario = new UsuarioDAL();
            return oUsuario.ActualizarContraseña(user, pass,newpass);
        }

        public List<UsuarioEL> ActualizarJefatura(int jefatura, int cod_id)
        {
            UsuarioDAL oUsuario = new UsuarioDAL();
            return oUsuario.ActualizarJefatura(jefatura,cod_id);
        }

    }
}
