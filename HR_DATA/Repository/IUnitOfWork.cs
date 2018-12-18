using HR_DATA.HR_Module.Organization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.Repository
{
    public interface IUnitOfWork
    {
     //   IRepository<Organization> ModelRepository { get; }
        Task CompleteAsync();
    }
}
