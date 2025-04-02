import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { CreateUser } from '../models/user.model';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  // registerUser(command: CreateUser): Observable<string> { ///, authToken: string)
  //   return this.http.post<string>(`${environment.apiUrl}/api/auth/register`, command);
  // }
}
