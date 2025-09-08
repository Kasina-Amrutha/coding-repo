import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class Rating {
  ratingId: number = 0;
  userId: number = 0;
  doctorId: number = 0;
  score: number = 0;  
  comment?: string = ''; 
}
