using Microsoft.EntityFrameworkCore;

namespace EVO_WebAPI.Controllers{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Departamento>()
                .HasData(new List<Departamento>(){
                    new Departamento(1, "Informática", "TI"),
                    new Departamento(2, "Segurança", "SEG"),
                    new Departamento(3, "Recursos Humanos", "RH"),
                    new Departamento(4, "Marketing", "MK"),
                    new Departamento(5, "Administrativo", "ADM"),
                });
            
            builder.Entity<Funcionario>()
                .HasData(new List<Funcionario>(){
                    new Funcionario(1, "Marta Kent", 33225555, 2),
                    new Funcionario(2, "Paula Isabela", 3354288, 1),
                    new Funcionario(3, "Laura Antonia", 566889, 3),
                    new Funcionario(4, "Luiza Maria", 656559, 4),
                   new Funcionario(5, "Lucas Machado", 6568541, 5),
                    new Funcionario(6, "Pedro Alvares", 45645445, 2),
                    new Funcionario(7, "Paulo José", 9874512, 4)
                });

        }
    }
}