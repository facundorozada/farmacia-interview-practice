using Application.DTOs.Medicamentos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/medicamentos")]
    public class MedicamentosController : ControllerBase
    {
        private readonly IMedicamentoService _medicamentoService;

        public MedicamentosController(IMedicamentoService medicamentoService)
        {
            _medicamentoService = medicamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicamentoResponseDto>>> ObtenerTodos()
        {
            return Ok(await _medicamentoService.ObtenerTodosAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicamentoResponseDto>> ObtenerPorId(int id)
        {
            var medicamento = _medicamentoService.ObtenerPorIdAsync(id);

            if (medicamento == null) return NotFound();

            return Ok(medicamento);
        }

        [HttpPost]
        public async Task<ActionResult<MedicamentoResponseDto>> Crear(CrearMedicamentoDto dto)
        {
            return Ok(await _medicamentoService.CrearAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, ActualizarMedicamentoDto dto)
        {
            bool actualizado = await _medicamentoService.ActualizarAsync(id, dto);

            if (!actualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool eliminado = await _medicamentoService.EliminarAsync(id);

            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
