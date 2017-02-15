import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../usuario.service';
import { Router, ActivatedRoute } from '@angular/router';
import { PerfilService } from '../perfil.service';
import { Usuario } from '../model';

@Component({
  selector: 'app-novo-usuario',
  templateUrl: './novo-usuario.component.html',
  styleUrls: ['./novo-usuario.component.css']
})
export class NovoUsuarioComponent implements OnInit {

  private perfis: any = [];
  private perfisDisponiveis: any = [];
  private perfisSelecionados: any = [];
  private perfilSelecionado: any = null;
  private usuario: any = {};

  constructor(private perfilService: PerfilService, private service: UsuarioService, private router: Router) { }

  ngOnInit() {

    this.perfilService.obterPerfis()
      .then(result => {
        this.perfis = result;
        this.perfisDisponiveis = this.perfis;
      }, err => console.log(err));

  }

  adicionarPerfil() {

    if (this.perfilSelecionado) {
      this.perfisSelecionados.push(this.perfilSelecionado);
      this.atualizarPerfisDisponiveis();
    }

  }

  removerPerfil(perfil: string) {

    let i = this.perfisSelecionados.indexOf(perfil);
    if (i >= 0) {
      this.perfisSelecionados.splice(i, 1);
      this.atualizarPerfisDisponiveis();
    }

  }

  private atualizarPerfisDisponiveis() {
    /**
     * Atualiza o Dropdown com os perfis disponíveis para seleção,
     * deixando somente os perfis que não foram escolhidos pelo usuário
     */
    this.perfisDisponiveis = this.perfis.filter(p => {
      return this.perfisSelecionados.indexOf(p.Nome) == -1;
    });
  }

  cadastrarUsuario() {


    this.usuario.Perfis = this.perfis.filter(p => {
      return this.perfisSelecionados.indexOf(p.Nome) != -1;
    });

    this.service.adicionarUsuario(this.usuario)
      .then(result => {
        console.log(result);
        this.router.navigate(['/usuarios']);
      }, err => {
        alert('Não foi possível cadastrar o usuário');
        let data = JSON.parse(err._body);
        console.log(data);
      });

  }

}