import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { EmployeeList } from "../_models/EmployeeList";
import { EmployeeService } from "../_services/employee.service";

@Injectable()
export class EmployeeListResolver implements Resolve<EmployeeList[]> {
  pageNumber = 1;
  pageSize = 5;

  constructor(
    private Employeeservice: EmployeeService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<EmployeeList[]> {
    return this.Employeeservice.GetEmployees(
      this.pageNumber,
      this.pageSize
    ).pipe(
      catchError(error => {
        this.alertify.error("Problem retrieving data");
        this.router.navigate(["/home/employee"]);
        return of(null);
      })
    );
  }
}
