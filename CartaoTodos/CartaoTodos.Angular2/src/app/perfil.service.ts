import { Injectable } from '@angular/core';
import { Perfil } from './model';

@Injectable()
export class PerfilService {

  constructor() { }

  obterPerfis(): Promise<Perfil[]> {
    return new Promise((resolve, reject) => {

      resolve([
        {
          Id: 2,
          Nome: "Administrador",
          Ativo: true
        },
        {
          Id: 4,
          Nome: "Gerente",
          Ativo: false
        }
      ]);


    });
  }

}
