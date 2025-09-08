import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class Admin {
  adminId: number = 0;
  username: string = '';
  email: string = '';
  password?: string;  
  role: string = 'Admin'; 
  token?: string;
}