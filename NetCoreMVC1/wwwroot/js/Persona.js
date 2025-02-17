window.onload = function () {
    listarPersonas();
}

let objPersona = {
    url: "Persona/listarPersona",
    cabeceras: [
        "ID Persona", "Nombre", "Apellido Paterno", "Apellido Materno",
        "Email", "Dirección", "ID Sexo", "Habilitado",
        "Teléfono", "Empleado", "ID Sucursal"
    ],
    propiedades: [
        "iidPersona", "nombre", "apPaterno", "apMaterno",
        "email", "direccion", "iidsexo", "bhabilitado",
        "telefono", "bempleado", "iidSucursal"
    ]
};

async function listarPersonas() {
    await pintar(objPersona);
}

async function buscar() {
    let nombrePersona = get("txtNombreBusqueda");
    objPersona.url = "Persona/filtrarPersona/?nombre=" + nombrePersona;
    await pintar(objPersona);
}

function limpiarControl() {
    listarPersonas();
    document.getElementById("txtNombreBusqueda").value = "";
}
