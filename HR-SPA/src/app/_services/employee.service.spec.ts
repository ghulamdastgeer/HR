/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EmployeeService } from './employee.service';
import {HttpClientTestingModule, HttpTestingController} from '@angular/common/http/testing';
import { EmployeeList } from '../Models/EmployeeList';
import { get } from 'selenium-webdriver/http';
describe('Service: Employee', () => {
  let service: EmployeeService;
  let httpmock: HttpTestingController;
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [EmployeeService]
    });
    service = TestBed.get(EmployeeService);
    httpmock = TestBed.get(HttpTestingController);
  });
  afterEach(() => {
   httpmock.verify();
  });
it('Should retrive employee from Api Via Get', () => {
 const employee: EmployeeList[] = [
  {
  id: 1, name: 'string' , phoneNo: '1234567', paidTimeOff: 1, dob: new Date(2018, 12, 11, 13, 34, 56) ,
   gender: 'Male', employeeDesignation: {
     name: 'manager'
   }, salary: {
    salaries: 24345
   },
  department: {
    name: 'eeeer'
  },
   address: {
    streetAddress: 'string',
    addressTypes: 1,
    cityId: 1
  },
  employeeImageResource: []
}
 ];
 service.GetEmployees().subscribe( employees => {
  expect(employees.length).toBe(1);
  expect(employees).toEqual(employee);
 });
 const request = httpmock.expectOne(`${service.baseUrl}/GetEmployees`);
 expect(request.request.method).toBe('Get');
 request.flush(employee);
});
});
