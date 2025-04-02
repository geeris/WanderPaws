import { Component } from '@angular/core';
import { NotificationService } from '../../../../../core/services/notification.service';

@Component({
  selector: 'app-dashboard-overview',
  templateUrl: './dashboard-overview.component.html',
  styleUrl: './dashboard-overview.component.css'
})
export class DashboardOverviewComponent {
  lostOrFound: string = ''; // remove later
  stateOptions: any[];
  pets: any[];
  selectedPet: string = '';

  constructor(
      private notificationService: NotificationService
    ) {
      this.stateOptions = [ 
        { label: 'Lost', value: 'Lost' }, 
        { label: 'Found', value: 'Found' } 
      ]; 

      // interface StateOption {
      //   label: string;
      //   value: string;
      // }

      this.pets = [ 
        { label: 'Dog', value: 'Dog' }, 
        { label: 'Cat', value: 'Cat' } 
      ]; 
    }
}
