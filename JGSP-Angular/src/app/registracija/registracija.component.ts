import { Component, OnInit } from '@angular/core';
import { RegUser, RegUserImg } from 'src/app/osoba';
import { NgForm } from '@angular/forms';
import { AuthHttpService } from 'src/app/services/auth.service';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent implements OnInit {
  
  registacijaForm = this.fb.group({
    name: ['', Validators.required],
    surname: ['', Validators.required],
    username: ['', Validators.required],
    password: ['', Validators.required],
    confirmPassword: ['', Validators.required],
    email: ['', Validators.email],
    date: ['', Validators.required],
    tip: ['', Validators.required]
  });

  constructor(private http: AuthHttpService, private fb: FormBuilder, private router: Router) { }
  tipovi: string[] = [ "Obican", "Student", "Penzioner" ];
  tip: string;
  slika : File = null;

  ngOnInit() {

    
  }

  onSubmit(){
    let regModel: RegUser = this.registacijaForm.value;
    this.http.reg(regModel).subscribe( x =>{
      if(this.slika != null){
        const fData : FormData = new FormData();
        fData.append('Img', this.slika, this.slika.name);
        console.log(fData)
        this.http.regImg(fData, regModel.username).subscribe();    
      }
      else{
        alert("Uspesno ste se registrovali");
        this.router.navigate(["/login"])
      }

    }
      
    );
   
    //form.reset();
  }

  DaLiJeStudentILIPenzioner(){
    if (this.registacijaForm.value.tip == "Student" || this.registacijaForm.value.tip == "Penzioner")
      return true;
    else
      return false;
  }

  onFileSelected(event){
    this.slika = <File>event.target.files[0];
    console.log(this.slika);
  }

  sendWithImg(){
    //poslati post ili get metodom 
    // const fData : FormData = new FormData();
    // fData.append('Img', this.slika, this.slika.name);
    // console.log(fData)
    // this.http.regImg(fData).subscribe();
  }

}
