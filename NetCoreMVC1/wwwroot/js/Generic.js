function get(val) {
    return document.getElementById(val).value;
}
function set(id, val) {
    return document.getElementById(id).value = val;
}

async function fetch_get(url, tipoRespuesta, cb) {

    try {
        let raiz = document.getElementById('oculto')?.value || '';  // Evita errores si el elemento no existe
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


let objConfigurationGlobal;
function pintar(objConfiguration) {
    objConfigurationGlobal = objConfiguration;
    fetch_get(objConfiguration.url, "json", function (res) {
        if (!Array.isArray(res) || res.length === 0) {
            document.getElementById("div-table").innerHTML = "<p>No hay datos disponibles.</p>";
            return;
        }
        let contenido = "<div id='contenedor-tabla'>";
        contenido += generarTabla(res);
        contenido += "</div>";
        document.getElementById("div-table").innerHTML = contenido;
    });
}
function generarTabla(res) {
    let cabeceras = objConfigurationGlobal?.cabeceras || [];
    let propiedades = objConfigurationGlobal?.propiedades || [];
    let contenido = "<table class='table table-striped table-borderer'>";
    contenido += "<thead><tr>";
    for (let i = 0; i < cabeceras.length; i++) {
        contenido += `<th>${cabeceras[i]}</th>`;
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
        contenido += "</tr>";
    }
    contenido += "</tbody></table>";
    return contenido;
}