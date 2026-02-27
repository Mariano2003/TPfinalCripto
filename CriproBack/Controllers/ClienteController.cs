using CriproBack.DTOs;       
using   CriproBack.Models;      
using Microsoft.AspNetCore.Mvc;  
using Microsoft.EntityFrameworkCore; 

namespace CriproBack.Controllers
{
    [Route("api/[controller]")]  
    [ApiController]               
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;  

       
        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]  
        public async Task<ActionResult<IEnumerable<ClienteReadDto>>> Get()
        {
            
            var clientes = await _context.Clientes.ToListAsync();

           
            var clienteDtos = clientes.Select(c => new ClienteReadDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Email = c.Email
            }).ToList();

       
            return Ok(clienteDtos);
        }

        // GET: api/clientes/id
        [HttpGet("{id}")] 
        public async Task<ActionResult<ClienteReadDto>> Get(int id)
        {
          
            var cliente = await _context.Clientes.FindAsync(id);

           
            if (cliente == null)
                return NotFound();

           
            var dto = new ClienteReadDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Email = cliente.Email
            };

           
            return Ok(dto);
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<ClienteReadDto>> Post(ClienteCreateDto dto)
        {
           
            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                Email = dto.Email
            };

            
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

           
            var clienteDto = new ClienteReadDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Email = cliente.Email
            };

           
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, clienteDto);
        }

        // PUT: api/clientes/id
        [HttpPut("{id}")] 
        public async Task<IActionResult> Put(int id, ClienteUpdateDto dto)
        {
          
            var cliente = await _context.Clientes.FindAsync(id);

         
            if (cliente == null)
                return NotFound();

          
            cliente.Nombre = dto.Nombre;
            cliente.Email = dto.Email;

           
            await _context.SaveChangesAsync();

       
            return NoContent();
        }

        // DELETE: api/clientes/id
        [HttpDelete("{id}")] 
        public async Task<IActionResult> Delete(int id)
        {
           
            var cliente = await _context.Clientes.FindAsync(id);

           
            if (cliente == null)
                return NotFound();

            
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            
            return NoContent();
        }
    }
}