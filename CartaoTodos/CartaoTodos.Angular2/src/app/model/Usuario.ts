import {Perfil} from './Perfil';

export interface Usuario {
    Id: number;
    Nome: string;
    Email: string;
    Senha: string;
    Login: string;
    Perfis: Perfil[];
}