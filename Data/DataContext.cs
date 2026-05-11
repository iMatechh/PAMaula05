using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaHAS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client;

namespace CopaHAS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Jogador> TB_JOGADORES { get; set; }
        public DbSet<Estadio> TB_ESTADIOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogador>().ToTable("TB_JOGADORES");
            modelBuilder.Entity<Estadio>().ToTable("TB_ESTADIOS");

            modelBuilder.Entity<Jogador>().HasData
            (
                new Jogador() { Id = 1, Nome = "Hugo Souza", NumeroCamisa = 1, Posicao = "Goleiro", Status = Models.Enuns.StatusJogador.Titular },
                new Jogador() { Id = 2, Nome = "Yuri Alberto", NumeroCamisa = 9, Posicao = "Atacante", Status = Models.Enuns.StatusJogador.Titular },
                new Jogador() { Id = 3, Nome = "Danilo", NumeroCamisa = 2, Posicao = "Lateral Direito", Status = Models.Enuns.StatusJogador.Titular },
                new Jogador() { Id = 4, Nome = "Marquinhos", NumeroCamisa = 4, Posicao = "Zagueiro", Status = Models.Enuns.StatusJogador.Titular },
                new Jogador() { Id = 5, Nome = "Casemiro", NumeroCamisa = 5, Posicao = "Volante", Status = Models.Enuns.StatusJogador.Titular },
                new Jogador() { Id = 6, Nome = "Alex Sandro", NumeroCamisa = 6, Posicao = "Lateral Esquerdo", Status = Models.Enuns.StatusJogador.Titular },
                new Jogador() { Id = 7, Nome = "Lucas Paquetá", NumeroCamisa = 7, Posicao = "Meio Campo", Status = Models.Enuns.StatusJogador.Titular },
                new Jogador() { Id = 8, Nome = "Bruno Guimarães", NumeroCamisa = 8, Posicao = "Meio Campo", Status = Models.Enuns.StatusJogador.Reserva },
                new Jogador() { Id = 9, Nome = "Richarlison", NumeroCamisa = 10, Posicao = "Atacante", Status = Models.Enuns.StatusJogador.Titular },
                new Jogador() { Id = 10, Nome = "Vinicius Jr", NumeroCamisa = 11, Posicao = "Atacante", Status = Models.Enuns.StatusJogador.Titular },
                new Jogador() { Id = 11, Nome = "Rodrygo", NumeroCamisa = 19, Posicao = "Atacante", Status = Models.Enuns.StatusJogador.DepartamentoMedico },
                new Jogador() { Id = 12, Nome = "Alisson", NumeroCamisa = 23, Posicao = "Goleiro", Status = Models.Enuns.StatusJogador.NaoRelacionado }
            );

            modelBuilder.Entity<Estadio>().HasData
            (
                // 🇺🇸 Estados Unidos (11)
                new Estadio() { Id = 1, Nome = "MetLife Stadium", Cidade = "East Rutherford (NY/NJ)", Capacidade = 82500m },
                new Estadio() { Id = 2, Nome = "SoFi Stadium", Cidade = "Los Angeles (CA)", Capacidade = 70240m },
                new Estadio() { Id = 3, Nome = "AT&T Stadium", Cidade = "Arlington (TX)", Capacidade = 80000m },
                new Estadio() { Id = 4, Nome = "Mercedes-Benz Stadium", Cidade = "Atlanta (GA)", Capacidade = 71000m },
                new Estadio() { Id = 5, Nome = "NRG Stadium", Cidade = "Houston (TX)", Capacidade = 72220m },
                new Estadio() { Id = 6, Nome = "Levi's Stadium", Cidade = "Santa Clara (CA)", Capacidade = 68500m },
                new Estadio() { Id = 7, Nome = "Lumen Field", Cidade = "Seattle (WA)", Capacidade = 68740m },
                new Estadio() { Id = 8, Nome = "Lincoln Financial Field", Cidade = "Philadelphia (PA)", Capacidade = 69596m },
                new Estadio() { Id = 9, Nome = "Hard Rock Stadium", Cidade = "Miami (FL)", Capacidade = 65326m },
                new Estadio() { Id = 10, Nome = "GEHA Field at Arrowhead Stadium", Cidade = "Kansas City (MO)", Capacidade = 76416m },
                new Estadio() { Id = 11, Nome = "Gillette Stadium", Cidade = "Foxborough (MA)", Capacidade = 65878m },
                
                new Estadio() { Id = 12, Nome = "BC Place", Cidade = "Vancouver", Capacidade = 54500m },
                new Estadio() { Id = 13, Nome = "BMO Field", Cidade = "Toronto", Capacidade = 30000m },
                
                new Estadio() { Id = 14, Nome = "Estadio Azteca", Cidade = "Cidade do México", Capacidade = 87000m },
                new Estadio() { Id = 15, Nome = "Estadio BBVA", Cidade = "Monterrey", Capacidade = 53500m },
                new Estadio() { Id = 16, Nome = "Estadio Akron", Cidade = "Guadalajara", Capacidade = 49850m }
            );

            //Área para futuros inserts no banco de dados a partir de outras classes/objetos
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>()
                .HaveColumnType("varchar").HaveMaxLength(200);

            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings
                .Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        //Inserir as linhas "new Jogador(){ Id = 1, ..." das lista de jogadores

    }
}

