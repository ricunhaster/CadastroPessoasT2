using System;

namespace CadastroPessoasT2
{
    public class PessoaFisica  : Pessoa  
    {
        public string cpf { get; set; }
        
        public DateTime dataNascimento  { get; set; }

        public override float PagarImposto(float rendimento)
        {
            throw new NotImplementedException();
        }

        public bool ValidarDataNascimento(DateTime dataNasc) 
        {
            return true;
        }    
    }
}