using Microsoft.EntityFrameworkCore;

namespace WebCadastro.Models
{
    public class Ligacao : DbContext
    {
        public Ligacao(DbContextOptions<Ligacao> options) : base(options) { }

        public DbSet<CadastroPet> CadastroPet { get; set; }
    }
}
