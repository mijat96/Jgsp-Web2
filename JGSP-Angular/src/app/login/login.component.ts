import { Component, OnInit } from '@angular/core';
import { User } from '../osoba';
import { AuthHttpService } from '../services/auth.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private http: AuthHttpService, private router: Router) { }

  isLogin: boolean = false;
  
  ngOnInit() {
  }

  login(user: User, form: NgForm){
    let l = this.http.logIn(user.username, user.password);
    form.reset();
  
    this.router.navigate(["/home"]);
 
  }

  
}
