using OnlineExam.Context;
using OnlineExam.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class StudentRepository : IstudentReposetory
    {
        private readonly OnlineExamContext _sqlServerContext;
        public StudentRepository(OnlineExamContext onlineExamContext)
        {
            _sqlServerContext = onlineExamContext ?? throw new ArgumentNullException(nameof(onlineExamContext));
        }
    }
}
