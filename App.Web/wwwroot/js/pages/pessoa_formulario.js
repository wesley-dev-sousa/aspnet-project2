function criar() {
    let obj = {
        nomepessoa: ($("[name='nomepessoa']").val() || ''),
        cpf: ($("[name='cpf']").val() || ''),
        dataaniversario: ($("[name='dataaniversario']").val() || ''),
        email: ($("[name='email']").val() || ''),
        senha: ($("[name='senha']").val() || '')
    };
    PessoaCriar(obj).then(function () {
        window.location.href = '/pessoas';
    }, function (err) {
        alert(err);
    });
};
