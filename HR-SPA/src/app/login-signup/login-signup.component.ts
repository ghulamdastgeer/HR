import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {AuthService} from '../_services/auth.service';
import {AlertifyService} from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-signup',
  templateUrl: './login-signup.component.html',
  styleUrls: ['./login-signup.component.css']
})
export class LoginSignupComponent implements OnInit {
model: any = {};
@Input() ValuesFromHome: any;
@Output() cancelRegister = new EventEmitter();
  constructor(public authservice: AuthService , private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }
  register() {
    this.authservice.register(this.model).subscribe(() => {
     this.alertify.success('Registration successful');
    }, error => {
    this.alertify.error('Registeration error');
    });
     }
    cancel() {
      this.cancelRegister.emit(false);
    }
    login() {
      this.authservice.login(this.model).subscribe(next => {
      this.alertify.success('Logged in Successfully');
      this.router.navigate(['/home']);

      }, error => {
        this.alertify.error('Failed to login');

      });

}
}
