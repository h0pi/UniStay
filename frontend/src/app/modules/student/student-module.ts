import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Home } from './home/home';
import { Applications } from './applications/applications';
import { Notifications } from './notifications/notifications';
import { Profile } from './profile/profile';
import { HallReservations } from './hall-reservations/hall-reservations';



@NgModule({
  declarations: [
    Home,
    Applications,
    Notifications,
    Profile,
    HallReservations
  ],
  imports: [
    CommonModule
  ]
})
export class StudentModule { }
