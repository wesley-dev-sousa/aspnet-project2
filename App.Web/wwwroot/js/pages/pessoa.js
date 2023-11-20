$(document).ready(function () {
    $('#busca').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    load();
});

function load() {
    let cidade = $('[name="busca"]').val();
    CidadeListaCidades(cidade).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append('' +
                '<tr id="obj-' + obj.id + '">' +
                '<td>' + (obj.nome || '--') + '</td>' +
                '<td>' + (obj.cpf || '--') + '</td>' +
                '<td>' + (obj.dataaniversario || '--') + '</td>' +
                '</tr>');
        });
    });
}

