using Application.DTOs.Medicamentos;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IMedicamentoRepository _medicamentoRepository;

        public MedicamentoService(IMedicamentoRepository medicamentoRespository)
        {
            _medicamentoRepository = medicamentoRespository;
        }

        public async Task<List<MedicamentoResponseDto>> ObtenerTodosAsync()
        {
            List<Medicamento> medicamentos = await _medicamentoRepository.ObtenerTodosAsync();

            return medicamentos.Select(m => new MedicamentoResponseDto
            {
            Id = m.Id,
            Nombre = m.Nombre,
            PrincipioActivo = m.PrincipioActivo,
            Precio = m.Precio,
            Stock = m.Stock,
            FechaVencimiento = m.FechaVencimiento,
            LaboratorioId = m.LaboratorioId,
            LaboratorioNombre = m.Laboratorio.Nombre,
            Activo = m.Activo
            }).ToList();
        }

        public async Task<MedicamentoResponseDto?> ObtenerPorIdAsync(int id)
        {
            Medicamento? m = await _medicamentoRepository.ObtenerPorIdAsync(id);

            if (m == null) return null;

            return new MedicamentoResponseDto
            {
                Id = m.Id,
                Nombre = m.Nombre,
                PrincipioActivo = m.PrincipioActivo,
                Precio = m.Precio,
                Stock = m.Stock,
                FechaVencimiento = m.FechaVencimiento,
                LaboratorioId = m.LaboratorioId,
                LaboratorioNombre = m.Laboratorio.Nombre,
                Activo = m.Activo
            };
        }

        public async Task<MedicamentoResponseDto> CrearAsync(CrearMedicamentoDto dto)
        {
            Medicamento medicamento = new Medicamento
            {
                Nombre = dto.Nombre,
                PrincipioActivo = dto.PrincipioActivo,
                Precio = dto.Precio,
                Stock = dto.Stock,
                FechaVencimiento = dto.FechaVencimiento,
                LaboratorioId = dto.LaboratorioId,
                Activo = true,
                Laboratorio = new Laboratorio { Id = dto.LaboratorioId }
            };

            medicamento = await _medicamentoRepository.CrearAsync(medicamento);

            return new MedicamentoResponseDto
            {
                Id = medicamento.Id,
                Nombre = medicamento.Nombre,
                PrincipioActivo = medicamento.PrincipioActivo,
                Precio = medicamento.Precio,
                Stock = medicamento.Stock,
                FechaVencimiento = medicamento.FechaVencimiento,
                LaboratorioId = medicamento.LaboratorioId,
                LaboratorioNombre = medicamento.Laboratorio.Nombre,
                Activo = medicamento.Activo
            };
        }
        
        public async Task<bool> ActualizarAsync(int id, ActualizarMedicamentoDto dto)
        {
            Medicamento? medicamento = await _medicamentoRepository.ObtenerPorIdAsync(id);

            if (medicamento == null) return false;

            medicamento.Nombre = dto.Nombre;
            medicamento.PrincipioActivo = dto.PrincipioActivo;
            medicamento.Precio = dto.Precio;
            medicamento.Stock = dto.Stock;
            medicamento.FechaVencimiento = dto.FechaVencimiento;
            medicamento.LaboratorioId = dto.LaboratorioId;
            medicamento.Activo = dto.Activo;
            medicamento.Laboratorio = new Laboratorio { Id = dto.LaboratorioId };

            return await _medicamentoRepository.ActualizarAsync(medicamento);
        }
        
        public async Task<bool> EliminarAsync(int id)
        {
            return await _medicamentoRepository.EliminarAsync(id);
        }
    }
}
