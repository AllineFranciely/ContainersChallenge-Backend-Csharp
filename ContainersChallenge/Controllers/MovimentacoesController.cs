using ContainersChallenge.Context;
using ContainersChallenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContainersChallenge.Controllers
{
    [Route("[movimentacoes]")]
    [ApiController]
    public class MovimentacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MovimentacoesController(AppDbContext _context)
        {
            _context = _context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Movimentacao>> Get()
        {
            var movimentacoes = _context.Movimentacoes.Take(10).ToList();
            if (movimentacoes is null)
            {
                return NotFound("Movimentações não encontradas");
            }
            return movimentacoes;
        }

        [HttpGet("{id.int}", Name = "ObterMovimentacao")]
        public ActionResult<Movimentacao> Get(int id)
        {
            var movimentacao = _context.Movimentacoes.FirstOrDefault(p => p.MovimentacaoId == id);
            if (movimentacao is null)
            {
                return BadRequest("Movimentação não encontrada");
            }
            return movimentacao;
        }

        [HttpPost]
        public ActionResult Post(Movimentacao movimentacao)
        {
            if (movimentacao is null)
                return BadRequest();

            _context.Movimentacoes.Add(movimentacao);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterMovimentacao",
                new { id = movimentacao.MovimentacaoId }, movimentacao);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Movimentacao movimentacao)
        {
            if (id != movimentacao.MovimentacaoId)
            {
                return BadRequest();
            }
            _context.Entry(movimentacao).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(movimentacao);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var movimentacao = _context.Movimentacoes.FirstOrDefault(p => p.MovimentacaoId == id);
            if (movimentacao is null)
            {
                return NotFound("Movimentação não localizada");
            }

            _context.Movimentacoes.Remove(movimentacao);
            _context.SaveChanges();
            return Ok(movimentacao);
        }
    }
}
