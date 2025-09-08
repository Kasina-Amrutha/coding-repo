import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})
export class Login {
  username: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    if (!this.username || !this.password) {
      this.errorMessage = 'Please enter username and password';
      return;
    }

    this.authService.login({ email: this.username, password: this.password }).subscribe({
      next: (response: any) => {
        // Save token to localStorage
        localStorage.setItem('token', response.token);

        // Decode role (AuthService already extracts role claim)
        const role = this.authService.getRoleFromToken();
        if (role === 'Admin') {
          this.router.navigate(['/admin']);
        } else {
          this.router.navigate(['/user']);
        }
      },
      error: () => {
        this.errorMessage = 'Invalid username or password';
      }
    });
  }
}