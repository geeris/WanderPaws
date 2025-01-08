import { Component } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  isActive = false;
  items: any[];

  constructor() {
    this.items = [
      {
        label: 'Dashboard',
        icon: 'pi pi-clipboard',
        routerLink: ['/dashboard'],
      },
      {
        label: 'Accounts',
        icon: 'pi pi-credit-card',
        routerLink: ['/accounts'],
      },
      {
        label: 'Transactions',
        icon: 'pi pi-money-bill',
        routerLink: ['/transactions'],
      },
      {
        label: 'Categories',
        icon: 'pi pi-box',
        routerLink: ['/categories'],
      }
    ];
  }

  setAsActive(selectedItem: any) {
    this.items.forEach(item => (item.isActive = false));

    selectedItem.isActive = true;
  }
}
