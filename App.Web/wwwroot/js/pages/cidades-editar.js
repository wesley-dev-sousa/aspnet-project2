function editar() {
    let id = {
        id: ($("[name='id']").val()),
        cep: ($("[name='cep']").val() || ''),
        nome: ($("[name='nome']").val() || ''),
        uf: ($("[name='uf']").val() || '')
    };
    CidadeEditar(id).then(function () {
        window.location.href = '/cidades';
    }, function (err) {
        alert(err);
    });

}
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
                '<td>' + (obj.id) + '</td>' +
                '<td>' + (obj.cep || '--') + '</td>' +
                '<td>' + (obj.nome || '--') + '</td>' +
                '<td>' + (obj.uf || '--') + '</td>' +
                '</tr>');
        });
    });
}