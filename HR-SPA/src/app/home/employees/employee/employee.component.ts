import { Component, OnInit } from '@angular/core';
import { DepartmentService } from 'src/app/_services/Department.service';
import { EmployeeService } from 'src/app/_services/employee.service';
import { NotificationService } from 'src/app/_services/notification.service';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor(private employeeservice: EmployeeService,
    private departmentService: DepartmentService,
    private notificationService: NotificationService) { }


  ngOnInit() {
    this.employeeservice.GetEmployees();
  }




}
