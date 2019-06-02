import { Component } from '@angular/core';
import { Osoba } from 'src/app/osoba';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'NewProject';
  peraOsoba: Osoba = {name:"Pera", surname:"Varga"}
}
