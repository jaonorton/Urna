using System;
using System.Collections.Generic;
using System.Text;
using Urna.CLI.DAO;
using Urna.CLI.Models;

namespace Urna.CLI.Services
{
    public class UrnaService
    {
        CandidatosServices _candidatoServices = new CandidatosServices();
        public void ComputarOsVotosPresidente(int votoPresidente)
        {
            Candidato votado = _candidatoServices.BuscarCandidato(votoPresidente);

            VotosDAO.VotosTotais++;
            votado.VotosRecebidos++;
        }
    }
}
