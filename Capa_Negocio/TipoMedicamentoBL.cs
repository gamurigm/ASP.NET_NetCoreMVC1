using Capa_Datos;
using Capa_Entidad;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public int GuardarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.GuardarTipoMedicamento(oTipoMedicamentoCLS);

        }

        public TipoMedicamentoCLS recuperarTipoMedicamento(int idTipoMedicamento)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.recuperarTipoMedicamento(idTipoMedicamento);
        }
    }
}
