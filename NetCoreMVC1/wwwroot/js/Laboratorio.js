
window.onload = function () {
    listarLaboratorio()
}

let urlED = "Laboratorio/recuperarLaboratorio?id=" 

let objLaboratorio = {
    url: "Laboratorio/listarLaboratorio",
    cabeceras: ["ID Laboratorio", "Nombre", "Dirección", "Persona Contacto"],
    propiedades: ["id", "nombre", "direccion", "personacontacto"],
    edit: true,
    delete: true,
    id: "id"
};


async function listarLaboratorio() {
    pintar(objLaboratorio)
}

function buscarLaboratorio() {
    let forma = document.getElementById("frmBusqueda")
    let frm = new FormData(forma)
    fetch_post("Laboratorio/filtrarLaboratorio", "json", frm, function (res) {
        console.log('Datos recibidos del filtro:', res)
        objLaboratorio.datos = res
        pintar(objLaboratorio)
    });
}

function limpiarLaboratorio() {
    limpiarDatos("frmBusqueda")
    listarLaboratorio()
}


async function Editar(id) {
    fetch_get(urlED + id, 'json', res => {
        set('modal-id-input', res.id)
        set('modal-nombre-input', res.nombre)
        set('modal-direccion-input', res.direccion)
       // set('modal-personacontacto-input', res.personacontacto

    });
    document.getElementById('modal-label').textContent = 'Editar Laboratorio'
    document.getElementById('modal-id-group').style.display = 'block'
    $('#save-modal').modal('show')
}

function Eliminar(id) {
    fetch_get(urlED + id, 'json', res => {
        let Nombre = res.nombre

        confirmacion(undefined, "¿Desea eliminar: " + Nombre + "?", function () {
            fetch_get("Laboratorio/Eliminar/?id=" + id, "text", function (res) {
                if (res == "1") {
                    Exito()
                    listarLaboratorio()
                }
            });
        });
    });
}
