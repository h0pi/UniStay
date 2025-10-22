import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdministratorDashboard } from './administrator-dashboard/administrator-dashboard';
import { ManageRooms} from './manage-rooms/manage-rooms';

const routes: Routes = [
  { path: '', component: AdministratorDashboard },
  { path: 'manage-rooms', component: ManageRooms }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdministratorRoutingModule { }
