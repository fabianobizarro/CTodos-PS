import { Component, OnInit } from '@angular/core';
import { Perfil } from '../model';
import { PerfilService } from '../perfil.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-novo-perfil',
  templateUrl: './novo-perfil.component.html',
  styleUrls: ['./novo-perfil.component.css']
})
export class NovoPerfilComponent implements OnInit {

  public perfil: Perfil = { Ativo: true, Id: 0, Nome: '' };

  constructor(private service: PerfilService, private router: Router) { }

  ngOnInit() {
  }

  submit() {
    this.service.adicionarPerfil(this.perfil)
      .then(result => {
        this.router.navigate(['/perfil']);
      }, err => {
        alert('Ocorreu um erro ao cadastrar este perfil');
        console.log(err);
      });
  }

}
