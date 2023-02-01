
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Diplom.Domain.Entities
{
    public class Question 
    {
		public Question()
		{
		
		}
		public Question(int testId) 
        {
            TestId = testId;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Answers { get; set; }
        [Required]
        public string RightAnswer { get; set; }
        public string Image { get; set; }
        [Required]
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
