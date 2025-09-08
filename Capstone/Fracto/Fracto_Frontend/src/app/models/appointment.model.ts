import { Injectable} from'@angular/core';

@Injectable({ providedIn: 'root' })
export class Appointment {
  appointmentId: number = 0;
  userId: number = 0;
  doctorId: number = 0;
  appointmentDate: string = '';  
  status: string = '';
}
