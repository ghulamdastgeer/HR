import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginSignupComponent } from './login-signup/login-signup.component';
import { AuthGuard } from './_gaurds/auth.guard';
import { UserComponent } from './home/User/User.component';
import { EmployeeComponent } from './home/employees/employee/employee.component';
import { EmployeesComponent } from './home/employees/employees.component';

const routes: Routes = [
{ path: 'loginsignup', component: LoginSignupComponent},
{ path: 'home', component: HomeComponent,
children: [
  {path: 'user', component: UserComponent},
  {path: 'Employee', component: EmployeesComponent}
] },
/*{
  path: '',
  runGuardsAndResolvers: 'always',
  canActivate: [AuthGuard],
children: [
  {path: 'user', component: UserComponent}
]
},*/
{ path: '**' , redirectTo: 'loginsignup', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
