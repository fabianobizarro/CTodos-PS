import { Injectable } from '@angular/core';
import { Usuario } from './model'
@Injectable()
export class UsuarioService {

    constructor() { }

    obterUsuarios(): Promise<Usuario[]> {
        return new Promise((resolve, reject) => {

            resolve([
                {
                    Id: 1,
                    Email: 'fabiano@email.com',
                    Nome: "Fabiano Bizarro",
                    Login: 'fabianob',
                    Senha: 'sfsdfsaf',
                    Perfis: [{ Id: 2, Nome: "Administrador", Ativo: true }]
                },
                {
                    Id: 1,
                    Email: 'fabiano@email.com',
                    Nome: "Fabiano Bizarro",
                    Login: 'fabianob',
                    Senha: 'sfsdfsaf',
                    Perfis: [{ Id: 2, Nome: "Administrador", Ativo: true }]
                }
            ]);


        });
    }

}
