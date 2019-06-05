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

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "home", component: HomeComponent },
  { path: "login", component: LoginComponent },
  { path: "registracija", component: RegistracijaComponent },
  { path: "redVoznje", component: RedVoznjeComponent },
  { path: "kupiKartu", component: KartaComponent },
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
    KartaComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [HttpService, {provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true}, AuthHttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
