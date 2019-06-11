import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/services/auth.service';
import { NgForm, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-karta-neregistrovan',
  templateUrl: './karta-neregistrovan.component.html',
  styleUrls: ['./karta-neregistrovan.component.css']
})
export class KartaNeregistrovanComponent implements OnInit {

  constructor(private http: AuthHttpService, private fb: FormBuilder) { }
  tipovi: string[] = ["Dnevna", "Mesecna", "Godisnja", "Vremenska"];

  tip: string;
  tipPutnika: string;
  cena1: number;
  vaziDo1 : string;
  user: string;
  
  regGroup = this.fb.group({
  
    mejl :  ['', Validators.required],
    });

  KupiKartu(){
    
    this.http.GetKupiKartu(this.tip, this.regGroup.get('mejl').value).subscribe((vaziDo)=>
    {
      this.vaziDo1 = vaziDo;
      err => console.log(err);
    });

}
  ngOnInit() {
  }

}
