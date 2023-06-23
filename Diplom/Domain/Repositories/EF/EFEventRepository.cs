using Diplom.Domain.Entities;
using Diplom.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Domain.Repositories.EF
{
	public class EFEventRepository:IEventRepository
	{
		private readonly AppDbContext context;
		public EFEventRepository(AppDbContext context) 
		{
			this.context = context;
		}
		public IQueryable<Event> GetEvents()//метод получения всех новостей из БД
		{
			return context.Events;
		}
		public Event GetEventById(int id) //метод получения новости по id
		{
			return context.Events.FirstOrDefault(x => x.Id == id);
		}
		public Event GetEventByName(string name)//метод получения новости по названию
		{
			return context.Events.FirstOrDefault(e => e.Name == name);
		}
		public void SaveEvent(Event entity) //метод сохранения новой или измененной новости
		{
			if (entity.Id == default(int)) { context.Entry(entity).State = EntityState.Added; }
			else { context.Entry(entity).State = EntityState.Modified; }
			context.SaveChanges();
		}
		public void DeleteEvent(int id) //метод удаления новости из БД по id
		{ 
			context.Events.Remove(new Event() { Id = id });
			context.SaveChanges();
		}
	}
}
