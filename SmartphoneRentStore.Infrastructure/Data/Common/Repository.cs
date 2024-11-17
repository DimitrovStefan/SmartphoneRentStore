
using Microsoft.EntityFrameworkCore;
using SmartphoneRentStore.Infastructure.Data;

namespace SmartphoneRentStore.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(SmartPhoneDbContext context)
        {
            this.context = context;
        }

        private DbSet<T> DbSet<T>() where T : class // Generic method
        {
            return context.Set<T>();
        }
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }
    }
}
