import { Injectable } from '@angular/core';
import { Usuario } from './model';
import { environment } from '../environments/environment';
import { Http } from '@angular/http';

@Injectable()
export class UsuarioService {

    private endpoint: string = environment.api_endpoint + '/Usuario';
    constructor(private http: Http) { }

    obterUsuarios(): Promise<Usuario[]> {
        return new Promise((resolve, reject) => {


            this.http.get(this.endpoint)
                .map(res => res.json())
                .subscribe(resolve, reject);

        });
    }

    obterDadosUsuario(id: number): Promise<Usuario> {
        return new Promise((resolve, reject) => {

            this.http.get(`${this.endpoint}/${id}`)
                .map(res => res.json())
                .subscribe(resolve, reject);

        });
    }

    adicionarUsuario(usuario: Usuario): Promise<any> {
        return new Promise((resolve, reject) => {

            this.http.post(this.endpoint, usuario)
                .map(res => {
                    return res.json();
                })
                .subscribe(resolve, reject);

        });
    }

    alterarUsuario(usuario: Usuario): Promise<any> {
        return new Promise((resolve, reject) => {

            this.http.put(`${this.endpoint}/${usuario.Id}`, usuario)
                .map(res => res.json())
                .subscribe(resolve, reject);

        });
    }

    excluirUsuario(id: number): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.delete(`${this.endpoint}/${id}`)
                .map(res => res.json())
                .subscribe(resolve, reject);
        });
    }

    adicionarPerfil(usuarioId: number, perfilId: number): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.post(`${this.endpoint}/${usuarioId}/perfil`, { Id: perfilId })
                .map(res => res.json())
                .subscribe(resolve, reject);
        });
    }

    removerPerfil(usuarioId: number, perfilId: number): Promise<any> {
        return new Promise((resolve, reject) => {

            this.http.delete(`${this.endpoint}/${usuarioId}/perfil?id=${perfilId}`)
                .map(res => res.json())
                .subscribe(resolve, reject);

        });
    }

}
