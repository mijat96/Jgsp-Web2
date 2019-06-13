import { Component, OnInit } from '@angular/core';
import { NgForm, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Stanica } from 'src/app/osoba';
import { AuthHttpService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-obrisi-stanica',
  templateUrl: './obrisi-stanica.component.html',
  styleUrls: ['./obrisi-stanica.component.css']
})
export class ObrisiStanicaComponent implements OnInit {
  staniceZaView : number[];
  selectedLine : string;
  slectedStanica : string;
  odgovor : string;
  constructor(private http: AuthHttpService, private fb: FormBuilder) { }

  ngOnInit() {
    this.http.GetStanice().subscribe((stanicesa)=>{
      this.staniceZaView = stanicesa;
      err => console.log(err);
    });
  }
  izbrisiS(){
    this.http.DeleteStanica(this.slectedStanica).subscribe();
  }
}
