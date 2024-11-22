﻿
using Microsoft.EntityFrameworkCore;
using SmartphoneRentStore.Infastructure.Data;
using SmartphoneRentStore.Infrastructure.Data.Models;
using SmartphoneRentStore.Infrastructure.Data;

namespace SmartphoneRentStore.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly SmartPhoneDbContext context;

        public Repository(SmartPhoneDbContext _context)
        {
            context = _context;
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
        
        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}

