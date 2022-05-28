using System;

namespace OnlineExam.Entity
{
    public class Exam
    {

		public int Id { get; set; }
		public int TeacherId { get; set; }
		public int ClassId { get; set; }
		public string QuestionName { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public bool Comleted { get; set; }

	}
}
