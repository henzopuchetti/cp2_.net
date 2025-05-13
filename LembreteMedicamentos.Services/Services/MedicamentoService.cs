using LembreteMedicamentos.Data.Contexts;
using LembreteMedicamentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LembreteMedicamentos.Services.Services;

public class MedicamentoService
{
    private readonly AppDbContext _context;
    public MedicamentoService(AppDbContext context) => _context = context;

    public async Task<List<Medicamento>> GetAllAsync() => await _context.Medicamentos.ToListAsync();
    public async Task<Medicamento?> GetByIdAsync(int id) => await _context.Medicamentos.FindAsync(id);

    public async Task<Medicamento> CreateAsync(Medicamento medicamento)
    {
        _context.Medicamentos.Add(medicamento);
        await _context.SaveChangesAsync();
        return medicamento;
    }

    public async Task<bool> UpdateAsync(Medicamento medicamento)
    {
        _context.Entry(medicamento).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Medicamentos.FindAsync(id);
        if (entity == null) return false;
        _context.Medicamentos.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}
