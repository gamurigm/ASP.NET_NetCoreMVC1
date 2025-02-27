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

            if(string.IsNullOrEmpty(oTipoMedicamentoCLS.nombre))
            {
                
                return 0; // indicar error
            }
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.GuardarTipoMedicamento(oTipoMedicamentoCLS);

        }

        public TipoMedicamentoCLS recuperarTipoMedicamento(int id)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.recuperarTipoMedicamento(id);
        }

        public int Eliminar(int id)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.Eliminar(id);
        }


    }
}
