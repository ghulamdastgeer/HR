using static HR_DATA.HR_Module.DataUtils;

namespace HR_DATA.HR_Module.EmployeePerformances
{
    public class Performance : HalfAuditEntity<int>
    {
      
        public int TaskCompleted { get; set; }

        public float Punctual { get; set; }


        public Behaviour Behaviour { get; set; }
       
        public int EmployeePerformanceId { get; set; }
        public EmployeePerformance EmployeePerformance { get; set; }
    }
}
