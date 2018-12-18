import { Component, Output , EventEmitter , OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  @Output() sidenavToggle = new EventEmitter<void>();
  constructor(public authService: AuthService, private alertify: AlertifyService,
    private router: Router) { }


  ngOnInit() {
  }
  onToggleSidenav() {
    this.sidenavToggle.emit();
  }
  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.router.navigate(['/loginsignup']);
  }

}
