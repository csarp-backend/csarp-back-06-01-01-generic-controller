using Kreta.Backend.Controllers.Assamblers;
using Kreta.Backend.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Controllers
{
    public abstract class BaseController<Tmodel, TDto> : ControllerBase
        where Tmodel : class, new()
        where TDto : class,new()
    {
        private Assambler<Tmodel,TDto> _assembler;
        private IRepositoryBase<Tmodel> _repo;

        public BaseController(Assambler<Tmodel, TDto> assembler, IRepositoryBase<Tmodel> repo)
        {
            _assembler = assembler;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllAsync()
        {
            List<Tmodel>? entities = new();

            if (_repo != null)
            {
                entities = await _repo.FindAll().ToListAsync();
                return Ok(entities.Select(entity =>  _assembler.ToDto(entity)));
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }
    }
}
