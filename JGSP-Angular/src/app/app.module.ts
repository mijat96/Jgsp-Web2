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

import { SpojiStanicaLinijaComponent } from './spoji-stanica-linija/spoji-stanica-linija.component';
import { ObrisiStanicaComponent } from './obrisi-stanica/obrisi-stanica.component';
import { ObrisiLinijaComponent } from './obrisi-linija/obrisi-linija.component';
import { OdobriMejlComponent } from './odobri-mejl/odobri-mejl.component';
import { AuthGuardControlor } from './services/auth.guard.controlor';
import { AuthGuardUlogovan } from './services/auth.guard.ulogova';
import { AuthGuardNeregistrovan } from './services/auth.guard.neregistrovan';
import { LokacijaVozilaComponent } from './lokacija-vozila/lokacija-vozila.component';

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "home", component: HomeComponent },
  { path: "login", component: LoginComponent, canActivate: [AuthGuardUlogovan] },
  { path: "registracija", component: RegistracijaComponent, canActivate: [AuthGuardUlogovan] },
  { path: "redVoznje", component: RedVoznjeComponent  },
  { path: "kupiKartu", component: KartaComponent, canActivate: [AuthGuardNeregistrovan] },
  { path: "kupiKartuNeregistrovan", component: KartaNeregistrovanComponent, canActivate: [AuthGuardUlogovan] },
  { path: "kontrolor", component: KontrolorComponent, canActivate: [AuthGuardControlor] },
  { path: "cenovnik", component: CenovnikComponent },
  { path: "lokacijaVozila", component: LokacijaVozilaComponent },
  { path: "mojProfil", component: MojProfilComponent, canActivate: [AuthGuardNeregistrovan] },
  { path: "promenaCene", component: CenovnikPromenaComponent, canActivate: [AuthGuard] },
  { path: "dodajCenovnik", component: CenovnikDodajComponent, canActivate: [AuthGuard] },
  { path: "dodajRedVoznje", component: DodajRedVoznjeComponent, canActivate: [AuthGuard] },
  { path: "obrisiCenovnik", component: CenovnikBrisanjeComponent, canActivate: [AuthGuard] },
  { path: "obrisiRedVoznje", component: ObrisiRedVoznjeComponent, canActivate: [AuthGuard] },
  { path: "dodajLiniju", component: DodajLinijuComponent, canActivate: [AuthGuard] },
  { path: "dodajStanicu", component: DodajStanicuComponent, canActivate: [AuthGuard] },
    { path: "spojiStanicaLinija", component: SpojiStanicaLinijaComponent, canActivate: [AuthGuard] },
    { path: "izbrisiStanicu", component: ObrisiStanicaComponent, canActivate: [AuthGuard] },
    { path: "izbrisiLiniju", component: ObrisiLinijaComponent, canActivate: [AuthGuard] },
    { path: "odobrimejl", component: OdobriMejlComponent, canActivate: [AuthGuardControlor] },
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
    SpojiStanicaLinijaComponent,
    ObrisiStanicaComponent,
    ObrisiLinijaComponent,
    OdobriMejlComponent,
    LokacijaVozilaComponent
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