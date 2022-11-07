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
        Task<List<Student>> UserRegister(List<Student> students);
        Task<Teacher> GetAllTeacher(loginViewModel loginViewModel);
        Task<Teacher> TeacherRegister(Teacher teacher);
        Task<IEnumerable<Teacher>> LoadAllTeacher();
        Task<Student> UpdateStudent(Student student);
        Task<Student> CheckLinkValidity(Student student);
        
        Task<Student> GetAllStudent(loginViewModel loginViewModel);
        Task<Teacher> GetAllUnApprovedTeacher(loginViewModel loginViewModel);
    }
}
