using Domain.Entities;
using Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Services;
using System.Runtime.InteropServices;

namespace Tests.Services
{
    public class MedicamentoServiceTests
    {
        [Fact]
        public async Task ObtenerPorIdAsync_SiExiste_DevuelveMedicamento()
        {
            // ARRANGE
            var repositoryMock = new Mock<IMedicamentoRepository>();

            Medicamento medicamento = new Medicamento
            {
                Id = 1
            };

            repositoryMock
                .Setup(repository => repository.ObtenerPorIdAsync(1))
                .ReturnsAsync(medicamento);

            // ACT
            var service = new MedicamentoService(repositoryMock.Object);

            var resultado = service.ObtenerPorIdAsync(1);


            // ASSERT
            Assert.NotNull(resultado);

            Assert.Equal(1, resultado.Id);
        }
    }
}
