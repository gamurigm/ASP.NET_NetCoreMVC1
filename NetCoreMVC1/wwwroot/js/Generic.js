function get(val) {
    return document.getElementById(val).value;
}
function set(id, val) {
    return document.getElementById(id).value = val;
}

function limpiarDatos(idFormulario) {
    let elementosName = document.querySelectorAll('#' + idFormulario + ' [name]');
    for (let i = 0; i < elementosName.length; i++) {
        let elementoActual = elementosName[i];
        let elementoName = elementoActual.name;
        setName(elementoName, "");
    }
}


function recuperarGenerico(url, idFormulario) {
    let elementosName = document.querySelectorAll('#' + idFormulario + ' [name]');
    let nombreName;

    fetch_get(url, "json", function (data) {

        console.log("Datos recibidos en Editar:", data);

            if (!data) {
                alert("Error al recuperar los datos");
                return;
            }

        for (let i = 0; i < elementosName.length; i++) {
            nombreName = elementosName[i].name;
            setName(nombreName, data[nombreName]);
        }
    });
}


function getName(nameControl) {
    return document.getElementsByName(nameControl)[0].value;
}
function setName(nameControl, val){
    return document.getElementsByName(nameControl)[0].value = val;
}

async function fetch_get(url, tipoRespuesta, cb) {

    try {
        let raiz = document.getElementById('oculto')?.value;
        let urlAbsoluta = `${window.location.protocol}//${window.location.host}/${raiz}${url}`;

        let res = await fetch(urlAbsoluta);
        if (!res.ok) throw new Error(Error`en la petición: ${res.statusText}`);
        let data;
        if (tipoRespuesta === "json") {
            data = await res.json();
        } else if (tipoRespuesta === "text") {
            data = await res.text();
        } else {
            throw new Error("Formato de respuesta no soportado.");
        }
        cb(data);
    } catch (e) {
        alert("Ocurrió un problema: " + e.message);
    }
}

async function fetch_post(url, tipoRespuesta, frm, cb) {

    try {
        let raiz = document.getElementById('oculto')?.value;
        let urlAbsoluta = `${window.location.protocol}//${window.location.host}/${raiz}${url}`;

        let res = await fetch(urlAbsoluta, {
            method: "POST",
            body: frm
        });

        if (tipoRespuesta === "json") {
            res = await res.json();
        } else if (tipoRespuesta === "text") {
            res = await res.text();
        } else {
            throw new Error("Formato de respuesta no soportado.");
        }
        cb(res);


    } catch (e) {
        alert("Ocurrió un problema en POST: " + e.message);
    }
}

let objConfigurationGlobal;
function pintar(objConfiguration) {
    objConfigurationGlobal = objConfiguration;

    if (objConfigurationGlobal.contenedorTabla == undefined)
        objConfigurationGlobal.contenedorTabla = "contenedorTabla";

    if (objConfigurationGlobal.propiedadId == undefined)
        objConfigurationGlobal.propiedadId = "id";  

    if (objConfiguration.datos) {
        // Si ya tenemos datos, los usamos directamente
        let contenido = "";
        contenido += "<div id='contenedorTabla'>";
        contenido += generarTabla(objConfiguration.datos);
        contenido += "</div>";
        document.getElementById("div-table").innerHTML = contenido;
    } else {

        fetch_get(objConfiguration.url, "json", function (res) {
            if (!Array.isArray(res) || res.length === 0) {
                document.getElementById("div-table").innerHTML = "<p>No hay datos disponibles.</p>";
                return;
            }
            let contenido = "<div id='" + objConfigurationGlobal.contenedorTabla + "'>";
            contenido += generarTabla(res);
            contenido += "</div>";
            document.getElementById("div-table").innerHTML = contenido;
        });
    }
}
function generarTabla(res) {
    let cabeceras = objConfigurationGlobal?.cabeceras || [];
    let propiedades = objConfigurationGlobal?.propiedades || [];
    let contenido = "<table class='table table-striped table-borderer'>";
    contenido += "<thead><tr>";
    for (let i = 0; i < cabeceras.length; i++) {
        contenido += `<th>${cabeceras[i]}</th>`;
    }


    if (objConfigurationGlobal.editar == true || objConfigurationGlobal.eliminar == true) {
        contenido += "<td>Operaciones</td>";
    }

    contenido += "</tr></thead>";
    contenido += "<tbody>";
    for (let i = 0; i < res.length; i++) {
        let obj = res[i];
        contenido += "<tr>";
        for (let j = 0; j < propiedades.length; j++) {
            let propActual = propiedades[j];
            contenido += `<td>${obj?.[propActual] ?? 'No disponible'}</td>`;
        }

        if (objConfigurationGlobal.editar == true || objConfigurationGlobal.eliminar == true) {
            let propiedadId = objConfigurationGlobal.propiedadId;
            contenido += "<td>";
            if (objConfigurationGlobal.editar == true) {
                contenido += `<i onclick="Editar(${obj[propiedadId]})" class="btn btn-info"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                  <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                  <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z"/>
                </svg > </i>`
            }
            contenido += " ";
            if (objConfigurationGlobal.eliminar == true) {
                contenido += `<i onclick="Eliminar(${obj[propiedadId]})" class="btn btn-danger"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                  <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0z"/>
                  <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4zM2.5 3h11V2h-11z"/>
                </svg></i>`
            }
            contenido += "<td>";
           
        }
        contenido += "</tr>";
        
    }
    contenido += "</tbody></table>";
    console.log("Datos recibidos para la tabla:", res);
    return contenido;
   
}

function confirmacion(titulo="Confirmacion", texto="Desasea guardar los cambios?", callback) {
    Swal.fire({
        title: titulo,
        text: texto,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "SI",
        cancelButtonText: "NO"
    }).then((result) => {
        if (result.isConfirmed) {
            callback()
        }
    });
}

function Exito() {
    Swal.fire(
       
        'Accion Exitosa'
    )
}

//function Exito() {
//    toastr.options = {
//        //"closeButton": false,
//        //"debug": false,
//        //"newestOnTop": false,
//        //"progressBar": false,
//        //"positionClass": "toast-top-right",
//        //"preventDuplicates": false,
//        //"onclick": null,
//        //"showDuration": "300",
//        //"hideDuration": "1000",
//        //"timeOut": "5000",
//        "extendedTimeOut": "1000",
//        "showEasing": "swing",
//        "hideEasing": "linear",
//        "showMethod": "fadeIn",
//        "hideMethod": "fadeOut"
//    }
//        toastr.success('Los datos se guardaron correctamente');
//}

function Error() {
    console.log("Se ha llamado a la función Error.");
    //Swal.fire({
    //    icon: "error",
    //    title: "Oops...",
    //    text: "Algo Ocurrio!",
    //    footer: '<a href="#">porqué tengo este error?</a>'
    // });
}        