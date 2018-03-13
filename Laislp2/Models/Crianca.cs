namespace Laislp2.Models
{
    public class Crianca
    {
        public int Id {get; set;}
        public string Sexo {get; set;}
        public double Peso {get; set;}
        public string Apgar1 {get; set;}
        public string Apgar2 {get; set;}
        public int IdParto {get; set;}
        public int IdMae {get; set;}
    }
}