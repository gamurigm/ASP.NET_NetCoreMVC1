using Capa_Entidad;

namespace Capa_Datos
{
    public class TipoMedicamentoDAL
    {
        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            return new List<TipoMedicamentoCLS>
            {
                new TipoMedicamentoCLS { Id = 1, nombre = "Analgesicos", descripcion = "Para aliviar el dolor" },
                new TipoMedicamentoCLS { Id = 2, nombre = "Antibióticos", descripcion = "Para tratar infecciones bacterianas" },
                new TipoMedicamentoCLS { Id = 3, nombre = "Antidepresivos", descripcion = "Para tratar trastornos del estado de ánimo" },
                new TipoMedicamentoCLS { Id = 4, nombre = "Antihistamínicos", descripcion = "Para tratar alergias" }
            };
        }
    }
}
