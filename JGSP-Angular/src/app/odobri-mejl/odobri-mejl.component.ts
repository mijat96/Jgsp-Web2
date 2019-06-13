import { Component, OnInit } from '@angular/core';
import { NgForm, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Stanica } from 'src/app/osoba';
import { AuthHttpService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-odobri-mejl',
  templateUrl: './odobri-mejl.component.html',
  styleUrls: ['./odobri-mejl.component.css']
})
export class OdobriMejlComponent implements OnInit {
  mejloviZaView : number[];
  selectedLine : string;
  selectedMejl : string;
  odgovor : string;
  constructor(private http: AuthHttpService, private fb: FormBuilder) { }

  ngOnInit() {
    this.http.GetMejlovi().subscribe((stanicesa)=>{
      this.mejloviZaView = stanicesa;
      err => console.log(err);
    });
  }
  odobri(){
    this.http.Odobri(this.selectedMejl).subscribe((stanicesa)=>{
      this.odgovor = stanicesa;
      err => console.log(err);
    });
  }
}
