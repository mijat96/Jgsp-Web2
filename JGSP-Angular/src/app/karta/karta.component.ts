import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-karta',
  templateUrl: './karta.component.html',
  styleUrls: ['./karta.component.css']
})
export class KartaComponent implements OnInit {

  constructor(private http: AuthHttpService) { }
  tipovi: string[] = ["dnevna", "mesecna", "godisnja", "vremenska"];
  tip: string;
  cena: number;

  ngOnInit() {
  }

  CenaKarte(){
    this.http.GetCenaKarte(this.tip).subscribe((cena)=>{
      this.cena = cena;
      err => console.log(err);
    });
  }
}
