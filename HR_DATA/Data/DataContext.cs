using HR_DATA.HR_Module.Addresses;
using HR_DATA.HR_Module.Attendance_Leave;
using HR_DATA.HR_Module.Benefit;
using HR_DATA.HR_Module.BusinessGoals;
using HR_DATA.HR_Module.EmployeePerformances;
using HR_DATA.HR_Module.Organization;
using HR_DATA.HR_Module.Recruitement;
using HR_DATA.HR_Module.Salaries;
using HR_DATA.HR_Module.Training_Development;
using HR_DATA.HR_Module.UserMgt;
using Microsoft.EntityFrameworkCore;
using System;

namespace HR_DATA.Data
{
    public class DataContext : DbContext
    {
        public DataContext(IServiceProvider services, DbContextOptions<DataContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeBenefits>()
        .HasKey(bc => new { bc.BenefitId, bc.EmployeeId });

            modelBuilder.Entity<EmployeeBenefits>()
                .HasOne(bc => bc.Benefits)
                .WithMany(b => b.Employees)
                .HasForeignKey(bc => bc.BenefitId);


            modelBuilder.Entity<EmployeeBenefits>()
                .HasOne(bc => bc.Employee)
                .WithMany(c => c.Benefits)
                .HasForeignKey(bc => bc.EmployeeId);

         
            modelBuilder.Entity<EmployeeTraining>()
       .HasKey(bc => new { bc.EmployeeId, bc.TrainingsId });

            modelBuilder.Entity<EmployeeTraining>()
                .HasOne(bc => bc.Trainings)
                .WithMany(b => b.EmployeeTraining)
                .HasForeignKey(bc => bc.TrainingsId);

            modelBuilder.Entity<EmployeeTraining>()
                .HasOne(bc => bc.Employee)
                .WithMany(c => c.EmployeeTrainings)
                .HasForeignKey(bc => bc.EmployeeId);

            modelBuilder.Entity<Address>()
                .HasOne(b => b.Employees)
                .WithOne(bc => bc.Address)
                .HasForeignKey<Address>(b => b.EmployeesId);

            modelBuilder.Entity<EmployeeTasks>()
                .HasOne(b => b.TaskAssigingAuth)
                .WithMany(bc => bc.TasksAssignedTo)
                .HasForeignKey(b => b.TaskAssiningAuthId);

            modelBuilder.Entity<EmployeeTasks>()
               .HasOne(b => b.Employee)
               .WithMany(bc => bc.TasksAssignedBy)
               .HasForeignKey(b => b.EmployeeId);

            modelBuilder.Entity<Address>()
               .HasOne(b => b.Branches)
               .WithOne(bc => bc.Address)
               .HasForeignKey<Address>(b => b.BranchesId);
            modelBuilder.Entity<Address>()
              .HasIndex(p => new { p.BranchesId, p.EmployeesId }).IsUnique();
           
            //Leave Composite Unique Index
            modelBuilder.Entity<Leaves>()
                .HasIndex(p => new { p.AttendanceId,p.Days}).IsUnique();
            //Default Constraint
            modelBuilder.Entity<User>()
                .Property(b => b.RoleId)
                .HasDefaultValue(2);

            //modelBuilder.Entity<Address>()
            //    .HasIndex(a => new { a.BranchesId, a.EmployeesId }).IsUnique();

            byte[] passwordHash, passwordSalt;

            CreatePasswordHash("password", out passwordHash, out passwordSalt);
           
            modelBuilder.Entity<Role>().HasData(
               new Role{ Id = 1, CreationTime = DateTime.Now, Name = "Super Admin" }
               ,new Role{Id=2,CreationTime=DateTime.Now,Name="Visitor" });

            modelBuilder.Entity<User>().HasData(
                new User{ Id = 1, CreationTime = DateTime.Now, LastActive=DateTime.Now,City="Lahore",Country="Pakistan", UserName = "yasir", PasswordHash=passwordHash, PasswordSalt=passwordSalt, RoleId=1 });

            base.OnModelCreating(modelBuilder);

        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Leaves> Leaves { get; set; }

        public DbSet<Benefits> Benefits { get; set; }

        public DbSet<Performance> Performance { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Departments> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeBenefits> EmployeeBenefits { get; set; }
        public DbSet<EmployeeTraining> EmployeeTrainings { get; set; }
        public DbSet<EmployeeDesignation> EmployeeDesignations { get; set; }
        public DbSet<EmployeePerformance> EmployeePerformances { get; set; }
        public DbSet<Applicants> Applicants { get; set; }
        public DbSet<Interviews> Interviews { get; set; }

        public DbSet<JobApplications> JobApplications { get; set; }

        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<EmployeeTasks> EmployeeTasks { get; set; }
       
    }
}





