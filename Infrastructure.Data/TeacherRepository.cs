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



    }
}
