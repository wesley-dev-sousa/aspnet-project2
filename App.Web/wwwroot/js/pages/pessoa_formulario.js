function criar(){
    let obj = {
        email: ($("[name='email']").val() || ''),
        senha: ($("[name='senha']").val() || ''),
        nomepessoa: ($("[name='nomepessoa']").val() || ''),
        cpf: ($("[name='cpf']").val() || '')
    };
    PessoaCriar(obj).then(function () {
        window.location.href = '/pessoas';
    }, function (err) {
        alert(err);
    });
}
