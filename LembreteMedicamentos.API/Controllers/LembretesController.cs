using LembreteMedicamentos.Domain.Entities;
using LembreteMedicamentos.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace LembreteMedicamentos.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LembretesController : ControllerBase
{
    private readonly LembreteService _service;
    public LembretesController(LembreteService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _service.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Lembrete lembrete)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _service.CreateAsync(lembrete);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Lembrete lembrete)
    {
        if (id != lembrete.Id) return BadRequest();
        var result = await _service.UpdateAsync(lembrete);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }
}

