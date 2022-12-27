using EVO_WebAPI.Controllers;
using System.Threading.Tasks;
namespace EVO_WebAPI{
    public interface IRepository{
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //FUNCIONARIO
        Task<Funcionario[]> GetAllFuncionariosAsync(bool includeDepartamento);        
        Task<Funcionario[]> GetFuncionariosAsyncByDepartamentoId(int deptId, bool includeDepartamento);
        Task<Funcionario> GetFuncionarioAsyncById(int funcionarioId, bool includeDepartamento);
        
        //DEPARTAMENTO
        Task<Departamento[]> GetAllDepartamentosAsync();
        Task<Departamento> GetDepartamentoAsyncById(int deptId);
        Task UpdateBookAsyncDept(int deptId, Departamento model);
        Task UpdateBookAsyncFunc(int funcionarioId, Funcionario model);
    }
}