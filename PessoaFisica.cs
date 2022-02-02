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
            
            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 365;
            
            Console.WriteLine($"{anos}");
            
            if (anos >= 18) 
            {
                return true;
            }   

            return false;
            
        }    
    }
}