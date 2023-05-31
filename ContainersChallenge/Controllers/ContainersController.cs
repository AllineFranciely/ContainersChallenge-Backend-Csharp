using System.ComponentModel;
using ContainersChallenge.Context;
using ContainersChallenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Container = ContainersChallenge.Models.Container;

namespace ContainersChallenge.Controllers
{
    [Route("containers")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContainersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("movimentacoes")]
        public ActionResult<IEnumerable<Container>> GetCategoriesProducts()
        {
            try
            {
                return _context.Containers.Include(p => p.Movimentacoes).Where(c => c.ContainerId <= 5).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Container>> Get()
        {
            try
            {
                return _context.Containers.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação");
            }
        }

        [HttpGet("{id:int}", Name = "ObterContainer")]
        public ActionResult<Container> Get(int id)
        {
            var container = _context.Containers.FirstOrDefault(p => p.ContainerId == id);
            if (container is null)
            {
                return BadRequest("Container não encontrado");
            }
            return container;
        }

        [HttpPost]
        public ActionResult Post(Container container)
        {
            if (container is null)
                return BadRequest();

            _context.Containers.Add(container);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterContainer",
                new { id = container.ContainerId }, container);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Container container)
        {
            if (id != container.ContainerId)
            {
                return BadRequest();
            }
            _context.Entry(container).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(container);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var container = _context.Containers.FirstOrDefault(p => p.ContainerId == id);
            // var product = _contex.Products.Find(id);
            if (container is null)
            {
                return NotFound("Container não localizado");
            }

            _context.Containers.Remove(container);
            _context.SaveChanges();
            return Ok(container);
        }
    }
}
