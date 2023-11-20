function criar() {
    let obj = {
        nome: ($("[name='nome']").val() || ''),
        cpf: ($("[name='cpf']").val() || ''),
        dataAniversario: ($("[name='dataAniversario']").val() || ''),
        email: ($("[name='email']").val() || ''),
        senha: ($("[name='senha']").val() || '')
    };
    PessoaCriar(obj).then(function () {
        window.location.href = '/pessoas';
    }, function (err) {
        alert(err);
    });
};
