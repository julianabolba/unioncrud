namespace ProjSocial.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? CPF { get; set; }
        public string? Cidade { get; set; }
        public string? Telefone { get;  set; }
        public DateTime? DataNasc { get; set; }
        public string? Orientacao { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }


    }
}
