﻿using OnlineExam.Entity;
using OnlineExam.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;





namespace OnlineExam.Services.Interfaces
{
    public interface ILoginService
    {
        Task<List<Student>> UserRegister(StudentVM student);
        Task<Teacher> GetAllTeacher(loginViewModel loginViewModel);
        Task<List<Teacher>> GetAllUnApprovedTeacher();
        Task<Teacher> TeacherRegister(Teacher teacher);
        Task<IEnumerable<Teacher>> LoadAllTeacher();
        Task<Student> UpdateStudent(Student student);
        Task<Student> CheckLinkValidity(Student student);
        Task<Student> GetAllStudent(loginViewModel loginViewModel);
        Task<Teacher> UpdateTeacher(Teacher teacher);
        Task<Teacher> GetAllAdmin(loginViewModel loginViewModel);



    }
}
