using System;

namespace CadastroPessoasT2
{
    class Program
    {
        static void Main(string[] args)
        {
          PessoaFisica pfMetodos = new PessoaFisica();

          PessoaFisica novaPf = new PessoaFisica();
          Endereco novoEndPf = new Endereco();

          novaPf.nome = "Ricardo";  
          novaPf.dataNascimento = new DateTime(2018,01,01);
          novaPf.cpf = "1234567890";
          novaPf.rendimento = 5000.35f;
        

          novoEndPf.logradouro = "Avenida Paulista";
          novoEndPf.numero = 900;
          novoEndPf.complemento = "Gazeta";
          novoEndPf.enderecoComercial = true;

          novaPf.endereco = novoEndPf;
        
         
/*
          Console.WriteLine(@$"
Nome : {novaPf.nome}
CPF : {novaPf.cpf}
Endereço : {novaPf.endereco.logradouro} , {novaPf.endereco.numero}
Complemento : {novaPf.endereco.complemento}
Maior de 18 anos : {pfMetodos.ValidarDataNascimento(novaPf.dataNascimento)}
Rendimento : {novaPf.rendimento}
");
*/

            PessoaJuridica pjMetodos = new PessoaJuridica();
            
            PessoaJuridica novaPj = new PessoaJuridica();
            Endereco novoEndPj = new Endereco();
            
            novaPj.nome = "XPTO Inc.";
            novaPj.cnpj = "12345678000134";
            novaPj.razaoSocial = "Razão Social de XPTO";
            novaPj.rendimento = 99999.55f;
          
            novoEndPj.logradouro = "Avenida Lins";
            novoEndPj.numero = 555;
            novoEndPj.complemento = "Vila Mariana";
            novoEndPj.enderecoComercial = true;
            
            novaPj.endereco = novoEndPj;


            //Console.WriteLine(novaPj.validarCnpj("12345678000134"));
          Console.WriteLine(@$"
Nome : {novaPj.nome}
Razão Social : {novaPj.razaoSocial}
CNPJ : {novaPj.cnpj}
CNPJ Válido : {pjMetodos.validarCnpj(novaPj.cnpj)}
Endereço : {novaPj.endereco.logradouro} , {novaPj.endereco.numero}
Complemento : {novaPj.endereco.complemento}
Rendimento : {novaPj.rendimento}



");

        }
    }
}
