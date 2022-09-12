using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineExam.Entity
{
    [Table("Student", Schema = "dbo")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public int ClassId { get; set; } = 0;
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
       

    }

    public class StudentVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public int ClassId { get; set; } = 0;
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public int NoOfStudent { get; set; } = 0;

    }


}
