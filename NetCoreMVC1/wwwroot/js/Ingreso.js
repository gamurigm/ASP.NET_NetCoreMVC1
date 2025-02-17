window.onload = function () {
    listarIngreso();
}

let objIngreso = {
    url: "Ingreso/listarIngreso",
    cabeceras: ["ID Ingreso", "ID Medicamento", "ID Laboratorio", "Fecha Compra", "Cantidad", "Fecha Vencimiento", "Precio Compra", "Habilitado", "Fecha Vencimiento", "ID Marca", "Precio Venta"],
    propiedades: ["IIDINGRESO", "IIDMEDICAMENTO", "IIDLABORATORIO", "FECHACOMPRA", "CANTIDAD", "FECHAVENCIMIENTO", "PRECIOCOMPRA", "BHABILITADO", "DFECHAVENCIMIENTO", "IIDMARCA", "PRECIOVENTA"]
};

async function listarIngreso() {
    await pintar(objIngresoMedicamento);
}

async function buscarIngreso() {
    let campo = get("txtIdIngresoBusqueda");
    objIngresoMedicamento.url = "IngresofiltrarIngreso/?nombre=" + campo;
    await pintar(objIngresoMedicamento);
}

function limpiarControl() {
    listarIngreso();
    set('');
}