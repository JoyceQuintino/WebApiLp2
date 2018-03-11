namespace Laislp2.Models
{
    public class Crianca
    {
        public int Id {get; set;}
        public string Sexo {get; set;}
        public double Peso {get; set;}
        public string Apgar1 {get; set;}
        public string Apgar2 {get; set;}
        public Parto IdParto {get; set;}
        public Mae IdMae {get; set;}
    }
}