window.onload = function () {
    alert('tipo Medicamento')
    listarTipoMedicamento();
}

let objTipoMedicamento = {
    url: "TipoMedicamento/listarTipoMedicamento",
    cabeceras: ["ID Tipo Medicamento", "Nombre", "Descripción"],
    propiedades: ["id", "nombre", "descripcion"]
};

async function listarTipoMedicamento() {
    await pintar(objTipoMedicamento);
}

async function buscarTipoMedicamento() {   
    let descTM = document.getElementById("txtDescripcionBusqueda").value
    objTipoMedicamento.url = "TipoMedicamento/filtrarTipoMedicamento/?descripcion=" + descTM
    await pintar(objTipoMedicamento)
}

function limpiarControl() {
    listarTipoMedicamento();
    document.getElementById("txtDescripcionBusqueda").value = "";
}
