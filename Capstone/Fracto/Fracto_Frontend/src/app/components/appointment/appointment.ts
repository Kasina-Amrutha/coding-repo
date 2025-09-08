import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppointmentService } from '../../services/appointment.service';

@Component({
  selector: 'app-appointment',
  standalone: false,
  templateUrl: './appointment.html',
  styleUrls: ['./appointment.css']
})
export class Appointment implements OnInit {
  doctorId!: number;
  appointmentDate: string = '';
  timeSlot: string = '';
  user: any;

  constructor(private route: ActivatedRoute, private appointmentService: AppointmentService) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.doctorId = params['doctorId'];
    });
    this.user = JSON.parse(localStorage.getItem('user') || '{}');
  }

  bookAppointment() {
    const appointment = {
      userId: this.user.userId,
      doctorId: this.doctorId,
      appointmentDate: this.appointmentDate,
      timeSlot: this.timeSlot,
      status: 'Pending'
    };

    this.appointmentService.createAppointment(appointment).subscribe(() => {
      alert('Appointment booked successfully!');
    });
  }
}