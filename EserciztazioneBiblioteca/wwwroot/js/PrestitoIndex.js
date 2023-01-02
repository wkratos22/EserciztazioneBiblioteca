var prestitoTable;
$(document).ready(function () {
    prestitoTable = $('#prestitoTable').DataTable();
});

//CREATE

$("#salva").click(function () {

    const prestito = {

        Data_inizio: $("#dataInzio").val(),

        Data_fine: $("#dataFine").val(),

        Descrizione: $("#descrizione").val(),

        Prezzo: $("#prezzo").val(),

        ClienteId: $("#cliente").val()

    };
    console.log(prestito);
    fetch('/api/PrestitoAPI/Create', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(prestito),
    })
    .then(response => response.json())
    .then(() => {

    })
    .catch(error => console.error('Unable to add item.', error));

});

$("#prestitoTable tbody").on("click", "tr", function () {
    const data = prestitoTable.row(this).data();
    var myModal = document.getElementById('editModal');
    console.log(data);

    var EditModal = new bootstrap.Modal(myModal);
    EditModal.show();


    document.getElementById("Id").value = data[0];

    document.getElementById("Data_inizio").value = date(data[1]);

    document.getElementById("Data_fine").value = date(data[2]);

    document.getElementById("Descrizione").value = data[4];

    document.getElementById("Prezzo").value = parseInt(data[5].replace("¤", ""));

    document.getElementById("clienteEdit").value = data[3];



});

function date(dateString) {
    var dateParts = dateString.split("/");
    console.log(dateParts);
    return (dateParts[2] + "-" + dateParts[1] + "-" + dateParts[0])
}



//EDIT

$("#Edit").click(function () {

    const prestitoEdit = {
        id: $("#Id").val(),

        Data_inizio: $("#Data_inizio").val(),

        Data_fine: $("#Data_fine").val(),

        Descrizione: $("#Descrizione").val(),

        Prezzo: $("#Prezzo").val(),

        ClienteId: $("#clienteEdit").val()

    };
    console.log(prestitoEdit);
    fetch('/api/PrestitoAPI/Edit', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(prestitoEdit),
    })
    .then(response => response.json())
    .then(() => {

    })
    .catch(error => console.error('Unable to add item.', error));
});


