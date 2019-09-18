using _05_Fiap.Web.AspNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05_Fiap.Web.AspNet.Persistences
{
    public class OlimpiadasContext : DbContext
    {
        public DbSet<Time> Times { get; set; }
        public DbSet<Campeonato> Campeonato { get; set; }
        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Treinador> Treinador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar a tabela associativa

            //Configurar as chaves da tabela
            modelBuilder.Entity<CampeonatoTime>().HasKey(c => new { c.CampeonatoId, c.TimeId });

            //Configurar o relacionamento com o Campeonato
            modelBuilder.Entity<CampeonatoTime>().
                 HasOne(c => c.Campeonato).
                WithMany(c => c.Times).
                HasForeignKey(c => c.TimeId);
            //Configurar o relacionamento com o Time
            modelBuilder.Entity<CampeonatoTime>().
                HasOne(c => c.Time).
                WithMany(c => c.Campeonatos).
                HasForeignKey(c => c.CampeonatoId);               


            base.OnModelCreating(modelBuilder);
        }


        public OlimpiadasContext(DbContextOptions o) : base(o)
        {

        }
    }
}
