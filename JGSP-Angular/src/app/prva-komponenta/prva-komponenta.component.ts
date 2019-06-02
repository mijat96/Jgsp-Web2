import { Component, OnInit, Input } from '@angular/core';
import { HttpService } from 'src/app/services/http.service';
import { Osoba } from 'src/app/osoba';
import { ValuesHttpService } from 'src/app/services/values.http.service';
import { AuthHttpService } from 'src/app/services/auth.service'

@Component({
  selector: 'app-prva-komponenta',
  templateUrl: './prva-komponenta.component.html',
  styleUrls: ['./prva-komponenta.component.css'],
  providers: [ValuesHttpService, AuthHttpService]
  //providers: [] dodavanje provajdera samo za ovu komponentu
})
export class PrvaKomponentaComponent implements OnInit {

  name: string
  clicks: number
  unos: string
  values: string[]

  @Input()  //prosledjivanje iz roditeljske komponente komponenti ispod
  osoba: Osoba

  constructor(private http: ValuesHttpService, private auth: AuthHttpService) { }  //injektuj mi httpService i smesti mi u polje http, moze i gore polje da se napravi

  ngOnInit() {
    //this.name = "Janicanin"
    //this.name = this.http.getName();
    this.http.getAll().subscribe((values) => this.values = values, err => console.log(err));
    //this.http.getName().subscribe((name) => this.name = name);  //strelica umesto metode razlika je u clouser-u
    this.clicks = 0;
    this.auth.logIn("admin@yahoo.com", "Admin123!");
  }

  clickCounter(){
    this.clicks++;
  }
  
}
