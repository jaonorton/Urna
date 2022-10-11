using System;
using System.Collections.Generic;
using System.Text;
using Urna.CLI.DAO;
using Urna.CLI.Mesário;
using Urna.CLI.Models;

namespace Urna.CLI.Services
{
    public class UrnaServices
    {
        public static Votos _votos = new Votos();
        static CandidatosServices _candidatosServices = new CandidatosServices();
        public static void MostrarCandidatos()
        {
            Console.Clear();
            List<Candidato> candidatos = _candidatosServices.BuscarCandidatos();

            foreach (var item in candidatos)
            {
                Console.WriteLine("Candidato: " + item.Nome);
                Console.WriteLine("Partido: " + item.Partido);
                Console.WriteLine("Número: " + item.Numero);
                Console.WriteLine("\n");
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar");
            Console.ReadLine();            
            MenuInicalUrna();

        }
        static public void MenuInicalUrna()
        {
            Console.Clear();
            Console.WriteLine("O que você gostaria?");
            Console.WriteLine("A - Votar");
            Console.WriteLine("B - Ver candidatos");

            string resposta = Console.ReadLine().ToLower();

            switch (resposta)
            {
                case "a":
                    MesarioService.PegarOTitulo();
                    break;
                case "b":
                    MostrarCandidatos();
                    break;

            }
        }
        static public void MenuVotacao(string tituloVotando)  //Quero passar um eleitor
        {
            Console.Clear();
            Console.WriteLine("Voto para presidente:");
            int votoPresidente = int.Parse(Console.ReadLine());
            ComputarOsVotos(votoPresidente, tituloVotando);
        }

        public static void ComputarOsVotos(int votoPresidente, string tituloVotando)
        {
            switch (votoPresidente)
            {
                case 13:
                    
                    bool confirmar1 = ConfirmarVoto(13);                //perguntar isso confirmar 1
                    if (confirmar1)
                    {
                        _votos.VotosLula++;
                        _votos.VotosTotais++;
                        //salvar que o eleitor votou
                        MenuInicalUrna(); //Erro desconhecido aqui
                    }
                    else
                    {
                        MenuVotacao(tituloVotando);
                    }
                    break;
                case 12:
                    bool confirmar2 = ConfirmarVoto(12);
                    if (confirmar2)
                    {
                        _votos.VotosSiru++;
                        _votos.VotosTotais++;
                        //Salvar que o eleitor votou
                        MenuInicalUrna();
                    }
                    else
                    {
                        MenuVotacao(tituloVotando);
                    }
                    break;
            }

            static bool ConfirmarVoto(int numeroVoto)
            {
                int confirmacao;
                Console.WriteLine("\nConfirmar voto em "); //puxar candidato pelo numero
                Console.WriteLine("1 - CONFIRMA");
                Console.WriteLine("2 - CORRIGE");
                confirmacao = int.Parse(Console.ReadLine());
                if (confirmacao == 1)
                {
                    Console.WriteLine("\n*PIRILILILI*");
                    Console.WriteLine("Voto confirmado");
                    Console.WriteLine("\nPressione qualquer tecla para inserir um novo título de eleitor");
                    Console.Read();
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
