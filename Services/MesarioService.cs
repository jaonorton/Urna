using System.Linq;
using Urna.CLI.DAO;
using Urna.CLI.Models;

namespace Urna.CLI.Services
{
    public class MesarioService
    {
        public Eleitor ObterEleitor(string tituloASerProcurado)
        {
            if(EleitorDAO.Eleitores.Any(x=>x.Titulo == tituloASerProcurado))
            {
                Eleitor eleitorASerEncontrado = EleitorDAO.Eleitores.Where(item => item.Titulo == tituloASerProcurado).First();
                return eleitorASerEncontrado;
            }

            return null;
        }
    }
}
