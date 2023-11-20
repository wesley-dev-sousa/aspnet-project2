$(document).ready(function () {
    $('#busca').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    load();
});

function load() {
    let pessoa = $('[name="busca"]').val();
    PessoaBuscarLista(pessoa).then(function (data) {
        $('#table tbody').html('');
        data.forEach(pessoa => {
            $('#table tbody').append('' +
                '<tr id="obj-' + pessoa.id + '">' +
                '<td>' + (pessoa.id) + '</td>' +
                '<td>' + (pessoa.nomepessoa || '--') + '</td>' +
                '<td>' + (pessoa.cpf || '--') + '</td>' +
                '<td>' + (pessoa.dataaniversario || '--') + '</td>' +
                '</tr>');
        });
    });
}

