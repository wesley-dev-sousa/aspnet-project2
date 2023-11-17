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
