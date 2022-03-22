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

        public async Task<Student> UserRegister(Student student)
        {
  
            var data = await _loginRepository.UserRegister(student);
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

        public async Task<IEnumerable<Teacher>> LoadAllTeacher()
        {
            var data= await _loginRepository.LoadAllTeacher();
            return data;
        }




    }
}
