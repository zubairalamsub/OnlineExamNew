using OnlineExam.Context;
using OnlineExam.Entity;
using OnlineExam.Entity.Interfaces;
using OnlineExam.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class LoginRepository : ILoginRepository
    {

        private readonly OnlineExamContext _sqlServerContext;
        public LoginRepository(OnlineExamContext onlineExamContext)
        {
            _sqlServerContext = onlineExamContext ?? throw new ArgumentNullException(nameof(onlineExamContext));
        }

       
        public async Task<Student> UserRegister(Student courierUsers)
        {
            await _sqlServerContext.Students.AddAsync(courierUsers);
            await _sqlServerContext.SaveChangesAsync();
            return courierUsers;

        }

        public async Task<Teacher> TeacherRegister(Teacher teacher)
        {


            try
            {
                await _sqlServerContext.Teacher.AddAsync(teacher);
                await _sqlServerContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return teacher;
        }
        public async Task<Teacher> GetAllTeacher(loginViewModel loginViewModel)
        {

            var teacher = _sqlServerContext.Teacher.Where(a=> a.UserName == loginViewModel.UserName
             && a.Password.Equals(loginViewModel.Password)).Select(x=> new Teacher
             {
                 Id= x.Id,
                 AdminType= x.AdminType,
                 Email= x.Email,
                 Name= x.Name,
                 Password= x.Password,
                 PhoneNumber= x.PhoneNumber,
                 PostedOn= x.PostedOn,
                 UserName=x.UserName
             }).FirstOrDefault();
            return teacher;

        }

        public async Task<IEnumerable<Teacher>> LoadAllTeacher()
        {
            try
            {
                IEnumerable<Teacher> teachers = _sqlServerContext.Teacher.Select(x => new Teacher
                {
                    Id = x.Id,
                    AdminType = x.AdminType,
                    Email = x.Email,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    PostedOn = x.PostedOn,
                    UserName = x.UserName

                }).ToList();
                return teachers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
