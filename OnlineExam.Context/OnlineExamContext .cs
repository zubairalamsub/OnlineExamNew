using Microsoft.EntityFrameworkCore;
using OnlineExam.Entity;
using OnlineExam.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Context
{
    public class OnlineExamContext:DbContext
    {
        public OnlineExamContext(DbContextOptions<OnlineExamContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<AssignClass> AssignTeacher { get; set; }
        public DbSet<ClassInfo> ClassInfo { get; set; }

    }
}
