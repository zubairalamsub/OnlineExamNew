using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Entity;
using OnlineExam.Entity.ViewModel;

namespace OnlineExam.Entity.Interfaces
{
    public interface ILoginRepository
    {
        Task<Student> UserRegister(Student courierUsers);
        Task<Teacher> GetAllTeacher(loginViewModel loginViewModel);
        Task<Teacher> TeacherRegister(Teacher teacher);
        Task<IEnumerable<Teacher>> LoadAllTeacher();
    }
}
