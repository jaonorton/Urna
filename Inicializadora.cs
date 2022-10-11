using Urna.CLI.DAO;
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

            // TODO: Faz sentido nulo ser um candidato
            CandidatoDAO.Candidatos.Add(new Candidato
            {
                Nome = "Nulo",
                Numero = 00,
                Partido = "Nulo"
            });
        }

        public void CriarUmEleitor()
        {
            for (int i = 0; i < 20; i++)
            {
                EleitorDAO.Eleitores.Add(new Eleitor
                {
                    Titulo = i.ToString("D3"),
                    JaVotou = false
                });
            }
        }
    }
}
