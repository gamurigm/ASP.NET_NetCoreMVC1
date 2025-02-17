using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class TipoMedicamentoBL
    {
        public List<TipoMedicamentoCLS> listaMedicamentos()
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.listarTipoMedicamento();

        }
        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(string nombre)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.filtrarTipoMedicamento(nombre);

        }
    }
}
