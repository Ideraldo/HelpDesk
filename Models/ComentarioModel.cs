using System.ComponentModel.DataAnnotations;

namespace HelpDeskService.Models
{
    public class ComentarioModel
    {
        public Guid IdComentario { get; set; }
        public string Comentario { get; set; }
        public bool IsReagido { get; set; }
        public TicketModel Ticket { get; set; }
        public UsuarioModel Usuario { get; set; }
        public Guid IdTicket { get; set; }

    }
}
