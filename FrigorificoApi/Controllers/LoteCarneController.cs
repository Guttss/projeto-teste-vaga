using Microsoft.AspNetCore.Mvc;
using FrigorificoApi.Data;
using FrigorificoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FrigorificoApi.Controllers;
[ApiController]
[Route("api/[controller]")] // O endpoint será: /api/lotecarne
public class LoteCarneController : ControllerBase
{
    private readonly AppDbContext _context;

    // Injeção de dependência do contexto do banco
    public LoteCarneController(AppDbContext context)
    {
        _context = context;
    }

    // Equivalente ao @GetMapping
    [HttpGet]
    public async Task<IActionResult> GetLotes()
    {
        var lotes = await _context.Lotes.ToListAsync();
        return Ok(lotes); // Retorna Status 200 e o JSON
    }

    // Equivalente ao @PostMapping
    [HttpPost]
    public async Task<IActionResult> Criar(LoteCarne lote)
    {
        lote.DataEntrada = DateTime.Now; // Preenche a data automaticamente

        _context.Lotes.Add(lote);
        await _context.SaveChangesAsync(); // Salva no banco de dados

        return CreatedAtAction(nameof(GetLotes), new {id = lote.Id }, lote); // Status 201 Created
    }
}
    
