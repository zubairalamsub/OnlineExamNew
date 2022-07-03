using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Entity
{
   public class QuestionRequest
    {
        public int ExamId { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; }

    }
}
