
window.onload = function () {
    listarSucursal();
}

let objSucursal = {
    url: "Sucursal/listarSucursal",
    cabeceras: ["ID Sucursal", "Nombre", "Dirección"],
    propiedades: ["iidsucursal", "nombre", "direccion"]
};

async function listarSucursal() {
    await pintar(objSucursal);
}

async function buscarSucursal() {
    let nombreSucursal = get("txtNombreBusqueda");
    objSucursal.url = "Sucursal/filtrarSucursal/?nombre=" + nombreSucursal;
    await pintar(objSucursal);
}

function limpiarControl() {
    listarSucursal();
    document.getElementById("txtNombreBusqueda").value = "";
}

