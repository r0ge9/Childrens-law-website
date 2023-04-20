using Diplom.Domain.Entities;
using Diplom.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Domain.Repositories.EF
{
	public class EFAdminRepository:IAdminRepository
	{
		private readonly AppDbContext context;
		public EFAdminRepository(AppDbContext context) 
		{
			this.context = context;
		}
		public IQueryable<Admin> GetAdmins()
		{
			return context.Admins;
		}
		public Admin GetAdminById(int id) 
		{
			return context.Admins.FirstOrDefault(x => x.Id == id);
		}
		public Admin GetAdminByName(string name)
		{
			return context.Admins.FirstOrDefault(e => e.Email == name);
		}
		public void SaveAdmin(Admin entity) 
		{
			if (entity.Id == default(int)) { context.Entry(entity).State = EntityState.Added; }
			else { context.Entry(entity).State = EntityState.Modified; }
			context.SaveChanges();
		}
		public void DeleteAdmin(int id) { 
			context.Admins.Remove(new Admin() { Id = id });
			context.SaveChanges();
		}
	}
}
