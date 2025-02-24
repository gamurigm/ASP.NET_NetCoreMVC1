window.onload = function () {
    listarUsuario();
}

let objUsuario= {
    url: "Usuario/listarUsuario",
    cabeceras: ["ID Usuario", "Nombre Usuario", "ID Tipo Usuario", "Contraseña", "Habilitado"],
    propiedades: ["iidusuario", "nombreusuario", "iidtipousuario", "contra", "bhabilitado"]
};

async function listarUsuario() {
    await pintar(objUsuario);
}

async function filtrarUsuario() {
    let nombre = get("txtNombreBusqueda")
    if (nombre == "")
        listarUsuario();
    else {

        objUsuario.url = "Usuario/filtrarUsuario/?nombre=" + nombre;
        await pintar(objUsuario);
    }
}

async function buscarUsuario() {
    let nombreUsuario = get("txtNombreBusqueda");
    objUsuario.url = "Usuario/filtrarUsuario/?nombre=" + nombreUsuario;
    await pintar(objUsuario);
}

function limpiarControl() {
    listarUsuario();
    set("txtNombreBusqueda", '');
}

