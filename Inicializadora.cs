﻿using Urna.CLI.DAO;
using Urna.CLI.Models;

namespace Urna.CLI
{
    public class Inicializadora
    {
        public void CriarCandidatos()
        {
            Candidato candidato1 = new Candidato();
            candidato1.Nome = "Lula";
            candidato1.Numero = 13;
            candidato1.Partido = "PT";

            Candidato candidato2 = new Candidato();
            candidato2.Nome = "Maçonaro";
            candidato2.Numero = 22;
            candidato2.Partido = "PL";

            CandidatoDAO.Candidatos.Add(candidato1);
            CandidatoDAO.Candidatos.Add(candidato2);
            CandidatoDAO.Candidatos.Add(new Candidato
            {
                Nome = "Siru",
                Numero = 12,
                Partido = "PDT"
            });
            CandidatoDAO.Candidatos.Add(new Candidato
            {
                Nome = "Nulo",
                Numero = 00,
                Partido = "Nulo"
            });
        }

        public void CriarUmEleitor()
        {
            EleitorDAO.Eleitores.Add(new Eleitor
            {
                Titulo = "000000000",
                JaVotou = true
            });

        }

    }
}
