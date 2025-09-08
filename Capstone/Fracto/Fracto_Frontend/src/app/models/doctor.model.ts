import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class Doctor {
  doctorId: number = 0;
  name: string = '';
  specializationId: number = 0;
}