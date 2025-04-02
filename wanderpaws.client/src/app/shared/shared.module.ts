import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastComponent } from './components/toast/toast.component';
import { ToastModule } from 'primeng/toast';
import { FooterLinkListComponent } from './components/footer-link-list/footer-link-list.component';

@NgModule({
  declarations: [
    ToastComponent,
    FooterLinkListComponent
  ],
  imports: [
    CommonModule,
    ToastModule
  ],
  exports: [
    ToastModule,
    ToastComponent,
    FooterLinkListComponent,
  ]
})
export class SharedModule { }
