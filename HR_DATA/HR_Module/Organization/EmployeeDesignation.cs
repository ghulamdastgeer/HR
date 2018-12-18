namespace HR_DATA.HR_Module.Organization
{
    public class EmployeeDesignation: HalfAuditEntity<int>
    {
        public string Name { get; set; }

        //one to one
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
