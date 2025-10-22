import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManageRooms } from './manage-rooms/manage-rooms';
import { AdministratorDashboard } from './pages/administrator-dashboard/administrator-dashboard';
import { Reports } from './pages/reports/reports';
import { Settings } from './pages/settings/settings';



@NgModule({
  declarations: [
    AdministratorDashboard,
    ManageRooms,
    Reports,
    Settings
  ],
  imports: [
    CommonModule
  ]
})
export class AdministratorModule { }
