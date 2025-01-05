import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { UserInterface } from './interfaces/user.interface';
import { AuthService } from './core/services/auth.service';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  constructor(private authService: AuthService) { }

  ngOnInit() { }

  logout() {
    this.authService.logout();
  }
}

// getForecasts() {
//   this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
//     (result) => {
//       this.forecasts = result;
//     },
//     (error) => {
//       console.error(error);
//     }
//   );
// }

// title = 'budgetbloom.client';
// }
