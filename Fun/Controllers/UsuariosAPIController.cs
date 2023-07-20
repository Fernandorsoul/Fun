
using Fun.Data;
using Fun.Models;
using Fun.Repositories;
using Fun.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fun.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosAPIController : ControllerBase
    {
        private readonly FunContext _context;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuariosAPIController(FunContext context, IUsuarioRepositorio usuarioRepositorio)
        {
            _context = context;
            _usuarioRepositorio = usuarioRepositorio;
        }       
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioModel>> BuscarUsuarios()
        {
            var usuarios = _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }


        [HttpGet("{id:int}",Name = "BuscarUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UsuarioModel> BuscarPorId(int id)
        {
            var usuario = _usuarioRepositorio.BuscarPorId(id);
            if(usuario == null)
            {
                return NotFound($"O usuário com o ID '{id}' não foi encontrado.");
            }
            return Ok(usuario);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UsuarioModel> Adicionar([FromBody] UsuarioModel usuario)
        {
            if (_context.Usuarios.FirstOrDefault(u => u.Nome.ToLower() == usuario.Nome.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError","Usuario ja existente!");
                return BadRequest(ModelState);
            }

            if(usuario == null)
            {
                return BadRequest(usuario);
            }
            if(usuario.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            usuario.Id = _context.Usuarios.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok(usuario);

            
        }
        


    }
}
