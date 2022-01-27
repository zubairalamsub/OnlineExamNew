using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.DAL
{
    public class OnlineExamContext : DbContext
    {

        public OnlineExamContext(DbContextOptions<OnlineExamContext> options) : base(options)
        {

        }


    }
}
