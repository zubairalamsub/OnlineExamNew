using OnlineExam.Entity;
using OnlineExam.Entity.Interfaces;
using OnlineExam.Entity.ViewModel;
using OnlineExam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Services
{
    public class TeacherService: ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;

        }

        public async Task<int> UploadQuestion(List<Questions> questins)
        {

            var data = await _teacherRepository.UploadQuestion(questins);
            return data;
        }

       public async Task<IEnumerable<Class>> LoadAllClasses()
        {
            var data=await _teacherRepository.LoadAllClasses();
            return data;
        }
        public async Task<IEnumerable<Exam>> LoadAllExam()
        {
            var data = await _teacherRepository.LoadAllExam();
            return data;
        }
     

        public async Task<int> AssignTeacherToClass(AssignClass assignTeacher)
        {
            var data = await _teacherRepository.AssignTeacherToClass(assignTeacher);
            return data;

        }
        public async Task<int> CreateNewExam(Exam exam)
        {
            var data = await _teacherRepository.CreateNewExam(exam);
            return data;

        }

        public async Task<int> SaveExamFnfo(ExamInfo examInfo)
        {

            var data = await _teacherRepository.SaveExamFnfo(examInfo);
            return data;
        }

        public async Task<CheckExamViewModel> CheckExamAvailability(QuestionRequest question)
        {

            var data = await _teacherRepository.CheckExamAvailability(question);
            return data;
        }

        public async Task<List<LoadQuestionViewModel>> LoadQuestionForExam(QuestionRequest question)
        {
            var data = await _teacherRepository.LoadQuestionForExam(question);
            return data;


        }
        public async Task<List<MarksViewModel>> LoadAllmarks(LoadMarksViewModel loadMarks)
        {
            var data = await _teacherRepository.LoadAllmarks(loadMarks);
            return data;


        }

        public async Task<List<ShowResultViewModel>> LoadAllExamResult(int studentId)
        {
            var data = await _teacherRepository.LoadAllExamResult(studentId);
            return data;
        }
        public async Task<ExamInfo> SubmitMarks(List<ExamInfoViewModel> examInfoViewModel)
        {
            int TotalObtainedMarks = examInfoViewModel.Count(x => x.Answer == x.Selected);
            int TotalMarks = examInfoViewModel.Count;
            var data = examInfoViewModel.Select(x => new ExamInfo
            {
                ExamId = x.ExamId,
                StudentId = x.StudentId,
                Marks = TotalObtainedMarks,
                TotalMarkS= TotalMarks
            }).FirstOrDefault() ;
            return await _teacherRepository.SaveExamInfo(data);

        }


        //public async Task<int> AssignTeacherToClass(AssignClass assignTeacher)
        // {

        //     var data = await _teacherRepository.AssignTeacherToClass(assignTeacher);
        //     return data;

        // }


    }
}
