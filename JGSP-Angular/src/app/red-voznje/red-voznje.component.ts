import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/services/auth.service';
import { error } from 'util';

@Component({
  selector: 'app-red-voznje',
  templateUrl: './red-voznje.component.html',
  styleUrls: ['./red-voznje.component.css']
})
export class RedVoznjeComponent implements OnInit {

  polasci: string;
  constructor(private http: AuthHttpService) { }

  ngOnInit() {
  }

  OnGetPolasci(){
      this.http.GetPolasci(1).subscribe(
        error => console.log(error),
        data => {
              this.polasci = data;
        }
      ) 
  }
  
}
