import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { UsuarioService } from '../usuario.service';
import { Usuario } from '../model';

@Component({
  selector: 'app-detalhes-usuario',
  templateUrl: './detalhes-usuario.component.html',
  styleUrls: ['./detalhes-usuario.component.css']
})
export class DetalhesUsuarioComponent implements OnInit {

  private usuario: any = {};

  constructor(private activatedRoute: ActivatedRoute, private service: UsuarioService) {

  }

  ngOnInit() {
    this.activatedRoute.params.subscribe((params: Params) => {
      let id = params['id'];

      this.service.obterDadosUsuario(id)
        .then(result => this.usuario = result,
        err => {
          console.log(err);
        });
    });
  }

}
