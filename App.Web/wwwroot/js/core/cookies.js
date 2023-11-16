function SetCookie(name, value) {
    let expires = "";
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

function GetCookie(name) {
    let nameEQ = name + "=";
    let ca = document.cookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) === ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) === 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function DeleteCookie(name) {
    document.cookie = name + '=; Max-Age=-99999999;';
    if (name === 'CP-Token') {
        SetCookie('CP-Token', null);
    }
}

function DeleteAllCookies() {
    DeleteCookie('CP-Token');
    DeleteCacheCookies();
}

function DeleteCacheCookies() {
    DeleteCookie('id-usuario');
    DeleteCookie('id-tipo-usuario');
    DeleteCookie('tipo-usuario');
    DeleteCookie('nome-usuario');
    DeleteCookie('numero-permissoes');
    DeleteCookie('org-codigo');
}
