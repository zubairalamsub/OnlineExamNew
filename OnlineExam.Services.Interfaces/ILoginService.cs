using OnlineExam.Entity;
using OnlineExam.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Student> UserRegister(Student student);
        Task<Teacher> GetAllTeacher(loginViewModel loginViewModel);
    }
}
