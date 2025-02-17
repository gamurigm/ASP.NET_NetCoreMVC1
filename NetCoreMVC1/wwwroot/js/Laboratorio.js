
window.onload = function () {
    listarLaboratorio();
}

let objLaboratorio = {
    url: "Laboratorio/listarLaboratorio",
    cabeceras: ["ID Laboratorio", "Nombre", "Dirección", "Habilitado", "Persona Contacto", "Número Contacto"],
    propiedades: ["iidlaboratorio", "nombre", "direccion", "bhabilitado", "personacontacto", "numerocontacto"]
};

async function listarLaboratorio() {
    await pintar(objLaboratorio);
}

async function filtrarLaboratorio() {
    let nombre = get("txtNombreBusqueda")
    if (nombre == "")
        listarLaboratorio();
    else {

        objSucursal.url = "Laboratorio/filtrarLaboratorio/?nombre=" + nombre;
        await pintar(objSucursal);
    }
}

async function buscarLaboratoriol() {
    let nombreSucursal = get("txtNombreBusqueda");
    objSucursal.url = "Laboratorio/filtrarLaboratorio/?nombre=" + nombreSucursal;
    await pintar(objSucursal);
}

function limpiarControl() {
    listarLaboratorio();
    set("txtNombreBusqueda", '');
}

