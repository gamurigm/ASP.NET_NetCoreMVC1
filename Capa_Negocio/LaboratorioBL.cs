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

        //public int GuardarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        //{

        //    if (string.IsNullOrEmpty(oTipoMedicamentoCLS.nombre))
        //    {

        //        return 0; // indicar error
        //    }
        //    TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
        //    return obj.GuardarTipoMedicamento(oTipoMedicamentoCLS);

        //}

        public LaboratorioCLS recuperarLaboratorio(int id)
        {
            LaboratorioDAL obj = new LaboratorioDAL();
            return obj.recuperarLaboratorio(id);
        }

        public int Eliminar(int id)
        {
            LaboratorioDAL obj = new LaboratorioDAL();
            return obj.Eliminar(id);
        }


    }
}
