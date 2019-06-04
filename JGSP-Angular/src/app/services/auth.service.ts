import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegUser } from 'src/app/osoba';
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class AuthHttpService{
    base_url = "http://localhost:52295"

    constructor(private http: HttpClient){

    }

    logIn(username: string, password: string){

        let data = `username=${username}&password=${password}&grant_type=password`;
        let httpOptions = {
            headers: {
                "Content-type": "application/x-www-form-urlencoded"
            }
        }

        this.http.post<any>(this.base_url + "/oauth/token", data, httpOptions).subscribe(data => {
            localStorage.jwt = data.access_token;
        });
    }

    reg(data: RegUser){
        return this.http.post<any>(this.base_url + "/api/Account/Register", data).subscribe();
    }

    logOut() : Observable<any>{
        return this.http.post<any>(this.base_url + "/api/Account/Logout", null);
    }
    GetPolasci(id: number) : Observable<any> {
        return this.http.get<any>(this.base_url + "/api/RedVoznjes/" + id);
    }
}