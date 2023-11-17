function remover() {
    CidadeRemover(($("[name='id']").val())).then(function () {
        window.location.href = '/cidades';
    }, function (err) {
        alert(err);
    });
}
