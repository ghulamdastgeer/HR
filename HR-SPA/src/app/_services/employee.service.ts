import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
// tslint:disable-next-line:import-blacklist
import { map } from 'rxjs/operators';
// import 'rxjs/add/operator/map';
import { EmployeeList } from 'src/app/_models/EmployeeList';
import { PaginatedResult } from 'src/app/_models/pagination';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
 public baseUrl = 'http://localhost:5000/api/Employee/';
constructor(private http: HttpClient) { }

GetEmployees(page?, itemsPerPage?, employeeParams? ): Observable<PaginatedResult<EmployeeList[]>>  {

  const paginatedResult: PaginatedResult<EmployeeList[]> = new PaginatedResult<EmployeeList[]>();
  let params = new HttpParams();
  if (page != null && itemsPerPage != null) {
   params = params.append('pageNumber', page);
   params = params.append('pageSize' , itemsPerPage);
   if (employeeParams != null) {
    params = params.append('name', employeeParams.name);
    params = params.append('Designation', employeeParams.designation);
    params = params.append('department', employeeParams.department);
    params = params.append('minSalary', employeeParams.minSalary);
    params = params.append('maxSalary', employeeParams.maxSalary);
    params = params.append('orderby', employeeParams.orderby);
  }
  }
    return this.http.get<EmployeeList[]>(this.baseUrl + 'GetEmployees' , { observe: 'response', params})
    .pipe(
      map ( response => {
        paginatedResult.result = response.body;
        if ( response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResult;
      })
    );
}

getEmployeeById(id: number) {
  return this.http.get<EmployeeList>(this.baseUrl + 'GetEmployeeById' + '/' + id);
}

createEmployee(Employee: any) {
  return this.http.post(this.baseUrl + 'Add-Employee', Employee);
}

updateEmployee(Employee: EmployeeList, id: number) {
  return this.http.put(this.baseUrl + 'UpdateEmployee' + '/' + id, Employee);
}

deleteemployee(id: number) {
  return this.http.delete(this.baseUrl + 'DeleteEmployee' + '/' + id);
}
}
