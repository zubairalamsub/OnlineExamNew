﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Entity;
using OnlineExam.Entity.ViewModel;
using OnlineExam.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OnlineExam.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        [Route("UserRegister")]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UserRegister([FromBody] Student student)
        {
            var response = new SingleResponseModel<Student>();

            try
            {

                var data = await _loginService.UserRegister(student);
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
        public async Task<bool> Index([FromBody] loginViewModel userlogIn)
        {
            try
            {
                var user = await _loginService.GetAllTeacher(userlogIn);
                if (user != null)
                {

                    HttpContext.Session.SetInt32("Id", user.Id);
                    HttpContext.Session.SetString("UserName", user.UserName);
                    HttpContext.Session.SetString("Password", user.Password);
                    HttpContext.Session.SetInt32("AdminType", Convert.ToInt32( user.AdminType));
                    HttpContext.Session.SetString("LoginType", "Teacher");
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddMinutes(1000);
                    Response.Cookies.Append("Id", user.Id.ToString(), option);
                    Response.Cookies.Append("UserName", user.UserName, option);
                    Response.Cookies.Append("Password", user.Password, option);
                    Response.Cookies.Append("AdminType", user.AdminType.ToString(), option);
                    Response.Cookies.Append("LoginType", "Teacher", option);
                    Response.Cookies.Append("dtfullname", user.Name, option);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


    }
}