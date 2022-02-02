using System;

namespace CadastroPessoasT2
{
    class Program
    {
        static void Main(string[] args)
        {
          PessoaFisica pfMetodos = new PessoaFisica();

          PessoaFisica novaPf = new PessoaFisica();
          Endereco novoEnd = new Endereco();
          
          novaPf.nome = "Ricardo";  
          novaPf.dataNascimento = new DateTime(2020,01,01);
          novaPf.cpf = "1234567890";
          novaPf.rendimento = 5000.35f;

          novoEnd.logradouro = "Avenida Paulista";
          novoEnd.numero = 900;
          novoEnd.complemento = "Gazeta";
          novoEnd.enderecoComercial = true;

          novaPf.endereco = novoEnd;
          

          //Console.WriteLine($"Nome : {novaPf.nome}");
          //Console.WriteLine($"Endereço : {novaPf.endereco.logradouro}");
          //Console.WriteLine($"{novaPf.ValidarDataNascimento(novaPf.dataNascimento)}");
         
          Console.WriteLine(@$"
Nome : {novaPf.nome}
CPF : {novaPf.cpf}
Endereço : {novaPf.endereco.logradouro} , {novaPf.endereco.numero}
Complemento : {novaPf.endereco.complemento}
Rendimento : {novaPf.rendimento}
");
          
            
        }
    }
}
