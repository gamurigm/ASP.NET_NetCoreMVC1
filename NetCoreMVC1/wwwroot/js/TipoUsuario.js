window.onload = function () {
    listarTipoUsuario();
}

let objTipoUsuario = {
    url: "TipoUsuario/listarTipoUsuario",
    cabeceras: ["ID Tipo usuario", "Nombre", "Descripción", "Habilitado"],
    propiedades: ["iidtipousuario", "nombre", "descripcion", "bhabilitado"]
};

async function listarTipoUsuario() {
    await pintar(objUsuario);
}

async function filtrarvUsuario() {
    let nombre = get("txtNombreBusqueda")
    if (nombre == "")
        listarUsuario();
    else {

        objUsuario.url = "TipoUsuario/filtrarTipoUsuario/?nombre=" + nombre;
        await pintar(objTipoUsuario);
    }
}

async function buscarTipoUsuario() {
    let nombreTipoUsuario = get("txtNombreBusqueda");
    objTipoUsuario.url = "TipoUsuario/filtrarTipoUsuario/?nombre=" + nombreTipoUsuario;
    await pintar(obTipojUsuario);
}

function limpiarControl() {
    listarTipoUsuario();
    set("txtNombreBusqueda", '');
}

