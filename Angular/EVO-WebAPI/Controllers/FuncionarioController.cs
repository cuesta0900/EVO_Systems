using Microsoft.AspNetCore.Mvc;
using EVO_WebAPI.Data;
using System;

namespace EVO_WebAPI.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController: ControllerBase{
        private readonly IRepository _repo;
        public FuncionarioController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get(){
            try{

                var result = await _repo.GetAllFuncionariosAsync(true);
                return Ok(result);
            }catch(Exception ex){
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("Id/{funcionarioId}")]
        public async Task<IActionResult> GetFuncionarioId(int funcionarioId){
            try{
                var result = await _repo.GetFuncionarioAsyncById(funcionarioId, true);
                return Ok(result);
            }catch(Exception ex){
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByDept/{departamentoId}")]
        public async Task<IActionResult> GetByDepartamentoId(int departamentoId){
            try{

                var result = await _repo.GetFuncionariosAsyncByDepartamentoId(departamentoId, false);
                return Ok(result);
            }catch(Exception ex){
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Funcionario model){

                _repo.Add(model);
                if(await _repo.SaveChangesAsync()){
                    return Ok(model);
                }else{
                    return BadRequest();
                }
        }

        [HttpPut("{funcionarioId}")]
        public async Task<IActionResult> put(int funcionarioId, [FromBody] Funcionario model)
        {
            await _repo.UpdateBookAsyncFunc(funcionarioId, model);
            return Ok();
        }

        [HttpDelete("{funcionarioId}")]
        public async Task<IActionResult> delete(int funcionarioId){
            try{
                var func = await _repo.GetFuncionarioAsyncById(funcionarioId, false);
                if(func == null) return NotFound();
                _repo.Delete(func);
                if(await _repo.SaveChangesAsync()){
                    return Ok(func);
                }
            }catch(Exception ex){
                return BadRequest($"Erro: {ex.Message}");
            }return BadRequest("Deu Ruim! ;-;");
        }
    }
}