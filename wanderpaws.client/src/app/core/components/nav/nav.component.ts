import { Component } from '@angular/core';
import { AuthService } from '../../../features/auth/services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  isActive = false;
  items: any[];

  constructor(private authService: AuthService) {
    this.items = [
      {
        label: 'Home',
        icon: 'pi pi-clipboard',
        routerLink: ['/dashboard'],
      },
      {
        label: 'Profile',
        icon: 'pi pi-box',
        routerLink: ['/categories'],
      },
      
        {
          label: 'Profile',
          icon: 'pi pi-user',
          items: [
            {
              label: 'Overview',  //my info/account details/summary
              routerLink: ['/dashboard'],
            },
            {
              label: 'My pets',
              routerLink: ['/categories'],
            },
            {
              label: 'Logout',
              command: () => authService.logout()
            }
          ]
        },
    ];
  }

  setAsActive(selectedItem: any) {
    this.items.forEach(item => (item.isActive = false));

    selectedItem.isActive = true;
  }
}
