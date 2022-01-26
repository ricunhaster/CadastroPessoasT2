using System;

namespace CadastroPessoasT2
{
    class Program
    {
        static void Main(string[] args)
        {
          PessoaFisica novaPf = new PessoaFisica();
        
          novaPf.nome = "Ricardo";
                  
          Console.WriteLine($"Nome : {novaPf.nome}");
          
            
        }
    }
}
