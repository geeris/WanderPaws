import { Injectable } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { CreateUser } from '../models/user.model';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
 
@Injectable({
  providedIn: 'root'
})
export class UserService {
    constructor(private http: HttpClient) {}

    registerUser(createUser: CreateUser): Observable<any> { ///, authToken: string)
        // const url = `${environment.apiUrl}/user/register`;
        // const headers = new HttpHeaders({
        //   'Skip-Interceptor' : 'true',
        //   //'Authorization': `Bearer ${authToken}`, // Include the auth token in the Authorization header
        //   'Content-Type': 'application/json'
        // });

        // , { headers }
        return this.http.post(`${environment.apiUrl}/api/auth/register`, createUser);
      }
}
