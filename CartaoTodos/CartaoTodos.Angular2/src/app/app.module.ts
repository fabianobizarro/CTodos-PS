import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';

import { AppRoutingModule } from './app.routing';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { NovoUsuarioComponent } from './novo-usuario/novo-usuario.component';
import { PerfilComponent } from './perfil/perfil.component';

import { UsuarioService } from './usuario.service';
import { PerfilService } from './perfil.service';
import { DetalhesUsuarioComponent } from './detalhes-usuario/detalhes-usuario.component';
import { EditarUsuarioComponent } from './editar-usuario/editar-usuario.component';
import { NovoPerfilComponent } from './novo-perfil/novo-perfil.component';
import { EditarPerfilComponent } from './editar-perfil/editar-perfil.component';

@NgModule({
    declarations: [
        AppComponent,
        MenuComponent,
        UsuariosComponent,
        NovoUsuarioComponent,
        PerfilComponent,
        DetalhesUsuarioComponent,
        EditarUsuarioComponent,
        NovoPerfilComponent,
        EditarPerfilComponent
    ],
    imports: [
        AppRoutingModule,
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    providers: [UsuarioService, PerfilService],
    bootstrap: [AppComponent]
})
export class AppModule { }
