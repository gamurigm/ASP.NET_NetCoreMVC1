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

//function guardarTipoMedicamento() {
//    let frmGuardar = document.getElementById("frmGuardarTipoMedicamento")
//    let frm = new FormData(frmGuardar)

//    confirmacion(undefined, undefined, function (rpta) {
//        fetch_post("TipoMedicamento/GuardarTipoMedicamento", "text", frm, function (data) {
//            if (data == "1") {
//                Exito();
//                listarTipoMedicamento();
//                limpiarDatos("frmGuardarTipoMedicamento");
//            } else Error();
//        });
//    });

//}


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

//function Editar(id) {

//    if (!id) {
//        console.error('ID no válido');
//        return;
//    }
//    console.log("ID a editar:", id);


//    fetch_get("TipoMedicamento/recuperarTipoMedicamento?id=" + id, "json", function (data) {
//        console.log("Datos recibidos en Editar:", data);

//        if (!data) {
//            alert("Error al recuperar los datos");
//            return;
//        }

//        set("id", data.id);
//        set("nombre", data.nombre);
//        set("descripcionTipoMedicamento", data.descripcion);
//    });
//}


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
     
    let  medNombre ='';

    
        fetch_get('TipoMedicamento/recuperarTipoMedicamento?id=' + id, 'json', res => {
            
            medNombre= res.nombre;
        });
        fetch_get("TipoMedicamento/Eliminar/?id=" + id, "text", function (data) {
            if (data == "1") {
                confirmacion(undefined, "desea eliminar: " + medNombre, function () {
                    
                    listarTipoMedicamento();
                });   
            }
        });
}
