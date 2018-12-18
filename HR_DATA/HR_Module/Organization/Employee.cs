using HR_DATA.HR_Module.Addresses;
using HR_DATA.HR_Module.Attendance_Leave;
using HR_DATA.HR_Module.Benefit;
using HR_DATA.HR_Module.BusinessGoals;
using HR_DATA.HR_Module.EmployeePerformances;
using HR_DATA.HR_Module.Salaries;
using HR_DATA.HR_Module.Training_Development;
using HR_DATA.HR_Module.UserMgt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static HR_DATA.HR_Module.DataUtils;

namespace HR_DATA.HR_Module.Organization
{
    public class Employee:HalfAuditEntity<int>
    {

        public string Name{get;set;}

        public string PhoneNo{get;set;}
        

        public Gender Gender { get; set; }
        
        public DateTime DOB { get; set; }
        //one to one
        public EmployeeDesignation EmployeeDesignation { get; set; }

        //one to one
        public Salary Salary{get;set;}

        //many to many
        public List<EmployeeBenefits> Benefits{get;set;}

        //MANY TO MANY
        public List<EmployeeTraining> EmployeeTrainings { get; set; }
        
        //one to one
        public int UserId { get; set; }
        public  User User{get;set;}

        // many to one
        public int DepartmentId { get; set; }
        public Departments Department { get; set; }
        
        //many to many
        public List<EmployeeTasks> EmployeeTasks { get; set; }
        //one to many 
        public List<Attendance> Attendance { get; set; }

        public EmployeePerformance performance { get; set; }
        public Address Address { get; set; }

        [InverseProperty("TaskAssigingAuth")]
        public List<EmployeeTasks> TasksAssignedTo { get; set; }

        [InverseProperty("Employee")]
        public List<EmployeeTasks> TasksAssignedBy { get; set; }

        public List<EmployeeImages> EmployeeImages { get; set; }

    }
}