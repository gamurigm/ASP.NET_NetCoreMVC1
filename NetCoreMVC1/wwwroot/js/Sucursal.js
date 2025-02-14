window.onload = function () {
    listarSucursal();
}

async function listarSucursal() {
    pintar({
        url: "Sucursal/listarSucursal",
        cabeceras: ["Id", "Nombre", "Direccion"],
        propiedades: ["idSucursal", "nombre", "direccion"]

    })

}
