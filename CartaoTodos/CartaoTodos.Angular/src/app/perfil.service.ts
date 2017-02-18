import { Injectable } from '@angular/core';
import { Perfil } from './model';
import { Http, Headers } from '@angular/http';
import { environment } from '../environments/environment';
import 'rxjs/add/operator/map';

@Injectable()
export class PerfilService {

  constructor(private http: Http) { }

  obterPerfis(todos: boolean = false): Promise<Perfil[]> {
    return new Promise((resolve, reject) => {

      let url = environment.api_endpoint + '/Perfil';

      if (todos)
        url += '?all=true'

      this.http.get(url)
        .map(res => res.json())
        .subscribe(resolve, reject);
    });
  }

  obterPerfil(id: number): Promise<any> {
    return new Promise((resolve, reject) => {

      let url = environment.api_endpoint + `/Perfil/${id}`;

      this.http.get(url)
        .map(res => res.json())
        .subscribe(resolve, reject);

    });
  }

  adicionarPerfil(perfil: Perfil): Promise<any> {
    return new Promise((resolve, reject) => {

      let url = environment.api_endpoint + '/Perfil';
      this.http.post(url, perfil)
        .map(res => res.json())
        .subscribe(resolve, reject);

    });
  }

  alterarPerfil(perfil: Perfil): Promise<any> {
    return new Promise((resolve, reject) => {
      let url = environment.api_endpoint + `/Perfil/${perfil.Id}`;
      this.http.put(url, perfil)
        .map(res => res.json())
        .subscribe(resolve, reject);
    })
  }

  excluirPerfil(id: number): Promise<any> {
    return new Promise((resolve, reject) => {
      let url = environment.api_endpoint + `/Perfil/${id}`;
      this.http.delete(url)
        .map(res => res.json())
        .subscribe(resolve, reject);
    });
  }

}
