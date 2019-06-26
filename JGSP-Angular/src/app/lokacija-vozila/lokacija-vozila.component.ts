import { Component, OnInit, Input } from '@angular/core';
import { GeoLocation } from '../map/map-model/geolocation';
import { MarkerInfo } from '../map/map-model/marker-info.model';
import { AuthHttpService } from '../services/auth.service';
import { Polyline } from '../map/map-model/polyline';

@Component({
  selector: 'app-lokacija-vozila',
  templateUrl: './lokacija-vozila.component.html',
  styleUrls: ['./lokacija-vozila.component.css'],
  styles: ['agm-map {height: 500px; width: 700px;}']
})
export class LokacijaVozilaComponent implements OnInit {

  @Input()
  linija: string;
  x: number;
  y: number;
  mrakerInfoMoj: MarkerInfo;
  markeri: MarkerInfo[];
  markerInfo: MarkerInfo;
  public polyline: Polyline;
  public zoom: number;
  public polylineMoje: Polyline;
  public nizKordinata: Cord[];

  ngOnInit() {
    this.mrakerInfoMoj = new MarkerInfo(new GeoLocation(this.x, this.y), 
      "assets/busicon.png",
      "Stanica" , "" , "http://ftn.uns.ac.rs/691618389/fakultet-tehnickih-nauka"); 
    this.markerInfo = new MarkerInfo(new GeoLocation(45.242268, 19.842954), 
       "assets/ftn.png",
       "Jugodrvo" , "" , "http://ftn.uns.ac.rs/691618389/fakultet-tehnickih-nauka");

    this.polyline = new Polyline([], 'blue', { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}});
    this.polylineMoje = new Polyline([], 'blue', { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}});
  }

  constructor(private http: AuthHttpService){
  }

  placeMarker($event){
    this.polyline.addLocation(new GeoLocation($event.coords.lat, $event.coords.lng))
    //console.log(this.polyline)
  }

  placeMarkerLinije(x, y){
    this.polylineMoje.addLocation(new GeoLocation(x, y))
    
    console.log(this.polylineMoje)
  }

  ShowStanica(idStanice: string){
    idStanice = this.linija;
    this.http.GetStanicaCord(idStanice).subscribe((raspored1)=>{
      this.nizKordinata = raspored1;
      err => console.log(err);
    }
    );
    
    //for(var i = 0; i <= this.nizKordinata.length; i++){
      // var g = new GeoLocation(0,0);
      // g.latitude = this.nizKordinata[i][0];
      // g.longitude = this.nizKordinata[i][1];
      //console.log(this.nizKordinata)
      //var g = new Cord();
      //g = this.nizKordinata[i];
      console.log(this.nizKordinata);
      this.nizKordinata.forEach(station => {
        let stationToPush: Cord = {
          x: station.x,
          y: station.y,
          name: station.name,
        };
        this.placeMarkerLinije(station.y, station.x);
    });

    
  }

  HideStanica(){
    this.nizKordinata = [];
    // this.mrakerInfoMoj = new MarkerInfo(new GeoLocation(45.242268, 19.842954),
    //   "assets/ftn.png",
    //   "Jugodrvo", "", "http://ftn.uns.ac.rs/691618389/fakultet-tehnickih-nauka");
    this.polyline = new Polyline([], 'blue', null);
    this.polylineMoje = new Polyline([], 'blue', null);
    //this.placeMarkerLinije(45.242268, 19.842954); 
  }
}

class Cord{
  x: number;
  y: number;
  name: string;
}
