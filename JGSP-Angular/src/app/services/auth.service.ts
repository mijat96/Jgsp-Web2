import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegUser, RegUserImg } from 'src/app/osoba';
import { Stanica } from 'src/app/osoba';
import { RedVoznje } from 'src/app/osoba';
import { CenovnikBindingModel } from 'src/app/osoba';
import { Observable } from 'rxjs/internal/Observable';


@Injectable()
export class AuthHttpService{
    base_url = "http://localhost:52295"
  constructor(private http: HttpClient){
      
    }
  user: string
    logIn(username: string, password: string): Observable<boolean> | boolean{
        let isDone: boolean = false;
        let data = `username=${username}&password=${password}&grant_type=password`;
        let httpOptions = {
            headers: {
                "Content-type": "application/x-www-form-urlencoded"
            }
        }

        this.http.post<any>(this.base_url + "/oauth/token", data, httpOptions).subscribe(data => {
            localStorage.jwt = data.access_token;
            let jwtData = localStorage.jwt.split('.')[1]
            let decodedJwtJsonData = window.atob(jwtData)
            let decodedJwtData = JSON.parse(decodedJwtJsonData)

  
            let role = decodedJwtData.role
            this.user = decodedJwtData.unique_name;
        });

        if(localStorage.jwt != "undefined"){
            isDone = true;
        }
        else{
            isDone = false;
        }

        return isDone;
        
    }

    reg(data: RegUser) : Observable<any>{
        return this.http.post<any>(this.base_url + "/api/Account/Register", data);
    }
    regImg(data: any, username: string) : Observable<any>{    
        return this.http.post<any>(this.base_url + "/api/Slikas/UploadImage/" + username, data);
    }
    GetMejlovi() : Observable<any>{
        return this.http.get<any>(this.base_url + "/api/Values/GetZahtevi");
    }
    Odobri(mejl :string) : Observable<any>{
        return this.http.get<any>(this.base_url + "/api/Values/Odobri/" + mejl);
    }
    DodajRedVoznje1(red : RedVoznje) : Observable<any>{
        return this.http.post<any>(this.base_url + "/api/Redovi/dodajRed" , red);
    }
    DodajStanicu(stanica : Stanica) : Observable<any>{
        return this.http.post<any>(this.base_url + "/api/Stanicas" , stanica);
    }
    DodajLiniju(broj : string) : Observable<any>{
        return this.http.get<any>(this.base_url + "/api/Linijas/GetLinijaDodaj/"  + broj);
    }
      obrisiCenovnik(id: number) : Observable<any>{
        return this.http.delete<any>(this.base_url + "/api/Cenovniks/" + id);
    }
    obrisiRedVoznje(id: number) : Observable<any>{
        return this.http.delete<any>(this.base_url + "/api/RedVoznjes/" + id);
    }
    DeleteLinija(id: number) : Observable<any>{
        return this.http.delete<any>(this.base_url + "/api/Linijas/" + id);
    }
    DeleteStanica(ime: string) : Observable<any>{
        return this.http.get<any>(this.base_url + "/api/Stanicas/IzbrisiStanicu/" + ime +"/a"+ "/a");
    }
    
    Promeni(data: RegUser) : Observable<any>{
        return this.http.post<any>(this.base_url + "/api/Kartas/PromeniProfil", data);
    }
    DodajCenovnik(cenovnik: CenovnikBindingModel) : Observable<any>{
        return this.http.post<any>(this.base_url + "/PromeniCenovnik",  cenovnik);
    }
    GetPolasci(id: number, dan : string) : Observable<any> {
        return this.http.get<any>(this.base_url + "/api/Linijas/GetLinija/" + id +"/" + dan);
    }

    GetLinije() : Observable<any> {
        return this.http.get<any>(this.base_url + "/api/Linijas/");
    }
    GetStanice() : Observable<any> {
        return this.http.get<any>(this.base_url + "/api/Stanicas/GetStanicee");
    }
    GetSpoji(linija:string, stanica: string) : Observable<any> {
        return this.http.get<any>(this.base_url + "/api/Stanicas/Spoji/" + linija + "/" + stanica );
    }
    GetKorisnika() : Observable<any> {
        return this.http.get<any>(this.base_url + "/api/Kartas/DobaviUsera");
    }
    //samo da se iscita json na serveru i popuni baza
    ParsiranjeJson(id: number, dan : string) : Observable<any> {
        return this.http.get<any>(this.base_url + "/api/Linijas/GetLinija/" + id + "/" + dan + "/" + "str");
    }

    GetCenaKarte(tip: string, tipPutnika: string): Observable<any>{
        return this.http.get<any>(this.base_url + "/api/Kartas/GetKarta/" + tip + "/" + tipPutnika);
    }
    GetPromenaCene(tip: string, tipPutnika: string, cena : number): Observable<any>{
        return this.http.get<any>(this.base_url + "/api/Kartas/GetKartaPromenaCene/" + tip + "/" + tipPutnika + "/" + cena);
    }
    GetKupiKartu(tipKarte: string, mejl: string): Observable<any>{
       
        return this.http.get<any>(this.base_url + "/api/Kartas/GetKartaKupi2/" + tipKarte  + "/" + mejl);
    }
    GetKupiKartuNeregistrovan(tipKarte: string, mejl :string): Observable<any>{
       
        return this.http.get<any>(this.base_url + "/api/Kartas/GetKartaKupi2/" + tipKarte + "/"  + mejl);
    }
    GetStanicaCord(idStanice: string): Observable<any>{
        return this.http.get<any>(this.base_url + "/api/Stanicas/GetStanica/" + idStanice);
    }
    GetProveriKartu(idKorisnika: string): Observable<any>{
       
        return this.http.get<any>(this.base_url + "/api/Kartas/GetProveri/" + idKorisnika );
    }
    GetSlika(idKorisnika: string): Observable<any>{
        return this.http.get<any>(this.base_url + "/api/Slikas/GetSlika/" + idKorisnika);
    }
    Verifikovan(): Observable<any>{
        return this.http.get<any>(this.base_url + "/api/Values/Verifikovan");
    }

}