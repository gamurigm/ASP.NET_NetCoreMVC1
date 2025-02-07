async function fetch_get(url, tipoRespuesta, cb)
{
    try {
        
        let raiz = document.getElementById('oculto').value
        let urlAbsoluta = window.location.protocol + "//" + window.location.host + "/" + raiz + url
        let res = await fetch(urlAbsoluta)

        if (tipoRespuesta == "json")
            res = await res.json()

        else if (tipoRespuesta == "text")
            res = await res.text()


        cb(res)

    } catch (e) {
        alert("ocurrio un problema")
    }
}