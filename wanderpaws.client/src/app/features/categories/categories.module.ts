import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoriesOverviewComponent } from './pages/categories-overview/categories-overview.component';
import { CategoriesRoutingModule } from './categories-routing.module';
import { MessageModule } from 'primeng/message';
import { NgIf } from '@angular/common';
import { BadgeModule } from 'primeng/badge';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { TagModule } from 'primeng/tag';
import { ToolbarModule } from 'primeng/toolbar';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';

// import { IconField } from 'primeng/iconfield'
// import { InputIcon } from 'primeng/inputicon'

// import { OverlayBadgeModule } from 'primeng/overlay';

@NgModule({
  declarations: [
    CategoriesOverviewComponent,
  ],
  imports: [
    CategoriesRoutingModule,
    CommonModule,
    MessageModule,
    NgIf,
    BadgeModule,
    TieredMenuModule,
    TagModule,
    ToolbarModule,

    ButtonModule,
    DialogModule,
    InputTextModule,
    DropdownModule,
    // IconField,
    // InputIcon
  ]
})
export class CategoriesModule { }
