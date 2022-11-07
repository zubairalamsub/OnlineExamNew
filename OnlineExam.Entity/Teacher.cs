using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Entity
{
    public class Teacher
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public bool AdminType { get; set; }
		public DateTime PostedOn { get; set; } = DateTime.Today;
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
        public int IsApproved { get; set; }
    }
}
