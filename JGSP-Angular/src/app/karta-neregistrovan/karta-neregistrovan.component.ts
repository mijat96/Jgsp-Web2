import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/services/auth.service';
import { NgForm, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
// import email from 'node_modules/emailjs/email.js';
// var server = require('././node_modules/emailjs/smtp/client');
// //var email   = require('emailjs/email');

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

    KupiKartuNeregistrovan(){
    
    this.http.GetKupiKartu(this.tip, this.regGroup.get('mejl').value).subscribe((vaziDo)=>
    {
      this.vaziDo1 = vaziDo;
      err => console.log(err);
    });


    
    // var server = this.e.server.connect({
    //   user:    "marko",
    //   password:"mijat",
    //   host:    "smtp.marko.mijatovic.1996@gmail.com",
    //   ssl:     true
    // });
    // server.send({
    //   text:    "i hope this works",
    //   from:    "you <marko.mijatovic.1996@gmail.com>",
    //   to:      this.regGroup.get('mejl').value,
    //   cc:      "else <else@your-email.com>",
    //   subject: "testing emailjs"
    // });
}

  
ngOnInit() {
  }

}
