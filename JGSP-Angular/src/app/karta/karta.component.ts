import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/services/auth.service';
//import { user } from 'src/app/services/auth.service';

@Component({
  selector: 'app-karta',
  templateUrl: './karta.component.html',
  styleUrls: ['./karta.component.css']
})
export class KartaComponent implements OnInit {

  constructor(private http: AuthHttpService) { }
  tipovi: string[] = ["Dnevna", "Mesecna", "Godisnja", "Vremenska"];
  tipoviPutnika: string[] = ["Djacka", "Penzionerska", "Regularna"];
  tip: string;
  tipPutnika: string;
  cena1: number;
  vaziDo1 : string;
  user: string;
  ngOnInit() {
  }

  CenaKarte(){
    this.http.GetCenaKarte(this.tip, this.tipPutnika).subscribe((cena)=>{
      this.cena1 = cena;
      err => console.log(err);
    });
  }
  KupiKartu(){
    
      this.http.GetKupiKartu(this.tip).subscribe((vaziDo)=>
      {
        this.vaziDo1 = vaziDo;
        err => console.log(err);
      });

  }
}
