import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/services/auth.service';
import { NgForm, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-kontrolor',
  templateUrl: './kontrolor.component.html',
  styleUrls: ['./kontrolor.component.css']
})
export class KontrolorComponent implements OnInit {

  Odgovor : string;
  nesto : string
  kontrolorGroup = this.fb.group({
  
  IdKorisnika :  ['', Validators.required],
  });
  constructor(private http: AuthHttpService, private fb: FormBuilder,) { }

  ngOnInit() {
  }
 
  ProveriKartu(){
  

    this.http.GetProveriKartu(this.kontrolorGroup.get('IdKorisnika').value).subscribe((Odgovor)=>
    {
      this.Odgovor = Odgovor;
      err => console.log(err);
    });

}
}
