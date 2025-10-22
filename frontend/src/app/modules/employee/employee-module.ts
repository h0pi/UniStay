import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FaultReports } from './fault-reports/fault-reports';
import { Dashboard } from './dashboard/dashboard';




@NgModule({
  declarations: [
    Dashboard,
    FaultReports
  ],
  imports: [
    CommonModule
  ]
})
export class EmployeeModule { }
