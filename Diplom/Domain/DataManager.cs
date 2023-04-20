using Diplom.Domain.Repositories.Abstract;

namespace Diplom.Domain
{
	public class DataManager
	{
		public IEventRepository Events { get; set; }
		public IReviewRepository Reviews { get; set; }
		public ITestRepository Tests { get; set; }
		public IQuestionRepository Questions { get; set; }
		public IAdminRepository Admins { get; set; }
		public DataManager(IEventRepository eventRepository,ITestRepository testRepository,IReviewRepository reviewRepository,IQuestionRepository questionRepository,IAdminRepository adminRepository) 
		{
			Events= eventRepository;
			Tests= testRepository;
			Reviews= reviewRepository;
			Questions= questionRepository;
			Admins= adminRepository;
		}
	}
}
