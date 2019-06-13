import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/services/auth.service';
import { NgForm, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-obrisi-red-voznje',
  templateUrl: './obrisi-red-voznje.component.html',
  styleUrls: ['./obrisi-red-voznje.component.css']
})
export class ObrisiRedVoznjeComponent implements OnInit {
  constructor(private http: AuthHttpService,  private fb: FormBuilder) { }
  RedGroup = this.fb.group({
 
   
  
    id :  ['', Validators.required]
    });
  ngOnInit() {
  }
  brisi (){
    this.http.obrisiRedVoznje( this.RedGroup.get('id').value).subscribe();
  }
}
