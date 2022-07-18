using System.ComponentModel.DataAnnotations;

namespace HelpDeskService.Models
{
    public class UsuarioModel
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cargo { get; set; }
        public int IdMaquina { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public List<TicketModel> tickets { get; set; }

    }
}
