import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/services/auth.service';
import { NgForm, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { CenovnikBindingModel } from 'src/app/osoba';
@Component({
  selector: 'app-cenovnik-dodaj',
  templateUrl: './cenovnik-dodaj.component.html',
  styleUrls: ['./cenovnik-dodaj.component.css']
})
export class CenovnikDodajComponent implements OnInit {

  constructor(private http: AuthHttpService,  private fb: FormBuilder) { }
 odgovor : string
  cenovnikGroup = this.fb.group({
 
   
    mesecna :  ['', Validators.required],
    godisnja :  ['', Validators.required],
    vremenska :  ['', Validators.required],
    dnevna :  ['', Validators.required],
    vaziDo :  ['', Validators.required],
    vaziOd :  ['', Validators.required],
    popustPenzija :  ['', Validators.required],
    popustStudent :  ['', Validators.required],
    id :  ['', Validators.required]
    });
  ngOnInit() {
  }
  NapraviCenovnik(){
    let cenovnik: CenovnikBindingModel = this.cenovnikGroup.value;
    this.http.DodajCenovnik(cenovnik).subscribe(
  
     
     
    );

  }
}
