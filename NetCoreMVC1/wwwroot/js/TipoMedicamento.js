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


async function guardarTipoMedicamento() {
    let form = new FormData(document.getElementById('modal-form'));

    confirmacion(undefined, undefined, function (rpta) {
        fetch_post('TipoMedicamento/guardarTipoMedicamento', 'text', form, res => {
            if (res == "1") {
                Exito();
                listarTipoMedicamento();
                limpiarDatos("modal-form");
            }
            if(parseInt(res)) $('#save-modal').modal('hide');
           
        });
    });   
}

function limpiarControl() {
    listarTipoMedicamento();
    document.getElementById("txtNombreBusqueda").value = "";
}

function limpiarTipoMedicamento() {
    limpiarDatos("frmGuardarTipoMedicamento");
}

async function Editar(id) {
    fetch_get('TipoMedicamento/recuperarTipoMedicamento?id=' + id, 'json', res => {
        set('modal-id-input', res.id);
        set('modal-nombre-input', res.nombre);
        set('modal-descripcion-input', res.descripcion);
       
    });
    document.getElementById('modal-label').textContent = 'Editar Tipo Medicamento';
    document.getElementById('modal-id-group').style.display = 'block';
    $('#save-modal').modal('show');
}

function Eliminar(id) {
    fetch_get('TipoMedicamento/recuperarTipoMedicamento?id=' + id, 'json', res => {
        let medNombre = res.nombre;

        confirmacion(undefined, "¿Desea eliminar: " + medNombre + "?", function () {
            fetch_get("TipoMedicamento/Eliminar/?id=" + id, "text", function (data) {
                if (data == "1") {
                    Exito();
                    listarTipoMedicamento();  
                }
            });
        }); 
    });
}


