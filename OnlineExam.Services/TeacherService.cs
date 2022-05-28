using OnlineExam.Entity;
using OnlineExam.Entity.Interfaces;
using OnlineExam.Entity.ViewModel;
using OnlineExam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Services
{
    public class TeacherService: ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;

        }

        public async Task<int> UploadQuestion(List<Questions> questins)
        {

            var data = await _teacherRepository.UploadQuestion(questins);
            return data;
        }

       public async Task<IEnumerable<Class>> LoadAllClasses()
        {
            var data=await _teacherRepository.LoadAllClasses();
            return data;
        }

       public async Task<int> AssignTeacherToClass(AssignClass assignTeacher)
        {

            var data = await _teacherRepository.AssignTeacherToClass(assignTeacher);
            return data;

        }


    }
}
