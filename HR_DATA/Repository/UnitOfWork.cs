using HR_DATA.Data;
using System.Threading.Tasks;

namespace HR_DATA.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private  DataContext _Context;

        public UnitOfWork()
        {
        }

        public UnitOfWork(DataContext context)
        {
            _Context = context;
        }
     public async Task CompleteAsync()
        {
            await _Context.SaveChangesAsync();
        }


    }
}
