import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardOverviewComponent } from './pages/dashboard-overview/dashboard-overview/dashboard-overview.component';
import { LayoutComponent } from '../../core/components/layout/layout.component';

// const routes: Routes = [
//     { path: '', component: DashboardOverviewComponent },
// ];

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: '',
        component: DashboardOverviewComponent,
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
