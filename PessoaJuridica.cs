using System;
using System.Collections.Generic;
using System.IO;

namespace CadastroPessoasT2
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }
        
        public string razaoSocial { get; set; }

        public string caminho { get; private set; } = "Database/Pessoa Juridica.csv";

        public override float PagarImposto(float rendimento)
        {
           float taxa;
           if (rendimento <= 3000)
           {
               taxa = (rendimento / 100) * 3;
               return taxa;
           }
           else if (rendimento > 3000 && rendimento <= 6000)
           {
               taxa = (rendimento / 100) * 5;
               return taxa;
           }
           else if (rendimento > 6000 && rendimento <= 10000)
           {
               taxa = (rendimento / 100) * 7;
               return taxa;
           }
           else
           {
                taxa = (rendimento / 100) * 9;
                return taxa;
           }
           
        }
        
        public bool ValidarCnpj(string cnpj)
        {
            if (cnpj.Length == 14 && cnpj.Substring(8,4) == "0001")
            {
                return true;
            }
            
            return false;
                                
        }
        

        public string PreparaLinhaCsv(PessoaJuridica pj)
        {
            //string linha = $"{pj.nome};{pj.razaoSocial};{pj.cnpj}";
            //return linha;
            return $"{pj.nome};{pj.razaoSocial};{pj.cnpj}";
        }

        public void Inserir(PessoaJuridica pj)
        {
            string[] linhas = {PreparaLinhaCsv(pj)};  
              
            File.AppendAllLines(caminho, linhas);
        }

        public List<PessoaJuridica> Ler()
        {
        
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach (string cadaLinha in linhas)
            {
                
                string[] atributos = cadaLinha.Split(";");

                PessoaJuridica cadaPj = new PessoaJuridica();
                
                cadaPj.nome = atributos[0];
                cadaPj.razaoSocial = atributos[1];
                cadaPj.cnpj = atributos[2];
                
                listaPj.Add(cadaPj);

            }

            return listaPj;       
        }
    }
}