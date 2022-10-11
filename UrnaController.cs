using System;
using System.Collections.Generic;
using Urna.CLI.Models;
using Urna.CLI.Services;

namespace Urna.CLI
{
    public class UrnaController
    {
        
        CandidatosServices _candidatosServices = new CandidatosServices();
        UrnaService _urnaService = new UrnaService();
        
        public void MostrarCandidatos()
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
            MenuInicialUrna();
        }

        public void MenuInicialUrna()
        {
            Console.Clear();
            Console.WriteLine("O que você gostaria?");
            Console.WriteLine("A - Votar");
            Console.WriteLine("B - Ver candidatos");

            string resposta = Console.ReadLine().ToLower();

            MesarioController mesario = new MesarioController();

            switch (resposta)
            {
                case "a":
                    mesario.PegarOTitulo();
                    break;
                case "b":
                    MostrarCandidatos(); // Criar um candidato controller pra ter esse método
                    break;
            }
        }

        public void MenuVotacao(Eleitor eleitor)  //Quero passar um eleitor
        {
            bool achouOPresidenciavel;
            bool confirmouOVoto = false;
            
            Console.Clear();

            do
            {

                Console.WriteLine("Voto para presidente:");
                int votoPresidente = int.Parse(Console.ReadLine());
            
                Candidato presidenciavel = _candidatosServices.BuscarCandidato(votoPresidente);

                if (presidenciavel is null)
                {
                    achouOPresidenciavel = false;
                    Console.WriteLine("Não foi encontrado o seu presidente, tente inserir o número novamente");
                }
                else
                {
                    achouOPresidenciavel = true;
                    confirmouOVoto = ConfirmarVoto(votoPresidente);
                    if (confirmouOVoto)
                    {
                        _urnaService.ComputarOsVotosPresidente(votoPresidente);
                    }
                    else
                    {
                        Console.WriteLine("Seu voto não foi confirmado, digite um novo número");
                    }
                }
            } while (!achouOPresidenciavel && !confirmouOVoto);

            eleitor.JaVotou = true;
        }

       
        bool ConfirmarVoto(int numeroVoto)
        {
            Candidato candidato = _candidatosServices.BuscarCandidato(numeroVoto);
            
            Console.WriteLine("\nConfirmar voto em " + candidato.Nome);
            Console.WriteLine("1 - CONFIRMA");
            Console.WriteLine("2 - CORRIGE");

            int confirmacao = int.Parse(Console.ReadLine());
            if (confirmacao == 1)
            {
                Console.WriteLine("\n*PIRILILILI*");
                Console.WriteLine("Voto confirmado");
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
