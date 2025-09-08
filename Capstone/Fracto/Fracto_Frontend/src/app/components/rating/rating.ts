import { Component } from '@angular/core';
import { RatingService } from '../../services/rating.service';

@Component({
  selector: 'app-rating',
  standalone: false,
  templateUrl: './rating.html',
  styleUrls: ['./rating.css']
})
export class Rating {
  doctorId: number = 0;
  ratingValue: number = 0;
  user: any;

  constructor(private ratingService: RatingService) {
    this.user = JSON.parse(localStorage.getItem('user') || '{}');
  }

  submitRating() {
    const rating = {
      doctorId: this.doctorId,
      userId: this.user.userId,
      ratingValue: this.ratingValue
    };

    this.ratingService.addRating(rating).subscribe(() => {
      alert('Rating submitted successfully!');
    });
  }
}