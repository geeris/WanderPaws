import { NgModule } from '@angular/core';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { CommonModule } from '@angular/common';
import { DashboardOverviewComponent } from './pages/dashboard-overview/dashboard-overview/dashboard-overview.component';

@NgModule({
  declarations: [
    DashboardOverviewComponent
  ],
  imports: [
    DashboardRoutingModule,
    CommonModule,
  ]
})
export class DashboardModule { }
