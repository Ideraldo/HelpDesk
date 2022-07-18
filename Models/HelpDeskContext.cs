using Microsoft.EntityFrameworkCore;
using HelpDeskService.Models;


namespace HelpDeskService.Models
{
    public class HelpDeskContext : DbContext
    {
        public HelpDeskContext(DbContextOptions options) : base(options)
        {
        }
      
        public DbSet<UsuarioModel>? usuarioModel { get; set; }
        public DbSet<TicketModel>? ticketModel { get; set; }
        public DbSet<ComentarioModel>? comentarioModel { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioModel>().ToTable("hd_usuarios");
            modelBuilder.Entity<UsuarioModel>().HasKey(x => x.IdUsuario);

            modelBuilder.Entity<UsuarioModel>().HasMany(x => x.tickets).WithOne(x => x.CriadoPor).HasForeignKey(x => x.IdUsuario);
            modelBuilder.Entity<UsuarioModel>().HasMany(x => x.tickets).WithOne(x => x.ResponsavelPeloTicket).HasForeignKey(x => x.IdResponsavel);

            modelBuilder.Entity<TicketModel>().ToTable("hd_tickets");
            modelBuilder.Entity<TicketModel>().HasKey(x => x.IdTicket);

            modelBuilder.Entity<TicketModel>().HasOne(x => x.CriadoPor).WithMany(x => x.tickets);
            modelBuilder.Entity<TicketModel>().HasOne(x => x.ResponsavelPeloTicket).WithMany(x => x.tickets);

            modelBuilder.Entity<TicketModel>().HasMany(x => x.Comentarios).WithOne(x => x.Ticket).HasForeignKey(x => x.IdTicket);

            modelBuilder.Entity<ComentarioModel>().ToTable("hd_comentarios");
            modelBuilder.Entity<ComentarioModel>().HasKey(x => x.IdComentario);

            modelBuilder.Entity<ComentarioModel>().HasOne(x => x.Ticket).WithMany(x => x.Comentarios);





        }

    }
}
