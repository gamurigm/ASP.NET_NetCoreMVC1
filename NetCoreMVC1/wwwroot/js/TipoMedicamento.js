window.onload = function () {
    listarTipoMedicamento();
}

async function listarTipoMedicamento()
{
    pintar({
        url: "TipoMedicamento/listarTipoMedicamento",
        cabeceras: ["Id_TipoMedicamento", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"]

    })

}
