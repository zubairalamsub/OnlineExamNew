using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Entity.ViewModel
{
    public class LoadQuestionViewModel
    {

		public int Id { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public string FirstOption { get; set; }
		public string SceondOption { get; set; }
		public string ThirdOption { get; set; }
		public string FourthOption { get; set; }
		public string Answer { get; set; }
		public string ClassId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }



    }
}
