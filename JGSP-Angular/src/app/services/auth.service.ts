import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegUser } from 'src/app/osoba';
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class AuthHttpService{
    base_url = "http://localhost:52295"
  constructor(private http: HttpClient){
      
    }
  user: string
    logIn(username: string, password: string){

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
    }

    reg(data: RegUser) : Observable<any>{
        return this.http.post<any>(this.base_url + "/api/Account/Register", data);
    }

 
    GetPolasci(id: number, dan : string) : Observable<any> {
        return this.http.get<any>(this.base_url + "/api/Linijas/GetLinija/" + id +"/" + dan);
    }

    GetLinije() : Observable<any> {
        return this.http.get<any>(this.base_url + "/api/Linijas/");
    }

    GetCenaKarte(tip: string): Observable<any>{
        return this.http.get<any>(this.base_url + "/api/Kartas/GetKarta/" + tip);
    }
    GetKupiKartu(tipKarte: string, tipKorisnika: string, user : string): Observable<any>{
       
        return this.http.get<any>(this.base_url + "/api/Kartas/GetKartaKupi2/" + tipKarte + "/" + tipKorisnika + "/" + user);
    }

 
}