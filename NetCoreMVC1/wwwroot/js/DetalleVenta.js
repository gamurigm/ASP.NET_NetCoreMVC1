window.onload = function () {
    listarSucursal();
}

let objSucursal = {
    url: "DetalleVenta/listarDetalleVenta",
    cabeceras: ["ID Sucursal", "Nombre", "Dirección"],
    propiedades: ["iidsucursal", "nombre", "direccion"]
};

async function listarSucursal() {
    await pintar(objSucursal);
}

async function buscarSucursal() {
    let nombreSucursal = get("txtNombreBusqueda");
    objSucursal.url = "DetalleVenta/filtrarDetalleVenta/?nombre=" + nombreSucursal;
    await pintar(objSucursal);
}

function limpiarControl() {
    listarSucursal();
    set('');
}

