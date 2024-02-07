using Kreta.Backend.Repos;
using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models.SchoolCitizens;
using Kreta.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private IStudentRepo _studentRepo;

        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            Student? entity = new();
            if (_studentRepo is not null)
            {
                entity = await _studentRepo.FindByCondition(entity => entity.Id == id).FirstOrDefaultAsync();
                if (entity != null)
                    return Ok(entity.ToDto());
                else
                    return Ok(new Student().ToDto());
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllAsync()
        {
            List<Student>? entities = new();

            if (_studentRepo != null)
            {
                entities = await _studentRepo.FindAll().ToListAsync();
                return Ok(entities.Select(entity => entity.ToDto()));
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateAsync(StudentDto entity)
        {
            ControllerResponse response = new();
            if (_studentRepo is not null)
            {
                response = await _studentRepo.UpdateAsync(entity.ToModel());
                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                    response.ClearAndAddError("Az adatok módosítása nem sikerült!");
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az adatok frissítés nem lehetséges!");
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudendAsync(Guid id)
        {
            ControllerResponse response = new();
            if (_studentRepo is not null)
            {
                response = await _studentRepo.DeleteAsync(id);
                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                    response.ClearAndAddError("Az  adatok törlése nem sikerült!");
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az adatok törlése nem lehetséges!");
            return BadRequest(response);
        }

        [HttpPost()]
        public async Task<IActionResult> InsertStudentAsync(StudentDto student)
        {
            ControllerResponse response = new();
            if (_studentRepo is not null)
            {
                response = await _studentRepo.CreateAsync(student.ToModel());
                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az új adatok mentése nem lehetséges!");
            return BadRequest(response);
        }
    }
}
