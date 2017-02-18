import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { PerfilService } from '../perfil.service';

@Component({
  selector: 'app-editar-perfil',
  templateUrl: './editar-perfil.component.html',
  styleUrls: ['./editar-perfil.component.css']
})
export class EditarPerfilComponent implements OnInit {

  private perfil: any = {};

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private service: PerfilService) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe((params: Params) => {
      let id = params['id'];

      this.service.obterPerfil(id)
        .then(result => this.perfil = result,
        err => {
          alert('Não foi possível carregar os dados do usuário');
          console.log(err);
        });
    });
  }

  submit() {
    this.service.alterarPerfil(this.perfil)
      .then(result => {
        this.router.navigate(['/perfil']);
      }, err => {
        alert("Erro ao tentar atualizar este perfil");
        console.error(err);
      });
  }

  excluirPerfil() {
    if (confirm('Deseja excluir este perfil?')) {
      this.service.excluirPerfil(this.perfil.Id)
        .then(result => {
          this.router.navigate(['/perfil']);
        }, err => {
          alert('Não foi possível excluir o registro');
          console.error(err);
        })
    }
  }



}
