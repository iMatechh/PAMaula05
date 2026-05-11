using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CopaHAS.Models.Enuns;
using CopaHAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace CopaHAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadoresExercicioController : ControllerBase
    {
         private static List<Jogador> listaJogadores = new List<Jogador>()
        {
            new Jogador(){Id = 1, Nome = "Hugo Souza", NumeroCamisa=1, Posicao = "Goleiro", Status= Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 2, Nome = "Yuri Alberto", NumeroCamisa=1, Posicao = "Atacante", Status= Models.Enuns.statusJogador.Titular}, 
            new Jogador(){Id = 2, Nome = "Fagner", NumeroCamisa = 23, Posicao = "Lateral Direito", Status = Models.Enuns.statusJogador.Reserva},
            new Jogador(){Id = 3, Nome = "Gustavo Henrique", NumeroCamisa = 13, Posicao = "Zagueiro", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 4, Nome = "Félix Torres", NumeroCamisa = 3, Posicao = "Zagueiro", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 5, Nome = "Matheus Bidu", NumeroCamisa = 21, Posicao = "Lateral Esquerdo", Status = Models.Enuns.statusJogador.Reserva},
            new Jogador(){Id = 6, Nome = "Raniele", NumeroCamisa = 14, Posicao = "Volante", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 7, Nome = "Maycon", NumeroCamisa = 7, Posicao = "Meio Campo", Status = Models.Enuns.statusJogador.Reserva},
            new Jogador(){Id = 8, Nome = "Rodrigo Garro", NumeroCamisa = 10, Posicao = "Meia", Status = Models.Enuns.statusJogador.Reserva},
            new Jogador(){Id = 9, Nome = "Romero", NumeroCamisa = 11, Posicao = "Atacante", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 10, Nome = "Wesley", NumeroCamisa = 36, Posicao = "Atacante", Status = Models.Enuns.statusJogador.Titular},
        };

        // a
        [HttpGet("Nome/{nome}")]
            public IActionResult GetByNome(string nome)
        {

            List<Jogador> lista =
                listaJogadores.FindAll(j =>
                j.Nome.ToLower().Contains(nome.ToLower()));
            
           if(!lista.Any())
            return NotFound("Jogador não encontrado.");
            
            return Ok(lista);
        }

        // b
        [HttpGet("Titulares")]
        public IActionResult GetTitulares()
        {
            List<Jogador> titulares = listaJogadores.Where(j => j.Status == statusJogador.Titular).OrderByDescending(j => j.NumeroCamisa).ToList();
            return Ok(titulares);
        }

        // c
        [HttpGet("Estatisticas")]
        public IActionResult GetEstatisticas()
        {
            int quantidade = listaJogadores.Count;
            int somaCamisas = listaJogadores.Sum(j => j.NumeroCamisa);
            
            return Ok( new { QntddJogadores = quantidade, Soma = somaCamisas });
        }

        // d
        [HttpPost("ValidarCamisa")]
        public IActionResult PostValidacao(Jogador j)
        {
            if (j.NumeroCamisa > 100)
                return BadRequest("O número da camiseta não pode ser maior que 100, tente novamente.");

            listaJogadores.Add(j);
            return Ok(listaJogadores);
        }

        // e
        [HttpPost("PostValidacaoNome")]
        public IActionResult PostValidacaoNome(Jogador j)
        {
            if (j.Posicao != "goleiro" && j.NumeroCamisa == 1)
                return BadRequest("Apenas goleiros utilizam a camiseta com o número 1.");

            listaJogadores.Add(j);
            return Ok(listaJogadores);
        }

        // f
        [HttpGet("GetByStatus/{status}")]
        public IActionResult GetByStatus(string status)
        {
           statusJogador sj = statusJogador.Nenhum;
           switch (status.ToLower())
           {
               case "titular":
                   sj = statusJogador.Titular;
                   break;
                case "reserva":
                   sj = statusJogador.Reserva;
                   break;
                case "departamentomedico":
                   sj = statusJogador.DepartamentoMedico;
                   break;
                case "naorelacionado":
                   sj = statusJogador.NaoRelacionado;
                   break;
               default:
                   return BadRequest("Status inexistente.");
           }

            List<Jogador> jogadores = listaJogadores.FindAll(j => j.Status == sj);
            return Ok(jogadores);
        }
    }
}