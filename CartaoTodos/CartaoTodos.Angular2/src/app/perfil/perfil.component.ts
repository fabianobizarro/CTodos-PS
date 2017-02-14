import { Component, OnInit } from '@angular/core';
import { PerfilService } from '../perfil.service';
import { Perfil } from '../model';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  private perfis: Perfil[];
  constructor(private service: PerfilService) { }

  ngOnInit() {
    this.service.obterPerfis()
      .then(result => {
        this.perfis = result;
      }, err => {
        console.log(err);
      });
  }

}
