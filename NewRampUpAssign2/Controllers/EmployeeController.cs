using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewRampUpAssign2.Interface;
using NewRampUpAssign2.Models;

namespace NewRampUpAssign2.Controllers
{
   //[Authorize]
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _IEmployee;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployee IEmployee, IMapper mapper)
        {
            _IEmployee = IEmployee;
            _mapper = mapper;
        }

        // GET: api/employee>

        [HttpGet]
        public async Task<ActionResult<List<EmpData>>> GetEmployeeDetails()
        {
            /*             var employee= await Task.FromResult(_IEmployee.GetEmployeeDetails());
            */
            var employees = await _IEmployee.GetEmployeeDetails();
            var records = _mapper.Map<List<EmpData>>(employees);
            return Ok(records);


        }

        // GET api/employee/

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpData>> GetEmployeeDetails(int id)
        {
            var employees = await _IEmployee.GetEmployeeDetails(id);
            if (employees == null)
            {
                return NotFound();
                //throw new Exception("This EmpId is not valid.");
            }
            var employee = _mapper.Map<EmpData>(employees);
            return Ok(employee);
        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(EmpData empData)
        {
            var employee = _mapper.Map<Employee>(empData);
            await _IEmployee.AddEmployee(employee);
            return employee;
        }

        // PUT api/employee/

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmpData empData)
        {
            int empId = empData.Id;

            var records = await _IEmployee.GetEmployeeDetails(empId);

            if (records == null)
            {
                throw new Exception($"empId not found.");
            }

            _mapper.Map(empData, records);

            try
            {
                await _IEmployee.UpdateEmployee(records);
            }
            catch (Exception)
            {
                throw new Exception("Error occured while updating empId");
            }

            return Ok("Employee Details Updated");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _IEmployee.DeleteEmployee(id);
            return Ok("Employee Deleted");
        }
    }
}