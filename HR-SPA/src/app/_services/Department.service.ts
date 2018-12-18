import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  private baseUrl = 'http://localhost:5000/api/Department/';
  constructor(private http: HttpClient) { }

  GetDepartments(): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'GetDepartments')
      .map((res: Response) => res.json())
      .catch((error: any) => {
        return Observable.throw (new Error(error.status));
      });
  }

GetDeptById(id: number) {
  return this.http.get<any>(this.baseUrl + 'GetDeptById' + '/' + id)
  .map(res => res.json());
}

createDepartment(Department: any) {
  return this.http.post(this.baseUrl + 'add-dept', Department);
}

updateDepartment(Employee: any, id: number) {
  return this.http.put(this.baseUrl + 'update-dept' + '/' + id, Employee);
}

deleteDepartment(id: number) {
  return this.http.delete(this.baseUrl + 'delete-dept' + '/' + id);
}
}
