using System;

namespace CadastroPessoasT2
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }
        
        public string razaoSocial { get; set; }

        public override float PagarImposto(float rendimento)
        {
            throw new System.NotImplementedException();
        }
        
        public bool validarCnpj(string cnpj)
        {
            if (cnpj.Length == 14 && cnpj.Substring(8,4) == "0001")
            {
                return true;
            }
            
            return false;
                                
        }
        
    }
}