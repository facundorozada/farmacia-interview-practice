using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string PrincipioActivo { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateOnly FechaVencimiento { get; set; }
        public int LaboratorioId { get; set; }
        public bool Activo { get; set; }

        public Laboratorio Laboratorio { get; set; } = null!;
    }
}
