import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../src/app/core/guards/auth.guard'

const routes: Routes = [
  {
    path: '',
    redirectTo: 'auth',
    pathMatch: 'full'
  },
  {
    path: 'auth',
    loadChildren: () => import('./features/auth/auth.module').then(m => m.AuthModule) // lazy loading module // we will only load this code when we run this patch
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./features/dashboard/dashboard.module').then(m => m.DashboardModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'categories',
    loadChildren: () => import('./features/categories/categories.module').then(m => m.CategoriesModule),
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    redirectTo: 'auth'
  } // Redirect unknown routes to 'auth'
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }




// { path: '', component: LoginFormComponent }, // change this to 'login' later
//   { path: 'register', component: RegisterFormComponent },
//   { path: 'account',
//     loadChildren: () => import('./features/auth/auth.module').then(m => m.AuthModule) // lazy loading module // we will only load this code when we run this patch
//    },
//   // { path: 'app', component: HomeComponent, canMatch: [authGuard] },
//   { path: '**', redirectTo: '' },