using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Laboratorio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public bool Activo { get; set; }

        public ICollection<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();
    }
}
