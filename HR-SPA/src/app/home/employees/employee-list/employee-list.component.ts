import { Component, OnInit, ViewChild } from "@angular/core";
import { EmployeeService } from "src/app/_services/employee.service";
import { MatSort } from "@angular/material";
import { Pagination, PaginatedResult } from "src/app/_models/pagination";
import { EmployeeList } from "src/app/_models/EmployeeList";

@Component({
  selector: "app-employee-list",
  templateUrl: "./employee-list.component.html",
  styleUrls: ["./employee-list.component.css"]
})
export class EmployeeListComponent implements OnInit {
  employee: EmployeeList[];
  pageNumber = 1;
  pageSize = 5;
  employeeparams: any = {};
  @ViewChild(MatSort) sort: MatSort;
  searchKey: string;
  pagination: Pagination;
  columns = [
    {
      columnDef: "name",
      header: "Name.",
      cell: (Employee: any) => `${Employee.name}`
    },
    {
      columnDef: "phoneNo",
      header: "PhoneNo",
      cell: (Employee: any) => `${Employee.phoneNo}`
    },
    {
      columnDef: "dob",
      header: "DOB",
      cell: (Employee: any) => `${Employee.dob}`
    },
    {
      columnDef: "gender",
      header: "Gender",
      cell: (Employee: any) => `${Employee.gender}`
    },
    {
      columnDef: "employeeDesignation",
      header: "Designation",
      cell: (Employee: any) => `${Employee.employeeDesignation.name}`
    },
    {
      columnDef: "salary",
      header: "Salary",
      cell: (Employee: any) => `${Employee.salary.salaries}`
    },
    {
      columnDef: "department",
      header: "Department",
      cell: (Employee: any) => `${Employee.departmentResource.name}`
    },
    {
      columnDef: "address",
      header: "Address",
      cell: (Employee: any) => `${Employee.address.streetAddress}`
    }
  ];
  displayedColumns = this.columns.map(c => c.columnDef);
  dataSource: EmployeeList[];

  constructor(private Employeeservice: EmployeeService) {}
  ngOnInit() {
    this.Employeeservice.GetEmployees(this.pageNumber, this.pageSize).subscribe(
      data => {
        this.dataSource = data.result;
        this.pagination = data["employee"].pagination;
      },
      err => {
        console.log(err);
      }
    );
  }

  resetFilters() {
    this.employeeparams.name = "";
    this.employeeparams.department = "";
    this.employeeparams.minSalary = null;
    this.employeeparams.maxSalary = null;
    this.employeeparams.designation = "";
    this.GetEmployees();
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.GetEmployees();
  }

  GetEmployees() {
    this.Employeeservice.GetEmployees(
      this.pagination.currentPage,
      this.pagination.itemsperpage,
      this.employeeparams
    ).subscribe((res: PaginatedResult<EmployeeList[]>) => {
      this.dataSource = res.result;
      this.pagination = res.pagination;
    });
  }
}
