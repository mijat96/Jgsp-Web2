import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/services/auth.service';
import { NgForm, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-dodaj-liniju',
  templateUrl: './dodaj-liniju.component.html',
  styleUrls: ['./dodaj-liniju.component.css']
})
export class DodajLinijuComponent implements OnInit {

  constructor(private http: AuthHttpService,  private fb: FormBuilder) { }
  LinijaGroup = this.fb.group({
 
   
  
    broj :  ['', Validators.required]
    });
  ngOnInit() {
  }
  dodaj (){
    this.http.DodajLiniju( this.LinijaGroup.get('broj').value).subscribe();
  }
}
