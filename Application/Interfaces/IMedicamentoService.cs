using Application.DTOs.Medicamentos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IMedicamentoService
    {
        Task<List<MedicamentoResponseDto>> ObtenerTodosAsync();
        Task<MedicamentoResponseDto?> ObtenerPorIdAsync(int id);
        Task<MedicamentoResponseDto> CrearAsync(CrearMedicamentoDto dto);
        Task<bool> ActualizarAsync(int id, ActualizarMedicamentoDto dto);
        Task<bool> EliminarAsync(int id);
    }
}
