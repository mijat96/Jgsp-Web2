import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/services/auth.service';
@Component({
  selector: 'app-cenovnik',
  templateUrl: './cenovnik.component.html',
  styleUrls: ['./cenovnik.component.css']
})
export class CenovnikComponent implements OnInit {
  tipovi: string[] = ["Dnevna", "Mesecna", "Godisnja", "Vremenska"];
  tipoviPutnika: string[] = ["Student", "Penzioner", "Obican"];
  tip: string;
  tipPutnika: string;
  cena1: number;
  constructor(private http: AuthHttpService) { }

  ngOnInit() {
  }
  CenaKarte(){
    this.http.GetCenaKarte(this.tip, this.tipPutnika).subscribe((cena)=>{
      this.cena1 = cena;
     
      err => console.log(err);
    });
  }
}
