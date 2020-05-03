using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using School.WebApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using School.DataAccess.UnitOfWorks;
using School.Services;
using System.Net;
using School.WebApi.Models;
using AutoMapper;

namespace School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        private IStudentService _studentService;

        private IMapper _mapper;

        /// <summary>
        /// Constructor, initializes an instance of <see cref="StudentController"/>
        /// </summary>
        /// <param name="unitOfWork"></param>
        public StudentController(IUnitOfWork unitOfWork, IStudentService studentService, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._studentService = studentService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            HttpStatusCode status = HttpStatusCode.OK;
            Response<IEnumerable<Student>> response = new Response<IEnumerable<Student>>();

            try
            {
                IEnumerable<DataAccess.Entities.Student> studentEnumerable = await _studentService.GetAllStudents().ConfigureAwait(false);
                List<Student> studentModelEnumerable = new List<Student>();

                studentEnumerable.Cast<DataAccess.Entities.Student>().ToList().ForEach(student =>
                { 
                    Student studentModel = _mapper.Map<DataAccess.Entities.Student,Student>(student);
                    studentModelEnumerable.Add(studentModel);
                });

                response.ErrorMessage = string.Empty;
            }
            catch(ArgumentException argumentException)
            {
                response.ErrorMessage = argumentException.Message;
                status = HttpStatusCode.BadRequest;
            }
            catch(Exception exception)
            {
                response.ErrorMessage = exception.Message;
                status = HttpStatusCode.InternalServerError;
            }

            return new ObjectResult(response)
            {
                StatusCode = (int) status
            };
        }

        [HttpPost("create")]

        public async Task<IActionResult> CreateStudent ([FromBody] Student student)
        {
            HttpStatusCode status = HttpStatusCode.OK;
            Response<Student> response = new Response<Student>();

            try
            {
                await _studentService.AddNewStudent(_mapper.Map<Student, DataAccess.Entities.Student>(student));
                response.Model = student;
                response.ErrorMessage = string.Empty;
            }
            catch (ArgumentException argumentException)
            {
                response.ErrorMessage = argumentException.Message;
                status = HttpStatusCode.BadRequest;
            }
            catch (Exception exception)
            {
                response.ErrorMessage = exception.Message;
                status = HttpStatusCode.InternalServerError;
            }

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
    }
}