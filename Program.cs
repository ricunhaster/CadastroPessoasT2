using System;
using System.Collections.Generic;
using System.Threading;

namespace CadastroPessoasT2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();
            List<PessoaFisica> listaPf = new List<PessoaFisica>();

            Console.Clear();
            Console.WriteLine(@$"
================================================        
|     Bem vindo ao sistema de cadastro de      |
|     Pessoas Físicas e Pessoas Jurídicas      |
================================================       
");

            BarraCarregamento("Carregando");
            Console.ResetColor();

            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
  ==========================================
  |     Escolha uma das opções abaixo      |
  |----------------------------------------|
  |         1 - Pessoa Física              |
  |         2 - Pessoa Jurídica            |                 
  |                                        |
  |         0 - Sair                       |
  ==========================================
  ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":

                        string opcaoPf;
                        PessoaFisica pfMetodos = new PessoaFisica();

                        do
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine(@$"
  ==========================================
  |     Escolha uma das opções abaixo      |
  |----------------------------------------|
  |     1 - Cadastrar Pessoa Física        |
  |     2 - Listar Pessoas Físicas         |                 
  |                                        |
  |     0 - Voltar ao menu anterior        |
  ==========================================
  ");
                            Console.ResetColor();

                            opcaoPf = Console.ReadLine();

                            switch (opcaoPf)
                            {
                                case "1":
                                    PessoaFisica novaPf = new PessoaFisica();
                                    Endereco novoEndPf = new Endereco();

                                    Console.WriteLine($"Digite o nome da pessoa que deseja cadastrar");
                                    novaPf.nome = Console.ReadLine();

                                    bool dataValida;
                                    do
                                    {
                                        Console.WriteLine($"Digite a data de nascimento Ex: AAAA-MM-DD");
                                        DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

                                        dataValida = pfMetodos.ValidarDataNascimento(dataNascimento);

                                        if (dataValida)
                                        {
                                            novaPf.dataNascimento = dataNascimento;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"Data digitada inválida, digite uma data válida(Maior de 18 anos)");
                                            Console.ResetColor();
                                        }

                                    } while (dataValida == false);

                                    Console.WriteLine($"Digite o CPF");
                                    novaPf.cpf = Console.ReadLine();

                                    Console.WriteLine($"Digite o rendimento (somente números)");
                                    novaPf.rendimento = float.Parse(Console.ReadLine());

                                    Console.WriteLine($"Digite o logradouro");
                                    novoEndPf.logradouro = Console.ReadLine();

                                    Console.WriteLine($"Digite o número");
                                    novoEndPf.numero = int.Parse(Console.ReadLine());

                                    Console.WriteLine($"Digite o complemento(Aperte ENTER para vazio)");
                                    novoEndPf.complemento = Console.ReadLine();

                                    Console.WriteLine($"Este endereço é comercial (S/N)");
                                    string EndComercial = Console.ReadLine().ToUpper();
                                    if (EndComercial == "S")
                                    {
                                        novoEndPf.enderecoComercial = true;
                                    }
                                    else
                                    {
                                        novoEndPf.enderecoComercial = false;
                                    }

                                    novaPf.endereco = novoEndPf;

                                    listaPf.Add(novaPf);

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                                    Console.WriteLine($"Cadastro realizado com sucesso");
                                    Thread.Sleep(3000);
                                    break;

                                case "2":

                                    Console.Clear();

                                    if (listaPf.Count > 0)
                                    {
                                        foreach (PessoaFisica cadaItem in listaPf)
                                        {
                                            Console.WriteLine(@$"
Nome : {cadaItem.nome}
CPF : {cadaItem.cpf}
Endereço : {cadaItem.endereco.logradouro} , {cadaItem.endereco.numero}
Complemento : {cadaItem.endereco.complemento}
Maior de 18 anos : {(pfMetodos.ValidarDataNascimento(cadaItem.dataNascimento) ? "Sim" : "Não")}
Rendimento : {cadaItem.rendimento}
Taxa de imposto a ser paga: {pfMetodos.PagarImposto(cadaItem.rendimento).ToString("C")}
");
                                        }


                                        Console.WriteLine($"Digite 'Enter' para continuar");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine($"Lista vazia!");
                                        Console.ResetColor();
                                        Thread.Sleep(3000);
                                    }
                                    break;

                                case "0":
                                    break;

                                default:
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine($"Opção inválida, escolha uma opção válida");
                                    Console.ResetColor();
                                    Thread.Sleep(3000);
                                    break;
                            }
                        } while (opcaoPf != "0");

                        break;

                    case "2":

                        string opcaoPj;
                        PessoaJuridica pjMetodos = new PessoaJuridica();

                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(@$"
  ==========================================
  |     Escolha uma das opções abaixo      |
  |----------------------------------------|
  |     1 - Cadastrar Pessoa Jurídica      |
  |     2 - Listar Pessoas Jurídicas       |                 
  |                                        |
  |     0 - Voltar ao menu anterior        |
  ==========================================
  ");
                            Console.ResetColor();
                            opcaoPj = Console.ReadLine();

                            switch (opcaoPj)
                            {
                                case "1":
                                    PessoaJuridica novaPj = new PessoaJuridica();
                                    Endereco novoEndPj = new Endereco();
                                    Console.WriteLine($"Digite o nome da empresa que deseja cadastrar");

                                    novaPj.nome = Console.ReadLine();

                                    bool cnpjTest;

                                    do
                                    {
                                        
                                        Console.WriteLine($"Digite o CNPJ");
                                        string cnpjOk = Console.ReadLine();

                                        cnpjTest =  pjMetodos.ValidarCnpj(cnpjOk);
                                        if (cnpjTest)
                                        {
                                            novaPj.cnpj = cnpjOk;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"CNPJ inválido, digite um CNPJ válido");
                                            Console.ResetColor();
                                        }
                                    } while (cnpjTest == false);

                                    Console.WriteLine($"Digite a Razão Social");

                                    novaPj.razaoSocial = Console.ReadLine();

                                    Console.WriteLine($"Digite o Rendimento (somente números)");

                                    novaPj.rendimento = float.Parse(Console.ReadLine());

                                    Console.WriteLine($"Digite o logradouro");

                                    novoEndPj.logradouro = Console.ReadLine();

                                    Console.WriteLine($"Digite o número");

                                    novoEndPj.numero = int.Parse(Console.ReadLine());

                                    Console.WriteLine($"Digite o complemento, caso não exista tecle ENTER");

                                    novoEndPj.complemento = Console.ReadLine();

                                    Console.WriteLine($"O endereço é comercial? (S/N)");
                                    string endComercial = Console.ReadLine().ToUpper();

                                    if (endComercial == "S")
                                    {
                                        novoEndPj.enderecoComercial = true;
                                    }
                                    else
                                    {
                                        novoEndPj.enderecoComercial = false;
                                    }

                                    novaPj.endereco = novoEndPj;

                                    listaPj.Add(novaPj);

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine($"Cadastro realizado com sucesso!");
                                    Console.ResetColor();

                                    break;

                                case "2":

                                    Console.Clear();

                                    if (listaPj.Count > 0)
                                    {
                                        
                                    foreach (PessoaJuridica cadaItem in listaPj)
                                    {
                                        Console.WriteLine(@$"
Nome : {cadaItem.nome}
Razão Social : {cadaItem.razaoSocial}
CNPJ : {cadaItem.cnpj}
CNPJ Válido : {(pjMetodos.ValidarCnpj(cadaItem.cnpj) ? "Válido" : "Inválido")}
Endereço : {cadaItem.endereco.logradouro} , {cadaItem.endereco.numero}
Complemento : {cadaItem.endereco.complemento}
Rendimento : {cadaItem.rendimento}
Taxa de imposto a ser pago : {pjMetodos.PagarImposto(cadaItem.rendimento).ToString("C")}


");
                                    }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine($"Lista vazia!");
                                        Console.ResetColor();
                                        Thread.Sleep(3000);
                                    }

                                    //Thread.Sleep(3000);
                                    Console.WriteLine($"Digite 'Enter' para continuar");
                                    Console.ReadLine();

                                    break;

                                case "0":
                                    break;

                                default:
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine($"Opção inválida, escolha uma opção válida");
                                    Console.ResetColor();
                                    Thread.Sleep(3000);
                                    break;
                            }

                        } while (opcaoPj != "0");

                        //string cnpjValido = pjMetodos.ValidarCnpj(novaPj.cnpj) ? "Válido" : "Inválido";

                        //Console.WriteLine(novaPj.ValidarCnpj("12345678000134"));

                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine($"Obrigado por usar o nosso sistema!");
                        BarraCarregamento("Finalizando");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Opção inválida, escolha uma opção válida");
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        break;
                }

            } while (opcao != "0");
        }

        static void BarraCarregamento(string textoCarregamento)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write($"{textoCarregamento}");
            Thread.Sleep(500);

            for (var i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
        }

    }
}
