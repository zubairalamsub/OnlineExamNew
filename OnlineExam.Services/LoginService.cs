using Microsoft.AspNetCore.Http;
using OnlineExam.Entity;
using OnlineExam.Entity.Interfaces;
using OnlineExam.Entity.ViewModel;
using OnlineExam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Services
{
    public class LoginService : ILoginService
    {

        private readonly ILoginRepository _loginRepository;
       
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
          
        }

        public async Task< List<Student>> UserRegister(StudentVM student)
        {
            List<Student> st = new List<Student>();
            for(int i=0;i<student.NoOfStudent;i++)
            {
                st.Add(new Student { Name = "", Password = "", UserName = "", PhoneNumber = "", ClassId = student.ClassId,IsValid=1 });
            }
           

            var data = await _loginRepository.UserRegister(st);
            return data;
        }
        public async Task<Teacher> TeacherRegister(Teacher teacher)
        {

            var data = await _loginRepository.TeacherRegister(teacher);
            return data;
        }
        public async Task<Teacher> GetAllTeacher(loginViewModel loginViewModel)
        {

            var data = await _loginRepository.GetAllTeacher(loginViewModel);
            return data;
        }
        public async Task<Student> GetAllStudent(loginViewModel loginViewModel)
        {

            var data = await _loginRepository.GetAllStudent(loginViewModel);
            return data;
        }

        public async Task<IEnumerable<Teacher>> LoadAllTeacher()
        {
            var data= await _loginRepository.LoadAllTeacher();
            return data;
        }
        public async Task<Student> UpdateStudent(Student student)
        {

            var data = await _loginRepository.UpdateStudent(student);
            return data;
        }
        public async Task<Student> CheckLinkValidity(Student student)
        {

            var data = await _loginRepository.CheckLinkValidity(student);
            return data;
        }

        




    }
}
