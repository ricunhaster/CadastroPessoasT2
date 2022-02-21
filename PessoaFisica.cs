using System;

namespace CadastroPessoasT2
{
    public class PessoaFisica  : Pessoa  
    {
        public string cpf { get; set; }
        
        public DateTime dataNascimento  { get; set; }

        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 1500)
            {
                return 0;
            }
            else if (rendimento > 1500 && rendimento <= 3500)
            {
                return rendimento * 0.02f;
                
            }
            else if (rendimento > 3500 && rendimento <= 6000)
            {
                return rendimento * .035f;                
            }
            else
            {
                return rendimento * 0.05f;   
            }
        }

        public bool ValidarDataNascimento(DateTime dataNasc) 
        {
            
            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 365;
            
            //Console.WriteLine($"{anos}");
            
            if (anos >= 18) 
            {
                return true;
            }   

            return false;
            
        }    
    }
}