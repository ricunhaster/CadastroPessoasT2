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
            return true;
        }
        
    }
}