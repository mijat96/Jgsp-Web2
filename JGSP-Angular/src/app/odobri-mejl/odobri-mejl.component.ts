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
  slika: string;

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

  DobaviSliku(){
    //potrebno je poslati id korisnika i primiti sa servera sliku ako postoji
    this.http.GetSlika(this.selectedMejl).subscribe((slika) =>
      {
        this.slika = 'data:image/jpeg;base64,' + slika;
      }, err =>{
        if(err.status === 400) {
          this.slika = null;
          alert("Korisnik nije dostavio sliku!");
        }
      }
    );
  }
}
