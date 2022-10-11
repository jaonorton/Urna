using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Urna.CLI.DAO;
using Urna.CLI.Models;
using Urna.CLI.Services;

namespace Urna.CLI.Mesário
{
    public class MesarioService
    {
        static CandidatosServices _candidatosServices = new CandidatosServices();

        public static void EmitirAZeresima()
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

        static public void PegarOTitulo()
        {
            Console.Clear();
            Console.WriteLine("Insira o título de eleitor:");
            string tituloDeEleitor = Console.ReadLine();

            bool votoJaComputado = JaVotou(tituloDeEleitor);

            if (votoJaComputado)
            {
                Console.WriteLine("\nVoto já computado");
                PegarOTitulo();
            }
            else
            {
                UrnaServices.MenuVotacao(tituloDeEleitor);
            }

        }
        public static bool JaVotou(string tituloASerProcurado)
        {
            //Eleitor eleitorASerEncontrado = EleitorDAO.Eleitores.Where(item => item.Titulo == tituloASerProcurado).First();
            return false;
        }

    }
}
