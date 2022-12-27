namespace EVO_WebAPI.Controllers{
    public class Funcionario{
        
        public Funcionario(){  }
        public Funcionario(int id, string nome, int rg, int Departamentoid){
            this.id = id;
            this.nome = nome;
            this.rg = rg;
            this.departamentoid = Departamentoid;
        }

        public int id {get; set; }
        public string nome { get; set; }
        public int rg { get; set; }
        public int departamentoid { get; set; }
        public Departamento? Departamento { get; set; }
    }
}