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


       public async Task<List<LoadQuestionViewModel>> LoadQuestionForExam(QuestionRequest question)
        {
            //List<Questions> c = _sqlServerContext.Questions.Select(x => new Questions
            //{
            //    Id=x.Id,
            //    Name=x.Name,
            //    FirstOption=x.FirstOption,
            //    SceondOption=x.SceondOption,
            //    ThirdOption=x.ThirdOption,
            //    FourthOption=x.FourthOption,
            //    Answer=x.Answer,
            //    ClassId=x.ClassId,


            //}).ToList();
            //return c;


            //var studentInfo = from q in _sqlServerContext.Questions
            //                  join e in _sqlServerContext.Exam
            //                  on q.Name equals e.QuestionName  && q.ClassId equals question.ClassId
            //                  select new { student.student_name, student.student_city, course.course_name, course.course_desc };


            var x = from t1 in _sqlServerContext.Questions
                    from t2 in _sqlServerContext.Exam.Where(x => t1.Name == x.QuestionName && Convert.ToInt32(t1.ClassId) == x.ClassId && x.Id==question.ExamId)

                    select new LoadQuestionViewModel
                    {
                        Id = t1.Id,
                        Name = t1.Name,
                        FirstOption = t1.FirstOption,
                        SceondOption = t1.SceondOption,
                        ThirdOption = t1.ThirdOption,
                        FourthOption = t1.FourthOption,
                        Answer = t1.Answer,
                        Title=t1.Title,
                        StartTime=t2.StartTime,
                        EndTime=t2.EndTime

                    };
            return x.ToList();



        }



    }
}
