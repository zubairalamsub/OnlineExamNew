using Microsoft.EntityFrameworkCore;
using OnlineExam.Entity;
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

    }
}
