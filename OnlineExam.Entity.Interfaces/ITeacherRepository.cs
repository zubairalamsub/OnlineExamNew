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
       Task<List<LoadQuestionViewModel>> LoadQuestionForExam(QuestionRequest question);
       Task<CheckExamViewModel> CheckExamAvailability(QuestionRequest question);
       Task<ExamInfo> SaveExamInfo(ExamInfo examInfo);
       Task<int> CreateNewExam(Exam exam);
       Task<IEnumerable<Exam>> LoadAllExam();
       Task<List<MarksViewModel>> LoadAllmarks(LoadMarksViewModel loadMarks);
       Task<List<ShowResultViewModel>> LoadAllExamResult(int studentId);



    }
}
