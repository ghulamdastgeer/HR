﻿// <auto-generated />
using System;
using HR_DATA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HR_DATA.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181206084642_remove-uniqueconstrainattendance")]
    partial class removeuniqueconstrainattendance
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HR_DATA.HR_Module.Addresses.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressTypes");

                    b.Property<int?>("BranchesId");

                    b.Property<int>("CityId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<int?>("EmployeesId");

                    b.Property<string>("StreetAddress")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BranchesId")
                        .IsUnique()
                        .HasFilter("[BranchesId] IS NOT NULL");

                    b.HasIndex("CityId");

                    b.HasIndex("EmployeesId")
                        .IsUnique()
                        .HasFilter("[EmployeesId] IS NOT NULL");

                    b.HasIndex("BranchesId", "EmployeesId")
                        .IsUnique()
                        .HasFilter("[BranchesId] IS NOT NULL AND [EmployeesId] IS NOT NULL");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Addresses.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Addresses.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Attendance_Leave.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Check_in_time");

                    b.Property<DateTime>("Check_out_time");

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("Day");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Remarks");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Attendance_Leave.Leaves", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttendanceId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("Days");

                    b.Property<int>("LeaveStatus");

                    b.Property<int>("LeaveType");

                    b.HasKey("Id");

                    b.HasIndex("AttendanceId")
                        .IsUnique();

                    b.HasIndex("AttendanceId", "Days")
                        .IsUnique();

                    b.ToTable("Leaves");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Benefit.Benefits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Benefit");

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Benefits");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Benefit.EmployeeBenefits", b =>
                {
                    b.Property<int>("BenefitId");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("CreationTime");

                    b.HasKey("BenefitId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeBenefits");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.BusinessGoals.EmployeeTasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessGoals")
                        .IsRequired();

                    b.Property<DateTime>("CreationTime");

                    b.Property<DateTime>("DeadLine");

                    b.Property<bool?>("Deadlinemeet");

                    b.Property<int>("EmployeeId");

                    b.Property<int?>("EmployeeId1");

                    b.Property<DateTime>("Start");

                    b.Property<int>("Status");

                    b.Property<int?>("TaskAssiningAuthId");

                    b.Property<DateTime?>("TaskCompleted");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EmployeeId1");

                    b.HasIndex("TaskAssiningAuthId");

                    b.ToTable("EmployeeTasks");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.EmployeePerformances.EmployeePerformance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("EmployeeId");

                    b.Property<float>("PerformacePercentage");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("EmployeePerformances");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.EmployeePerformances.Performance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Behaviour");

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("EmployeePerformanceId");

                    b.Property<float>("Punctual");

                    b.Property<int>("TaskCompleted");

                    b.HasKey("Id");

                    b.HasIndex("EmployeePerformanceId")
                        .IsUnique();

                    b.ToTable("Performance");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Organization.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Name");

                    b.Property<int>("OrganizationID");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Organization.Departments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Organization.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<DateTime>("DOB");

                    b.Property<int>("DepartmentId");

                    b.Property<bool>("Gender");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNo");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Organization.EmployeeDesignation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("EmployeeDesignations");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Organization.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Recruitement.Applicants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Email");

                    b.Property<int>("JobPostingId");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int>("Shortlist");

                    b.HasKey("Id");

                    b.HasIndex("JobPostingId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Recruitement.Interviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicantsId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Selected");

                    b.Property<int>("type");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantsId")
                        .IsUnique();

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Recruitement.JobApplications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicantsId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("ResumeURL");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantsId")
                        .IsUnique();

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Recruitement.JobPosting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Description");

                    b.Property<string>("ImagUrl")
                        .IsRequired();

                    b.Property<string>("JobTitle");

                    b.Property<int>("Vaccancies");

                    b.HasKey("Id");

                    b.ToTable("JobPostings");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Salaries.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("EmployeeId");

                    b.Property<float>("Salaries");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Training_Development.EmployeeTraining", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<int>("TrainingsId");

                    b.Property<DateTime>("CreationTime");

                    b.HasKey("EmployeeId", "TrainingsId");

                    b.HasIndex("TrainingsId");

                    b.ToTable("EmployeeTrainings");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Training_Development.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget");

                    b.Property<DateTime>("CreationTime");

                    b.Property<DateTime>("Enddate");

                    b.Property<string>("Remarks");

                    b.Property<DateTime>("Startdate");

                    b.Property<string>("TrainingAgenda");

                    b.Property<int>("type");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.UserMgt.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new { Id = 1, CreationTime = new DateTime(2018, 12, 6, 13, 46, 40, 940, DateTimeKind.Local), Name = "Super Admin" },
                        new { Id = 2, CreationTime = new DateTime(2018, 12, 6, 13, 46, 40, 940, DateTimeKind.Local), Name = "Visitor" }
                    );
                });

            modelBuilder.Entity("HR_DATA.HR_Module.UserMgt.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("CreationTime");

                    b.Property<DateTime>("LastActive");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(2);

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, City = "Lahore", Country = "Pakistan", CreationTime = new DateTime(2018, 12, 6, 13, 46, 40, 940, DateTimeKind.Local), LastActive = new DateTime(2018, 12, 6, 13, 46, 40, 940, DateTimeKind.Local), PasswordHash = new byte[] { 156, 103, 233, 215, 154, 5, 145, 179, 69, 241, 16, 115, 43, 206, 161, 93, 196, 136, 167, 156, 216, 18, 241, 107, 77, 209, 92, 234, 101, 17, 164, 89, 255, 51, 164, 202, 36, 70, 4, 171, 19, 38, 251, 61, 38, 184, 21, 114, 218, 66, 124, 123, 248, 121, 134, 47, 101, 79, 40, 71, 32, 242, 210, 97 }, PasswordSalt = new byte[] { 50, 166, 94, 182, 76, 121, 151, 149, 231, 31, 83, 2, 170, 78, 215, 72, 78, 105, 70, 93, 3, 2, 4, 129, 57, 60, 59, 180, 193, 228, 162, 117, 91, 145, 4, 169, 66, 238, 79, 134, 118, 189, 12, 240, 199, 21, 230, 240, 120, 68, 151, 246, 33, 239, 126, 162, 220, 100, 251, 192, 140, 20, 177, 39, 249, 39, 119, 194, 121, 210, 125, 244, 27, 12, 8, 109, 155, 44, 55, 83, 113, 91, 85, 167, 168, 19, 175, 223, 68, 243, 246, 223, 173, 38, 46, 203, 244, 32, 34, 168, 208, 148, 73, 184, 42, 78, 166, 255, 202, 154, 11, 56, 53, 226, 158, 243, 164, 79, 24, 56, 246, 208, 190, 171, 127, 160, 36, 163 }, RoleId = 1, UserName = "yasir" }
                    );
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Addresses.Address", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Organization.Branch", "Branches")
                        .WithOne("Address")
                        .HasForeignKey("HR_DATA.HR_Module.Addresses.Address", "BranchesId");

                    b.HasOne("HR_DATA.HR_Module.Addresses.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HR_DATA.HR_Module.Organization.Employee", "Employees")
                        .WithOne("Address")
                        .HasForeignKey("HR_DATA.HR_Module.Addresses.Address", "EmployeesId");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Addresses.City", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Addresses.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Attendance_Leave.Attendance", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Organization.Employee", "Employee")
                        .WithMany("Attendance")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Attendance_Leave.Leaves", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Attendance_Leave.Attendance", "Attendance")
                        .WithOne("Leave")
                        .HasForeignKey("HR_DATA.HR_Module.Attendance_Leave.Leaves", "AttendanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Benefit.EmployeeBenefits", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Benefit.Benefits", "Benefits")
                        .WithMany("Employees")
                        .HasForeignKey("BenefitId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HR_DATA.HR_Module.Organization.Employee", "Employee")
                        .WithMany("Benefits")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.BusinessGoals.EmployeeTasks", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Organization.Employee", "Employee")
                        .WithMany("TasksAssignedBy")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HR_DATA.HR_Module.Organization.Employee")
                        .WithMany("EmployeeTasks")
                        .HasForeignKey("EmployeeId1");

                    b.HasOne("HR_DATA.HR_Module.Organization.Employee", "TaskAssigingAuth")
                        .WithMany("TasksAssignedTo")
                        .HasForeignKey("TaskAssiningAuthId");
                });

            modelBuilder.Entity("HR_DATA.HR_Module.EmployeePerformances.EmployeePerformance", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Organization.Employee", "Employee")
                        .WithOne("performance")
                        .HasForeignKey("HR_DATA.HR_Module.EmployeePerformances.EmployeePerformance", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.EmployeePerformances.Performance", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.EmployeePerformances.EmployeePerformance", "EmployeePerformance")
                        .WithOne("Performance")
                        .HasForeignKey("HR_DATA.HR_Module.EmployeePerformances.Performance", "EmployeePerformanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Organization.Branch", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Organization.Organization", "Organization")
                        .WithMany("Branches")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Organization.Departments", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Organization.Branch", "Branch")
                        .WithMany("Departments")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Organization.Employee", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Organization.Departments", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HR_DATA.HR_Module.UserMgt.User", "User")
                        .WithOne("Employee")
                        .HasForeignKey("HR_DATA.HR_Module.Organization.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Organization.EmployeeDesignation", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Organization.Employee", "Employee")
                        .WithOne("EmployeeDesignation")
                        .HasForeignKey("HR_DATA.HR_Module.Organization.EmployeeDesignation", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Recruitement.Applicants", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Recruitement.JobPosting", "JobPosting")
                        .WithMany("Applicants")
                        .HasForeignKey("JobPostingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Recruitement.Interviews", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Recruitement.Applicants", "Applicants")
                        .WithOne("Interviews")
                        .HasForeignKey("HR_DATA.HR_Module.Recruitement.Interviews", "ApplicantsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Recruitement.JobApplications", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Recruitement.Applicants", "Applicants")
                        .WithOne("JobApplications")
                        .HasForeignKey("HR_DATA.HR_Module.Recruitement.JobApplications", "ApplicantsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Salaries.Salary", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Organization.Employee", "Employee")
                        .WithOne("Salary")
                        .HasForeignKey("HR_DATA.HR_Module.Salaries.Salary", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.Training_Development.EmployeeTraining", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Organization.Employee", "Employee")
                        .WithMany("EmployeeTrainings")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HR_DATA.HR_Module.Training_Development.Training", "Trainings")
                        .WithMany("EmployeeTraining")
                        .HasForeignKey("TrainingsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_DATA.HR_Module.UserMgt.User", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.UserMgt.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
