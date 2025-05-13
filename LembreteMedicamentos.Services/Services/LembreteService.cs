using LembreteMedicamentos.Data.Contexts;
using LembreteMedicamentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LembreteMedicamentos.Services.Services;
public class LembreteService
{
    private readonly AppDbContext _context;
    public LembreteService(AppDbContext context) => _context = context;

    public async Task<List<Lembrete>> GetAllAsync() =>
        await _context.Lembretes.Include(l => l.Medicamento).Include(l => l.Idoso).ToListAsync();

    public async Task<Lembrete> GetByIdAsync(int id) =>
        await _context.Lembretes.FindAsync(id);

    public async Task<Lembrete> CreateAsync(Lembrete lembrete)
    {
        _context.Lembretes.Add(lembrete);
        await _context.SaveChangesAsync();
        return lembrete;
    }

    public async Task<bool> UpdateAsync(Lembrete lembrete)
    {
        _context.Entry(lembrete).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var lembrete = await _context.Lembretes.FindAsync(id);
        if (lembrete == null) return false;
        _context.Lembretes.Remove(lembrete);
        return await _context.SaveChangesAsync() > 0;
    }
}

