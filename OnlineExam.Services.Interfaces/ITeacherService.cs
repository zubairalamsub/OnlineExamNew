using OnlineExam.Entity;
using OnlineExam.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<int> UploadQuestion(List<Questions> questins);
        Task<IEnumerable<Class>> LoadAllClasses();

    }
}
