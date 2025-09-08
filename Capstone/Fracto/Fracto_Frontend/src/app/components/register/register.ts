import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  standalone: false,
  templateUrl: './register.html',
  styleUrls: ['./register.css']
})
export class Register {
  username: string = '';
  email: string = '';
  password: string = '';
  role: string = 'User'; // Default role
  errorMessage: string = '';
  successMessage: string = '';
  

  constructor(private authService: AuthService, private router: Router) {}

  register() {
    if (!this.username || !this.password) {
      this.errorMessage = 'Please fill all fields';
      return;
    }

    this.authService.register(this.username, this.email, this.password, this.role).subscribe({
      next: () => {
        this.successMessage = 'Registration successful! Redirecting to login...';
        setTimeout(() => {
          this.router.navigate(['/login']);
        }, 2000);
      },
      error: () => {
        this.errorMessage = 'Registration failed. Try again.';
      }
    });
  }
}