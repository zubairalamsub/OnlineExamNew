using OnlineExam.Context;
using OnlineExam.Entity;
using OnlineExam.Entity.Interfaces;
using OnlineExam.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TeacherRepository : ITeacherRepository
    {

        private readonly OnlineExamContext _sqlServerContext;
        public TeacherRepository(OnlineExamContext onlineExamContext)
        {
            _sqlServerContext = onlineExamContext ?? throw new ArgumentNullException(nameof(onlineExamContext));
        }

        public async Task<int> UploadQuestion(List<Questions> questins)
        {
            try
            {

                //foreach (var ques in questins)
                //{

                //    await _sqlServerContext.Questions.AddAsync(ques);
                    
                //}
                await _sqlServerContext.AddRangeAsync(questins);
                return await _sqlServerContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<int> AssignTeacherToClass(AssignClass assignTeacher)
        {
            try
            {
                await _sqlServerContext.AssignClass.AddAsync(assignTeacher);
                return await _sqlServerContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<int> CreateNewExam(Exam exam)
        {
            try
            {
                await _sqlServerContext.Exam.AddAsync(exam);
                return await _sqlServerContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<int> SaveExamFnfo(ExamInfo examInfo)
        {

            try
            {
                await _sqlServerContext.ExamInfo.AddAsync(examInfo);
                return await _sqlServerContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       public async Task<CheckExamViewModel> CheckExamAvailability(QuestionRequest question)
        {

            try
            {
                int check = _sqlServerContext.Exam.Where(x => x.ClassId == question.ClassId && x.Completed == false).Count();
                int ExamId = _sqlServerContext.Exam.Where(x => x.ClassId == question.ClassId && x.Completed == false).Select(x => x.Id).FirstOrDefault();
                int CheckInExamInfo = _sqlServerContext.ExamInfo.Where(x => x.ExamId == ExamId && x.StudentId == question.StudentId).Count();
                
                if(CheckInExamInfo > 0)
                {
                    check = 0;
                    ExamId = 0;
                }
                return new CheckExamViewModel { ExamId = ExamId, Count = check };
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<int>CreateExam(Exam exam)
        {
            await _sqlServerContext.Exam.AddAsync(exam);
            return await _sqlServerContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Class>> LoadAllClasses()
        {
            try
            {
                IEnumerable<Class> c = _sqlServerContext.ClassInfo.Select(x => new Class
                {
                    Id = x.Id,
                    Name = x.Name

                }).ToList();
                return c;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IEnumerable<Exam>> LoadAllExam()
        {
            try
            {
                IEnumerable<Exam> e = _sqlServerContext.Exam.Select(x => new Exam
                {
                    Id = x.Id,
                    ClassId = x.ClassId,
                    Completed = x.Completed,
                    QuestionName = x.QuestionName,
                    StartTime = x.StartTime
                }).ToList();
                return e;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


       public async Task<List<LoadQuestionViewModel>> LoadQuestionForExam(QuestionRequest question)
        {
           


            var x = from t1 in _sqlServerContext.Questions
                    from t2 in _sqlServerContext.Exam.Where(x => t1.Name == x.QuestionName && Convert.ToInt32(t1.ClassId) == x.ClassId && x.Id==question.ExamId)

                    select new LoadQuestionViewModel
                    {
                        Id = t1.Id,
                        Name = t2.QuestionName,
                        FirstOption = t1.FirstOption,
                        SceondOption = t1.SceondOption,
                        ThirdOption = t1.ThirdOption,
                        FourthOption = t1.FourthOption,
                        Answer = t1.Answer,
                        Title=t1.Title,
                        StartTime=t2.StartTime,
                        EndTime=t2.EndTime,
                        ExamId=t2.Id
          
                    };
            return x.ToList();



        }

        public async Task<List<MarksViewModel>> LoadAllmarks(LoadMarksViewModel marksViewModel)
        {



            var x = from t1 in _sqlServerContext.ExamInfo
                    from t2 in _sqlServerContext.Students.Where(x => t1.StudentId == x.Id && t1.ExamId == marksViewModel.ExamId)

                    select new MarksViewModel
                    {
                        StudentId = t1.Id,
                        StudentName = t2.Name,
                        Marks = t1.Marks,
                        TotalMarks = t1.TotalMarkS

                    };
            return x.ToList();



        }

        public async Task<ExamInfo> SaveExamInfo(ExamInfo examInfo)
        {
            await _sqlServerContext.ExamInfo.AddAsync(examInfo);
            await _sqlServerContext.SaveChangesAsync();
            return examInfo;
        }



    }
}
