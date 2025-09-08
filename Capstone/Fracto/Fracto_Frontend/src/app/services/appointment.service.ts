import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AppointmentService {
  private apiUrl = 'https://localhost:4000/api/appointments';

  constructor(private http: HttpClient) {}

  getAppointments(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getAppointment(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  createAppointment(appointment: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, appointment);
  }

  updateAppointment(id: number, appointment: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, appointment);
  }

  deleteAppointment(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
}