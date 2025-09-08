import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:5001/api/auth'; // backend AuthController

  constructor(private http: HttpClient) {}

  login(credentials: { email: string; password: string }): Observable<boolean> {
    return this.http.post<any>(`${this.apiUrl}/login`, credentials).pipe(
      map(response => {
        if (response && response.token) {
          localStorage.setItem('token', response.token);
          return true;
        }
        return false;
      })
    );
  }

  register(username: string, email: string, password: string, role: string): Observable<any> {
    const user = { username, email, password, role };
    return this.http.post<any>(`${this.apiUrl}/register`, user);
  }
  

  logout(): void {
    localStorage.removeItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  getUserRole(): string | null {
    const token = this.getToken();
    if (!token) return null;

    const payload = JSON.parse(atob(token.split('.')[1]));
    return payload['role'] || null;
  }
  getRoleFromToken(): string | null {
    const token = this.getToken();
    if (!token) return null;

    const payload = JSON.parse(atob(token.split('.')[1]));
    return payload['role'] || null;
  }
}