using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationAPI.Interface;
using PatientInformationAPI.Models;
using Microsoft.Extensions.Hosting;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInformationController : ControllerBase
    {
        private readonly IDapperService _dapper;
        public PatientInformationController(IDapperService dapper)
        {
            {
                _dapper = dapper;
            }
           // return new string[] { "value1", "value2" };
        }

        // GET api/<PatientInformationController>/5
        [HttpGet("{idno}")]
        public Task<List<PatientInformation>> Get()
        {
            var tasks = _dapper.GetAll();
            return tasks;
        }

        // POST api/<PatientInformationController>
        [HttpPost]
        public async Task<string> Post([FromBody] PatientInformation patientInformation)
        {
            var task = await _dapper.CreateTask(patientInformation);
            return task;
        }

        // PUT api/<PatientInformationController>/5
        [HttpPut("{idno}")]
        public async Task<string> Put(int idno, [FromBody] PatientInformation repository)
        {
            var task = await _dapper.UpdateTask(repository);
            return task;
        }

        // DELETE api/<PatientInformationController>/5
        [HttpDelete("{idno}")]
        public async Task<string> Delete(int idno)
        {
            var response = await _dapper.DeleteTask(idno);
            return response;
        }

    }
}
