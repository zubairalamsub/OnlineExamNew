using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OnlineExam.Entity;
using OnlineExam.Entity.ViewModel;
using OnlineExam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OnlineExam.Controllers
{
    public class TeacherController : Controller
    {

		private readonly ITeacherService _techerService;

		public TeacherController(ITeacherService teacherService)
		{
			_techerService = teacherService;

		}
		public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadQuestion()
        {
			int teacherId = GetTeacherIdFromCookie();
			if (teacherId > 0)
			{
				return View();
			}
			else
			{
				return RedirectToAction("TeacherLogin", "Home");
			}

		}
	    public IActionResult CreateStudentId()
        {
			int teacherId = GetTeacherIdFromCookie();
			if (teacherId > 0)
            {
				return View();
            }
			else
            {
				return RedirectToAction("TeacherLogin", "Home");
            }

		
        }
        public int GetTeacherIdFromCookie()
        {
			try
			{
				var userid = Convert.ToInt32(ControllerContext.HttpContext.Request.Cookies["Id"]);
				return userid;
			}
			catch (Exception ex)

			{

				throw ex;
			}
        }
        public int GetStudentIdFromSession()
        {
            return Convert.ToInt32(HttpContext.Session.GetString("StudentId"));
        }


        [HttpGet]
		[Route("api/LoadAllClass")]
		[ProducesResponseType(200)]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> loadAllClass()
		{
			var response = new ListResponseModel<Class>();

			try
			{

				var data = await _techerService.LoadAllClasses();
				response.Model = data;
			}
			catch (Exception exp)
			{
				response.DidError = true;
				response.ErrorMessage = "There was an internal error, please contact to technical support.";
			}

			return response.ToHttpResponse();
		}

		[HttpGet]
		[Route("api/LoadAllQuestionName")]
		[ProducesResponseType(200)]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> LoadAllQuestionName()
		{
			var response = new ListResponseModel<Class>();

			try
			{

				var data = await _techerService.LoadAllClasses();
				response.Model = data;
			}
			catch (Exception exp)
			{
				response.DidError = true;
				response.ErrorMessage = "There was an internal error, please contact to technical support.";
			}

			return response.ToHttpResponse();
		}



		[HttpPost]
		[Route("api/CheckExamAvailability")]
		[ProducesResponseType(200)]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> CheckExamAvailability([FromBody] QuestionRequest question)
		{
			var response = new SingleResponseModel<CheckExamViewModel>();

			try
			{
				var data = await _techerService.CheckExamAvailability(question);
				response.Model = data;
			}
			catch (Exception exp)
			{
				response.DidError = true;
				response.ErrorMessage = "There was an internal error, please contact to technical support.";
			}

			return response.ToHttpResponse();
		}




		public async Task<int> UploadExcel(IFormFile file)
		{
			var Sheet1 = new List<Questions>();
		
			int result = 0;
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using (var stream = new MemoryStream())
			{
				file.CopyTo(stream);
				using (var package = new ExcelPackage(stream))
				{
					ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
					
					var rowCount = worksheet.Dimension.Rows;
					for (var row = 2; row <= rowCount; row++)
					{
						Sheet1.Add(new Questions
						{
							Name = worksheet.Cells[row, 1].Value.ToString().Trim(),
							Title = worksheet.Cells[row, 2].Value.ToString().Trim(),
							FirstOption = worksheet.Cells[row, 3].Value.ToString().Trim(),
							SceondOption = worksheet.Cells[row,4].Value.ToString().Trim(),
							ThirdOption=worksheet.Cells[row,5].Value.ToString().Trim(),
							FourthOption=worksheet.Cells[row,6].Value.ToString().Trim(),	
							Answer= worksheet.Cells[row, 7].Value.ToString().Trim(),
							ClassId=worksheet.Cells[row,8].Value.ToString().Trim(),
						});
					}
					

				}
			}
		
			
			var first = await  _techerService.UploadQuestion(Sheet1);
		
			return result;
		}

		public IActionResult AssignClassToteacher()
		{
			int teacherId = GetTeacherIdFromCookie();
			if (teacherId > 0)
			{
				return View();
			}
			else
			{
				return RedirectToAction("TeacherLogin", "Home");
			}


		}

		[HttpPost]

		[Route("api/Assignteacher")]

		[Route("api/AssignTeacherToClass")]
		[ProducesResponseType(200)]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> TeacherRegister([FromBody] AssignClass assignClass)
		{
			var response = new SingleResponseModel<int>();

			try
			{

				var data = await _techerService.AssignTeacherToClass(assignClass);
				response.Model = data;
			}
			catch (Exception exp)
			{
				response.DidError = true;
				response.ErrorMessage = "There was an internal error, please contact to technical support.";
			}

			return response.ToHttpResponse();
		}

		public async Task<IActionResult> AssignTeacherToClass([FromBody] AssignClass assign)
		{
			var response = new SingleResponseModel<int>();

			try
			{
				var data = await _techerService.AssignTeacherToClass(assign);
				response.Model = data;
			}
			catch (Exception exp)
			{
				response.DidError = true;
				response.ErrorMessage = "There was an internal error, please contact to technical support.";
			}
			return response.ToHttpResponse();
		}

		[HttpPost]
		[Route("api/SaveExamFnfo")]
		[ProducesResponseType(200)]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> SaveExamFnfo([FromBody] ExamInfo examInfo)
		{
			var response = new SingleResponseModel<int>();

			try
			{
				var data = await _techerService.SaveExamFnfo(examInfo);
				response.Model = data;
			}
			catch (Exception exp)
			{
				response.DidError = true;
				response.ErrorMessage = "There was an internal error, please contact to technical support.";
			}

			return response.ToHttpResponse();
		}


		//public IActionResult Exam()
		//      {

		//	return View();
		//      }

		[HttpPost]
		[Route("api/CreateNewExam")]
		[ProducesResponseType(200)]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> CreateNewExam([FromBody] Exam exam)
		{
			var response = new SingleResponseModel<int>();

			try
			{

				var data = await _techerService.CreateNewExam(exam);
				response.Model = data;
			}
			catch (Exception exp)
			{
				response.DidError = true;
				response.ErrorMessage = "There was an internal error, please contact to technical support.";
			}

			return response.ToHttpResponse();
		}



		public IActionResult CreateExam()
        {
			int teacherId = GetTeacherIdFromCookie();
			if (teacherId > 0)
			{
				return View();
			}
			else
			{
				return RedirectToAction("TeacherLogin", "Home");
			}

		}

		[HttpPost]
		[Route("api/LoadQuestionForExam")]
		[ProducesResponseType(200)]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> LoadQuestionForExam([FromBody] QuestionRequest question)
		{
			var response = new ListResponseModel<LoadQuestionViewModel>();

			try
			{
				var data = await _techerService.LoadQuestionForExam(question);
				response.Model = data;
			}
			catch (Exception exp)
			{
				response.DidError = true;
				response.ErrorMessage = "There was an internal error, please contact to technical support.";
			}

			return response.ToHttpResponse();
		}


		[HttpPost]
		[Route("api/LoadAllmarks")]
		[ProducesResponseType(200)]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> LoadAllmarks([FromBody] LoadMarksViewModel marks)
		{
			var response = new ListResponseModel<MarksViewModel>();

			try
			{
				var data = await _techerService.LoadAllmarks(marks);
				response.Model = data;
			}
			catch (Exception exp)
			{
				response.DidError = true;
				response.ErrorMessage = "There was an internal error, please contact to technical support.";
			}

			return response.ToHttpResponse();
		}

		[HttpPost]
		[Route("api/SubmitMarks")]
		[ProducesResponseType(200)]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> SubmitMarks([FromBody] List<ExamInfoViewModel> examInfoViewModel)
		{
			var response = new SingleResponseModel<ExamInfo>();

			try
			{
				var data = await _techerService.SubmitMarks(examInfoViewModel);
				response.Model = data;
			}
			catch (Exception exp)
			{
				response.DidError = true;
				response.ErrorMessage = "There was an internal error, please contact to technical support.";
			}

			return response.ToHttpResponse();
		}


		public IActionResult ShowMarksClassWise()


        {
            return View();
        }



		[HttpGet]
		[Route("api/LoadAllExam")]
		[ProducesResponseType(200)]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> LoadAllExam()
		{
			var response = new ListResponseModel<Exam>();

			try
			{

				var data = await _techerService.LoadAllExam();
				response.Model = data;
			}
			catch (Exception exp)
			{
				response.DidError = true;
				response.ErrorMessage = "There was an internal error, please contact to technical support.";
			}

			return response.ToHttpResponse();
		}




	}

}

