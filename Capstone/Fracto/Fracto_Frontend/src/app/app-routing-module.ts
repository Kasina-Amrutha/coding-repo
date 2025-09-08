import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Login } from './components/login/login';
import { Register } from './components/register/register';
import { DoctorList } from './components/doctor-list/doctor-list';
import { Appointment } from './components/appointment/appointment';
import { Rating } from './components/rating/rating';
import { AuthGuard } from './guards/auth.guards-guard';
import { Unauthorized } from './components/unauthorized/unauthorized';
import { User } from './models/user.model';


const routes: Routes = [
  { path: 'login', component: Login },
  { path: 'register', component: Register },
  { path: 'doctors', component: DoctorList },
  { path: 'appointments', component: Appointment },
  { path: 'ratings', component: Rating },
  { path: 'unauthorized', component: Unauthorized },
 {
    path: 'user',
    loadChildren: () => import('./models/user.model').then(m => m.User),
    canActivate: [AuthGuard],
    data: { role: 'User' }
  },
   {
    path: 'admin',
    loadChildren: () => import('./models/admin.model').then(m => m.Admin),
    canActivate: [AuthGuard],
    data: { role: 'Admin' }
  },
  {
    path: 'rating',
    loadChildren: () => import('./models/rating.model').then(m => m.Rating),
    canActivate: [AuthGuard],
    data: { role: 'User' }
  },
  {
    path: 'appointment',
    loadChildren: () => import('./models/appointment.model').then(m => m.Appointment),
    canActivate: [AuthGuard],
    data: { role: 'User' }
  },
  {
    path: 'doctor',
    loadChildren: () => import('./models/doctor.model').then(m => m.Doctor),
    canActivate: [AuthGuard],
    data: { role: 'User' }
  },
  

  { path: '', redirectTo: '/login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }