
window.onload = function () {
    listarSucursal();
}

let objSucursal = {
    url: "Sucursal/listarSucursal",
    cabeceras: ["ID Sucursal", "Nombre", "Dirección"],
    propiedades: ["iidsucursal", "nombre", "direccion"],
    //contenedorTabla: "contenedorTabla"
};

async function listarSucursal() {
    pintar(objSucursal);
}

//async function filtrarSucursal() {
//    let nombre = get("txtNombreBusqueda")
//    if (nombre == "")
//        listarSucursal();
//    else {

//        objSucursal.url = "Sucursal/filtrarSucursal/?nombre=" + nombre;
//        pintar(objSucursal);
//    }
//}

//async function buscarSucursal() {
//    let nombreSucursal = get("txtNombreBusqueda");
//    objSucursal.url = "Sucursal/filtrarSucursal/?nombre=" + nombreSucursal;
//    await pintar(objSucursal);
//}

async function buscarSucursal() {
    let forma = document.getElementById("frmBusqueda");
    let frm = new FormData(forma);

    fetch_post("Sucursal/filtrarSucursal", "json", frm, function (res) {
        console.log('Datos recibidos del filtro:', res);
        objSucursal.datos = res; 
        pintar(objSucursal); 
    });
}

function guardarSucursal() {
    let frmGuardar = document.getElementById("frmGuardarSucursal")
    let frm = new FormData(frmGuardar)

    fetch_post("Sucursal/GuardarSucursal", "text", frm, function (data) {
        if (data == "1") {
            listarSucursal();
            limpiarDatos("frmGuardarSucursal");
        }
    });


}
function limpiarSucursal() {
    limpiarDatos("frmGuardarSucursal");
    listarSucursal();    
}

