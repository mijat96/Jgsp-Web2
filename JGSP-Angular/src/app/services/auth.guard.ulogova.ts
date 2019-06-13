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
export class AuthGuardUlogovan implements CanActivate, CanActivateChild {
  constructor(private router: Router) { }
  role : any;
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {    
    
    

    if (!(localStorage.getItem('jwt') != "null" && localStorage.getItem('jwt') != "undefined" && localStorage.getItem('jwt') != "")) {
      return true;
    }
    // not logged in so redirect to login page
    else {
      console.error("Can't access, not login");
      this.router.navigate(['/home']);
      return false;
    }
  }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    return this.canActivate(route, state);
  }

}
