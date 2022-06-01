using OnlineExam.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Entity.Interfaces
{
    public interface ITeacherRepository
    {
       Task<int> UploadQuestion(List<Questions> questins);
       Task<IEnumerable<Class>> LoadAllClasses();
       Task<int> AssignTeacherToClass(AssignClass assignTeacher);
       Task<int> SaveExamFnfo(ExamInfo examInfo);
        Task<List<Questions>> LoadQuestionForExam(QuestionRequest question);

    }
}
