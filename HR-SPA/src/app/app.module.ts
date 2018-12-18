import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MDBBootstrapModule} from 'angular-bootstrap-md';
import { MaterialModule } from './core/material.module';
import {ScrollDispatchModule} from '@angular/cdk/scrolling';
import { CdkTableModule } from '@angular/cdk/table';

import { AppComponent } from './app.component';
import { NavbarComponent } from './home/navbar/navbar.component';
import { SidenavComponent } from './home/sidenav/sidenav.component';
import { HomeComponent } from './home/home.component';
import { LoginSignupComponent } from './login-signup/login-signup.component';
import { UserComponent} from './home/User/User.component';
import {AuthService} from './_services/auth.service';
import {AlertifyService} from './_services/alertify.service';
import { AuthGuard } from './_gaurds/auth.guard';
import { EmployeeService } from './_services/employee.service';
import { EmployeeListComponent } from './home/employees/employee-list/employee-list.component';
import { DepartmentService } from './_services/Department.service';
import { EmployeeComponent } from './home/employees/employee/employee.component';
import {EmployeesComponent } from './home/employees/employees.component';
import { DatePipe } from '@angular/common';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginSignupComponent,
    NavbarComponent,
    SidenavComponent,
    UserComponent,
    EmployeeComponent,
    EmployeeListComponent,
    EmployeesComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    FlexLayoutModule,
    ScrollDispatchModule,
    CdkTableModule,
    MDBBootstrapModule.forRoot()
  ],
  schemas: [ NO_ERRORS_SCHEMA ],
  providers: [
    AuthService,
    AlertifyService,
    AuthGuard,
    EmployeeService,
    DepartmentService,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
