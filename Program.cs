using System;
using System.Collections.Generic;
using Urna.CLI.Models;

namespace Urna.CLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Inicializadora inicializadora = new Inicializadora();   
            inicializadora.CriarCandidatos();
            inicializadora.CriarUmEleitor();

            MesarioController mesario = new MesarioController();
            mesario.EmitirAZeresima();

            // repetição enquanto houver eleitor que não tiver votado
            UrnaController urna = new UrnaController();
            urna.MenuInicialUrna();
        }
    }
}
