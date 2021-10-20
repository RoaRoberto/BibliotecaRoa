import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
//import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LibroService } from './services/Libro.service';
import { AutorService } from './services/Autor.service';
import { CiudadService } from './services/Ciudad.service';
import { HttpClientModule } from '@angular/common/http';
import { LibroComponent } from './libro/libro.component';
import { AutorComponent } from './Autor/autor.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    LibroComponent,
    AutorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    HttpClientModule,

  ],
  providers: [
    
    LibroService,
    AutorService,
    CiudadService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
