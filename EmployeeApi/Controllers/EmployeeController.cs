using System.Threading.Tasks;
using EmployeeApi.DAL.Entities;
using EmployeeApi.Dtos;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var point = await _employeeService.GetByIdAsync(id);
            return Ok(point);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeCreationDto employee)
        {
            return Ok(await _employeeService.CreateAsync(employee));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeEditDto employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            return Ok(await _employeeService.UpdateAsync(employee));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);

            return NoContent();
        }
    }
}
