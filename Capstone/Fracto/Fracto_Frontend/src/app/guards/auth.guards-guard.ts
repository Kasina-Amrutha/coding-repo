import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    // 1. Check if user is logged in
    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/login']);
      return false;
    }

    // 2. Get required role from route data
    const requiredRole = route.data['role'];

    // 3. Get current user's role from AuthService (or localStorage, etc.)
    const userRole = this.authService.getUserRole();

    // 4. Match roles
    if (requiredRole && requiredRole !== userRole) {
      this.router.navigate(['/unauthorized']);
      return false;
    }

    return true;
  }
}