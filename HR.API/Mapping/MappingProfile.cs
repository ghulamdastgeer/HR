using AutoMapper;
using HR.API.Controllers.Resources;
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

namespace HR.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<SaveOrganizationResource, Organization>()
            .ForMember(V => V.Branches, opt => opt.Ignore());

            CreateMap<Organization, OrganizationResource>();

            CreateMap<SaveBranchResource, Branch>()
                .ForMember(v => v.Departments, opt => opt.Ignore())
                .ForMember(v => v.Organization, opt => opt.Ignore());

            CreateMap<SaveAddressResource, Address>()
                .ForMember(v => v.Branches, opt => opt.Ignore())
                .ForMember(v => v.Employees, opt => opt.Ignore())
                .ForMember(v => v.City, opt => opt.Ignore())
                .ForMember(v => v.EmployeesId, opt => opt.Ignore())
                .ForMember(v => v.BranchesId, opt => opt.Ignore());

            CreateMap<Branch, BranchResource>();

            CreateMap<SaveDepartmentResource, Departments>()
                .ForMember(v => v.Branch, opt => opt.Ignore())
                .ForMember(v => v.Employees, opt => opt.Ignore());

            CreateMap<Departments, DepartmentsResource>();

            CreateMap<SaveEmployeeResource, Employee>()
                .ForMember(v => v.Attendance, opt => opt.Ignore())
                .ForMember(v => v.Department, opt => opt.Ignore())
                .ForMember(v => v.User, opt => opt.Ignore());

            CreateMap<EmployeeBenefitResource, EmployeeBenefits>()
                .ForMember(v => v.Benefits, opt => opt.Ignore())
                .ForMember(v => v.Employee, opt => opt.Ignore())
                .ForMember(v => v.EmployeeId, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<EmployeeTrainingResource, EmployeeTraining>()
                .ForMember(v => v.Employee, opt => opt.Ignore())
                .ForMember(v => v.Trainings, opt => opt.Ignore())
                .ForMember(v => v.TrainingsId, opt => opt.Ignore());

                
            CreateMap<EmployeeDesignationResource, EmployeeDesignation>()
                 .ForMember(v => v.Employee, opt => opt.Ignore())
                 .ForMember(v => v.EmployeeId, opt => opt.Ignore());
            CreateMap<SalaryResource, Salary>()
                .ForMember(v => v.EmployeeId, opt => opt.Ignore())
                .ForMember(v => v.Employee, opt => opt.Ignore());

            CreateMap<Employee, EmployeeResource>();

            CreateMap<BenefitsResource,Benefits>()
                .ReverseMap();

            CreateMap<Salary, SalaryResource>()
                .ReverseMap();

            CreateMap<EmployeeDesignation, EmployeeDesignationResource>()
                .ReverseMap();

            CreateMap<BenefitsResource, Benefits>()
                .ForMember(v => v.Employees, opt => opt.Ignore());
            CreateMap<TrainingResource, Training>();
               

            CreateMap<AttendanceResource, Attendance>()
                .ForMember(v => v.Employee, opt => opt.Ignore())
                .ForMember(v => v.Leave, opt => opt.Ignore());
            
            CreateMap<LeaveResource, Leaves>()
                .ForMember(v => v.Attendance, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<JobPostingResource, JobPosting>()
                .ForMember(v => v.Applicants, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ApplicantResource, Applicants>()
                .ForMember(v => v.Interviews, opt => opt.Ignore())
                .ForMember(v => v.JobPosting, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<JobApplicationResource, JobApplications>()
                 .ForMember(v => v.Applicants, opt => opt.Ignore())
                 .ForMember(v=>v.ApplicantsId,opt=>opt.Ignore())
                 .ReverseMap();
            CreateMap<InterviewsResource, Interviews>()
                .ForMember(v => v.Applicants, opt => opt.Ignore());
           
           
            CreateMap<EmployeeTasksResources, EmployeeTasks>()
                .ForMember(v => v.TaskAssigingAuth, opt => opt.Ignore())
                .ForMember(v => v.Employee, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<EmployeePerformanceResource, EmployeePerformance>()
                .ForMember(v => v.Employee, opt => opt.Ignore())       
                .ReverseMap();
            CreateMap<PerformanceResource, Performance>()
                .ForMember(v => v.EmployeePerformance, opt => opt.Ignore())
                .ForMember(v => v.EmployeePerformanceId, opt => opt.Ignore());

            CreateMap<SaveUserResource, User>()
                .ForMember(v => v.LastActive, opt => opt.Ignore())
                .ForMember(v => v.City, opt => opt.Ignore())
                .ForMember(v => v.Country, opt => opt.Ignore())
                .ForMember(v => v.RoleId, opt => opt.Ignore())
                .ForMember(v => v.Employee, opt => opt.Ignore());
            CreateMap<LoginUserResource, User>()
                .ForMember(v => v.Employee, opt => opt.Ignore())
                .ForMember(v => v.LastActive, opt => opt.Ignore())
                .ForMember(v => v.City, opt => opt.Ignore())
                .ForMember(v => v.Country, opt => opt.Ignore())
                .ForMember(v => v.Role, opt => opt.Ignore())
                .ForMember(v => v.RoleId, opt => opt.Ignore());
            CreateMap<RoleResource, Role>()
                .ForMember(v => v.User, opt => opt.Ignore());

            CreateMap<EmployeeImageResource, EmployeeImages>()
                .ForMember(v => v.Employee, opt => opt.Ignore())
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ReverseMap();
               

        }

    }
}