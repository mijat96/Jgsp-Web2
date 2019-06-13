import { Injectable } from '@angular/core';
import {
  CanActivate, Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  CanActivateChild,
} from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthGuardControlor implements CanActivate, CanActivateChild {
  constructor(private router: Router) { }
  role : any;
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {    
    let jwtData = localStorage.jwt.split('.')[1]
    let decodedJwtJsonData = window.atob(jwtData)
    let decodedJwtData = JSON.parse(decodedJwtJsonData)


      this.role = decodedJwtData.nameid

    if (this.role === 'Kontrolor') {
      return true;
    }
    // not logged in so redirect to login page
    else {
      console.error("Can't access, not admin");
      this.router.navigate(['/home']);
      return false;
    }
  }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    return this.canActivate(route, state);
  }

}
