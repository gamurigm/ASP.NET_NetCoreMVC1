window.onload = function () {
    listarMedicamento();
}


async function listarMedicamento() {
    fetch_get("Medicamentos/saludo", "text", function (res) {
        alert(res)

    })

}