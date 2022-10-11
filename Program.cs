using System;
using System.Collections.Generic;
using Urna.CLI.Mesário;
using Urna.CLI.Models;
using Urna.CLI.Services;

namespace Urna.CLI
{
    public class Program
    {

        static void Main(string[] args)
        {
            Inicializadora inicializadora = new Inicializadora();   
            inicializadora.CriarCandidatos();                       //Cria os candidatos
            inicializadora.CriarUmEleitor();

            MesarioService.EmitirAZeresima();                       //Emite a zerésima

            UrnaServices.MenuInicalUrna();                          //Vai para a votação

        }

        
    }
}
