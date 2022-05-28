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
<<<<<<< HEAD

=======
       Task<int> SaveExamFnfo(ExamInfo examInfo);
       
>>>>>>> 8eff51d450f60c98971d1b03668844e2a88912c8
    }
}
