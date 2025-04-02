import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { AuthModule } from './features/auth/auth.module';
import { DashboardComponent } from './features/dashboard/components/dashboard/dashboard.component';
import { SharedModule } from './shared/shared.module';
import { CategoriesModule } from './features/categories/categories.module';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    // CategoriesModule ??
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, BrowserAnimationsModule,
    
    CoreModule,
    AuthModule,
    CategoriesModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
