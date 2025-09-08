import { Component, OnInit } from '@angular/core';
import { DoctorService } from '../../services/doctor.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-doctor-list',
  standalone: false,
  templateUrl: './doctor-list.html',
  styleUrls: ['./doctor-list.css']
})
export class DoctorList implements OnInit {
  doctors: any[] = [];
  filteredDoctors: any[] = [];
  city: string = '';
  specialization: string = '';
  rating: number = 0;

  constructor(private doctorService: DoctorService, private router: Router) {}

  ngOnInit(): void {
    this.doctorService.getDoctors().subscribe(data => {
      this.doctors = data;
      this.filteredDoctors = data;
    });
  }

  filterDoctors() {
    this.filteredDoctors = this.doctors.filter(doc =>
      (!this.city || doc.city.toLowerCase().includes(this.city.toLowerCase())) &&
      (!this.specialization || doc.specializationId == this.specialization) &&
      (!this.rating || doc.rating >= this.rating)
    );
  }

  bookAppointment(doctor: any) {
    this.router.navigate(['/appointments'], { queryParams: { doctorId: doctor.doctorId } });
  }
}