import { NgModule } from '@angular/core';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { CommonModule, formatCurrency } from '@angular/common';
import { DashboardOverviewComponent } from './pages/dashboard-overview/dashboard-overview/dashboard-overview.component';

import { SelectButtonModule } from 'primeng/selectbutton';
import { FormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';  // Correct module for p-dropdown

@NgModule({
  declarations: [
    DashboardOverviewComponent,
  ],
  imports: [
    DashboardRoutingModule,
    CommonModule,

    SelectButtonModule, FormsModule,
    DropdownModule,
  ]
})
export class DashboardModule { }
