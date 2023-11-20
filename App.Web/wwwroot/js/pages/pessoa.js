$(document).ready(function () {
    $('#buscaPessoa').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    load();
});

function load() {
    let pessoa = $('[name="buscaPessoa"]').val();
    PessoaBuscarLista(pessoa).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append('' +
                '<tr id="obj-' + obj.id + '">' +
                '<td>' + (obj.id) + '</td>' +
                '<td>' + (obj.nomepessoa || '--') + '</td>' +
                '<td>' + (obj.cpf || '--') + '</td>' +
                '<td>' + (obj.dataaniversario || '--') + '</td>' +
                '</tr>');
        });
    });
}

