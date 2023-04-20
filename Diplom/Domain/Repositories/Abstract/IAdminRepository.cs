using Diplom.Domain.Entities;

namespace Diplom.Domain.Repositories.Abstract
{
	public interface IAdminRepository
	{
		IQueryable<Admin> GetAdmins();
		Admin GetAdminById(int id);
		Admin GetAdminByName(string name);
		void SaveAdmin(Admin entity);
		void DeleteAdmin(int id);

	}
}
