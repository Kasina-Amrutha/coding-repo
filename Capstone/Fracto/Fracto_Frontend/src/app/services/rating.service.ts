import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class RatingService {
  private apiUrl = 'https://localhost:4000/api/ratings';

  constructor(private http: HttpClient) {}

  getRatings(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getRating(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  addRating(rating: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, rating);
  }

  updateRating(id: number, rating: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, rating);
  }

  deleteRating(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
}