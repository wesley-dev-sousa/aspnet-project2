function criar(){
    let pessoa = {
        email: ($("[name='email']").val() || ''),
        senha: ($("[name='senha']").val() || ''),
        nomepessoa: ($("[name='nomepessoa']").val() || ''),
        dataaniversario: ($("[name='nomepessoa']").val() || ''),
        cpf: ($("[name='cpf']").val() || '')
    };
    PessoaCriar(pessoa).then(function () {
        window.location.href = '/pessoas';
    }, function (err) {
        alert(err);
    });
}
