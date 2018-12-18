using System;
using System.ComponentModel.DataAnnotations;

namespace HR_DATA.HR_Module
{
    public class DataUtils
    {
        public enum AttendanceType { Present=1,Absent=0,OnLeave=2};
        public enum BenefitType { Default=1,Special=2};
        public enum LeaveStatus { Pending = 0, Approved = 1, Rejected = 2,Underreview=3 };
        public enum TrainingType { Onthejob = 1, Offthejob = 2 };
        public enum InterviewType { Screening = 1, TechnicalTest = 2 };
        public enum Leave { Sleave = 1, Fleave = 2, AnnualLeave = 3, Weddingleave = 4, Sickleave = 5, Compensatationleave = 6 };
        public enum Selected { Selected=1,Rejected=2,Pending=3 };
        public enum Shortlisted { Shortlisted=1,Rejected=2,Pending=3};
        public enum Estatus { Student = 1, Employed = 2, Unemployeed = 3 };
        public enum Behaviour { Passive = 1, Assertive = 2, Aggresive = 3 };
        public enum AddressType { Employee=1,Branch=2};
        public enum Taskstatus { OnGoing=1,Completed=2,OverDue=3};
        public enum Gender { male=1,female=2};
    }
    public abstract class Entity<T>
    {
        [Key]
        public T Id { get; set; }
    }

    public abstract class HalfAuditEntity<T> : Entity<T>
    {
        public HalfAuditEntity()
        {
            CreationTime = DateTime.Now;
        }
        public DateTime CreationTime { get; set; }

    }

 
}


