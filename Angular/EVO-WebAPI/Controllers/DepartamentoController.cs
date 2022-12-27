using Microsoft.AspNetCore.Mvc;
using EVO_WebAPI.Data;

namespace EVO_WebAPI.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController: ControllerBase{
        private readonly IRepository _repo;
        public DepartamentoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            try{

                var result = await _repo.GetAllDepartamentosAsync();
                return Ok(result);
            }catch(Exception ex){
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("Id/{deptId}")]
        public async Task<IActionResult> GetDepartamentoId(int deptId){
            try{
                var result = await _repo.GetDepartamentoAsyncById(deptId);
                return Ok(result);
            }catch(Exception ex){
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Departamento model){
            try{

                _repo.Add(model);
                if(await _repo.SaveChangesAsync()){
                    return Ok(model);
                }
            }catch(Exception ex){
                return BadRequest($"Erro: {ex.Message}");
            }return BadRequest("Deu Ruim! ;-;");
        }

        [HttpPut("{deptId}")]
        public async Task<IActionResult> put(int deptId, [FromBody] Departamento model)
        {
            await _repo.UpdateBookAsyncDept(deptId, model);
            return Ok();
        }

        [HttpDelete("{deptId}")]
        public async Task<IActionResult> delete(int deptId){
            try{
                var dept = await _repo.GetDepartamentoAsyncById(deptId);
                if(dept == null) return NotFound();
                _repo.Delete(dept);
                if(await _repo.SaveChangesAsync()){
                    return Ok(dept);
                }
            }catch(Exception ex){
                return BadRequest($"Erro: {ex.Message}");
            }return BadRequest("Deu Ruim! ;-;");
        }
    }
}