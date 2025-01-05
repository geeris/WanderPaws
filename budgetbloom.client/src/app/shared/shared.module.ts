import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastComponent } from './components/toast/toast.component';
import { ToastModule } from 'primeng/toast';

@NgModule({
  declarations: [
    ToastComponent
  ],
  imports: [
    CommonModule,
    ToastModule
  ],
  exports: [
    ToastModule,
    ToastComponent
  ]
})
export class SharedModule { }
