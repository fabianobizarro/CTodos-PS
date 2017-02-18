import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UsuariosComponent } from './usuarios/usuarios.component';
import { PerfilComponent } from './perfil/perfil.component';
import { NovoUsuarioComponent } from './novo-usuario/novo-usuario.component';
import { DetalhesUsuarioComponent } from './detalhes-usuario/detalhes-usuario.component';
import { EditarUsuarioComponent } from './editar-usuario/editar-usuario.component';
import { NovoPerfilComponent } from './novo-perfil/novo-perfil.component';
import { EditarPerfilComponent } from './editar-perfil/editar-perfil.component';

const appRoutes: Routes = [
    { path: '', component: UsuariosComponent },
    { path: 'usuarios', component: UsuariosComponent },
    { path: 'usuarios/novo', component: NovoUsuarioComponent },
    { path: 'usuarios/:id', component: DetalhesUsuarioComponent },
    { path: 'usuarios/:id/editar', component: EditarUsuarioComponent },
    { path: 'perfil', component: PerfilComponent },
    { path: 'perfil/novo', component: NovoPerfilComponent },
    { path: 'perfil/:id/editar', component: EditarPerfilComponent }
]

@NgModule({
    imports: [RouterModule.forRoot(appRoutes, { useHash: true })],
    exports: [RouterModule]
})
export class AppRoutingModule { }