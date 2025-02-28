
window.onload = function () {
    listarSucursal();
}

let objSucursal = {
    url: "Sucursal/listarSucursal",
    cabeceras: ["ID Sucursal", "Nombre", "Dirección"],
    propiedades: ["id", "nombre", "direccion"],
    //contenedorTabla: "contenedorTabla"
    editar: true,
    eliminar: true,
    propiedadId: "id"
};

async function listarSucursal() {
    pintar(objSucursal);
}


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

async function Editar(id) {
    fetch_get('Sucursal/recuperarSucursal?id=' + id, 'json', res => {
        set('modal-id-input', res.id);
        set('modal-nombre-input', res.nombre);
        set('modal-direccion-input', res.descripcion);

    });
    document.getElementById('modal-label').textContent = 'Editar Sucursal';
    document.getElementById('modal-id-group').style.display = 'block';
    $('#save-modal').modal('show');
}

function Eliminar(id) {
    fetch_get('Sucursal/recuperarSucursal?id=' + id, 'json', res => {
        let Nombre = res.nombre;

        confirmacion(undefined, "¿Desea eliminar: " + Nombre + "?", function () {
            fetch_get("Sucursal/Eliminar/?id=" + id, "text", function (data) {
                if (data == "1") {
                    Exito();
                    listarTipoMedicamento();
                }
            });
        });
    });
}
