namespace GerenciamentoFerias.Models
{
    public class Notificacao
    {
        public int Id { get; set; }
        public string Mensagem { get; set; } = string.Empty; 
        public DateTime DataEnvio { get; set; } 
        public bool Lida { get; set; } 
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}