using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taiwo_clearwox_backend_codechalleneg.Interfaces;
using taiwo_clearwox_backend_codechalleneg.Models;

namespace taiwo_clearwox_backend_codechalleneg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("{Search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await employeeRepository.Search(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                var result = Ok(await employeeRepository.GetEmployees());
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetEmployee(int id)
        {
            try
            {
                var request = await employeeRepository.GetEmployee(id);
                var response = Ok(await employeeRepository.GetEmployee(id));
                if (request == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }
                else if (request != null)
                {
                    return response;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                //var result = Ok(await employeeRepository.GetEmployee(id));
                if (employee == null)
                {
                    return BadRequest();
                }

                var emp = employeeRepository.GetEmployeeByEmail(employee.Email);
                if (emp == null)
                {
                    var request = await employeeRepository.AddEmployee(employee);
                    var result = CreatedAtAction(nameof(GetEmployee), new { id = request.EmployeeId },
                        request);
                    return result;
                }
                else
                {
                    ModelState.AddModelError("email", "Employee email already in use");
                    return BadRequest(ModelState);

                }


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {

                if (id != employee.EmployeeId)
                {
                    return BadRequest("EmployeeId Mismatch");
                }
                else
                {
                    var request = Ok(await employeeRepository.GetEmployee(id));
                    if (request == null)
                    {
                        return NotFound($"Employee with Id = {id} not found");
                    }
                    return await employeeRepository.UpdateEmployee(employee);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data on the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var request = Ok(await employeeRepository.GetEmployee(id));
                if (request == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await employeeRepository.DeleteEmployee(id);



            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting data from the database");
            }
        }





    }
}
