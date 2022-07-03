using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Entity
{
    public class ExamInfoViewModel
    {
       
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public bool Comleted { get; set; }
        public int TotalMarkS { get; set; }
        public string Selected { get; set; }
        public string Answer { get; set; }


    }
}
