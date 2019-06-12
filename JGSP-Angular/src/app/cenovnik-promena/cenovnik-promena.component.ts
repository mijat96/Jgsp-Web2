import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/services/auth.service';
import { NgForm, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-cenovnik-promena',
  templateUrl: './cenovnik-promena.component.html',
  styleUrls: ['./cenovnik-promena.component.css']
})
export class CenovnikPromenaComponent implements OnInit {
  tipovi: string[] = ["Dnevna", "Mesecna", "Godisnja", "Vremenska"];
  tipoviPutnika: string[] = ["Student", "Penzioner", "Obican"];
  tip: string;
  tipPutnika: string;
  cena1: number;

  cenaGroup = this.fb.group({
  
    cenaNova :  ['', Validators.required],
    });
  constructor(private http: AuthHttpService,  private fb: FormBuilder) { }

  ngOnInit() {
  }
  PromenaCene(){
    this.http.GetPromenaCene(this.tip, this.tipPutnika, this.cenaGroup.get('cenaNova').value).subscribe((cena)=>{
      this.cena1 = cena;
     
      err => console.log(err);
    });
  }
}
