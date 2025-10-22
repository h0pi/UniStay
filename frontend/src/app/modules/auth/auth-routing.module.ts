import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login';
import { Logout } from './logout/logout';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: Logout }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
