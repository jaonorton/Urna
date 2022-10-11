using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Urna.CLI.DAO;
using Urna.CLI.Models;
using Urna.CLI.Services;

namespace Urna.CLI
{
    public class MesarioController
    {
        MesarioService _mesarioService = new MesarioService();
        CandidatosServices _candidatosServices = new CandidatosServices();
        UrnaController _urnaController = new UrnaController();

        public void EmitirAZeresima()
        {
            List<Candidato> candidatos = _candidatosServices.BuscarCandidatos();

            Console.WriteLine("EMISSÃO DA ZERÉSIMA\n");
            foreach (var item in candidatos)
            {
                Console.WriteLine("Candidato: " + item.Nome + "  Votos: " + item.VotosRecebidos);
                Console.WriteLine("\n");
            }

            Console.WriteLine("\nZERÉSIMA EMITIDA, APERTE QUALQUER TECLA PARA CONTINUAR");
            Console.ReadLine();
            Console.Clear();
        }

        public void PegarOTitulo()
        {
            Console.Clear();
            Console.WriteLine("Insira o título de eleitor: ");
            string tituloDeEleitor = Console.ReadLine();

            Eleitor eleitor = _mesarioService.ObterEleitor(tituloDeEleitor);

            if (eleitor is null)
            {
                Console.WriteLine("Eleitor não encontrado");
            }
            else
            {
                if (eleitor.JaVotou)
                {
                    Console.WriteLine("\nVoto já computado");
                }
                else
                {
                    _urnaController.MenuVotacao(eleitor);
                }
            }
        }
    }
}
