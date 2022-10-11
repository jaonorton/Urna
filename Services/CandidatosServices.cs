﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Urna.CLI.DAO;
using Urna.CLI.Models;

namespace Urna.CLI.Services
{
    public class CandidatosServices
    {
        public List<Candidato> BuscarCandidatos()         
        {
            return CandidatoDAO.Candidatos.OrderBy(x => x.Numero).ToList();
        }

    }
}
