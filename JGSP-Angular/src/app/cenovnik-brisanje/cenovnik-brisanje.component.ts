import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/services/auth.service';
import { NgForm, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-cenovnik-brisanje',
  templateUrl: './cenovnik-brisanje.component.html',
  styleUrls: ['./cenovnik-brisanje.component.css']
})

export class CenovnikBrisanjeComponent implements OnInit {

  constructor(private http: AuthHttpService,  private fb: FormBuilder) { }
  cenovnikGroup = this.fb.group({
 
   
  
    id :  ['', Validators.required]
    });
  ngOnInit() {
  }
brisi (){
  this.http.obrisiCenovnik( this.cenovnikGroup.get('id').value).subscribe();
}
}
