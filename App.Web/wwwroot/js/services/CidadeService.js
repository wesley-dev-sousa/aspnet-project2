async function CidadeListaCidades(busca) {
    return new Promise((resolve, reject) => {
        Get('Cidade/ListaCidades?busca=' + busca).then(function (response) {
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

async function CidadeBuscaPorId(id) {
    return new Promise((resolve, reject) => {
        Get('Cidade/BuscaPorId?id=' + id).then(function (response) {
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

async function CidadeSalvar(obj) {
    return new Promise((resolve, reject) => {
        Post('Cidade/Salvar', obj).then(function (response) {
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

async function CidadeRemover(id) {
    return new Promise((resolve, reject) => {
        Delete('Cidade/Remover?id=' + id).then(function (response) {
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
