import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router'
import { HttpService } from './services/http.service';
import { from } from 'rxjs';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AuthHttpService } from './services/auth.service';
import { PrvaKomponentaComponent } from 'src/app/prva-komponenta/prva-komponenta.component';
import { RegistracijaComponent } from './registracija/registracija.component';
import { RedVoznjeComponent } from './red-voznje/red-voznje.component';
import { LinijeComponent } from './linije/linije.component';
import { KartaComponent } from './karta/karta.component';

import { MapComponent } from './map/map.component';
import { AgmCoreModule } from '@agm/core';
import { KontrolorComponent } from './kontrolor/kontrolor.component';
import { CenovnikComponent } from './cenovnik/cenovnik.component';
import { KartaNeregistrovanComponent } from './karta-neregistrovan/karta-neregistrovan.component';
import { MojProfilComponent } from './moj-profil/moj-profil.component';
import { CenovnikPromenaComponent } from './cenovnik-promena/cenovnik-promena.component';
import { CenovnikDodajComponent } from './cenovnik-dodaj/cenovnik-dodaj.component';
import { CenovnikBrisanjeComponent } from './cenovnik-brisanje/cenovnik-brisanje.component';
import { DodajRedVoznjeComponent } from './dodaj-red-voznje/dodaj-red-voznje.component';
import { ObrisiRedVoznjeComponent } from './obrisi-red-voznje/obrisi-red-voznje.component';
import { DodajLinijuComponent } from './dodaj-liniju/dodaj-liniju.component';
import { DodajStanicuComponent } from './dodaj-stanicu/dodaj-stanicu.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthGuard } from './services/auth.guard';


const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "home", component: HomeComponent },
  { path: "login", component: LoginComponent },
  { path: "registracija", component: RegistracijaComponent },
  { path: "redVoznje", component: RedVoznjeComponent, canActivate: [AuthGuard]  },
  { path: "kupiKartu", component: KartaComponent },
  { path: "kupiKartuNeregistrovan", component: KartaNeregistrovanComponent },
  { path: "kontrolor", component: KontrolorComponent },
  { path: "cenovnik", component: CenovnikComponent },
  { path: "mojProfil", component: MojProfilComponent },
  { path: "promenaCene", component: CenovnikPromenaComponent },
  { path: "dodajCenovnik", component: CenovnikDodajComponent },
  { path: "dodajRedVoznje", component: DodajRedVoznjeComponent },
  { path: "obrisiCenovnik", component: CenovnikBrisanjeComponent },
  { path: "obrisiRedVoznje", component: ObrisiRedVoznjeComponent },
  { path: "dodajLiniju", component: DodajLinijuComponent },
  { path: "dodajStanicu", component: DodajStanicuComponent },
  { path: "**", redirectTo: "home" }
]

@NgModule({
  declarations: [
    AppComponent,
    PrvaKomponentaComponent,
    HomeComponent,
    LoginComponent,
    RegistracijaComponent,
    RedVoznjeComponent,
    LinijeComponent,
    KartaComponent,
    MapComponent,
    KontrolorComponent,
    CenovnikComponent,
    KartaNeregistrovanComponent,
    MojProfilComponent,
    CenovnikPromenaComponent,
    CenovnikDodajComponent,
    CenovnikBrisanjeComponent,
    DodajRedVoznjeComponent,
    ObrisiRedVoznjeComponent,
    DodajLinijuComponent,
    DodajStanicuComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    AgmCoreModule.forRoot({apiKey: 'AIzaSyDnihJyw_34z5S1KZXp90pfTGAqhFszNJk'}),
    RouterModule.forRoot(routes)
  ],
  providers: [HttpService, {provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true}, AuthHttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }