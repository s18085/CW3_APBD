using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CW3.DAL;
using CW3.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CW3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public StudentsController(IDbService ser)
        {
            _dbService = ser;
        }
        [HttpGet]
        public IActionResult GetStudent(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }
        // POST api/values
        [HttpPost]
        public IActionResult CreateStudent(Student  st)
        {
            st.IndexNb = $"s{new Random().Next(1, 20000)}";
            return Ok(st);
        }

        // PUT api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok($"Usuwanie ukończone dla Id: {id}");
        }

        // DELETE api/values/5
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            return Ok($"Aktualizacja dokończona dla Id: {id}");
        }
    }
}
