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
  cenaKarte: number = 15;
  tip: string;
  tipPutnika: string;
  cena1: number;
  vaziDo1 : string;
  user: string;
  mejl : string;
  ngOnInit() {
  }


  KupiKartu(){
    
      this.http.GetKupiKartu(this.tip, "prazno").subscribe((vaziDo)=>
      {
        this.vaziDo1 = vaziDo;
        alert(vaziDo);
        err => console.log(err);
        
      });

  }
}
