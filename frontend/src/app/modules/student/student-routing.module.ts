import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Applications } from './applications/applications';
import { HallReservations } from './hall-reservations/hall-reservations';
import { Home } from './home/home';
import { Notifications } from './notifications/notifications';
import { Profile } from './profile/profile';

const routes: Routes = [
  { path: '', component: Home },
  { path: 'applications', component: Applications },
  { path: 'hall-reservations', component: HallReservations },
  { path: 'home', component: Home },
  { path: 'notifications', component: Notifications },
  { path: 'profile', component: Profile },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentRoutingModule { }
