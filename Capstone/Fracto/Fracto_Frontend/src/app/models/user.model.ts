import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })

export class User {
  userId: number = 0;
  username: string = '';
  email: string = '';
  password?: string;  // optional, usually only used during registration/login

  
  }
    
