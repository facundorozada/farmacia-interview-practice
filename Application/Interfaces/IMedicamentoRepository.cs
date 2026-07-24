using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMedicamentoRepository
    {
        Task<List<Medicamento>> ObtenerTodosAsync();
        Task<Medicamento?> ObtenerPorIdAsync(int id);
        Task<Medicamento> CrearAsync(Medicamento medicamento);
        Task<bool> ActualizarAsync(Medicamento medicamento);
        Task<bool> EliminarAsync(int id);
    }
}
