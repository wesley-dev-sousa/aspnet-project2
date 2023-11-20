async function PessoaBuscarLista(busca) {
    return new Promise((resolve, reject) => {
        Get('Pessoa/BuscarLista?busca=' + busca).then(function (response) {
            console.log(response)
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}

async function PessoaBuscaPorId(id) {
    return new Promise((resolve, reject) => {
        Get('Pessoa/BuscaPorId?id=' + id).then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}

async function PessoaCriar(pessoa) {
    return new Promise((resolve, reject) => {
        Post('Pessoa/Criar', pessoa).then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}

async function PessoaEditar(id) {
    return new Promise((resolve, reject) => {
        Put('Pessoa/Editar?id=', id).then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}

async function PessoaRemover(id) {
    return new Promise((resolve, reject) => {
        Delete('Pessoa/Remover?id=' + id).then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}
