
window.onload = function () {
    listarLaboratorio();
}

let objLaboratorio = {
    url: "Laboratorio/listarLaboratorio",
    cabeceras: ["ID Laboratorio", "Nombre", "Dirección", "Persona Contacto"],
    propiedades: ["iidlaboratorio", "nombre", "direccion", "personacontacto"],
    contenedorTabla: "contenedorTabla"
};


async function listarLaboratorio() {
    pintar(objLaboratorio);
}

function buscarLaboratorio() {
    let forma = document.getElementById("frmBusqueda");
    let frm = new FormData(forma);
    fetch_post("Laboratorio/filtrarLaboratorio", "json", frm, function (res) {
        console.log('Datos recibidos del filtro:', res);
        objLaboratorio.datos = res;
        pintar(objLaboratorio); 
    });
}

function limpiarLaboratorio() {
    limpiarDatos("frmBusqueda")
    listarLaboratorio();
}

