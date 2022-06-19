using Infrastructure.Data;
using OnlineExam.Entity.Interfaces;
using OnlineExam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Services
{
    public class StudentService : IStudentService
    {

        private readonly IstudentReposetory _studentRepository;

        public StudentService(IstudentReposetory loginRepository)
        {
            _studentRepository = loginRepository;

        }
    }
}
