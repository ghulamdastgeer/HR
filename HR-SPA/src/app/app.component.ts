import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'HR-SPA';
  jwthelper = new JwtHelperService();
  model: any = {};

  constructor(public authservice: AuthService ) { }

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.authservice.decodedtoken = this.jwthelper.decodeToken(token);
     }
  }

}
