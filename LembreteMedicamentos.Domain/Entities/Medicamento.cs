using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LembreteMedicamentos.Domain.Entities;
public class Medicamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Dosagem { get; set; }
}


