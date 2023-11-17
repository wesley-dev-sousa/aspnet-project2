function editar() {
    let obj = {
        id: ($("[name='id']").val() || ''),
        cep: ($("[name='cep']").val() || ''),
        nome: ($("[name='nome']").val() || ''),
        uf: ($("[name='uf']").val() || '')
    };
    CidadeEditar(obj).then(function () {
        window.location.href = '/cidades';
    }, function (err) {
        alert(err);
    });
}
