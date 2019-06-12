import { Component, OnInit } from '@angular/core';
import { RegUser } from 'src/app/osoba';
import { NgForm } from '@angular/forms';
import { AuthHttpService } from 'src/app/services/auth.service';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent implements OnInit {
  
  registacijaForm = this.fb.group({
    name: ['', Validators.required],
    surname: ['', Validators.required],
    username: ['', Validators.required],
    password: ['', Validators.required],
    confirmPassword: ['', Validators.required],
    email: ['', Validators.required],
    date: ['', Validators.required],
    tip: ['', Validators.required]
  });

  constructor(private http: AuthHttpService, private fb: FormBuilder, private router: Router) { }
  tipovi: string[] = ["Admin", "Student", "Penzioner", "Obican"];
  tip: string;
  ngOnInit() {
  }

  onSubmit(){
    let regModel: RegUser = this.registacijaForm.value;
    this.http.reg(regModel).subscribe(
      
    )
    
    this.router.navigate(["/login"])
    //form.reset();
  }



}
