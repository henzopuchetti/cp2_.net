using LembreteMedicamentos.Domain.Entities;
using LembreteMedicamentos.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LembreteMedicamentos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdososController : ControllerBase
{
    private readonly IdosoService _service;
    public IdososController(IdosoService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _service.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Idoso idoso)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _service.CreateAsync(idoso);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Idoso idoso)
    {
        if (id != idoso.Id) return BadRequest();
        var result = await _service.UpdateAsync(idoso);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }
}
