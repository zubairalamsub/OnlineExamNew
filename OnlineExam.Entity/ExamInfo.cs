using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Entity
{
    public class ExamInfo
    {
		public int Id { get; set; }
		public int ExamId { get; set; }
		public int StudentId { get; set; }
		public int Marks { get; set; }
		public bool Completed { get; set; }
        public int TotalMarkS{ get; set; }

    }
}
