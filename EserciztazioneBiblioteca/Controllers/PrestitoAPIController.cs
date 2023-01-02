using EserciztazioneBiblioteca.Data;
using EserciztazioneBiblioteca.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EserciztazioneBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestitoAPIController : ControllerBase
    {
        private readonly EserciztazioneBibliotecaContext _context;

        public PrestitoAPIController(EserciztazioneBibliotecaContext context)
        {
            _context = context;
        }


        // GET: api/<PrestitoAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PrestitoAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PrestitoAPIController>
        [HttpPost("Create")]
        [Produces("application/json")]
        public async Task<ActionResult> Post(Prestito prestito)
        {

            _context.Prestito.Add(prestito);
            var isSuccessfull = await _context.SaveChangesAsync();
            if(isSuccessfull>0)
            {
                return Ok("WE UAGLIO");
            }
            return BadRequest("NO NON VA BENE");
        }

        [HttpPost("Edit")]

        public async Task<ActionResult> Edit(Prestito prestito)
        {
            _context.Prestito.Update(prestito);
            var editSuccessfull = await _context.SaveChangesAsync();

            if(editSuccessfull>0)
            {
                return Ok("i dati sono stati caricati in modo corretto");
            } else
            {
                return BadRequest("errore durante il caricamento dei dati");
            }
        }

        // PUT api/<PrestitoAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }



        // DELETE api/<PrestitoAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
