using System;

namespace CadastroPessoasT2
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }
        
        public string razaoSocial { get; set; }

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
        
    }
}