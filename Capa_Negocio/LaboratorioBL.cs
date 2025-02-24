using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class LaboratorioBL
    {
        public List<LaboratorioCLS> listaLaboratorios()
        {
            LaboratorioDAL obj = new LaboratorioDAL();
            return obj.listarLaboratorio();

        }

        public List<LaboratorioCLS> filtrarLaboratorio(LaboratorioCLS objLab)
        {
            LaboratorioDAL obj = new LaboratorioDAL();
            return obj.filtrarLaboratorio(objLab);

        }
    }
}
