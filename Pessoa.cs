namespace CadastroPessoasT2
{
    public abstract class Pessoa
    {
        public string nome { get; set; }
        
        public Endereco endereco { get; set; }

        public float rendimento { get; set; }

        public abstract float PagarImposto(float rendimento);
        
    }
}