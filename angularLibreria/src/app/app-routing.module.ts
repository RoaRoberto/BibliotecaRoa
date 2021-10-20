import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AutorComponent } from './Autor/autor.component';
import { HomeComponent } from './home/home.component';
import { LibroComponent } from './libro/libro.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'Libros',
    component: LibroComponent
  },
  {
    path: 'Autores',
    component: AutorComponent
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
