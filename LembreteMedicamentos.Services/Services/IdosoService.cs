using LembreteMedicamentos.Data.Contexts;
using LembreteMedicamentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LembreteMedicamentos.Services.Services;

public class IdosoService
{
	private readonly AppDbContext _context;
	public IdosoService(AppDbContext context) => _context = context;

	public async Task<List<Idoso>> GetAllAsync() => await _context.Idosos.ToListAsync();
	public async Task<Idoso?> GetByIdAsync(int id) => await _context.Idosos.FindAsync(id);

	public async Task<Idoso> CreateAsync(Idoso idoso)
	{
		_context.Idosos.Add(idoso);
		await _context.SaveChangesAsync();
		return idoso;
	}

	public async Task<bool> UpdateAsync(Idoso idoso)
	{
		_context.Entry(idoso).State = EntityState.Modified;
		return await _context.SaveChangesAsync() > 0;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var entity = await _context.Idosos.FindAsync(id);
		if (entity == null) return false;
		_context.Idosos.Remove(entity);
		return await _context.SaveChangesAsync() > 0;
	}
}
