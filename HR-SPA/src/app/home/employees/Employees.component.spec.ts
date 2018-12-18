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
      cell: (Employee: any) 