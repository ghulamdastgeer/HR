using static HR_DATA.HR_Module.DataUtils;

namespace HR_DATA.Helper
{
    public class EmployeeParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize;}
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value;}
        }

        public string Name { get; set; }

        public string Designation { get; set; }
        public Gender? Gender { get; set; }
        public int? DepartmentId { get; set; }
        public int? MinSalary { get; set; } = 10000;
        public int? MaxSalary { get; set; } = 1000000;
        public string OrderBy { get; set; }

    }
}