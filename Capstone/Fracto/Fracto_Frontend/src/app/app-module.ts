import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Login } from './components/login/login';
import { Register } from './components/register/register';
import { DoctorList } from './components/doctor-list/doctor-list';
import { Appointment } from './components/appointment/appointment';
import { Rating } from './components/rating/rating';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { Unauthorized } from './components/unauthorized/unauthorized';

@NgModule({
  declarations: [
    App,
    Login,
    Register,
    DoctorList,
    Appointment,
    Rating,
    Unauthorized
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [ { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
  bootstrap: [App]
})
export class AppModule { }