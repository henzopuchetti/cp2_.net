using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LembreteMedicamentos.Domain.Entities;
public class Lembrete
{
    public int Id { get; set; }
    public DateTime Horario { get; set; }
    public string Observacoes { get; set; }

    public int IdosoId { get; set; }
    public Idoso Idoso { get; set; }

    public int MedicamentoId { get; set; }
    public Medicamento Medicamento { get; set; }
}

