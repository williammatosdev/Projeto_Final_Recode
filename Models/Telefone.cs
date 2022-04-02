namespace CadastroElogin.Models
{
    public class Telefone
    {
        public int Id_tel { get; set; }
        public int Id_usuario { get; set; }
        public string Celeluar { get; set; }
        public Usuario Usuario { get; set; }
    }
}
