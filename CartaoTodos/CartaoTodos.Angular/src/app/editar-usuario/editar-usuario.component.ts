import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../usuario.service';
import { Router, ActivatedRoute } from '@angular/router';
import { PerfilService } from '../perfil.service';
import { Usuario, Perfil } from '../model';


@Component({
  selector: 'app-editar-usuario',
  templateUrl: './editar-usuario.component.html',
  styleUrls: ['./editar-usuario.component.css']
})
export class EditarUsuarioComponent implements OnInit {

  private perfis: any = [];
  private perfisDisponiveis: any = [];
  private perfisSelecionados: any = [];
  private perfilSelecionado: any = null;
  private usuario: any = {};

  constructor(private perfilService: PerfilService, private service: UsuarioService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.perfilService.obterPerfis()
      .then(result => {
        this.perfis = result;
        this.atualizarPerfisDisponiveis();
      }, err => {
        alert('Não foi possível obter os perfis de usuário');
        console.log(err)
      });


    this.activatedRoute.params.subscribe((params) => {
      let id = params['id'];

      this.service.obterDadosUsuario(id)
        .then(result => {
          this.usuario = result;
          this.perfisSelecionados = this.usuario.Perfis;
          this.atualizarPerfisDisponiveis();
        },
        err => {
          alert('Não foi possível obter os dados do usuário. Tente novamente');
          console.log(err);
        });
    });
  }

  adicionarPerfil() {

    this.service.adicionarPerfil(this.usuario.Id, this.perfilSelecionado)
      .then(result => {

        let perfil = this.perfis.filter(p => {
          return p.Id == this.perfilSelecionado
        })[0];

        this.perfisSelecionados.push(perfil);
        this.atualizarPerfisDisponiveis();

      }, err => {
        alert('Não foi possível vincular este perfil ao usuário. Tente novamente');
        console.log(err);
      });

  }

  removerPerfil(perfil: Perfil) {

    this.service.removerPerfil(this.usuario.Id, perfil.Id)
      .then(result => {

        let i = this.perfisSelecionados.indexOf(perfil);
        if (i >= 0) {
          this.perfisSelecionados.splice(i, 1);
          this.atualizarPerfisDisponiveis();
        }

      }, err => {
        alert('Não foi possível remover este perfil. Tente novamente');
        console.log(err);
      });

  }

  private atualizarPerfisDisponiveis() {
    /**
     * Atualiza o Dropdown com os perfis disponíveis para seleção,
     * deixando somente os perfis que não foram escolhidos pelo usuário
     */
    this.perfisDisponiveis = this.perfis.filter(p => {
      return this.perfisSelecionados.indexOf(p) == -1;
    });
  }

  alterarUsuario() {
    this.service.alterarUsuario(this.usuario)
      .then(result => {
        this.router.navigate(['/usuarios']);
      }, err => {
        alert('Erro ao tentar atualizar os dados do usuário');
        console.log(err);
      });

  }

  excluirUsuario() {
    this.service.excluirUsuario(this.usuario.Id)
      .then(result => {
        this.router.navigate(['/usuarios']);
      }, err => {
        alert('Erro ao tentar excluir o usuário');
        console.log(err);
      })
  }
}