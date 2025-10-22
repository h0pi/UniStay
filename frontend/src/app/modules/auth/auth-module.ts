import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login';
import { Logout } from './logout/logout';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    LoginComponent,
    Logout
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
  ]
})
export class AuthModule { }
