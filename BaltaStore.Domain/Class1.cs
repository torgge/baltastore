using System;

namespace BaltaStore.Domain
{
    public interface IPessoa
    {
        string Nome { get; set; }
        string Sobrenome { get; set; }
    }

    public interface IFuncionario
    {
        double Salario { get; set; }
    }
    
    public class Funcionario : IPessoa, IFuncionario
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public double Salario { get; set; }
    }
}
