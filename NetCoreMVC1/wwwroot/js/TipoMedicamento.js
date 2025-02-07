window.onload = function () {
    listarTipoMedicamento();
}

async function listarTipoMedicamento()
{
    fetch_get("TipoMedicamento/listarTipoMedicamento", "json", function (res)
    {
        let nRegistros = res.length
        let contenido
        contenido += "<table class='table'>"
        contenido += "<thead>"
        contenido += "</thead>"

        let obj
        contenido += "<tbody>"

        for (let i = 0; i < nRegistros; i++) {
            obj = res[i]
            contenido += "<tr>"                            /* -- 1ra Fila (Headers) -- */
            contenido += `<td>${obj.id}</td>`
            contenido += `<td>${obj.nombre}</td>` 
            contenido += `<td>${obj.descripcion}</td>`
            contenido += `</tr>` 
        }
        contenido += "</tbody>"
        contenido += "</table>"
        
        document.getElementById("div-table").innerHTML = contenido

    })



    

}
