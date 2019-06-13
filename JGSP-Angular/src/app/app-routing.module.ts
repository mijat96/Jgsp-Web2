// import { NgModule } from '@angular/core';
// import { Routes, RouterModule } from '@angular/router';
// import { AuthGuard } from './services/auth.guard';
// import { LoginComponent } from './login/login.component';
// import { DodajRedVoznjeComponent } from './dodaj-red-voznje/dodaj-red-voznje.component';
// import { HomeComponent } from './home/home.component';
// import { KartaComponent } from './karta/karta.component';
// import { RegistracijaComponent } from './registracija/registracija.component';
// import { RedVoznjeComponent } from './red-voznje/red-voznje.component';
// import { KartaNeregistrovanComponent } from './karta-neregistrovan/karta-neregistrovan.component';
// import { KontrolorComponent } from './kontrolor/kontrolor.component';
// import { CenovnikComponent } from './cenovnik/cenovnik.component';
// import { MojProfilComponent } from './moj-profil/moj-profil.component';
// import { CenovnikPromenaComponent } from './cenovnik-promena/cenovnik-promena.component';
// import { CenovnikDodajComponent } from './cenovnik-dodaj/cenovnik-dodaj.component';
// import { CenovnikBrisanjeComponent } from './cenovnik-brisanje/cenovnik-brisanje.component';
// import { ObrisiRedVoznjeComponent } from './obrisi-red-voznje/obrisi-red-voznje.component';
// import { DodajLinijuComponent } from './dodaj-liniju/dodaj-liniju.component';
// import { DodajStanicuComponent } from './dodaj-stanicu/dodaj-stanicu.component';

// // const routes: Routes = [
// //   {
// //     path: 'dodaj-red-voznje',
// //     component: DodajRedVoznjeComponent,
// //     canActivate: [AuthGuard]
// //   },
// //   { 
// //     path: 'karta', 
// //     component: KartaComponent, 
// //   },
// //   {
// //     path: 'crisis-center',
// //     component: CrisisCenterComponent,
    
// //       children: [
// //         {
// //           path: '',
// //           component: CrisisListComponent,
          
// //           children: [
// //             {
// //               path: ':id',
// //               component: CrisisDetailComponent,
// //               canActivate: [AuthGuard],
// //               resolve: {
// //                 crisis: CrisisDetailResolverService
// //               }
// //             },
// //             {
// //               path: '',
// //               component: CrisisCenterHomeComponent
// //             }
// //           ]
// //         }
// //       ]
// //   },
// //   {
// //     path: '',
// //     redirectTo: '/crisis-center',
// //     pathMatch: 'full'
// //   },
// //   {
// //     path: '**',
// //     component: HomeComponent
// //   }
// // ];

// const routes: Routes = [
//   { path: "", component: HomeComponent },
//   { path: "home", component: HomeComponent,
//      children:[
//        { path: "login", component: LoginComponent },
//        { path: "registracija", component: RegistracijaComponent, canActivate: [AuthGuard] },
//        { path: "redVoznje", component: RedVoznjeComponent },
//        { path: "kupiKartu", component: KartaComponent },
//        { path: "kupiKartuNeregistrovan", component: KartaNeregistrovanComponent },
//        { path: "kontrolor", component: KontrolorComponent },
//        { path: "cenovnik", component: CenovnikComponent },
//        { path: "mojProfil", component: MojProfilComponent },
//        { path: "promenaCene", component: CenovnikPromenaComponent },
//        { path: "dodajCenovnik", component: CenovnikDodajComponent },
//        { path: "dodajRedVoznje", component: DodajRedVoznjeComponent },
//        { path: "obrisiCenovnik", component: CenovnikBrisanjeComponent },
//        { path: "obrisiRedVoznje", component: ObrisiRedVoznjeComponent },
//        { path: "dodajLiniju", component: DodajLinijuComponent },
//        { path: "dodajStanicu", component: DodajStanicuComponent },
//      ]
//   },
//   {
//     path: '',
//     redirectTo: '/home',
//     pathMatch: 'full'
//   },
//   { path: "**", redirectTo: "home" }
// ];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
// export class AppRoutingModule { }


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }