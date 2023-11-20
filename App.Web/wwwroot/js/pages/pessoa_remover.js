function deletar() {
    PessoaDeletar(($("[name='id']").val())).then(function () {
        window.location.href = '/pessoas';
    }, function (err) {
        alert(err);
    });
}
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
                '<td>' + (obj.nome || '--') + '</td>' +
                '<td>' + (obj.cpf || '--') + '</td>' +
                '</tr>');
        });
    });
}