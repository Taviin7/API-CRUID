using API_CRUD.DAO;
using API_CRUD.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotoController : ControllerBase
    {

        [HttpGet]
        public IActionResult Listar()
        {
            PilotoDAO dao = new PilotoDAO();
            var pilotos = dao.Listar();
            return Ok(pilotos);
        }

        [HttpPost]
        public IActionResult Cadastrar(PilotoDTO piloto)
        {
            PilotoDAO dao = new PilotoDAO();
            dao.Cadastrar(piloto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar(PilotoDTO piloto)
        {
            PilotoDAO dao = new PilotoDAO();
            dao.Alterar(piloto);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Remover(int id)
        {
            PilotoDAO dao = new PilotoDAO();
            dao.Remover(id);
            return Ok();
        }
    }
}