using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Repositories
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private readonly List<Medicamento> _medicamentos =
        [
            new Medicamento
            {
                Id = 1,
                Nombre = "Analgex 500",
                PrincipioActivo = "Paracetamol",
                Precio = 4500,
                Stock = 120,
                FechaVencimiento = new DateOnly(2027, 12, 31),
                LaboratorioId = 1,
                Activo = true,
                Laboratorio = new Laboratorio
                {
                    Id = 1,
                    Nombre = "Laboratorio Andino",
                    Pais = "Argentina",
                    Activo = true
                }
            },
            new Medicamento
            {
                Id = 2,
                Nombre = "Ibuflex 400",
                PrincipioActivo = "Ibuprofeno",
                Precio = 5200,
                Stock = 80,
                FechaVencimiento = new DateOnly(2027, 10, 15),
                LaboratorioId = 2,
                Activo = true,
                Laboratorio = new Laboratorio
                {
                    Id = 2,
                    Nombre = "Salud Pharma",
                    Pais = "Uruguay",
                    Activo = true
                }
            },
            new Medicamento
            {
                Id = 3,
                Nombre = "Alerfin",
                PrincipioActivo = "Loratadina",
                Precio = 3900,
                Stock = 55,
                FechaVencimiento = new DateOnly(2028, 3, 20),
                LaboratorioId = 3,
                Activo = true,
                Laboratorio = new Laboratorio
                {
                    Id = 3,
                    Nombre = "BioSur",
                    Pais = "Argentina",
                    Activo = true
                }
            }
        ];

        public Task<List<Medicamento>> ObtenerTodosAsync()
        {
            return Task.FromResult(_medicamentos.ToList());
        }

        public Task<Medicamento?> ObtenerPorIdAsync(int id)
        {
            Medicamento? medicamento =
                _medicamentos.FirstOrDefault(m => m.Id == id);

            return Task.FromResult(medicamento);
        }

        public Task<Medicamento> CrearAsync(Medicamento medicamento)
        {
            medicamento.Id = _medicamentos.Count == 0
                ? 1
                : _medicamentos.Max(m => m.Id) + 1;

            _medicamentos.Add(medicamento);

            return Task.FromResult(medicamento);
        }

        public Task<bool> ActualizarAsync(Medicamento medicamento)
        {
            Medicamento? medicamentoExistente = _medicamentos.FirstOrDefault(m => m.Id == medicamento.Id);

            if (medicamentoExistente == null)
                return Task.FromResult(false);

            medicamentoExistente.Nombre = medicamento.Nombre;
            medicamentoExistente.PrincipioActivo = medicamento.PrincipioActivo;
            medicamentoExistente.Precio = medicamento.Precio;
            medicamentoExistente.Stock = medicamento.Stock;
            medicamentoExistente.FechaVencimiento = medicamento.FechaVencimiento;
            medicamentoExistente.LaboratorioId = medicamento.LaboratorioId;
            medicamentoExistente.Activo = medicamento.Activo;

            return Task.FromResult(true);
        }

        public Task<bool> EliminarAsync(int id)
        {
            Medicamento? medicamentoExistente = _medicamentos.FirstOrDefault(m => m.Id == id);

            if (medicamentoExistente == null)
                return Task.FromResult(false);

            _medicamentos.Remove(medicamentoExistente);

            return Task.FromResult(true);
        }
    }
}
