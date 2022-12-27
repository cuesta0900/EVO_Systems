namespace EVO_WebAPI.Controllers{
    public class Departamento{
        public Departamento(){  }
        public Departamento(int id, string nome, string sigla){
            this.id = id;
            this.nome = nome;
            this.sigla = sigla;
        }

        public int id {get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }
    }
}