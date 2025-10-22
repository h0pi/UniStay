import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LoginComponent} from './modules/auth/login/login';
import {Logout} from './modules/auth/logout/logout';

const routes: Routes = [
  { path:'login',component:LoginComponent},
  {path:'logout',component:Logout},
  // 🔐 AUTH MODULE — login i logout funkcionalnosti
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth-module').then(m => m.AuthModule)
  },

  // 🌍 Public module (početna, kontakt, o nama itd.)
  {
    path: '',
    loadChildren: () => import('./modules/public/public-module').then(m => m.PublicModule)
  },

  // 🎓 Student (dashboard, announcements, applications, profile...)
  {
    path: 'student',
    loadChildren: () => import('./modules/student/student-module').then(m => m.StudentModule)
  },

  // 🧑‍💼 Employee (manage rooms, faults, inventory, etc.)
  {
    path: 'employee',
    loadChildren: () => import('./modules/employee/employee-module').then(m => m.EmployeeModule)
  },

  // 🧑‍💻 Administrator (manage users, announcements, reports...)
  {
    path: 'admin',
    loadChildren: () => import('./modules/administrator/administrator-module').then(m => m.AdministratorModule)
  },

  // 🚫 Wildcard — ako neko unese pogrešan URL
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
