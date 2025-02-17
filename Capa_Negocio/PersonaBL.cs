using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class PersonaBL
    {
        public List<PersonaCLS> listaPersonas()
        {
            PersonaDAL obj = new PersonaDAL();
            return obj.listarPersona();
        }

        public List<PersonaCLS> filtrarPersona(string nombre)
        {
            PersonaDAL obj = new PersonaDAL();
            return obj.filtrarPersona(nombre);
        }
        
    }
}
