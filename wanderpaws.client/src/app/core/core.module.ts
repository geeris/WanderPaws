import { ErrorHandler, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { UnauthorizedInterceptor } from './interceptors/unauthorized.interceptor';
import { GlobalErrorHandler } from './models/globalErrorHandler';
import { ServerErrorInterceptor } from './interceptors/error-handling.interceptor';
import { MessageService } from 'primeng/api';
import { NotificationService } from './services/notification.service';
import { NavComponent } from './components/nav/nav.component';
import { LayoutComponent } from './components/layout/layout.component';
import { RouterModule } from '@angular/router';
import { MenubarModule } from 'primeng/menubar';
import { AvatarModule } from 'primeng/avatar'

import { DividerModule } from 'primeng/divider';
import { SharedModule } from "../shared/shared.module";

@NgModule({
  declarations: [FooterComponent, HeaderComponent, NavComponent, LayoutComponent],
  exports: [FooterComponent, HeaderComponent],
  imports: [
    CommonModule,
    MenubarModule,
    AvatarModule,
    RouterModule,
    SharedModule,
    DividerModule,
    SharedModule
],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: UnauthorizedInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ServerErrorInterceptor,
      multi: true
    },
    {
      provide: ErrorHandler,
      useClass: GlobalErrorHandler
    },
    MessageService,
    NotificationService
  ]
})
export class CoreModule {
  private static instance: boolean = false;

  constructor() {
    if (CoreModule.instance) {
      throw new Error('CoreModule is already loaded. Import it in AppModule only.');
    }
    CoreModule.instance = true;
  }
}
