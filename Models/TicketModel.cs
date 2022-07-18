using HelpDeskService.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskService.Models
{
    public class TicketModel 
    {
      
        public Guid IdTicket { get; set; }
        public Prioridade Prioridade { get; set; }
        public TipoTicket TipoTicket { get; set; }
        public UsuarioModel CriadoPor { get; set; }
        public Guid IdUsuario { get; set; }
        public UsuarioModel ResponsavelPeloTicket { get; set; }
        public Guid IdResponsavel { get; set; }
        public List<ComentarioModel> Comentarios { get; set; }
        public Guid IdComentario { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public DateTime DataExclusao { get; set; }
        public StatusTicket StatusTicket { get; set; }
    }
}
