using System.Collections.Generic;

namespace CadastroElogin.Models
{
    public class Usuario
    {
        public int Id_usuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Senha { get; set; }

        public ICollection<Telefone> telefones { get; set; }
    }
}
