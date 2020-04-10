using System;
using System.Collections.Generic;
using CW3.DAL;
using CW3.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CW3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;
        private List<Student> stList;
        public StudentsController(IDbService ser)
        {
            _dbService = ser;
        }
        [HttpGet]
        public IActionResult GetStudent(string orderBy)
        {
            using (var con = new SqlConnection("Data Source=db_mssql;Initial Catalog=s18085;Integrated Security=true"))   
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText =   "select S.FirstName, S.LastName, S.BirthDate, St.Name, E.Semester" +
                                    "from Student S" +
                                    "inner join Enrollment E on E.IdEnrollment = S.IdEnrollment" +
                                    "inner join Studies St on St.IdStudy = E.IdStudy";
                con.Open();
                var dr = com.ExecuteReader();
                stList = new List<Student>();
                while (dr.Read())
                {
                    var st1 = new Student();
                    st1.FirstName = dr["S.FirstName"].ToString();
                    st1.LastName = dr["S.LastName"].ToString();
                    st1.BirthDate = dr["S.BirthDate"].ToString();
                    st1.StudiesName = dr["St.Name"].ToString();
                    st1.Semester = dr["E.Semester"].ToString();
                    stList.Add(st1);
                }
            }
            return Ok(stList);
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
