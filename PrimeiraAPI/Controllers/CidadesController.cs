using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Models;
using PrimeiraAPI.Repository;
using System.ComponentModel.DataAnnotations;

namespace PrimeiraAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        private const string V = "paises/{idPais}/estados/{idEstado}/cidade";

        [HttpGet(V)]
        public List<Cidade> GetCidades(
            [FromQuery] string nome,
            [FromQuery, Range(100, 10000000)] int fromPopulacao
            )
        {
            var resultado = CidadesRepository.Cidades;

            if (string.IsNullOrEmpty(nome))
            {
                resultado = resultado.Where(cidade => cidade.Nome == nome).ToList();
            }

            if(fromPopulacao > 0)
            {
                resultado = resultado.Where(cidade => cidade.Populacao >= fromPopulacao).ToList();
            }
            return resultado;
            
        }
    }
}
