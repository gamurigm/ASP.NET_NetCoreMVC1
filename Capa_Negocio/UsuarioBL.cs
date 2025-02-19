using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class UsuarioBL
    {
        public List<UsuarioCLS> listaUsuarios()
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.listarUsuario();

        }

        public List<UsuarioCLS> filtrarUsuario(string nombre)
        {
            UsuarioDAL obj = new UsuarioDAL();
            return obj.filtrarUsuario(nombre);

        }
    }
}
