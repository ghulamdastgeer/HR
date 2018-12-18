import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'http://localhost:5000/api/User/';
jwthelper = new JwtHelperService();
decodedtoken: any;

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'Login', model).pipe(
     map((response: any) => {
       const user = response;
       if (user) {
         localStorage.setItem('token', user.token);
         this.decodedtoken = this.jwthelper.decodeToken(user.token);
        console.log(this.decodedtoken);
            }
     })
    );
  }

  register(model: any) {
  return this.http.post(this.baseUrl + 'register', model);
  }

  loggedin() {
    const token = localStorage.getItem('token');
    return !this.jwthelper.isTokenExpired(token);

  }
  IsInRole() {
  }

}
