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
    [Migration("20181213171549_EmployeeImages")]
    partial class EmployeeImages
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

            modelBuilder.Entity("HR_DATA.HR_Module.Organization.EmployeeImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("Priority");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeImages");
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
                        new { Id = 1, CreationTime = new DateTime(2018, 12, 13, 22, 15, 47, 443, DateTimeKind.Local), Name = "Super Admin" },
                        new { Id = 2, CreationTime = new DateTime(2018, 12, 13, 22, 15, 47, 444, DateTimeKind.Local), Name = "Visitor" }
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
                        new { Id = 1, City = "Lahore", Country = "Pakistan", CreationTime = new DateTime(2018, 12, 13, 22, 15, 47, 445, DateTimeKind.Local), LastActive = new DateTime(2018, 12, 13, 22, 15, 47, 445, DateTimeKind.Local), PasswordHash = new byte[] { 46, 98, 65, 227, 192, 16, 146, 2, 97, 193, 43, 85, 227, 73, 171, 151, 18, 220, 6, 225, 31, 0, 152, 200, 207, 160, 5, 130, 176, 211, 187, 229, 126, 213, 203, 48, 219, 92, 111, 125, 185, 69, 250, 19, 15, 91, 54, 130, 217, 155, 218, 179, 253, 147, 121, 69, 88, 99, 201, 123, 236, 160, 120, 152 }, PasswordSalt = new byte[] { 207, 150, 83, 240, 208, 228, 134, 88, 210, 219, 43, 242, 60, 206, 95, 150, 174, 150, 82, 217, 48, 190, 26, 18, 44, 87, 27, 228, 85, 220, 22, 180, 238, 233, 106, 92, 35, 173, 101, 73, 252, 141, 30, 130, 111, 18, 126, 239, 223, 36, 228, 208, 124, 55, 157, 40, 121, 190, 20, 251, 83, 227, 241, 108, 198, 236, 93, 114, 1, 157, 117, 115, 220, 7, 102, 131, 140, 115, 43, 176, 74, 184, 199, 45, 89, 81, 203, 207, 143, 92, 240, 195, 109, 255, 246, 67, 124, 52, 193, 175, 52, 9, 212, 62, 4, 247, 191, 128, 61, 231, 9, 26, 251, 22, 209, 109, 102, 11, 117, 191, 26, 216, 86, 54, 133, 178, 141, 79 }, RoleId = 1, UserName = "yasir" }
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

            modelBuilder.Entity("HR_DATA.HR_Module.Organization.EmployeeImages", b =>
                {
                    b.HasOne("HR_DATA.HR_Module.Organization.Employee", "Employee")
                        .WithMany("EmployeeImages")
                        .HasForeignKey("EmployeeId")
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
