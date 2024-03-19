﻿using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Infrastructure.Data.Common
{
	public class Repository : IRepository
	{
		private readonly DbContext context;

        public Repository(FoodDeliveryAppDbContext _context)
        {
            context = _context;
        }

		private DbSet<T> DbSet<T>() where T : class
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

		public async Task SaveChangesAsync()
		{
			await context.SaveChangesAsync();
		}
	}
}