using System.Linq;
using System.Threading.Tasks;
using EVO_WebAPI.Controllers;
using Microsoft.EntityFrameworkCore;

namespace EVO_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Funcionario[]> GetAllFuncionariosAsync(bool includeDepartamento = false)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            if (includeDepartamento)
            {
                query = query.Include(pe => pe.Departamento);
            }

            return await query.ToArrayAsync();
        }
        public async Task<Funcionario> GetFuncionarioAsyncById(int funcionarioId, bool includeDepartamento)
        {
            
            IQueryable<Funcionario> query = _context.Funcionarios;

            if (includeDepartamento)
            {
                query = query.Include(pe => pe.Departamento);
            }
            
            query = query.AsNoTracking()
                         .OrderBy(funcionario => funcionario.id)
                         .Where(funcionario => funcionario.id == funcionarioId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Funcionario[]> GetFuncionariosAsyncByDepartamentoId(int deptId, bool includeDepartamento)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            if (includeDepartamento)
            {
                query = query.Include(p => p.Departamento);
            }

            query = query.AsNoTracking()
                         .OrderBy(funcionario => funcionario.id)
                         .Where(funcionario => funcionario.departamentoid == deptId);

            return await query.ToArrayAsync();
        }

        public async Task UpdateBookAsyncFunc(int funcionarioId, Funcionario model){
            var func = await _context.Funcionarios.FindAsync(funcionarioId);
            if(func != null){
                func.nome = model.nome;
                func.rg = model.rg;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Departamento[]> GetAllDepartamentosAsync()
        {
            IQueryable<Departamento> query = _context.Departamentos;

            query = query.AsNoTracking()
                         .OrderBy(Departamento => Departamento.id);

            return await query.ToArrayAsync();
        }
        public async Task<Departamento> GetDepartamentoAsyncById(int deptId)
        {
                IQueryable<Departamento> query = _context.Departamentos;
            
                query = query.AsNoTracking()
                            .OrderBy(Departamento => Departamento.id)
                            .Where(Departamento => Departamento.id == deptId);
                
                return await query.FirstOrDefaultAsync();
            
        }

        public async Task UpdateBookAsyncDept(int deptId, Departamento model){
            var dept = await _context.Departamentos.FindAsync(deptId);
            if(dept != null){
                dept.nome = model.nome;
                dept.sigla = model.sigla;
                await _context.SaveChangesAsync();
            }
        }

        
    }
}