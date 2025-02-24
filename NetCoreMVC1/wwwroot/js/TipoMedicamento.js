window.onload = function () { 
    listarTipoMedicamento();
}

let objTipoMedicamento = {
    url: "TipoMedicamento/listarTipoMedicamento",
    cabeceras: ["ID Tipo Medicamento", "Nombre", "Descripción"],
    propiedades: ["id", "nombre", "descripcion"],
    editar: true,
    eliminar: true,
    propiedadId: "id"
};

async function listarTipoMedicamento() {
    await pintar(objTipoMedicamento);
}

function filtrarTipoMedicamento() {
    let nombre = get("txtNombreBusqueda")
    if (nombre == "")
        listarTipoMedicamento();
    else {
     
        objTipoMedicamento.url = "TipoMedicamento/filtrarTipoMedicamento/?nombre=" + nombre;
        pintar(objTipoMedicamento);
    }
}

async function buscarTipoMedicamento() {  
    let descTM = document.getElementById("txtDescripcionBusqueda").value;
    objTipoMedicamento.url = "TipoMedicamento/filtrarTipoMedicamento/?nombre=" + descTM;
    await pintar(objTipoMedicamento);
}

function guardarTipoMedicamento() {
    let frmGuardar = document.getElementById("frmGuardarTipoMedicamento")
    let frm = new FormData(frmGuardar)

    fetch_post("TipoMedicamento/GuardarTipoMedicamento", "text", frm, function (data) {
        if (data == "1") {
            listarTipoMedicamento();
            limpiarDatos("frmGuardarTipoMedicamento");
        }
    });


}

function limpiarControl() {
    listarTipoMedicamento();
    document.getElementById("txtNombreBusqueda").value = "";
}

function limpiarTipoMedicamento() {
    limpiarDatos("frmGuardarTipoMedicamento");
}

function Editar(id) {
    console.log("ID recibido:", id);
    recuperarGenerico("TipoMedicamento/recuperarTipoMedicamento/?id=" + id, "frmGuardarTipoMedicamento")
   
}