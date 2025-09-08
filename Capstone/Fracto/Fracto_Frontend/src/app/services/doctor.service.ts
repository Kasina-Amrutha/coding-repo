import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class DoctorService {
  private apiUrl = 'https://localhost:4000/api/doctors';

  constructor(private http: HttpClient) {}

  getDoctors(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getDoctor(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  addDoctor(doctor: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, doctor);
  }

  updateDoctor(id: number, doctor: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, doctor);
  }

  deleteDoctor(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
}