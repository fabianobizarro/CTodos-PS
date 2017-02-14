import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../usuario.service';
import { Usuario, Perfil } from '../model';

@Component({
    selector: 'app-usuarios',
    templateUrl: './usuarios.component.html',
    styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

    public usuarios: Usuario[];

    constructor(public service: UsuarioService) { }

    ngOnInit() {
        this.service.obterUsuarios()
            .then(result => {
                this.usuarios = result
            }, err => {
                console.log(err);
            });
    }

}
